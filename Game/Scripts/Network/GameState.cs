using System.Collections.Generic;

namespace Game.Scripts.Network
{
    public class GameState
    {
        private GameColor _colorOfCurrentPlayer;

        private List<Piece> _pieces;

        public GameState(GameColor color, List<Piece> pieces)
        {
            _colorOfCurrentPlayer = color;
            _pieces = pieces;
        }
        
        public GameColor ColorOfCurrentPlayer
        {
            get { return _colorOfCurrentPlayer; }
        }

        public List<Piece> Pieces
        {
            get { return _pieces; }
        }
    }
}