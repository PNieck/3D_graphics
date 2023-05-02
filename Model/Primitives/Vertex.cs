using System.Numerics;

namespace _3D_graphics.Model.Primitives
{
    public class Vertex
    {
        Vector3 _coordinates;
        Vector3 _normal;

        public float x { get { return _coordinates.X; } }
        public float y { get { return _coordinates.Y; } }
        public float z { get { return _coordinates.Z; } }

        public Vertex(float x, float y, float z, float normalX, float normalY, float normalZ)
        {
            _coordinates = new Vector3(x, y, z);
            _normal = new Vector3(normalX, normalY, normalZ);
        }

        public Vertex(Vector3 coordinates, Vector3 normal)
        {
            _coordinates = coordinates;
            _normal = normal;
        }
    }
}
