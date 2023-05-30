using _3D_graphics.Model.Primitives;
using System.Drawing;
using Tests.TestingTools;

namespace Tests
{
    public class TestingToolsTests
    {
        [Fact]
        public void BoundingBoxForSingleTriangle()
        {
            Triangle triangle = new Triangle(
                new Vertex(15, 19, 40),
                new Vertex(7, 20, 30),
                new Vertex(-5, -10, 25));

            Box box = BoundingBox.Calculate(triangle);

            Assert.Equal(20, box.Top);
            Assert.Equal(-10, box.Bottom);
            Assert.Equal(-5, box.Left);
            Assert.Equal(15, box.Right);

            Assert.Equal(20, box.Width);
            Assert.Equal(30, box.Height);
        }

        [Fact]
        public void BoundingBoxForMultipleTriangles()
        {
            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle(
                    new Vertex(15,  19, 40),
                    new Vertex( 7,  20, 30),
                    new Vertex(-5, -10, 25)),
                new Triangle(
                    new Vertex(-10, 20, 5),
                    new Vertex(  0,  0, 0),
                    new Vertex( 10, 10, 0)),
            };

            Box box = BoundingBox.Calculate(triangles);

            Assert.Equal(20, box.Top);
            Assert.Equal(-10, box.Bottom);
            Assert.Equal(-10, box.Left);
            Assert.Equal(15, box.Right);
        }
    }
}
