using _3D_graphics.Model.Camera;
using System.Numerics;

namespace Tests.TestingTools
{
    public class ConstantCamera : ICamera
    {
        public Matrix4x4 GetCameraMatrix()
            => Matrix4x4.Identity;
    }
}
