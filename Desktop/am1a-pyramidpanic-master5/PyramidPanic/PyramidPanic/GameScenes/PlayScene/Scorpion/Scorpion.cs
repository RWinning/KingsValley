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
    public class Scorpion : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;
        private WalkLeft walkLeft;
        private WalkRight walkRight;
        private int rightBorder;
        private int leftBorder;
        private Rectangle collisionRect;


        //properties
        public int RightBorder
        {
            get { return this.rightBorder; }
            set { this.rightBorder = value; }
        }
        public int LeftBorder
        {
            get { return this.leftBorder; }
            set { this.leftBorder = value; }
        }
        public Rectangle CollisionRect
        {
            get {
                    this.collisionRect.X = (int)this.position.X - 16;
                    this.collisionRect.Y = (int)this.position.Y - 16;
                    return this.collisionRect;
                }
        }
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public IEntityState State
        {
            set { this.state = value; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        
        //Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.collisionRect = new Rectangle((int)this.position.X - 16,
                                               (int)this.position.Y - 16,
                                               32,
                                               32);
            this.texture = game.Content.Load<Texture2D>(@"Scorpion\Scorpion");
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
        }

        //Update
        public void Update(GameTime gameTime)
        {
           this.state.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        { 
            this.state.Draw(gameTime);                
        }
    }
}
