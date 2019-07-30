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
        
        public Pawn(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color) : base(id, position, pixelPosition, texture, color)
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

        public void Move()
        {
            Field field = ResourceManager.Instance.Fields[(int) _position.X, (int) _position.Y];

            if (field.Piece != null)
            {
                if (field.Piece.Color != Color)
                {
                    // Kill the other piece.

                    field.Piece = this;

                    this._position = field.Id;
                }
            }
        }
    }
}