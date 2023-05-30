using _3D_graphics.Controller.Rendering.RenderingEngines.TrianglesFilling;
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
                IColorCalculator colorCalculator = new ConstColorCalculator(model);

                foreach (Triangle triangle in model.triangles)
                {
                    algorithm.DrawTriangle(triangle, colorCalculator);
                }
            }

            return _canvas;
        }


        private readonly struct ConstColorCalculator : IColorCalculator
        {
            private readonly Color _color;

            public ConstColorCalculator(RenderObject renderObject)
            {
                _color = renderObject.color;
            }

            public Color GetColor(Vector3 worldCoordinates)
                => _color;

            public void SetActualTriangle(Triangle worldTriangle) { }
        }
    }
}
