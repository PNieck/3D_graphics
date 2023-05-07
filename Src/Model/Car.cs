using System.Numerics;

namespace _3D_graphics.Model
{
    public delegate void CarHaveMoved(Vector3 newPosition);

    public class Car: RenderObject
    {
        private const float speed = 5.0f;
        
        private event CarHaveMoved? carHaveMoved;

        private Vector3 _front;

        public Car(RenderObject model) : base(model)
        {
            _front = Vector3.UnitX;
        }

        public void AddPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved += handerMethod;
        }

        public void RemoverPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved -= handerMethod;
        }

        public void GoForeward() => mesh.Move(speed * _front);

        public void GoBackward() => mesh.Move(-speed * _front);
    }
}
