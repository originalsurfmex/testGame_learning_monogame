using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace testGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _balloon, _balloon2, _balloon3, _background;

        private Color _pulsing;
        private Vector2 _mousePos,
            _balloonPos, _balloonOrig,
            _balloon2Pos, _balloon2Orig,
            _balloon3Pos;

        private float _balloon2Rot, _balloon2R,
            _balloon3R, _balloon3Rot;
        private int redComponent, blueComponent, greenComponent;

        private MouseState _mouse, _mousePrev;
        private KeyboardState _key, _keyPrev;
        private bool _mouseClick, _keyPress, _calcCannonRot;

        Cannon cannon;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public void HandleInput()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _pulsing = new Color(redComponent, 0, 0);

            _mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            _balloon2R = 70.0f;
            _balloon3R = 120.0f;

            _balloonOrig = new Vector2(_balloon.Width / 2, _balloon.Height / 2);
            _balloonPos = _mousePos - _balloonOrig;
            _balloon2Rot += 0.1f;
            _balloon2Pos = new Vector2((float)Math.Cos(_balloon2Rot) * _balloon2R, 
                (float)Math.Sin(_balloon2Rot) * _balloon2R);
            _balloon2Orig = new Vector2(_graphics.PreferredBackBufferWidth / 2, 
                _graphics.PreferredBackBufferHeight / 2);
            _balloon3Rot += 0.05f;
            _balloon3Pos = new Vector2((float)Math.Cos(_balloon2Rot) * _balloon3R, 
                (float)Math.Sin(_balloon2Rot) * _balloon3R);
            _balloon2Pos += _balloon2Orig; //vector math here
            _balloon3Pos = _balloon2Pos - _balloon3Pos;

            cannon.Origin = new Vector2(cannon.Tex.Height, cannon.Tex.Height) / 2;
            cannon.Position = new Vector2(41 + cannon.Origin.X, 380 + cannon.Origin.Y);

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
                cannon.ColorGetset = Color.Red;
            }
            else if (_key.IsKeyDown(Keys.G) && _keyPrev.IsKeyUp(Keys.G))
            {
                cannon.ColorGetset = Color.Green;
            }
            else if (_key.IsKeyDown(Keys.B) && _keyPrev.IsKeyUp(Keys.B))
            {
                cannon.ColorGetset = Color.Blue;
            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _balloon = Content.Load<Texture2D>("images/spr_lives");
            _balloon2 = Content.Load<Texture2D>("images/spr_lives");
            _balloon3 = Content.Load<Texture2D>("images/spr_lives");

            _background = Content.Load<Texture2D>("images/spr_background");

            //MediaPlayer.Play(Content.Load<Song>("sounds/snd_music"));
            _balloon2Rot = 1.0f;
            _balloon3Rot = 1.0f;


            cannon = new Cannon(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            redComponent = gameTime.TotalGameTime.Milliseconds / 8;
            greenComponent = gameTime.TotalGameTime.Milliseconds / 1;
            blueComponent = gameTime.TotalGameTime.Milliseconds / 20;

            HandleInput();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);


            _spriteBatch.Draw(_balloon, _balloonPos, _pulsing);
            _spriteBatch.Draw(_balloon2, _balloon2Pos, _pulsing);
            _spriteBatch.Draw(_balloon3, _balloon3Pos, _pulsing);

            cannon.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}