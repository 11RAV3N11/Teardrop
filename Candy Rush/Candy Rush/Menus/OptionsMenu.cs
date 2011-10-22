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
    class OptionsMenu : BaseMenuScreen
    {
        protected Sprite m_Background;
        protected Sprite m_Moon;
        protected Sprite m_Grave;
        protected Sprite m_Pumpkin;
        protected Sprite m_Title;

        protected Sprite m_Resolution;
        protected Sprite m_fullScreen;
        protected Sprite m_checkMark;
        protected ImageButton m_Back;
        protected ImageButton m_lArrow;
        protected ImageButton m_rArrow;
        protected ImageButton m_checkBox;

        public OptionsMenu()
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

            m_Resolution = new Sprite();
            m_Resolution.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Resolution");
            m_Resolution.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(60.0f, 35.0f));

            m_fullScreen = new Sprite();
            m_fullScreen.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\FullScreen");
            m_fullScreen.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(57.0f, 58.0f));

            m_checkMark = new Sprite();
            m_checkMark.Texture = ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\CheckMark");
            m_checkMark.Position = ExperiaHelper.Instance.PositionByResolution(new Vector2(71.0f, 68.0f));


            m_lArrow = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\lArrow"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(58.0f, 45.0f)));
            m_rArrow = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\rArrow"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(90.0f, 46.0f)));
            m_checkBox = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\CheckBox"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(71.0f, 68.0f)));
            m_Back = new ImageButton(ContentLoader.Instance.Load<Texture2D>(ContentContainer.UI, @"Content\\Graphics\\Back"),
                ExperiaHelper.Instance.PositionByResolution(new Vector2(66.0f, 78.0f)));

            
        }

        public override void Update()
        {
            if (m_lArrow.Clicked)
            {
                //to implement
            }

            if (m_rArrow.Clicked)
            {
                //to implement
            }

            if (m_checkBox.Clicked)
            {
                //to implement full screen mechanics; draw undraw "check mark"
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
            m_Resolution.Draw(graphics.SpriteBatch);
            m_fullScreen.Draw(graphics.SpriteBatch);
            m_checkMark.Draw(graphics.SpriteBatch);

            m_lArrow.Draw(graphics);
            m_rArrow.Draw(graphics);
            m_checkBox.Draw(graphics);
            m_Back.Draw(graphics);
        }
    }
}