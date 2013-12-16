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
    public class StartScene : IState //de class startScene implementeerd de interface IState.
    {
        //Fields
        private PyramidPanic game;

        public StartScene(PyramidPanic game)
        {
            this.game = game;
        }

        public void Intialize()
        {


        }

        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right) || Input.EdgeDetectMousePressLeft())
            {
                this.game.IState = this.game.GameOverScene;
            }

            if (Input.EdgeDetectKeyDown(Keys.Left) || Input.EdgeDetectMousePressRight())
            {
                this.game.IState = this.game.HelpScene;
            }

        }

        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Yellow);
            
            
        }
    }
}
