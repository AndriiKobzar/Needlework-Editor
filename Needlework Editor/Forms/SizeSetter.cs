using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public partial class SizeSetter : Form
    {
        public int WindowHeight 
        {
            get { return (int)heightSetter.Value; }
            set { heightSetter.Value = value; }
        }
        public int WindowWidth
        {
            get { return (int)widthSetter.Value; }
            set { widthSetter.Value = value; }
        }
        public int Distance
        {
            get { return (int)distanceSetter.Value; }
            set { distanceSetter.Value = value; }
        }
        public SizeSetter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
