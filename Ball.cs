using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class Ball
    {
        private Texture2D _currentBall, _ballsBlue, _ballsRed, _ballsGreen;
        private Vector2 _ballOrig, _ballOrigTex, _ballPos, _velocity;
        private Color _ballColor;
        private float _ballAng;
        private bool _shooting;

        public Ball(ContentManager Content)
        {
            _currentBall = Content.Load<Texture2D>("images/spr_ball_blue");
            _ballsBlue = Content.Load<Texture2D>("images/spr_ball_blue");
            _ballsRed = Content.Load<Texture2D>("images/spr_ball_red");
            _ballsGreen = Content.Load<Texture2D>("images/spr_ball_green");

            _ballOrigTex = new Vector2(_ballsBlue.Width, _ballsBlue.Height) / 2;

            _shooting = false;
        }

        public void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButton() && !_shooting)
            {
                _shooting = true;
                //subtracting vectors is like shooting an arrow, mousePos is built-in magnitude too
                _velocity = (inputHelper.MousePos - Painter.GameWorld.Cannon.BallPos) * 2.1f;
            }
        }

        public void Reset()
        {
            // reset ball location within Update, otherwise glitches
            _ballColor = Color.Blue;
            _velocity = Vector2.Zero;
            _shooting = false;
            Painter.GameWorld.Cannon.CannonRotate = false;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _ballAng = Painter.GameWorld.Cannon.Angle;
            _ballOrig = Painter.GameWorld.Cannon.Origin + new Vector2(90, -20);

            //this is where ball location is dictated
            if (_shooting)
            {
                _ballPos += _velocity * dt;
                _velocity.Y += 400.0f * dt;
                _currentBall = _ballsRed;
            }
            else
            {
                _ballPos = Painter.GameWorld.Cannon.BallPos;
            }

            //on screen or off screen
            //if (_ballPos.X >= Painter.ScreenSize.X + 100 ||
            //    _ballPos.Y >= Painter.ScreenSize.Y + 100)
            if (!Painter.GameWorld.InWorld(_ballPos))
            {
                Reset();
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Painter.GameWorld.Cannon.ColorGetset == Color.Red)
            {
                _currentBall = _ballsRed;
                _ballColor = Color.Red;
            }
            else if (Painter.GameWorld.Cannon.ColorGetset == Color.Green)
            {
                _currentBall = _ballsGreen;
                _ballColor = Color.Green;
            }
            else
            {
                _currentBall = _ballsBlue;
                _ballColor = Color.Blue;
            }

            spriteBatch.Draw(_currentBall, _ballPos, null, Color.White, 0.0f, _ballOrig,
               1.0f, SpriteEffects.None, 0);
        }

        public Texture2D BallTex
        {
            get { return _currentBall; }
            set { _currentBall = value; }
        }

        public Color Color { get { return _ballColor; } }

        public bool Shooting
        {
            get { return _shooting; }
        }
        public Rectangle BBox
        {
            get
            {
                Rectangle spriteBound = _ballsBlue.Bounds;
                spriteBound.Offset(_ballPos - _ballOrig);
                return spriteBound;
            }
        }

    }
}