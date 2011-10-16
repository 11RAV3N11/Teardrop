﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Experia.Framework.Physics;

namespace Experia.Framework.Entities
{
    public class Kinetics
    {
        protected Vector2 m_PreviousPosition;
        protected Vector2 m_NewPosition;
        protected Vector2 m_ValidPosition;
        protected BaseDrawableGameEntity2D m_CheckObjectEntity;
        //protected Sprite m_CheckObjectSprite;
        public static Kinetics Instance
        {
            get
            {
                return Experia.Framework.Generics.Singleton<Kinetics>.Instance;
            }
        }
        public Vector2 MoveObject(BaseDrawableGameEntity2D entityObject, Vector2 objectPosition, Vector2 futurePosition)
        {
            m_CheckObjectEntity = entityObject;
            //m_CheckObjectSprite = objectSprite;
            m_PreviousPosition = objectPosition;
            m_NewPosition = futurePosition;
            if (m_PreviousPosition == m_NewPosition)
            {
                m_ValidPosition = m_NewPosition;
                return m_ValidPosition;
            }
            ObjectCollision.Instance.RunPostitionCollision(m_CheckObjectEntity);
            return m_ValidPosition;
        }
    }
}
