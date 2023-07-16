using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ShadingAlgorithms
{
    public abstract class InterpolationBasedShading : Shading
    {
        protected Triangle actTriangle;

        public InterpolationBasedShading(ColorCalculator colorCalculator) : base(colorCalculator)
        { }

        public override void SetTriangle(Triangle triangle)
            => actTriangle = triangle;


        protected (float v1, float v2, float v3) InterpolationCoefficients(Vector3 worldCoordinates)
        {
            float coeff1 = TriangleArea(actTriangle.v2.coordinates,
                                        actTriangle.v3.coordinates,
                                        worldCoordinates);

            float coeff2 = TriangleArea(actTriangle.v1.coordinates,
                                        actTriangle.v3.coordinates,
                                        worldCoordinates);

            float coeff3 = TriangleArea(actTriangle.v1.coordinates,
                                        actTriangle.v2.coordinates,
                                        worldCoordinates);

            float sum = coeff1 + coeff2 + coeff3;

            // Normalization
            coeff1 /= sum;
            coeff2 /= sum;
            coeff3 /= sum;

            return (coeff1, coeff2, coeff3);
        }

        private static float TriangleArea(Vector3 v1, Vector3 v2, Vector3 v3)
            => Vector3.Cross(v1 - v3, v2 - v3).Length();
    }
}
