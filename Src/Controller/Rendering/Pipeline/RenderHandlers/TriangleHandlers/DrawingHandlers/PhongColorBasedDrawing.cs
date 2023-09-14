using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
{
    public abstract class PhongColorBasedDrawing : TriangleFillingHandler
    {
        PhongModelWithFog phongColorCalculator;

        protected PhongColorBasedDrawing(Shading shading) : base(shading)
        {
            if (this.shading.colorCalculator is not PhongModelWithFog)
                this.shading.colorCalculator = new PhongModelWithFog();

            phongColorCalculator = (PhongModelWithFog)this.shading.colorCalculator;
        }

        public override void Handle(TriangleHandlerContext context)
        {
            phongColorCalculator.SetCamera(context.Camera);
            phongColorCalculator.SetLightSources(context.Scene.lights);
            phongColorCalculator.fogLevel = context.Scene.FogLevel;

            base.Handle(context);
        }
    }
}
