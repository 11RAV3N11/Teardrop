namespace Experia.Framework.Entities
{
    public abstract class BaseGameEntity
    {
        protected bool m_Disposed;

        public bool Enabled { get; set; }

        public bool Disposed
        {
            get { return m_Disposed; }
        }

        public abstract void Initialize(Graphics graphics);
        public abstract void Update();

    }
}
