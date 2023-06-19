using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public class TPPCamera : Camera, ICamera
    {
        private static readonly Vector3 CameraPositionOffset = new Vector3(0, 0, 3);
        private const float CameraTargetMultiplier = 15f;
        private const float CameraPositionMultiplier = -2f;

        public TPPCamera(Car car, int width, int height, Angle fov):
            base(CalculateCameraPosition(car.Coordinates, car.VectorToFront), CalculateCameraTarget(car.Coordinates, car.VectorToFront), width, height, fov)
        {
            car.AddPositionObserver(CarHaveMovedHandler);
        }


        private void CarHaveMovedHandler(Vector3 coordinates, Vector3 vectorToFront)
        {
            ChangePositionAndTarget(
                CalculateCameraPosition(coordinates, vectorToFront),
                CalculateCameraTarget(coordinates, vectorToFront)
            );
        }

        private static Vector3 CalculateCameraPosition(Vector3 carCoordinates, Vector3 vectorToFront)
            => vectorToFront * CameraPositionMultiplier + carCoordinates + CameraPositionOffset;

        private static Vector3 CalculateCameraTarget(Vector3 carCoordinates, Vector3 vectorToFront)
            => vectorToFront * CameraTargetMultiplier + carCoordinates;
    }
}
