using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering
{
    public class CameraController
    {
        private BaseCamera _baseCamera;

        public CameraController(Car car, int width, int height) {
            _baseCamera = new BaseCamera(
                new Vector3(0, -700, 700), Vector3.Zero, width, height, Angle.FromDegrees(100));

            car.AddPositionObserver(TargetMovedHandler);
        }

        public ICamera GetCamera() => _baseCamera;

        private void TargetMovedHandler(Vector3 newPosition)
        {

        }
    }
}
