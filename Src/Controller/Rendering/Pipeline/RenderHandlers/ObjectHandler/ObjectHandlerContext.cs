using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers;
using _3D_graphics.Model;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler
{
    public class ObjectHandlerContext : SceneHandlerContext
    {
        public RenderObject RenderObject { get; set; }

        public ObjectHandlerContext(SceneHandlerContext sceneHandlerContext, RenderObject renderObject) :
            base(sceneHandlerContext)
        {
            RenderObject = renderObject;
        }

        public ObjectHandlerContext(ObjectHandlerContext objectHandler) :
            this(objectHandler, objectHandler.RenderObject)
        { }
    }
}
