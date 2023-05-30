using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling
{
    public interface IColorCalculator
    {
        public void SetActualTriangle(Triangle worldTriangle);

        Color GetColor(Vector3 worldCoordinates);
    }
}
