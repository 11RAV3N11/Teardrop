using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework.Controls
{
    public enum MouseButton { LeftButton, RightButton, MiddleButton }
    public class MouseExtension
    {
        /*### Mouse Information ###*/
        public Texture2D[] MouseTexture;
        public bool ClampMouse;
        public bool DisplayMouse;
        protected Vector2 m_MousePosition, m_DeltaMouse;
        protected int m_MouseWheelValue, m_MouseWheelDelta;
        protected MouseState m_CurrentState, m_PreviousState;
        protected Vector2 m_PrevMousePosition, m_PrevDeltaMouse;
        protected int m_PrevMouseWheelValue, m_PrevMouseWheelDelta;
        protected Rectangle m_Rectangle;
        public Rectangle BoundingRectangle { get { return m_Rectangle; } }
        public Vector2 MouseDelta
        {
            get { return this.m_DeltaMouse; }
        }
        public Vector2 PreviousMouseDelta
        {
            get { return this.m_PrevDeltaMouse; }
        }
        public int MouseWheelDelta
        {
            get { return this.m_MouseWheelDelta; }
        }
        public Vector2 MousePosition
        {
            get { return m_MousePosition; }
            set
            {
                this.m_MousePosition = value;
                Mouse.SetPosition((int)value.X, (int)value.Y);
            }
        }
        public MouseExtension(Texture2D t2dMouseIcon, bool MouseClamped)
        {
            /*Prepare the Mouse Settings*/
            m_CurrentState = new MouseState(); m_PreviousState = new MouseState();
            m_PrevMousePosition = m_MousePosition = m_PrevDeltaMouse = m_DeltaMouse = Vector2.Zero;

            ClampMouse = MouseClamped;

            MouseTexture = new Texture2D[1];
            MouseTexture[0] = t2dMouseIcon;

            m_Rectangle = new Rectangle();
            DisplayMouse = true;
        }
        /// <summary>(Internal - Input Manager) Called Inside the built-in Input Manager however may be instantiated and called if not using</summary>
        public void Update(Rectangle BackBufferBounds)
        {
            Vector2 ClampedMouse = Vector2.Zero;
            /*Update Previous Mouse States*/
            m_PreviousState = m_CurrentState;
            m_PrevMousePosition = m_MousePosition;
            m_PrevDeltaMouse = m_DeltaMouse;
            m_PrevMouseWheelDelta = m_MouseWheelDelta;
            m_PrevMouseWheelValue = m_MouseWheelValue;

            /*Update Mouse Information*/
            m_CurrentState = Mouse.GetState(); //<-- Grab the Current Mouse's State

            /*Check here to clamp the mouse before storing its new position and calculations*/
            if (ClampMouse)
            {
                if (m_CurrentState.X > BackBufferBounds.Width)
                {
                    ClampedMouse.X = BackBufferBounds.Width;
                    ClampedMouse.Y = m_CurrentState.Y;
                }
                if (m_CurrentState.X < 0)
                {
                    ClampedMouse.X = 0;
                    ClampedMouse.Y = m_CurrentState.Y;
                }

                if (m_CurrentState.Y > BackBufferBounds.Height)
                {
                    ClampedMouse.Y = BackBufferBounds.Height;
                    ClampedMouse.X = m_CurrentState.X;
                }
                if (m_CurrentState.Y < 0 - 30)
                {
                    ClampedMouse.Y = 0;
                    ClampedMouse.X = m_CurrentState.X;
                }
            }

            m_MousePosition.X = m_CurrentState.X; m_MousePosition.Y = m_CurrentState.Y;
            m_DeltaMouse = m_MousePosition - m_PrevMousePosition;
            m_MouseWheelDelta = m_CurrentState.ScrollWheelValue - m_PreviousState.ScrollWheelValue;
            m_MouseWheelValue += m_MouseWheelDelta;

            m_Rectangle.X = (int)m_MousePosition.X; m_Rectangle.Y = (int)m_MousePosition.Y;

            if (ClampMouse)
                if (ClampedMouse != Vector2.Zero)
                    Mouse.SetPosition((int)ClampedMouse.X, (int)ClampedMouse.Y);
        }
        public void Draw(GraphicsManager graphics)
        {
            if(MouseTexture != null)
            graphics.SpriteBatch.Draw(MouseTexture[0], m_MousePosition, null, Color.White, 0.0f,
                new Vector2((int)(MouseTexture[0].Width / 2f), (int)(MouseTexture[0].Height / 2f)),
                1.0f, SpriteEffects.None, 0f);
        }
        /// <summary>(bool) Checks to see if a given Mouse Button has been pressed [INFO: Useful for spamming]</summary>
        public bool CheckMouseButtonDown(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_CurrentState.LeftButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_CurrentState.RightButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_CurrentState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        /// <summary>(bool) Checks for a given Mouse Button to see if it has been Released</summary>
        public bool CheckMouseButtonReleased(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_CurrentState.LeftButton != ButtonState.Pressed && m_PreviousState.LeftButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_CurrentState.RightButton != ButtonState.Pressed && m_PreviousState.RightButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_CurrentState.MiddleButton != ButtonState.Pressed && m_PreviousState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        /// <summary>(bool) Check for a given Mouse Button to see if it was pressed down [INFO: Useful for non-spammy actions]</summary>
        public bool CheckMouseButtonPressed(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_CurrentState.LeftButton == ButtonState.Pressed && m_PreviousState.LeftButton != ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_CurrentState.RightButton == ButtonState.Pressed && m_PreviousState.RightButton != ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_CurrentState.MiddleButton == ButtonState.Pressed && m_PreviousState.MiddleButton != ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }

        /// <summary>(bool) Checks to see if a given Mouse Button has been pressed [INFO: Useful for spamming]</summary>
        public bool CheckPrevMouseButtonDown(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_PreviousState.LeftButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_PreviousState.RightButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_PreviousState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        /// <summary>(bool) Checks for a given Mouse Button to see if it has been Released</summary>
        public bool CheckPrevMouseButtonReleased(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_CurrentState.LeftButton != ButtonState.Pressed && m_PreviousState.LeftButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_CurrentState.RightButton != ButtonState.Pressed && m_PreviousState.RightButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_CurrentState.MiddleButton != ButtonState.Pressed && m_PreviousState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        /// <summary>(bool) Check for a given Mouse Button to see if it was pressed down [INFO: Useful for non-spammy actions]</summary>
        public bool CheckPrevMouseButtonPressed(MouseButton Button)
        {
            switch (Button)
            {
                case MouseButton.LeftButton:
                    if (m_CurrentState.LeftButton != ButtonState.Pressed && m_PreviousState.LeftButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.RightButton:
                    if (m_CurrentState.RightButton != ButtonState.Pressed && m_PreviousState.RightButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case MouseButton.MiddleButton:
                    if (m_CurrentState.MiddleButton != ButtonState.Pressed && m_PreviousState.MiddleButton == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
    }
}