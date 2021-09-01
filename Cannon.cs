using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    public class Cannon
    {
        Texture2D _cannon;
        Vector2 _cannonPos, _cannonOrig;
        float _cannonRot;
        Color color, Red, Green, Blue;
        bool _calcCannonRot;
        public Cannon(ContentManager Content)
        {
            _cannon = Content.Load<Texture2D>("images/spr_cannon_barrel");
            color = Color.Blue;
            _cannonOrig = new Vector2(_cannon.Height, _cannon.Height) / 2;
            _cannonPos = new Vector2(41 + _cannonOrig.X, 380 + _cannonOrig.Y);

        }

        public void HandleInput(InputHelper inputHelper)
        {
        
            // helper boolean, checks if the mouse was clicked after a release using a previous state variable
            if (inputHelper.MouseClick)
                _calcCannonRot = !_calcCannonRot;
            if (_calcCannonRot)
                _cannonRot = (float)Math.Atan2(inputHelper.MousePos.Y - _cannonPos.Y, 
                    inputHelper.MousePos.X - _cannonPos.X);
            else
                _cannonRot = 0.0f;

            // change them colors RGBizzlee
            if (inputHelper.KeyPressed(Keys.R))
            {
                color = Color.Red;
            }
            else if (inputHelper.KeyPressed(Keys.G))
            {
                color = Color.Green;
            }
            else if (inputHelper.KeyPressed(Keys.B))
            {
                color = Color.Blue;
            }
        }
        public void Reset()
        {
            _cannonRot = 0.0f;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_cannon, _cannonPos, null, color, _cannonRot, _cannonOrig, 1.0f, SpriteEffects.None, 0);
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

        public Color ColorGetset
        {
            get { return color; }
            set
            {
                if (value != Color.Red && value != Color.Blue && value != Color.Green)
                    return;
                color = value;
            }
        }

        public bool CannonRotate
        {
            get { return _calcCannonRot; }
            set { _calcCannonRot = value; }
        }

        //-----------------------------------------------------

        public Vector2 BallPos
        {
            get
            {
                float opposite = (float)Math.Sin(_cannonRot) * _cannon.Width * 0.80f;
                float adjacent = (float)Math.Cos(_cannonRot) * _cannon.Width * 0.80f;
                return _cannonPos + new Vector2(adjacent, opposite);
            }
        }
    }
}
