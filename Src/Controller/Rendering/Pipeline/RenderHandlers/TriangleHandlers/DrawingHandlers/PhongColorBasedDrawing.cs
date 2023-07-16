using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
{
    public abstract class PhongColorBasedDrawing : TriangleFillingHandler
    {
        PhongModel phongColorCalculator;

        protected PhongColorBasedDrawing(Shading shading) : base(shading)
        {
            if (this.shading.colorCalculator is not PhongModel)
                this.shading.colorCalculator = new PhongModel();

            phongColorCalculator = (PhongModel)this.shading.colorCalculator;
        }

        public override void Handle(TriangleHandlerContext context)
        {
            phongColorCalculator.SetCamera(context.Camera);
            phongColorCalculator.SetLightSources(context.Scene.lights);

            base.Handle(context);
        }
    }
}
