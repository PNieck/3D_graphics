
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public interface ICamera
    {
        public Vector3 Position { get; }

        public Vector3 LookingDirection { get; }

        public Matrix4x4 GetCameraMatrix();

        public Vector3 Project(Vector3 worldVector3);

        public Vector3 ProjectNormal(Vector3 worldNormal);

        public Vertex Project(Vertex worldVertex);

        public Triangle Project(Triangle worldTriangle);

        public Vector3 Unproject(Vector3 screenVector3);
    }
}
