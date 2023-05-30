namespace _3D_graphics.Model.Canvas
{
    public interface IPixelPainterWithBuffer : IPixelPainter
    {
        public bool ShouldDraw(int x, int y, float z);

        public void SetPixel(int x, int y, float z, Color color);
    }
}
