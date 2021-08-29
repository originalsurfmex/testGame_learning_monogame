using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace testGame
{
    public class Painter : Game
    {
        protected GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        static GameWorld gameWorld;
        public static GameWorld GameWorld
        {
            get { return gameWorld; }
        }


        public Painter()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected void HandleInput()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
               Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameWorld = new GameWorld(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            gameWorld.Update(gameTime, _graphics);
            HandleInput();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            gameWorld.Draw(gameTime, _spriteBatch);
            base.Draw(gameTime);
        }

    }
}