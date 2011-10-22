using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework.Controls;

namespace Experia.Framework.UI
{
    public class ImageButton: Sprite
    {
        public Color HoverColor;
        protected Color m_OriginalSpriteColor;
        protected Vector2 m_PercentPosition;
        public ImageButton(Texture2D buttonTexture, Vector2 position)
        {
            base.Texture = buttonTexture;
            base.Position = position;
            HoverColor = Color.Red;
            m_OriginalSpriteColor = base.Color;
        }
        public ImageButton(Texture2D buttonTexture, float percentX, float percentY)
        {
            base.Texture = buttonTexture;
            base.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(percentX, percentY));
            HoverColor = Color.Red;
            m_OriginalSpriteColor = base.Color;
            m_PercentPosition = new Vector2(percentX, percentY);
            GraphicsManager.Instance.HookGraphicsRebuild += new GraphicsManager.GraphicsRebuildArgs(m_UpdatePositionByResolution);
        }
        protected void m_UpdatePositionByResolution(GraphicsManager graphics)
        {
            base.Position = ExperiaHelper.Instance.PositionByResolution(m_PercentPosition);
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(base.BoundingRectangle))
                {
                    //Hover Logic
                    base.Color = HoverColor;
                    if (InputManager.Instance.Mouse.CheckMouseButtonPressed(MouseButton.LeftButton))
                    {
                        return true;
                    }
                    return false;
                }
                base.Color = m_OriginalSpriteColor;
                return false;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            base.Draw(graphics.SpriteBatch);
        }
    }
}