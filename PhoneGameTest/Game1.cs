using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace PhoneGameTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameSprite _background, _enemy;
        Hero2D _hero;
        RenderContext _renderContext;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _renderContext = new RenderContext();
            _background = new GameSprite("Background");
            _enemy = new GameSprite("Enemy");
            _hero = new Hero2D();
            _hero.Initialize();

            _enemy.Position = new Vector2(10, 10);
            

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderContext.SpriteBatch = spriteBatch;
            _renderContext.GraphicsDevice = graphics.GraphicsDevice;

            _background.LoadContent(Content);
            _enemy.LoadContent(Content);
            _hero.LoadContent(Content);

        }

        protected override void UnloadContent()
        {
          
        }

       
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            _renderContext.GameTime = gameTime;
            _enemy.Update(_renderContext);
            _hero.Update(_renderContext);
            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            
            spriteBatch.Begin();
            _background.Draw(_renderContext);
            _enemy.Draw(_renderContext);
            _hero.Draw(_renderContext);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
