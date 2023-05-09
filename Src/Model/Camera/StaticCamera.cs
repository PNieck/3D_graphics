using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public class StaticCamera : BaseCamera, ICamera
    {
        public StaticCamera(Vector3 coordinates, Vector3 cameraTarget, int width, int height, Angle fov):
            base(coordinates, cameraTarget, width, height, fov)
        {}
    }
}
