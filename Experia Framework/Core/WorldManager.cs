using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Experia.Framework
{
    public class WorldManager
    {
        public static WorldManager Instance { get { return Experia.Framework.Generics.Singleton<WorldManager>.Instance; } }
        protected bool m_EditorEnabled = false;

        protected WorldManager()
        {
            
        }
        public void SaveEntitiesIntoXml(string xmlNameAndLocation)
        {
            XmlWriter writer = FileIO.Instance.XmlWriterCreateInstance(out writer, xmlNameAndLocation, "Entities");

            Dictionary<string, string> entityInfo = new Dictionary<string,string>();

            for (int i = EntityManager.Instance.DrawableGameObjects.Count - 1; i >= 0; i--)
            {
                entityInfo.Add("PosX", EntityManager.Instance.DrawableGameObjects[i].Sprite.Position.X.ToString());
                entityInfo.Add("PosY", EntityManager.Instance.DrawableGameObjects[i].Sprite.Position.Y.ToString());
                FileIO.Instance.XmlWriteAttributeElement(writer, EntityManager.Instance.DrawableGameObjects[i].IsEntity, entityInfo);
            }

            FileIO.Instance.XmlClose(writer);

            writer = null;
        }
        public void LoadEntitiesFromXml(string xmlLocation)
        {

        }
        public void Update()
        {
            if (InputManager.Instance.Keyboard.CheckKeyPressed(Keys.F11))
            {
                m_EditorEnabled = !m_EditorEnabled;
                GraphicsManager.Instance.BackBufferColor = Color.Black;
            }

            if (m_EditorEnabled)
            {
                for (int i = EntityManager.Instance.DrawableGameObjects.Count - 1; i >= 0; i--)
                {
                    if (InputManager.Instance.Mouse.BoundingRectangle.Intersects(EntityManager.Instance.DrawableGameObjects[i].Sprite.BoundingRectangle))
                    {
                        Primitive2D.Instance.Color = Color.Red;
                    }
                    else
                    {
                        Primitive2D.Instance.Color = Color.White;
                    }
                }
            }
            else
            {
                GraphicsManager.Instance.BackBufferColor = Color.CornflowerBlue;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            if (m_EditorEnabled)
            {
                graphics.SpriteBatch.End(); //<-- Need to Create a Param object that can be passed to restore states
                graphics.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
                for (int i = EntityManager.Instance.DrawableGameObjects.Count - 1; i >= 0; i--)
                {
                    Primitive2D.Instance.Thickness = 2f;
                    Primitive2D.Instance.Position = Vector2.Zero;
                    Primitive2D.Instance.CreateSquare(new Vector2(EntityManager.Instance.DrawableGameObjects[i].Sprite.BoundingRectangle.Left, EntityManager.Instance.DrawableGameObjects[i].Sprite.BoundingRectangle.Top),
                        new Vector2(EntityManager.Instance.DrawableGameObjects[i].Sprite.BoundingRectangle.Right, EntityManager.Instance.DrawableGameObjects[i].Sprite.BoundingRectangle.Bottom));
                    Primitive2D.Instance.RenderSquarePrimitive(graphics.SpriteBatch, EntityManager.Instance.DrawableGameObjects[i].Sprite.Origin);
                }
                graphics.SpriteBatch.End();
                GraphicsManager.Instance.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            }
        }
    }
}
