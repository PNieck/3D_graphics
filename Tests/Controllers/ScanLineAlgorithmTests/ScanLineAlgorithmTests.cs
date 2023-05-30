using _3D_graphics.Controller.Rendering.RenderingEngines.Utils;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Collections.Specialized;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using Tests.TestingTools;

namespace Tests.Controllers.ScanLineAlgorithmTests
{
    public class ScanLineAlgorithmTests
    {
        private const int CANVAS_WIDTH = 100;
        private const int CANVAS_HEIGTH = 100;
        private static readonly Color TESTING_COLOR = Color.FromArgb(0, 0, 0);
        private static readonly Color TESTING_BACKGROUND = Color.FromArgb(255, 255, 255);

        private ScanLineAlgorithm algorithm;
        private Canvas canvas;

        public ScanLineAlgorithmTests()
        {
            canvas = new Canvas(CANVAS_WIDTH, CANVAS_HEIGTH);
            var zBuffer = new ZBuffer(canvas);
            algorithm = new ScanLineAlgorithm(zBuffer, new ConstantCamera());
        }

        [Theory]
        [ClassData(typeof(TrivialTrianglesCases))]
        public void SimpleTrianglesDrawingTest(params Triangle[] triangles)
        {
            var painter = canvas.GetPixelPainter();
            painter.Clear(TESTING_BACKGROUND);

            foreach (Triangle triangle in triangles)
            {
                algorithm.DrawTriangle(triangle, ColorCalculator);
            }

            Box boxWithTriangles = BoundingBox.Calculate(triangles);
            boxWithTriangles.Inflate(1);

            foreach(var pixel in CanvasPixels())
            {
                if (boxWithTriangles.Contains(pixel.x, pixel.y))
                    continue;

                Assert.Equal(TESTING_BACKGROUND, painter.GetPixel(pixel.x, pixel.y));
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
                algorithm.DrawTriangle(triangle, ColorCalculator);
            }

            AssertCanvas(triangles);
        }


        private Color ColorCalculator(Vector3 coordinates)
        => TESTING_COLOR;

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
