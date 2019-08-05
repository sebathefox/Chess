using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    public class Field
    {
        private Vector2 _id;
        private Rectangle _rect;

        private Texture2D _hover;

        private bool _hoverEnabled;
        
        private Piece _piece;
        
        public Field(Vector2 id, Point rectOffset)
        {
            _id = id;
            _rect = new Rectangle(rectOffset, new Point(64, 64));
            _piece = null;
            _hover = ResourceManager.Instance.Textures["hover_field"];
            _hoverEnabled = false;
        }
        
        public Vector2 Id => _id;
        
        public Rectangle Rect => _rect;

        public Piece Piece
        {
            get => _piece;
            set => _piece = value;
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            if (_hoverEnabled)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(_hover, _rect, Color.CornflowerBlue);
                spriteBatch.End();
            }
        }
        
        public bool HoverEnabled { get => _hoverEnabled; set => _hoverEnabled = value; }
    }
}