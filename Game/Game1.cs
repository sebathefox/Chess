using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Game.Scripts;
using Game.Scripts.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D _board;

        public Game1(string[] args)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IPEndPoint ep = null;

            if (args.Contains("--server"))
            {
                Console.WriteLine("Running as server.");
                // Create server socket.
                ep = new IPEndPoint(IPAddress.Any, 5151);
                NetworkManager.Instance.State = SocketState.Server;
            }
            else if(args.Contains("--client"))
            {
                if(args.Length > 1) ep = new IPEndPoint(IPAddress.Parse(args[1]), 5151);
                else ep = new IPEndPoint(IPAddress.Loopback, 5151);

                NetworkManager.Instance.State = SocketState.Client;
                // Begin connection to the Host server.
            }
            
            NetworkManager.Instance.Self = new GameSocket(NetworkManager.Instance.State, ep);
        }

        protected override void Initialize()
        {
            Window.Title = NetworkManager.Instance.State.ToString();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _board = Content.Load<Texture2D>("board");

            #region SpriteLoading

            ResourceManager.Instance.LoadTexture(Content, "black_bishop");
            ResourceManager.Instance.LoadTexture(Content, "black_castle");
            ResourceManager.Instance.LoadTexture(Content, "black_king");
            ResourceManager.Instance.LoadTexture(Content, "black_knight");
            ResourceManager.Instance.LoadTexture(Content, "black_pawn");
            ResourceManager.Instance.LoadTexture(Content, "black_queen");
            
            ResourceManager.Instance.LoadTexture(Content, "white_bishop");
            ResourceManager.Instance.LoadTexture(Content, "white_castle");
            ResourceManager.Instance.LoadTexture(Content, "white_king");
            ResourceManager.Instance.LoadTexture(Content, "white_knight");
            ResourceManager.Instance.LoadTexture(Content, "white_pawn");
            ResourceManager.Instance.LoadTexture(Content, "white_queen");
            
            ResourceManager.Instance.LoadTexture(Content, "hover_field");

            #endregion
            
            // Initializes the board.
            ResourceManager.Instance.Init();
            
            // Initialises and creates the players and their pieces.
            ResourceManager.Instance.Players[0] = new Player(GameColor.Black);
            ResourceManager.Instance.Players[1] = new Player(GameColor.White);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            List<PieceState> states = new List<PieceState>();
            
            PieceState? statz = NetworkManager.Instance.Self.PollState();
            
            for (int i = 0; i < 16; i++)
            {
                if(ResourceManager.Instance.Players[0][i] != null)
                    ResourceManager.Instance.Players[0][i].Update(gameTime, statz);

                if(ResourceManager.Instance.Players[1][i] != null)
                    ResourceManager.Instance.Players[1][i].Update(gameTime, statz);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(_board, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            ResourceManager.Instance.Players[0].Draw(ref spriteBatch);
            ResourceManager.Instance.Players[1].Draw(ref spriteBatch);

            base.Draw(gameTime);
        }
    }
}