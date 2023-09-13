using _3D_graphics.Model.Canvas;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class StaticBackgroundSetter : RenderHandler<SceneHandlerContext>
    {
        private readonly Color backgroundColor;

        public StaticBackgroundSetter(Color background)
        {
            backgroundColor = background;
        }

        public override void Handle(SceneHandlerContext context)
        {
            var canvasPart = new CanvasPart(
                context.Canvas.MinX,
                context.Canvas.MaxY,
                context.Canvas.Width,
                context.Canvas.Height
            );

            using (var painter = context.Canvas.GetPixelPainter(canvasPart))
            {
                painter.Fill(backgroundColor, float.MaxValue);
            }

            InvokeNextHandler(context);
        }
    }
}
