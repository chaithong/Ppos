using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Text;

namespace Ppos.Class
{
    internal class Class_Sale
    {
        public static void update_hole_temp(bool hole)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp SET hole = " + hole + " " ;
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // update phone ถ้ามีการแก้ไขหรือลบออก
        public static void update_member(string id_member,string discount)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                            "SET id_member = '"+id_member+"', " +
                                                            "percent_discount_member = "+ discount + ", " +
                                                            "updated_date = datetime('now', 'localtime'), " +
                                                            "updated_by = '" + Class_Parameter.User_Login + "' " +
                                                            "where hole = false and void = false";
                        cmd_sqlite.ExecuteNonQuery();

                        if(Convert.ToDouble(discount) >0)
                        {
                            // คำนวนส่วนลดสมาชิก
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                           "SET discount_member = (item_price_sum - discount_promotion) * cast(" + discount + " as real)/cast(100 as real), " +
                                                           "price_net = item_price_sum - discount_promotion - ((item_price_sum - discount_promotion) * cast(" + discount + " as real)/cast(100 as real)) " +
                                                           "where hole = false and void = false and effective_member = true";
                           
                        }
                        else
                        {
                            // คืนค่าส่วนลดสมาชิก
                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                           "SET discount_member = 0, " +
                                                           "price_net = item_price_sum - discount_promotion " +
                                                           "where hole = false and void = false";
                        }
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       // หาค่า id สูงสุดใน temp
        public static int id_invoid_body_temp()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT coalesce(max(id),0) from Invoice_Body_Temp";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);

                        return Convert.ToInt32(dt.Rows[0][0]);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
           
        }
        // หาบิลถ้ามีพักบิล ตอนเริ่มเปิดหน้าขาย
        public static bool hole_invoid_body_temp()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT 1 from Invoice_Body_Temp where hole = true";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                        // จะต้องตรวจสอบ hole bill ด้วย
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
        }
        public static void insert_invoice_body_temp(bool v,bool r,string small_barcode,string item_barcode,
                                               string item_code,string item_name,string item_qty,string item_unit,string item_price,string item_price_sum,string item_cost_avg,
                                               string small_qty,string qty_small,
                                               string pro_id,string pro_type,string pro_desc,
                                               string criterion_type, string criterion_value,
                                               string offer_type, string offer_value,
                                               string discount_type, string repeat,
                                               string discount_promotion,
                                               string id_member, string percent_discount_member,
                                               string discount_member,
                                               string discount_custom,string discount_point, string discount_round,
                                               string price_net,string price_non_vat,string price_vat,string vat, bool sale_vat, bool premium,bool effective_member,bool hole)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"INSERT INTO Invoice_Body_Temp
                                               (created_by,created_date,updated_by,updated_date,
                                               void,return,small_barcode,item_barcode,
                                               item_code,item_name,item_qty,item_unit,item_price,item_price_sum,item_cost_avg,
                                               small_qty,qty_small,
                                               pro_id,pro_type,pro_desc,
                                               criterion_type,criterion_value,
                                               offer_type,offer_value,
                                               discount_type,repeat,
                                               discount_promotion,
                                               id_member,percent_discount_member,
                                               discount_member,
                                               discount_custom,discount_point,discount_round,
                                               price_net,price_non_vat,price_vat,vat,
                                               sale_vat,premium,effective_member,hole)
                                                VALUES( ";
                        cmd_sqlite.CommandText += "'"+ Class_Parameter.User_Login + "', " +
                            "datetime('now', 'localtime'), " +
                            "'', " +
                            "'', " +
                            "" + v + ", " +
                            "" + r + ", " +
                            "'" + small_barcode + "', " +
                            "'" + item_barcode + "', " +
                            "'" + item_code + "', " +
                            "'" + item_name + "', " +
                            "" + item_qty + ", " +
                            "'" + item_unit + "', " +
                            "" + item_price + ", " +
                            "" + item_price_sum + ", " +
                            "" + item_cost_avg + ", " +
                            "" + small_qty + ", " +
                            "" + qty_small + ", " +
                            "'" + pro_id + "', " +
                            "'" + pro_type + "', " +
                            "'" + pro_desc + "', " +
                            "'" + criterion_type + "', " +
                            "'" + criterion_value + "', " +
                            "'" + offer_type + "', " +
                            "'" + offer_value + "', " +
                            "'" + discount_type + "', " +
                            "'" + repeat + "', " +
                            "'" + discount_promotion + "', " +
                            "'" + id_member + "', " +
                            "'" + percent_discount_member + "', " +
                            "'" + discount_member + "', " +
                            "'" + discount_custom + "', " +
                            "'" + discount_point + "', " +
                            "'" + discount_round + "', " +
                            "'" + price_net + "', " +
                            "'" + price_non_vat + "', " +
                            "'" + price_vat + "', " +
                            "'" + vat + "', " +
                            "" + sale_vat + ", " +
                            "" + premium + ", " +
                            "" + effective_member + ", " +
                            "" + hole + "" +
                            ");";
                        Clipboard.SetText(cmd_sqlite.CommandText);
                        cmd_sqlite.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }      
        public static void Pro(string pro_id , 
            string pro_type,
            string criterion_type,
            string criterion_value,
            string offer_type,
            string offer_value,
            string discount_type,
            string repeat,
            string item_code)
        {
            try
            {
                //โปรต่อสินค้า
                if (pro_type == Class_Parameter.pro_base_item)
                {
                    // จำนวน
                    if (criterion_type == Class_Parameter.criterion_type_qty)
                    {
                        // ลดราคา
                        if (offer_type == Class_Parameter.offer_type_discount)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า จำนวน ลดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(offer_value) * Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());
                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);

                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code ,pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า จำนวน ลดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(criterion_value) * Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรต่อสินค้า จำนวน ลดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = 
                                                Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / 
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) *
                                                Convert.ToDouble(criterion_value);
                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / dis_amount,3)) *
                                                Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า จำนวน ลดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // กำหนดราคา
                        else if (offer_type == Class_Parameter.offer_type_set_value)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า จำนวน กำหนดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) * 
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า จำนวน กำหนดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมมูลค่าเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) *
                                                Convert.ToDouble(criterion_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรต่อสินค้า จำนวน กำหนดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount =
                                                Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) /
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) *
                                                Convert.ToDouble(criterion_value);

                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / dis_amount,3)) *
                                                       ( dis_amount - Convert.ToDouble(offer_value));

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า จำนวน กำหนดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) /
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) * Convert.ToDouble(criterion_value)) -
                                                Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // แถมสินค้า
                        else if (offer_type == Class_Parameter.offer_type_premium)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า จำนวน แถมสินค้า ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่    
                                    int C = pro_base_set_item(pro_id, criterion_value, criterion_type);
                                    if (C > 0 && pro_base_set_premium(pro_id, offer_value))
                                    {
                                        double dis = pro_base_dis_premium(pro_id, offer_value,C, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_base_update_0(item_code, pro_id, true);
                                    }

                                }
                                //โปรต่อสินค้า จำนวน แถมสินค้า ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่
                                    int C = pro_base_set_item(pro_id, criterion_value , criterion_type);
                                    if (C > 0 && pro_base_set_premium(pro_id, offer_value))
                                    {
                    
                                        double dis = pro_base_dis_premium(pro_id, offer_value, 1, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_base_update_0(item_code, pro_id, true);
                                    }
                                }
                            }                       
                        }
                    }
                    // มูลค่า
                    else if (criterion_type == Class_Parameter.criterion_type_value)
                    {
                        // ลดราคา
                        if (offer_type == Class_Parameter.offer_type_discount)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า มูลค่า ลดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            double dis_amount = Convert.ToDouble(offer_value) * Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());
                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า มูลค่า ลดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หาจำนวนในมูลค่าเงื่อนไข
                                            double dis_amount = Convert.ToDouble(criterion_value) /
                                               (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()));
                                            // หาส่วนลดในจำนวน
                                             dis_amount = dis_amount * Convert.ToDouble(offer_value);
                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรต่อสินค้า มูลค่า ลดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                               
                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            double dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(criterion_value), 3)) *
                                                Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า มูลค่า ลดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {

                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            double dis_amount = Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // กำหนดราคา
                        else if (offer_type == Class_Parameter.offer_type_set_value)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า มูลค่า กำหนดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมมูลค่าเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) *
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า มูลค่า กำหนดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // จำนวนในเงื่อนไข
                                            double dis_amount = Convert.ToDouble(criterion_value) /
                                                (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()));

                                            // หามูลค่าลดทั้งหมด
                                            dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) *
                                                dis_amount;

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรต่อสินค้า มูลค่า กำหนดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            
                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            double dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(criterion_value), 3)) *
                                                (Convert.ToDouble(criterion_value) - Convert.ToDouble(offer_value));

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                                //โปรต่อสินค้า มูลค่า กำหนดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_base_sum_item(pro_id, item_code);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {

                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            double dis_amount = Convert.ToDouble(criterion_value) - Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_base_update_dis(dt.Rows[0]["item_code"].ToString()!,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_base_update_0(item_code, pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // แถมสินค้า
                        else if (offer_type == Class_Parameter.offer_type_premium)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรต่อสินค้า มูลค่า แถมสินค้า ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่    
                                    int C = pro_base_set_item(pro_id, criterion_value, criterion_type);
                                    if (C > 0 && pro_base_set_premium(pro_id, offer_value))
                                    {
                                        double dis = pro_base_dis_premium(pro_id, offer_value, C, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_base_update_0(item_code, pro_id, true);
                                    }
                                }
                                //โปรต่อสินค้า มูลค่า แถมสินค้า ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่
                                    int C = pro_base_set_item(pro_id, criterion_value, criterion_type);
                                    if (C > 0 && pro_base_set_premium(pro_id, offer_value))
                                    {

                                        double dis = pro_base_dis_premium(pro_id, offer_value, 1, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_base_update_0(item_code, pro_id, true);
                                    }
                                }
                            }                        
                        }
                    }
                }
                //โปรคละสินค้า
                else if (pro_type == Class_Parameter.pro_mix_item)
                {
                    // จำนวน
                    if (criterion_type == Class_Parameter.criterion_type_qty)
                    {
                        // ลดราคา
                        if (offer_type == Class_Parameter.offer_type_discount)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรคละสินค้า จำนวน ลดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {

                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(offer_value) * Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());
                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);

                                        }
                                        else
                                        {
                                            pro_mix_update_0(pro_id, false);
                                        }
                                    }
                                }
                                //โปรคละสินค้า จำนวน ลดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(criterion_value) * Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0(pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรคละสินค้า จำนวน ลดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {

                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount =
                                                Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) /
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) *
                                                Convert.ToDouble(criterion_value);
                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / dis_amount, 3)) *
                                                Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0( pro_id, false);
                                        }
                                    }
                                }
                                //โปรคละสินค้า จำนวน ลดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0( pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // กำหนดราคา
                        else if (offer_type == Class_Parameter.offer_type_set_value)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรคละสินค้า จำนวน กำหนดราคา ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) *
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString());

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0(pro_id, false);
                                        }
                                    }
                                }
                                //โปรคละสินค้า จำนวน กำหนดราคา ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = ((Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString())) -
                                                Convert.ToDouble(offer_value)) *
                                                Convert.ToDouble(criterion_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0( pro_id, false);
                                        }
                                    }
                                }
                            }
                            // ต่อมูลค่า
                            else if (discount_type == Class_Parameter.discount_type_per_value)
                            {
                                //โปรคละสินค้า จำนวน กำหนดราคา ต่อมูลค่า ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount =
                                                Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) /
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) *
                                                Convert.ToDouble(criterion_value);

                                            // หามูลค่าลดรวม โดยไม่คิดเศษ
                                            dis_amount = Math.Floor(Math.Round(Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) / dis_amount, 3)) *
                                                       (dis_amount - Convert.ToDouble(offer_value));

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);
                                        }
                                        else
                                        {
                                            pro_mix_update_0( pro_id, false);
                                        }
                                    }
                                }
                                //โปรคละสินค้า จำนวน กำหนดราคา ต่อมูลค่า ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_mix_sum_item(pro_id);
                                    if (dt is not null)
                                    {
                                        // ถ้าผลรวมจำนวนเข้าเงื่อนไข
                                        if (Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) >= Convert.ToDouble(criterion_value))
                                        {
                                            // หามูลค่าลดทั้งหมด
                                            double dis_amount = (Convert.ToDouble(dt.Rows[0]["sum_price"].ToString()) /
                                                Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()) * Convert.ToDouble(criterion_value)) -
                                                Convert.ToDouble(offer_value);

                                            // เริ่มใส่ค่าส่วนลด
                                            pro_mix_update_dis(pro_id,
                                                                      dt.Rows[0]["sum_price"].ToString()!,
                                                                      dis_amount);

                                        }
                                        else
                                        {
                                            pro_mix_update_0( pro_id, false);
                                        }
                                    }
                                }
                            }
                        }
                        // แถมสินค้า
                        else if (offer_type == Class_Parameter.offer_type_premium)
                        {
                            // ต่อหน่วย
                            if (discount_type == Class_Parameter.discount_type_per_qty)
                            {
                                //โปรคละสินค้า จำนวน แถมสินค้า ต่อหน่วย ทำซ้ำ
                                if (repeat == Class_Parameter.repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่    
                                    int C = pro_mix_set_item(pro_id, criterion_value, criterion_type);
                                    if (C > 0 && pro_mix_set_premium(pro_id, offer_value))
                                    {
                                        double dis = pro_mix_dis_premium(pro_id, offer_value, C, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_mix_update_0( pro_id, true);
                                    }
                                }
                                //โปรคละสินค้า จำนวน แถมสินค้า ต่อหน่วย ไม่ทำซ้ำ
                                else if (repeat == Class_Parameter.not_repeat)
                                {
                                    // หาจำนวนชุดที่จะแถม   // ตรวจสอบว่าของแถมครบหรือไม่
                                    int C = pro_mix_set_item(pro_id, criterion_value, criterion_type);
                                    if (C > 0 && pro_mix_set_premium(pro_id, offer_value))
                                    {

                                        double dis = pro_mix_dis_premium(pro_id, offer_value, 1, discount_type);

                                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                        {
                                            con_sqlite.Open();
                                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                            {
                                                // เริ่มใส่ค่าส่วนลด
                                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                         "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                         "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                         "and void = false and hole = false";
                                                cmd_sqlite.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // คืนค่า ลด
                                        pro_mix_update_0( pro_id, true);
                                    }
                                }
                            }                        
                        }
                    }
                }
                //โปรชุดสินค้า
                else if (pro_type == Class_Parameter.pro_set_item)
                {
                    // ลดราคา
                    if (offer_type == Class_Parameter.offer_type_discount)
                    {
                        // ต่อหน่วย
                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            //โปรชุดสินค้า ลดราคา ต่อหน่วย ทำซ้ำ
                            if (repeat == Class_Parameter.repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if(pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = Convert.ToDouble(offer_value) *
                                     Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()!);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!,dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id,false);
                                }
                            }
                            //โปรชุดสินค้า ลดราคา ต่อหน่วย ไม่ทำซ้ำ
                            else if (repeat == Class_Parameter.not_repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = Convert.ToDouble(offer_value) *
                                        pro_set_set_qty(pro_id);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);
                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                        }
                        // ต่อมูลค่า
                        else if (discount_type == Class_Parameter.discount_type_per_value)
                        {
                            //โปรชุดสินค้า ลดราคา ต่อมูลค่า ทำซ้ำ
                            if (repeat == Class_Parameter.repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = Convert.ToDouble(offer_value) *
                                    pro_set_set_pro(pro_id);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                            //โปรชุดสินค้า ลดราคา ต่อมูลค่า ไม่ทำซ้ำ
                            else if (repeat == Class_Parameter.not_repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = Convert.ToDouble(offer_value);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                        }
                    }
                    // กำหนดราคา
                    else if (offer_type == Class_Parameter.offer_type_set_value)
                    {
                        // ต่อหน่วย
                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            //โปรชุดสินค้า กำหนดราคา ต่อหน่วย ทำซ้ำ
                            if (repeat == Class_Parameter.repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = (Convert.ToDouble(dt.Rows[0]["unit_price"].ToString()!) - Convert.ToDouble(offer_value)) *
                                     Convert.ToDouble(dt.Rows[0]["sum_qty"].ToString()!);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                            //โปรชุดสินค้า กำหนดราคา ต่อหน่วย ไม่ทำซ้ำ
                            else if (repeat == Class_Parameter.not_repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = (Convert.ToDouble(dt.Rows[0]["unit_price"].ToString()!) - Convert.ToDouble(offer_value)) *
                                        pro_set_set_qty(pro_id);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);
                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                        }
                        // ต่อมูลค่า
                        else if (discount_type == Class_Parameter.discount_type_per_value)
                        {
                            //โปรชุดสินค้า กำหนดราคา ต่อมูลค่า ทำซ้ำ
                            if (repeat == Class_Parameter.repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = (pro_set_set_price(pro_id)- Convert.ToDouble(offer_value)) *
                                    pro_set_set_pro(pro_id);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                            //โปรชุดสินค้า กำหนดราคา ต่อมูลค่า ไม่ทำซ้ำ
                            else if (repeat == Class_Parameter.not_repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id))
                                {
                                    DataTable dt = new DataTable();
                                    dt = pro_set_sum_item(pro_id);

                                    double dis_amount = pro_set_set_price(pro_id) - Convert.ToDouble(offer_value);

                                    pro_set_update_dis(pro_id, dt.Rows[0]["sum_price"].ToString()!, dis_amount);

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                        }
                    }
                    // แถมสินค้า
                    else if (offer_type == Class_Parameter.offer_type_premium)
                    {
                        // ต่อหน่วย
                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            //โปรชุดสินค้า แถมสินค้า ต่อหน่วย ทำซ้ำ
                            if (repeat == Class_Parameter.repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id) && pro_set_check_premium(pro_id,offer_value))
                                {                            
                                    double dis = pro_set_dis_premium(pro_id,offer_value, pro_set_set_pro(pro_id),discount_type);
                                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                    {
                                        con_sqlite.Open();
                                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                        {
                                            // เริ่มใส่ค่าส่วนลด
                                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                     "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                     "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                     "and void = false and hole = false";
                                            cmd_sqlite.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                            //โปรชุดสินค้า แถมสินค้า ต่อหน่วย ไม่ทำซ้ำ
                            else if (repeat == Class_Parameter.not_repeat)
                            {
                                // ตรวจสอบมีสินค้าเข้าเงื่อนไข
                                if (pro_set_check_pro(pro_id) && pro_set_check_premium(pro_id,offer_value))
                                {
                                    double dis = pro_set_dis_premium(pro_id, offer_value, 1, discount_type);
                                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                    {
                                        con_sqlite.Open();
                                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                        {
                                            // เริ่มใส่ค่าส่วนลด
                                            cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = item_price_sum * " + dis + ", " +
                                                                     "price_net = item_price_sum - (item_price_sum * " + dis + ") " +
                                                                     "WHERE pro_id = " + pro_id + " and premium = true " +
                                                                     "and void = false and hole = false";
                                            cmd_sqlite.ExecuteNonQuery();
                                        }
                                    }

                                }
                                else
                                {
                                    pro_set_update_0(pro_id, false);
                                }
                            }
                        }                   
                    }
                }
            }
            catch (Exception ex)
            {                 
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        public static DataTable pro_base_sum_item(string pro_id, string item_code)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = @"SELECT ibt.item_code,
                                                    coalesce(sum(ibt.item_qty*ibt.qty_small),0) as sum_qty,
                                                    coalesce(sum(ibt.item_price_sum),0) as sum_price                                             
                                                    FROM Invoice_Body_Temp ibt 
                                                    join Promotion_Items pi on pi.item_code = ibt.item_code
                                                    join Promotion p on p.pro_id = pi.pro_id                                                
                                                    where ibt.void = false and ibt.hole = false
                                                    and p.pro_id = '" + pro_id + "' and ibt.item_code = '" + item_code + "'  group by ibt.item_code";



                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable sum_item_pro = new System.Data.DataTable();
                        sum_item_pro.Load(reader);
                        if (sum_item_pro.Rows.Count > 0)
                        {
                            return sum_item_pro;
                        }
                        else
                        {
                            return null!;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        public static int pro_base_set_item(string pro_id, string criterion_value, string criterion_type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ต่อหน่วย
                        if (criterion_type == Class_Parameter.criterion_type_qty)
                        {
                            cmd_sqlite.CommandText = "SELECT coalesce(sum(ic.c),0) as set_all from( " +
                                                "SELECT ibt.item_code ,floor(round(sum(ibt.item_qty*ibt.qty_small)/" + criterion_value + ",2)) as c " +
                                                "from Promotion p " +
                                                "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pi.item_code " +
                                                "and ibt.void = false and ibt.hole = false and ibt.premium = false " +
                                                "where p.pro_id = " + pro_id + " " +
                                                "group by ibt.item_code " +
                                                "HAVING floor(round(sum(ibt.item_qty*ibt.qty_small)/" + criterion_value + ",2)) >= 1) ic";
                        }
                        else
                        {
                            cmd_sqlite.CommandText = "SELECT coalesce(sum(ic.c),0) as set_all from( " +
                                                "SELECT ibt.item_code ,floor(round(sum(ibt.item_qty*ibt.item_price)/" + criterion_value + ",2)) as c " +
                                                "from Promotion p " +
                                                "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pi.item_code " +
                                                "and ibt.void = false and ibt.hole = false and ibt.premium = false " +
                                                "where p.pro_id = " + pro_id + " " +
                                                "group by ibt.item_code " +
                                                "HAVING floor(round(sum(ibt.item_qty*ibt.item_price)/" + criterion_value + ",2)) >= 1) ic";
                        }
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToInt32(set.Rows[0][0]);
                        }
                      
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static bool pro_base_set_premium(string pro_id, string offer)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT pip.item_code ,sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) as c "+
                                                 "from Promotion p "+
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "left join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = "+pro_id+" " +
                                                 "group by pip.item_code " +
                                                 "HAVING sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) < "+offer+";";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static double pro_base_dis_premium(string pro_id, string offer ,int count_set, string discount_type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.qty_small)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }
                        else
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.item_price)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }
                            

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToDouble(set.Rows[0][0]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }   
        public static void pro_base_update_0(string item_code ,string pro_id, bool premium)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if(premium)
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = true 
                                                    and pro_id = " + pro_id ;
                        }
                        else
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = false 
                                                    and item_code = '" + item_code + "'";
                        }
                        

                        cmd_sqlite.ExecuteNonQuery();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }
        public static void pro_base_update_dis(string item_code, string sum_price, double dis_amount)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // เริ่มใส่ค่าส่วนลด
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ", " +
                                                 "price_net = item_price_sum - (cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ") " +
                                                 "WHERE item_code = " + item_code + " and void = false and hole = false";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static DataTable pro_mix_sum_item(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = @"SELECT coalesce(sum(ibt.item_qty*ibt.qty_small),0) as sum_qty,
                                                    coalesce(sum(ibt.item_price_sum),0) as sum_price                                             
                                                    FROM Invoice_Body_Temp ibt 
                                                    join Promotion_Items pi on pi.item_code = ibt.item_code
                                                    join Promotion p on p.pro_id = pi.pro_id                                                
                                                    where ibt.void = false and ibt.hole = false
                                                    and p.pro_id = '" + pro_id + "'";



                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable sum_item_pro = new System.Data.DataTable();
                        sum_item_pro.Load(reader);
                        if (sum_item_pro.Rows.Count > 0)
                        {
                            return sum_item_pro;
                        }
                        else
                        {
                            return null!;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        public static int pro_mix_set_item(string pro_id, string criterion_value, string criterion_type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ต่อหน่วย
                        if (criterion_type == Class_Parameter.criterion_type_qty)
                        {
                            cmd_sqlite.CommandText = "SELECT coalesce(sum(ic.c),0) as set_all from( " +
                                                "SELECT floor(round(sum(ibt.item_qty*ibt.qty_small)/" + criterion_value + ",2)) as c " +
                                                "from Promotion p " +
                                                "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pi.item_code " +
                                                "and ibt.void = false and ibt.hole = false and ibt.premium = false " +
                                                "where p.pro_id = " + pro_id + " " +
                                                "HAVING floor(round(sum(ibt.item_qty*ibt.qty_small)/" + criterion_value + ",2)) >= 1) ic";
                        }
                        else
                        {
                            cmd_sqlite.CommandText = "SELECT coalesce(sum(ic.c),0) as set_all from( " +
                                                "SELECT floor(round(sum(ibt.item_qty*ibt.item_price)/" + criterion_value + ",2)) as c " +
                                                "from Promotion p " +
                                                "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pi.item_code " +
                                                "and ibt.void = false and ibt.hole = false and ibt.premium = false " +
                                                "where p.pro_id = " + pro_id + " " +
                                                "HAVING floor(round(sum(ibt.item_qty*ibt.item_price)/" + criterion_value + ",2)) >= 1) ic";
                        }
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToInt32(set.Rows[0][0]);
                        }

                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static bool pro_mix_set_premium(string pro_id, string offer)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT pip.item_code ,sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "left join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code " +
                                                 "HAVING sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) < " + offer + ";";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static double pro_mix_dis_premium(string pro_id, string offer, int count_set, string discount_type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.qty_small)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }
                        else
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.item_price)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }


                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToDouble(set.Rows[0][0]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static void pro_mix_update_dis(string pro_id, string sum_price, double dis_amount)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // เริ่มใส่ค่าส่วนลด
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ", " +
                                                 "price_net = item_price_sum - (cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ") " +
                                                 "WHERE pro_id = " + pro_id + " and void = false and hole = false";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
        public static void pro_mix_update_0(string pro_id, bool premium)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (premium)
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = true 
                                                    and pro_id = " + pro_id;
                        }
                        else
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = false 
                                                    and pro_id = " + pro_id;
                        }
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       
        public static bool pro_set_check_pro(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT qty_pro.item_code "+
                                                 "from  ( SELECT pi.item_code ,coalesce(sum(pi.item_set_qty),0) as qty "+
                                                 "from Promotion p " +
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                 "where p.pro_id = "+pro_id+" " +
                                                 "GROUP by pi.item_code ) qty_pro " +
                                                 "left join " +
                                                 "(SELECT ibt.item_code ,coalesce(sum(ibt.item_qty*ibt.qty_small ),0) as qty " +
                                                 "from Invoice_Body_Temp ibt " +
                                                 "join Promotion p on p.pro_id = ibt.pro_id and p.pro_id = "+pro_id+" " +
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id and pi.item_code = ibt.item_code " +
                                                 "where ibt.void = false and ibt.hole = false " +
                                                 "group by ibt.item_code ) qty_temp " +
                                                 "on qty_pro.item_code = qty_temp.item_code " +
                                                 "where coalesce(qty_temp.qty,0) < qty_pro.qty";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
               
                        if (set.Rows.Count > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool pro_set_check_premium(string pro_id, string offer)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT pip.item_code ,sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "left join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code " +
                                                 "HAVING sum(coalesce(ibt.item_qty,0)*coalesce(ibt.qty_small,0)) < " + offer + ";";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static DataTable pro_set_sum_item(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = @"SELECT coalesce(sum(ibt.item_qty * ibt.qty_small),0) as sum_qty,
                                                    coalesce(sum(ibt.item_price_sum),0) as sum_price   ,
                                                    coalesce(sum(ibt.item_price_sum),1) / coalesce(sum(ibt.item_qty*ibt.qty_small),1) as unit_price
                                                    FROM Invoice_Body_Temp ibt                                                                                                 
                                                    where ibt.void = false and ibt.hole = false and ibt.pro_id =  " + pro_id;



                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable sum_item_pro = new System.Data.DataTable();
                        sum_item_pro.Load(reader);
                        if (sum_item_pro.Rows.Count > 0)
                        {
                            return sum_item_pro;
                        }
                        else
                        {
                            return null!;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        public static int pro_set_set_qty(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = @" SELECT coalesce(sum(pi.item_set_qty),0) as qty
                                                    from Promotion p 
                                                    join Promotion_Items pi on pi.pro_id = p.pro_id 
                                                    where p.pro_id = "+pro_id;

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToInt32(set.Rows[0]["qty"].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static int pro_set_set_pro(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = "SELECT min(set_item.min_set) as set_pro "+
                                                 "from (SELECT qty_pro.item_code,qty_pro.qty,qty_temp.qty, "+
                                                 "floor(round(qty_temp.qty/qty_pro.qty,2)) as min_set "+
                                                 "from (SELECT pi.item_code ,coalesce(sum(pi.item_set_qty),0) as qty "+
                                                 "from Promotion p "+
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id "+
                                                 "where p.pro_id = "+pro_id+" "+
                                                 "GROUP by pi.item_code ) qty_pro "+
                                                 "join (SELECT ibt.item_code ,coalesce(sum(ibt.item_qty*ibt.qty_small ),0) as qty "+
                                                 "from Invoice_Body_Temp ibt "+
                                                 "join Promotion p on p.pro_id = ibt.pro_id and p.pro_id = "+pro_id+" "+
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id and pi.item_code = ibt.item_code "+
                                                 "where ibt.void = false and ibt.hole = false "+
                                                 "group by ibt.item_code ) qty_temp "+
                                                 "on qty_pro.item_code = qty_temp.item_code "+
                                                 "where coalesce(qty_temp.qty,0) >= qty_pro.qty) set_item";



                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToInt32(set.Rows[0]["set_pro"].ToString());
                        }
                        else
                        {
                            return 0 ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static double pro_set_dis_premium(string pro_id, string offer, int count_set, string discount_type)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        if (discount_type == Class_Parameter.discount_type_per_qty)
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.qty_small)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }
                        else
                        {
                            cmd_sqlite.CommandText = "SELECT (count_set.ms * price_set.s) / price_all.sum_price_all " +
                                                 "from( " +
                                                 "SELECT case when min(s.c) > " + count_set + " then " + count_set + " else min(s.c) end as ms from( " +
                                                 "SELECT pip.item_code ,floor(round(sum(ibt.item_qty*ibt.item_price)/" + offer + ",2)) as c " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) s ) count_set " +
                                                 "join ( " +
                                                 "SELECT sum(ps.s) as s " +
                                                 "from( " +
                                                 "SELECT pip.item_code, (sum(ibt.item_qty*ibt.item_price) / sum(ibt.item_qty*ibt.qty_small) * " + offer + " ) as s " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + " " +
                                                 "group by pip.item_code) ps ) price_set " +
                                                 "join ( " +
                                                 "SELECT sum(ibt.item_qty*ibt.item_price) as sum_price_all " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items_Premium pip on pip.pro_id = p.pro_id " +
                                                 "join Invoice_Body_Temp ibt on ibt.pro_id = p.pro_id and ibt.item_code = pip.item_code " +
                                                 "and ibt.void = false and ibt.hole = false and ibt.premium = true " +
                                                 "where p.pro_id = " + pro_id + ") price_all";
                        }


                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToDouble(set.Rows[0][0]);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static double pro_set_set_price(string pro_id)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = "SELECT sum(unit_price.unit_price*qty_pro.qty ) as set_price "+
                                                 "from (SELECT ibt.item_code ,sum(ibt.item_price)/sum(ibt.item_qty*ibt.qty_small) as unit_price " +
                                                 "from Invoice_Body_Temp ibt " +
                                                 "join Promotion p on p.pro_id = ibt.pro_id and p.pro_id = "+pro_id+" " +
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id and pi.item_code = ibt.item_code " +
                                                 "where ibt.void = false and ibt.hole = false " +
                                                 "group by ibt.item_code) unit_price " +
                                                 "join (SELECT pi.item_code ,coalesce(sum(pi.item_set_qty),0) as qty " +
                                                 "from Promotion p " +
                                                 "join Promotion_Items pi on pi.pro_id = p.pro_id " +
                                                 "where p.pro_id = "+pro_id+" " + 
                                                 "GROUP by pi.item_code) qty_pro on qty_pro.item_code = unit_price.item_code;";



                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable set = new System.Data.DataTable();
                        set.Load(reader);
                        if (set.Rows.Count > 0)
                        {
                            return Convert.ToDouble(set.Rows[0]["set_price"].ToString()!);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public static void pro_set_update_dis(string pro_id, string sum_price, double dis_amount)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // เริ่มใส่ค่าส่วนลด
                        cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp set discount_promotion = cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ", " +
                                                 "price_net = item_price_sum - (cast( item_price_sum as real) / cast( " + sum_price + " as real ) * " + dis_amount + ") " +
                                                 "WHERE pro_id = " + pro_id + " and void = false and hole = false";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void pro_set_update_0(string pro_id, bool premium)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (premium)
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = true 
                                                    and pro_id = " + pro_id;
                        }
                        else
                        {
                            cmd_sqlite.CommandText = @" UPDATE Invoice_Body_Temp set discount_promotion = 0,
                                                    price_net = item_price_sum
                                                    where hole = false and premium = false 
                                                    and pro_id = " + pro_id;
                        }
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string[] sum_price()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT COALESCE(sum(ibt.item_qty),0),
                                                   COALESCE(sum(ibt.item_price_sum),0),
                                                   COALESCE(sum(ibt.discount_promotion),0),
                                                   COALESCE(sum(ibt.discount_member),0),                                               
                                                   FLOOR(ROUND(COALESCE(sum(ibt.item_price_sum),0)- COALESCE(sum(ibt.discount_promotion),0) - COALESCE(sum(ibt.discount_member),0),2))
                                                   from Invoice_Body_Temp ibt 
                                                   where ibt.void = false and ibt.hole = false";

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        string[] result = { dt.Rows[0][0].ToString()!, 
                            dt.Rows[0][1].ToString()!, 
                            dt.Rows[0][2].ToString()!,
                            dt.Rows[0][3].ToString()!,
                            Math.Abs(Convert.ToDouble(dt.Rows[0][1]) - Convert.ToDouble(dt.Rows[0][2]) - Convert.ToDouble(dt.Rows[0][3]) - Convert.ToDouble(dt.Rows[0][4])).ToString()!,
                            dt.Rows[0][4].ToString()! };
                        return result;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] result = {"0","0","0","0","0","0" };
                return result;
                
            }
        }

    }
}
