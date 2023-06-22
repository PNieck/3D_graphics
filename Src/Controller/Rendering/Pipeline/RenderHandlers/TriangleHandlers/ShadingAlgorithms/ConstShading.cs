using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ShadingAlgorithms
{
    public class ConstShading : Shading
    {
        private Color color;

        public ConstShading(ColorCalculator colorCalculator) : base(colorCalculator)
        {
            color = Color.Black;
        }


        public override Color GetColor(Vector3 worldCoordinates)
            => color;

        public override void SetTriangle(Triangle triangle)
        {
            color = colorCalculator.GetColor(GetMiddleOfTriangle(triangle));
        }


        private static Vertex GetMiddleOfTriangle(Triangle triangle)
            => new Vertex(MeanVector(triangle.v1.coordinates,
                           triangle.v2.coordinates,
                           triangle.v3.coordinates),
                          MeanVector(triangle.v1.normal,
                           triangle.v2.normal,
                           triangle.v3.normal));

        private static Vector3 MeanVector(Vector3 v1, Vector3 v2, Vector3 v3)
            => (v1 + v2 + v3) / 3;
    }
}
