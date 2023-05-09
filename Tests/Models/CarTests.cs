using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;
using System.Numerics;

namespace Tests.Models
{
    public class CarTests
    {
        private Car _car;

        public CarTests()
        {
            InitSceneContoller controller = new InitSceneContoller();
            _car = controller.GetCarObject();
        }

        [Fact]
        public void InitCarPositionIsVectorZeroAndFrontIsXAxis()
        {
            Assert.Equal(Vector3.Zero, _car.Coordinates);
            Assert.Equal(Vector3.UnitX, _car.VectorToFront);
        }

        [Fact]
        public void CorrectPositionAfterMovement()
        {
            InitCarPositionIsVectorZeroAndFrontIsXAxis();

            _car.GoForeward();

            Assert.Equal(new Vector3(Car.movementSpeed, 0, 0), _car.Coordinates);
            Assert.Equal(Vector3.UnitX, _car.VectorToFront);
        }
    }
}
