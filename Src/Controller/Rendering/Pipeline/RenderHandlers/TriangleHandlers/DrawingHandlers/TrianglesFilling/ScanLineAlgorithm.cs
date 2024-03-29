﻿using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.TrianglesFilling
{
    public class ScanLineAlgorithm
    {
        private Canvas canvas;
        private ICamera camera;
        private Shading shadingAlgorithm;

        public ScanLineAlgorithm(Canvas painter, ICamera camera, Shading shadingAlgorithm)
        {
            this.canvas = painter;
            this.camera = camera;
            this.shadingAlgorithm = shadingAlgorithm;
        }

        public void DrawTriangle(Triangle triangle)
        {
            shadingAlgorithm.SetTriangle(triangle);

            Triangle triangleFromObserver = camera.Project(triangle);
            using var painter = canvas.GetPixelPainter(Outline(triangleFromObserver));

            if (painter.IsEmpty)
                return;

            Draw(triangleFromObserver, painter);
        }

        private void Draw(Triangle triangle, IPixelPainter painter)
        {
            (Vertex v1, Vertex v2, Vertex v3) = SortVerticesAscendingByY(triangle);

            /* here we know that v1.y <= v2.y <= v3.y */
            /* check for trivial case of bottom-flat triangle */
            if (v2.y == v3.y)
            {
                FillTopFlatTriangle(v1.coordinates, v2.coordinates, v3.coordinates, triangle, painter);
            }
            /* check for trivial case of top-flat triangle */
            else if (v1.y == v2.y)
            {
                FillBottomFlatTriangle(v1.coordinates, v2.coordinates, v3.coordinates, triangle, painter);
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
                    FillTopFlatTriangle(v1.coordinates, v2.coordinates, v4, triangle, painter);
                    FillBottomFlatTriangle(v2.coordinates, v4, v3.coordinates, triangle, painter);
                }
                else
                {
                    FillTopFlatTriangle(v1.coordinates, v4, v2.coordinates, triangle, painter);
                    FillBottomFlatTriangle(v4, v2.coordinates, v3.coordinates, triangle, painter);
                }
            }
        }

        private void FillBottomFlatTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Triangle actTriangle, IPixelPainter painter)
        {
            float invslope1 = (v1.X - v3.X) / (v1.Y - v3.Y);
            float invslope2 = (v2.X - v3.X) / (v2.Y - v3.Y);

            float curx1 = v1.X;
            float curx2 = v2.X;

            int maxY = (int)v3.Y;

            for (int scanlineY = (int)v1.Y; scanlineY < maxY; scanlineY++)
            {
                DrawHorizontalLine(curx1, curx2, scanlineY, actTriangle, painter);
                curx1 += invslope1;
                curx2 += invslope2;
            }
        }

        private void FillTopFlatTriangle(Vector3 v1, Vector3 v2, Vector3 v3, Triangle actTriangle, IPixelPainter painter)
        {
            float invslope1 = (v2.X - v1.X) / (v2.Y - v1.Y);
            float invslope2 = (v3.X - v1.X) / (v3.Y - v1.Y);

            float curx1 = v1.X;
            float curx2 = v1.X;

            int maxY = (int)v3.Y;

            for (int scanlineY = (int)v1.Y; scanlineY < maxY; scanlineY++)
            {
                DrawHorizontalLine(curx1, curx2, scanlineY, actTriangle, painter);
                curx1 += invslope1;
                curx2 += invslope2;
            }
        }

        private void DrawHorizontalLine(float x1, float x2, int y, Triangle actTriangle, IPixelPainter painter)
        {
            int actX = (int)MathF.Floor(x1);
            int stopX = (int)MathF.Ceiling(x2);

            while (actX <= stopX)
            {
                float z = CalculateZ(actX, y, actTriangle);

                if (!painter.Contains(actX, y))
                {
                    if (actX < painter.MinX)
                        System.Diagnostics.Debug.Write($"X diff: {painter.MinX - actX} ");
                    else if (actX > painter.MaxX)
                        System.Diagnostics.Debug.Write($"X diff: {actX - painter.MaxX} ");

                    if (y < painter.MinY)
                        System.Diagnostics.Debug.Write($"Y diff: {painter.MinY - y}");
                    else if (y > painter.MaxY)
                        System.Diagnostics.Debug.Write($"Y diff: {y - painter.MaxY}");

                    System.Diagnostics.Debug.WriteLine("");
                }

                if (painter.Contains(actX, y) && painter.IsOnTop(actX, y, z))
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

        private static CanvasPart Outline(Triangle triangle)
        {
            float minX = triangle.v1.x;
            float maxX = triangle.v1.x;
            float minY = triangle.v1.y;
            float maxY = triangle.v1.y;

            if (minX > triangle.v2.x) minX = triangle.v2.x;
            else if (maxX < triangle.v2.x) maxX = triangle.v2.x;

            if (minX > triangle.v3.x) minX = triangle.v3.x;
            else if (maxX < triangle.v3.x) maxX = triangle.v3.x;

            if (minY > triangle.v2.y) minY = triangle.v2.y;
            else if (maxY < triangle.v2.y) maxY = triangle.v2.y;

            if (minY > triangle.v3.y) minY = triangle.v3.y;
            else if (maxY < triangle.v3.y) maxY = triangle.v3.y;

            return new CanvasPart((int)MathF.Floor(minX - 1),
                            (int)MathF.Ceiling(maxY + 1),
                            (int)MathF.Ceiling(maxX - minX + 3),
                            (int)MathF.Ceiling(maxY - minY + 3));
        }
    }
}
