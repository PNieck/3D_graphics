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
    }
}