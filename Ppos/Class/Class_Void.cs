using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Ppos.Class
{
    internal class Class_Void
    {
        public static void update_void(string trx_no ,string id_member,int point_use,int point_increase)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ปรับจำนวนเพิ่ม
                        cmd_sqlite.CommandText = "SELECT ib.item_barcode,ib.qty_small,sum(ib.item_qty) as qty,ib.item_cost_avg "+
                                                   "from Invoice_Body ib "+
                                                   "where ib.void = false and ib.trx_no = '"+trx_no+"' "+
                                                   "group by ib.item_barcode ,ib.qty_small ,ib.item_cost_avg ";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Class_Item_Adjust.Increase(
                                    dt.Rows[i]["item_barcode"].ToString()!,
                                    dt.Rows[i]["qty_small"].ToString()!,
                                    dt.Rows[i]["qty"].ToString()!,
                                    dt.Rows[i]["item_cost_avg"].ToString()!,
                                    "ยกเลิกบิล",
                                    trx_no);
                            }
                        }

      
                        // คืนแต้มที่ใช้
                        if(point_use > 0 && id_member != string.Empty)
                        {
                            Class_Member_Detail.increase_point(id_member,
                                      0,
                                      0,
                                      0,
                                      point_use,
                                      "คืนแต้ม",
                                      trx_no);
                        }
       
                        // ดึงแต้มที่ได้คืนมา
                        if (point_increase >0 && id_member != string.Empty)
                        {
                            Class_Member_Detail.decrease_point(id_member,
                                      0,
                                      0,
                                      0,
                                      point_increase,
                                      "ดึงแต้ม",
                                      trx_no);
                        }
                       

                        // ปรับสถานะ invoice head

                        cmd_sqlite.CommandText = "UPDATE Invoice_Head SET status = 'V', " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "void_date = datetime('now', 'localtime') " +
                                                    "WHERE trx_no = '" + trx_no+"'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
