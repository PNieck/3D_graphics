namespace _3D_graphics.Model.Canvas
{
    public interface IPixelPainter
    {
        public void SetPixel(int x, int y, Color color);

        public Color GetPixel(int x, int y);

        public void Fill(Color color);

        public void Clear();
    }
}
