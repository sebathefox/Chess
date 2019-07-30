using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    public enum GameColor
    {
        Black,
        White
    }
    
    public class Player
    {
        private Piece[] _pieces;

        private GameColor _color;

        public Player(GameColor color)
        {
            _color = color;

            switch (color)
            {
                case GameColor.Black:
                    _pieces = LayoutFactory.GenerateBlack();
                    break;
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            foreach (Piece piece in _pieces)
            {
                if(piece == null)
                    continue;
                
                piece.Draw(ref spriteBatch);
            }
        }
        

        public Piece this[int index] => _pieces[index];

        public GameColor Color => _color;
    }
}