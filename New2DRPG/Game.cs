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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using New2DRPG.CoreComponents;


namespace New2DRPG
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        StartScreen startScreen;
        HelpScreen helpScreen;
        GameScreen activeScreen;
        SpriteFont normalFont;
        Texture2D background;
        KeyboardState newState;
        KeyboardState oldState;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            normalFont = Content.Load<SpriteFont>("normal");
            background = Content.Load<Texture2D>("gryphon");
            startScreen = new StartScreen(this, normalFont, background);
            Components.Add(startScreen);
            background = Content.Load<Texture2D>("fire-dragon");
            helpScreen = new HelpScreen(this, background);
            Components.Add(helpScreen);
            startScreen.Show();
            helpScreen.Hide();
            activeScreen = startScreen;
        }
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            newState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
            ButtonState.Pressed)
                this.Exit();
            if (activeScreen == startScreen)
            {
                HandleStartScreenInput();
            }
            else if (activeScreen == helpScreen)
            {
                HandleHelpScreenInput();
            }
            oldState = newState;
            base.Update(gameTime);
        }

        private void HandleHelpScreenInput()
        {
            if (CheckKey(Keys.Space) ||
            CheckKey(Keys.Enter) ||
            CheckKey(Keys.Escape))
            {
                activeScreen.Hide();
                activeScreen = startScreen;
                activeScreen.Show();
            }
        }

        private void HandleStartScreenInput()
        {
            if (CheckKey(Keys.Enter) || CheckKey(Keys.Space))
            {
                switch (startScreen.SelectedIndex)
                {
                    case 0:
                        activeScreen.Hide();
                        activeScreen = helpScreen;
                        activeScreen.Show();
                        break;
                    case 1:
                        Exit();
                        break;
                }
            }
        }
        private bool CheckKey(Keys theKey)
        {
            return oldState.IsKeyDown(theKey) && newState.IsKeyUp(theKey);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}