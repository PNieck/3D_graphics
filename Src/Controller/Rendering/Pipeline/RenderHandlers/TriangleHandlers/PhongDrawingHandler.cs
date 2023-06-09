﻿using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ColorCalculators;
using _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.ShadingAlgorithms;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers
{
    public class PhongDrawingHandler : TriangleFillingHandler
    {
        PhongModel phongColorCalculator;

        public PhongDrawingHandler() :
            base(new PhongShading(new PhongModel()))
        {
            phongColorCalculator = (PhongModel)this.shading.colorCalculator;
        }

        protected override void Action(TriangleHandlerContext context)
        {
            phongColorCalculator.SetCamera(context.Camera);
            phongColorCalculator.SetLightSources(context.Scene.lights);

            base.Action(context);
        }
    }
}
