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
        Buckets _bucket1, _bucket2, _bucket3;


        public GameWorld(ContentManager Content)
        {
            _background = Content.Load<Texture2D>("images/spr_background");
            _balloons = new Balloons(Content);
            _cannon = new Cannon(Content);
            _ball = new Ball(Content);

            _bucket1 = new Buckets(Content, 480.0f, Color.Red);
            _bucket2 = new Buckets(Content, 735.0f, Color.Blue);
            _bucket3 = new Buckets(Content, 610.0f, Color.Green);
        }

        public void HandleInput(InputHelper inputHelper)
        {
            _cannon.HandleInput(inputHelper);
            _ball.HandleInput(inputHelper);
            _balloons.HandleInput(inputHelper);
        }
        public void Update(GameTime gameTime)
        {

            _balloons.Update(gameTime, Painter.Graphics);
            _ball.Update(gameTime);
            _bucket1.Update(gameTime);
            _bucket2.Update(gameTime);
            _bucket3.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _balloons.Draw(gameTime, spriteBatch);
            _ball.Draw(gameTime, spriteBatch);
            _cannon.Draw(gameTime, spriteBatch);

            _bucket1.Draw(gameTime, spriteBatch);
            _bucket2.Draw(gameTime, spriteBatch);
            _bucket3.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public Cannon Cannon
        {
            get { return _cannon; }
        }

        public bool InWorld(Vector2 position)
        {
            // return false if out of bounds, true if in bounds
            return position.X > 0 && position.X < Painter.ScreenSize.X + 100 &&
                position.Y < Painter.ScreenSize.Y + 100;
        }
    }
}