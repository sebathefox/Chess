using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Game.Scripts
{
    /// <summary>
    /// The abstract base class all pieces must inherit.
    /// </summary>
    public abstract class Piece
    {
        protected bool _hasMoved;
        protected bool _selected;
        protected MouseState _oldMouseState;
        protected Vector2 _pixelPosition;
        private Texture2D _texture;
        protected GameColor _color;
        private int _id;

        protected Vector2 _position;

        protected List<Field> _moveableFields;

        /// <summary>
        /// Creates a new Piece if used as base constructer call.
        /// </summary>
        /// <param name="id">The player specific id of the piece</param>
        /// <param name="position">The 'virtual' position of the Piece</param>
        /// <param name="pixelPosition">The position in pixels of the Piece</param>
        /// <param name="texture">The Texture of the Piece</param>
        /// <param name="color">The Color of the Piece</param>
        public Piece(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color)
        {
            _position = position;
            _pixelPosition = pixelPosition;
            _texture = texture;
            _hasMoved = false;
            _selected = false;
            _oldMouseState = Mouse.GetState();
            _color = color;
            _moveableFields = new List<Field>();
            _id = id;
            ResourceManager.Instance.Fields[(int) _position.X, (int) _position.Y].Piece = this;
        }
        
        /// <summary>
        /// Runs every time the main gameloop reaches it's Update method.
        /// </summary>
        /// <param name="gameTime">The deltatime for the game.</param>
        public virtual void Update(GameTime gameTime)
        {
            if(_texture == null)
                return;
            
            MouseState state = Mouse.GetState();

            Rectangle rect = new Rectangle(_pixelPosition.ToPoint(), new Point(Texture.Height));
            
            if (rect.Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
                _oldMouseState.LeftButton == ButtonState.Released && _selected)
            {
                _selected = false;
                _moveableFields.Clear();
            }
            else if (rect.Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
                     _oldMouseState.LeftButton == ButtonState.Released)
            {
                _selected = true;
            }


            if (_selected && _moveableFields.Count < 1)
            {
                GetMoveableFields();
            }

            if(_selected && _moveableFields.Count > 0)
                for (int i = 0; i < _moveableFields.Count; i++)
                {
                    _moveableFields[i].HoverEnabled = true;
                    
                    if (_moveableFields[i].Rect.Contains(state.Position)  && state.LeftButton == ButtonState.Pressed &&
                        _oldMouseState.LeftButton == ButtonState.Released && _selected)
                    {
                        Move(_moveableFields[i]);
                    }
                }
            
            
            _oldMouseState = state;
        }

        public virtual void Draw(ref SpriteBatch spriteBatch)
        {
            if(_texture == null)
                return;
            
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _pixelPosition, Microsoft.Xna.Framework.Color.White);
            spriteBatch.End();

            foreach (Field field in _moveableFields)
            {
                field.Draw(ref spriteBatch);
            }
        }

        protected void Move(Field moveableField)
        {
            if (moveableField.Piece != null)
            {
                if (moveableField.Piece.Color == Color)
                {
                    // Don't Move.
                    _moveableFields.Clear();
                    return;
                }
                // Kill the other piece.
                
                moveableField.Piece.Kill();
            }

            this._selected = false;
            
            this._hasMoved = true;

            ResourceManager.Instance.Fields[(int) _position.X, (int) _position.Y].Piece = null;
            
            moveableField.Piece = this;

            this._position = moveableField.Id;

            this._pixelPosition = moveableField.Rect.Location.ToVector2();

            
            
            _moveableFields.Clear();
        }

        private void Kill()
        {
            int plr = -1;
            switch (_color)
            {
                case GameColor.Black:
                    plr = 0;
                    break;
                case GameColor.White:
                    plr = 1;
                    break;
            }
            
            ResourceManager.Instance.Players[plr].KillPiece(_id);
            _texture = null;
            _position = new Vector2(-1, -1);
            _pixelPosition = new Vector2(-64, -64);

        }

        protected bool AddMoveableField(Point pos)
        {
            bool blockIsEmpty = true;
            bool blockOutOfBounds = true;
            
            if (_position.X >= 0 && _position.Y >= 0 && _position.X <= 7 && _position.Y <= 7)
            {
                blockOutOfBounds = false;
                
                List<Piece> pieces = new List<Piece>();
                pieces.AddRange(ResourceManager.Instance.Players[0].Pieces);
                pieces.AddRange(ResourceManager.Instance.Players[1].Pieces);
                

                foreach (Piece piece in pieces)
                {
                    if (piece == null)
                        continue;
                    
                    if (pos == piece._position.ToPoint())
                    {
                        if (piece.Color != _color)
                        {
                            _moveableFields.Add(ResourceManager.Instance.Fields[pos.X, pos.Y]);
                        }

                        blockIsEmpty = false;
                        break;
                    }
                }
                
                if (blockIsEmpty)
                {
                    _moveableFields.Add(ResourceManager.Instance.Fields[pos.X, pos.Y]);
                }
            }

            return !blockIsEmpty || blockOutOfBounds;
        }
        
        public abstract void GetMoveableFields();

        public Texture2D Texture => _texture;

        public Vector2 Position => _position;

        public GameColor Color => _color;
    }
}