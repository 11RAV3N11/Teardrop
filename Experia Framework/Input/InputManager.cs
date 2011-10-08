using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework.Controls;

namespace Experia.Framework.Components
{
    public class InputManager
    {
        protected MouseExtension m_Mouse;
        protected KeyboardExtension m_Keyboard;
        protected GamePadExtension m_GamePad;

        protected bool m_EnableGamePad, m_EnableMouse, m_EnableKeyboard;

        public void EnableGamePad()
        {
            if (m_GamePad == null)
            {
                m_GamePad = new GamePadExtension();
                //Todo Write script to detect if a controller is in...
            }
        }

        public void EnableMouse(Texture2D mouseTexture, bool clampToWindow)
        {
            if (m_Mouse == null)
            {
                m_Mouse = new MouseExtension();
                m_Mouse.Initialize(mouseTexture, clampToWindow);
            }
        }

        public InputManager Instance
        {
            get { return Experia.Framework.Generics.Singleton<InputManager>.Instance; }
        }
        protected InputManager()
        {
            m_Mouse = new MouseExtension();
            if (Microsoft.Xna.Framework.Input.Keyboard.GetState() != null) //<-- If it's null we are on a 360
            {
                m_Keyboard = new KeyboardExtension();
            }
            m_GamePad = new GamePadExtension();
        }
        public void Update(Rectangle windowBounds)
        {
            m_Mouse.Update(windowBounds);
            m_Keyboard.Update();

            if (m_EnableGamePad)
            {
                m_GamePad.Update();
            }
        }
    }
}
