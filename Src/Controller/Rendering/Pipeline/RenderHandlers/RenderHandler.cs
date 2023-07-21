namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public abstract class RenderHandler<T> : IRenderHandler<T>
    {
        static private readonly IRenderHandler<T> nullHandler = new NullRenderHandler<T>();

        protected IRenderHandler<T> nextHandler;

        public RenderHandler()
            => nextHandler = nullHandler;

        public void SetNextHandler(IRenderHandler<T> handler)
            => nextHandler = handler;

        public abstract void Handle(T context);


        public void InvokeNextHandler(T context)
            => nextHandler.Handle(context);
    }
}
