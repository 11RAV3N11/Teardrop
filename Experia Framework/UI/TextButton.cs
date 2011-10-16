using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework.Controls;

namespace Experia.Framework.UI
{
    public class TextButton
    {
        protected Font2D m_Font;
        protected string m_Text;
        protected Vector2 m_TextSizeFromFont;
        protected Vector2 m_Position, m_ShadowPosition;
        protected Rectangle m_Rectangle;
        protected Color m_OriginalColor;
        public bool EnableFontShadow;
        public Color HoverColor;
        public string Text
        {
            get { return m_Text;}
            set
            {
                if(m_Text != value)
                {
                    m_Text = value;
                    m_TextSizeFromFont = m_Font.MeasureString(value);
                    m_Font.Origin.X = m_TextSizeFromFont.X / 2f;
                    m_Font.Origin.Y = m_TextSizeFromFont.Y / 2f;
                    m_Rectangle.Height = (int)m_TextSizeFromFont.Y;
                    m_Rectangle.Width = (int)m_TextSizeFromFont.X;
                }
            }
        }
        public Vector2 Position
        {
            get { return m_Position; }
            set
            {
                m_Position = value;
                m_Rectangle.X = (int)(value.X - m_Font.Origin.X);
                m_Rectangle.Y = (int)(value.Y - m_Font.Origin.Y);
                m_ShadowPosition.X = value.X + 3.0f;
                m_ShadowPosition.Y = value.Y + 5.0f;
            }
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(m_Rectangle))
                {
                    //Add Hover Logic Here
                    m_Font.Color = HoverColor;
                    if (InputManager.Instance.Mouse.CheckMouseButtonPressed(MouseButton.LeftButton))
                    {
                        return true;
                    }
                    else return false;
                }
                else
                {
                    m_Font.Color = m_OriginalColor;
                    return false;
                }
            }
        }
        public TextButton(Font2D font, string text)
        {
            m_Font = font;
            m_Rectangle = new Rectangle();
            Text = text;
            m_OriginalColor = font.Color;
            HoverColor = Color.Red;
        }
        public void Draw(GraphicsManager graphics)
        {
            m_Font.Draw(graphics.SpriteBatch, m_Text, m_Position);
        }
    }
}
