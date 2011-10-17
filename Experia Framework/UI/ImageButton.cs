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
        public ImageButton(Texture2D buttonTexture, Vector2 percentPosition)
        {
            m_Sprite = new Sprite();
            m_Sprite.Texture = buttonTexture;
            m_Sprite.Position = ExperiaHelper.Instance.PositionByResolution(percentPosition);
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(m_Sprite.BoundingRectangle))
                {
                    //Hover Logic
                    m_Sprite.Color = Color.Red;
                    if (InputManager.Instance.Mouse.CheckMouseButtonPressed(MouseButton.LeftButton))
                    {
                        return true;
                    }
                    return false;
                }
                m_Sprite.Color = Color.White;
                return false;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            m_Sprite.Draw(graphics.SpriteBatch);
        }
    }
}