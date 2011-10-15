using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework;
using Experia.Framework.UI;

namespace CandyRush
{
    public class MainMenu: BaseMenuScreen
    {
        Font2D m_MenuFont;
        MenuButton[] m_Buttons;
        public MainMenu()
        {
            m_Buttons = new MenuButton[3];

            m_MenuFont = new Font2D(@"Content\\Chiller");
            m_MenuFont.Color = Color.Orange;
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                m_Buttons[i] = new MenuButton();
            }

            m_Buttons[0].Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(50f, 50f));
        }
        public override void Update()
        {
            if (m_Buttons[0].Clicked)
                throw new Exception("W00t!");
        }

        public override void Draw(GraphicsManager graphics)
        {
            m_MenuFont.Draw(graphics.SpriteBatch, "New Game", m_Buttons[0].Position);
        }
    }
}
