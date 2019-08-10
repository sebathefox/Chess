using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Scripts
{
    /// <summary>
    /// Defines the two colors in regular Chess.
    /// </summary>
    public enum GameColor
    {
        Black,
        White
    }
    
    /// <summary>
    /// Defines the player which is used to hold the pieces and color. It is also used as a middleman that draws all of the of the pieces for the game.
    /// </summary>
    public class Player : IEnumerable
    {
        private Piece[] _pieces;

        private GameColor _color;

        /// <summary>
        /// Creates a new Player.
        /// </summary>
        /// <param name="color">The Color of the Player</param>
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

        /// <summary>
        /// Draws the player's pieces into the backbuffer.
        /// </summary>
        /// <param name="spriteBatch">The graphics engine entrypoint.</param>
        public void Draw(ref SpriteBatch spriteBatch)
        {
            foreach (Piece piece in _pieces)
            {
                piece?.Draw(ref spriteBatch);
            }
        }

        /// <summary>
        /// "Kills" a piece and removes it from the board.
        /// </summary>
        /// <param name="piece">The index of the piece to remove.</param>
        public void KillPiece(int piece)
        {

            ResourceManager.Instance.Fields[(int) _pieces[piece].Position.X, (int) _pieces[piece].Position.Y].Piece = null;
            
            _pieces[piece] = null;
            
        }
        
        /// <summary>
        /// Indexer to get the player's pieces. 
        /// </summary>
        /// <param name="index">The index of the Piece.</param>
        public Piece this[int index] { get => _pieces[index];  set => _pieces[index] = value; }

        /// <summary>
        /// Gets the Color of the player.
        /// </summary>
        public GameColor Color => _color;
        
        public IEnumerator GetEnumerator()
        {
            return _pieces.GetEnumerator();
        }
    }
}