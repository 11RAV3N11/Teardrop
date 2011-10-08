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
        public Texture2D Texture;
        public Vector2 Position, Origin, Scale;
        public float Rotation, Layer;
        public BoundingBox BoundingBox;
        public Color Color;
        public SpriteEffects SpriteEffects;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects, Layer);
        }

    }
}
