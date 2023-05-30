using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Controller.Rendering.RenderingEngines.Shading;
using _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public class ObjectColorRendering : RenderingEngine
    {
        private ZBuffer _buffer;
        private ConstShading shading;

        public ObjectColorRendering(int width, int height) : base(width, height)
        {
            _buffer = new ZBuffer(_canvas);
            shading = new ConstShading(new ConstColorCalculator(Color.Black));
        }

        public override Canvas RenderScene(Scene scene, ICamera camera)
        {
            Matrix4x4 cameraMatrix = camera.GetCameraMatrix();
            IPixelPainterWithBuffer painter = _buffer.GetPainter();
            ScanLineAlgorithm algorithm = new ScanLineAlgorithm(_buffer, camera, shading);

            painter.Clear(Background);

            foreach (var model in scene.renderObjects)
            {
                shading.SetColorCalculator(new ConstColorCalculator(model));

                foreach (Triangle triangle in model.triangles)
                {
                    algorithm.DrawTriangle(triangle);
                }
            }

            return _canvas;
        }


        
    }
}
