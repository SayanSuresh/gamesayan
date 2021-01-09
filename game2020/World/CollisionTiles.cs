using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public class CollisionTiles : Tile
    {
        public CollisionTiles(int i, Rectangle newRectangle, string path, ContentManager content)
        {
            texture = content.Load<Texture2D>(path + i);
            this.Rectangle = newRectangle;
        }
    }
}
