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
        
        // Maak een variabele aan van het type StartScene
        private StartScene startScene;

        // Maak een variabele aan van het type PlayScene
        private PlayScene playScene;

        // Maak een variabele aan van het type HelpScene
        private HelpScene helpScene;

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene gameOverScene;

        // Maak een variabele aan van het type LoadScene
        private LoadScene loadScene;

        // Maak een variabele aan van het type QuitScene
        private QuitScene quitScene;

        // Maak een variabele iState aan van het type interface IState
        private IState iState;
                
        #region Properties        
        // Maak de interface variabele iState beschikbaar buiten de class d.m.v
        // een property IState
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }

        // Maak het field this.startScene beschikbaar buiten de class d.m.v een
        // property StartScene
        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        // Maak het field this.playScene beschikbaar buiten de class d.m.v een
        // property PlayScene
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        // Maak het field this.helpScene beschikbaar buiten de class d.m.v een
        // property HelpScene
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        // Maak het field this.gameOverScene beschikbaar buiten de class d.m.v een
        // property GameOverScene
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }

        // Maak het field this.loadScene beschikbaar buiten de class d.m.v een
        // property LoadScene
        public LoadScene LoadScene
        {
            get { return this.loadScene; }
        }

        public QuitScene QuitScene
        {
            get { return this.quitScene; }
        }

        // Maak het field this.spriteBatch beschikbaar buiten de class d.m.v een
        // property SpriteBatch
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
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
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Een spritebatch is nodig voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // We maken nu het object/instantie aan van het type startScene. Dit doe je door 
            // de constructor aan te roepen van de StartScene class.
            this.startScene = new StartScene(this);

            // Nieuwe instantie van de PlayScene class
            this.playScene = new PlayScene(this);

            // Nieuwe instantie van de HelpScene class
            this.helpScene = new HelpScene(this);

            // Nieuwe instantie van de GameOverScene
            this.gameOverScene = new GameOverScene(this);

            // Nieuwe instantie (object) van de LoadScene class
            this.loadScene = new LoadScene(this);

            // Nieuwe instantie (object) van de QuitScene class
            this.quitScene = new QuitScene(this);

            
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

            // De Update method van de static Input class wordt aangeroepen
            Input.Update();

            // De Update methode van het object dat toegewezen is aan het interface-object
            // this.iState wordt aangeroepen.
            this.iState.Update(gameTime);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            //Geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.Black);
            
            // Voor een spriteBatch instantie iets kan tekenen moet de Begin() methode
            // aangeroepen worden van de SpriteBatch class
            this.spriteBatch.Begin();

            // De Draw methode van het object dat toegewezen is aan het interface-object
            // this.iState wordt aangeroepen.
            this.iState.Draw(gameTime);

            // Nadat de spriteBatch.Draw() is aangeroepen moet de End() methode van de
            // SpriteBatch class worden aangeroepen
            this.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
