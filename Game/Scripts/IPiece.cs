using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    public interface IPiece
    {
        void Update(GameTime gameTime);

        void Draw(ref SpriteBatch spriteBatch);
        
        Vector2 PixelPosition { get; }
        
        Texture2D Texture { get; }
    }
}