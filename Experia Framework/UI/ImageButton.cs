using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework.Controls;

namespace Experia.Framework.UI
{
    public class ImageButton
    {
        protected Sprite m_Sprite;
        public Sprite Sprite
        {
            get { return m_Sprite; }
            set
            {
                m_Sprite = value;
                m_OriginalSpriteColor = m_Sprite.Color;
            }
        }
        public Color HoverColor;
        protected Color m_OriginalSpriteColor;
        public ImageButton(Texture2D buttonTexture, Vector2 position)
        {
            Sprite = new Sprite();
            Sprite.Texture = buttonTexture;
            HoverColor = Color.Red;
            Sprite.Position = position;
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(Sprite.BoundingRectangle))
                {
                    //Hover Logic
                    Sprite.Color = HoverColor;
                    if (InputManager.Instance.Mouse.CheckMouseButtonPressed(MouseButton.LeftButton))
                    {
                        return true;
                    }
                    return false;
                }
                Sprite.Color = m_OriginalSpriteColor;
                return false;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            Sprite.Draw(graphics.SpriteBatch);
        }
    }
}