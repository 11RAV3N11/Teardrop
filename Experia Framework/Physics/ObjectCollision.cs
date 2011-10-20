using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Experia.Framework.Entities;

namespace Experia.Framework.Physics
{
    class ObjectCollision
    {
        protected Vector2 m_BaseObjectPosition;
        protected BaseDrawableGameEntity2D m_BaseObjectEntity;
        protected BaseDrawableGameEntity2D m_TestObjectEntity;
        protected Rectangle m_BaseObjectRectangle;
        protected Rectangle m_TestObjectRectangle;
        protected int m_EntityCountainerCount;
        protected bool m_DoesCollide;
        protected int m_TopObject;
        protected int m_BottomObject;
        protected int m_LeftObject;
        protected int m_RightObject;
        protected bool m_HasBoxCollided;
        protected bool m_HasPixelCollided;
        protected Color m_BaseSinglePixel;
        protected Color m_TestSinglePixel;
        protected Color[] m_BasePixelData; //later make static
        protected Color[] m_TestPixelData; //later make static
        public static ObjectCollision Instance
        {
            get
            {
                return Experia.Framework.Generics.Singleton<ObjectCollision>.Instance;
            }
        }
        protected ObjectCollision()
        {
            m_BaseObjectPosition = Vector2.Zero;
        }
        protected void UpdateBaseInformation()
        {
            //Updates the entity count in the Container
            m_EntityCountainerCount = EntityManager.Instance.DrawableGameObjects.Count - 1;
            //Sets the values for the Base Entity / Obtained entity that is moving
            m_BaseObjectRectangle.X = (int)m_BaseObjectPosition.X;
            m_BaseObjectRectangle.Y = (int)m_BaseObjectPosition.Y;
            m_BaseObjectRectangle.Width = m_BaseObjectEntity.Sprite.Texture.Bounds.Width;
            m_BaseObjectRectangle.Height = m_BaseObjectEntity.Sprite.Texture.Bounds.Height;
            //This sets up the Base valued for Pixel Collision
            m_BasePixelData = new Color[m_BaseObjectEntity.Sprite.Texture.Width * m_BaseObjectEntity.Sprite.Texture.Height];
            m_BaseObjectEntity.Sprite.Texture.GetData<Color>(m_BasePixelData);
        }
        protected void UpdateTestInformation()
        {
            //Sets the values for the test object
            m_TestObjectRectangle.X = (int)m_TestObjectEntity.Sprite.Position.X;
            m_TestObjectRectangle.Y = (int)m_TestObjectEntity.Sprite.Position.Y;
            m_TestObjectRectangle.Width = m_TestObjectEntity.Sprite.Texture.Bounds.Width;
            m_TestObjectRectangle.Height = m_TestObjectEntity.Sprite.Texture.Bounds.Height;
            //Sets the Pixel Collision Test Values accordingly
            m_TopObject = Math.Max(m_BaseObjectRectangle.Top, m_TestObjectRectangle.Top);
            m_BottomObject = Math.Min(m_BaseObjectRectangle.Bottom, m_TestObjectRectangle.Bottom);
            m_LeftObject = Math.Max(m_BaseObjectRectangle.Left, m_TestObjectRectangle.Left);
            m_RightObject = Math.Min(m_BaseObjectRectangle.Right, m_TestObjectRectangle.Right);
            //This sets up the Test Values for Pixel Collision
            m_TestPixelData = new Color[m_TestObjectEntity.Sprite.Texture.Width * m_TestObjectEntity.Sprite.Texture.Height];
            m_TestObjectEntity.Sprite.Texture.GetData<Color>(m_TestPixelData);
            //Resets the conditions for Box and Pixel Collision
            m_HasBoxCollided = false;
            m_HasPixelCollided = false;
        }
        protected bool RunBoxCollision()
        {
            return m_BaseObjectRectangle.Intersects(m_TestObjectRectangle);
        }
        protected bool RunPixelCollision()
        {
            //Pixel Collision Logic
            //Loop will Start on the top left of the texture that made contact
            for (int m_IndexY = m_TopObject; m_IndexY < m_BottomObject; m_IndexY++)
            {
                //Loop will continue to the right from the left side of the texture
                for (int m_IndexX = m_LeftObject; m_IndexX < m_RightObject; m_IndexX++)
                {
                    //Obtaines the Pixel Color for both textures at this exact Pixel in the loop
                    m_BaseSinglePixel = m_BasePixelData[(m_IndexY - m_BaseObjectRectangle.Top) * m_BaseObjectRectangle.Width + (m_IndexX - m_BaseObjectRectangle.Left)];
                    m_TestSinglePixel = m_TestPixelData[(m_IndexY - m_TestObjectRectangle.Top) * m_TestObjectRectangle.Width + (m_IndexX - m_TestObjectRectangle.Left)];
                    //If Both pixels are anything but transparent, collision has occured
                    if (m_BaseSinglePixel.A != 0 && m_TestSinglePixel.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        protected bool RunCollisionScan()
        {
            // Starts Looping though the entities
            // Counter goes backwards just in case an entity is pulled out mid-loop
            for (int m_index = m_EntityCountainerCount; m_index >= 0; m_index--)
            {
                //Sets the Collision Test Object to be the current object in the list
                m_TestObjectEntity = EntityManager.Instance.DrawableGameObjects[m_index];
                //Exits the loop in the case that the Obtained object is the test object in the container
                if (m_BaseObjectEntity == m_TestObjectEntity)
                    return false;
                //Updates the Values for the test Object that the Base Object will compare to
                UpdateTestInformation();
                //Runs Box Collision between Base and Test Object
                m_HasBoxCollided = RunBoxCollision();
                //If True: Runs Box Collision
                //If False: Test Object will go to the next object in the container
                if (m_HasBoxCollided)
                {
                    m_HasPixelCollided = RunPixelCollision();
                    if (m_HasPixelCollided)
                        return true;
                }
            }
            return false;
        }
        public bool RunPostitionCollision(BaseDrawableGameEntity2D objectEntity, Vector2 currentPosition, Vector2 futurePosition)
        {
            m_BaseObjectEntity = objectEntity;
            m_BaseObjectPosition = futurePosition;
            //UpdateInformation will set the values from the Obtained entity that is moving
            UpdateBaseInformation();
            //Starts the Collision Checking and returns if anythign has collided
            m_DoesCollide = RunCollisionScan();
            return m_DoesCollide;
        }
    }
}