using _3D_graphics.Controller;
using _3D_graphics.Model.Canvas;

namespace _3D_graphics
{
    public partial class MainForm : Form
    {
        SceneController sceneController;

        public MainForm()
        {
            InitializeComponent();
            sceneController = new SceneController(CanvasWidget.Width, CanvasWidget.Height, NewSceneHandler);
            sceneController.AddNewFpsObserver(FpsHandler);

            sceneController.RequestRender();
        }

        void NewSceneHandler(Canvas screen)
        {
            screen.Apply(CanvasWidget);
        }

        void FpsHandler(double fps)
        {
            FPSCounter.Text = string.Format("FPS: {0:N2}", fps);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    sceneController.MoveCarForward();
                    break;
                case Keys.Down:
                    sceneController.MoveCarBackward();
                    break;
                case Keys.Right:
                    sceneController.TurnCarRight();
                    break;
                case Keys.Left:
                    sceneController.TurnCarLeft();
                    break;
            }
        }

        private void StaticCameraButton_Click(object sender, EventArgs e)
            => sceneController.SetCameraType(CameraType.Static);

        private void CarFollowingCameraButton_Click(object sender, EventArgs e)
            => sceneController.SetCameraType(CameraType.CarFollowing);

        private void TPPCameraToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetCameraType(CameraType.TPP);

        private void modelColorToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.ObjectColor);

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.Edges);

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.PhongShading);

        private void gourandShadingToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.GouraudShading);
    }
}