using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color) { }

        public override void GetMoveableFields()
        {
            int x = (int) _position.X;
            int y = (int)_position.Y;
            
            for (; x <= 7 && y <= 7; x++, y++)
            {
                if(x == _position.X && y == _position.Y)
                    continue;
                
                if(!AddField(x, y))
                    break;
            }
            
            x = (int) _position.X;
            y = (int)_position.Y;
            
            for (; x >= 0 && y >= 0; x--, y--)
            {
                if(x == _position.X && y == _position.Y)
                    continue;
                
                if(!AddField(x, y))
                    break;
            }
            
            x = (int) _position.X;
            y = (int)_position.Y;
            
            for (; x <= 7 && y >= 0; x++, y--)
            {
                if(x == _position.X && y == _position.Y)
                    continue;
                
                if(!AddField(x, y))
                    break;
            }
            
            x = (int) _position.X;
            y = (int)_position.Y;
            
            for (; x >= 0 && y <= 7; x--, y++)
            {
                if(x == _position.X && y == _position.Y)
                    continue;
                
                if(!AddField(x, y))
                    break;
            }
        }

        private bool AddField(int x, int y)
        {
            Field currentField = ResourceManager.Instance.Fields[x, y];
                    
            if(currentField == null)
                throw new Exception("currentField Is Null!");

            if (currentField.Piece != null)
            {
                if (currentField.Piece.Color == _color)
                    return false;
            }

            AddMoveableField(currentField.Id.ToPoint());
            return true;
        }
    }
}