using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    public class Painter : Game
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private InputHelper _inputHelper;

        private static GameWorld gameWorld;

        public static GameWorld GameWorld
        {
            get { return gameWorld; }
        }

        public static GraphicsDeviceManager Graphics
        {
            get { return _graphics; }
        }

        public static Vector2 ScreenSize { get; private set; }
        public static Random Random { get; private set; }

        //---------------------------------------

        public Painter()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _inputHelper = new InputHelper();
            Random = new Random();

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

            ScreenSize = new Vector2(_graphics.GraphicsDevice.Viewport.Width,
                 _graphics.GraphicsDevice.Viewport.Height);


        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _inputHelper.Update(); //general mouse clicks, etc
            gameWorld.HandleInput(_inputHelper); //specific to other classes
            gameWorld.Update(gameTime);
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