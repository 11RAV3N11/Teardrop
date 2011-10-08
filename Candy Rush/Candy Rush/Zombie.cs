using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Experia.Framework;
using Experia.Framework.Entities;

namespace CandyRush
{
    class Zombie: BaseDrawableGameEntity
    {
        public Sprite Sprite;
        public override void Initialize(Experia.Framework.UpdatePacket updatePacket, Experia.Framework.GraphicsPacket graphics)
        {
            Sprite = new Sprite();
            Sprite.Texture = ContentLoader.Instance.Load<Texture2D>(Container.Game, @"Content\\Zombie");
            base.Display = true;
            base.m_Disposed = false;
            base.m_Enabled = true;
            base.Initialize(updatePacket, graphics);
        }
        public override void Update(UpdatePacket updatePacket)
        {

        }
        public override void Draw(GraphicsPacket graphics)
        {
            graphics.SpriteBatch.Begin();
            graphics.SpriteBatch.Draw(Sprite.Texture, Sprite.Position, null, Sprite.Color, Sprite.Rotation, Sprite.Origin, Sprite.Scale, Sprite.SpriteEffects, Sprite.Layer);
            graphics.SpriteBatch.End();
        }
    }
}
