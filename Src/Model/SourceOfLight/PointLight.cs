using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public class PointLight : Light, ISourceOfLight
    {
        public PointLight(Vector3 coordinates, Color lightColor):
            base(coordinates, lightColor)
        {}

        public PointLight(Vector3 coordinates): this(coordinates, Color.White) { }

        public override Color GetColor(Vector3 coordinates)
            => color;

        public override ColorRatios GetColorRatios(Vector3 coordinates)
            => colorRatios;
    }
}
