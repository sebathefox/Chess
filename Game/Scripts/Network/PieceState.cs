namespace Game.Scripts.Network
{
    public struct PieceState
    {
        private int _id;
        private GameColor _color;

        public PieceState(int id, GameColor color)
        {
            _id = id;
            _color = color;
        }
        
        public int Id => _id;

        public GameColor Color => _color;
    }
}