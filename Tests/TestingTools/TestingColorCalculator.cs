using _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling;
using _3D_graphics.Model.Primitives;
using System.Drawing;
using System.Numerics;

namespace Tests.TestingTools
{
    public readonly struct TestingColorCalculator : IColorCalculator
    {
        private readonly Color _color;

        public TestingColorCalculator(Color color)
        {
            _color = color;
        }

        public Color GetColor(Vector3 worldCoordinates)
            => _color;

        public void SetActualTriangle(Triangle worldTriangle) { }
    }
}
