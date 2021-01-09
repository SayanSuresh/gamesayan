using game2020.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.GameScreen
{
    public class ScreenUpdate : IScreenUpdater
    {
        private GraphicsDeviceManager _graphics;

        public void UpdateScreen(GraphicsDeviceManager graphics, int width, int height)
        {
            this._graphics = graphics;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }
    }
}
