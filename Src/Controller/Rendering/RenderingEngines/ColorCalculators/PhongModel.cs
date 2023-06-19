using _3D_graphics.Model.Camera;
using _3D_graphics.Model.Primitives;
using _3D_graphics.Model.SourceOfLight;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.RenderingEngines.ColorCalculators
{
    internal class PhongModel : ColorCalculator
    {
        private const float SPECULAR_REFLECTION_CONST = 0.2f;
        private const float DIFFUSE_REFACTION_CONST = 0.5f;
        private const float AMBIENT_REFLECTION_CONST = 0.7f;
        private const float SHINESS_CONST = 20;

        private ColorRatios colorRations;

        private IEnumerable<ISourceOfLight> sourcesOfLights;
        private ICamera camera;

        public PhongModel(Color color, IEnumerable<ISourceOfLight> sourcesOfLights, ICamera camera):
            base(color)
        {
            colorRations = new ColorRatios(color);

            this.sourcesOfLights = sourcesOfLights;
            this.camera = camera;
        }

        public PhongModel(): base(Color.Black)
        { }

        public override Color GetColor(Vertex worldCoordinates)
        {
            Vector3 toViewer = Vector3.Normalize(camera.Position - worldCoordinates.coordinates);

            ColorRatios resultColorRations = SPECULAR_REFLECTION_CONST * colorRations;

            foreach (var source in sourcesOfLights)
            {
                ColorRatios mixedColorRatios = source.GetColorRatios(worldCoordinates.coordinates) * colorRations;
                Vector3 toLight = Vector3.Normalize(source.Coordinates - worldCoordinates.coordinates);
                Vector3 lightReflection = CalculateReflection(worldCoordinates.normal, toLight);

                float normalToLightCos = Vector3.Dot(worldCoordinates.normal, toLight);
                float viewerToReflectionCos = Vector3.Dot(toViewer, lightReflection);

                if (normalToLightCos > 0.0f)
                    resultColorRations += DIFFUSE_REFACTION_CONST * mixedColorRatios * normalToLightCos;

                if (viewerToReflectionCos > 0.0f)
                    resultColorRations += AMBIENT_REFLECTION_CONST * mixedColorRatios * MathF.Pow(viewerToReflectionCos, SHINESS_CONST);
                    
            }

            return resultColorRations.GetColor();
        }

        public override void SetBaseColor(Color color)
        {
            if (baseColor.Equals(color)) return;

            colorRations = new ColorRatios(color);
            base.SetBaseColor(color);
        }

        public void SetLightSources(IEnumerable<ISourceOfLight> sources)
        {
            sourcesOfLights = sources;
        }

        public void SetCamera(ICamera camera)
        {
            this.camera = camera;
        }

        private static Vector3 CalculateReflection(Vector3 normal, Vector3 toLight)
            => 2 * Vector3.Dot(normal, toLight) * normal - toLight;
    }
}
