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
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        //dit is een rectangle die aan de muiscursos zit vastgeplakt
        private static Rectangle mouseRect;

        //Constructor
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oms = ms;
            oks = ks;
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
        }
        //Update
        public static void Update()
        {
            oms = ms;
            oks = ks;
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
        }

        //dit is de edgedetector voor het indrukken van een knop
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //dit is de edgedetector voor het signaleren of een knop niet ingedrukt is en de vorige update wel ingedrukt was
        public static bool EdgeDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key) && oks.IsKeyDown(key));
        }

        public static bool EdgeDetectMousePressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);
        }

        public static bool EdgeDetectMousePressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }

        //dit is een leveldetector voor het detecteren of een keyboardtoets is ingedrukt.
        public static bool LevelDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key));
        }
        //dit is een leveldetector voor het detecteren of een keyboardtoets niet is ingedrukt.
        public static bool LevelDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key));
        }

        public static Vector2 Mouseposition()
        {
            return new Vector2 (ms.X, ms.Y);
        }


        public static Rectangle MouseRect()
        {
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            return mouseRect;
        }
    }
}
