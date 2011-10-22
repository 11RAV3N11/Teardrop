﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Experia.Framework;
using Experia.Framework.UI;

namespace CandyRush
{
    class PlayMenu : BaseMenuScreen
    {
        protected Sprite m_Background;
        protected Sprite m_Moon;
        protected Sprite m_Grave;
        protected Sprite m_Pumpkin;
        protected Sprite m_Title;

        protected ImageButton m_NewGame;
        protected ImageButton m_Continue;
        protected ImageButton m_Back;

        public PlayMenu()
        {
            m_Background = new Sprite();
            m_Background.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Background");
            m_Background.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(0.0f, 0.0f));
            m_Moon = new Sprite();
            m_Moon.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Moon");
            m_Moon.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(78.0f, 2.0f));

            m_Grave = new Sprite();
            m_Grave.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Grave");
            m_Grave.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(50.0f, 10.0f));

            m_Pumpkin = new Sprite();
            m_Pumpkin.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Pumpkin");
            m_Pumpkin.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(26.0f, 42.0f));

            m_Title = new Sprite();
            m_Title.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Title");
            m_Title.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(5.0f, 5.0f));


            m_NewGame = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\NewGame"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(60f, 38f)));
            m_Continue = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Continue"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(60.0f, 54.0f)));
            m_Back = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Back"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(66.0f, 68.0f)));
        }

        public override void Update()
        {
            if (m_NewGame.Clicked)
            {
                //to implement
            }

            if (m_Continue.Clicked)
            {
                //to implement
            }

            if (m_Back.Clicked)
            {
                MenuManager.Instance.SwitchMenu("Main");
            }
        }

        public override void Draw(GraphicsManager graphics)
        {
            m_Background.Draw(graphics.SpriteBatch);
            m_Moon.Draw(graphics.SpriteBatch);
            m_Pumpkin.Draw(graphics.SpriteBatch);
            m_Grave.Draw(graphics.SpriteBatch);
            m_Title.Draw(graphics.SpriteBatch);

            m_NewGame.Draw(graphics);
            m_Continue.Draw(graphics);
            m_Back.Draw(graphics);
        }
    }
}