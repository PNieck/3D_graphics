using System.Numerics;

namespace _3D_graphics.Model.Primitives
{
    public readonly struct ColorRatios
    {
        private readonly Vector3 ratios;

        public readonly float RedRatio { get => ratios.X;  }
        public readonly float GreenRatio { get => ratios.Y; }
        public readonly float BlueRatio { get => ratios.Z; }
        

        public ColorRatios(Color color)
        {
            ratios = new Vector3(color.R, color.G, color.B);
            ratios /= byte.MaxValue;
        }

        private ColorRatios(Vector3 ratios)
        {
            this.ratios = ratios;
        }

        public readonly Color GetColor()
        {
            Vector3 colorValues = ratios * byte.MaxValue;

            return Color.FromArgb(
                (int)MathF.Min(colorValues.X, byte.MaxValue),
                (int)MathF.Min(colorValues.Y, byte.MaxValue),
                (int)MathF.Min(colorValues.Z, byte.MaxValue));
        }

        public override string ToString()
            => ratios.ToString();



        public static ColorRatios operator +(ColorRatios cr1, ColorRatios cr2)
            => new ColorRatios(cr1.ratios + cr2.ratios);

        public static ColorRatios operator *(ColorRatios colorRatios, float value)
            => new ColorRatios(colorRatios.ratios * value);

        public static ColorRatios operator *(float value, ColorRatios colorRatios)
            => colorRatios * value;

        public static ColorRatios operator *(ColorRatios cr1, ColorRatios cr2)
            => new ColorRatios(cr1.ratios * cr2.ratios);
    }
}
