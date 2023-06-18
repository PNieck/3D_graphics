using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public interface ICamera
    {
        public Vector3 Position { get; }

        public Matrix4x4 GetCameraMatrix();
    }
}
