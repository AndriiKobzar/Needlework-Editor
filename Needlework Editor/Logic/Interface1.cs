using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needlework_Editor
{
    interface INeedleworkable
    {
        void Draw(Graphics g);
        bool HasPoint(Point p);
        void DrawPoint(Graphics g, Point p);
        void Move(int dx, int dy);
        List<Point> Points { get; }
    }
}
