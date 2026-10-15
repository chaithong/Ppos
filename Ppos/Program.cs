using Ppos.Class;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Ppos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {

                if (Priorprocess() != null)
                {
                    // Class_MessageBox.MessageBox_Alert(QPOS_Management.Properties.Resources.gif_error, "แจ้งเตือน", "โปรแกรมกำลังทำงานอยู่ !", "", Color.Lime, "ตกลง", Color.Red);                 
                    MessageBox.Show("โปรแกรมกำลังทำงาน !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*  if (!Class_File_Data.Complete())
                 {
                     MessageBox.Show("ผิดพลาด !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }*/
                // ตั้งค่าให้เธรดปัจจุบันและเธรดในอนาคตใช้ปี ค.ศ. (en-US) เป็นค่าเริ่มต้น
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

                // สร้าง path
                if (!System.IO.Directory.Exists(Form_Login.path))
                {
                    System.IO.Directory.CreateDirectory(Form_Login.path);
                }
                // สร้าง DB
                Class_Create_DB.Create_DB("20260000", "CODETEST");

                // สร้าง path image item
                if (!System.IO.Directory.Exists(Form_Login.item_path))
                {
                    System.IO.Directory.CreateDirectory(Form_Login.item_path);
                }
                // สร้าง path image logo
                if (!System.IO.Directory.Exists(Form_Login.logo_path))
                {
                    System.IO.Directory.CreateDirectory(Form_Login.logo_path);
                }

                ApplicationConfiguration.Initialize();

                if (File.Exists(Form_Login.path + @"\database.db"))
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            try
                            {
                                cmd_sqlite.CommandText = "SELECT status from Setting_Configure where title = 'login_program'";
                                var er = cmd_sqlite.ExecuteReader();
                                DataTable dt = new DataTable();
                                dt.Load(er);
                                if (dt.Rows.Count == 1)
                                {
                                    Class_Parameter.login_program = Convert.ToBoolean(dt.Rows[0]["status"].ToString());
                                }
                              
                            }
                            catch
                            {

                            }
                           
                        }
                    }
                }
                if (Class_Parameter.login_program)
                {
                    Application.Run(new Form_Login());
                }
                else
                {
          
                    Application.Run(new Form_Main());
                }

            }
            catch
            {
                Application.Exit();
            }
           
        }
        public static Process Priorprocess()
        {
            try
            {
      
                Process curr = Process.GetCurrentProcess();
                Process[] procs = Process.GetProcessesByName(curr.ProcessName);
                foreach (Process p in procs)
                {
                    if ((p.Id != curr.Id) && (p.MainModule!.FileName == curr.MainModule!.FileName))
                    {
                        return p;
                    }
                }


                return null!;
            }
            catch
            {
                return null!;
            }

        }
    }
}