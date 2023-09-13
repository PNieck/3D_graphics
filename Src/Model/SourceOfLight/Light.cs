using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public abstract class Light: ISourceOfLight
    {
        protected Color color;
        protected ColorRatios colorRatios;

        public Vector3 Coordinates { get; protected set; }

        public Light(Vector3 coordinates, Color lightColor)
        {
            Coordinates = coordinates;
            color = lightColor;
            colorRatios = new ColorRatios(lightColor);
        }

        public abstract Color GetColor(Vector3 coordinates);

        public abstract ColorRatios GetColorRatios(Vector3 coordinates);
    }
}
