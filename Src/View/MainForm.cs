using _3D_graphics.Controller;
using System.Windows.Forms;

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

        void NewSceneHandler(Model.Canvas screen)
        {
            screen.Apply(CanvasWidget);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    sceneController.MoveCarForeward();
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
    }
}