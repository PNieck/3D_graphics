using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;

namespace Tests.Controllers
{
    public class InitSceneContollerTests
    {
        private InitSceneContoller _controller;

        public InitSceneContollerTests()
        {
            _controller = new InitSceneContoller();
        }

        [Fact]
        public void InitSceneControllerGetABackgroundModels()
        {
            IEnumerable<RenderObject> objects = _controller.GetBackgroundObjects();
        }

        [Fact]
        public void InitSceneControllerGetACarModels()
        {
            RenderObject objects = _controller.GetCar();
        }
    }
}