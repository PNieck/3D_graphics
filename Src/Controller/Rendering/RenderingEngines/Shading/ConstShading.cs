using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.Shading
{
    public class ConstShading : IShading
    {
        private IColorCalculator colorCalculator;
        private Color color;

        public ConstShading(IColorCalculator colorCalculator)
        {
            this.colorCalculator = colorCalculator;
            color = Color.Black;
        }
            

        public Color GetColor(Vertex worldCoordinates)
            => color;

        public void SetTriangle(Triangle triangle)
        {
            color = colorCalculator.GetColor(GetMiddleOfTriangle(triangle));
        }

        public void SetColorCalculator(IColorCalculator colorCalculator)
        {
            this.colorCalculator = colorCalculator;
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
