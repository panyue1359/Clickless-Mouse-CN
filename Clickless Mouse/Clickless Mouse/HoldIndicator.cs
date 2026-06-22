using System.Drawing;
using System.Windows.Forms;

namespace Clickless_Mouse
{
    public partial class HoldIndicator : Form
    {
        readonly int diameter;
        readonly Color indicatorColor;

        public HoldIndicator(int diameter, Color indicatorColor)
        {
            InitializeComponent();

            BackColor = Color.White;
            TransparencyKey = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;

            this.diameter = diameter;
            this.indicatorColor = indicatorColor;
            Width = diameter;
            Height = diameter;

            // Prevent occasional first-show flicker, matching the square overlay approach.
            PointToClient(new Point(0, 0));
            Location = new Point(diameter * -1, diameter * -1);
        }

        private void HoldIndicator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, ClientRectangle);

            using (SolidBrush brush = new SolidBrush(indicatorColor))
            {
                g.FillEllipse(brush, 0, 0, diameter - 1, diameter - 1);
            }
        }
    }
}
