using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Experia.Framework.Entities;

namespace Experia.Framework.Physics
{
    class ObjectCollision
    {
        protected Vector2 m_ValidatedPosition;
        protected BaseDrawableGameEntity2D m_BaseObjectEntity;
        protected BaseDrawableGameEntity2D m_TestObjectEntity;
        protected Rectangle m_BaseObjectRectangle;
        protected Rectangle m_TestObjectRectangle;
        protected int m_EntityCountainerCount;
        public static ObjectCollision Instance
        {
            get
            {
                return Experia.Framework.Generics.Singleton<ObjectCollision>.Instance;
            }
        }
        protected void UpdateInformation()
        {
            m_EntityCountainerCount = EntityManager.Instance.DrawableGameObjects.Count;
        }
        public Vector2 RunPostitionCollision(BaseDrawableGameEntity2D objectEntity)
        {
            UpdateInformation();
            return m_ValidatedPosition;
        }
    }
}