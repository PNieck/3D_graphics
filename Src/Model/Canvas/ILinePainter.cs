namespace _3D_graphics.Model.Canvas
{
    public interface ILinePainter : IDisposable
    {
        public void DrawLine(Pen pen, float x1, float y1, float x2, float y2);

        public void DrawProjectedLine(Pen pen, float x1, float y1, float x2, float y2);

        public void Clear(Color color);
    }
}
