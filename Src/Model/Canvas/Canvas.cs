using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace _3D_graphics.Model.Canvas
{
    public class Canvas: IDisposable
    {
        private readonly BitmapCartesianConverter converter;

        private Int32[] bits;
        private bool Disposed;
        private GCHandle bitsHandle;

        private readonly float[,] zbuffer;

        private readonly HashSet<CanvasPixelPainter> painters;

        public Bitmap Bitmap { get; private set; }

        public int Width { get {  return Bitmap.Width; } }
        public int Height { get { return Bitmap.Height; } }

        public int MinX { get { return converter.FromBitmapX(0); } }
        public int MaxX { get { return converter.FromBitmapX(Width - 1); } }

        public int MinY { get { return converter.FromBitmapY(Height - 1); } }
        public int MaxY { get { return converter.FromBitmapY(0); } }

        public Canvas(int width, int height)
        {
            bits = new Int32[width * height];
            bitsHandle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, bitsHandle.AddrOfPinnedObject());
;
            converter = new BitmapCartesianConverter(width, height);
            zbuffer = new float[width, height];

            painters = new HashSet<CanvasPixelPainter>();
        }

        public IPixelPainter GetPixelPainter(CanvasPart part)
        {
            CanvasPixelPainter result;

            lock(painters)
            {
                while (!ResourceAvailable(part))
                    Monitor.Wait(painters);

                result = new CanvasPixelPainter(this, part);
                painters.Add(result);
            }

            return result;
        }

        private bool ResourceAvailable(CanvasPart part)
        {
            foreach (var painter in painters)
            {
                if (painter.UsedPart.IntersectsWith(part))
                    return false;
            }

            return true;
        }

        public Bitmap GetSnapshot()
        {
            Bitmap result;

            lock (painters)
            {
                if (painters.Count != 0)
                    throw new Exception("Trying to get image with active painters");

                result = (Bitmap)Bitmap.Clone();
            }

            return result;
        }

        public void ResetZValues()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    zbuffer[x, y] = float.MaxValue;
                }
            }
        }

        private void DisposePainter(CanvasPixelPainter painter)
        {           
            lock(painters)
            {
                painters.Remove(painter);
                Monitor.PulseAll(painters);
            }
        }

        public void Dispose()
        {
            if (Disposed)
                return;

            lock(painters)
            {
                if (painters.Count > 0)
                    throw new Exception("Trying to dispose image with active painters");

                Disposed = true;
                Bitmap.Dispose();
                bitsHandle.Free();
            }
        }

        private class CanvasPixelPainter : IPixelPainter
        {
            private readonly Canvas canvas;
            public readonly CanvasPart UsedPart;

            public int MinX => UsedPart.Left;
            public int MaxX => UsedPart.Right;
            public int MinY => UsedPart.Bottom;
            public int MaxY => UsedPart.Top;

            public bool IsEmpty => UsedPart.IsEmpty;

            public CanvasPixelPainter(Canvas canvas, CanvasPart part)
            {
                this.canvas = canvas;

                var wholeCanvas = new CanvasPart(canvas.MinX, canvas.MaxY, canvas.Width, canvas.Height);
                UsedPart = wholeCanvas.Intersect(part);
            }

            public void Dispose()
            {
                canvas.DisposePainter(this);
            }

            public void SetPixel(int x, int y, float z, Color color)
            {
                (int bitmapX, int bitmapY) = canvas.converter.FromCartesian(x, y);

                int index = bitmapX + (bitmapY * canvas.Width);
                int col = color.ToArgb();

                canvas.bits[index] = col;

                canvas.zbuffer[bitmapX, bitmapY] = z;
            }

            public Color GetPixel(int x, int y, out float z)
            {
                (int bitmapX, int bitmapY) = canvas.converter.FromCartesian(x, y);

                int index = bitmapX + (bitmapY * canvas.Width);
                int col = canvas.bits[index];
                Color result = Color.FromArgb(col);

                z = canvas.zbuffer[bitmapX, bitmapY];

                return result;
            }

            public bool IsOnTop(int x, int y, float z)
            {
                (int bitmapX, int bitmapY) = canvas.converter.FromCartesian(x, y);

                return canvas.zbuffer[bitmapX, bitmapY] > z;
            }

            public void Fill(Color color, float z = 0)
            {
                // ToDo: Try parallel for

                for (int x = MinX; x <= MaxX; x++)
                {
                    for (int y = MinY; y <= MaxY; y++)
                    {
                        SetPixel(x, y, z, color);
                    }
                }
            }

            public bool Contains(int x, int y)
                => UsedPart.Contains(x, y);
        }
    }
}
