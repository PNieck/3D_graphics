using _3D_graphics.Model.Camera;
using System.Numerics;

namespace Tests.TestingTools
{
    public class ConstantCamera : ICamera
    {
        private static readonly Vector3 position = new Vector3(0, 0, 400);

        public Vector3 Position => position;

        public Matrix4x4 GetCameraMatrix()
            => Matrix4x4.Identity;
    }
}
