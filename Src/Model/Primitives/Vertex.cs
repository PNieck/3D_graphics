using System.Numerics;

namespace _3D_graphics.Model.Primitives
{
    public class Vertex
    {
        public Vector3 coordinates { get; }
        public Vector3 normal { get; }

        public float x { get { return coordinates.X; } }
        public float y { get { return coordinates.Y; } }
        public float z { get { return coordinates.Z; } }


        public Vertex(float x, float y, float z) :
            this(new Vector3(x, y, z), Vector3.UnitZ)
        { }

        public Vertex(float x, float y, float z, float normalX, float normalY, float normalZ) :
            this(new Vector3(x, y, z), new Vector3(normalX, normalY, normalZ))
        { }

        public Vertex(Vector3 coordinates) :
            this(coordinates, Vector3.UnitZ)
        { }

        public Vertex(Vector3 coordinates, Vector3 normal)
        {
            this.coordinates = coordinates;
            this.normal = normal;

            if (this.normal.LengthSquared() != 1.0f)
            {
                this.normal = Vector3.Normalize(this.normal);
            }
        }

        public Vertex Transform(Matrix4x4 matrix)
        {
            return new Vertex(
                Vector3.Transform(coordinates, matrix),
                Vector3.TransformNormal(normal, matrix)
            );
        }

        public Vertex Move(Vector3 vector)
        {
            return new Vertex(
                coordinates + vector,
                normal
            );
        }

        public override string ToString()
        {
            return $"Coordinates: {coordinates}, normal: {normal}";
        }
    }
}
