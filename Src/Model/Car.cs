using System.Numerics;

namespace _3D_graphics.Model
{
    public delegate void CarHaveMoved(Vector3 newPosition);

    public class Car: RenderObject
    {
        private event CarHaveMoved? carHaveMoved;

        public Car(RenderObject model) : base(model) { }

        public void AddPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved += handerMethod;
        }

        public void RemoverPositionObserver(CarHaveMoved handerMethod)
        {
            carHaveMoved -= handerMethod;
        }

        public void GoForeward(float unit)
        {
            Vector3 translation = new Vector3(unit, 0, 0);
            mesh.Move(translation);
        }

        public void GoBackward(float unit)
        {
            Vector3 translation = new Vector3(-unit, 0, 0);
            mesh.Move(translation);
        }
    }
}
