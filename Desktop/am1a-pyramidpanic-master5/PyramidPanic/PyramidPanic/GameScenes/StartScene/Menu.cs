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
    public class Menu
    {
        //Fields
        // Maak een enumeration voor de buttons die op het scherm te zien zijn
        private enum Buttons { Start, Load, Help, Scores, Quit }
        //                      0       1     2     3       4
        // Maak een variabele van het type Buttons en geef hem de naam waarde Buttons.Start
        private Buttons buttonActive = Buttons.Start;

        //Maak een variabele (reference) van het type Image
        private Image start, load, help, scores, quit;

        //Deze variabelen zorgen voor de juiste afstand tussen de knopen
        private int top = 20, bottom = 430, space = 120;

        // Maak een variabele aan activeColor. Dit is de kleur van de actieve knop
        private Color activeColor = Color.Gold;

        //Maak een variabele (reference) van het type PyramidPaniic
        private PyramidPanic game;

        // Maak een variabele buttonList van het type List<Image>
        private List<Image> buttonList;


        //Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        public void Initialize()
        {
            this.LoadContent();
        }

        public void LoadContent()
        {
            // Maak een instantie aan van de List<Image> type en stop deze in de variabele this.buttonList
            this.buttonList = new List<Image>();
            this.buttonList.Add(this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(this.top, this.bottom)));
            this.buttonList.Add(this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(this.top + 1 * this.space, this.bottom)));
            this.buttonList.Add(this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(this.top + 2 * this.space, this.bottom)));
            this.buttonList.Add(this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(this.top + 3 * this.space, this.bottom)));
            this.buttonList.Add(this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(this.top + 4 * this.space, this.bottom)));
        }


        //Update
        public void Update(GameTime gameTime)
        {
            /* Deze if - instructie checked of er op de rechterpijltoets wordt gedrukt.
             * De actie die daarop volgt is het ophogen van de variabele buttonActive
             */
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.ChangeButtonColorToNormal();
                this.buttonActive++;
            }

            /* Deze if - instructie checked of er op de linkerpijltoets wordt gedrukt.
             * De actie die daarop volgt is het verlagen van de variabele buttonActive
             */
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.ChangeButtonColorToNormal();
                this.buttonActive--;
            }  
            
            /* Door boven een button te staan met de muiscursor verandert de 
             * knopkleur naar de activeColor waarde. Door ook nog met de muis
             * links te klikken ga je naar de betreffende gameScene
             */
            if (this.start.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.IState = this.game.PlayScene;
                }
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Start;
                this.start.Color = this.activeColor;
            }
            else if (this.load.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.IState = this.game.LoadScene;
                }
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Load;
                this.load.Color = this.activeColor;
            }
            else if (this.help.Rectangle.Intersects(Input.MouseRect()))
            {
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Help;
                this.help.Color = this.activeColor;
            }
            else if (this.scores.Rectangle.Intersects(Input.MouseRect()))
            {
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Scores;
                this.scores.Color = this.activeColor;
            }
            else if (this.quit.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.IState = this.game.QuitScene;
                }                
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Quit;
                this.quit.Color = this.activeColor;
            }
            else
            {
                // Beschijn alle knoppen weer met wit licht.
                this.ChangeButtonColorToNormal();
                
                // Maak een switch case instructie voor de variabele buttonActive
                switch (this.buttonActive)
                {
                    case Buttons.Start:
                        // De Ternary operator:
                        // variabele = (vergelijking) ? waarde als waar : waarde als niet waar;
                        this.game.IState = (Input.EdgeDetectKeyDown(Keys.Enter))
                                ? (IState)this.game.PlayScene : this.game.StartScene;
                        this.start.Color = this.activeColor;
                        break;
                    case Buttons.Load:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            this.game.IState = this.game.LoadScene;
                        }
                        this.load.Color = this.activeColor;
                        break;
                    case Buttons.Scores:
                        this.scores.Color = this.activeColor;
                        break;
                    case Buttons.Help:
                        this.help.Color = this.activeColor;
                        break;
                    case Buttons.Quit:
                        if (Input.EdgeDetectKeyDown(Keys.Enter))
                        {
                            this.game.IState = this.game.QuitScene;
                        }
                        this.quit.Color = this.activeColor;
                        break;
                }
            }
        }


        //Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.buttonList)
            {
                image.Draw(gameTime);
            }
        }

        /* Helper method voor het met wit licht beschijnen van de buttons
         */
        private void ChangeButtonColorToNormal()
        {
            /* We doorlopen het this.buttonList object (type List<Image>) met een foreach instructie
             * en we roepen voor ieder image-object de propertie Color op en geven deze de
             * waarde Color.White.
             */
            foreach (Image image in this.buttonList)
            {
                image.Color = Color.White;
            }
        }
    }
}
