using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Experia.Framework;
using Experia.Framework.Entities;

namespace Candy_Rush
{
    class Zombie: BaseDrawableGameEntity
    {

        public override void Initialize(Experia.Framework.UpdatePacket updatePacket, Experia.Framework.GraphicsPacket graphics)
        {
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

        }
    }
}
