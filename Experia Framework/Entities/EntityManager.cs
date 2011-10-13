using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Experia.Framework.Entities;
using Experia.Framework.Generics;

namespace Experia.Framework
{
    public class EntityManager
    {
        public static EntityManager Instance
        {
            get { return Singleton<EntityManager>.Instance; }
        }

        public List<BaseGameEntity> GameObjects;
        public List<BaseDrawableGameEntity2D> DrawableGameObjects;

        protected EntityManager()
        {
            GameObjects = new List<BaseGameEntity>();
            DrawableGameObjects = new List<BaseDrawableGameEntity2D>();
        }

        public void AddGameEntity(object gameEntity)
        {
            BaseGameEntity tempEntity = gameEntity as BaseGameEntity;
            BaseDrawableGameEntity2D tempEntity2D = gameEntity as BaseDrawableGameEntity2D;
            BaseDrawableGameEntity3D tempEntity3D = gameEntity as BaseDrawableGameEntity3D; //<-- Placeholder

            if (tempEntity2D != null)
            {
                DrawableGameObjects.Add(tempEntity2D);
            }
            else if (tempEntity != null)
            {
                GameObjects.Add(tempEntity);
            }

        }

        public void Initialize(GraphicsManager graphicsPacket)
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Initialize(graphicsPacket);
            }

            for (int i = 0; i < DrawableGameObjects.Count; i++)
            {
                DrawableGameObjects[i].Initialize(graphicsPacket);
            }
        }

        public void Update()
        {
            //Update all of our Game Objects if they are enabled
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                if (GameObjects[i].Enabled)
                {
                    GameObjects[i].Update();
                }
            }

            //Update all of our Drawable Game Objects if they are enabled
            for (int i = DrawableGameObjects.Count - 1; i >= 0; i--)
            {
                if (DrawableGameObjects[i].Enabled)
                {
                    DrawableGameObjects[i].Update();
                }
            }

        }

        public void Draw(GraphicsManager graphicsPacket)
        {
            for (int i = DrawableGameObjects.Count - 1; i >= 0; i--)
            {
                if (DrawableGameObjects[i].Display)
                {
                    DrawableGameObjects[i].Draw(graphicsPacket);
                }
            }
        }
    }
}
