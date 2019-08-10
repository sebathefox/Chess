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
            for (int x = (int)_position.X, y = (int)_position.Y; x < 8 && y < 8; x++, y++)
            {
                if(!AddField(x, y))
                    break;
            }
            
            for (int x = (int)_position.X, y = (int)_position.Y; x >= 0 && y >= 0; x--, y--)
            {
                if(!AddField(x, y))
                    break;
            }
            
            for (int x = (int)_position.X, y = (int)_position.Y; x < 8 && y >= 0; x++, y--)
            {
                if(!AddField(x, y))
                    break;
            }
            
            for (int x = (int)_position.X, y = (int)_position.Y; x >= 0 && y < 8; x--, y++)
            {
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