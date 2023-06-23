using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ShadingAlgorithms;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.TrianglesFilling;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers
{
    public abstract class TriangleFillingHandler : RenderHandler<TriangleHandlerContext>
    {
        protected readonly Shading shading;


        public TriangleFillingHandler(Shading shading)
        {
            this.shading = shading;
        }

        public override void Handle(TriangleHandlerContext context)
        {
            shading.SetTriangle(context.Triangle);
            shading.SetBaseColor(context.RenderObject.color);

            var algorithm = new ScanLineAlgorithm(context.DrawingBuffer.GetPainter(),
                                                  context.Camera,
                                                  shading);

            algorithm.DrawTriangle(context.Triangle);

            InvokeNextHandler(context);
        }
    }
}
