using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public partial class DotControl : UserControl
    {
        NEItem item;
        int index;
        Point MouseDownLocation;
        
        public DotControl(NEItem item, int _point)
        {
            InitializeComponent();
            this.item = item;
            this.index = _point;
            this.Location = item.Points[index];
        }

        private void DotControl_Load(object sender, EventArgs e)
        {

        }

        private void DotControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) MouseDownLocation = e.Location;
        }

        private void DotControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
            this.item.MovePoint(index, this.Left, this.Top);
        }

    }
}