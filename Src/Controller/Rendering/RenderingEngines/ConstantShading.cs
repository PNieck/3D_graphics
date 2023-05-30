using _3D_graphics.Controller.Rendering.RenderingEngines.Utils;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public class ConstantShading : RenderingEngine
    {
        private ZBuffer _buffer;

        public ConstantShading(int width, int height) : base(width, height)
        {
            _buffer = new ZBuffer(_canvas);
        }

        public override Canvas RenderScene(Scene scene, ICamera camera)
        {
            Matrix4x4 cameraMatrix = camera.GetCameraMatrix();
            IPixelPainterWithBuffer painter = _buffer.GetPainter();
            ScanLineAlgorithm algorithm = new ScanLineAlgorithm(_buffer, camera);

            painter.Clear(Background);

            foreach (var model in scene.renderObjects)
            {
                foreach (Triangle triangle in model.triangles)
                {
                    algorithm.DrawTriangle(triangle, CalculateColor);
                }
            }

            return _canvas;
        }

        private Color CalculateColor(Vector3 coordinates)
            => Color.Orange;
    }
}
