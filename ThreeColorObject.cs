using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class ThreeColorObject
    {
        protected Texture2D _objCurrent, _objRed, _objGreen, _objBlue;
        protected Color _currentCol;
        protected Vector2 _objOrig, _objTexOrig, _objPos, _objVelocity;
        protected float _dt, _objRot, _objVelFactor;

        protected ThreeColorObject(ContentManager Content, string redSprite,
            string greenSprite, string blueSprite)
        {
            //sprite textures
            _objCurrent = Content.Load<Texture2D>(blueSprite);
            _objBlue = Content.Load<Texture2D>(blueSprite);
            _objGreen = Content.Load<Texture2D>(greenSprite);
            _objRed = Content.Load<Texture2D>(redSprite);

            //default color
            _currentCol = Color.Blue;

            //object origin and position vectors
            _objOrig = new Vector2(_objCurrent.Height, _objCurrent.Width) / 2;
            _objPos = Vector2.Zero;
            _objVelocity = Vector2.Zero;
            _objRot = 0.0f;

            //set floats
            _objRot = 0.0f; //rotation
            _objVelFactor = 1.0f; //velocity factor/multiplier
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
        }

        public virtual void Reset()
        {
            _currentCol = Color.Blue;
            _objVelocity = Vector2.Zero;
            _objRot = 0.0f;
        }

        public virtual void Update(GameTime gameTime)
        {
            _dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _objPos += _objVelocity * _objVelFactor * _dt;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // pick the sprite based on the current Color
            if (_currentCol == Color.Red)
                _objCurrent = _objRed;
            else if (_currentCol == Color.Green)
                _objCurrent = _objGreen;
            else
                _objCurrent = _objBlue;

            // draw the object sprite
            spriteBatch.Draw(_objCurrent, _objPos, null, _currentCol, _objRot,
                _objOrig, 1.0f, SpriteEffects.None, 0);
        }
        public Vector2 Origin
        {
            get { return _objOrig; }
        }
        public Color ColorGetSet
        {
            get { return _currentCol; }
            protected set
            {
                if (value != Color.Red && value != Color.Blue && value != Color.Green)
                    return;
                _currentCol = value;
            }
        }
        public Rectangle BBox
        {
            get
            {
                Rectangle spriteBound = _objCurrent.Bounds;
                spriteBound.Offset(_objPos - _objOrig);
                return spriteBound;
            }
        }
    }
}