using _3D_graphics.Controller;
using _3D_graphics.Model.Canvas;
using _3D_graphics.Model.SourceOfLight;

namespace _3D_graphics
{
    public partial class MainForm : Form
    {
        SceneController sceneController;
        RenderController renderController;

        public MainForm()
        {
            InitializeComponent();
            sceneController = new SceneController();

            renderController = new RenderController(CanvasWidget.Width, CanvasWidget.Height, sceneController);
            renderController.AddFpsHandler(FpsHandler);
            renderController.AddRenderObserver(RenderHandler);

            renderController.RenderScene();
        }

        void RenderHandler(Bitmap screen)
        {
            CanvasWidget.Image = screen;
            CanvasWidget.Refresh();
        }

        void FpsHandler(double fps)
        {
            FPSCounter.Text = string.Format("FPS: {0:N2}", fps);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    sceneController.MoveCarForward();
                    break;
                case Keys.S:
                    sceneController.MoveCarBackward();
                    break;
                case Keys.D:
                    sceneController.TurnCarRight();
                    break;
                case Keys.A:
                    sceneController.TurnCarLeft();
                    break;

                case Keys.Up:
                    sceneController.MoveCarLights(CarLightMovement.Up);
                    break;
                case Keys.Down:
                    sceneController.MoveCarLights(CarLightMovement.Down);
                    break;
                case Keys.Right:
                    sceneController.MoveCarLights(CarLightMovement.Right);
                    break;
                case Keys.Left:
                    sceneController.MoveCarLights(CarLightMovement.Left);
                    break;

                case Keys.F:
                    if (renderController.CarShakingStatus)
                        renderController.RemoveCarShaking();
                    else
                        renderController.AddCarShaking();
                    break;
            }

            renderController.RenderScene();
        }

        private void StaticCameraButton_Click(object sender, EventArgs e)
        {
            renderController.SetCameraType(CameraType.Static);
            renderController.RenderScene();
        }

        private void CarFollowingCameraButton_Click(object sender, EventArgs e)
        {
            renderController.SetCameraType(CameraType.CarFollowing);
            renderController.RenderScene();
        }

        private void TPPCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderController.SetCameraType(CameraType.TPP);
            renderController.RenderScene();
        }

        private void modelColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderController.SetRenderingType(RenderingType.ObjectColor);
            renderController.RenderScene();
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderController.SetRenderingType(RenderingType.Edges);
            renderController.RenderScene();
        }

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderController.SetRenderingType(RenderingType.PhongShading);
            renderController.RenderScene();
        }

        private void gourandShadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderController.SetRenderingType(RenderingType.GouraudShading);
            renderController.RenderScene();
        }
    }
}