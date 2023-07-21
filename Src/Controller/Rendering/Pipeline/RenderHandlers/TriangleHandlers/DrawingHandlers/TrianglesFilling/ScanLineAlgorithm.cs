using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.TrianglesFilling
{
    public class ScanLineAlgorithm
    {
        private IZBufferedPixelPainter painter;
        private ICamera camera;
        private Shading shadingAlgorithm;

        public ScanLineAlgorithm(IZBufferedPixelPainter painter, ICamera camera, Shading shadingAlgorithm)
        {
            this.painter = painter;
            this.camera = camera;
            this.shadingAlgorithm = shadingAlgorithm;
        }

        public void DrawTriangle(Triangle triangle)
        {
            shadingAlgorithm.SetTriangle(triangle);

            Triangle triangleFromObserver = camera.Project(triangle);

            (Vertex v1, Vertex v2, Vertex v3) = SortVerticesAscendingByY(triangleFromObserver);

            /* here we know that v1.y <= v2.y <= v3.y */
            /* check for trivial case of bottom-flat triangle */
            if (v2.y == v3.y)
            {
                FillTopFlatTriangle(v1.coordinates, v2.coordinates, v3.coordinates, triangleFromObserver);
            }
            /* check for trivial case of top-flat triangle */
            else if (v1.y == v2.y)
            {
                FillBottomFlatTriangle(v1.coordinates, v2.coordinates, v3.coordinates, triangleFromObserver);
            }
            else
            {
                /* general case - split the triangle in a top-flat and bottom-flat one */
                Vector3 v4;

                if (v1.x == v3.x)
                    v4 = new Vector3(v1.x, v2.y, 0);
                else
                    v4 = new Vector3((v2.y - v1.y) * (v3.x - v1.x) / (v3.y - v1.y) + v1.x, v2.y, 0);

                if (v2.coordinates.X < v4.X)
                {
                    FillTopFlatTriangle(v1.coordinates, v2.coordinates, v4, triangleFromObserver);
                    FillBottomFlatTriangle(v2.coordinates, v4, v3.coordinates, triangleFromObserver);
                }
                else
                {
                    FillTopFlatTriangle(v1.coordinates, v4, v2.coordinates, triangleFromObserver);
                    FillBottomFlatTriangle(v4, v2.coordinates, v3.coordinates, triangleFromObserver);
                }
            }
        }

        private void FillBottomFlatTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Triangle actTriangle)
        {
            float invslope1 = (v1.X - v3.X) / (v1.Y - v3.Y);
            float invslope2 = (v2.X - v3.X) / (v2.Y - v3.Y);

            float curx1 = v1.X;
            float curx2 = v2.X;

            int maxY = (int)v3.Y;

            for (int scanlineY = (int)v1.Y; scanlineY < maxY; scanlineY++)
            {
                DrawHorizontalLine(curx1, curx2, scanlineY, actTriangle);
                curx1 += invslope1;
                curx2 += invslope2;
            }
        }

        private void FillTopFlatTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Triangle actTriangle)
        {
            float invslope1 = (v2.X - v1.X) / (v2.Y - v1.Y);
            float invslope2 = (v3.X - v1.X) / (v3.Y - v1.Y);

            float curx1 = v1.X;
            float curx2 = v1.X;

            int maxY = (int)v3.Y;

            for (int scanlineY = (int)v1.Y; scanlineY < maxY; scanlineY++)
            {
                DrawHorizontalLine(curx1, curx2, scanlineY, actTriangle);
                curx1 += invslope1;
                curx2 += invslope2;
            }
        }

        private void DrawHorizontalLine(float x1, float x2, int y, Triangle actTriangle)
        {
            int actX = (int)MathF.Floor(x1);
            int stopX = (int)MathF.Ceiling(x2) + 1;

            while (actX <= stopX)
            {
                float z = CalculateZ(actX, y, actTriangle);

                if (painter.CanDraw(actX, y, z))
                {
                    Vector3 worldCoordinates = camera.Unproject(new Vector3(actX, y, z));

                    painter.SetPixel(actX, y, z, shadingAlgorithm.GetColor(worldCoordinates));
                }
                actX++;
            }
        }

        private static float CalculateZ(float x, float y, Triangle triangle)
        {
            Vector3 v1 = triangle.v2.coordinates - triangle.v1.coordinates;
            Vector3 v2 = triangle.v3.coordinates - triangle.v1.coordinates;

            Vector3 normal = Vector3.Cross(v1, v2);

            float d = -(normal.X * triangle.v1.x + normal.Y * triangle.v1.y + normal.Z * triangle.v1.z);

            return -(normal.X * x + normal.Y * y + d) / normal.Z;
        }

        private static (Vertex v1, Vertex v2, Vertex v3) SortVerticesAscendingByY(Triangle triangle)
        {
            List<Vertex> vertices = new List<Vertex>(3)
            {
                triangle.v1,
                triangle.v2,
                triangle.v3
            };

            vertices.Sort((v1, v2) =>
            {
                int yCompResult = v1.y.CompareTo(v2.y);
                if (yCompResult != 0) return yCompResult;
                else return v1.x.CompareTo(v2.x);
            });

            return (vertices[0], vertices[1], vertices[2]);
        }
    }
}
