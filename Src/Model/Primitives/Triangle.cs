using System.Numerics;

namespace _3D_graphics.Model.Primitives
{
    public class Triangle
    {
        public Vertex v1 { get; }
        public Vertex v2 { get; }
        public Vertex v3 { get; }

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Triangle Transform(Matrix4x4 matrix)
        {
            return new Triangle(v1.Tranform(matrix), v2.Tranform(matrix), v3.Tranform(matrix));
        }

        public Triangle Move(Vector3 vector)
        {
            return new Triangle(v1.Move(vector), v2.Move(vector), v3.Move(vector));
        }

        public IEnumerable<Vertex> Vertices()
        {
            yield return v1;
            yield return v2;
            yield return v3;
        }

        public override string ToString()
        {
            return $"Coordinates: {v1.coordinates}, {v2.coordinates}, {v3.coordinates}";
        }
    }
}
