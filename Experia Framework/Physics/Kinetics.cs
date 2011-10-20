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
        protected bool m_HasCollided;
        public static Kinetics Instance
        {
            get
            {
                return Experia.Framework.Generics.Singleton<Kinetics>.Instance;
            }
        }
        protected Kinetics()
        {
            m_PreviousPosition = Vector2.Zero;
            m_NewPosition = Vector2.Zero;
            m_ValidPosition = Vector2.Zero;
            m_HasCollided = false;
        }
        public Vector2 MoveObject(BaseDrawableGameEntity2D entityObject, Vector2 futurePosition)
        {
            m_CheckObjectEntity = entityObject;
            m_PreviousPosition = entityObject.Sprite.Position;
            m_NewPosition = futurePosition;
            //If ths position is still the same, skip collision logic
            if (m_PreviousPosition == m_NewPosition)
            {
                m_ValidPosition = m_NewPosition;
                return m_ValidPosition;
            }
            //Run Collision Checking and return if collision occured
            m_HasCollided = ObjectCollision.Instance.RunPostitionCollision(m_CheckObjectEntity, m_PreviousPosition, m_NewPosition);
            //Set the position accordingly if collision occured or not
            if (m_HasCollided)
                m_ValidPosition = m_PreviousPosition;
            else
                m_ValidPosition = m_NewPosition;
            return m_ValidPosition;
        }
    }
}
