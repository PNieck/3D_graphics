namespace _3D_graphics.Controller
{
    public delegate void SceneChangedHandler(Bitmap bitmap);

    public class SceneController
    {
        private Bitmap actualScene;
        private event SceneChangedHandler? sceneChanged;


        public SceneController(int width, int height, SceneChangedHandler? handler = null)
        {
            actualScene = new Bitmap(width, height);

            if (handler != null)
            {
                sceneChanged = handler;
            }
        }

        public void AddNewSceneHandler(SceneChangedHandler handler)
        {
            sceneChanged += handler;
        }
    }
}
