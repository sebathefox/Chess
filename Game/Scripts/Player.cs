using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    public enum GameColor
    {
        Black,
        White
    }
    
    public class Player : IEnumerable
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
                case GameColor.White:
                    _pieces = LayoutFactory.GenerateWhite();
                    break;
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            foreach (Piece piece in _pieces)
            {
                piece?.Draw(ref spriteBatch);
            }
        }

        public void KillPiece(int piece)
        {
            _pieces[piece] = null;
        }
        

        public Piece this[int index] { get => _pieces[index];  set => _pieces[index] = value; }

        public GameColor Color => _color;

        public Piece[] Pieces { get => _pieces; set => _pieces = value; }
        
        public IEnumerator GetEnumerator()
        {
            return _pieces.GetEnumerator();
        }
    }
}