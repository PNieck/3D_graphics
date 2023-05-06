using _3D_graphics.Model;
using _3D_graphics.Model.Primitives;
using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics.Controller.SceneInit
{
    public class InitSceneContoller
    {
        private ObjParser _objParser;

        public InitSceneContoller()
        {
            _objParser = new ObjParser();
        }

        public Scene GetScene()
        {
            var renderObjects = GetBackgroundObjects();
            var car = GetCarObject();
            var lights = new List<ISourceOfLight>();

            return new Scene(renderObjects, lights, car);
        }

        public IEnumerable<RenderObject> GetBackgroundObjects()
        {
            LinkedList<RenderObject> list = new LinkedList<RenderObject>();

            RenderObject plane = ParseFromResources(Models.Plane, Color.Green);
            plane.Scale(200);
            list.AddLast(plane);

            return list;
        }

        public Car GetCarObject()
        {
            Car car = new Car(ParseFromResources(Models.Car, Color.Blue));
            car.Scale(100);
            return car;
        }

        private RenderObject ParseFromResources(byte[] resources, Color color)
        {
            Stream stream = new MemoryStream(resources);
            IEnumerable<Mesh> mesh = _objParser.Parse(stream);

            if (mesh.Count() != 1)
                throw new FileFormatException("Invalid obj file");

            return new RenderObject(mesh.First(), color);
        }
    }
}
