using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.ObjectHandler;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers
{
    public class TriangleHandlerContext : ObjectHandlerContext
    {
        public Triangle Triangle { get; set; }

        public TriangleHandlerContext(ObjectHandlerContext objectContext, Triangle triangle) :
            base(objectContext)
        {
            Triangle = triangle;
        }
    }
}
