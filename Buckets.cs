using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    internal class Buckets : ThreeColorObject
    {
        private readonly Texture2D _bucketLives;
        private float _difficulty;

        public Buckets(ContentManager Content, float position, Color target) :
            base(Content, "images/spr_can_red", "images/spr_can_green", "images/spr_can_blue")
        {
            _bucketLives = Content.Load<Texture2D>("images/spr_lives");
            _objPos.X += position;

            _currentCol = target;
            _objVelFactor = 50.0f;
            _difficulty = 1.0f + (float)Painter.Random.NextDouble();
        }

        public override void Reset()
        {
            _currentCol = RandomColor();
            _objPos.Y = -150;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //gravity
            _objPos.Y += _objVelFactor * _difficulty * _dt;

            //gameworld bounds and lose a life
            if (!Painter.GameWorld.InWorld(_objPos - _objOrig) &&
                Painter.Random.NextDouble() > 0.8f)
            {
                Painter.GameWorld.LoseLife();
                _difficulty += .25f + (float)Painter.Random.NextDouble();
                Reset();
            }

            //reset difficulty if too high / too fast
            if (_difficulty > 20.0f) _difficulty = 2.0f + (float)Painter.Random.NextDouble();

            //collisions and color reset and lose a life
            if (BBox.Intersects(Painter.GameWorld.Ball.BBox))
            {
                if (_currentCol != Painter.GameWorld.Ball.ColorGetSet)
                    Painter.GameWorld.LoseLife();
                if (_currentCol == Painter.GameWorld.Ball.ColorGetSet)
                    Reset();

                Painter.GameWorld.Ball.Reset();
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(_objCurrent, _objPos, null, Color.White, 0.0f,
                _objOrig, 1.0f, SpriteEffects.None, 0);
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