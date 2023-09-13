using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public enum CarLightMovement
    {
        Up,
        Down,
        Right,
        Left
    }

    public class CarHeadLight : Spotlight, ISourceOfLight
    {
        private static readonly Angle rotationSpeed = Angle.FromDegrees(2.0f);
        
        private readonly float offsetFromCenter;
        private readonly Vector3 height;
        private Quaternion rotation;

        public CarHeadLight(Vector3 carCoordinates, Vector3 vectorToFront, float offsetFromCenter, float height, float focus) :
            base(carCoordinates + offsetFromCenter * vectorToFront + height * Vector3.UnitZ, vectorToFront, focus, Color.White)
        {
            this.offsetFromCenter = offsetFromCenter;
            this.height = height * Vector3.UnitZ;

            rotation = Quaternion.Identity;
        }

        public void UpdatePosition(Vector3 carCoordinates, Vector3 carVectorToFront)
        {
            Coordinates = carCoordinates + offsetFromCenter * carVectorToFront + height;
            lightingDirection = Vector3.Transform(carVectorToFront, rotation);
        }

        public void Move(CarLightMovement move)
        {
            Quaternion quat;

            switch(move)
            {
                case CarLightMovement.Up:
                    quat = Quaternion.CreateFromYawPitchRoll(rotationSpeed.Radians, 0, 0);
                    break;

                default:
                    throw new Exception("Unknown movement specifier");
            }

            rotation *= quat;

            lightingDirection = Vector3.Transform(lightingDirection, quat);
        }
    }
}
