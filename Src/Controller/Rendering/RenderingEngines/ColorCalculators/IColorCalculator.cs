using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators
{
    public interface IColorCalculator
    {
        Color GetColor(Vertex worldCoordinates);
    }
}
