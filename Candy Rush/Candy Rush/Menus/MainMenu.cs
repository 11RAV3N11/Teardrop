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
        TextButton[] m_Buttons;
        ImageButton m_ImgButton;
        public MainMenu()
        {
            m_Buttons = new TextButton[3];

            m_MenuFont = new Font2D(@"Content\\Chiller");
            m_MenuFont.Color = Color.Orange;
            for (int i = 0; i < m_Buttons.Length; i++)
            {
                m_Buttons[i] = new TextButton(m_MenuFont, "New Game");
            }
            Texture2D temp = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Zombie");
            m_ImgButton = new ImageButton(temp , new Vector2(10f, 10f));
            m_Buttons[0].Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(75f, 20f));
        }
        public override void Update()
        {
            if (m_Buttons[0].Clicked)
                throw new Exception("Item Clicked!");
            if (m_ImgButton.Clicked)
                throw new Exception("Ricardo Clicked!");
        }

        public override void Draw(GraphicsManager graphics)
        {
            m_Buttons[0].Draw(graphics);
            m_ImgButton.Draw(graphics);
        }
    }
}
