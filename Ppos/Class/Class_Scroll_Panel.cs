using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    public static class Class_Scroll_Panel
    {
        // ตัวแปรสำหรับจำสถานะ (ใช้ร่วมกันในการลาก)
        public static bool isScrolling = false;
        private static Point startMousePoint = new Point(0, 0);
        private static Point startScrollPoint = new Point(0, 0);
        private static Panel targetPanel;

        /// <summary>
        /// เปิดใช้งานระบบคลิกลาก Scroll สำหรับ Panel และวัตถุภายในทั้งหมด
        /// </summary>
        public static void EnableDragScroll(Panel panel)
        {
            if (panel == null) return;

            targetPanel = panel;
            targetPanel.AutoScroll = true; // เปิด AutoScroll เสมอ

            // ผูก Event ให้ Panel หลัก
            RegisterEvents(targetPanel);

            // วนลูปผูก Event ให้ทุก Object ย่อยที่อยู่ใน Panel ณ ขณะนั้น
            foreach (Control ctrl in targetPanel.Controls)
            {
                if(ctrl is not DataGridView)
                {
                    RegisterEvents(ctrl);
                    foreach (Control control in ctrl.Controls)
                    {
                        if (control is not DataGridView)
                        {
                            RegisterEvents(control);
                            foreach (Control control2 in control.Controls)
                            {
                                if (control2 is not DataGridView)
                                {
                                    RegisterEvents(control2);
                                    foreach (Control control3 in control2.Controls)
                                    {
                                        if (control3 is not DataGridView)
                                        {
                                            RegisterEvents(control3);
                                            /*foreach (Control control4 in control3.Controls)
                                            {
                                                if (control4 is not DataGridView)
                                                {
                                                    RegisterEvents(control4);
                                                }
                                                   
                                            }*/
                                        }
                                           
                                        
                                    }
                                }
                                   
                            }
                        }
                           
                    }
                }
               
            }
        }

        /// <summary>
        /// ผูก Event ให้กับ Control ตัวใหม่ที่เพิ่งเพิ่มเข้ามาทีหลัง
        /// </summary>
        public static void RegisterEvents(Control ctrl)
        {
            if (ctrl == null)
            {
                return;
            }           
            // ลบ Event เก่าออกก่อนเพื่อป้องกันการผูกซ้ำ (หากมีการเรียกฟังก์ชันซ้ำ)
            ctrl.MouseDown -= Common_MouseDown!;
            ctrl.MouseMove -= Common_MouseMove!;
            ctrl.MouseUp -= Common_MouseUp!;

            // ผูก Event ใหม่
            ctrl.MouseDown += Common_MouseDown!;
            ctrl.MouseMove += Common_MouseMove!;
            ctrl.MouseUp += Common_MouseUp!;
        }

        private static void Common_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && targetPanel != null)
            {
                isScrolling = true;
                startMousePoint = Cursor.Position;
                startScrollPoint = new Point(targetPanel.HorizontalScroll.Value, targetPanel.VerticalScroll.Value);
            }
        }

        private static void Common_MouseMove(object sender, MouseEventArgs e)
        {
            if (isScrolling && targetPanel != null)
            {
                int deltaX = Cursor.Position.X - startMousePoint.X;
                int deltaY = Cursor.Position.Y - startMousePoint.Y;

                int newScrollX = startScrollPoint.X - deltaX;
                int newScrollY = startScrollPoint.Y - deltaY;

                if (newScrollX < 0) newScrollX = 0;
                if (newScrollY < 0) newScrollY = 0;

                targetPanel.AutoScrollPosition = new Point(newScrollX, newScrollY);
            }
        }

        private static void Common_MouseUp(object sender, MouseEventArgs e)
        {
            isScrolling = false;
        }

    }
}
