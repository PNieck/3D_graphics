using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public abstract class Camera : ICamera
    {
        private const float NEAR_PLANE = 10;
        private const float FAR_PLANE = 1000;

        private readonly int _width;
        private readonly int _height;
        private readonly Angle _fov;

        private Vector3 _position;
        private Vector3 _target;

        private Matrix4x4 _projectionMatrix;
        private Matrix4x4 _viewMatrix;

        private bool _cameraParametersHaveChanged;
        private Matrix4x4 _cameraMatrix;
        private Matrix4x4 _normalsTransformationMatrix;

        private float _aspectRatio { get => _width / (float)_height; }

        public Vector3 Position { get { return _position; } }

        public Vector3 LookingDirection { get { return Vector3.Normalize(_target - _position); } }

        public Camera(Vector3 coordinates, Vector3 cameraTarget, int width, int height, Angle fov)
        {
            _fov = fov;
            _width = width;
            _height = height;
            _position = coordinates;
            _target = cameraTarget;
            _cameraParametersHaveChanged = false;

            /* Camera matrix must be created at the end */
            _viewMatrix = CreateViewMatrix();
            _projectionMatrix = CreateProjectionMatrix();
            UpdateCameraMatrix();
        }

        public Matrix4x4 GetCameraMatrix()
        {
            if (_cameraParametersHaveChanged)
                UpdateCameraMatrix();

            return _cameraMatrix;
        }

        public Matrix4x4 GetNormalsTranFormationMatrix()
        {
            if (_cameraParametersHaveChanged)
                UpdateCameraMatrix();

            return _normalsTransformationMatrix;
        }

        public Vector3 Project(Vector3 worldPosition)
        {
            var p = Vector4.Transform(new Vector4(worldPosition, 1.0f), GetCameraMatrix());

            return new Vector3(p.X / p.W * _width / 2, p.Y / p.W * _height / 2, p.Z / p.W);
        }

        public Vector3 ProjectNormal(Vector3 worldNormal)
        {
            var n = Vector4.Transform(new Vector4(worldNormal, 1.0f), GetNormalsTranFormationMatrix());

            return new Vector3(n.X / n.W, n.Y / n.W, n.Z / n.W);
        }

        public Vertex Project(Vertex worldVertex)
            => new Vertex(Project(worldVertex.coordinates), ProjectNormal(worldVertex.normal));

        public Triangle Project(Triangle worldTriangle)
            => new Triangle(Project(worldTriangle.v1), Project(worldTriangle.v2), Project(worldTriangle.v3));

        public Vector3 Unproject(Vector3 screenPosition)
        {
            screenPosition.X /= _width / 2;
            screenPosition.Y /= _height / 2;
            var p = Vector4.Transform(new Vector4(screenPosition, 1.0f), Matrix4x4.Transpose(_normalsTransformationMatrix));

            return new Vector3(p.X / p.W, p.Y / p.W, p.Z / p.W);
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

        private void UpdateCameraMatrix()
        {
            _cameraMatrix = _viewMatrix * _projectionMatrix;

            if (!Matrix4x4.Invert(_cameraMatrix, out _normalsTransformationMatrix))
                throw new Exception("Cannot invert camera matrix");

            _normalsTransformationMatrix = Matrix4x4.Transpose(_normalsTransformationMatrix);
        }

        
    }
}
