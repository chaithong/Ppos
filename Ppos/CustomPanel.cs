using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos
{
    public class CustomPanel : Panel
    {
      
         // สร้าง Property ให้ปรับความโค้งในหน้า Design ได้
         private int _borderRadius = 10;

         [Category("Appearance")]
         [Description("ปรับความโค้งของมุม Panel")]
         [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
         public int BorderRadius
         {
             get { return _borderRadius; }
             set
             {
                 _borderRadius = value;
                 this.Invalidate(); // สั่งให้วาดหน้าจอใหม่ทันทีเมื่อเปลี่ยนค่า
             }
         }

         // เขียนโค้ดทับเหตุการณ์ตอนวาดหน้าจอ (OnPaint)
         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);

             // เปิดโหมดลดรอยหยักขอบ
             e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

             using (GraphicsPath path = new GraphicsPath())
             {
                 // ตรวจสอบไม่ให้ขนาดมุมโค้งใหญ่เกินขนาดตัว Panel
                 int radius = Math.Min(_borderRadius, Math.Min(this.Width, this.Height) / 2);
                 if (radius <= 0) radius = 1;

                 path.AddArc(0, 0, radius, radius, 180, 90);
                 path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                 path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                 path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                 path.CloseAllFigures();

                 // วาดสีพื้นหลัง
                 using (SolidBrush brush = new SolidBrush(this.BackColor))
                 {
                     e.Graphics.FillPath(brush, path);
                 }

                 // ตัดขอบเขต Panel ให้โค้งจริง (ช่วยให้ปุ่มหรือของข้างในไม่ทะลุมุมโค้งออกมา)
                 this.Region = new Region(path);
             }
         }
    }
}
