using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    public class Cannon : ThreeColorObject
    {
        public Cannon(ContentManager Content) //only one sprite per color on the cannon
            : base(Content, "images/spr_cannon_barrel", "images/spr_cannon_barrel", "images/spr_cannon_barrel")
        {
            _objOrig = new Vector2(_objCurrent.Height, _objCurrent.Height) / 2;
            _objPos = new Vector2(40 + _objOrig.X, 375 + _objOrig.Y);
            CannonRotate = false;
        }

        public override void HandleInput(InputHelper inputHelper)
        {

            // helper boolean, checks if the mouse was clicked after a release using a previous state variable
            if (inputHelper.MouseClick)
                CannonRotate = !CannonRotate;
            if (CannonRotate)
                _objRot = (float)Math.Atan2(inputHelper.MousePos.Y - _objPos.Y,
                    inputHelper.MousePos.X - _objPos.X);
            else
                _objRot = 0.0f;

            // get that RGB son, needs to be improved so its not so heavy...just get a key
            if (inputHelper.KeyPressed(Keys.R) || inputHelper.KeyPressed(Keys.G) || 
                inputHelper.KeyPressed(Keys.B))
            {
                _currentCol = inputHelper.ColorSwitcher(_currentCol);
            }
        }

        public bool CannonRotate { get; set; }

        public Vector2 BallPos
        {
            get
            {
                float opposite = (float)Math.Sin(_objRot) * _objCurrent.Width * 0.80f;
                float adjacent = (float)Math.Cos(_objRot) * _objCurrent.Width * 0.80f;
                return _objPos + new Vector2(adjacent, opposite);
            }
        }
    }
}
