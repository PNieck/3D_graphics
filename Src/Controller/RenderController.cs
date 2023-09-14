using _3D_graphics.Controller.Rendering;
using _3D_graphics.Controller.Rendering.Pipeline;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using System.Timers;

namespace _3D_graphics.Controller
{
    public delegate void RenderFinished(Bitmap screen);
    public delegate void SceneFPSHandler(double fpsCnt);

    public enum RenderingType
    {
        Edges,
        ObjectColor,
        PhongShading,
        GouraudShading
    }

    public enum CameraType
    {
        Static,
        TPP,
        CarFollowing
    }

    public class RenderController
    {
        private SceneController sceneController;
        private readonly CameraController _cameraController;
        private RenderingPipeline _pipeline;
        private readonly RenderingPipelineFactory _pipelineFactory;
        private bool timerIsOn;

        private event RenderFinished? renderFinished;

        private System.Timers.Timer renderTimer;

        public bool CarShakingStatus { get { return _pipelineFactory.CarShaking; } }

        public RenderController(int windowWidth, int windowHeight, SceneController sceneController)
        {
            this.sceneController = sceneController;
            _cameraController = new CameraController(sceneController.scene.car, windowWidth, windowHeight);

            _pipelineFactory = new RenderingPipelineFactory(windowWidth, windowHeight);
            _pipeline = _pipelineFactory.GetPipeline();

            renderTimer = new System.Timers.Timer();
            renderTimer.Enabled = false;
            renderTimer.Interval = 10;
            renderTimer.Elapsed += OnTimedEvent;
            renderTimer.AutoReset = false;

            timerIsOn = false;
        }

        public void AddRenderObserver(RenderFinished handler)
            => renderFinished += handler;

        public void RenderScene()
        {
            if (!timerIsOn)
                Render();
        }

        public void SetRenderingType(RenderingType renderType)
        {
            _pipelineFactory.RenderingType = renderType;
            _pipeline = _pipelineFactory.GetPipeline();
        }

        public void SetCameraType(CameraType type)
            => _cameraController.SetCameraType(type);

        public void AddFpsHandler(SceneFPSHandler handler)
        {
            _pipelineFactory.AddFpsHandler(handler);
            _pipeline = _pipelineFactory.GetPipeline();
        }

        public void AddCarShaking()
        {
            _pipelineFactory.AddCarShaking();
            _pipeline = _pipelineFactory.GetPipeline();

            timerIsOn = true;
            renderTimer.Start();
        }

        public void RemoveCarShaking()
        {
            _pipelineFactory.RemoveCarShaking();
            _pipeline = _pipelineFactory.GetPipeline();

            timerIsOn = false;
            renderTimer.Stop();
        }


        private void Render()
        {
            Bitmap canvas;

            lock (sceneController.scene)
            {
            ICamera camera = _cameraController.GetCamera();
            canvas = _pipeline.RenderScene(sceneController.scene, camera);
            }

            renderFinished?.Invoke(canvas);
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
                Render();
                
            if (timerIsOn) renderTimer.Start();
        }
    }
}
