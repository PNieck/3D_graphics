using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers
{
    public class ObjectColorDrawingHandler : TriangleFillingHandler
    {
        private static readonly Color DEAFULT_COLOR = Color.Orange;

        public ObjectColorDrawingHandler():
            base(new ConstShading(new ConstColorCalculator(DEAFULT_COLOR)))
        {
        }
    }
}
