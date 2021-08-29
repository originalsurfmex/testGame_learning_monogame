using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class GameWorld
    {
        Texture2D _background;
        Balloons _balloons;
        Cannon _cannon;
        Ball _ball;
        InputHelper inputHelper;

        public GameWorld(ContentManager Content)
        {
            _background = Content.Load<Texture2D>("images/spr_background");
            _balloons = new Balloons(Content);
            _cannon = new Cannon(Content);
            _ball = new Ball(Content);
            inputHelper = new InputHelper();
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager _graphics)
        {
            _balloons.Update(gameTime, inputHelper, _graphics);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            inputHelper.Update(_cannon, _ball);

            spriteBatch.Begin();
            spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _balloons.Draw(gameTime, spriteBatch);
            _ball.Draw(gameTime, spriteBatch, _cannon);
            _cannon.Draw(gameTime, spriteBatch, _ball);
            spriteBatch.End();
        }

        public Cannon Cannon
        {
            get { return _cannon; }
        }
    }
}