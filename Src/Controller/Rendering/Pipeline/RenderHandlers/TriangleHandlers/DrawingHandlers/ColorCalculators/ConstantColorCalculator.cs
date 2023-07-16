using _3D_graphics.Model;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators
{
    public class ConstColorCalculator : ColorCalculator
    {
        public ConstColorCalculator(RenderObject renderObject) :
            base(renderObject.color)
        { }

        public ConstColorCalculator(Color color) : base(color)
        { }

        public override Color GetColor(Vertex worldCoordinates)
            => baseColor;
    }
}
