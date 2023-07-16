using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
{
    public class GouraudDrawingHandler : PhongColorBasedDrawing
    {
        public GouraudDrawingHandler():
            base(new GouraudShading(new PhongModel()))
        { }
    }
}
