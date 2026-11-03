using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YourProjectNamespace // เปลี่ยนให้ตรงกับ Namespace ของโปรเจกต์คุณ
{
    public static class ControlHelper
    {
        // เรียกใช้ Windows API เพื่อเปิด-ปิดการวาดหน้าต่าง (ช่วยลดอาการกระตุกอย่างเด็ดขาด)
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 11;

        /// <summary>
        /// จัดกึ่งกลาง รองรับ Scroll และเปิดระบบลดการกระตุกขั้นสูงสุดสำหรับแผงที่มีคอนโทรลจำนวนมาก
        /// </summary>
        public static void SetupCenterWithScroll(Panel parentPanel, Control childControl)
        {
            // 1. เปิด DoubleBuffered ให้ Panel หลัก
            EnableDoubleBuffer(parentPanel);

            // 2. ไล่เปิด DoubleBuffered ให้คอนโทรลทุกตัวภายในแบบลึกทุกชั้น (Recursive)
            EnableDoubleBufferForAll(childControl);

            parentPanel.AutoScroll = true;
            childControl.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            parentPanel.Resize += (sender, e) =>
            {
                if (parentPanel.IsDisposed || childControl.IsDisposed) return;

                // หยุดการวาดหน้าต่างของ Form หลักชั่วคราว (เพื่อไม่ให้ตาเราเห็นตอนระบบกำลังขยับคอนโทรล)
                Form parentForm = parentPanel.FindForm();
                if (parentForm != null && parentForm.IsHandleCreated)
                {
                    SendMessage(parentForm.Handle, WM_SETREDRAW, false, 0);
                }

                parentPanel.SuspendLayout();

                int scrollX = parentPanel.HorizontalScroll.Value;
                int scrollY = parentPanel.VerticalScroll.Value;

                parentPanel.AutoScrollPosition = new Point(0, 0);

                int newX = (parentPanel.ClientSize.Width - childControl.Width) / 2;
                int newY = (parentPanel.ClientSize.Height - childControl.Height) / 2;

                if (newX < 0) newX = 0;
                if (newY < 0) newY = 0;

                childControl.Location = new Point(newX, newY);

                parentPanel.HorizontalScroll.Value = Math.Min(scrollX, parentPanel.HorizontalScroll.Maximum);
                parentPanel.VerticalScroll.Value = Math.Min(scrollY, parentPanel.VerticalScroll.Maximum);

                parentPanel.ResumeLayout(false);

                // เปิดการวาดหน้าต่างกลับมา และสั่ง Refresh ทีเดียวแบบนุ่มนวล
                if (parentForm != null && parentForm.IsHandleCreated)
                {
                    SendMessage(parentForm.Handle, WM_SETREDRAW, true, 0);
                    parentForm.Refresh(); // สั่งให้ทุกคอนโทรลวาดตัวพร้อมกันในจังหวะเดียว
                }
            };
        }

        /// <summary>
        /// สั่งเปิด DoubleBuffered ให้กับคอนโทรลหลัก และคอนโทรลลูกทั้งหมดที่อยู่ข้างในแบบอัตโนมัติ
        /// </summary>
        public static void EnableDoubleBufferForAll(Control parent)
        {
            if (parent == null) return;

            EnableDoubleBuffer(parent);

            foreach (Control child in parent.Controls)
            {
                EnableDoubleBufferForAll(child); // ค้นหาลึกลงไปในกรณีมี Panel ซ้อน Panel
            }
        }

        /// <summary>
        /// เปิด DoubleBuffered บนคอนโทรลเดี่ยวผ่าน Reflection
        /// </summary>
        public static void EnableDoubleBuffer(Control control)
        {
            try
            {
                PropertyInfo doubleBufferProperty = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)!;

                if (doubleBufferProperty != null)
                {
                    doubleBufferProperty.SetValue(control, true, null);
                }
            }
            catch { }
        }
    }
}
