using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public class CarHeadLight : Spotlight, ISourceOfLight
    {
        private readonly float offsetFromCenter;
        private readonly Vector3 height;

        public CarHeadLight(Vector3 carCoordinates, Vector3 vectorToFront, float offsetFromCenter, float height, float focus) :
            base(carCoordinates + offsetFromCenter * vectorToFront + height * Vector3.UnitZ, vectorToFront, focus, Color.White)
        {
            this.offsetFromCenter = offsetFromCenter;
            this.height = height * Vector3.UnitZ;
        }

        public void UpdatePosition(Vector3 carCoordinates, Vector3 carVectorToFront)
        {
            Coordinates = carCoordinates + offsetFromCenter * carVectorToFront + height;
            lightingDirection = carVectorToFront;
        }


    }
}
