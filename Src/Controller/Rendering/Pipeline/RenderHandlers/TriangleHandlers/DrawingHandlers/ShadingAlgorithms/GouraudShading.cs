// Ignore Spelling: Gouraud

using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms
{
    public class GouraudShading : InterpolationBasedShading
    {
        private ColorRatios vertex1Color;
        private ColorRatios vertex2Color;
        private ColorRatios vertex3Color;


        public GouraudShading(ColorCalculator colorCalculator) : base(colorCalculator)
        { }

        public override Color GetColor(Vector3 worldCoordinates)
        {
            (float coeff1, float coeff2, float coeff3) = InterpolationCoefficients(worldCoordinates);

            ColorRatios resultRations = coeff1 * vertex1Color +
                                        coeff2 * vertex2Color +
                                        coeff3 * vertex3Color;

            return resultRations.GetColor();
        }

        public override void SetTriangle(Triangle triangle)
        {
            vertex1Color = new ColorRatios(colorCalculator.GetColor(triangle.v1));
            vertex2Color = new ColorRatios(colorCalculator.GetColor(triangle.v2));
            vertex3Color = new ColorRatios(colorCalculator.GetColor(triangle.v3));

            base.SetTriangle(triangle);
        }
    }
}
