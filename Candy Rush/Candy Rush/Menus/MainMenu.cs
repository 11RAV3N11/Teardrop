using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Experia.Framework;
using Experia.Framework.UI;

namespace CandyRush
{
    public class MainMenu: BaseMenuScreen
    {
        Font2D m_MenuFont;
        public MainMenu()
            : base("Main Menu")
        {

        }
        public override void Initialize()
        {
            m_MenuFont = new Font2D(@"Content\\Chiller");
            m_MenuFont.Color = Color.Orange;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {

        }
    }
}
