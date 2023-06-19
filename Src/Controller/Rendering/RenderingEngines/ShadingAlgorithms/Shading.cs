﻿using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms
{
    public abstract class Shading
    {
        public ColorCalculator colorCalculator;

        protected Shading(ColorCalculator colorCalculator)
        {
            this.colorCalculator = colorCalculator;
        }

        public abstract Color GetColor(Vector3 worldCoordinates);

        public abstract void SetTriangle(Triangle triangle);

        public void SetBaseColor(Color color)
            => colorCalculator.SetBaseColor(color);
    }
}
