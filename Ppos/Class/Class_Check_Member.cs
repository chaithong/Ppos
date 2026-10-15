using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Check_Member
    {
        public static bool Phone(string phone, string id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT phone from Member where status = 1 " +
                                                 "and phone = '" + phone + "' ";
                        if (id != "")
                        {
                            cmd_sqlite.CommandText += "and id <> " + id;
                        }
                        var e = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(e);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(
                                "เบอร์โทร : " + phone + Environment.NewLine +
                                "มีอยู่แล้ว กรุณาใช้เบอร์ใหม่",
                                "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
