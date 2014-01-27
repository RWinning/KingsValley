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
    
    public class ExplorerWalkRight : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;
        private Vector2 velocity;

        //Contstructor
        public ExplorerWalkRight(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            this.velocity = new Vector2(this.explorer.Speed, 0f);
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            // Deze code zorgt ervoor dat de explorer niet buiten de rechterrand
            // kan lopen.
            if (this.explorer.Position.X > 640 - 16)
            {
                //Breng de explorer in de toestand Idle
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Initialize();
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Position -= this.velocity;
            }
            

            // Als de Right knop wordt losgelaten, dan moet de 
            // explorer weer in de toestand Idle komen
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Initialize();
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = 0f;
            }
            this.explorer.Position += this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            base.Update(gameTime);
        }


        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
