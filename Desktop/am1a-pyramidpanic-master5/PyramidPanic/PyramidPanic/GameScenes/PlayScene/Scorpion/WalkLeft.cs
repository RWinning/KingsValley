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
    // Dit is een toestands class (dus moet hij de interface implementeren)
    // Deze class belooft dan plechtig dat hij de methods uit de interface heeft (toepast)
    
    public class WalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        private Scorpion scorpion;
        private Vector2 velocity;

        //Contstructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.effect = SpriteEffects.FlipHorizontally;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                      32,
                                                      32);
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X < this.scorpion.LeftBorder)
            {
                //Breng de beetle in de toestand walkdown
                this.scorpion.State = this.scorpion.WalkRight;
                this.scorpion.WalkRight.Initialize();
            }
            this.scorpion.Position -= this.velocity;
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            base.Update(gameTime);
        }


        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
