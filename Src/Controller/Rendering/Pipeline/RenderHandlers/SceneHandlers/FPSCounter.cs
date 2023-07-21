using System.Diagnostics;

namespace _3D_graphics.Controller.Rendering.Pipeline.RenderHandlers.SceneHandlers
{
    public class FPSCounter : RenderHandler<SceneHandlerContext>
    {
        private const int MEASUREMENT_FRQUENCY = 5;
        
        private Stopwatch _stopwatch;
        private TimeSpan timeSum;
        private int _framesCnt;

        private event SceneFPSHandler? fpsMeasurement;

        public FPSCounter(SceneFPSHandler handler)
        {
            _stopwatch = new Stopwatch();
            timeSum = TimeSpan.Zero;
            _framesCnt = 0;

            fpsMeasurement += handler;
        }

        public override void Handle(SceneHandlerContext context)
        {
            _stopwatch.Start();
            InvokeNextHandler(context);
            _stopwatch.Stop();

            timeSum += _stopwatch.Elapsed;
            _framesCnt++;

            _stopwatch.Reset();

            if (_framesCnt == MEASUREMENT_FRQUENCY)
            {
                double result = MEASUREMENT_FRQUENCY / timeSum.TotalSeconds;
                _framesCnt = 0;
                timeSum = TimeSpan.Zero;

                fpsMeasurement?.Invoke(result);
            }
        }

        /// <summary>
        /// Adds FPS handler from observers.
        /// </summary>
        /// <param name="handler">Handler to add</param>
        /// <returns>Number of observers</returns>
        public int AddObserver(SceneFPSHandler handler)
        {
            fpsMeasurement += handler;
            return fpsMeasurement.GetInvocationList().Length;
        }

        /// <summary>
        /// Removes FPS handler from observers.
        /// </summary>
        /// <param name="handler">Handler to remove</param>
        /// <returns>Number of observers</returns>
        public int RemoveObserver(SceneFPSHandler handler)
        {
            fpsMeasurement -= handler;

            if (fpsMeasurement == null)
                return 0;

            return fpsMeasurement.GetInvocationList().Length;
        }
    }
}
