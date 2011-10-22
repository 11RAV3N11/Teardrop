using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public class Sprite
    {
        public Vector2 Origin, Scale;
        public float Rotation, Layer;
        public Color Color;
        public SpriteEffects SpriteEffects;
        protected Vector2 m_Position;
        protected Rectangle m_Bounds;
        public Vector2 Position
        {
            get { return m_Position; }
            set
            {
                m_Position.X = (int)value.X;
                m_Position.Y = (int)value.Y;
                m_Bounds.X = (int)value.X;
                m_Bounds.Y = (int)value.Y;
            }
        }
        protected Texture2D m_Texture;
        public Texture2D Texture
        {
            get
            {
                return m_Texture;
            }
            set
            {
                m_Texture = value;
                m_Bounds = value.Bounds;
                m_Bounds.X = (int)m_Position.X;
                m_Bounds.Y = (int)m_Position.Y;
            }
        }
        public Rectangle BoundingRectangle
        {
            get
            {
                return m_Bounds;
            }
        }

        public Sprite()
        {
            Scale = Vector2.One;
            Color = Color.White;
            SpriteEffects = SpriteEffects.None;
            m_Bounds = new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (m_Texture != null)
                spriteBatch.Draw(m_Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, Layer);
        }
    }
}
