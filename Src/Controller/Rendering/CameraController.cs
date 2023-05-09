using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering
{
    public class CameraController
    {
        private static readonly Vector3 DefaultInitCameraPosition = new Vector3(0, -700, 700);
        
        private CarFollowingCamera _carFollowingCamera;

        public CameraController(Car car, int width, int height) {
            _carFollowingCamera = new CarFollowingCamera(DefaultInitCameraPosition, car, width, height, Angle.FromDegrees(100));
        }

        public ICamera GetCamera() => _carFollowingCamera;
    }
}
