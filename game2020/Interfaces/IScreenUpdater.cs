using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Interfaces
{
    public interface IScreenUpdater
    {
        public void UpdateScreen(GraphicsDeviceManager graphics, int width, int height);
    }
}
