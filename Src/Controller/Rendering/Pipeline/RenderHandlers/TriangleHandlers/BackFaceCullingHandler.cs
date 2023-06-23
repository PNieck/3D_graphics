using _3D_graphics.Model.Primitives;
using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.TriangleHandlers
{
    public class BackFaceCullingHandler : RenderHandler<TriangleHandlerContext>
    {
        public override void Handle(TriangleHandlerContext context)
        {
            Vector3 lookingDirection = context.Camera.LookingDirection;
            Vector3 meanNormal = MeanNormal(context.Triangle);

            if (Vector3.Dot(lookingDirection, meanNormal) > 0.5f)
                return;

            InvokeNextHandler(context);
        }

        private static Vector3 MeanNormal(Triangle triangle)
            => (triangle.v1.normal + triangle.v2.normal + triangle.v3.normal) / 3;
    }
}
