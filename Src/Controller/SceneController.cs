using _3D_graphics.Controller.Rendering;
using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;

namespace _3D_graphics.Controller
{
    public delegate void SceneChangedHandler(Canvas screen);

    public class SceneController
    {
        private Canvas screen;
        private Scene scene;
        private event SceneChangedHandler? sceneChanged;

        private RenderController renderController;

        public SceneController(int width, int height, SceneChangedHandler? handler = null)
        {
            screen = new Model.Canvas(width, height);
            
            InitSceneContoller initScene = new InitSceneContoller();
            scene = initScene.GetScene();

            renderController = new RenderController(width, height, scene.car);

            if (handler != null)
            {
                sceneChanged = handler;
            }
        }

        public void AddNewSceneObserver(SceneChangedHandler handler)
        {
            sceneChanged += handler;
        }

        public void RequestRender()
        {
            screen = renderController.RenderScene(scene);
            sceneChanged?.Invoke(screen);
        }

        public void MoveCarForeward()
        {
            scene.car.GoForeward();
            RequestRender();
        }

        public void MoveCarBackward()
        {
            scene.car.GoBackward();
            RequestRender();
        }

        public void TurnCarRight()
        {
            scene.car.TurnRight();
            RequestRender();
        }

        public void TurnCarLeft()
        {
            scene.car.TurnLeft();
            RequestRender();
        }

        public void ChangeToStaticCamera()
        {
            renderController.Camera.ChangeToStaticCamera();
            RequestRender();
        }

        public void ChangeToCarFollowingCamera()
        {
            renderController.Camera.ChangeToCarFollowingCamera();
            RequestRender();
        }

        public void ChangeToTPPCamera()
        {
            renderController.Camera.ChangeToTPPCamera();
            RequestRender();
        }
    }
}
