using _3D_graphics.Controller.Rendering.RenderingEngines;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using _3D_graphics.Model.SourceOfLight;
using System.Drawing;
using System.Numerics;

namespace Tests.Controllers.RenderingTests
{
    public class PhongRenderingTests
    {
        [Fact]
        public void RenderSimpleTriangle()
        {
            var scene = GetSceneWithSimpleTriangle();
            var camera = GetCamera();

            var render = new PhongRendering(120, 120);

            var canvas = render.RenderScene(scene, camera);
        }

        private static Scene GetSceneWithSimpleTriangle()
        {
            Mesh mesh = new Mesh(new List<Triangle> { new Triangle(
                    new Vertex(-50, -50, 0),
                    new Vertex(-50,  50, 0),
                    new Vertex( 50,  50, 0)) });

            Car car = new Car(new RenderObject(mesh, Color.Orange, "Single triangle"));

            var lights = new List<ISourceOfLight> { new PointLight(new Vector3(0, 0, 100)) };

            return new Scene(new List<RenderObject>(), lights, car);
        }

        private static ICamera GetCamera()
            => new StaticCamera(new Vector3(-5, 0, 50), Vector3.Zero, 120, 120, Angle.FromDegrees(100));
    }
}
