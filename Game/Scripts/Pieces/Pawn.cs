using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color) { }
        
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
                    
                    if(_position.Y - 2 >= 0)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X, (int)_position.Y - 2]);

                    
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
                    
                    if(_position.Y + 2 <= 7)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X, (int)_position.Y + 2]);
                    
                    if(_position.X + 1 <= 7)
                        fields.Add(ResourceManager.Instance.Fields[(int)_position.X + 1, (int)_position.Y + 1]);
                }
            }

            foreach (Field field in fields)
            {
                AddMoveableField(field.Id.ToPoint());
            }
        }
    }
}