using _3D_graphics.Model;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.SceneInit
{
    public class InitSceneContoller
    {
        private ObjParser _objParser;

        public InitSceneContoller()
        {
            _objParser = new ObjParser();
        }

        public IEnumerable<RenderObject> GetBackgroundObjects()
        {
            LinkedList<RenderObject> list = new LinkedList<RenderObject>();

            list.AddLast(ParseFromResource(Models.Plane, Color.Green));

            return list;
        }

        public Car GetCar()
        {
            return Car(ParseFromResource(Models.Car, Color.Blue));
        }

        private RenderObject ParseFromResource(byte[] resources, Color color)
        {
            Stream stream = new MemoryStream(Models.Plane);
            IEnumerable<Mesh> mesh = _objParser.Parse(stream);

            if (mesh.Count() != 1)
                throw new FileFormatException("Invalid obj file");

            return new RenderObject(mesh.First(), color);
        }
    }
}
