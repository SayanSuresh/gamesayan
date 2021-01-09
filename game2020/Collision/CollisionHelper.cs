using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCol
{
    public class CollisionHelper: ICollisionHelper
    {
        // Voor deze stukje berekeningen van collision heb ik afgeleid
        // uit een tutorial van een youtuber (Oyyou: MonoGame Tutorial 009 - Sprite Collision Detection and Response 7:00 min)

        public bool CollisionBottom(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Bottom >= rect2.Top - 1 &&
                    rect1.Bottom <= rect2.Top + (rect2.Height / 2) &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public bool CollisionTop(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Top >= rect2.Bottom - 1 &&
                    rect1.Top <= rect2.Bottom + (rect2.Height / 5) &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public  bool CollisionRight(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Right <= rect2.Right &&
                    rect1.Right >= rect2.Left - 5 &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4));
        }

        public bool CollisionLeft(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Left >= rect2.Left &&
                    rect1.Left <= rect2.Right + 5 &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4));
        }
    }
}
