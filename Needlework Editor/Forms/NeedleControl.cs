using System;
using System.Drawing;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public partial class NeedleControl : UserControl
    {
        Point MouseDownLocation;
        NENeedle needle = null;
        public event Action AngleChanged;
        public double Angle
        {
            set
            {
                pictureBox1.Top = -(int)(Math.Sin(value) * Width / 2) + Width / 2 - pictureBox1.Height / 2;
                pictureBox1.Left = (int)(Math.Cos(value) * Width / 2) + Width / 2 - pictureBox1.Width / 2;
            }
        }
        internal NENeedle Needle
        {
            get { return needle; }
            set { needle = value; }
        }

        public NeedleControl()
        {
            InitializeComponent();
            
        }

        private void NeedleControl_Load(object sender, EventArgs e)
        {
            this.CreateGraphics().DrawEllipse(new Pen(Color.Black), 0, 0, this.Width, this.Height);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
        }

        private void NeedleControl_Paint(object sender, PaintEventArgs e)
        {
            this.CreateGraphics().DrawEllipse(new Pen(Color.Black), 0, 0, this.Width, this.Height);
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X + pictureBox1.Left - MouseDownLocation.X - Width / 2;
                int y = -(e.Y + pictureBox1.Top - MouseDownLocation.Y) + Height / 2;

                if (x != 0 && y != 0)
                {
                    double cos = x / Math.Sqrt(x * x + y * y);
                    double sin = y / Math.Sqrt(x * x + y * y);
                    pictureBox1.Location = new Point((int)(cos * Width / 2) + Width / 2 - pictureBox1.Width / 2,
                                                    -(int)(sin * Width / 2) + Width / 2 - pictureBox1.Height / 2);
                    if (needle != null)
                    {
                        needle.SetAngle(sin, cos);
                        AngleChanged();
                    }
                }
            }
        }
        
    }
}
