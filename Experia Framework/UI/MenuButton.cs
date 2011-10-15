using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework.UI
{
    public class MenuButton //[Obsolete] <-- Yeah new Idea on this >.< setup a button factory 
    {
        protected Rectangle m_Rectangle;
        protected Vector2 m_Position;
        protected string m_Text;
        public MenuButton()
        {
            m_Rectangle = new Rectangle();
        }
        public Vector2 Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
                m_Rectangle.X = (int)value.X;
                m_Rectangle.Y = (int)value.Y;
            }
        }
        public string Text
        {
            get { return m_Text; }
            set
            {
                
            }
        }
        public Color Color
        {
            get;
            set;
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(m_Rectangle))
                    return true;
                else return false;
            }
        }
        public void Draw(GraphicsManager graphics, SpriteFont font)
        {
            graphics.SpriteBatch.DrawString(font, Text, Position, Color);
        }
    }
}
