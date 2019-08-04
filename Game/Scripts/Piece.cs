using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Game.Scripts
{
    public abstract class Piece : IPiece
    {
        protected int _id;
        
        
        protected bool _hasMoved;
        protected bool _selected;
        protected MouseState _oldMouseState;
        protected Vector2 _pixelPosition;
        private Texture2D _texture;
        protected GameColor _color;

        protected Vector2 _position;

        protected List<Field> _moveableFields;

        public Piece(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color)
        {
            _id = id;
            _position = position;
            _pixelPosition = pixelPosition;
            _texture = texture;
            _hasMoved = false;
            _selected = false;
            _oldMouseState = Mouse.GetState();
            _color = color;
            _moveableFields = new List<Field>();
        }
        
        public virtual void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            Rectangle rect = new Rectangle(_pixelPosition.ToPoint(), new Point(Texture.Height));
            
            if (rect.Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
                _oldMouseState.LeftButton == ButtonState.Released && _selected)
            {
                _selected = false;
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

            foreach (Field field in _moveableFields)
            {
                if (field.Rect.Contains(state.Position)  && state.LeftButton == ButtonState.Pressed &&
                    _oldMouseState.LeftButton == ButtonState.Released && _selected)
                {
                    Move(field);
                }
            }
            
            _moveableFields.Clear();
            
            _oldMouseState = state;
        }

        public virtual void Draw(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _pixelPosition, Microsoft.Xna.Framework.Color.White);
            spriteBatch.End();
        }

        protected void Move(Field moveableField)
        {
            if (moveableField.Piece != null)
            {
                if (moveableField.Piece.Color == Color)
                {
                    // Don't Move.
                }
            }
            
            // Kill the other piece.

            this._hasMoved = true;
            
            moveableField.Piece = this;

            this._position = moveableField.Id;

            this._pixelPosition = moveableField.Rect.Location.ToVector2();

            this._selected = false;
        }

        protected bool AddMoveableField(Point pos)
        {
            bool blockIsEmpty = true;
            bool blockOutOfBounds = true;
            
            if (_position.X >= 1 && _position.Y >= 1 && _position.X <= 7 && _position.Y <= 7)
            {
                blockOutOfBounds = false;

                foreach (Piece piece in ResourceManager.Instance.Players[0])
                {
                    if (pos == piece._position.ToPoint())
                    {
                        if (ResourceManager.Instance.Players[0].Color != _color)
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

        protected void FindFieldsHorizontal()
        {
            Point pos = _position.ToPoint();

            for (int i = 0; i < 7; i++)
            {
                pos.X += i;
                if(AddMoveableField(pos)) break;
            }

            pos = _position.ToPoint();
            
            for (int i = 0; i < 7; i++) {   
                pos.X -= 1;
                if (AddMoveableField(pos)) break;
            }
        }
        
        public abstract void GetMoveableFields();

        public Vector2 PixelPosition => _pixelPosition;
        public Texture2D Texture => _texture;

        public GameColor Color
        {
            get { return _color; }
        }
    }
}