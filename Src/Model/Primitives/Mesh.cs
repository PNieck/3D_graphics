using System.Numerics;

namespace _3D_graphics.Model.Primitives
{ 
    public class Mesh
    {
        private readonly List<Triangle> _originalTriangles;
        private List<Triangle> _triangles;
        private Matrix4x4 _objectMatrix;

        public IEnumerable<Triangle> triangles
            { get { return _triangles.AsReadOnly(); }  }

        public Mesh(IEnumerable<Triangle> triangles, Vector3 position, float scale = 1)
        {
            _originalTriangles = new List<Triangle>(triangles);
            _objectMatrix = Matrix4x4.CreateTranslation(position) * Matrix4x4.CreateScale(scale);

            _triangles = new List<Triangle>(_originalTriangles.Count);
            foreach(Triangle triangle in _originalTriangles)
            {
                _triangles.Add(triangle.Transform(_objectMatrix));
            }
        }

        public Mesh(IEnumerable<Triangle> triangles) : this(triangles, Vector3.Zero) { }

        public void Scale(float scale)
        {
            _objectMatrix *= Matrix4x4.CreateScale(scale);
            CalculateTriangles();
        }

        public void Move(Vector3 translation)
        {
            _objectMatrix *= Matrix4x4.CreateTranslation(translation);
            CalculateTriangles();
        }

        public void RotateAroundZ(Angle angle)
        {
            _objectMatrix *= Matrix4x4.CreateRotationZ(angle.Radians);
            CalculateTriangles();
        }


        private void CalculateTriangles()
        {
            for (int i=0; i < _originalTriangles.Count; i++)
            {
                _triangles[i] = _originalTriangles[i].Transform(_objectMatrix);
            }
        }
    }
}
