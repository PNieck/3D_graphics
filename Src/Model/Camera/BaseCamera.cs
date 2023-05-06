using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public class BaseCamera: ICamera
    {
        private const float DEG_TO_RAD = 0.0174532925f;
        private const float NEAR_PLANE = 10;
        private const float FAR_PLANE = 1000;

        private Vector3 _position;
        private Vector3 _target;

        private Matrix4x4 _projectionMatrix;
        private Matrix4x4 _viewMatrix; 

        public BaseCamera(Vector3 coordinates, Vector3 cameraTarget, int width, int height, float fov_deg)
        {
            _projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
                fov_deg * DEG_TO_RAD, width / height, NEAR_PLANE, FAR_PLANE);

            _position = coordinates;
            _target = cameraTarget;

            _viewMatrix = CreateViewMatrix();
        }

        public Matrix4x4 GetCameraMatrix() => _viewMatrix * _projectionMatrix;

        //public Matrix4x4 GetCameraMatrix() => _projectionMatrix * _viewMatrix;

        public virtual void ChangeTarget(Vector3 newTarget)
        {
            _target = newTarget;
            _viewMatrix = CreateViewMatrix();
        }


        private Matrix4x4 CreateViewMatrix()
        {
            return Matrix4x4.CreateLookAt(_position, _target, Vector3.UnitZ);
        }
    }
}
