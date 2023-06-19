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

            sceneController.RequestRender();
        }

        void NewSceneHandler(Canvas screen)
        {
            screen.Apply(CanvasWidget);
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
        {
            sceneController.ChangeToStaticCamera();
        }

        private void CarFollowingCameraButton_Click(object sender, EventArgs e)
        {
            sceneController.ChangeToCarFollowingCamera();
        }

        private void tPPCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sceneController.ChangeToTPPCamera();
        }

        private void modelColorToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.ObjectColor);

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.Edges);

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
            => sceneController.SetRenderingType(RenderingType.PhongShading);
    }
}