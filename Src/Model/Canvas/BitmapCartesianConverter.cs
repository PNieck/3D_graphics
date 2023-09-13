using System.Security.Policy;

namespace _3D_graphics.Model.Canvas
{
    public readonly struct BitmapCartesianConverter
    {
        private int XChange { get; }
        private int YChange { get; }

        public BitmapCartesianConverter(int width, int height)
        {
            XChange = width / 2;
            YChange = height / 2;
        }

        public int FromBitmapX(int x)
            => x - XChange;

        public int FromBitmapY(int y)
            => -y + YChange;

        public (int x, int y) FromBitmap(int x, int y)
            => (FromBitmapX(x), FromBitmapY(y));

        public int FromCartesianX(int x)
            => x + XChange;

        public int FromCartesianY(int y)
            => -y + YChange;

        public (int x, int y) FromCartesian(int x, int y)
            => (FromCartesianX(x), FromCartesianY(y));
    }
}
