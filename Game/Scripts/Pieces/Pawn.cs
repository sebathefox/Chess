using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Scripts.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        private bool _selected;
        
        public Pawn(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture) : base(id, position, pixelPosition, texture)
        {
            _hasMoved = false;
            _selected = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Move(Vector2 newPosition)
        {
            base.Move(newPosition);
        }
    }
}