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
        public Sprite Sprite;
        public ImageButton(Texture2D buttonTexture, Vector2 percentPosition)
        {
            Sprite = new Sprite();
            Sprite.Texture = buttonTexture;
            Sprite.Position = ExperiaHelper.Instance.PositionByResolution(percentPosition);
        }
        public bool Clicked
        {
            get
            {
                if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(Sprite.BoundingRectangle))
                {
                    //Hover Logic
                    Sprite.Color = Color.Red;
                    if (InputManager.Instance.Mouse.CheckMouseButtonPressed(MouseButton.LeftButton))
                    {
                        return true;
                    }
                    return false;
                }
                Sprite.Color = Color.White;
                return false;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            Sprite.Draw(graphics.SpriteBatch);
        }
    }
}