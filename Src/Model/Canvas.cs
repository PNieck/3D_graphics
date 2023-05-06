using System.Windows.Forms;

namespace _3D_graphics.Model
{
    public class Canvas
    {
        private Bitmap _bitmap;

        public Canvas(int  width, int height)
        {
            _bitmap = new Bitmap(width, height);
        }

        public ScreenPainter GetScreenPainter() => new ScreenPainterImplem(_bitmap);

        public void Apply(PictureBox pictureBox)
        {
            pictureBox.Image = _bitmap;
            pictureBox.Refresh();
        }

        private class ScreenPainterImplem : ScreenPainter
        {
            private Graphics _graphics;
            private readonly float _xChange;
            private readonly float _yChange;

            public ScreenPainterImplem(Bitmap bitmap)
            {
                _graphics = Graphics.FromImage(bitmap);
                _xChange = bitmap.Width / 2;
                _yChange = bitmap.Height / 2;
            }

            public void Clear(Color color) => _graphics.Clear(color);

            public void DrawLine(Pen pen, float x1, float y1, float x2, float y2)
            {
                (float actX1, float actY1) = Recalculate(x1, y1);
                (float actX2, float actY2) = Recalculate(x2, y2);

                _graphics.DrawLine(pen, actX1, actY1, actX2, actY2);
            }

            public void Dispose()
            {
                _graphics.Dispose();
            }


            private (float x, float y) Recalculate(float x, float y)
            {
                return (x + _xChange, _yChange - y);
            }
        }
    }

    public interface ScreenPainter: IDisposable
    {
        public void DrawLine(Pen pen ,float x1, float y1, float x2, float y2);

        public void Clear(Color color);
    }
}
