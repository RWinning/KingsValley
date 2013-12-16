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

    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Maak een variable aan van het type StartScene
        private StartScene startScene;
        private PlayScene playScene;
        private HelpScene helpScene;
        private GameOverScene gameOverScene;

        //maak een variable ISate aan met type interface.
        private IState iState;


        #region Proberties
        //proberties
        //maak de interface variable iState beschikbaar buiten de class d.m.v. 
        //een propertie IState
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }

        }

        //maak het field this.startScene beschikbaar buiten de class d.m.v
        //een propertie StartScene
        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        //maak het field this.playScene beschikbaar buiten de class d.m.v
        //een propertie PlayScene
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        //maak het field this.helpScene beschikbaar buiten de class d.m.v
        //een propertie HelpScene
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        //maak het field this.gameOverScene beschikbaar buiten de class d.m.v
        //een propertie GameOverScene
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }
        
        #endregion
        //Dit is de constructor. Heeft altijd dezelfde naam als de class.
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Verander de titel van het canvas
            Window.Title = "Pyramid Panic Beta 00.00.00.01";

            // Maakt de muis zichtbaar
            IsMouseVisible = true;

            // Verandert de breedte van het canvas.
            this.graphics.PreferredBackBufferWidth = 640;

            // Verandert de hoogte van het canvas.
            this.graphics.PreferredBackBufferHeight = 480;

            // Past de nieuwe hoogte en breedte toe.
            this.graphics.ApplyChanges();

            this.iState = this.gameOverScene;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Een spritebatch is nodig voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //We maken nu het object/instalatie aan van het type Startscene. Dit doe je door
            //de constructor aan te roepen van de Startscene class.
            this.startScene = new StartScene(this);
            this.playScene = new PlayScene(this);
            this.helpScene = new HelpScene(this);
            this.gameOverScene = new GameOverScene(this);
            this.iState = this.startScene;
        }
        
        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Zorgt dat het spel stopt wanneer je op de gamepad button Back indrukt
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
            Input.Update();
            //De update methode van het object die toegewesen is aan het interface object
            //this.IState word aan geroepen.
            this.iState.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            //Geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.Black);
            

            //Voor een spriteBatch iets kan tekenen moet Begin() method
            //aangeroepen worden.

            this.spriteBatch.Begin();

            //De draw methode van het object die toegewesen is aan het interface object
            //this.IState word aan geroepen.
            this.iState.Draw(gameTime);

            //Nadat de spriteBatch.Draw() is aangeroepen moet End() method van de
            //SpriteBatch class worden aangeroepen.
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}