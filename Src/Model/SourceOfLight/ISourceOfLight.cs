using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public interface ISourceOfLight
    {
        float GetIntensivity(Vector3 coordinates);
    }
}
