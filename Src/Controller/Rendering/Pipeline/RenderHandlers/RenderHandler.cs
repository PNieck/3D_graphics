namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public abstract class RenderHandler<T> : IRenderHandler<T>
    {
        protected IRenderHandler<T>? nextHandler;

        public RenderHandler()
            => nextHandler = null;

        public void SetNextHandler(IRenderHandler<T> handler)
            => nextHandler = handler;

        public abstract void Handle(T context);


        public void InvokeNextHandler(T context)
            => nextHandler?.Handle(context);
    }
}
