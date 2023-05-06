using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Model
{
    public class RenderObject
    {
        public Mesh mesh { get; }
        public Color color {get; set;}

        public IEnumerable<Triangle> triangles
        { get { return mesh.triangles; } }
        

        public RenderObject(Mesh mesh, Color objColor)
        {
            this.mesh = mesh;
            this.color = objColor;
        }

        public RenderObject(RenderObject renderObject): this(renderObject.mesh, renderObject.color) { }

        public void Scale(float ratio)
        {
            mesh.Scale(ratio);
        }
    }
}
