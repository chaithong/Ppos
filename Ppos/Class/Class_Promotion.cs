using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Promotion
    {

        public static string Pro_Item(
             string pro_id,
             string pro_type,
             string pro_desc,
             string criterion_type,
             string criterion_value,
             string offer_type,
             string offer_value,
             string discount_type,
             string repeat,
             string date_start,
             string date_end,
             DataTable item_pro,
             DataTable item_premium_pro
            )
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if(pro_id == "") // เพิ่มโปร
                        {
                            // pro
                            cmd_sqlite.CommandText = "INSERT INTO Promotion " +
                                                     "(created_by, created_date, updated_by, updated_date, " +
                                                     "pro_id, pro_type, pro_desc, criterion_type, criterion_value, " +
                                                     "offer_type, offer_value, " +
                                                     "discount_type, repeat, start_datetime, end_datetime, " +
                                                     "mon, tue, wed, thu, fri, sat, sun, status) " +
                                                     "VALUES( " +
                                                     "'" + Class_Parameter.User_Login + "'," +
                                                     "datetime('now', 'localtime')," +
                                                     "''," +
                                                     "''," +
                                                     "(select COALESCE(max(pro_id),0)+1 from Promotion)," +
                                                     "'" + pro_type +"'," +
                                                     "'" + pro_desc + "'," +
                                                     "'" + criterion_type + "'," +
                                                     "'" + criterion_value + "'," +
                                                     "'" + offer_type + "'," +
                                                     "'" + offer_value + "'," +
                                                     "'" + discount_type + "'," +
                                                     "'" + repeat + "'," +
                                                     "'" + date_start + "'," +
                                                     "'" + date_end + "'," +
                                                     "" + Class_Parameter.pro_mon + "," +
                                                     "" + Class_Parameter.pro_tue + "," +
                                                     "" + Class_Parameter.pro_wed + "," +
                                                     "" + Class_Parameter.pro_thu + "," +
                                                     "" + Class_Parameter.pro_fri + "," +
                                                     "" + Class_Parameter.pro_sat + "," +
                                                     "" + Class_Parameter.pro_sun + "," +
                                                     "1)" ;
                            cmd_sqlite.ExecuteNonQuery();

                            cmd_sqlite.CommandText = "select max(pro_id) from Promotion";
                            var e = cmd_sqlite.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(e);

                            // item_pro
                            for (int i = 0;i< item_pro.Rows.Count;i++)
                            {
                               
                                cmd_sqlite.CommandText = "INSERT INTO Promotion_Items " +
                                                   "(created_by,created_date,updated_by,updated_date," +
                                                   "pro_id,pro_type,item_code,item_name,item_price,item_set_qty," +
                                                   "barcode_small,barcode_medium,barcode_large," +
                                                   "status) " +
                                                   "VALUES( " +
                                                   "'" + Class_Parameter.User_Login + "'," +
                                                   "datetime('now', 'localtime')," +
                                                   "''," +
                                                   "''," +
                                                   dt.Rows[0][0].ToString()! + "," +
                                                   "'" + pro_type + "'," +
                                                   item_pro.Rows[i]["item_code_pro"].ToString() + "," +
                                                   "'" + item_pro.Rows[i]["item_name_pro"].ToString() + "'," +
                                                   item_pro.Rows[i]["item_price_pro"].ToString() + "," +
                                                   item_pro.Rows[i]["item_set_qty_pro"].ToString() + "," +
                                                   "'" + item_pro.Rows[i]["item_barcode_small_pro"].ToString() + "'," +
                                                   "'" + item_pro.Rows[i]["item_barcode_medium_pro"].ToString() + "'," +
                                                   "'" + item_pro.Rows[i]["item_barcode_large_pro"].ToString() + "'," +
                                                   "1)";
                                cmd_sqlite.ExecuteNonQuery();

                            }
                            // item_premium_pro
                            for (int i = 0; i < item_premium_pro.Rows.Count; i++)
                            {

                                cmd_sqlite.CommandText = "INSERT INTO Promotion_Items_Premium " +
                                                   "(created_by,created_date,updated_by,updated_date," +
                                                   "pro_id,pro_type,item_code,item_name,item_price," +
                                                   "barcode_small,barcode_medium,barcode_large," +
                                                   "status) " +
                                                   "VALUES( " +
                                                   "'" + Class_Parameter.User_Login + "'," +
                                                   "datetime('now', 'localtime')," +
                                                   "''," +
                                                   "''," +
                                                   dt.Rows[0][0].ToString()! + "," +
                                                   "'" + pro_type + "'," +
                                                   item_premium_pro.Rows[i]["item_code_premium_pro"].ToString() + "," +
                                                   "'" + item_premium_pro.Rows[i]["item_name_premium_pro"].ToString() + "'," +
                                                   item_premium_pro.Rows[i]["item_price_premium_pro"].ToString() + "," +
                                                   "'" + item_premium_pro.Rows[i]["item_premium_barcode_small_pro"].ToString() + "'," +
                                                   "'" + item_premium_pro.Rows[i]["item_premium_barcode_medium_pro"].ToString() + "'," +
                                                   "'" + item_premium_pro.Rows[i]["item_premium_barcode_large_pro"].ToString() + "'," +
                                                   "1)";
                                cmd_sqlite.ExecuteNonQuery();

                            }

                            return dt.Rows[0][0].ToString()!;
                        }
                        else // แก้ไขโปร
                        {
                            // update promotion
                            cmd_sqlite.CommandText = "UPDATE Promotion SET " +
                                       "updated_date = datetime('now', 'localtime'), " +
                                       "updated_by = '" + Class_Parameter.User_Login + "', " +
                                       "pro_desc='"+pro_desc+"',  " +
                                       "criterion_type='"+criterion_type+"',  " +
                                       "criterion_value ="+criterion_value+",  " +
                                       "offer_type ='"+offer_type+"',  " +
                                       "offer_value ="+offer_value+",  " +
                                       "discount_type ='"+discount_type+"', " +
                                       "repeat ='"+repeat+"',  " +
                                       "start_datetime ='"+date_start+"',  " +
                                       "end_datetime ='"+date_end+"',  " +
                                       "mon ="+Class_Parameter.pro_mon+",  " +
                                       "tue ="+Class_Parameter.pro_tue+",  " +
                                       "wed ="+Class_Parameter.pro_wed+",  " +
                                       "thu ="+Class_Parameter.pro_thu+",  " +
                                       "fri ="+Class_Parameter.pro_fri+",  " +
                                       "sat ="+Class_Parameter.pro_sat+",  " +
                                       "sun ="+Class_Parameter.pro_sun+" " +
                                       "where pro_id = "+pro_id;

                            cmd_sqlite.ExecuteNonQuery();

                            // item_pro
                            // ลบก่อน
                            cmd_sqlite.CommandText = "DELETE FROM Promotion_Items WHERE pro_id = "+pro_id;
                            cmd_sqlite.ExecuteNonQuery();
                            // เพิ่มใหม่
                            for (int i = 0; i < item_pro.Rows.Count; i++)
                            {

                                cmd_sqlite.CommandText = "INSERT INTO Promotion_Items " +
                                                   "(created_by,created_date,updated_by,updated_date," +
                                                   "pro_id,pro_type,item_code,item_name,item_price,item_set_qty," +
                                                   "barcode_small,barcode_medium,barcode_large," +
                                                   "status) " +
                                                   "VALUES( " +
                                                   "'" + Class_Parameter.User_Login + "'," +
                                                   "datetime('now', 'localtime')," +
                                                   "''," +
                                                   "''," +
                                                   pro_id + "," +
                                                   "'" + pro_type + "'," +
                                                   item_pro.Rows[i]["item_code_pro"].ToString() + "," +
                                                   "'" + item_pro.Rows[i]["item_name_pro"].ToString() + "'," +
                                                   item_pro.Rows[i]["item_price_pro"].ToString() + "," +
                                                   item_pro.Rows[i]["item_set_qty_pro"].ToString() + "," +
                                                   "'" + item_pro.Rows[i]["item_barcode_small_pro"].ToString() + "'," +
                                                   "'" + item_pro.Rows[i]["item_barcode_medium_pro"].ToString() + "'," +
                                                   "'" + item_pro.Rows[i]["item_barcode_large_pro"].ToString() + "'," +
                                                   "1)";
                                cmd_sqlite.ExecuteNonQuery();



                            }
                            // item_premium_pro
                            // ลบก่อน
                            cmd_sqlite.CommandText = "DELETE FROM Promotion_Items_Premium WHERE pro_id = " + pro_id;
                            cmd_sqlite.ExecuteNonQuery();
                            // เพิ่มใหม่
                            if(offer_type == "แถมสินค้า") // ถ้าแก้ไขแล้วไม่มีของแถม
                            {
                                for (int i = 0; i < item_premium_pro.Rows.Count; i++)
                                {

                                    cmd_sqlite.CommandText = "INSERT INTO Promotion_Items_Premium " +
                                                       "(created_by,created_date,updated_by,updated_date," +
                                                       "pro_id,pro_type,item_code,item_name,item_price," +
                                                       "barcode_small,barcode_medium,barcode_large," +
                                                       "status) " +
                                                       "VALUES( " +
                                                       "'" + Class_Parameter.User_Login + "'," +
                                                       "datetime('now', 'localtime')," +
                                                       "''," +
                                                       "''," +
                                                       pro_id + "," +
                                                       "'" + pro_type + "'," +
                                                       item_premium_pro.Rows[i]["item_code_premium_pro"].ToString() + "," +
                                                       "'" + item_premium_pro.Rows[i]["item_name_premium_pro"].ToString() + "'," +
                                                       item_premium_pro.Rows[i]["item_price_premium_pro"].ToString() + "," +
                                                       "'" + item_premium_pro.Rows[i]["item_premium_barcode_small_pro"].ToString() + "'," +
                                                       "'" + item_premium_pro.Rows[i]["item_premium_barcode_medium_pro"].ToString() + "'," +
                                                       "'" + item_premium_pro.Rows[i]["item_premium_barcode_large_pro"].ToString() + "'," +
                                                       "1)";
                                    cmd_sqlite.ExecuteNonQuery();
                                }
                            }
                           
                          return pro_id;
                        }
                        
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
