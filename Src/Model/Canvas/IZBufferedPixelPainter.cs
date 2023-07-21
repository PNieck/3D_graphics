namespace _3D_graphics.Model.Canvas
{
    public interface IZBufferedPixelPainter : IPixelPainter
    {
        public bool CanDraw(int x, int y, float z);

        public void SetPixel(int x, int y, float z, Color color);

        public void ResetZValues();
    }
}
