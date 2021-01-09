using Game1;
using game2020.Animation.HeroAnimations;
using game2020.Backgrounds;
using game2020.Collision;
using game2020.Commands;
using game2020.Controls;
using game2020.GameScreen;
using game2020.Input;
using game2020.Interfaces;
using game2020.Players;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace game2020
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Menu
        private bool gameStarted = false;
        private int count = 0;
        private Texture2D deadTextTexture;
        private Rectangle deadTextRectangle;
        private Button btnPlay, btnQuit;

        private IScreenUpdater screenUpdater;
        private IGameCommand gameCommand;

        private Camera camera;

        private CollisionManager collisionManager;
        private CollisionWithEnemy collisionWithEnemy;

        private Level level;
        private Level1 lv1;
        private Level2 lv2;

        private Texture2D textureHero;
        private Hero hero;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Option for resizing screen
            screenUpdater = new ScreenUpdate();
            // screenUpdater.UpdateScreen(_graphics, 1280, 720);

            // Menu buttons
            btnPlay = new Button();
            btnQuit = new Button();

            gameCommand = new MoveCommand();

            collisionManager = new CollisionManager(new CollisionHelper());
            collisionWithEnemy = new CollisionWithEnemy();
            collisionWithEnemy.IsCollision = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load level
            //Tile.Content = Content;
            lv1 = new Level1(Content);
            lv2 = new Level2(Content);
            level = lv1;

            // Load menu content
            btnPlay.Load(Content.Load<Texture2D>("Menu/start_normal"), new Vector2(280, 150));
            btnQuit.Load(Content.Load<Texture2D>("Menu/quit_normal"), new Vector2(300, 280));
            deadTextTexture = Content.Load<Texture2D>("Menu/deadText");
            deadTextRectangle = new Rectangle(100, 0, deadTextTexture.Width, deadTextTexture.Height);

            camera = new Camera(GraphicsDevice.Viewport);

            // Load players content
            textureHero = Content.Load<Texture2D>("Players/thief");

            initialzeGameObjects();
        }

        private void initialzeGameObjects()
        {
            hero = new Hero(textureHero, new KeyBoardReader(), gameCommand);
            hero.HeroWalkAnimation(new WalkRightAnimation(textureHero, hero), new WalkLeftAnimation(textureHero, hero),
                                   new WalkUpAnimation(textureHero, hero), new WalkDownAnimation(textureHero, hero));
        }

        private void intro(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            if (!gameStarted)
            {
                if (collisionWithEnemy.IsCollision)
                {
                    btnPlay.isClicked = false;
                    gameStarted = true;
                    collisionWithEnemy.IsCollision = false;
                }

                // Player and background update
                hero.Update(gameTime);
                foreach (Scrolling scrolling in level.ScrollingLayer)
                    scrolling.Update();
            }
            else if (gameStarted)
            {
                if (btnPlay.isClicked)
                    gameStarted = false;
                if (btnQuit.isClicked)
                    Exit();

                btnPlay.Update(mouse);
                btnQuit.Update(mouse);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Intro menu
            intro(gameTime);

            if (collisionManager.IsCollisionWithExit)
                level = lv2;

            // Scrolling backgrounds
            foreach (Scrolling scrolling in level.ScrollingLayer)
                if (scrolling.rectangle.X + scrolling.texture.Width <= 0)
                    scrolling.rectangle.X = 3200;
           
            foreach (CollisionTiles tile in level.CollisionTiles)
            {
                camera.Update(hero.Position, level.Width, level.Height);
                collisionManager.UpdateCollision(hero.CollisionRectangle, tile.Rectangle, level.Width, level.Height, hero);

                collisionManager.LevelCollision(hero.CollisionRectangle, tile.Rectangle, tile.texture, hero);
            }

            if (level.Enemies != null)
            {
                foreach (Enemy enemy in level.Enemies)
                {
                    enemy.Update(hero);
                    collisionWithEnemy.Handle(collisionManager, hero);
                    collisionManager.CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            _spriteBatch.Begin();
            if (gameStarted)
            {
                if (count > 1)
                    _spriteBatch.Draw(deadTextTexture, deadTextRectangle, Color.AliceBlue);

                btnPlay.Draw(_spriteBatch);
                btnQuit.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               camera.Transform);

            if (!gameStarted)
            {
                if (count < 2)
                    count++;

                foreach (Layer layer in level.Layers)
                    layer.Draw(_spriteBatch);

                // level.ScrollingLayer.Draw(_spriteBatch);
                foreach (Scrolling scrolling in level.ScrollingLayer)
                    scrolling.Draw(_spriteBatch);

                level.Draw(_spriteBatch);

                hero.Draw(_spriteBatch);

                foreach (Enemy enemy in level.Enemies)
                    enemy.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
