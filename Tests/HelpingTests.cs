using System.Numerics;

namespace Tests
{
    public class HelpingTests
    {
        [Fact]
        public void Vector3TransformTheSameWayAsVector4()
        {
            Vector3 v3 = new Vector3(1, 2, 3);
            Vector4 v4 = new Vector4(v3, 1);

            Matrix4x4 matrix = Matrix4x4.CreateTranslation(5, 4, 3) * Matrix4x4.CreateRotationY(10);

            Vector3 v3_result = Vector3.Transform(v3, matrix);
            Vector4 v4_result = Vector4.Transform(v4, matrix);

            Assert.Equal(1, v4_result.W);
            Assert.Equal(v4_result.X, v3_result.X);
            Assert.Equal(v4_result.Y, v3_result.Y);
            Assert.Equal(v4_result.Z, v3_result.Z);
        }
    }
}
