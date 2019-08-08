using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts.Pieces
{
    public class Knight : Piece
    {
        public Knight(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color) { }

        public override void GetMoveableFields()
        {
            List<Point> possiblePositions = new List<Point>();
            
            // Top-left quarter

            if (_position.X - 2 >= 0 && _position.Y - 1 >= 0)
            {
                possiblePositions.Add(new Point((int) _position.X - 2, (int) _position.Y - 1));
                
                if (_position.X - 1 >= 0 && _position.Y - 2 >= 0)
                {
                    possiblePositions.Add(new Point((int) _position.X - 1, (int) _position.Y - 2));
                }
            }

            if (_position.X + 1 < 8 && _position.Y - 2 >= 0)
            {
                // Top-right quarter
                possiblePositions.Add(new Point((int) _position.X + 1, (int) _position.Y - 2));
                
                if(_position.X + 2 < 8 && _position.Y - 1 >= 0)
                    possiblePositions.Add(new Point((int) _position.X + 2, (int) _position.Y - 1));
            }

            if (_position.X + 2 < 8 && _position.Y + 1 < 8)
            {
                // Bottom-right quarter
                possiblePositions.Add(new Point((int) _position.X + 2, (int) _position.Y + 1));
                
                if(_position.X + 1 < 8 && _position.Y + 2 < 8)
                    possiblePositions.Add(new Point((int) _position.X + 1, (int) _position.Y + 2));
            }

            if (_position.X - 1 >= 0 && _position.Y + 2 < 8)
            {
                // Bottom-left quarter
                possiblePositions.Add(new Point((int) _position.X - 1, (int) _position.Y + 2));
                
                if(_position.X - 2 >= 0 && _position.Y + 1 < 8)
                    possiblePositions.Add(new Point((int) _position.X - 2, (int) _position.Y + 1));
            }
            
            foreach (Point point in possiblePositions)
            {
                AddMoveableField(point);
            }
        }
    }
}