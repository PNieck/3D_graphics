using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline
{
    public class RenderingPipelineFactory
    {
        private ZBuffer zBuffer;

        public RenderingPipelineFactory(int canvasWidth, int canvasHeight)
        {
            var canvas = new Canvas(canvasWidth, canvasHeight);
            zBuffer = new ZBuffer(canvas);
        }


        public RenderingPipeline GetPipeline(RenderingType renderType)
        {
            var sceneToObject = new SceneToObjectHandler();
            var objectToTriangle = new ObjectToTriangleHandler();

            sceneToObject.SetNextHandler(objectToTriangle);

            switch (renderType)
            {
                case RenderingType.Edges:
                    var edgesDrawing = new EdgesDrawingHandler(Pens.Black);
                    objectToTriangle.SetNextHandler(edgesDrawing);
                    break;

                case RenderingType.ObjectColor:
                    var objectsDrawing = new ObjectColorDrawingHandler();
                    objectToTriangle.SetNextHandler(objectsDrawing);
                    break;

                case RenderingType.PhongShading:
                    var phongDrawing = new PhongDrawingHandler();
                    objectToTriangle.SetNextHandler(phongDrawing);
                    break;

                default:
                    throw new Exception("Unknown render type");
            }

            return new RenderingPipeline(zBuffer, sceneToObject);
        }
    }
}
