using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts.Pieces
{
    public class King : Piece
    {
        public King(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(position, pixelPosition, texture, color)
        {
        }

        public override void GetMoveableFields()
        {
            List<Point> points = new List<Point>(8);

            bool leftSide = false;
            bool topSide = false;
            bool rightSide = false;
            bool bottomSide = false;

            // Left side
            if (_position.X - 1 >= 0)
            {
                leftSide = true;
                points.Add(new Point((int)_position.X - 1, (int) _position.Y));
            }
            
            // Right side
            if (_position.X + 1 < 8)
            {
                points.Add(new Point((int)_position.X + 1, (int) _position.Y));
                rightSide = true;
            }

            // Top side
            if (_position.Y - 1 >= 0)
            {
                points.Add(new Point((int)_position.X, (int) _position.Y - 1));
                topSide = true;
            }

            // Bottom side
            if (_position.Y + 1 < 8)
            {
                points.Add(new Point((int)_position.X, (int) _position.Y + 1));
                bottomSide = true;
            }

            if (leftSide && topSide)
                points.Add(new Point((int)_position.X - 1, (int) _position.Y - 1));

            if(topSide && rightSide)
                points.Add(new Point((int)_position.X + 1, (int) _position.Y - 1));
            
            if(rightSide && bottomSide)
                points.Add(new Point((int)_position.X + 1, (int) _position.Y + 1));
            
            if(bottomSide && leftSide)
                points.Add(new Point((int)_position.X - 1, (int) _position.Y + 1));

            foreach (Point point in points)
            {
                AddMoveableField(point);
            }
        }
    }
}