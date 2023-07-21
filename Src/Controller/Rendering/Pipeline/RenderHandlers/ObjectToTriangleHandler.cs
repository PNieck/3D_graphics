using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class ObjectToTriangleHandler : IRenderHandler<ObjectHandlerContext>
    {
        public IRenderHandler<TriangleHandlerContext> NextHandler { get; set; }

        public ObjectToTriangleHandler()
            => NextHandler = NullRenderHandler<TriangleHandlerContext>.GetInstance();

        public void Handle(ObjectHandlerContext context)
        {
            foreach (var triangle in context.RenderObject.triangles)
            {
                var newContext = new TriangleHandlerContext(context, triangle);
                NextHandler.Handle(newContext);
            }
        }
    }
}
