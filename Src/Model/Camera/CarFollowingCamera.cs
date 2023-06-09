﻿using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.Camera
{
    public class CarFollowingCamera : Camera
    {
        public CarFollowingCamera(Vector3 coordinates, Car car, int width, int height, Angle fov) :
            base(coordinates, car.Coordinates, width, height, fov)
        {
            car.AddPositionObserver(CarMovedHandle);
        }

        private void CarMovedHandle(Vector3 coordinates, Vector3 vectorToFront) => ChangeTarget(coordinates);
    }
}
