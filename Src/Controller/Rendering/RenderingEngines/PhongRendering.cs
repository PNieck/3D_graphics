using _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators;
using _3D_graphics.Controller.Rendering.RenderingEngines.ShadingAlgorithms;
using _3D_graphics.Model;
using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics.Controller.Rendering.RenderingEngines
{
    public class PhongRendering : ShaderRendering
    {
        private PhongModel colorCalculator;
        
        public PhongRendering(int width, int height, IEnumerable<ISourceOfLight> lightSources, ICamera camera) :
            base(width, height,
                new PhongShading(new PhongModel(Color.Black, lightSources, camera)))
        {
            colorCalculator = (PhongModel)shading.colorCalculator;
        }

        public PhongRendering(int width, int height) :
            base(width, height, new PhongShading(new PhongModel()))
        {
            colorCalculator = (PhongModel)shading.colorCalculator;
        }

        public override Canvas RenderScene(Scene scene, ICamera camera)
        {
            colorCalculator.SetCamera(camera);
            colorCalculator.SetLightSources(scene.lights);

            return base.RenderScene(scene, camera);
        }
    }
}
