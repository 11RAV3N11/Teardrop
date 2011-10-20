using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework.Graphics
{
    public class Primitive2D
    {
        public static Primitive2D Instance { get { return Experia.Framework.Generics.Singleton<Primitive2D>.Instance; } }
        /*********************************************************************/
        // Members.
        /*********************************************************************/

        /// <summary>The thickness of the shape's edge.</summary>
        protected float m_fThickness = 1f;

        /// <summary>1x1 pixel that creates the shape.</summary>
        protected Texture2D m_Pixel = null;

        /// <summary>List of vectors.</summary>
        protected List<Vector2> m_VectorList = new List<Vector2>();

        public Color Color
        {
            get;
            set;
        }

        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>The render depth of the primitive line object (0 = front, 1 = back).</summary>
        protected float Depth
        {
            get;
            set;
        }


        /*************************************************************************/
        /// <summary>
        /// Get/Set the thickness of the shape's edge.
        /// </summary>
        /*************************************************************************/
        public float Thickness
        {
            get { return m_fThickness; }
            set { m_fThickness = value; }
        }

        /*************************************************************************/
        /// <summary>
        /// Gets the number of vectors which make up the primitive object.
        /// </summary>
        /*************************************************************************/
        public int CountVectors
        {
            get { return m_VectorList.Count; }
        }

        /*************************************************************************/
        /// <summary>
        /// Gets the vector position from the list.
        /// </summary>
        /// <param name="index">The index to get from.</param>
        /*************************************************************************/
        public Vector2 GetVector(int index)
        {
            return m_VectorList[index];
        }

        /*********************************************************************/
        // Functions.
        /*********************************************************************/
        protected Primitive2D()
        {
            /*************************************************************************/
            // Create the pixel texture.
            m_Pixel = new Texture2D(GraphicsManager.Instance.Device, 1, 1, false, SurfaceFormat.Color);
            m_Pixel.SetData<Color>(new Color[] { Color.White });
            //
            /*************************************************************************/
        }
        ~Primitive2D()
        {
            m_Pixel.Dispose();
            m_VectorList.Clear();
        }

        /*************************************************************************/
        /// <summary>
        /// Adds a vector to the primitive object.
        /// </summary>
        /// <param name="position">The vector to add.</param>
        /*************************************************************************/
        public void AddVector(Vector2 position)
        {
            m_VectorList.Add(position);
        }

        /*************************************************************************/
        /// <summary>
        /// Inserts a vector into the primitive object.
        /// </summary>
        /// <param name="index">The index to insert it at.</param>
        /// <param name="position">The vector to insert.</param>
        /*************************************************************************/
        public void InsertVector(int index, Vector2 position)
        {
            m_VectorList.Insert(index, position);
        }

        /*************************************************************************/
        /// <summary>
        /// Removes a vector from the primitive object.
        /// </summary>
        /// <param name="position">The vector to remove.</param>
        /*************************************************************************/
        public void RemoveVector(Vector2 position)
        {
            m_VectorList.Remove(position);
        }

        /*************************************************************************/
        /// <summary>
        /// Removes a vector from the primitive object.
        /// </summary>
        /// <param name="index">The index of the vector to remove.</param>
        /*************************************************************************/
        public void RemoveVector(int index)
        {
            m_VectorList.RemoveAt(index);
        }

        /*************************************************************************/
        /// <summary>
        /// Clears all vectors from the list.
        /// </summary>
        /*************************************************************************/
        public void ClearVectors()
        {
            m_VectorList.Clear();
        }

        /*************************************************************************/
        /// <summary> 
        /// Create a line primitive.
        /// </summary>
        /// <param name="startPosition">Start of the line, in pixels.</param>
        /// <param name="endPosition">End of the line, in pixels.</param>
        /*************************************************************************/
        public void CreateLine(Vector2 startPosition, Vector2 endPosition)
        {
            m_VectorList.Clear();
            m_VectorList.Add(startPosition);
            m_VectorList.Add(endPosition);
        }

        /*************************************************************************/
        /// <summary>
        /// Create a triangle primitive.
        /// </summary>
        /// <param name="pointPosOne">Fist point, in pixels.</param>
        /// <param name="pointPosTwo">Second point, in pixels.</param>
        /// <param name="pointPosThree">Third point, in pixels.</param>
        /*************************************************************************/
        public void CreateTriangle(Vector2 pointPosOne, Vector2 pointPosTwo, Vector2 pointPosThree)
        {
            m_VectorList.Clear();
            m_VectorList.Add(pointPosOne);
            m_VectorList.Add(pointPosTwo);
            m_VectorList.Add(pointPosThree);
            m_VectorList.Add(pointPosOne);
        }

        /*************************************************************************/
        /// <summary>
        /// Create a square primitive.
        /// </summary>
        /// <param name="topLeftPos">Top left hand corner of the square.</param>
        /// <param name="bottomRightPos">Bottom right hand corner of the square.</param>
        /*************************************************************************/
        public void CreateSquare(Vector2 topLeftPos, Vector2 bottomRightPos)
        {
            m_VectorList.Clear();
            m_VectorList.Add(topLeftPos);
            m_VectorList.Add(new Vector2(topLeftPos.X, bottomRightPos.Y));
            m_VectorList.Add(bottomRightPos);
            m_VectorList.Add(new Vector2(bottomRightPos.X, topLeftPos.Y));
            m_VectorList.Add(topLeftPos);
        }

        /*************************************************************************/
        /// <summary>
        /// Creates a circle starting from (0, 0).
        /// </summary>
        /// <param name="radius">The radius (half the width) of the circle.</param>
        /// <param name="sides">The number of sides on the circle. (64 is average).</param>
        /*************************************************************************/
        public void CreateCircle(float radius, int sides)
        {
            m_VectorList.Clear();

            /*************************************************************************/
            // Local variables.
            float fMax = (float)MathHelper.TwoPi;
            float fStep = fMax / (float)sides;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Create the full circle.
            for (float fTheta = fMax; fTheta >= -1; fTheta -= fStep)
            {
                m_VectorList.Add(new Vector2(radius * (float)Math.Cos((double)fTheta),
                                             radius * (float)Math.Sin((double)fTheta)));
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Creates an ellipse starting from (0, 0) with the given width and height.
        /// Vectors are generated using the parametric equation of an ellipse.
        /// </summary>
        /// <param name="semiMajorAxis">The width of the ellipse at its center.</param>
        /// <param name="semiMinorAxis">The height of the ellipse at its center.</param>
        /// <param name="sides">The number of sides on the ellipse. (64 is average).</param>
        /*************************************************************************/
        public void CreateEllipse(float semiMajorAxis, float semiMinorAxis, int sides)
        {
            m_VectorList.Clear();

            /*************************************************************************/
            float fMax = (float)MathHelper.TwoPi;
            float fStep = fMax / (float)sides;
            /*************************************************************************/

            /*************************************************************************/
            // Create full ellipse.
            for (float fTheta = fMax; fTheta >= -1; fTheta -= fStep)
            {
                m_VectorList.Add(new Vector2((float)(semiMajorAxis * Math.Cos(fTheta)),
                                             (float)(semiMinorAxis * Math.Sin(fTheta))));
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render points of the primitive.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderPointPrimitive(SpriteBatch spriteBatch)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count <= 0)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel, Position + m_VectorList[i], null, Color, fAngle, new Vector2(0.5f, 0.5f), m_fThickness, SpriteEffects.None, Depth);
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render points of the primitive.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /// <param name="angle">The counterclockwise rotation in radians. (0.0f is default).</param>
        /// <param name="pivotPos">Position in which to rotate around.</param>
        /*************************************************************************/
        public void RenderPointPrimitive(SpriteBatch spriteBatch, float angle, Vector2 pivotPos)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count <= 0)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Rotate object based on pivot.
            Rotate(angle, pivotPos);
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel,
                                  Position + m_VectorList[i],
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0.5f, 0.5f),
                                  m_fThickness,
                                  SpriteEffects.None,
                                  Depth);
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render the lines of the primitive.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderLinePrimitive(SpriteBatch spriteBatch)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];

                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1,
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0, 0.5f),
                                  new Vector2(fDistance, m_fThickness),
                                  SpriteEffects.None,
                                  Depth);
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render the lines of the primitive.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /// <param name="angle">The counterclockwise rotation in radians. (0.0f is default).</param>
        /// <param name="pivotPos">Position in which to rotate around.</param>
        /*************************************************************************/
        public void RenderLinePrimitive(SpriteBatch spriteBatch, float angle, Vector2 pivotPos)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Rotate object based on pivot.
            Rotate(angle, pivotPos);
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];

                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1,
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0, 0.5f),
                                  new Vector2(fDistance, m_fThickness),
                                  SpriteEffects.None,
                                  Depth);
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a square algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderSquarePrimitive(SpriteBatch spriteBatch, Vector2 origin)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero, vLength = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            int nCount = 0;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Calculate length.
                vLength = vPosition2 - vPosition1;
                vLength.Normalize();

                // Calculate count for roundness.
                nCount = (int)Math.Round(fDistance);
                //
                /*************************************************************************/

                /*************************************************************************/
                // Run through and render the primitive.
                while (nCount-- > 0)
                {
                    // Increment position.
                    vPosition1 += vLength;

                    // Stretch the pixel between the two vectors.
                    spriteBatch.Draw(m_Pixel, Position + vPosition1, null, Color, 0, origin, m_fThickness, SpriteEffects.None, Depth);
                }
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }
        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a square algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderSquarePrimitive(SpriteBatch spriteBatch, Vector2 v2Origin, bool CameraEnabled)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero, vLength = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            int nCount = 0;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Calculate length.
                vLength = vPosition2 - vPosition1;
                vLength.Normalize();

                // Calculate count for roundness.
                nCount = (int)Math.Round(fDistance);
                //
                /*************************************************************************/

                /*************************************************************************/
                // Run through and render the primitive.
                while (nCount-- > 0)
                {
                    // Increment position.
                    vPosition1 += vLength;

                    // Stretch the pixel between the two vectors.
                    if(!CameraEnabled)
                    spriteBatch.Draw(m_Pixel, Position + vPosition1, null, Color, 0, v2Origin, m_fThickness, SpriteEffects.None, Depth);
                }
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a round algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderRoundPrimitive(SpriteBatch spriteBatch)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero, vLength = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            int nCount = 0;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Calculate length.
                vLength = vPosition2 - vPosition1;
                vLength.Normalize();

                // Calculate count for roundness.
                nCount = (int)Math.Round(fDistance);
                //
                /*************************************************************************/

                /*************************************************************************/
                // Run through and render the primitive.
                while (nCount-- > 0)
                {
                    // Increment position.
                    vPosition1 += vLength;

                    // Stretch the pixel between the two vectors.
                    spriteBatch.Draw(m_Pixel,
                                      Position + vPosition1 + 0.5f * (vPosition2 - vPosition1),
                                      null,
                                      Color,
                                      fAngle,
                                      new Vector2(0.5f, 0.5f),
                                      new Vector2(fDistance, m_fThickness),
                                      SpriteEffects.None,
                                      Depth);
                }
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a round algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /// <param name="_fAngle">The counterclockwise rotation in radians. (0.0f is default).</param>
        /// <param name="_vPivot">Position in which to rotate around.</param>
        /*************************************************************************/
        public void RenderRoundPrimitive(SpriteBatch spriteBatch, float _fAngle, Vector2 _vPivot)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Rotate object based on pivot.
            Rotate(_fAngle, _vPivot);
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero, vLength = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            int nCount = 0;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));

                // Calculate length.
                vLength = vPosition2 - vPosition1;
                vLength.Normalize();

                // Calculate count for roundness.
                nCount = (int)Math.Round(fDistance);
                //
                /*************************************************************************/

                /*************************************************************************/
                // Run through and render the primitive.
                while (nCount-- > 0)
                {
                    // Increment position.
                    vPosition1 += vLength;

                    // Stretch the pixel between the two vectors.
                    spriteBatch.Draw(m_Pixel,
                                      Position + vPosition1 + 0.5f * (vPosition2 - vPosition1),
                                      null,
                                      Color,
                                      fAngle,
                                      new Vector2(0.5f, 0.5f),
                                      new Vector2(fDistance, m_fThickness),
                                      SpriteEffects.None,
                                      Depth);
                }
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a point and line algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /*************************************************************************/
        public void RenderPolygonPrimitive(SpriteBatch spriteBatch)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));
                //
                /*************************************************************************/

                /*************************************************************************/
                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1 + 0.5f * (vPosition2 - vPosition1),
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0.5f, 0.5f),
                                  new Vector2(fDistance, Thickness),
                                  SpriteEffects.None,
                                  Depth);

                // Render the points of the polygon.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1,
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0.5f, 0.5f),
                                  m_fThickness,
                                  SpriteEffects.None,
                                  Depth);
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Render primitive by using a point and line algorithm.
        /// </summary>
        /// <param name="_spriteBatch">The sprite batch to use to render the primitive object.</param>
        /// <param name="_fAngle">The counterclockwise rotation in radians. (0.0f is default).</param>
        /// <param name="_vPivot">Position in which to rotate around.</param>
        /*************************************************************************/
        public void RenderPolygonPrimitive(SpriteBatch spriteBatch, float _fAngle, Vector2 _vPivot)
        {
            /*************************************************************************/
            // Validate.
            if (m_VectorList.Count < 2)
                return;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Rotate object based on pivot.
            Rotate(_fAngle, _vPivot);
            //
            /*************************************************************************/

            /*************************************************************************/
            // Local variables.
            Vector2 vPosition1 = Vector2.Zero, vPosition2 = Vector2.Zero;
            float fDistance = 0f, fAngle = 0f;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Run through the list of vectors.
            for (int i = m_VectorList.Count - 1; i >= 1; --i)
            {
                /*************************************************************************/
                // Store positions.
                vPosition1 = m_VectorList[i - 1];
                vPosition2 = m_VectorList[i];
                //
                /*************************************************************************/

                /*************************************************************************/
                // Calculate the distance between the two vectors.
                fDistance = Vector2.Distance(vPosition1, vPosition2);

                // Calculate the angle between the two vectors.
                fAngle = (float)Math.Atan2((double)(vPosition2.Y - vPosition1.Y),
                                           (double)(vPosition2.X - vPosition1.X));
                //
                /*************************************************************************/

                /*************************************************************************/
                // Stretch the pixel between the two vectors.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1 + 0.5f * (vPosition2 - vPosition1),
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0.5f, 0.5f),
                                  new Vector2(fDistance, Thickness),
                                  SpriteEffects.None,
                                  Depth);

                // Render the points of the polygon.
                spriteBatch.Draw(m_Pixel,
                                  Position + vPosition1,
                                  null,
                                  Color,
                                  fAngle,
                                  new Vector2(0.5f, 0.5f),
                                  m_fThickness,
                                  SpriteEffects.None,
                                  Depth);
                //
                /*************************************************************************/
            }
            //
            /*************************************************************************/
        }

        /*************************************************************************/
        /// <summary>
        /// Rotate primitive object based on pivot.
        /// </summary>
        /// <param name="_fAngle">The counterclockwise rotation in radians. (0.0f is default).</param>
        /// <param name="_vPivot">Position in which to rotate around.</param>
        /*************************************************************************/
        public void Rotate(float _fAngle, Vector2 _vPivot)
        {
            /*************************************************************************/
            // Subtract pivot from all points.
            for (int i = m_VectorList.Count - 1; i >= 0; --i)
                m_VectorList[i] -= _vPivot;
            //
            /*************************************************************************/

            /*************************************************************************/
            // Rotate about the origin.
            Matrix mat = Matrix.CreateRotationZ(_fAngle);
            for (int i = m_VectorList.Count - 1; i >= 0; --i)
                m_VectorList[i] = Vector2.Transform(m_VectorList[i], mat);
            //
            /*************************************************************************/

            /*************************************************************************/
            // Add pivot to all points.
            for (int i = m_VectorList.Count - 1; i >= 0; --i)
                m_VectorList[i] += _vPivot;
            //
            /*************************************************************************/
        }
    }
}
