namespace _3D_graphics.Model.Canvas
{
    public readonly struct CanvasPart
    {
        private readonly int X;
        private readonly int Y;

        public int Width { get; }
        public int Height { get; }

        public int Left => X;
        public int Right => X + Width - 1;
        public int Top => Y;
        public int Bottom => Y - Height + 1;

        public bool IsEmpty { get; }

        public CanvasPart(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            IsEmpty = false;
        }

        public CanvasPart()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;

            IsEmpty = true;
        }

        public static CanvasPart FromLTRB(int left, int top, int right, int bottom)
            => new CanvasPart(left, top, right - left + 1, top - bottom + 1);

        public bool IntersectsWith(CanvasPart p)
        {
            if (this.IsEmpty || p.IsEmpty)
                return false;

            // If one is on the right side of the other
            if (Right < p.Left || p.Right < Left)
                return false;

            // If one is higher than the other
            if (Top < p.Bottom || p.Top < Bottom)
                return false;

            return true;
        }

        public bool Contains(int x, int y)
        {
            if (x >= Left && x <= Right &&
                y >= Bottom && y <= Top)
                return true;

            return false;
        }

        public CanvasPart Intersect(CanvasPart part)
        {
            if (!IntersectsWith(part))
                return new CanvasPart();

            return CanvasPart.FromLTRB(
                Math.Max(this.Left, part.Left),
                Math.Min(this.Top, part.Top),
                Math.Min(this.Right, part.Right),
                Math.Max(this.Bottom, part.Bottom));
        }
    }
}
