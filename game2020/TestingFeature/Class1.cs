using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.TestingFeature
{
    class Class1
    {

        // voor collisionmanager

        //public void LevelCollision(Rectangle playerRec, Rectangle tileRectangle, Texture2D texture, ITransform heroTransform, int[,] map, Level lvl)()

        //public bool bla { get; set; }
        //private int counter { get; set; }


        // Level 2 unstable block
        //if (texture.Name == "Levels/Level1/45" || texture.Name == "Levels/Level1/46")
        //{
        //    bla = true;
        //    if (playerRec.Intersects(tileRectangle))
        //    {
        //        counter++;
        //        if (counter > 25)
        //        {
        //            for (int x = 0; x < map.GetLength(1); x++)
        //            {
        //                for (int y = 0; y < map.GetLength(0); y++)
        //                {
        //                    if (map[y, x] == 45 || map[y, x] == 46)
        //                    {
        //                        map[y, x] = 0;
        //                        lvl.UpdateLevel();
        //                        counter = 0;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        // game.cs
        //if (collisionManager.bla)
        //{
        //    level.CopyLevel();
        //    collisionManager.bla = false;
        //}


        // Level class
        //public void CopyLevel()
        //{
        //    PrevcollisionTiles.Clear();
        //    for (int i = 0; i < CollisionTiles.Count; i++)
        //    {
        //        PrevcollisionTiles.Add(collisionTiles[i]);
        //    }

        //    //PrevcollisionTiles = collisionTiles.Select(a => a.Copy()).ToList();
        //}

        //public void UpdateLevel()
        //{
        //    CollisionTiles.Clear();
        //    for (int x = 0; x < prevMap.GetLength(1); x++)
        //    {
        //        for (int y = 0; y < prevMap.GetLength(0); y++)
        //        {
        //            int number = CurrentMap[y, x];

        //            if (number > 0)
        //            {
        //                CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * Size, y * Size, Size, Size), path, this.content));
        //            }

        //            width = (x + 1) * Size;
        //            height = (y + 1) * Size;
        //        }
        //    }
        //}

        //PrevcollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size), path, this.content));

        //public List<CollisionTiles> PrevcollisionTiles = new List<CollisionTiles>();
        //private int[,] prevMap { get; set; }
        //this.prevMap = map;
    }
}
