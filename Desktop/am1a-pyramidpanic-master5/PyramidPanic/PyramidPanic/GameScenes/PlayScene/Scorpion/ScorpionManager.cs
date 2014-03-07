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
    public class ScorpionManager
    {
        // Fields
        private static Level level;

        // Property
        public static Level Level
        {
            set { 
                  level = value;
                  CollisionDetectScorpionRight();
                  CollisionDetectScorpionLeft();
                }
        }

        public static void  CollisionDetectScorpionRight()
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                for (int i = (int)(scorpion.Position.X/ 32); i <= 20; i++)
                {
                    if (level.Blocks[i, (int)(scorpion.Position.Y / 32)].Passable == false)
                    {
                        scorpion.RightBorder = (i - 1) * 32 + 16;
                        break;
                    }
                }
            }
        }

        public static void CollisionDetectScorpionLeft()
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                for (int i = (int)(scorpion.Position.X / 32); i >= 0; i--)
                {
                    if (level.Blocks[i, (int)(scorpion.Position.Y / 32)].Passable == false)
                    {
                        scorpion.LeftBorder = (i + 1) * 32 + 16;
                        break;
                    }
                }
            }
        }

    }
}
