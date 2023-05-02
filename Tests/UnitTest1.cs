using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void InitSceneControllerSuccesfullCreation()
        {
            InitSceneContoller controller = new InitSceneContoller();
        }

        [Fact]
        public void InitSceneControllerGetABackgroundModels()
        {
            InitSceneContoller controller = new InitSceneContoller();

            IEnumerable<RenderObject> objects = controller.GetBackgroundObjects();
        }
    }
}