using _3D_graphics.Model.Canvas;
using System.Drawing;

namespace Tests.Models
{
    public class CanvasTests
    {
        [Theory]
        [InlineData(401, 201, -200, 200, -100, 100)]
        [InlineData(100, 100, -50, 49, -49, 50)]
        public void CanvasSizes(int width, int height, int expMinX, int expMaxX, int expMinY, int expMaxY)
        {
            using Canvas canvas = new Canvas(width, height);

            Assert.Equal(width, canvas.Width);
            Assert.Equal(height, canvas.Height);

            Assert.Equal(expMinX, canvas.MinX);
            Assert.Equal(expMaxX, canvas.MaxX);

            Assert.Equal(expMinY, canvas.MinY);
            Assert.Equal(expMaxY, canvas.MaxY);
        }

        [Theory]
        [InlineData(201, 101)]
        [InlineData(200, 100)]
        public void PixelPainterSizesWholeCanvas(int canvasWidth, int canvasHeight)
        {
            using Canvas canvas = new Canvas(canvasWidth, canvasHeight);
            var wholeCanvas = new CanvasPart(canvas.MinX, canvas.MaxY, canvas.Width, canvas.Height);

            using var painter = canvas.GetPixelPainter(wholeCanvas);

            Assert.Equal(canvas.MinX, painter.MinX);
            Assert.Equal(canvas.MinY, painter.MinY);
            Assert.Equal(canvas.MaxX, painter.MaxX);
            Assert.Equal(canvas.MaxY, painter.MaxY);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(300, 300)]
        public void FillWholeCanvas(int canvasWidth, int canvasHeight)
        {
            var testingColor = Color.FromArgb(5, 10, 15);

            using var canvas = new Canvas(canvasWidth, canvasHeight);
            var wholeCanvas = new CanvasPart(canvas.MinX, canvas.MaxY, canvas.Width, canvas.Height);

            using var painter = canvas.GetPixelPainter(wholeCanvas);

            painter.Fill(testingColor);

            for (int x = painter.MinX; x <= painter.MaxX; x++)
            {
                for (int y = painter.MinY; y <= painter.MaxY; y++)
                {
                    Assert.Equal(testingColor, painter.GetPixel(x, y, out _));
                }
            }
        }
    }
}
