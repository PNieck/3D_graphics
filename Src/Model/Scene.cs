using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics.Model
{
    public enum DayStatus { GettingDarker, GettintBrighter, NotChanging };

    public class Scene
    {
        List<RenderObject> _renderObjects;  // Including the car
        public Car car { get; }
        public Sun Sun { get; }
        List<ISourceOfLight> _lights;

        public IReadOnlyList<RenderObject> renderObjects { get { return _renderObjects.AsReadOnly(); } }
        public IReadOnlyList<ISourceOfLight> lights { get { return _lights.AsReadOnly(); } }

        public DayStatus DayStatus { get; set;  }
        public float TimeOfDay { get; set; }

        public Scene(IEnumerable<RenderObject> renderObjects, IEnumerable<ISourceOfLight> lights, Car car, Sun sun)
        {
            _renderObjects = new List<RenderObject>(renderObjects);
            this.car = car;
            _lights = new List<ISourceOfLight>(lights);

            if (!_renderObjects.Contains(this.car))
                _renderObjects.Insert(0, this.car);

            if (!_lights.Contains(car.Light))
                _lights.Add(car.Light);

            if (!_lights.Contains(sun))
                _lights.Add(sun);

            TimeOfDay = 0.0f;
            DayStatus = DayStatus.GettingDarker;
            Sun = sun;
        }
    }
}
