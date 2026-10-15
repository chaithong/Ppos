using System;
using System.Globalization;
using System.Text;
using Hardware.Info;

namespace Ppos.Class
{
    internal class Class_Expiry_Date
    {
        // ตรวจสอบแค่วันหมดอายุ
        public static bool Check_EXP()
        {
            try
            {
                CultureInfo cultures = new CultureInfo("en-US");

                // อ่านค่าบรรทัดล่างสุด และวันที่หมดอายุอยู่หลังสุด
                string TO_DATE = Class_Base64.RC_Base64ToString(File.ReadLines(Class_Parameter.RCtxt).Last()).Split("|")[4];
                // แปลงจาก ปีเดือนวัน เป็น วัน - เดือน - ปี
                TO_DATE = TO_DATE.Substring(6, 2) + "-" + TO_DATE.Substring(4, 2) + "-" + TO_DATE.Substring(0, 4);

                // วันใช้ได้ต้องมากกว่าหรือเท่ากับวันปัจจุบัน
                if (DateTime.Parse(TO_DATE) >= DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures)))
                {
                    // ยังมีเวลาใช้งาน
                    return true;
                }
                else
                {
                    // เวลาใช้งานหมด
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
