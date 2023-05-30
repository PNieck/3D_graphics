using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.Shading
{
    public interface IShading: IColorCalculator
    {
        public void SetColorCalculator(IColorCalculator colorCalculator);

        public void SetTriangle(Triangle triangle);
    }
}
