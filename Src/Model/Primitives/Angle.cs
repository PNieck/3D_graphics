namespace _3D_graphics.Model.Primitives
{
    public struct Angle
    {
        private static float DEG2RAD = 0.0174532925f;
        private static float RAD2DEG = 1 / DEG2RAD;

        private float _degrees;

        public float Degrees { get { return _degrees; } }
        public float Radians { get { return _degrees * DEG2RAD; } }

        private Angle(float value) => _degrees = value;

        public static Angle FromDegrees(float degrees)
            => new Angle(degrees);

        public static Angle FromRadians(float radians)
            => new Angle(radians * RAD2DEG);
    }
}
