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
    public class Block : Image
    {
        //Fields
        private bool passable;

        //Properties
        public bool Passable
        {
            get { return passable; }
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        //Constructor
        public Block(PyramidPanic game, string pathNameAsset, Vector2 position, bool passable)
            : base(game, pathNameAsset, position)
        {
            this.passable = passable;
        }

        //Update

        //Draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
