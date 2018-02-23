
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace LaserDetectionSystem
{
    public class MyTab : TabControl
    {
        private static List<WeakReference> __ENCList;

        private bool _BlackColor;

        public bool BlackColor
        {
            get
            {
                return this._BlackColor;
            }
            set
            {
                this._BlackColor = value;
                this.Refresh();
            }
        }

        [DebuggerNonUserCode]
        static MyTab()
        {
            MyTab.__ENCList = new List<WeakReference>();
        }

        public MyTab()
        {
            List<WeakReference> _ENCList = MyTab.__ENCList;
            Monitor.Enter(_ENCList);
            try
            {
                MyTab.__ENCList.Add(new WeakReference(this));
            }
            finally
            {
                Monitor.Exit(_ENCList);
            }
            this._BlackColor = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(44, 136);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle tabRect;
            Rectangle rectangle;
            Point point;
            Size size;
            Point location;
            Point location1;
            StringFormat stringFormat;
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphic = Graphics.FromImage(bitmap);
            try
            {
               
              //  this.SelectedTab.BackColor = Color.FromArgb(50, 50, 50);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error :" + exception.Message);
            }
            graphic.Clear(Color.FromArgb(25, 25, 25));
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(44, 55, 72));
            Size itemSize = this.ItemSize;
            Rectangle rectangle1 = new Rectangle(0, 0, checked(itemSize.Height + 4), this.Height);
            graphic.FillRectangle(solidBrush, rectangle1);
            Pen pen = new Pen(Color.FromArgb(47, 57, 73));
            Point point1 = new Point(checked(this.Width - 1), 0);
            Point point2 = new Point(checked(this.Width - 1), checked(this.Height - 1));
            graphic.DrawLine(pen, point1, point2);
            Pen pen1 = new Pen(Color.FromArgb(14, 78, 169));
            itemSize = this.ItemSize;
            point2 = new Point(checked(itemSize.Height + 1), 0);
            point1 = new Point(checked(this.Width - 1), 0);
            graphic.DrawLine(pen1, point2, point1);
            Pen pen2 = new Pen(Color.FromArgb(14, 78, 169));
            itemSize = this.ItemSize;
            point2 = new Point(checked(itemSize.Height + 3), checked(this.Height - 1));
            point1 = new Point(checked(this.Width - 1), checked(this.Height - 1));
            graphic.DrawLine(pen2, point2, point1);
            Pen pen3 = new Pen(Color.FromArgb(14, 78, 169));
            itemSize = this.ItemSize;
            point2 = new Point(checked(itemSize.Height + 3), 0);
            Size itemSize1 = this.ItemSize;
            point1 = new Point(checked(itemSize1.Height + 3), 999);
            graphic.DrawLine(pen3, point2, point1);
            int tabCount = checked(this.TabCount - 1);
            for (int i = 0; i <= tabCount; i = checked(i + 1))
            {
                if (i != this.SelectedIndex)
                {
                    rectangle = this.GetTabRect(i);
                    location1 = rectangle.Location;
                    int x = checked(location1.X - 2);
                    location = this.GetTabRect(i).Location;
                    point = new Point(x, checked(location.Y - 2));
                    tabRect = this.GetTabRect(i);
                    int width = checked(tabRect.Width + 3);
                    Rectangle tabRect1 = this.GetTabRect(i);
                    size = new Size(width, checked(tabRect1.Height + 1));
                    Rectangle rectangle2 = new Rectangle(point, size);
                    graphic.FillRectangle(new SolidBrush(Color.FromArgb(44, 55, 72)), rectangle2);
                    Pen pen4 = new Pen(Color.FromArgb(25, 91, 183));
                    location1 = new Point(rectangle2.Right, rectangle2.Top);
                    location = new Point(rectangle2.Right, rectangle2.Bottom);
                    graphic.DrawLine(pen4, location1, location);
                    if (this.ImageList == null)
                    {
                        string text = this.TabPages[i].Text;
                        Font font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                        Brush gray = Brushes.Wheat ;
                        RectangleF rectangleF = rectangle2;
                        stringFormat = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        graphic.DrawString(text, font, gray, rectangleF, stringFormat);
                    }
                }
                else
                {
                    rectangle1 = this.GetTabRect(i);
                    point2 = rectangle1.Location;
                    int num = checked(point2.X - 2);
                    point1 = this.GetTabRect(i).Location;
                    Point location2 = new Point(num, checked(point1.Y - 2));
                    tabRect = this.GetTabRect(i);
                    int width1 = checked(tabRect.Width + 3);
                    Rectangle tabRect2 = this.GetTabRect(i);
                    itemSize1 = new Size(width1, checked(tabRect2.Height - 1));
                    Rectangle rectangle3 = new Rectangle(location2, itemSize1);
                    ColorBlend colorBlend = new ColorBlend();
                    Color[] colorArray = new Color[] { Color.FromArgb(44, 55, 72), Color.FromArgb(44, 55, 72), Color.FromArgb(44, 55, 72) };
                    Color[] colorArray1 = colorArray;
                    if (!this.BlackColor)
                    {
                        // colorArray1[0] = Color.FromArgb(230, 230, 250);
                        colorArray1[0] = Color.FromArgb(21, 90, 187);
                        colorArray1[1] = Color.FromArgb(14, 78, 169);
                        colorArray1[2] = Color.FromArgb(14, 78, 169);
                    }
                    else
                    {
                        colorArray1[0] = Color.FromArgb(21, 90, 187);
                        colorArray1[1] = Color.FromArgb(18, 87, 184);
                        colorArray1[2] = Color.FromArgb(24, 92, 190);
                    }
                    colorBlend.Colors = colorArray1;
                    colorBlend.Positions = new float[] { 0f, 0.5f, 1f };
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle3, Color.Red, Color.Red, 90f)
                    {
                        InterpolationColors = colorBlend
                    };
                    graphic.FillRectangle(linearGradientBrush, rectangle3);
                    graphic.SmoothingMode = SmoothingMode.HighQuality;
                    Point[] pointArray = new Point[3];
                    itemSize1 = this.ItemSize;
                    int height = checked(itemSize1.Height - 3);
                    rectangle = this.GetTabRect(i);
                    location2 = rectangle.Location;
                    point2 = new Point(height, checked(location2.Y + 20));
                    pointArray[0] = point2;
                    itemSize = this.ItemSize;
                    int height1 = checked(itemSize.Height + 4);
                    point1 = this.GetTabRect(i).Location;
                    point = new Point(height1, checked(point1.Y + 14));
                    pointArray[1] = point;
                    size = this.ItemSize;
                    int num1 = checked(size.Height + 4);
                    location = this.GetTabRect(i).Location;
                    location1 = new Point(num1, checked(location.Y + 27));
                    pointArray[2] = location1;
                    Point[] pointArray1 = pointArray;
                    graphic.FillPolygon(new SolidBrush(Color.FromArgb(44, 55, 72)), pointArray1);
                    graphic.DrawPolygon(new Pen(Color.FromArgb(14, 78, 169)), pointArray1);
                    if (this.ImageList == null)
                    {
                        string str = this.TabPages[i].Text;
                        Font font1 = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                        SolidBrush solidBrush1 = new SolidBrush(this.TabPages[i].ForeColor);
                        RectangleF rectangleF1 = rectangle3;
                        stringFormat = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        graphic.DrawString(str, font1, solidBrush1, rectangleF1, stringFormat);
                    }
                }
            }
            Pen pen5 = new Pen(Color.FromArgb(14, 78, 169));
            size = this.ItemSize;
            rectangle = new Rectangle(0, 0, checked(size.Height + 3), checked(this.Height - 1));
            graphic.DrawRectangle(pen5, rectangle);
            Graphics graphics = e.Graphics;
            object[] objectValue = new object[] { RuntimeHelpers.GetObjectValue(bitmap.Clone()), 0, 0 };
           Microsoft.VisualBasic.CompilerServices. NewLateBinding.LateCall(graphics, null, "DrawImage", objectValue, null, null, null, true);
            graphic.Dispose();
            bitmap.Dispose();
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }
    }
}
