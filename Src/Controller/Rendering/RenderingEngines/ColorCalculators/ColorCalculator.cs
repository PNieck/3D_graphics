using _3D_graphics.Model.Primitives;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators
{
    public abstract class ColorCalculator
    {
        protected Color baseColor;
        
        public ColorCalculator(Color baseColor)
        {
            this.baseColor = baseColor;
        }

        public abstract Color GetColor(Vertex worldCoordinates);

        public virtual void SetBaseColor(Color color)
            => baseColor = color;
    }
}
