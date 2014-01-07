using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TrialOfHermes2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, enemy, heroRightLeft;
        heroSprite heroSprite;
        Point frameSize = new Point(24, 26);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(8, 4);
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 70;
        Vector2 heroPosition = new Vector2(340, 250);
        const float heroSpeed = 2;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            background = Content.Load<Texture2D>(@"background");
            enemy = Content.Load<Texture2D>(@"enemy");
            heroSprite = new heroSprite(Content.Load<Texture2D>(@"heroSpriteBasicMove"), 1, 24, 26);
            heroSprite.Position = new Vector2(340, 250);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            heroSprite.HandleSpriteMovement(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
                {
                GraphicsDevice.Clear(Color.DarkOliveGreen);

            spriteBatch.Begin();
            spriteBatch.Draw(heroSprite.Texture, heroSprite.Position, heroSprite.SourceRect, Color.White, 0f, heroSprite.Origin, 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(enemy, new Vector2(200,400), Color.White);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
