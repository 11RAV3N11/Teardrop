using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public class Font2D
    {
        protected SpriteFont m_Font;
        public SpriteFont Font { get { return m_Font; } }
        public Color Color;
        public float Rotation, Layer;
        public Vector2 Origin, Scale;
        public SpriteEffects Effects;
        public Font2D(string spriteFontLocation)
        {
            m_Font = ContentLoader.Instance.Load<SpriteFont>(ContentContainer.Persistent, spriteFontLocation);
            Color = Color.White;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            Effects = SpriteEffects.None;
        }
        public Vector2 MeasureString(object text)
        {
            string tempString = text as string;
            StringBuilder tempStringBuilder = text as StringBuilder;

            if (tempString != null)
                return m_Font.MeasureString(tempString);
            else if (tempStringBuilder != null)
                return m_Font.MeasureString(tempStringBuilder);

            return Vector2.Zero;
        }
        public void Draw(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            spriteBatch.DrawString(m_Font, text, position, Color, Rotation, Origin, Scale, Effects, Layer);
        }

    }
}
