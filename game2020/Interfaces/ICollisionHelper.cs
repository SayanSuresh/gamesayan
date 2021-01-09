using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringCol
{
    public interface ICollisionHelper
    {
        public bool CollisionBottom(Rectangle rect1, Rectangle rect2);
        public bool CollisionTop(Rectangle rect1, Rectangle rect2);
        public bool CollisionRight(Rectangle rect1, Rectangle rect2);
        public bool CollisionLeft(Rectangle rect1, Rectangle rect2);
    }
}
