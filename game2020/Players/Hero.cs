using game2020.Animation;
using game2020.Animation.HeroAnimations;
using game2020.Collision;
using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Hero : ITransform, ICollisionRectangle, ICollisionEntity
    {
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public bool HasJumped { get; set; }
        public Vector2 Velocity { get; set; }

        private Rectangle _collisionRectangle;
        private Texture2D heroTexture;
        private GameTime gameTime;

        private IInputReader reader;
        private IGameCommand moveCommand;
        private IEntityAnimation walkRight, walkLeft, walkUp, walkDown, currentAnimation;


        public void HeroWalkAnimation(IEntityAnimation walkRight, IEntityAnimation walkLeft, IEntityAnimation walkUp, IEntityAnimation walkDown)
        {
            this.walkRight = walkRight;
            this.walkLeft = walkLeft;
            this.walkUp = walkUp;
            this.walkDown = walkDown;
            currentAnimation = walkDown;
        }

        public Hero(Texture2D texture, IInputReader inputReader, IGameCommand mvCommand)
        {
            this.heroTexture = texture;
            currentAnimation = walkDown;

            //Read input for hero class
            this.reader = inputReader;
            this.moveCommand = mvCommand;

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 62, 110);
            Position = new Vector2(0, 800);
        }

        private void move(Vector2 _direction)
        {
            if (_direction.X == -1)
                currentAnimation = walkLeft;
            else if (_direction.X == 1)
                currentAnimation = walkRight;
            else if (_direction.Y == -1)
                currentAnimation = walkUp;
            if (_direction.X == 0 && _direction.Y == 0)
                currentAnimation = walkDown;

            //jumping movement
            if (_direction.Y == -1 && HasJumped == false)
            {
                Velocity = new Vector2(Velocity.X, -10f);
                HasJumped = true;
            }

            Position += Velocity;
            if (Velocity.Y < 20)
                Velocity += new Vector2(Velocity.X, 0.9f);

            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            var direction = reader.ReadInput();
            this.gameTime = gameTime;
            if (direction.X != 0 || direction.Y != 0)
                //animatie.Update(gameTime);
                currentAnimation.Update(this.gameTime);

            move(direction);

            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;
            CollisionRectangle = _collisionRectangle;
        }
    }
}
