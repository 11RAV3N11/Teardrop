using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Experia.Framework.Entities;
using Experia.Framework.Generics;

namespace Experia.Framework
{
    public class EntityManager
    {
        public static EntityManager Instance
        {
            get { return Singleton<EntityManager>.Instance; }
        }
        protected List<BaseGameEntity> m_GameObjects;
        protected List<BaseDrawableGameEntity2D> m_DrawableGameObjects;

        public List<BaseGameEntity> GetGameObjects { get { return m_GameObjects; } }
        public List<BaseDrawableGameEntity2D> GetDrawableGameObjects { get { return m_DrawableGameObjects; } }

        protected EntityManager()
        {
            m_GameObjects = new List<BaseGameEntity>();
            m_DrawableGameObjects = new List<BaseDrawableGameEntity2D>();
        }

        public void Initialize(Graphics graphicsPacket)
        {
            for (int i = 0; i < m_GameObjects.Count; i++)
            {
                m_GameObjects[i].Initialize(graphicsPacket);
            }

            for (int i = 0; i < m_DrawableGameObjects.Count; i++)
            {
                m_DrawableGameObjects[i].Initialize(graphicsPacket);
            }
        }

        public void Update()
        {
            //Update all of our Game Objects if they are enabled
            for (int i = m_GameObjects.Count - 1; i >= 0; i--)
            {
                if (m_GameObjects[i].Enabled)
                {
                    m_GameObjects[i].Update();
                }
            }

            //Update all of our Drawable Game Objects if they are enabled
            for (int i = m_DrawableGameObjects.Count - 1; i >= 0; i--)
            {
                if (m_DrawableGameObjects[i].Enabled)
                {
                    m_DrawableGameObjects[i].Update();
                }
            }

        }

        public void Draw(Graphics graphicsPacket)
        {
            for (int i = m_DrawableGameObjects.Count - 1; i >= 0; i--)
            {
                if (m_DrawableGameObjects[i].Display)
                {
                    m_DrawableGameObjects[i].Draw(graphicsPacket);
                }
            }
        }
    }
}
