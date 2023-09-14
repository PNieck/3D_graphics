using System.Numerics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    internal class CarShaker : RenderHandler<SceneHandlerContext>
    {
        private const float MaxOffset = 5.0f;

        private Random random;

        public CarShaker()
        {
            random = new Random();
        }

        public override void Handle(SceneHandlerContext context)
        {
            var offset = new Vector3(GetOffset(), GetOffset(), 0);
            context.Scene.car.MoveByVector(offset);

            InvokeNextHandler(context);

            context.Scene.car.MoveByVector(-offset);
        }

        private float GetOffset()
        {
            float result = (float)random.NextDouble() * MaxOffset;

            int sign = random.Next(0, 2);

            return sign == 0 ? -result : result;
        }
    }
}
