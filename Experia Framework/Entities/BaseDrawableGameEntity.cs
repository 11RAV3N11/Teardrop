namespace Experia.Framework.Entities
{
    public abstract class BaseDrawableGameEntity2D: BaseGameEntity
    {
        public bool Display;

        public BaseDrawableGameEntity2D()
        {
            m_Disposed = false;
            Display = true;
            Enabled = true;
        }

        public abstract void Draw(Graphics graphics);
    }
}
