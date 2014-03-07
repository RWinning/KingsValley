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
    public class StartScene : IState // De class StartScene implementeert de interface IState
    {
        //Fields van de class StartScene
        private PyramidPanic game;

        // Maak een variabele (reference) aan van de Image class genaamd background
        private Image background, title;

        // Maak een variabele (reference) aan van de Menu class genaamd menu
        private Menu menu;

        // Constructor van de StartScene-class krijgt een object game mee van het type PyramidPanic
        public StartScene(PyramidPanic game)
        {
            this.game = game;

            // Roep de Initialize method aan
            this.Initialize();
        }

        // Initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen).
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {
            
            //Roep de LoadContent method aan
            this.LoadContent();
        }

        // LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {
            // Nu maken we twee objecten (instanties) van de class Image
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
            this.menu = new Menu(this.game);
        }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz.......
        public void Update(GameTime gameTime)
        {
            // Hier wordt de Update method van het menu-object aangeroepen
            this.menu.Update(gameTime);
        }

        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Purple);
            
            // Roep de Draw method aan van het background object
            this.background.Draw(gameTime);

            // Roep de Draw method aan van het title object
            this.title.Draw(gameTime);

            // Roep de Draw method aan van het menu object
            this.menu.Draw(gameTime);
        }
    }
}
