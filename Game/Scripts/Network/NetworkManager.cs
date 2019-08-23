namespace Game.Scripts.Network
{
    public sealed class NetworkManager
    {
        private static NetworkManager _instance;

        private GameSocket _self;

        private SocketState _state;
        
        static NetworkManager()
        {
            if(_instance == null)
                _instance = new NetworkManager();
        }

        private NetworkManager()
        {
            _self = null;
            _state = SocketState.Client;
        }
        
        public static NetworkManager Instance => _instance;

        public GameSocket Self
        {
            get => _self;
            set => _self = value;
        }

        public SocketState State
        {
            get => _state;
            set => _state = value;
        }
        
        
    }
}