namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public class NullRenderHandler<T> : IRenderHandler<T>
    {
        public void Handle(T context)
        { }
    }
}
