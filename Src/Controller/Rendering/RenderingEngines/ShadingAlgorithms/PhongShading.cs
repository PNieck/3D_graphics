// Ignore Spelling: Phong

using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Diagnostics;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms
{
    public class PhongShading : Shading
    {
        Triangle actTriangle;

        public PhongShading(ColorCalculator colorCalculator) : base(colorCalculator)
        { }

        public override Color GetColor(Vector3 worldCoordinates)
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

            Vector3 interpolatedNormal = coeff1 * actTriangle.v1.normal +
                                         coeff2 * actTriangle.v2.normal +
                                         coeff3 * actTriangle.v3.normal;

            return colorCalculator.GetColor(new Vertex(worldCoordinates, interpolatedNormal));
        }

        public override void SetTriangle(Triangle triangle)
            => actTriangle = triangle;

        private static float TriangleArea(Vector3 v1, Vector3 v2, Vector3 v3)
            => Vector3.Cross(v1 - v3, v2 - v3).Length();
    }
}
