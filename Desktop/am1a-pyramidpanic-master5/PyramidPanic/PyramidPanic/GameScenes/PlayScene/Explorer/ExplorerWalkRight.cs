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
        public ExplorerWalkRight(Explorer explorer)
            : base(explorer)
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
            this.explorer.Position += this.velocity;

            // Als de explorer tegen een block instantie aanloopt waarvan
            // de Passable property op false staat, kan hij er niet daarheen
            if (ExplorerManager.CollisionDectectionExplorerWalls())
            {
                // Ze de explorer weer terug
                this.explorer.Position -= this.velocity;
            }

            if (this.explorer.Position.X > 640 - 16)
            {
                //Breng de explorer in de toestand IdleWalk
                this.explorer.Position -= this.velocity;
                this.explorer.State = this.explorer.IdleWalk;
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                this.explorer.IdleWalk.Rotation = 0f;
            }


            // Als de Right knop wordt losgelaten, dan moet de 
            // explorer weer in de toestand Idle komen
            if (Input.LevelDetectKeyUp(Keys.Right))
            {
                // Bereken de modulo waarde 32 van de x-positie van de explorer
                int modulo = (int)this.explorer.Position.X % 32;
                //Console.WriteLine((int)this.explorer.Position.X);
                //Console.WriteLine(modulo);

                //Check of de modulo waarde al groter of gelijk aan 30 is
                // Als dat niet geval is niet stoppen, anders wel stoppen
                if (modulo >= 16 - this.explorer.Speed && modulo <= 16)
                {
                    // Zet de laatste stap op zijn grid
                    int geheelAantalmalen32 = (int)(this.explorer.Position.X / 32);
                    //Console.WriteLine(geheelAantalmalen32);
                    this.explorer.Position = new Vector2((geheelAantalmalen32 + 1) * 32 - 16,
                                                          this.explorer.Position.Y);

                    this.explorer.State = this.explorer.Idle;
                    this.explorer.Idle.Effect = SpriteEffects.None;
                    this.explorer.Idle.Rotation = 0f;
                }
            }

            base.Update(gameTime);
        }


        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}