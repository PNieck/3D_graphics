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

        public override Canvas RednerScene(Scene scene, ICamera camera)
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

            //using (ILinePainter sp = _canvas.GetEdgePainter())
            //{
            //    foreach (var model in scene.renderObjects)
            //    {
            //        foreach (Triangle triangle in model.triangles)
            //        {
            //            Vertex v1 = triangle.v1.Tranform(cameraMatrix);
            //            Vertex v2 = triangle.v2.Tranform(cameraMatrix);
            //            Vertex v3 = triangle.v3.Tranform(cameraMatrix);

            //            DrawEdge(v1, v2, sp);
            //            DrawEdge(v2, v3, sp);
            //            DrawEdge(v3, v1, sp);
            //        }
            //    }
            //}

            return _canvas;
        }

        private Color CalculateColor(Vector3 coordinates)
            => Color.Orange;

        // TODO: remove
        private void DrawEdge(Vertex v1, Vertex v2, ILinePainter sp) =>
            sp.DrawLine(Pens.Black, v1.x, v1.y, v2.x, v2.y);
    }
}
