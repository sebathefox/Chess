using Game.Scripts;
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

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _board = Content.Load<Texture2D>("board");

            ResourceManager.Instance.LoadTexture(Content, "black_bishop");
            ResourceManager.Instance.LoadTexture(Content, "black_castle");
            ResourceManager.Instance.LoadTexture(Content, "black_king");
            ResourceManager.Instance.LoadTexture(Content, "black_knight");
            ResourceManager.Instance.LoadTexture(Content, "black_pawn");
            ResourceManager.Instance.LoadTexture(Content, "black_queen");
            
            ResourceManager.Instance.LoadTexture(Content, "hover_field");

            ResourceManager.Instance.Init();
            
            ResourceManager.Instance.Players[0] = new Player(GameColor.Black);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < 16; i++)
            {
                if(ResourceManager.Instance.Players[0][i] != null)
                    ResourceManager.Instance.Players[0][i].Update(gameTime);
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

            base.Draw(gameTime);
        }
    }
}