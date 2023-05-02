using System.Numerics;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Model
{
    public class RenderObject
    {
        private Mesh mesh;
        private Color color;
        private Matrix4x4 objectMatrix;

        public RenderObject(Mesh mesh, Color objColor)
        {
            this.mesh = mesh;
            this.color = objColor;
        }
    }
}
