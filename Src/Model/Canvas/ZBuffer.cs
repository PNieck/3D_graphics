namespace _3D_graphics.Model.Canvas
{
    public class ZBuffer
    {
        private readonly float[,] zbuffer;
        public Canvas Canvas { get; private set; }

        public ZBuffer(Canvas canvas)
        {
            zbuffer = new float[canvas.Width, canvas.Height];
            Canvas = canvas;
        }

        /* TODO: don't create new item */
        public IZBufferedPixelPainter GetPainter()
            => new ZBufferPainter(Canvas.GetPixelPainter(), zbuffer);

        public ILinePainter GetEdgePainter()
            => Canvas.GetEdgePainter();


        private class ZBufferPainter : IZBufferedPixelPainter
        {
            private readonly float[,] zBuffer;
            private readonly IPixelPainter screenPainter;

            private int xChange { get { return zBuffer.GetLength(0) / 2; } }
            private int yChange { get { return zBuffer.GetLength(1) / 2; } }

            public ZBufferPainter(IPixelPainter painter, float[,] zBuffer)
            {
                this.zBuffer = zBuffer;
                screenPainter = painter;
            }

            public void Clear()
            {
                screenPainter.Clear();

                for (int row = 0; row < zBuffer.GetLength(0); row++)
                {
                    for (int col = 0; col < zBuffer.GetLength(1); col++)
                    {
                        zBuffer[row, col] = float.PositiveInfinity;
                    }
                }
            }

            public void Fill(Color color)
                => screenPainter.Fill(color);

            public void SetPixel(int x, int y, Color color)
            {
                int actX = RecalculateX(x);
                int actY = RecalculateY(y);

                if (CoordinatesInRange(actX, actY))
                {
                    screenPainter.SetPixel(x, y, color);
                    zBuffer[actX, actY] = 0;
                }
            }

            public void SetPixel(int x, int y, float z, Color color)
            {
                screenPainter.SetPixel(x, y, color);
                zBuffer[RecalculateX(x), RecalculateY(y)] = z;
            }

            public Color GetPixel(int x, int y)
                => screenPainter.GetPixel(x, y);

            public bool ShouldDraw(int x, int y, float z)
            {
                int actX = RecalculateX(x);
                int actY = RecalculateY(y);

                if (!CoordinatesInRange(actX, actY))
                    return false;

                return zBuffer[actX, actY] > z;
            }


            private int RecalculateX(int x)
                => x + xChange;

            private int RecalculateY(int y)
                => yChange - y;

            private bool CoordinatesInRange(int actX, int actY)
                => actX > 0 && actX < zBuffer.GetLength(0) &&
                   actY > 0 && actY < zBuffer.GetLength(1);
        }
    }

    
}
