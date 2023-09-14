namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class TimeHandler : RenderHandler<SceneHandlerContext>
    {
        private const float timeDelta = 0.01f;

        public override void Handle(SceneHandlerContext context)
        {
            switch (context.Scene.DayStatus)
            {
                case Model.DayStatus.NotChanging:
                    break;

                case Model.DayStatus.GettingDarker:
                    if (context.Scene.TimeOfDay >= 1.0f)
                    {
                        context.Scene.DayStatus = Model.DayStatus.NotChanging;
                        context.Scene.TimeOfDay = 1.0f;
                    }
                    else
                        context.Scene.TimeOfDay += timeDelta;
                    break;

                case Model.DayStatus.GettintBrighter:
                    if (context.Scene.TimeOfDay <= 0.0f)
                    {
                        context.Scene.DayStatus = Model.DayStatus.NotChanging;
                        context.Scene.TimeOfDay = 0.0f;
                    }
                    else
                        context.Scene.TimeOfDay -= timeDelta;
                    break;

                default:
                    throw new Exception("Unknown day status");
            }

            InvokeNextHandler(context);
        }
    }
}
