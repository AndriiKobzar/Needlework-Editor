using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Needlework_Editor
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        byte arcStep = 0;

        bool isClicked = false;
        bool isNeedleClicked = false;
        bool isNeedleCorrecting = false;

        bool firstNeedlePointClicked = false;
        bool ctrlClicked = false;

        Point firstNeedlePoint = new Point();
        Point firstNeedleCorrection = new Point();

        Graphics g;
        Color currentColor = Color.Red;
        Pen CanvasPen = new Pen(Color.LightGray, 1);

        List<INeedleworkable> items = new List<INeedleworkable>();
        List<NEItem> selectedItems = new List<NEItem>();
        List<NEItem> buffer = null;

        Dictionary<Point, INeedleworkable> Interceptions = new Dictionary<Point, INeedleworkable>();
        NEBackground canvas = null;
        NENeedle needle = null;
        List<Image> steps = new List<Image>();

        int distance = 8;

        Point currentPoint = new Point();

        Bitmap image;

        string backPath;
        public Form1()
        {
            InitializeComponent();
            g = drawingPanel.CreateGraphics();
            toolBox.SelectedIndex = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DrawCanvas(g);
        }
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Draw();   
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectFolder.ShowDialog() == DialogResult.OK)
            {
                int i = 1;
                foreach (Bitmap image in steps)
                {
                    image.Save(selectFolder.SelectedPath+"\\image"+i.ToString()+".jpg");
                    i++;
                }
            }
        }
        private void DrawItems(Graphics imageGraphics)
        {
            foreach (INeedleworkable item in items)
            {
                item.Draw(imageGraphics);
            }
            foreach(KeyValuePair<Point,INeedleworkable> pair in Interceptions)
            {
                pair.Value.DrawPoint(imageGraphics,pair.Key);
            }
        }
        private void DrawCanvas(Graphics imageGraphics)
        {
            if (backPath == null)
            {
                Pen p = new Pen(Color.Black);
                for (int i = 0; i < drawingPanel.Width; i += distance)
                {
                    imageGraphics.DrawLine(CanvasPen, i, 0, i, drawingPanel.Height);
                }
                for (int i = 0; i < drawingPanel.Height; i += distance)
                {
                    imageGraphics.DrawLine(CanvasPen, 0, i, drawingPanel.Width, i);
                }
            }
            else
            {
                g.DrawImage(new Bitmap(backPath, false), new Point());
            }
        }
        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            currentPoint = new Point(e.X, e.Y);
        }
        private void drawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                //check if this point belongs to any item
                NEItem foundItem = null;
                foreach(INeedleworkable item in items)
                {
                    drawingPanel.Controls.Clear();//clear panel from dots
                    if (item is NEItem && item.HasPoint(e.Location)) 
                    { 
                        drawingPanel.Controls.Clear(); 
                        foundItem = item as NEItem; 
                        break; 
                    }
                }
                if (drawingPanel.Controls.Count > 0 && foundItem == null)
                {
                    drawingPanel.Controls.Clear();//clear panel from dots
                    selectedItems = new List<NEItem>();//clear seleted items
                    buffer = null;
                    return; //break execution
                }
                if (foundItem != null && !ctrlClicked) //we have found one
                {
                    DotControl[] dots = foundItem.GetDots();//show dots for editing an item
                    foreach(DotControl dot in dots)
                    {
                        drawingPanel.Controls.Add(dot);
                    }
                }
                else if(foundItem != null && ctrlClicked)
                {
                    selectedItems.Add(foundItem);
                    foundItem.IsSelected = true;
                    Draw();
                }
                else //it is empty point, so we draw
                {
                    if (!isNeedleClicked) //draw item
                    {
                        DrawItem(e);
                    }
                    else  //draw needle
                    {
                        DrawNeedle();
                    }
                }
            }
           // Draw();
        }
        void ResetPointsArray()
        {
            points = new List<Point>();
            arcStep = 0;
            isClicked = false;
        }
        private void DrawItem(MouseEventArgs e)
        {
            switch (toolBox.SelectedIndex)
            {
                case 0://line
                    {
                        if (!isClicked)
                        {
                            points.Add(getHoleByPoint(e.X, e.Y));
                        }
                        else
                        {
                            points.Add(getHoleByPoint(e.X, e.Y));
                            NEItem newItem = new NEItem(currentColor, (int)threadWidthPicker.Value, points);
                            newItem.Draw(g);
                            items.Add(newItem);
                            points = new List<Point>();
                        }
                        isClicked = !isClicked;
                    }
                    break;
                case 1: //curve
                    {
                        if (arcStep < curvePointsNumber.Value - 1)
                        {
                            points.Add(getHoleByPoint(e.X, e.Y));
                            arcStep++;
                        }
                        else
                        {
                            arcStep = 0;
                            points.Add(new Point(e.X, e.Y));
                            NEItem newItem = new NEItem(currentColor, (int)threadWidthPicker.Value, points);
                            try
                            {
                                newItem.Draw(g);
                                items.Add(newItem);
                            }
                            catch (DivideByZeroException)
                            {
                                MessageBox.Show("Не вдалось побудувати криву");
                            }
                            points = new List<Point>();
                        }

                    } break;
                case 2: // edit needle;
                    if (needle != null)
                    {
                        if (needle.HasPoint(e.Location) && !isNeedleCorrecting)
                        {
                            firstNeedleCorrection = e.Location;
                        }
                        else if (needle.HasPoint(e.Location))
                        {
                            needle.SetFilledPart(firstNeedleCorrection, e.Location);
                            Draw();
                        }
                        isNeedleCorrecting = !isNeedleCorrecting;
                    }
                    else MessageBox.Show("Спочатку створіть голку.","ПОПЕРЕДЖЕННЯ");
                    break;
            }
        }
        private void DrawNeedle()
        {
            if (!firstNeedlePointClicked)
            {
                firstNeedlePoint = currentPoint;
            }
            else
            {
                needle = new NENeedle(firstNeedlePoint, currentPoint);
                items.Add(needle);
                needle.Draw(g);
                NeedleBtn.Text = "Прибрати голку";
                isNeedleClicked = false;
                needleRedactor.Needle = needle;
                needleRedactor.Angle = needle.GetAngle();
            }
            firstNeedlePointClicked = !firstNeedlePointClicked;
        }
        private Point getHoleByPoint(int x, int y)
        {
            x -= x % 5;
            x += 2;
            y -= y % 5;
            y += 2;
            return new Point(x, y);
        }     
        private void DrawItems()
        {
            DrawItems(g);
        }
        private void ClearCanvas()
        {
            drawingPanel.Controls.Clear();
            items = new List<INeedleworkable>();
            g.Clear(Color.White);   
            DrawCanvas();
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                INeedleworkable toBeRemoved = items[items.Count-1];
                items.RemoveAt(items.Count - 1);
                foreach(KeyValuePair<Point, INeedleworkable> pair in Interceptions)
                {
                    if (pair.Value == toBeRemoved) Interceptions.Remove(pair.Key);
                }
                Draw();
            }
        }
        private void DrawCanvas()
        {
            Pen p = new Pen(Color.Gray);
            if (canvas == null)
            {
                for (int i = 0; i < drawingPanel.Width; i += distance)
                {
                    g.DrawLine(CanvasPen, i, 0, i, drawingPanel.Height);
                }
                for (int i = 0; i < drawingPanel.Height; i += distance)
                {
                    g.DrawLine(CanvasPen, 0, i, drawingPanel.Width, i);
                }
            }
            else canvas.DrawCanvas(g, CanvasPen);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Height < drawingPanel.Location.Y+drawingPanel.Height || Width<drawingPanel.Location.X+drawingPanel.Width)
            {
                DrawCanvas();
                DrawItems();
            }
        }
        private void canvasColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (canvasCD.ShowDialog()==DialogResult.OK)
            {
                CanvasPen.Color = canvasCD.Color;
                DrawCanvas();
                DrawItems();
            }

        }
        private void ThreadColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threadCD.ShowDialog() == DialogResult.OK) currentColor = threadCD.Color;
        }
        private void SolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawCanvas();
            backPath = null;
        }
        private void LaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasRedactor Redactor = new CanvasRedactor();
            if (Redactor.ShowDialog() == DialogResult.OK)
            {
                canvas = Redactor.Background;
                drawingPanel.Width = canvas.Width;
                drawingPanel.Height = canvas.Height;
                g = drawingPanel.CreateGraphics();
                DrawCanvas();
            }
            points = new List<Point>();
        }
        private void changeLayerCMSI_Click(object sender, EventArgs e)
        {
            List<INeedleworkable> itemsHere = new List<INeedleworkable>();
            foreach (INeedleworkable item in items)
            {
                if (item.HasPoint(currentPoint)) itemsHere.Add(item);
            }
            foreach (Point p in Interceptions.Keys)
            {
                if (Math.Sqrt(Math.Pow(p.X - currentPoint.X, 2) + Math.Pow(p.Y - currentPoint.Y, 2)) <= 10)
                {
                    List<INeedleworkable> ditemsHere = new List<INeedleworkable>();
                    foreach (INeedleworkable item in items)
                    {
                        if (item.HasPoint(currentPoint)) ditemsHere.Add(item);
                    }
                    if (ArrayEquals(itemsHere, ditemsHere))
                    { currentPoint = p; break; }
                }
            }
            if (!Interceptions.ContainsKey(currentPoint) && itemsHere.Count > 0)
                Interceptions.Add(currentPoint, itemsHere[0]);
            else if (Interceptions.ContainsKey(currentPoint) && itemsHere.Count > 0)
            {
                try
                {
                    Interceptions[currentPoint] = itemsHere[itemsHere.IndexOf(Interceptions[currentPoint]) + 1];
                }
                catch
                {
                    Interceptions[currentPoint] = itemsHere[0];
                }
            }
            DrawItems();
        }//action causes changing order of items in point
        private bool ArrayEquals(List<INeedleworkable> a1, List<INeedleworkable> a2)
        {
            if (a1.Count != a2.Count) return false;
            foreach(INeedleworkable item in a1)
            {
                if (!a2.Contains(item)) return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {   //save step
            if (needle != null)
            {
                Bitmap image = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                Graphics imageGraphics = Graphics.FromImage(image);
                Draw(imageGraphics);
                steps.Add(image);
                points = new List<Point>();
            }
            else MessageBox.Show("Намалюйте голку", "ПОПЕРЕДЖЕННЯ");
        }
        private void Draw(Graphics g)
        {
            g.Clear(Color.White);
            DrawCanvas(g);
            DrawItems(g);
            //if (needle != null) needle.Draw(g);
        }
        private void Draw()
        {
            g.Clear(Color.White);
            g = drawingPanel.CreateGraphics();
            if (image != null) g.DrawImage(image, new Point(0, 0));
            DrawCanvas();
            DrawItems();
        }
        private void imageOnBcgrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                openFile.DefaultExt = ".jpg";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    g.Clear(Color.White);
                    image = new Bitmap(openFile.FileName, false);
                    g.DrawImage(image, new Point(0, 0));
                    DrawCanvas();
                    DrawItems();
                }
                openFile.DefaultExt = "";
                imageOnBcgrToolStripMenuItem.Text = "Прибрати зображення";
            }
            else
            {
                image = null;
                Draw();
                imageOnBcgrToolStripMenuItem.Text = "Встановити зображення";
            }

        }
        private void backTSMI_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Background Files (.ned)|*.ned";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    canvas = new NEBackground(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Не вдалося відкрити файл. Схоже, що файл редагувавя ззовні.","ПОПЕРЕДЖЕННЯ");
                }
                g.Clear(Color.White);
                Draw();
            }
            ofd.Dispose();
        }
        private void NeedleBtn_Click(object sender, EventArgs e)
        {
            if (needle==null)
            {
                isNeedleClicked = true;
                needleRedactor.Visible = true;
            }
            else
            {
                NeedleBtn.Text = "Намалювати голку";
                items.Remove(needle);
                needle = null;
                isNeedleClicked = false;
                needleRedactor.Visible = true;
                Draw();
            }
            ResetPointsArray();
        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        private void toolBox_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int _distance = distance;
            if (canvas != null) _distance = canvas.Distance;
            if(toolBox.SelectedIndex!=2)    
                switch (e.KeyCode)
                {
                    case Keys.Left: 
                       foreach (NEItem item in selectedItems)
                       {
                           item.Move(-_distance, 0);
                       }
                       Draw();                    
                       break;
                    case Keys.Right: 
                        foreach (NEItem item in selectedItems)
                        {
                           item.Move(_distance, 0);
                        }
                        Draw(); break;
                    case Keys.Up: 
                        foreach (NEItem item in selectedItems)
                        {
                            item.Move(0,-_distance);
                        }
                        Draw(); break;
                    case Keys.Down:
                        foreach (NEItem item in selectedItems)
                        {
                            item.Move(0, _distance);
                        }Draw();break;
                    case Keys.ControlKey: ctrlClicked = true; break;
                    case Keys.C: if (ctrlClicked) buffer = new List<NEItem>(selectedItems); 
                        for(int i = 0; i<buffer.Count; i++)
                        {
                            buffer[i] = buffer[i].Clone();
                        }
                    break;
                        case Keys.V: if (buffer != null)
                        {
                        //get offset to draw near the upper-left corner
                            int dx = items[0].Points[0].X;
                            int dy = items[0].Points[0].Y;
                            foreach (NEItem item in selectedItems)
                            {
                                foreach (Point p in item.Points)
                                {
                                    dx = Math.Min(dx, p.X);
                                    dy = Math.Min(dy, p.Y);
                                }
                            }
                            foreach (NEItem item in buffer)
                            {
                                item.Move(-dx, -dy);
                                item.Draw(g);
                            }
                       }
                      break;
                        case Keys.Delete:
                      if (selectedItems.Count > 0)
                      {
                          foreach (NEItem item in selectedItems)
                          {
                              items.Remove(item);
                          }
                          selectedItems = new List<NEItem>();
                          Draw();
                      }
                            break;
                }
            else if(needle!=null) // move needle
            {
                switch(e.KeyCode)
                {
                    case Keys.Up: needle.Move(0, -distance); break;
                    case Keys.Down: needle.Move(0, distance); break;
                    case Keys.Left: needle.Move(-distance, 0); break;
                    case Keys.Right: needle.Move(distance, 0); break;
                }
                Draw();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrlClicked = false;
        }

        private void saveAsFileTSMI_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = false;
            // get offset
            int dx = items[0].Points[0].X;
            int dy = items[0].Points[0].Y;
            foreach(NEItem item in selectedItems)
            {
                foreach(Point p in item.Points)
                {
                    dx = Math.Min(dx, p.X);
                    dy = Math.Min(dy, p.Y);
                }
            }
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName+".neg", FileMode.Create)))
                {
                    foreach(NEItem item in selectedItems)
                    {
                        item.Move(-dx, -dy);
                        sw.WriteLine(item.GetSaveInfo());
                        item.Move(dx, dy);
                    }
                }
            }
            sfd.Dispose();
            
        }

        private void inputFromFileTSMI_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Items File (.neg)|(*.neg)" })
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {  
                    using(StreamReader reader = new StreamReader(new FileStream(ofd.FileName, FileMode.Open)))
                    {
                        string line;
                        string[] pointsString;
                        try
                        {
                            while (!reader.EndOfStream)
                            {
                                line = reader.ReadLine();
                                pointsString = line.Split('{', '}');
                                int width = int.Parse(pointsString[pointsString.Length - 1]);

                                for (int i = 0; i < pointsString.Length - 1; i++)
                                {
                                    string pointString = pointsString[i];
                                    if (pointString != "")
                                    {
                                        string[] values = pointString.Split(',');
                                        points.Add(new Point(int.Parse(values[0].Substring(2)), int.Parse(values[1].Substring(2))));
                                    }
                                }
                                items.Add(new NEItem(currentColor, width, points));
                                points = new List<Point>();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Не вдалося відкрити файл. Схоже, що файл редагувавя ззовні.", "ПОПЕРЕДЖЕННЯ");
                        }
                    }
                }
            }
            Draw();
        }

        private void needleRedactor_AngleChanged()
        {
            Draw();
        }

        private void toolBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right)
                e.Handled = true;
        }

        private void toolBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolBox.SelectedIndex == 1) curvePointsNumber.Enabled = true;
            else curvePointsNumber.Enabled = false;
            points = new List<Point>();
        }

        private void drawingPanel_Resize(object sender, EventArgs e)
        {
            toolboxPanel.Left = drawingPanel.Right+10;
            Draw();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ResetPointsArray();
            if (selectedItems.Count != 0)
            {
                selectedItems = new List<NEItem>();
                Draw();
            }
        }

        private void toolboxPanel_Click(object sender, EventArgs e)
        {
            ResetPointsArray();
        }

        private void розміриToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SizeSetter setter = new SizeSetter())
            {
                setter.WindowHeight = drawingPanel.Height;
                setter.WindowWidth = drawingPanel.Width;
                setter.Distance = (canvas==null)?distance:canvas.Distance;
                if(setter.ShowDialog()==DialogResult.OK)
                {
                    if (canvas != null)
                    {
                        canvas.Width = setter.WindowWidth;
                        canvas.Height = setter.WindowHeight;
                        canvas.Distance = setter.Distance;
                    }
                    else distance = setter.Distance;
                    drawingPanel.Width = setter.WindowWidth;
                    drawingPanel.Height = setter.WindowHeight;
                }
            }
            Draw();
        }
    }
}