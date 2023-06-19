using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering
{
    public class CameraController
    {
        private static readonly Vector3 DefaultInitCameraPosition = new Vector3(0, -400, 400);
        private static readonly Vector3 DefaultCameraTarget = Vector3.Zero;
        private static readonly Angle DefaultFOV = Angle.FromDegrees(50);

        private ICamera _actualCamera;
        private readonly Car _car;
        private readonly int _width;
        private readonly int _height;

        public CameraController(Car car, int width, int height) {
            _car = car;
            _width = width;
            _height = height;

            _actualCamera = GetCarFollowingCamera();
        }

        public ICamera GetCamera() => _actualCamera;

        public void ChangeToCarFollowingCamera()
        {
            if (_actualCamera is not CarFollowingCamera)
                _actualCamera = GetCarFollowingCamera();
        }

        public void ChangeToStaticCamera()
        {
            if (_actualCamera is not StaticCamera)
                _actualCamera = GetStaticCamera();
        }

        public void ChangeToTPPCamera()
        {
            if (_actualCamera is not TPPCamera)
                _actualCamera = GetTPPCamera();
        }


        private ICamera GetCarFollowingCamera()
            => new CarFollowingCamera(DefaultInitCameraPosition, _car, _width, _height, DefaultFOV);

        private ICamera GetStaticCamera()
            => new StaticCamera(DefaultInitCameraPosition, DefaultCameraTarget, _width, _height, DefaultFOV);

        private ICamera GetTPPCamera()
            => new TPPCamera(_car, _width, _height, DefaultFOV);
    }
}
