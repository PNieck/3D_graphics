using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class SceneToObjectHandler : IRenderHandler<SceneHandlerContext>
    {
        private IRenderHandler<ObjectHandlerContext>? nextHandler;

        public SceneToObjectHandler()
            => nextHandler = null;

        public void SetNextHandler(IRenderHandler<ObjectHandlerContext> handler)
            => nextHandler = handler;

        public void Handle(SceneHandlerContext context)
        {
            if (nextHandler == null)
                return;

            foreach (var renderObject in context.Scene.renderObjects)
            {
                var newContext = new ObjectHandlerContext(context, renderObject);
                nextHandler.Handle(newContext);
            }
        }
    }
}
