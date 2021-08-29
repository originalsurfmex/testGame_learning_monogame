using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class Cannon
    {
        Texture2D _cannon;
        Vector2 _cannonPos, _cannonOrig;
        float _cannonRot;
        public Cannon(ContentManager Content)
        {
            _cannon = Content.Load<Texture2D>("images/spr_cannon_barrel");

        }

        public void Reset()
        {
            _cannonRot = 0.0f;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Ball ball)
        {
            spriteBatch.Draw(_cannon, _cannonPos, null, ball.ColorGetset, _cannonRot, _cannonOrig, 1.0f, SpriteEffects.None, 0);
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

    }
}
