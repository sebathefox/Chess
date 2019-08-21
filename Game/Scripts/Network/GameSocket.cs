using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Game.Scripts.Network
{
    public enum SocketState
    {
        Client = 0x0,
        Server = 0x1
    }
    
    public class GameSocket
    {
        private Socket _socket;
        private SocketState _socketState;

        public GameSocket(SocketState state, IPEndPoint ep)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            if (state == SocketState.Client)
            {
                try
                {
                    _socket.Connect(ep);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    _socket.Dispose();
                    throw new DivideByZeroException("Sorry, you did not divide by zero it was because of an invalid argument...");
                }
            }
            else
            {
                _socket.Bind(ep);
                _socket.Listen(1);
            }
        }

        public SocketState GetSocketState() => _socketState;

        public void SendChange(GameState state)
        {
            
        }

        public GameState PollState()
        {
            return null;
        }
    }
}