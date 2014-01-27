// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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

namespace PyramidPanic
{
    public class AnimatedSprite
    {
        //Fields
        private IAnimatedSprite iAnimatedSprite;
        protected Rectangle destinationRectangle, sourceRectangle;
        private float timer = 0f;
        protected SpriteEffects effect;
        protected int imageNumber = 1; //Loopt van 0 tm 3
        protected float rotation = 0f;
        private Vector2 pivot;

        // De constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            this.iAnimatedSprite = iAnimatedSprite;
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);            
            this.effect = SpriteEffects.None;
            this.pivot = new Vector2(16f, 16f);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (this.timer > 5 / 60f)
            {
                if (this.sourceRectangle.X < 96)
                {
                    this.sourceRectangle.X += 32;
                }
                else
                {
                    this.sourceRectangle.X = 0;
                }
                this.timer = 0f;
            }
            this.timer += 1 / 60f;
        }


        // Draw method van de AnimatedSprite class
        public void Draw(GameTime gameTime)
        {
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture,
                                              this.destinationRectangle,
                                              this.sourceRectangle,
                                              Color.White,
                                              this.rotation,
                                              this.pivot,
                                              this.effect,
                                              0f);              
        }
    }
}
