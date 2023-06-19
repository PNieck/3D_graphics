namespace _3D_graphics.Model.Canvas
{
    public class ZBuffer
    {
        private float[,] zbuffer;
        private Canvas canvas;

        public ZBuffer(Canvas canvas)
        {
            zbuffer = new float[canvas.Width, canvas.Height];
            this.canvas = canvas;
        }

        /* TODO: don't create new item */
        public IPixelPainterWithBuffer GetPainter()
            => new ZBufferPainter(canvas.GetPixelPainter(), zbuffer);


        private class ZBufferPainter : IPixelPainterWithBuffer
        {
            private float[,] zBuffer;
            private IPixelPainter screenPainter;

            private int xChange { get { return zBuffer.GetLength(0) / 2; } }
            private int yChange { get { return zBuffer.GetLength(1) / 2; } }

            public ZBufferPainter(IPixelPainter painter, float[,] zBuffer)
            {
                this.zBuffer = zBuffer;
                screenPainter = painter;
            }

            public void Clear(Color color)
            {
                screenPainter.Clear(color);

                for (int row = 0; row < zBuffer.GetLength(0); row++)
                {
                    for (int col = 0; col < zBuffer.GetLength(1); col++)
                    {
                        zBuffer[row, col] = float.PositiveInfinity;
                    }
                }
            }

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

            public bool ShouldDrawProjected(float x, float y, float z)
                => ShouldDraw(UnprojectX(x), UnprojectY(y), z);

            public void SetPixelProjected(float x, float y, float z, Color color)
                => SetPixel(UnprojectX(x), UnprojectY(y), z, color);


            private int RecalculateX(int x)
                => x + xChange;

            private int RecalculateY(int y)
                => yChange - y;

            private int UnprojectX(float x)
                => (int)MathF.Round(x * xChange);

            private int UnprojectY(float y)
                => (int)MathF.Round(y * yChange);

            private bool CoordinatesInRange(int actX, int actY)
                => actX > 0 && actX < zBuffer.GetLength(0) &&
                   actY > 0 && actY < zBuffer.GetLength(1);
        }
    }

    
}
