using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class DayNightBackgroundSetter : RenderHandler<SceneHandlerContext>
    {
        private const double Hue = 186;
        private const double Saturation = 1.0;

        private HsvColor converter;

        public DayNightBackgroundSetter()
        {
            converter = new HsvColor();
        }

        public override void Handle(SceneHandlerContext context)
        {
            double Value = 1.0 - context.Scene.TimeOfDay;

            converter.HsvToRgb(Hue, Saturation, Value, out int R, out int G, out int B);

            Color color = Color.FromArgb(R, G, B);

            var canvasPart = new CanvasPart(
                context.Canvas.MinX,
                context.Canvas.MaxY,
                context.Canvas.Width,
                context.Canvas.Height
            );

            using (var painter = context.Canvas.GetPixelPainter(canvasPart))
            {
                painter.Fill(color, float.MaxValue);
            }

            InvokeNextHandler(context);
        }
    }
}
