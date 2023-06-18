using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms;
using _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Drawing;
using Tests.TestingTools;

namespace Tests.Controllers.ScanLineAlgorithmTests
{
    public class ScanLineAlgorithmTests
    {
        private const int CANVAS_WIDTH = 100;
        private const int CANVAS_HEIGTH = 100;
        private static readonly Color TESTING_COLOR = Color.FromArgb(0, 0, 0);
        private static readonly Color TESTING_BACKGROUND = Color.FromArgb(255, 255, 255);

        private readonly ScanLineAlgorithm algorithm;
        private readonly Canvas canvas;
        private readonly Shading shading;

        public ScanLineAlgorithmTests()
        {
            canvas = new Canvas(CANVAS_WIDTH, CANVAS_HEIGTH);
            var zBuffer = new ZBuffer(canvas);
            shading = new ConstShading(new ConstColorCalculator(TESTING_COLOR));
            algorithm = new ScanLineAlgorithm(zBuffer, new ConstantCamera(), shading);
        }

        [Theory]
        [ClassData(typeof(TrivialTrianglesCases))]
        public void SimpleTrianglesDrawingTest(params Triangle[] triangles)
        {
            var painter = canvas.GetPixelPainter();
            painter.Clear(TESTING_BACKGROUND);

            foreach (Triangle triangle in triangles)
            {
                algorithm.DrawTriangle(triangle);
            }

            Box boxWithTriangles = BoundingBox.Calculate(triangles);
            boxWithTriangles.Inflate(1);

            foreach(var (x, y) in CanvasPixels())
            {
                if (boxWithTriangles.Contains(x, y))
                    continue;

                Assert.Equal(TESTING_BACKGROUND, painter.GetPixel(x, y));
            }
        }

        [Theory(Skip = "No good enough results testing method")]
        [ClassData(typeof(TrivialTrianglesCases))]
        public void TrianglesDrawingTest(params Triangle[] triangles)
        {
            var painter = canvas.GetPixelPainter();
            painter.Clear(TESTING_BACKGROUND);

            foreach (Triangle triangle in triangles)
            {
                algorithm.DrawTriangle(triangle);
            }

            AssertCanvas(triangles);
        }

        [Fact]
        public void SimpleTriangleCovering()
        {
            Triangle t1 = new Triangle(
                            new Vertex(-20, -10, 5),
                            new Vertex(-40,  20, 5),
                            new Vertex( 30,  25, 5));

            Triangle t2 = new Triangle(
                            new Vertex(-20, -10, 10),
                            new Vertex(-40,  20, 10),
                            new Vertex( 30,  25, 10));

            Color triangleBehindColor = Color.Orange;

            var painter = canvas.GetPixelPainter();
            painter.Clear(TESTING_BACKGROUND);

            algorithm.DrawTriangle(t2);
            shading.SetBaseColor(triangleBehindColor);
            algorithm.DrawTriangle(t1);

            foreach (var (x, y) in CanvasPixels())
                Assert.NotEqual(triangleBehindColor, painter.GetPixel(x, y));

            painter.Clear(TESTING_BACKGROUND);

            shading.SetBaseColor(triangleBehindColor);
            algorithm.DrawTriangle(t1);
            shading.SetBaseColor(TESTING_COLOR);
            algorithm.DrawTriangle(t2);

            foreach (var (x, y) in CanvasPixels())
                Assert.NotEqual(triangleBehindColor, painter.GetPixel(x, y));
        }


        private void AssertCanvas(IEnumerable<Triangle> triangles)
        {
            var painter = canvas.GetPixelPainter();

            foreach (var pixel in CanvasPixels())
            {
                Color pixelColor = painter.GetPixel(pixel.x, pixel.y);

                if (PointInsideTriangle.PointInsideOneOf2DTriangles(pixel.x, pixel.y, triangles))
                    Assert.Equal(TESTING_COLOR, pixelColor);
                else
                    Assert.Equal(TESTING_BACKGROUND, pixelColor);
            }
        }

        IEnumerable<(int x, int y)> CanvasPixels()
        {
            for (int x = -(CANVAS_WIDTH / 2); x < CANVAS_WIDTH / 2; x++)
            {
                for (int y = -(CANVAS_HEIGTH / 2 - 1); y < CANVAS_HEIGTH / 2; y++)
                {
                    yield return (x, y);
                }
            }
        }
    }
}
