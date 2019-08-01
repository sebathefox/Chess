using System.Collections.Generic;
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
        private GameColor _color;

        protected Vector2 _position;

        protected List<Field> _moveableFields;

        public Piece(int id, Vector2 position, Vector2 pixelPosition, Texture2D texture, GameColor color)
        {
            _id = id;
            _position = position;
            _pixelPosition = pixelPosition;
            _texture = texture;
            _oldState = Keyboard.GetState();
            _color = color;
            _moveableFields = new List<Field>();
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
            spriteBatch.Draw(_texture, _pixelPosition, Microsoft.Xna.Framework.Color.White);
            spriteBatch.End();
        }

        public virtual void Move(Vector2 newPosition) { }

        public abstract void GetMoveableFields();

        public Vector2 PixelPosition => _pixelPosition;
        public Texture2D Texture => _texture;

        public GameColor Color
        {
            get { return _color; }
        }
    }
}