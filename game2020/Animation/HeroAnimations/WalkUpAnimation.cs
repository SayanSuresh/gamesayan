using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Animation.HeroAnimations
{
    class WalkUpAnimation : IEntityAnimation
    {
        private Texture2D texture;
        private ITransform transform;
        private AnimationManager _animation;

        public AnimationManager Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public WalkUpAnimation(Texture2D texture, ITransform transform)
        {
            this.texture = texture;
            this.transform = transform;
            Animation = new AnimationManager();
            Animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 48, 62)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(48, 0, 48, 62)));
            Animation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 48, 62)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.Position, Animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            Animation.Update(gameTime);
        }
    }
}
