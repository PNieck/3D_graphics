using _3D_graphics.Model;
using _3D_graphics.Model.Primitives;
using _3D_graphics.Model.SourceOfLight;
using System.Numerics;

namespace _3D_graphics.Controller.SceneInit
{
    public class InitSceneController
    {
        private ObjParser _objParser;

        public InitSceneController()
        {
            _objParser = new ObjParser();
        }

        public Scene GetScene()
        {
            var renderObjects = GetBackgroundObjects();
            var car = GetCarObject();
            var lights = new List<ISourceOfLight>();
            var sun = new Sun(new Vector3(0, 100, 400));

            return new Scene(renderObjects, lights, car, sun);
        }

        public IEnumerable<RenderObject> GetBackgroundObjects()
        {
            LinkedList<RenderObject> list = new LinkedList<RenderObject>();

            RenderObject plane = ParseFromResources(Models.Plane, Color.Green, "Plane");
            plane.Scale(200);
            list.AddLast(plane);

            return list;
        }

        public Car GetCarObject()
        {
            Car car = new Car(ParseFromResources(Models.Car, Color.Blue, "Car"));
            car.Scale(100);
            car.RotateAroundZ(Angle.FromDegrees(180));
            car.MoveByVector(new Vector3(0, 0, 50));
            return car;
        }

        private RenderObject ParseFromResources(byte[] resources, Color color, string name)
        {
            Stream stream = new MemoryStream(resources);
            IEnumerable<Mesh> mesh = _objParser.Parse(stream);

            if (mesh.Count() != 1)
                throw new FileFormatException("Invalid obj file");

            return new RenderObject(mesh.First(), color, name);
        }
    }
}
