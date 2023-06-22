using _3D_graphics.Controller.Rendering.Pipeline;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering
{
    public class RenderController
    {
        private readonly CameraController _cameraController;
        private RenderingPipeline _pipeline;

        private readonly RenderingPipelineFactory _pipelineFactory;

        private readonly int windowWidth;
        private readonly int windowHeight;

        public CameraController Camera { get { return _cameraController; } }

        public RenderController(int windowWidth, int windowHeight, Car car)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;

            _cameraController = new CameraController(car, windowWidth, windowHeight);
            
            _pipelineFactory = new RenderingPipelineFactory(windowWidth, windowHeight);
            _pipeline = _pipelineFactory.GetPipeline(RenderingType.PhongShading);
        }

        public Canvas RenderScene(Scene scene)
        {
            ICamera camera = _cameraController.GetCamera();
            return _pipeline.RenderScene(scene, camera);
        }
        public void SetRenderingType(RenderingType renderType)
        {
            _pipeline = _pipelineFactory.GetPipeline(renderType);
        }
    }
}
