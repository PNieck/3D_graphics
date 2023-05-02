namespace _3D_graphics.Model
{
    public class Mesh
    {
        private List<Point> points;

        public Mesh(IEnumerable<Point> points)
        {
            this.points = new List<Point>(points);
        }
    }
}
