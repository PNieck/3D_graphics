using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public interface ISourceOfLight
    {
        public Vector3 Coordinates { get; }

        public Color GetColor(Vector3 coordinates);

        public ColorRatios GetColorRatios(Vector3 coordinates);
    }
}
