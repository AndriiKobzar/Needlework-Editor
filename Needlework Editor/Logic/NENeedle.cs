using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Needlework_Editor
{
    class NENeedle : INeedleworkable
    {
        private class PointComparer:IComparer<Point>
        {
            public int Compare(Point first, Point second)
            {
                if (first.X == second.X)
                {
                    return first.Y - second.Y;
                }
                else
                {
                    return first.X - second.X;
                }

            }
        }
        Bitmap needleBmp = new Bitmap("Needle.png");
        Point[] points = new Point[2];
        Rectangle filled = new Rectangle();
        
        public List<Point> Points 
        { 
            get { return new List<Point>(this.points); } 
        }
        public NENeedle(Point fnp, Point snp)
        {
            this.points[0] = fnp;
            this.points[1] = snp;
            needleBmp.MakeTransparent(Color.White);
        }
        public void SetFilledPart(Point p1, Point p2)
        {
            needleBmp = new Bitmap("Needle.png");
            Point rectanglePoint1 = new Point(0, (int)Math.Sqrt(Math.Pow(points[0].X - p1.X,2)+Math.Pow(points[0].Y-p1.Y,2)));
            Point rectanglePoint2 = new Point(0, (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)));
            Matrix transform = new Matrix();
            transform.Rotate(-this.GetAngle());
            Point[] pts = new Point[] { new Point(p1.X-points[0].X,p1.Y-points[0].Y),new Point(p2.X-points[0].X, p2.Y-points[0].Y) };
            transform.TransformPoints(pts);
            for(int i = 0; i<pts.Length; i++)
            {
                pts[i] = new Point(Math.Abs(pts[i].X), Math.Abs(pts[i].Y));
            }
            Array.Sort(pts, new PointComparer());
            filled = new Rectangle(pts[0], new Size(needleBmp.Width, Math.Abs(pts[0].Y - pts[1].Y)));    
        }
        public void Draw(Graphics g)
        {
            GraphicsState state = g.Save();
            Graphics.FromImage(needleBmp).FillRectangle(new SolidBrush(Color.White), filled);
            needleBmp.MakeTransparent(Color.White);
            double derivative = (double)(points[0].Y - points[1].Y) / (points[0].X - points[1].X);
            g.TranslateTransform(points[0].X, points[0].Y);
            g.RotateTransform(this.GetAngle());
            g.DrawImage(needleBmp, new Point(-needleBmp.Width/2, -20));
            g.Restore(state);
        }
        public bool HasPoint(Point p)
        {
            try
            {
               // Bitmap picture = new Bitmap(Math.Max(points[0].X, points[1].X), Math.Max(points[0].Y, points[1].Y));
                Bitmap picture = new Bitmap(1000, 1000);
                Graphics g = Graphics.FromImage(picture);
                this.Draw(g);      
                return (picture.GetPixel(p.X, p.Y).R != 255 && picture.GetPixel(p.X, p.Y).G != 255 && picture.GetPixel(p.X, p.Y).B != 255);                    
            }
            catch(Exception)
            {
                return false;
            }
        }
        public void SetAngle(double sin, double cos)
        {
            double x = points[0].X;
            double y = points[0].Y;
            x += cos * needleBmp.Height;
            y -= sin * needleBmp.Height;
            points[1] = new Point((int)x, (int)y);
        }
        public float GetAngle()
        {
            double derivative = (double)(points[0].Y - points[1].Y) / (points[0].X - points[1].X);
            if (points[0].Y - points[1].Y > 0 && points[0].X - points[1].X > 0)
            {
                return (float)(180.0 * Math.Atan(derivative) / Math.PI) + 90.0F;
            }
            else if (points[0].Y - points[1].Y > 0 && points[0].X - points[1].X < 0)
            {
                return (float)(180.0 * Math.Atan(derivative) / Math.PI) - 90.0F;
            }
            else if (points[0].Y - points[1].Y < 0 && points[0].X - points[1].X > 0)
            {
                return (float)(180.0 * Math.Atan(derivative) / Math.PI) + 90.0F;
            }
            else if (points[0].Y - points[1].Y < 0 && points[0].X - points[1].X < 0)
            {
                return (float)(180.0 * Math.Atan(derivative) / Math.PI) - 90.0F;
            }
            else if (points[0].X==points[1].X && points[0].Y>points[1].Y)
            {
                return -90.0F;
            }
            else if (points[0].X==points[1].X && points[0].Y>points[1].Y)
            {
                return 90.0F;
            }
            return 0;
        }

        public void Move(int dx, int dy)
        {
            points[0] = new Point(points[0].X + dx, points[0].Y + dy);
            points[1] = new Point(points[1].X + dx, points[1].Y + dy);
        }
        public void DrawPoint(Graphics g, Point p)
        {
            Bitmap bmp = new Bitmap(10, 10); // picture, which contains a part of a curve, which has to be redrawn
            Graphics bmpGrp = Graphics.FromImage(bmp);
            bmpGrp.TranslateTransform(-p.X + 5, -p.Y + 5);
            this.Draw(bmpGrp);
            g.DrawImage(bmp, p.X - 5, p.Y - 5);
            bmpGrp.Dispose();
            bmp.Dispose();  
        }
    }
}

