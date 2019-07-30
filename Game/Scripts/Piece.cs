using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Game.Scripts
{
    public abstract class Piece : IPiece
    {
        protected int _id;
        
        protected Vector2 _pixelPosition;
        private Texture2D _texture;
        private KeyboardState _oldState;

        protected Vector2 _position;

        public Piece(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture)
        {
            _id = id;
            _position = position;
            _pixelPosition = pixelPosition;
            _texture = texture;
            _oldState = Keyboard.GetState();
        }
        
        public virtual void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state[Keys.W] == KeyState.Down && _oldState[Keys.W] == KeyState.Up)
                _pixelPosition.Y -= 64;
            if (state[Keys.S] == KeyState.Down && _oldState[Keys.S] == KeyState.Up)
                _pixelPosition.Y += 64;
            if (state[Keys.A] == KeyState.Down && _oldState[Keys.A] == KeyState.Up)
                _pixelPosition.X -= 64;
            if (state[Keys.D] == KeyState.Down && _oldState[Keys.D] == KeyState.Up)
                _pixelPosition.X += 64;

            _oldState = state;
        }

        public virtual void Draw(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _pixelPosition, Color.White);
            spriteBatch.End();
        }

        public virtual void Move(Vector2 newPosition) { }

        public Vector2 PixelPosition => _pixelPosition;
        public Texture2D Texture => _texture;
    }
}