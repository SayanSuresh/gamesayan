using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public abstract class Tile
    {
        public Texture2D texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }

        //protected ContentManager content { get; set; }
        //public Tile(ContentManager content) { this.content = content; }

        //private  static ContentManager content;
        //public static ContentManager Content
        //{
        //    protected get { return content; }
        //    set { content = value; }
        //}
    }
}
