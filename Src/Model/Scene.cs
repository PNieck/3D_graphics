﻿using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics.Model
{
    public class Scene
    {
        List<RenderObject> _renderObjects;  // Including the car
        public Car car { get; }
        List<ISourceOfLight> _lights;

        public IReadOnlyList<RenderObject> renderObjects { get { return _renderObjects; } }


        public Scene(IEnumerable<RenderObject> renderObjects, IEnumerable<ISourceOfLight> lights, Car car)
        {
            _renderObjects = new List<RenderObject>(renderObjects);
            this.car = car;
            _lights = new List<ISourceOfLight>(lights);

            if (!_renderObjects.Contains(this.car))
            {
                _renderObjects.Add(this.car);
            }
        }
    }
}