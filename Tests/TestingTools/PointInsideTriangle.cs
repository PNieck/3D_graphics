using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace Tests.TestingTools
{
    public static class PointInsideTriangle
    {
        public static bool PointInsideOneOf2DTriangles(float x, float y, IEnumerable<Triangle> triangles)
            => PointInsideOneOf2DTriangles(new Vector2(x, y), triangles);

        public static bool PointInsideOneOf2DTriangles(Vector2 point, IEnumerable<Triangle> triangles)
        {
            foreach (Triangle triangle in triangles)
            {
                if (PointIn2DTriangle(point, triangle))
                    return true;
            }

            return false;
        }

        private static bool PointIn2DTriangle(Vector2 pt, Triangle t)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;
            d1 = Sign(pt, t.v1, t.v2);
            d2 = Sign(pt, t.v2, t.v3);
            d3 = Sign(pt, t.v3, t.v1);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }


        private static float Sign(Vector2 p1, Vertex p2, Vertex p3)
        {
            return (p1.X - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.Y - p3.y);
        }
    }
}
