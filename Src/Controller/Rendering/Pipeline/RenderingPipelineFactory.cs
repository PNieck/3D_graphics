using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.Optimizations;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline
{
    public class RenderingPipelineFactory
    {
        private readonly Canvas canvas;
        private readonly HashSet<SceneFPSHandler> fpsHandlers;

        public bool CarShaking { get; private set; }

        public RenderingType RenderingType { get; set; }

        public RenderingPipelineFactory(int canvasWidth, int canvasHeight)
        {
            canvas = new Canvas(canvasWidth, canvasHeight);

            RenderingType = RenderingType.PhongShading;
            fpsHandlers = new HashSet<SceneFPSHandler>();
            CarShaking = false;
        }


        public RenderingPipeline GetPipeline()
        {
            var sceneToObject = new SceneToObjectHandler();
            var objectToTriangle = new ObjectToTriangleHandler();

            (var firstSceneHandler, var lastSceneHandler) = GetScenePipeline();
            (var firstTriangleHandler, _) = GetTrianglePipeline();

            lastSceneHandler.NextHandler = sceneToObject;
            sceneToObject.NextHandler = objectToTriangle;
            objectToTriangle.NextHandler = firstTriangleHandler;

            return new RenderingPipeline(canvas, firstSceneHandler);
        }

        public void AddFpsHandler(SceneFPSHandler handler)
            => fpsHandlers.Add(handler);

        public void RemoveFpsHandler(SceneFPSHandler handler)
            => fpsHandlers.Remove(handler);

        public void AddCarShaking()
            => CarShaking = true;

        public void RemoveCarShaking()
            => CarShaking = false;


        private (RenderHandler<SceneHandlerContext> first, RenderHandler<SceneHandlerContext> last)
            GetScenePipeline()
        {
            RenderHandler<SceneHandlerContext> firstHandler = new StaticBackgroundSetter(Color.White);
            RenderHandler<SceneHandlerContext> lastHandler = firstHandler;

            if (fpsHandlers.Count > 0)
            {
                var fpsHandler = CreateFPSCounter();
                fpsHandler.NextHandler = firstHandler;
                firstHandler = fpsHandler;
            }
            
            if (CarShaking)
            {
                var carShaker = new CarShaker();
                lastHandler.NextHandler = carShaker;
                lastHandler = carShaker;
            }

            return (firstHandler, lastHandler);
        }

        private (RenderHandler<TriangleHandlerContext> first, RenderHandler<TriangleHandlerContext> last)
            GetTrianglePipeline()
        {
            var backFaceCulling = new BackFaceCullingHandler();
            var drawingHandler = GetDrawingHandler();

            backFaceCulling.NextHandler = drawingHandler;

            return (backFaceCulling, drawingHandler);
        }

        private RenderHandler<TriangleHandlerContext> GetDrawingHandler()
        {
            return RenderingType switch
            {
                //RenderingType.Edges => new EdgesDrawingHandler(Pens.Black),
                RenderingType.Edges => new ObjectColorDrawingHandler(),
                RenderingType.ObjectColor => new ObjectColorDrawingHandler(),
                RenderingType.PhongShading => new PhongDrawingHandler(),
                RenderingType.GouraudShading => new GouraudDrawingHandler(),

                _ => throw new Exception("Unknown render type"),
            };
        }

        private FPSCounter CreateFPSCounter()
        {
            var fpsHandler = new FPSCounter(fpsHandlers.First());

            bool first = true;
            foreach (var elem in fpsHandlers)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                fpsHandler.AddObserver(elem);
            }

            return fpsHandler;
        }
    }
}
