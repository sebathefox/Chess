using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Game.Scripts.Network
{
    [Serializable]
    public class GameState : ISerializable
    {
        private GameColor _colorOfCurrentPlayer;

        private List<PieceState> _pieces;

        public GameState(GameColor color, List<PieceState> pieces)
        {
            _colorOfCurrentPlayer = color;
            _pieces = pieces;
        }
        
        public GameColor ColorOfCurrentPlayer
        {
            get { return _colorOfCurrentPlayer; }
        }

        public List<PieceState> Pieces
        {
            get { return _pieces; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("colorOfPlayer", _colorOfCurrentPlayer);
            info.AddValue("pieces", _pieces);
        }
    }
}