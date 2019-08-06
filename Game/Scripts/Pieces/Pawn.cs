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
        public Pawn(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(position, pixelPosition, texture, color) { }

//        public override void Update(GameTime gameTime)
//        {
//            MouseState state = Mouse.GetState();
//
//            Rectangle rect = new Rectangle(_pixelPosition.ToPoint(), new Point(Texture.Height));
//            
//            if (rect.Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
//                _oldMouseState.LeftButton == ButtonState.Released && _selected)
//            {
//                _selected = false;
//            }
//            else if (rect.Contains(state.Position) && state.LeftButton == ButtonState.Pressed &&
//                _oldMouseState.LeftButton == ButtonState.Released)
//            {
//                _selected = true;
//            }
//
//
//            if (_selected && _moveableFields.Count < 1)
//            {
//                GetMoveableFields();
//            }
//
//            foreach (Field field in _moveableFields)
//            {
//                if (field.Rect.Contains(state.Position)  && state.LeftButton == ButtonState.Pressed &&
//                    _oldMouseState.LeftButton == ButtonState.Released && _selected)
//                {
//                    Move(field);
//                }
//            }
//            
//            _moveableFields.Clear();
//            
//            _oldMouseState = state;
//        }

        public override void GetMoveableFields()
        {
            List<Field> fields = new List<Field>();

            if (_color == GameColor.White)
            {
                if (_position.Y - 1 >= 0)
                {
                    if(_position.X - 1 >= 0)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X - 1, (int)_position.Y - 1]);
                    fields.Add(ResourceManager.Instance.Fields[(int)_position.X, (int)_position.Y - 1]);
                    
                    if(_position.X + 1 <= 7)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X + 1, (int)_position.Y - 1]);
                }
            }
            else
            {
                if (_position.Y + 1 <= 7)
                {
                    if(_position.X - 1 >= 0)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X - 1, (int)_position.Y + 1]);
                    fields.Add(ResourceManager.Instance.Fields[(int)_position.X, (int)_position.Y + 1]);
                    
                    if(_position.X + 1 <= 7)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X + 1, (int)_position.Y + 1]);
                }
            }

            foreach (Field field in fields)
            {
                AddMoveableField(field.Id.ToPoint());
            }
            
            
            
//            for (int i = 0; i < 4; i++)
//            {
//                Field field = null;
//                
//                if (_position.X >= 0 && _position.Y >= 0 && _position.X <= 7 && _position.Y <= 7)
//                {
//                    if (i < 3)
//                    {
//                        if(_position.X - i > 0 && _position.Y - i > 0 && _position.X + i <= 7 && _position.Y + i <= 7)
//                            field = ResourceManager.Instance.Fields[(int) (_position.X - 1) + i, (int) _position.Y + 1];
//                    }
//                    else if (!_hasMoved)
//                    {
//                        field = ResourceManager.Instance.Fields[(int) _position.X, (int) _position.Y + 2];
//                    }
//
//
//                    if (field != null)
//                    {
//                        if (field.Piece != null)
//                        {
//                            if (field.Piece.Color != Color)
//                                AddMoveableField(field.Id.ToPoint());
//                        }
//                        else
//                            AddMoveableField(field.Id.ToPoint());
//                    }
//                }
//            }
        }
    }
}