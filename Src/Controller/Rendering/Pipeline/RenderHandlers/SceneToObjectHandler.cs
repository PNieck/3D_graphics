using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class SceneToObjectHandler : IRenderHandler<SceneHandlerContext>
    {


        public IRenderHandler<ObjectHandlerContext> NextHandler { get; set; }

        public SceneToObjectHandler()
            => NextHandler = NullRenderHandler<ObjectHandlerContext>.GetInstance();

        public void Handle(SceneHandlerContext context)
        {
            foreach (var renderObject in context.Scene.renderObjects)
            {
                var newContext = new ObjectHandlerContext(context, renderObject);
                NextHandler.Handle(newContext);
            }
        }
    }
}
