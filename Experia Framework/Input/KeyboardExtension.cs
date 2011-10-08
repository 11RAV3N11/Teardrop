using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Experia.Framework.Controls
{
    public class KeyboardExtension
    {
        protected KeyboardState m_CurrentState, m_PreviousState;
        protected Keys[] m_KeysPressed, m_PrevKeysPressed;
        public void Initialize()
        {
            m_CurrentState = new KeyboardState();
            m_PreviousState = new KeyboardState();
            m_CurrentState = Keyboard.GetState();
            m_PreviousState = Keyboard.GetState();
            m_KeysPressed = m_CurrentState.GetPressedKeys();
            m_PrevKeysPressed = m_PreviousState.GetPressedKeys();
        }
        public void Update()
        {
            //Update the previous states
            m_PreviousState = m_CurrentState;
            m_PrevKeysPressed = m_PreviousState.GetPressedKeys();

            m_CurrentState = Keyboard.GetState();
            m_KeysPressed = m_CurrentState.GetPressedKeys();
        }
        /// <summary>(bool) Checks to see if a key has been pressed [INFO: Checks for non-spamming key presses]</summary>
        public bool CheckKeyPressed(Keys Key)
        {
            if (m_CurrentState.IsKeyDown(Key) && !m_PreviousState.IsKeyDown(Key))
                return true;
            else return false;
        }
        /// <summary>(bool) Checks to see if a key has been pressed and or held [INFO: Checks for a key press useful for spamming]</summary>
        public bool CheckKeyDown(Keys Key)
        {
            if (m_CurrentState.IsKeyDown(Key))
                return true;
            else return false;
        }
        /// <summary>(bool) Checks for a Key Release</summary>
        public bool CheckKeyRelease(Keys Key)
        {
            if (!m_CurrentState.IsKeyDown(Key) && m_PreviousState.IsKeyDown(Key))
                return true;
            else return false;
        }
        public bool CheckZeroKeysDown()
        {
            int length = m_CurrentState.GetPressedKeys().Length;
            if (m_CurrentState.GetPressedKeys().Length == 1)
                return true;
            else return false;
        }
        public bool CheckAnyKeyDown()
        {
            if (m_CurrentState.GetPressedKeys().Length != 1)
                return true;
            else return false;
        }
    }
}
