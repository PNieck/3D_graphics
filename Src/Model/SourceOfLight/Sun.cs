using System.Numerics;

namespace _3D_graphics.Model.SourceOfLight
{
    public class Sun : PointLight
    {
        public Sun(Vector3 coordinates) : base(coordinates, Color.Blue)
        { }

        public void SetBrightness(float sceneTime)
        {
            float time = MathF.Max(sceneTime, 0.0f);
            time = MathF.Min(time, 1.0f);
            int ration = (int)((1 - time) * 255);
            color = Color.FromArgb(ration, ration, ration);
            colorRatios = new Primitives.ColorRatios(color);
        }
    }
}
