using _3D_graphics.Controller.Rendering;
using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller
{
    public delegate void SceneChangedHandler(Canvas screen);

    public enum RenderingType
    {
        Edges,
        ObjectColor,
        PhongShading
    }

    public class SceneController
    {
        private Canvas screen;
        private Scene scene;
        private event SceneChangedHandler? sceneChanged;

        private RenderController renderController;

        public SceneController(int width, int height, SceneChangedHandler? handler = null)
        {
            screen = new Canvas(width, height);
            
            InitSceneController initScene = new InitSceneController();
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

        public void MoveCarForward()
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

        public void SetRenderingType(RenderingType renderType)
        {
            renderController.SetRenderingType(renderType);
            RequestRender();
        }
    }
}
