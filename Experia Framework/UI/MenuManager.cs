using System.Collections.Generic;

namespace Experia.Framework.UI
{
    public class MenuManager
    {
        public MenuManager Instance { get { return Experia.Framework.Generics.Singleton<MenuManager>.Instance; } }

        protected Dictionary<string, BaseMenuScreen> m_Menus;
        /// <summary>Return the Collection of Menus</summary>
        public Dictionary<string, BaseMenuScreen> Menu
        {
            get
            {
                return m_Menus;
            }
        }
        protected MenuManager()
        {
            m_Menus = new Dictionary<string, BaseMenuScreen>();
        }
        public void Update()
        {
            foreach (KeyValuePair<string, BaseMenuScreen> kvp in m_Menus)
            {
                if (m_Menus[kvp.Key].Active)
                {
                    m_Menus[kvp.Key].Update();
                }
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            foreach (KeyValuePair<string, BaseMenuScreen> kvp in m_Menus)
            {
                if (m_Menus[kvp.Key].Active)
                {
                    m_Menus[kvp.Key].Draw();
                }
            }
        }
    }
}
