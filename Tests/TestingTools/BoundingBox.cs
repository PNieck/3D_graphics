using _3D_graphics.Model.Primitives;

namespace Tests.TestingTools
{
    public static class BoundingBox
    {
        public static Box Calculate(Triangle t)
        {
            float maxX = float.NegativeInfinity;
            float maxY = float.NegativeInfinity;
            float minX = float.PositiveInfinity;
            float minY = float.PositiveInfinity;

            foreach (Vertex v in t.Vertices())
            {
                if (maxX < v.x) maxX = v.x;
                if (minX > v.x) minX = v.x;

                if (maxY < v.y) maxY = v.y;
                if (minY > v.y) minY = v.y;
            }

            return new Box(maxX, minX, maxY, minY);
        }

        public static Box Calculate(IEnumerable<Triangle> triangles)
        {
            Box? result = null;

            foreach (var triangle in triangles)
            {
                if (result is null)
                    result = Calculate(triangle);
                else
                    result = Box.Union((Box)result, Calculate(triangle));
            }

            if (result is null)
                throw new ArgumentException("Collection cannot be empty");

            return (Box)result;
        }
    }

    public struct Box
    {
        public readonly float Width { get => Right - Left; }
        public readonly float Height { get => Top - Bottom; }


        public float Top { get; private set; }
        public float Bottom { get; private set; }
        public float Left { get; private set; }
        public float Right { get; private set; }

        public Box(float x1, float x2, float y1, float y2)
        {
            Top = MathF.Max(y1, y2);
            Bottom = MathF.Min(y1, y2);

            Left = MathF.Min(x1, x2);
            Right = MathF.Max(x1, x2);
        }

        public void Inflate(float value)
        {
            Top += value;
            Bottom -= value;
            Left -= value;
            Right += value;
        }

        public readonly bool Contains(float x, float y)
            => y >= Bottom && y <= Top && x >= Left && x <= Right;

        public override readonly string ToString()
            => $"Box - Top: {Top}, Bottom {Bottom}, Left: {Left}, Right: {Right}";

        public static Box Union(Box b1, Box b2)
        {
            return new Box(MathF.Max(b1.Right, b2.Right),
                           MathF.Min(b1.Left, b2.Left),
                           MathF.Max(b1.Top, b2.Top),
                           MathF.Min(b1.Bottom, b2.Bottom));
        }
    }
}
