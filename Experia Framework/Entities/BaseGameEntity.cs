using System;
using System.Reflection;

namespace Experia.Framework.Entities
{
    public abstract class BaseGameEntity
    {
        protected bool m_Disposed;

        protected string m_IsEntity;
        public string IsEntity
        {
            get { return m_IsEntity; }
        }

        public bool Enabled { get; set; }

        public bool Disposed
        {
            get { return m_Disposed; }
        }

        public virtual void Initialize(GraphicsManager graphics)
        {
            Type t = this.GetType();
            m_IsEntity = t.FullName;
            t = null;
        }
        public abstract void Update();

    }
}
