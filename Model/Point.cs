using System.Numerics;

namespace _3D_graphics.Model
{
    public class Point
    {
        Vector3 _coordinates;

        public float x { get { return _coordinates.X; } }
        public float y { get { return _coordinates.Y; } }
        public float z { get { return _coordinates.Z; } }

        public Point(float x, float y, float z)
        {
            _coordinates = new Vector3(x, y, z);
        }

        public Point(Vector3 coordinates)
        {
            this._coordinates = coordinates;
        }
    }
}
