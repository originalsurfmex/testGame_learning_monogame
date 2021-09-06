using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace testGame
{
    public class Ball : ThreeColorObject
    {
        public Ball(ContentManager Content) :
            base(Content, "images/spr_ball_red", "images/spr_ball_green", "images/spr_ball_blue")
        {
            Shooting = false;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButton() && !Shooting)
            {
                Shooting = true;
                //subtracting vectors is like shooting an arrow, mousePos is built-in magnitude too
                _objVelocity = (inputHelper.MousePos - Painter.GameWorld.Cannon.BallPos) * 2.1f;
            }
        }

        public override void Reset()
        {
            // reset ball location within Update, otherwise glitches
            Shooting = false;
            Painter.GameWorld.Cannon.CannonRotate = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _currentCol = Painter.GameWorld.Cannon.ColorGetSet;
            _objOrig = Painter.GameWorld.Cannon.Origin + new Vector2(80, -25);

            //this is where ball location is dictated
            if (Shooting)
            {
                _objPos += _objVelocity * _dt;
                _objVelocity.Y += 400.0f * _dt;
            }
            else
                _objPos = Painter.GameWorld.Cannon.BallPos;

            if (!Painter.GameWorld.InWorld(_objPos))
                Reset();
        }

        public bool Shooting { get; private set; }
    }
}