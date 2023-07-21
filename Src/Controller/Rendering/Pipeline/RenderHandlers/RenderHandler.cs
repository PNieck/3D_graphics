namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public abstract class RenderHandler<T> : IRenderHandler<T>
    {
        public IRenderHandler<T> NextHandler { get; set; }

        public RenderHandler()
            => NextHandler = NullRenderHandler<T>.GetInstance();

        public abstract void Handle(T context);


        public void InvokeNextHandler(T context)
            => NextHandler.Handle(context);
    }
}
