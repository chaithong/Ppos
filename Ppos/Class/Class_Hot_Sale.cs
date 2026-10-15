using QRCoder.Core.Renderers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;


namespace Ppos.Class
{
    internal class Class_Hot_Sale
    {
        public static void hot_sale()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // 
                        cmd_sqlite.CommandText = @"SELECT ib.small_barcode,ib.item_barcode,ib.item_code,ib.item_name ,sum(ib.item_qty)
                                                   from Invoice_Body ib 
                                                   where ib.void = false
                                                   and date(ib.created_date) >= date('now', 'localtime', '-" + Class_Parameter.hotkey_hot_sale_back_date+@" days')
                                                   group by ib.small_barcode,ib.item_barcode,ib.item_code,ib.item_name 
                                                   order by sum(ib.item_qty) desc
                                                   LIMIT "+Class_Parameter.hotkey_hot_sale_limit;

                        var er = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            cmd_sqlite.CommandText = @"delete from Item_Hotkey where pag = 5";
                            cmd_sqlite.ExecuteNonQuery();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey (created_by,created_date,updated_by,updated_date,pag,item_code,small_barcode,barcode,column,row)
                                                   VALUES('" + Class_Parameter.User_Login + "',datetime('now', 'localtime'), '', '',5,'" + dt.Rows[i]["item_code"] + "','" + dt.Rows[i]["small_barcode"] + "','" + dt.Rows[i]["item_barcode"] + "',0,0 )";
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
