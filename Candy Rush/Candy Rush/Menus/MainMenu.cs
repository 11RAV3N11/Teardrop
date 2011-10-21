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
        public Sprite m_MenuImage;

        public ImageButton m_PlayImage;
        public ImageButton m_OptionsImage;
        public ImageButton m_CreditsImage;
        public ImageButton m_ExitImage;

        public MainMenu()
        {
            m_MenuImage = new Sprite();
            m_MenuImage.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\MenuScreen");
            m_PlayImage = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Play"), new Vector2(68f, 30f));
            m_OptionsImage = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Options"), new Vector2(62.0f, 45.0f));
            m_CreditsImage = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Credits"), new Vector2(63.0f, 62.0f));
            m_ExitImage = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Exit"), new Vector2(67.0f, 79.0f));
        }

        public override void Update()
        {
            if (m_PlayImage.Clicked)
            {
                //to implement
            }

            if (m_OptionsImage.Clicked)
            {
                //to implement
            }

            if (m_CreditsImage.Clicked)
            {
                //to implement
            }

            if (m_ExitImage.Clicked)
            {
                //to implement
            }

        }

        public override void Draw(GraphicsManager graphics)
        {
            m_MenuImage.Draw(graphics.SpriteBatch);
            m_PlayImage.Draw(graphics);
            m_OptionsImage.Draw(graphics);
            m_CreditsImage.Draw(graphics);
            m_ExitImage.Draw(graphics);
        }
    }
}
