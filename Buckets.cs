using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    internal class Buckets
    {
        private Texture2D _bucketCurrent, _bucketRed, _bucketGreen, _bucketBlue;
        private Vector2 _bucketPos, _bucketOrig;
        private Color _color, _targetcolor;
        private float _velocity;
        private float _difficulty;

        public Buckets(ContentManager Content, float position, Color target)
        {
            _bucketCurrent = Content.Load<Texture2D>("images/spr_can_blue");
            _bucketRed = Content.Load<Texture2D>("images/spr_can_red");
            _bucketGreen = Content.Load<Texture2D>("images/spr_can_green");
            _bucketBlue = Content.Load<Texture2D>("images/spr_can_blue");

            _bucketOrig = new Vector2(_bucketRed.Width, _bucketRed.Height) / 2;
            _bucketPos = new Vector2(Painter.ScreenSize.X, Painter.ScreenSize.Y) / 2;
            _bucketPos.X += position;

            _targetcolor = target;
            _velocity = 50.0f;
            //_difficulty = 1.2f;
            _difficulty = 1.0f + (float)Painter.Random.NextDouble();

            //Reset();
        }

        public void Reset()
        {
            _color = RandomColor();
            _bucketPos.Y = -150;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _bucketPos.Y += _velocity * _difficulty * dt;

            if (!Painter.GameWorld.InWorld(_bucketPos - _bucketOrig) &&
                Painter.Random.NextDouble() > 0.8f)
            {
                _difficulty += .25f + (float)Painter.Random.NextDouble();
                Reset();
            }

            if (_difficulty > 20.0f) _difficulty = 2.0f + (float)Painter.Random.NextDouble();

            if (_targetcolor == Color.Red)
                _bucketCurrent = _bucketRed;
            else if (_targetcolor == Color.Green)
                _bucketCurrent = _bucketGreen;
            else
                _bucketCurrent = _bucketBlue;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_bucketCurrent, _bucketPos, null, Color.White, 0.0f,
                _bucketOrig, 1.0f, SpriteEffects.None, 0);
        }

        private Color RandomColor()
        {
            int randomVal = Painter.Random.Next(3);
            if (randomVal == 0)
                return Color.Blue;
            else if (randomVal == 1)
                return Color.Red;
            else
                return Color.Green;
        }
    }
}