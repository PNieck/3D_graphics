using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class SceneHandlerContext
    {
        public Scene Scene { get; }
        public ICamera Camera { get; }
        public ZBuffer DrawingBuffer { get; }

        public SceneHandlerContext(Scene scene, ICamera camera, ZBuffer drawingBuffer)
        {
            Scene = scene;
            Camera = camera;
            DrawingBuffer = drawingBuffer;
        }

        public SceneHandlerContext(SceneHandlerContext sceneContext) :
            this(sceneContext.Scene, sceneContext.Camera, sceneContext.DrawingBuffer)
        { }
    }
}
