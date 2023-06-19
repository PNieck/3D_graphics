using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public class PointLight : ISourceOfLight
    {
        private Color color;
        private ColorRatios colorRatios;

        public Vector3 Coordinates { get; set; }

        public PointLight(Vector3 coordinates, Color lightColor)
        {
            Coordinates = coordinates;
            color = lightColor;
            colorRatios = new ColorRatios(lightColor);
        }

        public PointLight(Vector3 coordinates): this(coordinates, Color.White) { }

        public Color GetColor(Vector3 coordinates)
            => color;

        public ColorRatios GetColorRatios(Vector3 coordinates)
            => colorRatios;
    }
}
