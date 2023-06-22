namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public abstract class RenderHandler<T> : IRenderHandler<T>
    {
        protected IRenderHandler<T>? nextHandler;

        public RenderHandler()
            => nextHandler = null;

        public void SetNextHandler(IRenderHandler<T> handler)
            => nextHandler = handler;

        protected abstract void Action(T context);


        public void Handle(T context)
        {
            Action(context);

            nextHandler?.Handle(context);
        }
    }
}
