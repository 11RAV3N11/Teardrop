using Microsoft.Xna.Framework;

namespace Experia.Framework.Entities
{
    public abstract class BaseDrawableGameEntity2D: BaseGameEntity
    {
        public bool Display;
        public Sprite Sprite;
        public BaseDrawableGameEntity2D()
        {
            m_Disposed = false;
            Display = true;
            Enabled = true;
            Sprite = new Sprite();
        }

        public abstract void Draw(GraphicsManager graphics);
    }
}
