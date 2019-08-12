using System.Net.Sockets;

namespace Game.Scripts.Network
{
    public class GameSocket
    {
        private Socket _client;
        private Socket _server;

        public GameSocket()
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void SendChange(GameState state)
        {
            
        }
    }
}