namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class SunHandler : RenderHandler<SceneHandlerContext>
    {
        public override void Handle(SceneHandlerContext context)
        {
            context.Scene.Sun.SetBrightness(context.Scene.TimeOfDay);

            InvokeNextHandler(context);
        }
    }
}
