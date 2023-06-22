using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class ObjectToTriangleHandler : IRenderHandler<ObjectHandlerContext>
    {
        private IRenderHandler<TriangleHandlerContext>? nextHandler;

        public ObjectToTriangleHandler()
            => nextHandler = null;

        public void SetNextHandler(IRenderHandler<TriangleHandlerContext> handler)
            => nextHandler = handler;

        public void Handle(ObjectHandlerContext context)
        {
            if (nextHandler == null)
                return;

            foreach (var triangle in context.RenderObject.triangles)
            {
                var newContext = new TriangleHandlerContext(context, triangle);
                nextHandler.Handle(newContext);
            }
        }
    }
}
