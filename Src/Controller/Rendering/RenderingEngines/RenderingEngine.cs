using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public abstract class RenderingEngine
    {
        protected static readonly Color Background = Color.White;
        
        protected Canvas _canvas;

        public RenderingEngine(int width, int height)
        {
            _canvas = new Canvas(width, height);
        }

        public abstract Canvas RenderScene(Scene scene, ICamera camera);
    }
}
