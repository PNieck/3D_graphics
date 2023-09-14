using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers.ColorCalculators
{
    public class PhongModelWithFog: PhongModel
    {
        public float fogLevel;

        public override Color GetColor(Vertex worldCoordinates)
        {
            if (fogLevel <= 0)
                return base.GetColor(worldCoordinates);

            Color baseColor = base.GetColor(worldCoordinates);

            float dist = Vector3.Distance(camera.Position, worldCoordinates.coordinates);

            int offset = (int)(dist / 2.5f * fogLevel);


            return Color.FromArgb(
                Math.Min(baseColor.R + offset, 255),
                Math.Min(baseColor.G + offset, 255),
                Math.Min(baseColor.B + offset, 255)
            );
        }
    }
}
