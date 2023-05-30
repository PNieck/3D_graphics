using _3D_graphics.Model.Primitives;
using System.Collections;

namespace Tests.Controllers.ScanLineAlgorithmTests
{
    public class TrivialTrianglesCases : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            /* Single Triangle */
            new Triangle[]
            { 
                new Triangle(
                    new Vertex(-20, -10, 5),
                    new Vertex(-40, 20, 5),
                    new Vertex(30, 25, 5))
            },

            /* Two contacting triangles */
            new Triangle[]
            {
                new Triangle(
                    new Vertex(-20, -10, 5),
                    new Vertex(-40, 0, 5),
                    new Vertex(30, 15, 5)),
                new Triangle(
                    new Vertex(-30, 40, 5),
                    new Vertex(-40, 0, 5),
                    new Vertex(30, 15, 5))
            },

            /* Square made out of two triangles */
            new Triangle[]
            {
                new Triangle(
                    new Vertex(-25, 25, 5),
                    new Vertex(25, 25, 5),
                    new Vertex(-25, -25, 5)),
                new Triangle(
                    new Vertex(-25, -25, 5),
                    new Vertex(25, 25, 5),
                    new Vertex(25, -25, 5)),
            },

            /* Square made out of four triangles */
            new Triangle[]
            {
                new Triangle(
                    new Vertex(-25, 25, 5),
                    new Vertex(25, 25, 5),
                    new Vertex(0, 0, 5)),
                new Triangle(
                    new Vertex(25, 25, 5),
                    new Vertex(25, -25, 5),
                    new Vertex(0, 0, 5)),
                new Triangle(
                    new Vertex(0, 0, 5),
                    new Vertex(25, -25, 5),
                    new Vertex(-25, -25, 5)),
                new Triangle(
                    new Vertex(-25, -25, 5),
                    new Vertex(-25, 25, 5),
                    new Vertex(0, 0, 5)),
            },

            /* Nearly flat top triangle */
            new Triangle[]
            {
                new Triangle(
                    new Vertex(-20, -10, 5),
                    new Vertex(-40, 20, 5),
                    new Vertex(30, 20.01f, 5)),
            },

            /* Nearly flat bottom triangle */
            new Triangle[]
            {
                new Triangle(
                    new Vertex(-20, -10, 5),
                    new Vertex(-40, 20, 5),
                    new Vertex(30, -10.01f, 5)),
            },
            
        };

        public IEnumerator<object[]> GetEnumerator()
            => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
