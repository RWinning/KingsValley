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
    public class Explorer : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;
        private Rectangle collisionRect;
        private Texture2D collisionText;


        //Maak van iedere toestand (state) een field
        //private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkUp walkUp;
        private ExplorerWalkLeft walkLeft;
        private ExplorerWalkRight walkRight;
        private ExplorerIdle idle;
        private ExplorerIdleWalk idleWalk;

        //properties
        public Rectangle CollisionRect
        {
            get { return this.collisionRect; }
        }
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkUp; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public ExplorerIdle Idle
        {
            get { return this.idle; }
        }
        public ExplorerIdleWalk IdleWalk
        {
            get { return this.idleWalk; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                this.collisionRect.X = (int)this.position.X - 16;
                this.collisionRect.Y = (int)this.position.Y - 16;
                this.state.Initialize();
            }
        }
        public IEntityState State
        {
            set
            {
                this.state = value;
                this.state.Initialize();
            }
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
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Explorer\Explorer");
            this.collisionRect = new Rectangle((int)position.X - 16, (int)position.Y - 16, 32, 32);
            this.collisionText = this.game.Content.Load<Texture2D>(@"Scorpion\CollisionText");
            this.walkDown = new ExplorerWalkDown(this);
            this.walkUp = new ExplorerWalkUp(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.walkRight = new ExplorerWalkRight(this);
            this.idle = new ExplorerIdle(this);
            this.idleWalk = new ExplorerIdleWalk(this);
            this.state = this.idle;
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
            //this.game.SpriteBatch.Draw(this.collisionText, this.collisionRect, new Color(255, 0, 0, 0));     
        }
    }
}