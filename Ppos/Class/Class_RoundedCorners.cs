using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_RoundedCorners
    {
        public static Bitmap CreateRoundedCorners(Bitmap image, int cornerRadius)
        {
            try
            {
                // สร้าง Bitmap แผ่นใหม่ที่มีขนาดเท่าเดิมและรองรับความโปร่งใส (Alpha Channel)
                Bitmap roundedImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                using (Graphics g = Graphics.FromImage(roundedImage))
                {
                    // ตั้งค่าให้ภาพเนียนราบรื่น ไม่เป็นรอยหยัก
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    // เคลียร์พื้นหลังให้โปร่งใสทั้งหมด (เหมือนพื้นหลังไฟล์ PNG)
                    g.Clear(Color.Transparent);

                    // สร้างเส้นทาง (Path) เพื่อกำหนดขอบเขตมุมโค้ง
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int diameter = cornerRadius * 2;
                        Rectangle bounds = new Rectangle(0, 0, image.Width, image.Height);

                        // วาดมุมโค้งทั้ง 4 มุม
                        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                        path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y, diameter, diameter, 270, 90);
                        path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y + bounds.Height - diameter, diameter, diameter, 0, 90);
                        path.AddArc(bounds.X, bounds.Y + bounds.Height - diameter, diameter, diameter, 90, 90);
                        path.CloseAllFigures();

                        // กำหนดให้วาดภาพเฉพาะภายในขอบเขตของเส้นทางที่สร้างไว้
                        g.SetClip(path);
                        g.DrawImage(image, bounds);
                    }
                }

                return roundedImage;
            }
            catch
            {
                return null!;
            }

        }
    }
}
