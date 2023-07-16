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
            var painter = context.DrawingBuffer.GetPainter();
            painter.Fill(backgroundColor);

            InvokeNextHandler(context);
        }
    }
}
