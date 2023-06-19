using _3D_graphics.Controller.Rendering.RenderingEngines;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering
{
    public class RenderController
    {
        private CameraController _cameraController;
        private RenderingEngine _renderEngine;

        public CameraController Camera { get { return _cameraController; } }

        public RenderController(int windowWidth, int windowHeight, Car car)
        {
            _cameraController = new CameraController(car, windowWidth, windowHeight);
            //_renderEngine = new ObjectColorRendering(windowWidth, windowHeight);
            _renderEngine = new EdgesRendering(windowWidth, windowHeight);
            //_renderEngine = new PhongRendering(windowWidth, windowHeight);
        }

        public Canvas RenderScene(Scene scene)
        {
            ICamera camera = _cameraController.GetCamera();
            return _renderEngine.RenderScene(scene, camera);
        }
    }
}
