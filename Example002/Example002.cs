using AGI.Foundation.Graphics;
using System.Windows.Forms;

namespace STKComponentsTutorials
{
    public partial class Example002 : Form
    {
        private Insight3D insight3D;
        public Example002()
        {
            InitializeComponent();

            insight3D = new Insight3D();
            insight3D.Dock = DockStyle.Fill;
            this.Controls.Add(insight3D);
        }
    }
}
