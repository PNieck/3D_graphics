using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
{
    public class PhongDrawingHandler : TriangleFillingHandler
    {
        PhongModel phongColorCalculator;

        public PhongDrawingHandler() :
            base(new PhongShading(new PhongModel()))
        {
            phongColorCalculator = (PhongModel)shading.colorCalculator;
        }

        public override void Handle(TriangleHandlerContext context)
        {
            phongColorCalculator.SetCamera(context.Camera);
            phongColorCalculator.SetLightSources(context.Scene.lights);

            base.Handle(context);
        }
    }
}
