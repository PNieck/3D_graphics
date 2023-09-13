using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline
{
    public class RenderingPipeline
    {
        private readonly IRenderHandler<SceneHandlerContext> renderHandler;
        private readonly Canvas canvas;

        public RenderingPipeline(Canvas drawingBuffer, IRenderHandler<SceneHandlerContext> renderHandler)
        {
            this.renderHandler = renderHandler;
            canvas = drawingBuffer;
        }

        public Canvas RenderScene(Scene scene, ICamera camera)
        {
            var context = new SceneHandlerContext(scene, camera, canvas);

            renderHandler.Handle(context);

            return canvas;
        }
    }
}
