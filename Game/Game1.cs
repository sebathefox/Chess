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

        private Texture2D _tex;
        private Player _player;

        

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

            _tex = Content.Load<Texture2D>("board");

            ResourceManager.Instance.LoadTexture(Content, "black_bishop");
            ResourceManager.Instance.LoadTexture(Content, "black_castle");
            ResourceManager.Instance.LoadTexture(Content, "black_king");
            ResourceManager.Instance.LoadTexture(Content, "black_knight");
            ResourceManager.Instance.LoadTexture(Content, "black_pawn");
            ResourceManager.Instance.LoadTexture(Content, "black_queen");

            // TODO: use this.Content to load your game content here
            
            _player = new Player(GameColor.Black);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            for (int i = 0; i < 16; i++)
            {
                if(_player[i] != null)
                    _player[i].Update(gameTime);
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(_tex, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            
//            spriteBatch.Begin();
//            foreach (Field field in ResourceManager.Instance.Fields)
//            {
//                spriteBatch.Draw(ResourceManager.Instance.Textures["black_knight"], field.Rect, Color.CornflowerBlue);
//            }
//            spriteBatch.End();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

            _player.Draw(ref spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}