using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model
{
    public delegate void CarHaveMoved(Vector3 newCoordinates, Vector3 newVectorToFront);

    public class Car: RenderObject
    {
        public const float movementSpeed = 5.0f;
        public static readonly Angle turningSpeed = Angle.FromDegrees(5.0f);
        
        private event CarHaveMoved? carHaveMoved;

        private Vector3 _front;
        private Vector3 _coordinates;

        public Vector3 Coordinates { get { return _coordinates; } }
        public Vector3 VectorToFront { get { return _front; } }

        public override IEnumerable<Triangle> triangles
        {
            get
            {
                foreach (var triangle in base.triangles)
                {
                    yield return triangle.Move(_coordinates);
                }
            }
        }

        public Car(RenderObject model) : base(model)
        {
            _front = Vector3.UnitX;
            _coordinates = Vector3.Zero;
        }

        public void AddPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved += handerMethod;
        }

        public void RemoverPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved -= handerMethod;
        }

        public void GoForeward()
        {
            _coordinates += _front * movementSpeed;
            InformObserversAboutMovement();
        }

        public void GoBackward()
        {
            _coordinates -= _front * movementSpeed;
            InformObserversAboutMovement();
        }

        public void TurnRight()
        {
            TurnByAngle(-turningSpeed);
            InformObserversAboutMovement();
        }

        public void TurnLeft()
        {
            TurnByAngle(turningSpeed);
            InformObserversAboutMovement();
        }


        private void TurnByAngle(Angle angle)
        {
            _front = Vector3.Transform(
                _front,
                Quaternion.CreateFromYawPitchRoll(0, 0, angle.Radians)
            );
            mesh.RotateAroundZ(angle);
        }

        private void InformObserversAboutMovement()
            => carHaveMoved?.Invoke(_coordinates, _front);
    }
}
