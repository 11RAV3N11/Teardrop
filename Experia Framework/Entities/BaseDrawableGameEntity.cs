using Experia.Framework.Interfaces;

namespace Experia.Framework.Entities
{
    public abstract class BaseDrawableGameEntity: IGameObject
    {
        protected bool m_Enabled;
        protected bool m_Disposed;
        public bool Display;

        public abstract void Update(UpdatePacket updatePacket);
        public abstract void Draw(GraphicsPacket graphics);

        public virtual void Initialize(UpdatePacket updatePacket, GraphicsPacket graphics)
        {

        }

        public bool Enabled
        {
            get { return m_Enabled; }
            set { m_Enabled = value; }
        }

        public bool Disposed
        {
            get
            {
                return m_Disposed;
            }
        }
    }
}
