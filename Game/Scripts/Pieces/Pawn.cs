using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Scripts.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        private bool _selected;
        private MouseState _oldMouseState;
        
        public Pawn(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color)
        {
            _hasMoved = false;
            _selected = false;
            _oldMouseState = Mouse.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            
            if (new Rectangle(_pixelPosition.ToPoint(), new Point(Texture.Height)).Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
                _oldMouseState.LeftButton == ButtonState.Released && _selected)
            {
                _selected = false;
            }
            else if (new Rectangle(_pixelPosition.ToPoint(), new Point(Texture.Height)).Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
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
            
            base.Update(gameTime);
        }

        public override void Move(Vector2 newPosition)
        {
            base.Move(newPosition);
        }

        public override void GetMoveableFields()
        {
            for (int i = 0; i < 4; i++)
            {
                Field field = null;

                if (_position.X >= 0 && _position.Y >= 0 && _position.X <= 8 && _position.Y <= 8)
                {
                    if (i < 3)
                    {
                        field = ResourceManager.Instance.Fields[(int) (_position.X - 1) + i, (int) _position.Y + 1];
                    }
                    else if (!_hasMoved)
                    {
                        field = ResourceManager.Instance.Fields[(int) _position.X, (int) _position.Y + 2];
                    }


                    if (field != null)
                    {
                        if (field.Piece != null)
                        {
                            if (field.Piece.Color != Color)
                                _moveableFields.Add(field);
                        }
                        else
                            _moveableFields.Add(field);
                    }
                }
            }
        }

        public void Move(Field moveableField)
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
    }
}