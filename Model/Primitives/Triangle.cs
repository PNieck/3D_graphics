namespace _3D_graphics.Model.Primitives
{
    public class Triangle
    {
        private Vertex _v1;
        private Vertex _v2;
        private Vertex _v3;

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            _v1 = v1;
            _v2 = v2;
            _v3 = v3;
        }
    }
}
