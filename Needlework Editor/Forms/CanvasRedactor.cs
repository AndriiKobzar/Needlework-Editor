using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public partial class CanvasRedactor : Form
    {
        Graphics g;
        private int distance = 5;

        List<Rectangle> removedThreads = new List<Rectangle>();

        Point p1 = new Point();
        Point p2 = new Point();

        private Point current = new Point();
        private bool isClicked = false;

        int width;
        int height;

        Pen white = new Pen(Color.White);

        NEBackground back = new NEBackground();
        public NEBackground Background
        {
            get { return this.back; }
        }
        public CanvasRedactor()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
            width = canvas.Width;
            height = canvas.Height;
            DrawCanvas();
        }
        private void DrawCanvas()
        {
            canvas.CreateGraphics().Clear(Color.White);
            canvas.Width = int.Parse(canvasWidth.Text);
            canvas.Height = int.Parse(canvasHeight.Text);
            Pen p = new Pen(Color.Gray);
            g = canvas.CreateGraphics();
            for(int i = 0; i < width; i+= distance)
            {
                g.DrawLine(p, i, 0, i, height);
            }
            for (int i = 0; i < height; i += distance)
            {
                g.DrawLine(p, 0, i, width, i);
            }
            foreach(Rectangle rect in removedThreads)
            {
                g.DrawRectangle(white, rect);
            }
        }
        private void CanvasRedactor_Load(object sender, EventArgs e)
        {
            DrawCanvas();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                width = int.Parse(canvasWidth.Text);
                errorProvider1.Clear();DrawCanvas();
                back.Width = width;
            }
            catch { errorProvider1.SetError(canvasWidth, "Некоректне значення"); }            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                distance = int.Parse(textBox3.Text);
                errorProvider1.Clear(); 
                DrawCanvas();
                back.Distance = distance;
            }
            catch { errorProvider1.SetError(textBox3, "Некоректне значення"); }     
        }
        private void OKBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                back.Save(dialog.FileName + ".neb");             
            }

        }
        private void canvas_Click(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
                Graphics g = Graphics.FromImage(bitmap);
                p1 = new Point(distance * (current.X / distance), distance * (current.Y / distance));
            }
            else
            {
                p2 = new Point(distance * (current.X / distance), distance * (current.Y / distance));
                if (p1.X.Equals(p2.X)) //vertical line
                {
                    Point fixedPoint = (p1.Y > p2.Y) ? (new Point(p2.X + 1, p2.Y + 1)) : (new Point(p1.X + 1, p1.Y + 1));
                    Rectangle rect = new Rectangle(fixedPoint, new Size(distance - 1, Math.Abs(p1.Y - p2.Y) - 1));
                    removedThreads.Add(rect);
                    g.FillRectangle(new SolidBrush(Color.White), removedThreads[removedThreads.Count - 1]);
                }
                else if(p1.Y.Equals(p2.Y)) // horizontal line
                {
                    Point fixedPoint = (p1.X > p2.X) ? (new Point(p2.X + 1, p2.Y + 1)) : (new Point(p1.X+1, p1.Y+1));
                    removedThreads.Add(new Rectangle(fixedPoint, new Size(Math.Abs(p1.X - p2.X) - 1, distance - 1)));
                    g.FillRectangle(new SolidBrush(Color.White), removedThreads[removedThreads.Count - 1]);
                } 
                
            }
            isClicked = !isClicked;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            current = new Point(e.X, e.Y);
        }

        private void canvasHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                height = int.Parse(canvasHeight.Text);
                errorProvider2.Clear();
                DrawCanvas();
                back.Height = height;
            }
            catch { errorProvider2.SetError(canvasHeight, "Некоректне значення"); }           
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawCanvas();
        }
    }
}
