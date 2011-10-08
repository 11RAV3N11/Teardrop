using Experia.Framework.Interfaces;

namespace Experia.Framework.Entities
{
    public abstract class BaseGameEntity : IGameObject
    {
        protected bool m_Enabled;
        protected bool m_Disposed;

        public virtual void Initialize(UpdatePacket updatePacket, GraphicsPacket graphics)
        {

        }
        public abstract void Update(UpdatePacket updatePacket);

        public bool Enabled
        {
            get
            {
                return m_Enabled;
            }
            set
            {
                m_Enabled = value; ;
            }
        }

        public bool Disposed
        {
            get { return m_Disposed; }
        }
    }
}
