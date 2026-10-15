using System;
using System.Globalization;
using System.Data;
using System.Data.SQLite;
using Hardware.Info;
using System.Text;

namespace Ppos.Class
{
    internal class Class_File_Data
    {
        public static bool Complete()
        {
            try
            {
                CultureInfo cultures = new CultureInfo("en-US");


                // ตรวจสอบถ้ามีไฟล์ครบแล้ว
                if (File.Exists(Class_Parameter.STtxt)  // ต้องมี ไฟล์ ST
                 && File.ReadAllLines(Class_Parameter.STtxt).Length == 1  // ไฟล์ ST ต้องมีข้อมูล 1 บรรทัด
                 && File.Exists(Class_Parameter.RCtxt)   // ต้องมี ไฟล์ RC
                 && File.ReadAllLines(Class_Parameter.RCtxt).Length > 0  // ไฟล์ RC ต้องมีข้อมูล                
                 && File.Exists(Form_Login.path + @"\database.db") // ต้องมี Document\Ppos\database.db
                    )
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // วันที่เริ่มในไฟล์ ST
                            string ST_DATE = Class_Base64.ST_String();
                            // เปลี่ยนเป็น ปี - เดือน - วัน
                            ST_DATE = ST_DATE.Substring(0, 4) + "-" + ST_DATE.Substring(4, 2) + "-" + ST_DATE.Substring(6, 2);
                            // วันที่ใน ST ต้องน้อยกว่าหรือเท่ากับ วันที่เครื่อง
                           
                            if (DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd", cultures)) >= DateTime.Parse(ST_DATE))
                            {
                                // ดึงข้อมูล code ใน connection
                                cmd_sqlite.CommandText = "select Code From Connection";
                                string dt = "dtcode";
                                using (var reader = cmd_sqlite.ExecuteReader())
                                {                                    
                                    while (reader.Read())
                                    {                                 
                                       dt = reader["Code"].ToString()!;
                                    }
                                }
                                // ดึง srmb
                                string srmb ="srmb";
                                IHardwareInfo hardwareInfo = new HardwareInfo();
                                hardwareInfo.RefreshMotherboardList();
                                ///// ถ้ามีข้อมูล mb ใน list
                                if (hardwareInfo.MotherboardList.Count > 0)
                                {
                                    // เก็บไว้ตรวจสอบ
                                    srmb = hardwareInfo.MotherboardList[0].SerialNumber.Replace("/", "");
                                }
                                // วันที่ใน ST ต้องเท่ากับ วันที่ใน tabel connection
                                if (srmb == dt)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                // มีอันในอันหนึ่ง ไม่ครบ
                else if (File.Exists(Class_Parameter.RCtxt)   // ไฟล์ RC
                      || File.Exists(Class_Parameter.STtxt)  // ไฟล์ ST
                      || File.Exists(Form_Login.path + @"\database.db") // Document\Ppos\database.db
                        )
                {
                    // มีแค่บ้างอัน
                    return false;
                }
                else // เปิดครั้งแรก ไม่มีไฟล์เลย
                {
                    return true;
                }              
            }
            catch
            {
                return false;
            }
        }
    }
}
