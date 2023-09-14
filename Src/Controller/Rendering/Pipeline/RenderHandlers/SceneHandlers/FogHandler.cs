namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class FogHandler : RenderHandler<SceneHandlerContext>
    {
        private const float fogDelta = 0.01f;

        public override void Handle(SceneHandlerContext context)
        {
            switch (context.Scene.FogStatus)
            {
                case Model.FogStatus.NotChanging:
                    break;

                case Model.FogStatus.GettingStronger:
                    if (context.Scene.FogLevel >= 1.0f)
                    {
                        context.Scene.FogStatus = Model.FogStatus.NotChanging;
                        context.Scene.FogLevel = 1.0f;
                    }
                    else
                        context.Scene.FogLevel += fogDelta;
                    break;

                case Model.FogStatus.GettingWeaker:
                    if (context.Scene.FogLevel <= 0.0f)
                    {
                        context.Scene.FogStatus = Model.FogStatus.NotChanging;
                        context.Scene.FogLevel = 0.0f;
                    }
                    else
                        context.Scene.FogLevel -= fogDelta;
                    break;

                default:
                    throw new Exception("Unknown day status");
            }

            InvokeNextHandler(context);
        }
    }
}
