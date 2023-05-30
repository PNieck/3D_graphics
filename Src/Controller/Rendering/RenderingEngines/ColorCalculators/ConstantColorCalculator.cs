using _3D_graphics.Model;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators
{
    public struct ConstColorCalculator : IColorCalculator
    {
        private readonly Color _color;

        public ConstColorCalculator(RenderObject renderObject):
            this(renderObject.color)
        { }

        public ConstColorCalculator(Color color)
        {
            _color = color;
        }

        public Color GetColor(Vertex worldCoordinates)
            => _color;
    }
}
