using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using System.Numerics;
using Tests.TestingTools;

namespace Tests.Models
{
    public class CameraTests
    {
        [Fact]
        public void InverseCameraMatrix()
        {
            ICamera camera = new StaticCamera(
                new Vector3(-20, 0, 150),
                Vector3.Zero,
                120, 100,
                Angle.FromDegrees(100));

            var cameraMatrix = camera.GetCameraMatrix();
            Matrix4x4 inversedMatrix;

            Assert.True(Matrix4x4.Invert(cameraMatrix, out inversedMatrix));
            Matrix4x4 multiplication = cameraMatrix * inversedMatrix;

            MatrixAssert.WithIn(Matrix4x4.Identity, multiplication, 0.001f);
        }

        [Fact]
        public void UnprojectTests()
        {
            ICamera camera = new StaticCamera(
                new Vector3(-20, 0, 150),
                Vector3.Zero,
                120, 100,
                Angle.FromDegrees(100));

            Vector3 position = new Vector3(10, 20, 30);

            var projected = camera.Project(position);
            var unprojected = camera.Unproject(projected);
            

            Assert.Equal((double)position.X, (double)unprojected.X, 3);
            Assert.Equal((double)position.Y, (double)unprojected.Y, 3);
            Assert.Equal((double)position.Z, (double)unprojected.Z, 3);
        }

        [Fact]
        public void Vector3TransformNotAlwayEqualsVector3Transform()
        {
            ICamera camera = new StaticCamera(
                new Vector3(-20, 0, 150),
                Vector3.Zero,
                120, 100,
                Angle.FromDegrees(100));

            var matrix = camera.GetCameraMatrix();

            Vector3 vector3 = new Vector3(10, 20, 30);
            Vector4 vector4 = new Vector4(vector3, 1);

            vector3 = Vector3.Transform(vector3, matrix);
            vector4 = Vector4.Transform(vector4, matrix);

            vector4 /= vector4.W;

            Vector3 fromVector4 = new Vector3(vector4.X, vector4.Y, vector4.Z);

            Assert.NotEqual(vector3, fromVector4);
        }
    }
}
