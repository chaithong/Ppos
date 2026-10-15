using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Ppos
{
    public class CustomGroupBox : GroupBox
    {
        private Color _borderColor = Color.Black;
        private int _borderRadius = 10;
        private int _borderThickness = 1; // ตัวแปรเก็บความหนาเริ่มต้น

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; this.Invalidate(); }
        }

        // เพิ่ม Property ใหม่สำหรับปรับความหนาของเส้น
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value < 1 ? 1 : value; this.Invalidate(); } // ป้องกันไม่ให้ตั้งค่าต่ำกว่า 1
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                new Point(10, 0), this.ForeColor, this.BackColor);

              Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
             Rectangle rect = this.ClientRectangle;
            rect.Y += tSize.Height ;
            rect.Height -= tSize.Height ;

            // คำนวณตำแหน่งเส้นตามความหนาจริง
            float halfThickness = _borderThickness / 2f;
            float x = rect.X + halfThickness;
            float y = rect.Y + halfThickness;
            float width = rect.Width - _borderThickness;
            float height = rect.Height - _borderThickness;

            using (GraphicsPath path = new GraphicsPath())
            {
                if (_borderRadius > 0)
                {
                    path.StartFigure();
                    path.AddArc(x, y, _borderRadius, _borderRadius, 180, 90);
                    path.AddArc(x + width - _borderRadius, y, _borderRadius, _borderRadius, 270, 90);
                    path.AddArc(x + width - _borderRadius, y + height - _borderRadius, _borderRadius, _borderRadius, 0, 90);
                    path.AddArc(x, y + height - _borderRadius, _borderRadius, _borderRadius, 90, 90);
                    path.CloseFigure();

                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        e.Graphics.DrawRectangle(pen, x, y, width, height);
                    }
                }
            }
        }
    }
}
