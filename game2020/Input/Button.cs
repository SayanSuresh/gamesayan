using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Controls
{
    public class Button
    {
        // Om die kleueren aan te passen heb ik wat referentie gebruikt van deze link:
        // https://github.com/MonoGame/MonoGame/pull/4962

        private Color color = new Color(255, 255, 255, 255);
        private Texture2D buttonTexture;
        private Vector2 position;
        private Rectangle rectangle;
        private bool down;

        public bool isClicked;

        public Button() { }

        public void Load(Texture2D newTexture, Vector2 newPosition)
        {
            buttonTexture = newTexture;
            position = newPosition;
        }

        public void Update(MouseState mouse)
        {
            mouse = Mouse.GetState();

            rectangle = new Rectangle((int)position.X, (int)position.Y, buttonTexture.Width, buttonTexture.Height);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (color.A == 255) 
                    down = false;
                if (color.A == 0) 
                    down = true;
                if (down) 
                    color.A += 3;    
                else 
                    color.A -= 3;

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                    color.A = 255;
                }
            }
            else if (color.A < 255)
                color.A += 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, rectangle, color);
        }
    }
}
