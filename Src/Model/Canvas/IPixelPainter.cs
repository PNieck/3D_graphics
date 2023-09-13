namespace _3D_graphics.Model.Canvas
{
    public interface IPixelPainter: IDisposable
    {
        public int MinX { get; }
        public int MaxX { get; }
        public int MinY { get; }
        public int MaxY { get; }

        public bool IsEmpty { get; }

        public void SetPixel(int x, int y, float z, Color color);

        public Color GetPixel(int x, int y, out float z);

        public bool Contains(int x, int y);

        public bool IsOnTop(int x, int y, float z);

        public void Fill(Color color, float z = 0);
    }
}
