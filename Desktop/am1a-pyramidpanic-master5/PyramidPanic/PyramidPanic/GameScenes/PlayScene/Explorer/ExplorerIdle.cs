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
    
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;
        private Vector2 velocity;
        private int imageNumber = 1;
       
        //properties
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }

        public float Rotation
        {
            set { this.rotation = value; }
        }

        //Constructor
        public ExplorerIdle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                      (int)this.explorer.Position.Y,
                                                      32,
                                                      32);
            this.sourceRectangle = new Rectangle(this.imageNumber * 32, 0, 32, 32);
            this.velocity = new Vector2(0f, 0f);
        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            //Bij het indrukken van de Right knop moet de toestand van de explorer veranderen in
            // ExplorerWalkRight
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
                this.explorer.WalkRight.Initialize();

            }
            else if (Input.LevelDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
                this.explorer.WalkLeft.Initialize();
            }
            else if (Input.LevelDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.WalkDown;
                this.explorer.WalkDown.Initialize();
            }
            else if (Input.LevelDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.WalkUp;
                this.explorer.WalkUp.Initialize();
            }
            

            this.explorer.Position += this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //base.Update(gameTime);
        }


        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
