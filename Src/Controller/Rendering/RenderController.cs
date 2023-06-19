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

        private readonly int windowWidth;
        private readonly int windowHeight;

        public CameraController Camera { get { return _cameraController; } }

        public RenderController(int windowWidth, int windowHeight, Car car)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            _cameraController = new CameraController(car, windowWidth, windowHeight);
            _renderEngine = new PhongRendering(windowWidth, windowHeight);
        }

        public Canvas RenderScene(Scene scene)
        {
            ICamera camera = _cameraController.GetCamera();
            return _renderEngine.RenderScene(scene, camera);
        }
        public void SetRenderingType(RenderingType renderType)
        {
            switch (renderType)
            {
                case RenderingType.Edges:
                    if (_renderEngine is not EdgesRendering)
                        _renderEngine = new EdgesRendering(windowWidth, windowHeight);
                    break;

                case RenderingType.ObjectColor:
                    if (_renderEngine is not ObjectColorRendering)
                        _renderEngine = new ObjectColorRendering(windowWidth, windowHeight);
                    break;

                case RenderingType.PhongShading:
                    if (_renderEngine is not PhongRendering)
                        _renderEngine = new PhongRendering(windowWidth, windowHeight);
                    break;

                default:
                    throw new Exception("Unknown rendering type");
            }
        }
    }
}
