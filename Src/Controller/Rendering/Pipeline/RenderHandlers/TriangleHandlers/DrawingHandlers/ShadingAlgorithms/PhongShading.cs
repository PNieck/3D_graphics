// Ignore Spelling: Phong

using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms
{
    public class PhongShading : InterpolationBasedShading
    {
        public PhongShading(ColorCalculator colorCalculator) : base(colorCalculator)
        { }

        public override Color GetColor(Vector3 worldCoordinates)
        {
            (float coeff1, float coeff2, float coeff3) = InterpolationCoefficients(worldCoordinates);

            Vector3 interpolatedNormal = coeff1 * actTriangle.v1.normal +
                                         coeff2 * actTriangle.v2.normal +
                                         coeff3 * actTriangle.v3.normal;

            return colorCalculator.GetColor(new Vertex(worldCoordinates, interpolatedNormal));
        }
    }
}
