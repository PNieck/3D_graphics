using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Model
{
    public class RenderObject
    {
        public Mesh mesh { get; }
        public Color color {get; set;}
        public string name { get;}

        public IEnumerable<Triangle> triangles
        { get { return mesh.triangles; } }
        

        public RenderObject(Mesh mesh, Color color, string name)
        {
            this.mesh = mesh;
            this.color = color;
            this.name = name;
        }

        public RenderObject(RenderObject renderObject):
            this(renderObject.mesh, renderObject.color, renderObject.name) { }

        public void Scale(float ratio)
        {
            mesh.Scale(ratio);
        }

        public override string ToString()
        {
            return $"{name} render object";
        }
    }
}
