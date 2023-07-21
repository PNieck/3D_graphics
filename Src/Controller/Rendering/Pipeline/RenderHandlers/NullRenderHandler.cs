namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class NullRenderHandler<T> : IRenderHandler<T>
    {
        private static readonly NullRenderHandler<T> INSTANCE = new NullRenderHandler<T>();

        private NullRenderHandler() { }

        public void Handle(T context)
        { }

        
        public static NullRenderHandler<T> GetInstance()
            => INSTANCE;
    }
}
