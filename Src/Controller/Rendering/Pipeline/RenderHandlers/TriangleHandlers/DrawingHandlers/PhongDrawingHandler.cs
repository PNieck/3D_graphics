using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
{
    public class PhongDrawingHandler : PhongColorBasedDrawing
    {
        public PhongDrawingHandler() :
            base(new PhongShading(new PhongModel()))
        { }
    }
}
