using Microsoft.Xna.Framework;

namespace Game.Scripts
{
    public class Field
    {
        private Vector2 _id;
        private Rectangle _rect;
        
        public Field(Vector2 id, Point rectOffset)
        {
            _id = id;
            _rect = new Rectangle(rectOffset, new Point(64, 64));
        }
        
        public Vector2 Id => _id;
        
        public Rectangle Rect => _rect;
    }
}