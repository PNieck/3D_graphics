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
        private readonly ZBuffer drawingBuffer;

        public RenderingPipeline(ZBuffer drawingBuffer, IRenderHandler<SceneHandlerContext> renderHandler)
        {
            this.renderHandler = renderHandler;
            this.drawingBuffer = drawingBuffer;
        }

        public Canvas RenderScene(Scene scene, ICamera camera)
        {
            var context = new SceneHandlerContext(scene, camera, drawingBuffer);

            renderHandler.Handle(context);

            return drawingBuffer.Canvas;
        }
    }
}
