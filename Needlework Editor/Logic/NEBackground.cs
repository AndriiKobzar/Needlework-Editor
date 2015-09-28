using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public class NEBackground
    {
         
        List<Rectangle> removed = new List<Rectangle>();
        int distance = 5;
        int width = 500;

        public int Width
        {
            get { return width; }
            set { this.width = value; }
        }
        int height = 300;

        public int Height
        {
            get { return height; }
            set { this.height = value; }
        }
        public int Distance 
        {
            get { return this.distance; }
            set { this.distance = value; }
        }
        public NEBackground()
        {

        }
        public NEBackground(string path)
        {
            using(StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                this.width = int.Parse(reader.ReadLine());
                this.height = int.Parse(reader.ReadLine());
                this.distance = int.Parse(reader.ReadLine());
                while(!reader.EndOfStream)
                {
                    string[] values = reader.ReadLine().Split(' ');
                    removed.Add(new Rectangle(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3])));
                }
               
            }

        }
        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                sw.WriteLine(width);
                sw.WriteLine(height);
                sw.WriteLine(distance);
                foreach (Rectangle rect in removed)
                {
                    sw.WriteLine(string.Format("{0} {1} {2} {3}", rect.X, rect.Y, rect.Width, rect.Height));
                }
            }
        }
        public void DrawCanvas(Graphics g, Pen CanvasPen)
        {
            Pen p = CanvasPen;
            SolidBrush white = new SolidBrush(Color.White);
            for (int i = 0; i < width; i += distance)
            {
                g.DrawLine(p, i, 0, i, height);
            }
            for (int i = 0; i < height; i += distance)
            {
                g.DrawLine(p, 0, i, width, i);
            }
            foreach (Rectangle rect in removed)
            {
                g.FillRectangle(white, rect);
            }
        }

        
    }
}
