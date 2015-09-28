using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Needlework_Editor
{
    public class NEItem : INeedleworkable
    {
        private List<Point> points = new List<Point>();
        private Pen pen;
        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        public List<Point> Points
        {
            get { return this.points; }
        }
        public Pen ItemPen
        {
            get { return this.pen; }
            set { this.pen = value; }
        }
        public NEItem(Color color, int width, List<Point> points)
        {
            this.pen = new Pen(color, width);
            this.pen.Alignment = PenAlignment.Center;
            this.points = points;
        }
        public void Draw(Graphics g)
        {
            Pen borderPen = new Pen(Color.Black, this.pen.Width + 2);
            if (isSelected)
            {
                Pen selectedBorderPen = new Pen(Color.Green, this.pen.Width + 2);
                g.DrawCurve(selectedBorderPen, this.points.ToArray());
            }
            else g.DrawCurve(borderPen, this.points.ToArray());
            g.DrawCurve(pen, this.points.ToArray());
            
        }
        public bool HasPoint(Point p)
        {
            Bitmap b = new Bitmap(1000,1000);
            Graphics g = Graphics.FromImage(b);
            this.Draw(g);
            return b.GetPixel(p.X, p.Y).R == this.pen.Color.R && b.GetPixel(p.X, p.Y).G == this.pen.Color.G && b.GetPixel(p.X, p.Y).B == this.pen.Color.B;
        }
        public void DrawPoint(Graphics g, Point p)
        {
            int size = (int)this.pen.Width;
            Bitmap bmp = new Bitmap(2*size,2*size); // picture, which contains a part of a curve, which has to be redrawn
            Graphics bmpGrp = Graphics.FromImage(bmp);
            Pen borderPen = new Pen(Color.Black, this.pen.Width + 2);
            bmpGrp.TranslateTransform(-p.X+size, -p.Y+size);
            bmpGrp.DrawCurve(borderPen, points.ToArray());
            bmpGrp.DrawCurve(pen, points.ToArray());
            g.DrawImage(bmp, p.X-size, p.Y-size);
            bmpGrp.Dispose();
            bmp.Dispose();      
        }
        public void Move(int dx, int dy)// moves item on specified value
        {
            for(int i = 0; i<points.Count;i++)
            {
                points[i] = new Point(points[i].X+dx,points[i].Y+dy);
            }
        }
        public void MovePoint(int index, int newX, int newY)
        {
            points[index] = new Point(newX, newY);
        }
        internal DotControl[] GetDots()
        {
            DotControl[] result = new DotControl[points.Count];
            for(int i = 0; i<points.Count; i++)
            {
                result[i] = new DotControl(this, i);
            }
            return result;
        }
        public string GetSaveInfo()
        {
            string result = "";
            for (int i = 0; i < points.Count; i++ )
            {
                result += points[i].ToString();
            }
            result+=this.pen.Width;
            return result;
        }
        public NEItem Clone()
        {
            Point[] pts = null;
            points.CopyTo(pts,0);
            return new NEItem(this.pen.Color, (int)this.pen.Width, new List<Point>(pts));
        }
       
    }
}