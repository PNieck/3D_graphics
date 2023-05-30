using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public class EdgesRendering : RenderingEngine
    {
        private static readonly Pen pen = Pens.Black;

        public EdgesRendering(int width, int height) : base(width, height) { }

        public override Canvas RenderScene(Scene scene, ICamera camera)
        {
            Matrix4x4 cameraMatrix = camera.GetCameraMatrix();

            using (ILinePainter sp = _canvas.GetEdgePainter())
            {
                sp.Clear(Background);

                foreach(var model in scene.renderObjects)
                {
                    foreach(Triangle triangle in model.triangles)
                    {
                        Vertex v1 = triangle.v1.Tranform(cameraMatrix);
                        Vertex v2 = triangle.v2.Tranform(cameraMatrix);
                        Vertex v3 = triangle.v3.Tranform(cameraMatrix);

                        DrawEdge(v1, v2, sp);
                        DrawEdge(v2, v3, sp);
                        DrawEdge(v3, v1, sp);
                    }
                }
            }

            return _canvas;
        }

        private static void DrawEdge(Vertex v1, Vertex v2, ILinePainter sp) =>
            sp.DrawLine(pen, v1.x, v1.y, v2.x, v2.y);
    }
}
