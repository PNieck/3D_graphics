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
            using (ILinePainter sp = _canvas.GetEdgePainter())
            {
                sp.Clear(Background);

                foreach(var model in scene.renderObjects)
                {
                    foreach(Triangle triangle in model.triangles)
                    {
                        Vector3 v1 = camera.Project(triangle.v1.coordinates);
                        Vector3 v2 = camera.Project(triangle.v2.coordinates);
                        Vector3 v3 = camera.Project(triangle.v3.coordinates);

                        DrawEdge(v1, v2, sp);
                        DrawEdge(v2, v3, sp);
                        DrawEdge(v3, v1, sp);
                    }
                }
            }

            return _canvas;
        }

        private static void DrawEdge(Vector3 v1, Vector3 v2, ILinePainter sp) =>
            sp.DrawLine(pen, v1.X, v1.Y, v2.X, v2.Y);
    }
}
