using _3D_graphics.Model;
using _3D_graphics.Model.Camera;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public abstract class BaseRenderingEngine
    {
        protected static readonly Color Background = Color.White;
        
        protected Canvas _screen;

        public BaseRenderingEngine(int width, int height)
        {
            _screen = new Canvas(width, height);
        }

        public abstract Canvas RednerScene(Scene scene, ICamera camera);
    }
}
