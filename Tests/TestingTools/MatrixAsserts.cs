using System.Numerics;

namespace Tests.TestingTools
{
    public static class MatrixAssert
    {
        public static void WithIn(Matrix4x4 expected, Matrix4x4 actual, float tolerance)
        {
            Assert.Equal(expected.M11, actual.M11, tolerance);
            Assert.Equal(expected.M12, actual.M12, tolerance);
            Assert.Equal(expected.M13, actual.M13, tolerance);
            Assert.Equal(expected.M14, actual.M14, tolerance);

            Assert.Equal(expected.M21, actual.M21, tolerance);
            Assert.Equal(expected.M22, actual.M22, tolerance);
            Assert.Equal(expected.M23, actual.M23, tolerance);
            Assert.Equal(expected.M24, actual.M24, tolerance);

            Assert.Equal(expected.M31, actual.M31, tolerance);
            Assert.Equal(expected.M32, actual.M32, tolerance);
            Assert.Equal(expected.M33, actual.M33, tolerance);
            Assert.Equal(expected.M34, actual.M34, tolerance);

            Assert.Equal(expected.M41, actual.M41, tolerance);
            Assert.Equal(expected.M42, actual.M42, tolerance);
            Assert.Equal(expected.M43, actual.M43, tolerance);
            Assert.Equal(expected.M44, actual.M44, tolerance);
        }
    }
}
