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
    public class BeetleManager
    {
        //Fields
        private static Level level;

        // Properties
        public static Level Level
        {
            set { 
                    level = value;
                    CollisionDetectBeetleDown();
                    CollisionDetectBeetleUp();   
                }
        }

        public static void CollisionDetectBeetleDown()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int j = (int)(beetle.Position.Y / 32); j <= 15; j++)
                {
                    if (level.Blocks[(int)(beetle.Position.X / 32), j].Passable == false)
                    {
                        beetle.BottomBorder = (j - 1) * 32 + 16;
                        break;
                    }
                }
            }
        }

        public static void CollisionDetectBeetleUp()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int j = (int)(beetle.Position.Y / 32); j >= 0; j--)
                {
                    if (level.Blocks[(int)(beetle.Position.X / 32), j].Passable == false)
                    {
                        beetle.TopBorder = (j + 1) * 32 + 16;
                        break;
                    }
                }
            }
        } 
    }
}
