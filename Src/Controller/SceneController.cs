using _3D_graphics.Controller.SceneInit;
using _3D_graphics.Model;
using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics.Controller
{
    public class SceneController
    {
        public Scene scene { get; }

        public SceneController()
        {
            InitSceneController initScene = new InitSceneController();
            scene = initScene.GetScene();
        }

        public void MoveCarForward()
        {
            lock(scene)
            {
                scene.car.GoForeward();
            }
        }

        public void MoveCarBackward()
        {
            lock (scene)
            {
                scene.car.GoBackward();
            }
        }

        public void TurnCarRight()
        {
            lock (scene)
            {
                scene.car.TurnRight();
            }
        }

        public void TurnCarLeft()
        {
            lock (scene)
            {
                scene.car.TurnLeft();
            }
        }

        public void MoveCarLights(CarLightMovement move)
        {
            lock(scene)
            {
                scene.car.MoveLight(move);
            }
        }
    }
}
