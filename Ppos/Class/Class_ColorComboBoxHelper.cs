using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ppos.Class
{
    public static class ColorComboBoxHelper
    {
        public static void Initialize(ComboBox cbo)
        {
            cbo.DrawMode = DrawMode.OwnerDrawFixed;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.ItemHeight = 24; // ปรับความสูงช่องสีให้กดง่าย

            cbo.Items.Clear();

            // 🎨 กำหนดเฉพาะ "สีหลัก" ที่ต้องการให้แสดงใน ComboBox
            string[] mainColors = new string[]
            {
                "White",      // ขาว
                "Black",      // ดำ               
                "Silver",       // เทา
                "Salmon",        // แดง
                "Lime",
                "LightGreen",// เขียว
                "Blue",       // น้ำเงิน
                "Yellow",     // เหลือง
                "Orange",     // ส้ม
                "Purple",     // ม่วง
                "Pink",       // ชมพู
                "Brown",      // น้ำตาล
                "Cyan"        // ฟ้า / เขียวอมฟ้า
            };

            // แอดสีหลักเข้าไปใน ComboBox
            foreach (string colorName in mainColors)
            {
                cbo.Items.Add(colorName);
            }

            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;

            // ป้องกันการผูก Event ซ้ำหากมีการเรียก Initialize หลายรอบ
            cbo.DrawItem -= ComboBox_DrawItem!;
            cbo.DrawItem += ComboBox_DrawItem!;
        }

        private static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            ComboBox cbo = (ComboBox)sender;
            string colorName = cbo.Items[e.Index]!.ToString()!;
            Color itemColor = Color.FromName(colorName);

            // วาดกล่องสีเต็มขนาด (ไม่แสดงชื่อ)
            Rectangle rectColorBox = new Rectangle(e.Bounds.X +2, e.Bounds.Y+2 , e.Bounds.Width -4 , e.Bounds.Height-4 );

            using (Brush rectBrush = new SolidBrush(itemColor))
            {
                e.Graphics.FillRectangle(rectBrush, rectColorBox);
            }

            e.Graphics.DrawRectangle(Pens.White, rectColorBox);
            e.DrawFocusRectangle();
        }

        public static Color GetSelectedColor(ComboBox cbo)
        {
            if (cbo.SelectedItem == null) return Color.Transparent;
            return Color.FromName(cbo.SelectedItem.ToString()!);
        }
        public static void SetSelectedColor(ComboBox cbo, string colorString)
        {
            if (string.IsNullOrWhiteSpace(colorString)) return;

            try
            {
                Color targetColor;

                // ตรวจสอบว่าเป็นโค้ดสี HEX หรือไม่ (เช่น #FF0000 หรือ #000)
                if (colorString.StartsWith("#"))
                {
                    targetColor = ColorTranslator.FromHtml(colorString);
                }
                else
                {
                    // แปลงจากชื่อสีธรรมดา (เช่น "Red", "Blue")
                    targetColor = Color.FromName(colorString);
                }

                // สแกนหาดัชนี (Index) ของสีใน ComboBox ที่มีค่าสีตรงกัน
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    Color itemColor = Color.FromName(cbo.Items[i]!.ToString()!);

                    // เทียบค่าสีด้วยรหัส ARGB เพื่อความแม่นยำสูงสุด
                    if (itemColor.ToArgb() == targetColor.ToArgb())
                    {
                        cbo.SelectedIndex = i;
                        return; // เจอแล้วให้หยุดลูปทันที
                    }
                }
            }
            catch
            {
                // หาก String ที่ส่งมาไม่ใช่รูปแบบสีที่ถูกต้อง (เช่น ข้อความมั่วๆ) ให้ข้ามไป ไม่ต้องให้โปรแกรมแครช
               // System.Diagnostics.Debug.WriteLine($"ไม่สามารถแปลงค่า '{colorString}' ให้เป็นสีได้");
            }
        }

    }
}
