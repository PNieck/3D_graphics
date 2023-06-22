namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class StaticBackgroundSetter : RenderHandler<SceneHandlerContext>
    {
        private readonly Color backgroundColor;

        public StaticBackgroundSetter(Color background)
        {
            backgroundColor = background;
        }

        protected override void Action(SceneHandlerContext context)
        {
            var painter = context.DrawingBuffer.GetPainter();
            painter.Fill(backgroundColor);
        }
    }
}
