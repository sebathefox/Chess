using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

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

        private Socket _other;
        
        private SocketState _socketState;
        private bool _shuttingDown;

        private byte[] _buffer;

        private IFormatter _formatter;

        private Thread _receiver;
        
        public GameSocket(SocketState state, IPEndPoint ep, int bufferSize = 1024)
        {
            
            
            _formatter = new BinaryFormatter();
            
            _receiver = new Thread(ReceiveLoop);

            _socketState = state;
            
            _shuttingDown = false;
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
//                finally
//                {
//                    _shuttingDown = true;
//                    _formatter = null;
//                    _buffer = null;
//                    _receiver.Interrupt();
//                    _receiver = null;
//                    _socket.Dispose();
//                    _socket = null;
//                    throw new DivideByZeroException("Sorry, you did not divide by zero it was because of an invalid argument...");
//                }
            }
            else
            {
                _socket.Bind(ep);
                _socket.Listen(1);
                _other = _socket.Accept();
                Console.WriteLine("Client Connected");
            }
            
            _receiver.Start();
        }

        ~GameSocket()
        {
            _shuttingDown = true;
            _formatter = null;
            _buffer = null;
            _receiver.Interrupt();
            _receiver = null;
            _socket.Dispose();
            _socket = null;
        }

        private void ReceiveLoop(object args)
        {
            while (!_shuttingDown)
            {
                if (_socketState == SocketState.Client)
                {
                    if (_socket.Available > 0)
                    {
                        _buffer = new byte[_socket.Available];
                        _socket.Receive(_buffer);
                    }
                }
                else if(_socketState == SocketState.Server)
                {
                    if (_other.Available > 0)
                    {
                        _buffer = new byte[_other.Available];
                        _other.Receive(_buffer);
                    }
                }
            }
        }

        public SocketState GetSocketState() => _socketState;

        public void SendChange(PieceState state)
        {
            
                if (_socketState == SocketState.Client)
                    _socket.Send(Serializer.Serialize(state));
                else _other.Send(Serializer.Serialize(state));

                Console.WriteLine("Sent data");
            
        }

        public PieceState? PollState()
        {
            if (_buffer == null || _buffer.Length < 1)
                return null;

            Console.WriteLine("Received data");

            PieceState state = Serializer.DeSerialize(_buffer);
            
            _buffer = null;
            
            return state;
        }
    }
}