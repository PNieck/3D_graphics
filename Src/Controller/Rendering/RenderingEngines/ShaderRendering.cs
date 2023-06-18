using _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms;
using _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public abstract class ShaderRendering : RenderingEngine
    {
        private ZBuffer _buffer;
        protected Shading shading;

        protected ShaderRendering(int width, int height, Shading shading) : base(width, height)
        {
            _buffer = new ZBuffer(_canvas);
            this.shading = shading;
        }

        public override Canvas RenderScene(Scene scene, ICamera camera)
        {
            IPixelPainterWithBuffer painter = _buffer.GetPainter();
            ScanLineAlgorithm algorithm = new ScanLineAlgorithm(_buffer, camera, shading);

            painter.Clear(Background);

            foreach (var model in scene.renderObjects)
            {
                shading.SetBaseColor(model.color);

                foreach (Triangle triangle in model.triangles)
                {
                    algorithm.DrawTriangle(triangle);
                }
            }

            return _canvas;
        }
    }
}
