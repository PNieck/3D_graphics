using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public class Spotlight : Light, ISourceOfLight
    {
        protected Vector3 lightingDirection;
        private readonly float focus;

        public Spotlight(Vector3 coordinates, Vector3 lightingDirection, float focus, Color lightColor) :
            base(coordinates, lightColor)
        {
            this.lightingDirection = Vector3.Normalize(lightingDirection);
            this.focus = focus;
        }

        public override Color GetColor(Vector3 coordinates)
            => GetColorRatios(coordinates).GetColor();

        public override ColorRatios GetColorRatios(Vector3 coordinates)
        {
            Vector3 toTarget = Vector3.Normalize(Coordinates - coordinates);
            float tmp = Vector3.Dot(-lightingDirection, toTarget);

            if (tmp <= 0)
                return new ColorRatios(Color.Black);

            return colorRatios * MathF.Pow(tmp, focus);
        }
    }
}
