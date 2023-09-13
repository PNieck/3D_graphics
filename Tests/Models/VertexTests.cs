using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace Tests.Models
{
    public class VertexTests
    {
        [Theory]
        [MemberData(nameof(VertexDataGenerator))]
        public void SimpleVertexTransformation(Vertex v)
        {
            Matrix4x4 M = Matrix4x4.CreateTranslation(Vector3.Zero);

            Vertex result = v.Transform(M);

            Assert.True(EqualVertex(v, result));
        }

        public static bool EqualVertex(Vertex expected, Vertex actual)
        {
            return expected.coordinates.Equals(actual.coordinates) &&
                   expected.normal.Equals(actual.normal);
        }

        public static IEnumerable<object[]> VertexDataGenerator() =>
            new List<object[]>
            {
                new object[] { new Vertex(1, 0, 0, 1, 0, 0) },
                new object[] { new Vertex(0, 1, 0, 1, 0, 0) },
                new object[] { new Vertex(0, 0, 1, 1, 0, 0) },
                new object[] { new Vertex(1, 2, 3, 1, 5, 8) }
            };
    }
}
