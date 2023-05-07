using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model
{
    public delegate void CarHaveMoved(Vector3 newPosition);

    public class Car: RenderObject
    {
        private const float movementSpeed = 5.0f;
        private static readonly Angle turningSpeed = Angle.FromDegrees(5.0f);
        
        private event CarHaveMoved? carHaveMoved;

        private Vector3 _front;
        private Vector3 _coordinates;

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
            _front = new Vector3(movementSpeed, 0, 0);
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

        public void GoForeward() => _coordinates += _front;

        public void GoBackward() => _coordinates -= _front;

        public void TurnRight() => TurnByAngle(-turningSpeed);

        public void TurnLeft() => TurnByAngle(turningSpeed);


        private void TurnByAngle(Angle angle)
        {
            _front = Vector3.Transform(
                _front,
                Quaternion.CreateFromYawPitchRoll(0, 0, angle.Radians)
            );
            mesh.RotateAroundZ(angle);
        }
    }
}
