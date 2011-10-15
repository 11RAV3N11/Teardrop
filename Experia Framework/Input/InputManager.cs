using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework.Controls;

namespace Experia.Framework
{
    public class InputManager
    {
        public static InputManager Instance
        {
            get { return Experia.Framework.Generics.Singleton<InputManager>.Instance; }
        }

        public MouseExtension Mouse;
        public KeyboardExtension Keyboard;
        public GamePadExtension GamePad;

        protected bool m_EnableGamePad, m_EnableMouse, m_EnableKeyboard;

        public void EnableGamePad()
        {
            if (GamePad == null)
            {
                GamePad = new GamePadExtension();
                //Todo Write script to detect if a controller is in...
            }
        }

        public void EnableMouse(Texture2D mouseTexture, bool clampToWindow)
        {
            if (Mouse == null)
            {
                Mouse = new MouseExtension(mouseTexture, clampToWindow);
            }
        }
        protected InputManager()
        {
            if (Microsoft.Xna.Framework.Input.Keyboard.GetState() != null) //<-- If it's null we are on a 360
            {
                Keyboard = new KeyboardExtension();
            }
        }
        public void Update(Rectangle windowBounds)
        {
            Mouse.Update(windowBounds);
            Keyboard.Update();

            if (m_EnableGamePad)
            {
                GamePad.Update();
            }
        }
    }
}
