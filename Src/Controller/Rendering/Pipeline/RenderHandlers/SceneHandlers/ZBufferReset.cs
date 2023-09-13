namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class ZBufferReset : RenderHandler<SceneHandlerContext>
    {
        public override void Handle(SceneHandlerContext context)
        {
            context.Canvas.ResetZValues();

            InvokeNextHandler(context);
        }
    }
}
