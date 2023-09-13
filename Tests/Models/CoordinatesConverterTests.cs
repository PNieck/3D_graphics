using _3D_graphics.Model.Canvas;
using System.Drawing;

namespace Tests.Models
{
    public class CoordinatesConverterTests
    {
        [Theory]
        [MemberData(nameof(PointsDataGenerator))]
        public void FromBitmapToCartesianTest(int coordWeight, int coordHeight, Point bitmapPoint, Point cartesianPoint)
        {
            var converter = new BitmapCartesianConverter(coordWeight, coordHeight);

            (int x, int y) = converter.FromBitmap(bitmapPoint.X, bitmapPoint.Y);

            Assert.Equal(x, cartesianPoint.X);
            Assert.Equal(y, cartesianPoint.Y);
        }

        [Theory]
        [MemberData(nameof(PointsDataGenerator))]
        public void FromCartesianToBitmapTest(int coordWeight, int coordHeight, Point bitmapPoint, Point cartesianPoint)
        {
            var converter = new BitmapCartesianConverter(coordWeight, coordHeight);

            (int x, int y) = converter.FromCartesian(cartesianPoint.X, cartesianPoint.Y);

            Assert.Equal(x, bitmapPoint.X);
            Assert.Equal(y, bitmapPoint.Y);
        }

        public static IEnumerable<object[]> PointsDataGenerator() =>
            new List<object[]>
            {
                /* width: 4 height: 3 coordinate system */
                new object[] {4, 3, new Point(0, 0), new Point(-2,  1)  },
                new object[] {4, 3, new Point(1, 0), new Point(-1,  1)  },
                new object[] {4, 3, new Point(2, 0), new Point( 0,  1)  },
                new object[] {4, 3, new Point(3, 0), new Point( 1,  1)  },
                new object[] {4, 3, new Point(0, 1), new Point(-2,  0)  },
                new object[] {4, 3, new Point(1, 1), new Point(-1,  0)  },
                new object[] {4, 3, new Point(2, 1), new Point( 0,  0)  },
                new object[] {4, 3, new Point(3, 1), new Point( 1,  0)  },
                new object[] {4, 3, new Point(0, 2), new Point(-2, -1)  },
                new object[] {4, 3, new Point(1, 2), new Point(-1, -1)  },
                new object[] {4, 3, new Point(2, 2), new Point( 0, -1)  },
                new object[] {4, 3, new Point(3, 2), new Point( 1, -1)  },

                /* width: 3 height: 4 coordinate system */
                new object[] {3, 4, new Point(0, 0), new Point(-1,  2)  },
                new object[] {3, 4, new Point(1, 0), new Point( 0,  2)  },
                new object[] {3, 4, new Point(2, 0), new Point( 1,  2)  },
                new object[] {3, 4, new Point(0, 1), new Point(-1,  1)  },
                new object[] {3, 4, new Point(1, 1), new Point( 0,  1)  },
                new object[] {3, 4, new Point(2, 1), new Point( 1,  1)  },
                new object[] {3, 4, new Point(0, 2), new Point(-1,  0)  },
                new object[] {3, 4, new Point(1, 2), new Point( 0,  0)  },
                new object[] {3, 4, new Point(2, 2), new Point( 1,  0)  },
                new object[] {3, 4, new Point(0, 3), new Point(-1, -1)  },
                new object[] {3, 4, new Point(1, 3), new Point( 0, -1)  },
                new object[] {3, 4, new Point(2, 3), new Point( 1, -1)  },
            };
    }
}
