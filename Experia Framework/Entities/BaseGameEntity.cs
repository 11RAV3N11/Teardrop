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

        public abstract void Initialize(GraphicsManager graphics);
        public abstract void Update();

    }
}
