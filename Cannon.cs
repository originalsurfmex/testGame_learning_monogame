using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    class Cannon
    {
        private Texture2D _cannon, _redball, _greenball, _blueball, _currentBall;
        private Vector2 _cannonPos, _cannonOrig, _ballOrig;
        private float _cannonRot;
        private Color _ballColor;
        public Cannon(ContentManager Content)
        {
            _cannon = Content.Load<Texture2D>("images/spr_cannon_barrel");
            _redball = Content.Load<Texture2D>("images/spr_cannon_red");
            _greenball = Content.Load<Texture2D>("images/spr_cannon_green");
            _blueball = Content.Load<Texture2D>("images/spr_cannon_blue");

            _ballColor = Color.Red;

            _ballOrig = new Vector2(_redball.Width, _redball.Height) / 2;
            _currentBall = _redball;

        }

        public void Reset()
        {
            _ballColor = Color.Blue;
            _cannonRot = 0.0f;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_currentBall, _cannonPos, null, Color.White, _cannonRot, _cannonOrig, 1.0f, SpriteEffects.None, 0);

            if (_ballColor == Color.Red)
                _currentBall = _redball;
            else if (_ballColor == Color.Green)
                _currentBall = _greenball;
            else
                _currentBall = _blueball;

            spriteBatch.Draw(_cannon, _cannonPos, null, _ballColor, _cannonRot, _cannonOrig, 1.0f, SpriteEffects.None, 0);
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

        public Vector2 Position
        {
            get { return _cannonPos; }
            set { _cannonPos = value; }
        }

        public float Angle
        {
            get { return _cannonRot; }
            set { _cannonRot = value; }
        }

        public Vector2 Origin
        {
            get { return _cannonOrig; }
            set { _cannonOrig = value; }
        }

        public Texture2D Tex
        {
            get { return _cannon; }
        }

        public Texture2D BallTex
        {
            get { return _currentBall; }
            set { _currentBall = value; }
        }
    }
}
