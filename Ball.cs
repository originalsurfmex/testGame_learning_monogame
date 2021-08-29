using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class Ball
    {
        Texture2D _redball, _greenball, _blueball, _currentBall;
        Vector2 _ballOrig;
        Color _ballColor;
        public Ball(ContentManager Content)
        {
            _redball = Content.Load<Texture2D>("images/spr_cannon_red");
            _greenball = Content.Load<Texture2D>("images/spr_cannon_green");
            _blueball = Content.Load<Texture2D>("images/spr_cannon_blue");

            _ballColor = Color.Red;
            //_ballColor = Painter.GameWorld.Cannon.Color;

            _ballOrig = new Vector2(_redball.Width, _redball.Height) / 2;
            _currentBall = _redball;

        }

        public void Reset()
        {
            _ballColor = Color.Blue;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Cannon cannon)
        {
            spriteBatch.Draw(_currentBall, cannon.Position, null, Color.White, cannon.Angle, cannon.Origin,
                1.0f, SpriteEffects.None, 0);

            if (_ballColor == Color.Red)
                _currentBall = _redball;
            else if (_ballColor == Color.Green)
                _currentBall = _greenball;
            else
                _currentBall = _blueball;

        }


        public Color ColorGetset
        {
            get { return _ballColor; }
            set
            {
                if (value != Color.Red && value != Color.Blue && value != Color.Green)
                    return;
                _ballColor = value;
            }
        }

        public Texture2D BallTex
        {
            get { return _currentBall; }
            set { _currentBall = value; }
        }
    }
}
