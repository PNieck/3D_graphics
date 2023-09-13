using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class SceneHandlerContext
    {
        public Scene Scene { get; }
        public ICamera Camera { get; }
        public Canvas Canvas { get; }

        public SceneHandlerContext(Scene scene, ICamera camera, Canvas canvas)
        {
            Scene = scene;
            Camera = camera;
            Canvas = canvas;
        }

        public SceneHandlerContext(SceneHandlerContext sceneContext) :
            this(sceneContext.Scene, sceneContext.Camera, sceneContext.Canvas)
        { }
    }
}
