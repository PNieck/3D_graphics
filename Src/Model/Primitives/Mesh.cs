namespace _3D_graphics.Model.Primitives
{
    public class Mesh
    {
        private List<Triangle> points;

        public Mesh(IEnumerable<Triangle> triangles)
        {
            this.points = new List<Triangle>(triangles);
        }
    }
}
