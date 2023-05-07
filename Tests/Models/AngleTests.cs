using _3D_graphics.Model.Primitives;

namespace Tests.Models
{
    public class AngleTests
    {
        [Theory]
        [MemberData(nameof(AngleDataGenerator))]
        public void CorrectConversionFromDegreesToDegrees(float angleInDegrees, float angleInRadians)
        {
            Angle angle = Angle.FromDegrees(angleInDegrees);

            Assert.Equal(angleInDegrees, angle.Degrees);
        }

        [Theory]
        [MemberData(nameof(AngleDataGenerator))]
        public void CorrectConversionFromRadiansToRadians(float angleInDegrees, float angleInRadians)
        {
            Angle angle = Angle.FromRadians(angleInRadians);

            Assert.Equal(angleInRadians, angle.Radians);
        }

        [Theory]
        [MemberData(nameof(AngleDataGenerator))]
        public void CorrectConversionFromRadiansToDegrees(float angleInDegrees, float angleInRadians)
        {
            Angle angle = Angle.FromRadians(angleInRadians);

            Assert.Equal(angleInDegrees, angle.Degrees);
        }

        [Theory]
        [MemberData(nameof(AngleDataGenerator))]
        public void CorrectConversionFromDegreesToRadians(float angleInDegrees, float angleInRadians)
        {
            Angle angle = Angle.FromDegrees(angleInDegrees);

            Assert.Equal(angleInRadians, angle.Radians);
        }

        [Theory]
        [MemberData(nameof(AngleDataGenerator))]
        public void UnaryMinusTests(float angleInDegrees, float angleInRadians)
        {
            Angle angle = Angle.FromDegrees(angleInDegrees);
            angle = -angle;

            Assert.Equal(-angleInDegrees, angle.Degrees);
        }


        public static IEnumerable<object[]> AngleDataGenerator() =>
            new List<object[]>
            {
                new object[] { 0, 0 },
                new object[] { 45, MathF.PI / 4.0f },
                new object[] { 90, MathF.PI / 2.0f },
                new object[] { 180, MathF.PI },
                new object[] { 360, MathF.PI * 2.0f },
                new object[] { 10, 0.1745329252f },
                new object[] { -157, -2.7401669256f }
            };
    }
}
