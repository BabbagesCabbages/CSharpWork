using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PhoneGameTest
{
    public class Hero2D : GameObject2D
    {
        
        private int _direction = 1;
        private const int Speed = 60;
        private GameAnimatedSprite _heroSprite;
        private const int FrameWidth = 32;

        public override void Initialize()
        {
            _heroSprite = new GameAnimatedSprite("Hero_SpriteSheet",8,80,new Point (FrameWidth,39));
            _heroSprite.Position = new Vector2(10, 348);

            _heroSprite.PlayAnimation(true);
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _heroSprite.LoadContent(contentManager);
        }

        public override void Update(RenderContext renderContext)
        {
            _heroSprite.Update(renderContext);

            var heroPos = _heroSprite.Position;
            if (_direction == 1 && heroPos.X >= renderContext.GraphicsDevice.Viewport.Width
                - (FrameWidth * _heroSprite.Scale.X))
            {
                _direction = -1;
                _heroSprite.Effect = SpriteEffects.FlipHorizontally;
            }

            else if (_direction == -1 && heroPos.X < 0)
            {
                _direction = 1;
                _heroSprite.Effect = SpriteEffects.None;
            }

            heroPos.X += (float)(Speed * renderContext.GameTime.ElapsedGameTime.TotalSeconds * _direction);

            _heroSprite.Position = heroPos;
        }

        public override void Draw(RenderContext renderContext)
        {
           _heroSprite.Draw(renderContext);
        }
    }
}
