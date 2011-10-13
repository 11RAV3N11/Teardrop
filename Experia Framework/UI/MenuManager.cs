using System.Collections.Generic;

namespace Experia.Framework.UI
{
    public class MenuManager
    {
        public MenuManager Instance { get { return Experia.Framework.Generics.Singleton<MenuManager>.Instance; } }
        public Dictionary<string, BaseMenuScreen> Menus;
        public bool Active;
        protected MenuManager()
        {
            Menus = new Dictionary<string, BaseMenuScreen>();
            Active = true;
        }
        public void Update()
        {
            foreach (KeyValuePair<string, BaseMenuScreen> kvp in Menus)
            {
                if (Menus[kvp.Key].Active)
                {
                    Menus[kvp.Key].Update();
                }
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            foreach (KeyValuePair<string, BaseMenuScreen> kvp in Menus)
            {
                if (Menus[kvp.Key].Active)
                {
                    Menus[kvp.Key].Draw();
                }
            }
        }
    }
}
