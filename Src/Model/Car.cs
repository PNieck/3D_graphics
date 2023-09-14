using _3D_graphics.Model.Primitives;
using _3D_graphics.Model.SourceOfLight;
using System.Numerics;

namespace _3D_graphics.Model
{
    public delegate void CarHaveMoved(Vector3 newCoordinates, Vector3 newVectorToFront);

    public class Car: RenderObject
    {
        public const float movementSpeed = 5.0f;
        public static readonly Angle turningSpeed = Angle.FromDegrees(5.0f);
        
        private event CarHaveMoved? carHaveMoved;

        private CarHeadLight headLight;

        public Vector3 Coordinates { get; private set; }
        public Vector3 VectorToFront { get; private set; }

        public ISourceOfLight Light { get => headLight; }

        public override IEnumerable<Triangle> triangles
        {
            get
            {
                foreach (var triangle in base.triangles)
                {
                    yield return triangle.Move(Coordinates);
                }
            }
        }

        public Car(RenderObject model) : base(model)
        {
            VectorToFront = Vector3.UnitX;
            Coordinates = Vector3.Zero;

            // TODO: remove hard-coded offset
            headLight = new CarHeadLight(Coordinates, VectorToFront, 100, 50, 0.5f);

            AddPositionObserver(headLight.UpdatePosition);
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
            var offset = VectorToFront * movementSpeed;
            Coordinates += offset;
            InformObserversAboutMovement();
        }

        public void GoBackward()
        {
            var offset = -VectorToFront * movementSpeed;
            Coordinates += offset;
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

        public override void MoveByVector(Vector3 vector)
        {
            base.MoveByVector(vector);
            InformObserversAboutMovement();
        }

        public void MoveLight(CarLightMovement move)
            => headLight.Move(move);


        private void TurnByAngle(Angle angle)
        {
            var quat = Quaternion.CreateFromYawPitchRoll(0, 0, angle.Radians);

            VectorToFront = Vector3.Transform(
                VectorToFront,
                quat
            );

            mesh.RotateAroundZ(angle);
        }

        private void InformObserversAboutMovement()
            => carHaveMoved?.Invoke(Coordinates, VectorToFront);
    }
}
