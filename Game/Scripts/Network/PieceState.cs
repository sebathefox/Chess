using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Microsoft.Xna.Framework;

namespace Game.Scripts.Network
{
    public struct PieceState
    {
        private int _id;
        private GameColor _color;
        private Vector2 _newPosition;

        public PieceState(int id, GameColor color, Vector2 newPosition)
        {
            _id = id;
            _color = color;
            _newPosition = newPosition;
        }
        
        public int Id => _id;

        public GameColor Color => _color;

        public Vector2 NewPosition => _newPosition;
        
    }
}