using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public interface ICamera
    {
        public Matrix4x4 GetCameraMatrix();
    }
}
