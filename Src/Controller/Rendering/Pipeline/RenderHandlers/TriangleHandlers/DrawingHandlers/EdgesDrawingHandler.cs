using _3D_graphics.Model.Canvas;
using System.Numerics;

//namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers.DrawingHandlers
//{
//    public class EdgesDrawingHandler : RenderHandler<TriangleHandlerContext>
//    {
//        private readonly Pen pen;

//        public EdgesDrawingHandler(Pen pen)
//        {
//            this.pen = pen;
//        }

//        public override void Handle(TriangleHandlerContext context)
//        {
//            ILinePainter lp = context.Canvas.GetEdgePainter();

//            Vector3 v1 = context.Camera.Project(context.Triangle.v1.coordinates);
//            Vector3 v2 = context.Camera.Project(context.Triangle.v2.coordinates);
//            Vector3 v3 = context.Camera.Project(context.Triangle.v3.coordinates);

//            DrawEdge(v1, v2, lp);
//            DrawEdge(v1, v3, lp);
//            DrawEdge(v2, v3, lp);

//            InvokeNextHandler(context);
//        }

//        private void DrawEdge(Vector3 v1, Vector3 v2, ILinePainter lp) =>
//            lp.DrawLine(pen, v1.X, v1.Y, v2.X, v2.Y);
//    }
//}
