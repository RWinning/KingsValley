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
    public class ExplorerManager
    {
        // Fields
        // Leg de level instantie vast
        private static Level level;

        // Leg de explorer instantie vast
        private static Explorer explorer;

        // Properties
        public static Level Level
        {
            set { level = value; }
        }
        public static Explorer Explorer
        {
            set { explorer = value; }
        }


        // Constructor
        public ExplorerManager()
        {

        }


        // Methods
        public static bool CollisionDectectionExplorerWalls()
        {
            // Doorloop het tweedimensionale Blocksarray en ....
            // eerst de rijen ( getLength(0) geeft het aantal rijen)
            for (int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                // voor iedere rij wil je alle kolommen doorlopen
                // getLength(1) geeft het aantal kolommen
                for (int j = 0; j < level.Blocks.GetLength(1); j++)
                {
                    // Onderzoek voor ieder Blockelement in het array of de property
                    // Passable de waarde true heeft.
                    if (level.Blocks[i, j].Passable == false)
                    {
                        // Onderzoek of de rectangles van het BlockElement en de Explorer
                        // elkaar overlappen. Geef dan de waarde true terug anders false
                        if (explorer.CollisionRect.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            //Console.WriteLine("Ik raak een muur element i = " + i + " j = " + j);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}