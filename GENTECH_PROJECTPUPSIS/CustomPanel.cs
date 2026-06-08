using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GENTECH_PROJECTPUPSIS
{
    public class CustomPanel : Panel
    {
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;


        public CustomPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(200, 100);
        }

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }
        public float GradientAngle
        {
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); }
        }
        public Color GradientTopColor
        {
            get => gradientTopColor;
            set { gradientTopColor = value; this.Invalidate(); }
        }
        public Color GradientBottomColor
        {
            get => gradientBottomColor;
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        private GraphicsPath GetRoundedRectanglePath(RectangleF rectangle, float radius)
        {
            GraphicsPath grpath = new GraphicsPath();
            grpath.StartFigure();
            grpath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius, radius, 0, 90);
            grpath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            grpath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            grpath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            grpath.CloseFigure();
            return grpath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.GradientTopColor, this.GradientBottomColor, this.GradientAngle);
            Graphics grphcs = e.Graphics;
            grphcs.FillRectangle(brush, this.ClientRectangle);

            RectangleF rectF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath grpath = GetRoundedRectanglePath(rectF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(grpath);
                    e.Graphics.DrawPath(pen, grpath);
                }
            }
            else this.Region = new Region(rectF);
        }

    }
}

