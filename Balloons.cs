using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace testGame
{
    public class Balloons
    {
        Texture2D _balloon, _balloon2, _balloon3;
        Vector2 _balloonPos, _balloonOrig, _balloon2Pos, _balloon2Orig, _balloon3Pos;
        float _balloon2Rot, _balloon2R, _balloon3R, _balloon3Rot;
        int redComponent, blueComponent, greenComponent;

        Color _pulsing;

        public Balloons(ContentManager Content)
        {
            _balloon = Content.Load<Texture2D>("images/spr_lives");
            _balloon2 = Content.Load<Texture2D>("images/spr_lives");
            _balloon3 = Content.Load<Texture2D>("images/spr_lives");


            //MediaPlayer.Play(Content.Load<Song>("sounds/snd_music"));
            _balloon2Rot = 1.0f;
            _balloon3Rot = 1.0f;
        }

        public void HandleInput(InputHelper inputHelper)
        {

            _balloonPos = inputHelper.MousePos - _balloonOrig;
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager _graphics)
        {
            redComponent = gameTime.TotalGameTime.Milliseconds / 5;
            greenComponent = gameTime.TotalGameTime.Milliseconds / 5;
            blueComponent = gameTime.TotalGameTime.Milliseconds / 20;

            _pulsing = new Color(redComponent, 0, 0);


            _balloon2R = 150.0f;
            _balloon3R = _balloon2R * 0.5f;

            _balloonOrig = new Vector2(_balloon.Width / 2, _balloon.Height / 2);
            _balloon2Rot += 0.1f;
            _balloon2Pos = new Vector2((float)Math.Cos(_balloon2Rot) * _balloon2R,
                (float)Math.Sin(_balloon2Rot) * _balloon2R);
            _balloon2Orig = new Vector2(Painter.ScreenSize.X - Painter.ScreenSize.X / 4,
                Painter.ScreenSize.Y / 2 - _balloon.Height / 2);
            _balloon3Rot += 0.15f;
            _balloon3Pos = new Vector2((float)Math.Cos(_balloon2Rot) * _balloon3R,
                (float)Math.Sin(_balloon2Rot) * _balloon3R);
            _balloon2Pos += _balloon2Orig; //vector math here
            _balloon3Pos = _balloon2Pos - _balloon3Pos;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_balloon, _balloonPos, _pulsing);
            spriteBatch.Draw(_balloon2, _balloon2Pos, _pulsing);
            spriteBatch.Draw(_balloon3, _balloon3Pos, _pulsing);
        }

        public Texture2D balloon1
        {
            get { return _balloon; }
            set { _balloon = balloon1; }
        }
        public Texture2D balloon2
        {
            get { return _balloon2; }
            set { _balloon2 = balloon2; }
        }
        public Texture2D balloon3
        {
            get { return _balloon3; }
            set { _balloon3 = balloon3; }

        }

    }

}
