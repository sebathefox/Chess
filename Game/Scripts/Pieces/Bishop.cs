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
            for (int x = (int)_position.X, y = (int)_position.Y; x <= 7 && y <= 7; x++, y++)
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

        /// <summary>
        /// validates a field before adding it to the list of playable fields.
        /// </summary>
        /// <param name="x">The X position of the field</param>
        /// <param name="y">The Y position of the field</param>
        /// <returns>Whether it succeeded or not</returns>
        /// <exception cref="Exception">If it doesn't find any field at the position.</exception>
        private bool AddField(int x, int y)
        {
            Field currentField = ResourceManager.Instance.Fields[x, y];
            
                    
            if(currentField == null)
                throw new Exception("currentField Is Null!");

            if (currentField.Piece != null)
            {
                if (currentField.Piece.Position == _position)
                    return true;
                
                if (currentField.Piece.Color == _color)
                    return false;
            }

            AddMoveableField(ResourceManager.Instance.Fields[x, y].Id.ToPoint());
            return true;
        }
    }
}