using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public abstract class BaseCamera: ICamera
    {
        private const float NEAR_PLANE = 10;
        private const float FAR_PLANE = 1000;

        private readonly float _aspectRatio;
        private readonly Angle _fov;

        private Vector3 _position;
        private Vector3 _target;

        private Matrix4x4 _projectionMatrix;
        private Matrix4x4 _viewMatrix;

        private bool _cameraParametersHaveChanged;
        private Matrix4x4 _cameraMatrix;

        public BaseCamera(Vector3 coordinates, Vector3 cameraTarget, int width, int height, Angle fov)
        {
            _fov = fov;
            _aspectRatio = width / (float)height;
            _position = coordinates;
            _target = cameraTarget;
            _cameraParametersHaveChanged = false;

            /* Camera matrix must be create at the end */
            _viewMatrix = CreateViewMatrix();
            _projectionMatrix = CreateProjectionMatrix();
            _cameraMatrix = CreateCameraMatrix();
        }

        public Matrix4x4 GetCameraMatrix()
        {
            if (_cameraParametersHaveChanged)
                _cameraMatrix = CreateCameraMatrix();

            return _cameraMatrix;
        }

        protected void ChangeTarget(Vector3 newTarget)
        {
            _target = newTarget;
            _viewMatrix = CreateViewMatrix();
            _cameraParametersHaveChanged = true;
        }

        protected void ChangePosition(Vector3 newPosition)
        {
            _position = newPosition;
            _viewMatrix = CreateViewMatrix();
            _cameraParametersHaveChanged = true;
        }

        protected void ChangePositionAndTarget(Vector3 newPosition, Vector3 newTarget)
        {
            _target = newTarget;
            _position = newPosition;
            _viewMatrix = CreateViewMatrix();
            _cameraParametersHaveChanged = true;
        }


        private Matrix4x4 CreateViewMatrix()
            => Matrix4x4.CreateLookAt(_position, _target, Vector3.UnitZ);

        private Matrix4x4 CreateProjectionMatrix()
            => Matrix4x4.CreatePerspectiveFieldOfView(_fov.Radians, _aspectRatio, NEAR_PLANE, FAR_PLANE);

        private Matrix4x4 CreateCameraMatrix()
            => _viewMatrix * _projectionMatrix;
    }
}
