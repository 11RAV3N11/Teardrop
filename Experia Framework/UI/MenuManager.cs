using System.Collections.Generic;

namespace Experia.Framework.UI
{
    public class MenuManager
    {
        public static MenuManager Instance { get { return Experia.Framework.Generics.Singleton<MenuManager>.Instance; } }
        protected Dictionary<string, BaseMenuScreen> m_Menus;
        protected MenuManager()
        {
            m_Menus = new Dictionary<string, BaseMenuScreen>();
        }
        public T AddMenu<T>(string menuName) where T : BaseMenuScreen, new()
        {
            BaseMenuScreen temp = new T();

            m_Menus.Add(menuName, temp);
            return (T)m_Menus[menuName];
        }
        public void Update()
        {
            foreach (KeyValuePair<string, BaseMenuScreen> kvp in m_Menus)
            {
                if (m_Menus[kvp.Key].Display)
                {
                    m_Menus[kvp.Key].Update();
                }
            }
        }
        public void Draw(GraphicsManager graphics)
        {
                foreach (KeyValuePair<string, BaseMenuScreen> kvp in m_Menus)
                {
                    if (m_Menus[kvp.Key].Display)
                    {
                        m_Menus[kvp.Key].Draw(graphics);
                    }
                }
        }
    }
}
