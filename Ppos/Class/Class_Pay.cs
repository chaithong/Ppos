using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Ppos.Class
{
    internal class Class_Pay
    {
        public static void update_pay( double cash,double transfer, int point, double change)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ส่วนลด แต้ม
                        if(point >0 && price_net_effective_member() >0)
                        {
                           
                            // update discount_point
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp SET discount_point = " + point / price_net_effective_member() + " * price_net " +
                                                     "WHERE void = false and hole = false and effective_member = true";
                            cmd_sqlite.ExecuteNonQuery();

                            // update price_net
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp SET price_net =  price_net - discount_point " +
                                                    "WHERE void = false and hole = false and effective_member = true";
                            cmd_sqlite.ExecuteNonQuery();
                        }
                        // ส่วนลดปัดเศษ
                        double p_net = price_net();
               
                        if (Form_Sale.discount_round > 0 && p_net > 0)
                        {

                            // update discount_round
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp SET discount_round = " + Form_Sale.discount_round / p_net + " * price_net " +
                                                     "WHERE void = false and hole = false ";
                            cmd_sqlite.ExecuteNonQuery();


                            // update price_net
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp SET price_net =  price_net - discount_round " +
                                                    "WHERE void = false and hole = false ";
                            cmd_sqlite.ExecuteNonQuery();
                        }
                        // ภาษี
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set "+
                                                  "price_non_vat = case when sale_vat = false then price_net else 0 end, "+
                                                  "price_vat = case when sale_vat = true then price_net / ("+((Convert.ToDouble(Class_Parameter.vat_rate) / 100)+1)+") else 0 end, "+
                                                  "vat = case when sale_vat = true then price_net / "+ ((Convert.ToDouble(Class_Parameter.vat_rate) / 100) + 1) + " * "+ (Convert.ToDouble(Class_Parameter.vat_rate) / 100) + " else 0 end "+
                                                  "where void = false and hole = false";
                        cmd_sqlite.ExecuteNonQuery();

                        string trx_no = Class_Tax_Invoice.Generate("0");
                        // adjust qty
                        cmd_sqlite.CommandText = @"SELECT ibt.item_barcode,ibt.qty_small,sum(ibt.item_qty) as qty,ibt.item_cost_avg
                                                   from Invoice_Body_Temp ibt 
                                                   where ibt.void = false and ibt.hole = false
                                                   group by ibt.item_barcode ,ibt.qty_small ,ibt.item_cost_avg  ";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Class_Item_Adjust.Decrease(
                                    dt.Rows[i]["item_barcode"].ToString()!,
                                    dt.Rows[i]["qty_small"].ToString()!,
                                    dt.Rows[i]["qty"].ToString()!,
                                    dt.Rows[i]["item_cost_avg"].ToString()!,
                                    "บิลขาย",
                                    trx_no
                                    );
                            }
                        }

                        // update point member
                        if(Form_Sale.id_member != "")
                        {
                            // ถ้าใช้ point จะลด point
                            if (point > 0)
                            {
                                Class_Member_Detail.decrease_point(Form_Sale.id_member,
                                        price_net(),
                                        price_net_ineffective_member(),
                                        price_net_effective_member(),
                                        point,
                                        "ใช้แต้ม",
                                        trx_no);
                            }
                            // ถ้ามีสินค้าที่มีผลกับสมาชิก
                            if (price_net_effective_member() > 0)
                            {
                                // ถ้าผลรวมตามเงื่อนไขสมาชิกแล้วได้มากกว่า 1 แต้ม
                                if (increase_point() > 0)
                                {
                                    Class_Member_Detail.increase_point(Form_Sale.id_member, 
                                        price_net(),
                                        price_net_ineffective_member(), 
                                        price_net_effective_member(),
                                        increase_point(),
                                        "เพิ่มแต้ม",
                                        trx_no);

                                }
                            }
                        }
                        // insert head
                        cmd_sqlite.CommandText = @"insert into Invoice_Head
                                                  (created_by,created_date,updated_by,updated_date,status,trx_no,item_qty,price_sum,id_member,percent_discount_member,point_increase,discount_promotion,discount_member,discount_custom,discount_point,discount_round,price_net,pay_cash,pay_transfer,change,price_non_vat,price_vat,vat,void_date,return_date,trx_no_reference)
                                                  SELECT '"+Class_Parameter.User_Login+@"',
                                                  datetime('now', 'localtime'),
                                                  '',
                                                  '',
                                                  'C',
                                                  '"+trx_no+@"',
                                                  sum(item_qty), 
                                                  sum(item_price_sum),
                                                  id_member,
                                                  percent_discount_member,
                                                  "+ increase_point() + @",
                                                  sum(discount_promotion),
                                                  sum(discount_member),
                                                  sum(discount_custom),
                                                  sum(discount_point),
                                                  sum(discount_round),
                                                  sum(price_net),
                                                  "+cash+ @",
                                                  "+transfer+@",
                                                  "+change+@",
                                                  sum(price_non_vat ), 
                                                  sum(price_vat),
                                                  sum(vat),
                                                  null,
                                                  null,
                                                  ''
                                                  FROM Invoice_Body_Temp
                                                  WHERE void = false and hole = false";
                        cmd_sqlite.ExecuteNonQuery();

                        // insert body
                        cmd_sqlite.CommandText = @"insert into Invoice_Body 
                                                   (created_by,created_date,updated_by,updated_date,trx_no,void,return,small_barcode,item_barcode,item_code,item_name,item_qty,item_unit,item_price,item_price_sum,item_cost_avg,small_qty,qty_small,pro_id,pro_type,pro_desc,criterion_type,criterion_value,offer_type,offer_value,discount_type,repeat,discount_promotion,id_member,percent_discount_member,discount_member,discount_custom,discount_point,discount_round,price_net,price_non_vat,price_vat,vat,sale_vat,premium,effective_member)
                                                  SELECT created_by, created_date, updated_by, updated_date,'"+trx_no+ @"', void, return, small_barcode, item_barcode, item_code, item_name, item_qty, item_unit, item_price, item_price_sum,item_cost_avg, small_qty, qty_small, pro_id, pro_type, pro_desc, criterion_type, criterion_value, offer_type, offer_value, discount_type, repeat, discount_promotion, id_member, percent_discount_member, discount_member, discount_custom, discount_point, discount_round, price_net, price_non_vat, price_vat, vat, sale_vat, premium, effective_member
                                                  FROM Invoice_Body_Temp
                                                  WHERE hole = false";
                        cmd_sqlite.ExecuteNonQuery();

                        // ลบ temp
                        cmd_sqlite.CommandText = @"DELETE from Invoice_Body_Temp WHERE hole = false";
                        cmd_sqlite.ExecuteNonQuery();

                        // ขายล่าสุด
                        Class_Last_Sale.last_sale();
                        // ขายดี
                        Class_Hot_Sale.hot_sale();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static double price_net_effective_member()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT                                               
                                                   COALESCE(sum(ibt.price_net),0)
                                                   from Invoice_Body_Temp ibt 
                                                   where ibt.void = false and ibt.hole = false and ibt.effective_member = true";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            return Convert.ToDouble(dt.Rows[0][0]);
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double price_net_ineffective_member()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT                                               
                                                   COALESCE(sum(ibt.price_net),0)
                                                   from Invoice_Body_Temp ibt 
                                                   where ibt.void = false and ibt.hole = false and ibt.effective_member = false";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            return Convert.ToDouble(dt.Rows[0][0]);
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double price_net()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT                                               
                                                   COALESCE(sum(ibt.price_net),0)
                                                   from Invoice_Body_Temp ibt 
                                                   where ibt.void = false and ibt.hole = false ";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            return Convert.ToDouble(dt.Rows[0][0]);
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        
        public static int increase_point()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT sale_per_point                                              
                                                   from Member 
                                                   where id = " + Form_Sale.id_member;

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            if (double.TryParse(dt.Rows[0][0].ToString(),out double result))
                            {
                                if(result > 0)
                                {
                                    return Convert.ToInt32(Math.Floor(Math.Round(price_net_effective_member() / result, 2)));

                                }

                            }
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
       
    }
}
