using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Interfaces
{
    public interface ITileCollision
    {
        //public CollisionTiles CollisionTiles { get; set; }
        public void LevelCollision(Rectangle playerRec, Rectangle tileRectangle, Texture2D texture, ITransform heroTransform);
    }
}
