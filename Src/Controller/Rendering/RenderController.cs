using _3D_graphics.Controller.Rendering.RenderingEngines;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;

namespace _3D_graphics.Controller.Rendering
{
    public class RenderController
    {
        private CameraController _cameraController;
        private BaseRenderingEngine _renderEngine;

        public RenderController(int windowWidth, int windowHeight, Car car)
        {
            _cameraController = new CameraController(car, windowWidth, windowHeight);
            _renderEngine = new EdgesRendering(windowWidth, windowHeight);
        }

        public Canvas RenderScene(Scene scene)
        {
            ICamera camera = _cameraController.GetCamera();
            return _renderEngine.RednerScene(scene, camera);
        }
    }
}
