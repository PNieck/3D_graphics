using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public class ObjectColorRendering : ShaderRendering
    {
        public ObjectColorRendering(int width, int height) :
            base(width, height, new ConstShading(new ConstColorCalculator(Color.Black)))
        { }
    }
}
