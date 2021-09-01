using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    public class InputHelper
    {
        Vector2 _mousePos;
        MouseState _mouse, _mousePrev;
        KeyboardState _key, _keyPrev;
        bool _mouseClick;

        public void Update()
        {
            _mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            // set up mouse & keyboard states
            _mousePrev = _mouse;
            _mouse = Mouse.GetState();
            _keyPrev = _key;
            _key = Keyboard.GetState();

            _mouseClick = _mouse.LeftButton == ButtonState.Pressed && _mousePrev.LeftButton == ButtonState.Released;
        }

        public Vector2 MousePos
        {
            get { return _mousePos; }
        }

        public bool MouseClick
        {
            get { return _mouseClick; }
        }

        public bool MouseLeftButton()
        {
            return _mouse.LeftButton == ButtonState.Pressed && _mousePrev.LeftButton == ButtonState.Released;
        }

        public bool KeyPressed(Keys key)
        {
            return _key.IsKeyDown(key) && _keyPrev.IsKeyUp(key);
        }
    }
}
