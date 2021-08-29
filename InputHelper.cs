using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    class InputHelper
    {
        Vector2 _mousePos;
        MouseState _mouse, _mousePrev;
        KeyboardState _key, _keyPrev;
        bool _mouseClick, _calcCannonRot;

        public void Update(Cannon cannon, Ball ball)
        {

            cannon.Origin = new Vector2(cannon.Tex.Height, cannon.Tex.Height) / 2;
            cannon.Position = new Vector2(41 + cannon.Origin.X, 380 + cannon.Origin.Y);

            _mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            // set up mouse & keyboard states
            _mousePrev = _mouse;
            _mouse = Mouse.GetState();
            _keyPrev = _key;
            _key = Keyboard.GetState();


            // helper boolean, checks if the mouse was clicked after a release using a previous state variable
            _mouseClick = _mouse.LeftButton == ButtonState.Pressed && _mousePrev.LeftButton == ButtonState.Released;
            if (_mouseClick)
                _calcCannonRot = !_calcCannonRot;
            if (_calcCannonRot)
                cannon.Angle = (float)Math.Atan2(_mousePos.Y - cannon.Position.Y, _mousePos.X - cannon.Position.X);
            else
                cannon.Angle = 0.0f;

            if (_key.IsKeyDown(Keys.R) && _keyPrev.IsKeyUp(Keys.R))
            {
                ball.ColorGetset = Color.Red;
            }
            else if (_key.IsKeyDown(Keys.G) && _keyPrev.IsKeyUp(Keys.G))
            {
                ball.ColorGetset = Color.Green;
            }
            else if (_key.IsKeyDown(Keys.B) && _keyPrev.IsKeyUp(Keys.B))
            {
                ball.ColorGetset = Color.Blue;
            }
        }

        public Vector2 MousePos
        {
            get { return _mousePos; }
        }
    }
}
