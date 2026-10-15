using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_ConvertDGVToDT
    {
        public static DataTable DGVToDT(DataGridView dgv)
        {
            try
            {
                DataTable dt = new DataTable();

                // 1. สร้างคอลัมน์ (Columns) ใน DataTable เลียนแบบจาก DataGridView
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    // ใช้ชื่อคอลัมน์ (Name) และประเภทข้อมูลเป็น string ไว้ก่อนเพื่อความยืดหยุ่น
                    dt.Columns.Add(col.Name, typeof(string));
                }

                // 2. วนลูปดึงข้อมูลจากแต่ละแถว (Rows)
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // ข้ามแถวเปล่าแถวสุดท้ายที่ระบบเปิดไว้ให้ผู้ใช้คลิกพิมพ์เพิ่มข้อมูลใหม่
                    if (row.IsNewRow) continue;

                    // ดึงเฉพาะแถวที่ไม่ได้ถูกซ่อนจากการค้นหา (Visible = true) 
                    // *หมายเหตุ: ถ้าต้องการดึงทุกแถวแม้จะถูกซ่อนอยู่ ให้ลบเงื่อนไข if นี้ออกได้เลยครับ
                    if (!row.Visible) continue;

                    DataRow dr = dt.NewRow();

                    // 3. วนลูปใส่ข้อมูลทีละช่อง (Cells) ในแถวนั้น ๆ
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        // ตรวจสอบค่าว่างป้องกันการเกิด Error (NullReferenceException)
                        dr[i] = row.Cells[i].Value ?? DBNull.Value;
                    }

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch
            {
                return null!;
            }
           
        }
    }
}
