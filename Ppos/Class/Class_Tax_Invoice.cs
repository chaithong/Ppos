using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Ppos.Class
{
    internal class Class_Tax_Invoice
    {
        public static string Generate(string type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        // ต้องนับที่ head
                        cmd_sqlite.CommandText = @"SELECT printf('%04d',count(ih.trx_no)+1) from Invoice_Head ih
                                                   where date(ih.created_date) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt_running = new System.Data.DataTable();
                        dt_running.Load(reader);
                        if (dt_running.Rows.Count > 0)
                        {
                            DateTime targetDate = DateTime.Now;
                            string julianDateShort = $"{targetDate:yy}{targetDate.DayOfYear:D3}";
                            return Class_Parameter.store_no + julianDateShort + type + dt_running.Rows[0][0].ToString()!;
                        }
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
