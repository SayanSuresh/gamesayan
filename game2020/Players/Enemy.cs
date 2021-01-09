using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Enemy : ICollisionRectangle
    {
        public bool IsCollision { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        private Rectangle _collisionRectangle;
        private Texture2D enemyTexture;
        private Vector2 position;
        private Vector2 velocity;

        private bool right;
        private float rotation = 0f;
        private float distance;
        private float oldDistance;
        private float playerDistance;

        public Enemy(Texture2D texture, Vector2 newPosition, float newDistance)
        {
            enemyTexture = texture;
            position = newPosition;
            distance = newDistance;

            oldDistance = distance;

            _collisionRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, enemyTexture.Width-30, enemyTexture.Height-30);
        }

        public void Update(ITransform player)
        {
            position += velocity;

            if (distance <= 0)
            {
                right = true;
                velocity.X = 1;
            }
            else if (distance >= oldDistance)
            {
                right = false;
                velocity.X = -1f;
            }

            if (right)
                distance += 1;
            else
                distance -= 1;

            playerDistance = player.Position.X - position.X;

            if (playerDistance >= -200 && playerDistance <= 200)
            {
                if (playerDistance < -1)
                    velocity.X = -1f;
                else if (playerDistance > 1)
                    velocity.X = 1f;
                else if (playerDistance == 0)
                    velocity.X = 0f;
            }

            _collisionRectangle.X = (int)position.X;
            _collisionRectangle.Y = (int)position.Y;
            CollisionRectangle = _collisionRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
                spriteBatch.Draw(enemyTexture, position, null, Color.White, rotation, new Vector2(32, 32), 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(enemyTexture, position, null, Color.White, rotation, new Vector2(32, 32), 1f, SpriteEffects.None, 0f);
        }
    }
}
