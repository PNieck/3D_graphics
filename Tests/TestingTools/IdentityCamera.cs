using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace Tests.TestingTools
{
    public class IdentityCamera : ICamera
    {
        private static readonly Vector3 position = new Vector3(0, 0, 400);

        public Vector3 Position => position;

        public Matrix4x4 GetCameraMatrix()
            => Matrix4x4.Identity;

        public Vector3 Project(Vector3 worldVector)
            => worldVector;

        public Vertex Project(Vertex worldVertex)
        {
            throw new NotImplementedException();
        }

        public Triangle Project(Triangle worldTriangle)
        {
            throw new NotImplementedException();
        }

        public Vector3 ProjectNormal(Vector3 worldNormal)
        {
            throw new NotImplementedException();
        }

        public Vector3 Unproject(Vector3 screenVector)
            => screenVector;
    }
}
