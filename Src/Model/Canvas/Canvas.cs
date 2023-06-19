using System.Drawing;
using System.Drawing.Printing;

namespace _3D_graphics.Model.Canvas
{
    public class Canvas
    {
        private Bitmap _bitmap;

        public int Width { get { return _bitmap.Width; } }
        public int Height { get { return _bitmap.Height; } }

        public Canvas(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
        }

        /* TODO: don't create new item */
        public IPixelPainter GetPixelPainter() => new CanvasPixelPainter(_bitmap);

        /* TODO: don't create new item */
        public ILinePainter GetEdgePainter() => new CanvasEdgePainter(_bitmap);

        public void Apply(PictureBox pictureBox)
        {
            pictureBox.Image = _bitmap;
            pictureBox.Refresh();
        }

        private class CanvasPixelPainter : IPixelPainter
        {
            private Bitmap _bitmap;
            private int _xChange { get { return _bitmap.Width / 2; } }
            private int _yChange { get { return _bitmap.Height / 2; } }

            public CanvasPixelPainter(Bitmap bitmap)
            {
                _bitmap = bitmap;
            }

            public void Clear(Color color)
            {
                using (Graphics g = Graphics.FromImage(_bitmap))
                {
                    g.Clear(color);
                }
            }

            public void SetPixel(int x, int y, Color color)
            {
                (int actX, int actY) = Recalculate(x, y);

                if (ValidCoordinates(actX, actY))
                {
                    _bitmap.SetPixel(actX, actY, color);
                }
            }

            public Color GetPixel(int x, int y)
            {
                (int actX, int actY) = Recalculate(x, y);

                if (ValidCoordinates(actX, actY))
                {
                    return _bitmap.GetPixel(actX, actY);
                }

                throw new ArgumentException("Indexes out of range");
            }

            private (int x, int y) Recalculate(int x, int y)
                => (x + _xChange, _yChange - y);

            private bool ValidCoordinates(int actX, int actY)
                => actX >= 0 && actX < _bitmap.Width &&
                   actY >= 0 && actY < _bitmap.Height;
        }

        private class CanvasEdgePainter: ILinePainter
        {
            private Graphics _graphics;
            private readonly float _xChange;
            private readonly float _yChange;

            public CanvasEdgePainter(Bitmap bitmap)
            {
                _graphics = Graphics.FromImage(bitmap);
                _xChange = bitmap.Width / 2;
                _yChange = bitmap.Height / 2;
            }

            public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
            {
                (float actX1, float actY1) = Recalculate(x1, y1);
                (float actX2, float actY2) = Recalculate(x2, y2);

                _graphics.DrawLine(pen, actX1, actY1, actX2, actY2);
            }

            public void DrawProjectedLine(Pen pen, float x1, float y1, float x2, float y2)
                => DrawLine(pen, x1 * _xChange, y1 * _yChange, x2 * _xChange, y2 * _yChange);

            public void Clear(Color color)
                => _graphics.Clear(color);

            public void Dispose()
            {
                _graphics.Dispose();
            }

            private (float x, float y) Recalculate(float x, float y)
                => (x + _xChange, _yChange - y);
        }
    }
}
