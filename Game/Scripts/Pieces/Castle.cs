using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts.Pieces
{
    public class Castle : Piece
    {
        public Castle(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color) { }

        public override void GetMoveableFields()
        {
            
        }
    }
}