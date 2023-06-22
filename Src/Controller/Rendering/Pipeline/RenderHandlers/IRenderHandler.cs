namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers
{
    public interface IRenderHandler<T>
    {
        public void Handle(T context);
    }
}
