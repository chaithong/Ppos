using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Item_Adjust
    {
        public static string Increase(string barcode, string qty_small, string qty, string cost,string trans_type,string trans_desc)
        {
            try
            {
                DataTable dt;
                double item_qty_begin, item_qty, item_qty_end; // จำนวนเริ่มกับจำนวนจบหน่วยที่เลือก
                double small_qty_begin, small_qty, small_qty_end; // หน่วยเล็ก
                double small_cost_avg;
                double medium_qty_end = 0, large_qty_end = 0;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // select item
                        cmd_sqlite.CommandText = "SELECT code, group_main, group_sub, name, " +
                            "small_barcode, small_unit, small_price, small_cost_last, small_cost_avg, small_qty, " +
                            "medium_barcode, medium_unit, medium_price, medium_cost_last, medium_cost_avg, medium_qty, medium_qty_small, " +
                            "large_barcode, large_unit, large_price, large_cost_last, large_cost_avg, large_qty, large_qty_small, " +
                            "sale_vat, sale_negative, item_weight, effective_promotion, effective_member, effective_hotkey " +
                            "FROM Item " +
                            "Where status = '1' " +
                            "and " +
                            "(small_barcode = '" + barcode + "' or " +
                            "medium_barcode = '" + barcode + "' or " +
                            "large_barcode = '" + barcode + "') "
                                                ;
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count != 1)
                        {
                            return null!;
                        }
                        // จำนวน
                        // หาจำนวนปรับ ตามหน่วยที่เลือก
                        item_qty = Convert.ToDouble(qty);
                        // เล็กตั้งต้น
                        small_qty_begin = Convert.ToDouble(dt.Rows[0]["small_qty"]);
                        // ปรับเล็ก
                        small_qty = item_qty * Convert.ToDouble(qty_small);
                        // เล็กจบ
                        small_qty_end = small_qty_begin + small_qty;
                        // จำนวนตั้งต้น ตามหน่วยที่เลือก
                        item_qty_begin = ((small_qty_begin != 0) ? small_qty_begin / Convert.ToDouble(qty_small) : 0);
                        // จำนวนจบ ตามหน่วยที่เลือก
                        item_qty_end = item_qty_begin + item_qty;
                        if (dt.Rows[0]["medium_barcode"].ToString() != string.Empty)
                        {
                            // จำนวนกลางจบ
                            medium_qty_end = ((small_qty_end != 0) ? small_qty_end / Convert.ToDouble(dt.Rows[0]["medium_qty_small"]) : 0);
                            if (dt.Rows[0]["large_barcode"].ToString() != string.Empty)
                            {
                                // จำนวนใหญ่จบ
                                large_qty_end = ((small_qty_end != 0) ? small_qty_end / Convert.ToDouble(dt.Rows[0]["large_qty_small"]) : 0);
                            }
                        }

                        // ต้นุทนเฉลี่ย
                        // หาทุนเฉลี่ยหน่วยเล็กใหม่
                        // จำนวนเริ่มต้นมากกว่า 0
                        if (small_qty_begin > 0)
                        {
                            // ทุนทั้งหมด รวม ของใหม่
                            small_cost_avg = (small_qty_begin * Convert.ToDouble(dt.Rows[0]["small_cost_avg"]))  // เล็ก ทุนเฉลี่ยเดิมทั้งหมด
                                        + (Convert.ToDouble(qty) * Convert.ToDouble(cost)); // ทุนใหม่สินค้าที่เลือก 
                                                                                            // หาทุนต่อหน่วย
                            if (small_cost_avg > 0 && small_qty_end > 0)
                            {
                                small_cost_avg = small_cost_avg / small_qty_end;
                            }
                            else
                            {
                                small_cost_avg = 0;
                            }
                        }
                        // ถ้าจำนวนปรับมากกว่าคงเหลือที่ติดลบ ปรับให้เป็นค่าบวก มีจำนวน
                        else if (Convert.ToDouble(qty) * Convert.ToDouble(qty_small) > Math.Abs(small_qty_begin))
                        {

                            // ทุนทั้งหมด รวม ของใหม่
                            small_cost_avg = ((Convert.ToDouble(qty) * Convert.ToDouble(qty_small)) - Math.Abs(small_qty_begin)) // หาจำนวนปรับเฉพาะมากกว่า 0
                                / Convert.ToDouble(qty_small) // หารจำนวนหน่วยเล็ก เพื่อจะเป็นหน่วยที่เลือก
                                * Convert.ToDouble(cost); // ทุนใหม่สินค้าที่เลือก 
                                                          // หาทุนต่อหน่วย
                            if (small_cost_avg > 0 && small_qty_end > 0)
                            {
                                small_cost_avg = small_cost_avg / small_qty_end;
                            }
                            else
                            {
                                small_cost_avg = 0;
                            }
                        }
                        // ถ้าจำนวนเริ่มต้นลบ และปรับเพิ่มยังลบ หรือ 0 อยู่
                        else
                        {
                            small_cost_avg = 0;
                        }

                        // update item
                        cmd_sqlite.CommandText = "UPDATE Item SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "small_qty = '" + small_qty_end + "'," +
                                                 "small_cost_avg = '" + small_cost_avg + "' ";
                        // ถ้าปรับหน่วยเล็ก จะแก้ไขทุนล่าสุด
                        if (Convert.ToDouble(qty_small) == 1)
                        {
                            cmd_sqlite.CommandText += ", small_cost_last = ' " + Convert.ToDouble(cost) + "' ";
                        }
                        // ถ้ามีหน่วยกลาง
                        if (dt.Rows[0]["medium_barcode"].ToString() != string.Empty)
                        {
                            cmd_sqlite.CommandText += ", medium_qty = '" + medium_qty_end + "' " +
                            ", medium_cost_avg = '" + (small_cost_avg * Convert.ToDouble(dt.Rows[0]["medium_qty_small"])) + "' ";
                            // ถ้าปรับหน่วยกลาง จะแก้ไขทุนล่าสุด
                            if (Convert.ToDouble(qty_small) == Convert.ToDouble(dt.Rows[0]["medium_qty_small"]))
                            {
                                cmd_sqlite.CommandText += ", medium_cost_last = ' " + Convert.ToDouble(cost) + "' ";
                            }
                            // ถ้ามีหน่วยใหญ่
                            if (dt.Rows[0]["large_barcode"].ToString() != string.Empty)
                            {
                                cmd_sqlite.CommandText += ",large_qty = '" + large_qty_end + "' " +
                                ", large_cost_avg = '" + (small_cost_avg * Convert.ToDouble(dt.Rows[0]["large_qty_small"])) + "' ";

                                // ถ้าปรับหน่วยใหญ่ จะแก้ไขทุนล่าสุด
                                if (Convert.ToDouble(qty_small) == Convert.ToDouble(dt.Rows[0]["large_qty_small"]))
                                {
                                    cmd_sqlite.CommandText += ", large_cost_last = ' " + Convert.ToDouble(cost) + "' ";
                                }
                            }
                        }
                        cmd_sqlite.CommandText += " where code = '" + dt.Rows[0]["code"].ToString() + "'";
                        cmd_sqlite.ExecuteNonQuery();

                        // insert transaction

                        // จำนวนเล็กเริ่มต้นมากกว่าหรือเท่ากับ 0 หรือ จำนวนปรับน้อยกว่าหรือเท่ากับสินค้าเริ่มต้น abs
                        if (small_qty_begin >= 0 || (item_qty <= Math.Abs(item_qty_begin)))
                        {
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                     "(created_by,created_date,updated_by,updated_date," +
                                                     "trans_type,trans_desc," +
                                                     "item_code,item_barcode," +
                                                     "item_qty_begin,item_qty,item_qty_end," +
                                                     "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                     "small_barcode," +
                                                     "small_qty_begin,small_qty,small_qty_end," +
                                                     "small_cost_begin,small_cost,small_cost_end) " +
                                                     "VALUES(" +
                                                     "'" + Class_Parameter.User_Login + "'," +
                                                     "datetime('now', 'localtime')," +
                                                     "''," +
                                                     "''," +
                                                     "'" + trans_type + "'," + // trans_type
                                                     "'" + trans_desc + "'," + // trans_desc
                                                     "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                     "'" + barcode + "'," + // barcode
                                                     "'" + item_qty_begin + "'," + // item_qty_begin
                                                     "'" + item_qty + "'," + // item_qty
                                                     "'" + item_qty_end + "'," + // item_qty_end
                                                     "'" + (Convert.ToDouble(dt.Rows[0]["small_cost_avg"]) * Convert.ToDouble(qty_small)) + "'," + // item_cost_begin
                                                     "'" + cost + "'," + // item_cost
                                                     "'" + (small_cost_avg * Convert.ToDouble(qty_small)) + "'," + // item_cost_end
                                                     "'" + qty_small + "'," + // item_qty_small
                                                     "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                     "'" + small_qty_begin + "'," + // small_qty_begin
                                                     "'" + small_qty + "'," + // small_qty
                                                     "'" + small_qty_end + "'," + // small_qty_end
                                                     "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost_begin
                                                     "'" + ((Convert.ToDouble(cost) != 0) ? Convert.ToDouble(cost) / Convert.ToDouble(qty_small) : 0) + "'," + // small_cost
                                                     "'" + small_cost_avg + "'" +  // small_cost_end
                                                     ")";


                        }
                        else // จำนวนเริ่มต้นน้อยกว่า 0 และมีการเพิ่มมากกว่า 0 ต้องทำให้ 0 ก่อน 
                        {
                            // จากลบให้เป็น 0
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                      "(created_by,created_date,updated_by,updated_date," +
                                                      "trans_type,trans_desc," +
                                                      "item_code,item_barcode," +
                                                      "item_qty_begin,item_qty,item_qty_end," +
                                                      "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                      "small_barcode," +
                                                      "small_qty_begin,small_qty,small_qty_end," +
                                                      "small_cost_begin,small_cost,small_cost_end) " +
                                                      "VALUES(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + trans_type + "'," + // trans_type
                                                      "'" + trans_desc + "'," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'" + item_qty_begin + "'," + // item_qty_begin
                                                      "'" + Math.Abs(item_qty_begin) + "'," + // item_qty
                                                      "'0'," + // item_qty_end
                                                      "'0'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'0'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'" + small_qty_begin + "'," + // small_qty_begin
                                                      "'" + Math.Abs(small_qty_begin) + "'," + // small_qty
                                                      "'0'," + // small_qty_end
                                                      "'0'," + // small_cost_begin
                                                      "'" + small_cost_avg + "'," + // small_cost
                                                      "'0'" +  // small_cost_end
                                                      "),";
                            // เพิ่มจากจำนวน 0
                            cmd_sqlite.CommandText += "(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + trans_type + "'," + // trans_type
                                                      "'" + trans_desc + "'," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'0'," + // item_qty_begin
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) + "'," + // item_qty
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) + "'," + // item_qty_end
                                                      "'0'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'" + cost + "'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'0'," + // small_qty_begin
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) * Convert.ToDouble(qty_small) + "'," + // small_qty
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) * Convert.ToDouble(qty_small) + "'," + // small_qty_end
                                                      "'0'," + // small_cost_begin
                                                      "'" + small_cost_avg + "'," + // small_cost
                                                      "'" + small_cost_avg + "'" +  // small_cost_end
                                                      ")";
                        }
                        cmd_sqlite.ExecuteNonQuery();

                    }
                }
                return item_qty_end.ToString("#,##0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        public static string Decrease(string barcode, string qty_small, string qty, string cost ,string trans_type, string trans_desc)
        {
            try
            {
                DataTable dt;
                double small_qty_end;               
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // select item
                        cmd_sqlite.CommandText = "SELECT code, group_main, group_sub, name, " +
                            "small_barcode, small_unit, small_price, small_cost_last, small_cost_avg, small_qty, " +
                            "medium_barcode, medium_unit, medium_price, medium_cost_last, medium_cost_avg, medium_qty, medium_qty_small, " +
                            "large_barcode, large_unit, large_price, large_cost_last, large_cost_avg, large_qty, large_qty_small, " +
                            "sale_vat, sale_negative, item_weight, effective_promotion, effective_member, effective_hotkey " +
                            "FROM Item " +
                            "Where status = '1' " +
                            "and " +
                            "(small_barcode = '" + barcode + "' or " +
                            "medium_barcode = '" + barcode + "' or " +
                            "large_barcode = '" + barcode + "') ";
                                                
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count != 1)
                        {
                            return null!;
                        }
                        // เล็ก คงเหลือ หลังปรับลด (ถ้าเป็น เล็ก qty small จะ 1)
                        small_qty_end = Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) -
                                       (Convert.ToDouble(qty_small) * Convert.ToDouble(qty));
                        

                        // update item
                        cmd_sqlite.CommandText = "UPDATE Item SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "small_qty = '" + small_qty_end + "' ";

                        // ลดเหลือ 0 avg จะ 0 ทั้งหมด
                        if (small_qty_end <= 0)
                        {
                            cmd_sqlite.CommandText += ", small_cost_avg = '0' " +
                                ", medium_cost_avg = '0' " +
                                ", large_cost_avg = '0' ";
                        }

                        if (dt.Rows[0]["medium_barcode"].ToString() != string.Empty)
                        {
                            cmd_sqlite.CommandText += ", medium_qty = '" + ((small_qty_end != 0) ? (small_qty_end / Convert.ToDouble(dt.Rows[0]["medium_qty_small"].ToString())) : 0) + "' ";
                            if (dt.Rows[0]["large_barcode"].ToString() != string.Empty)
                            {
                                cmd_sqlite.CommandText += ",large_qty = '" + ((small_qty_end != 0) ? (small_qty_end / Convert.ToDouble(dt.Rows[0]["large_qty_small"].ToString())) : 0) + "' ";
                            }
                        }
                        cmd_sqlite.CommandText += " where code = '" + dt.Rows[0]["code"].ToString() + "'";
                        cmd_sqlite.ExecuteNonQuery();

                        // หน่วยเล็ก เป็นค่าบวก และมากกว่าหรือเท่ากับ จำนวนปรับลด
                        // หน่วยเล็กน้อยกว่า 0
                        if (
                            (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) >= (Convert.ToDouble(qty_small) * Convert.ToDouble(qty)) &&
                            Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) >= 0) ||
                            Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) <= 0
                           )
                      
                        {
                            // insert transaction
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                     "(created_by,created_date,updated_by,updated_date," +
                                                     "trans_type,trans_desc," +
                                                     "item_code,item_barcode," +
                                                     "item_qty_begin,item_qty,item_qty_end," +
                                                     "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                     "small_barcode," +
                                                     "small_qty_begin,small_qty,small_qty_end," +
                                                     "small_cost_begin,small_cost,small_cost_end) " +
                                                     "VALUES(" +
                                                     "'" + Class_Parameter.User_Login + "'," +
                                                     "datetime('now', 'localtime')," +
                                                     "''," +
                                                     "''," +
                                                     "'" + trans_type + "'," + // trans_type
                                                     "'"+ trans_desc + "'," + // trans_desc
                                                     "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                     "'" + barcode + "'," + // barcode
                                                     "'" + ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) : 0) + "'," + // item_qty_begin
                                                     "'-" + qty + "'," + // item_qty
                                                     "'" + ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) - Convert.ToDouble(qty)) : 0) + "'," + // item_qty_end
                                                     "'" + cost + "'," + // item_cost_begin
                                                     "'" + cost + "'," + // item_cost
                                                     "'" + ((small_qty_end > 0) ? cost : 0) + "'," + // item_cost_end
                                                     "'" + qty_small + "'," + // item_qty_small
                                                     "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                     "'" + dt.Rows[0]["small_qty"].ToString() + "'," + // small_qty_begin
                                                     "'" + (small_qty_end - Convert.ToDouble(dt.Rows[0]["small_qty"])) + "'," + // small_qty
                                                     "'" + small_qty_end + "'," + // small_qty_end
                                                     "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost_begin
                                                     "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost
                                                     "'" + ((small_qty_end > 0) ? dt.Rows[0]["small_cost_avg"].ToString() : 0) + "'" +  // small_cost_end
                                                     ")";
                            cmd_sqlite.ExecuteNonQuery();

                        }
                        else // ปรับลด ให้ติดลบ
                        {                                     
                           
                            // ลบให้เป็น 0
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                      "(created_by,created_date,updated_by,updated_date," +
                                                      "trans_type,trans_desc," +
                                                      "item_code,item_barcode," +
                                                      "item_qty_begin,item_qty,item_qty_end," +
                                                      "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                      "small_barcode," +
                                                      "small_qty_begin,small_qty,small_qty_end," +
                                                      "small_cost_begin,small_cost,small_cost_end) " +
                                                      "VALUES(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + trans_type + "'," + // trans_type
                                                      "'" + trans_desc + "'," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'" + ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) : 0) + "'," + // item_qty_begin
                                                      "'-" + ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) : 0) + "',"  + // item_qty
                                                      "'0'," + // item_qty_end
                                                      "'" + cost + "'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'0'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'" + dt.Rows[0]["small_qty"].ToString() + "'," + // small_qty_begin
                                                      "'-" + dt.Rows[0]["small_qty"].ToString() + "'," + // small_qty
                                                      "'0'," + // small_qty_end
                                                      "'" + ((Convert.ToDouble(cost) != 0) ? Convert.ToDouble(cost) / Convert.ToDouble(qty_small) : 0) + "'," + // small_cost_begin
                                                      "'" + ((Convert.ToDouble(cost) != 0) ? Convert.ToDouble(cost) / Convert.ToDouble(qty_small) : 0) + "'," + // small_cost
                                                      "'0'" +  // small_cost_end
                                                      "),";
                            // ลบจากจำนวน 0
                            cmd_sqlite.CommandText += "(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + trans_type + "'," + // trans_type
                                                      "'" + trans_desc + "'," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'0'," + // item_qty_begin
                                                      "'-" + (Convert.ToDouble(qty) - ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) : 0)) + "'," + // item_qty
                                                      "'-" + (Convert.ToDouble(qty) - ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? (Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) : 0)) + "'," + // item_qty_end
                                                      "'0'," + // item_cost_begin
                                                      "'0'," + // item_cost
                                                      "'0'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'0'," + // small_qty_begin
                                                      "'" + small_qty_end + "'," + // small_qty
                                                      "'" + small_qty_end + "'," + // small_qty_end
                                                      "'0'," + // small_cost_begin
                                                      "'0'," + // small_cost
                                                      "'0'" +  // small_cost_end
                                                      ")";
                        
                             cmd_sqlite.ExecuteNonQuery();
                        }
                        return ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) != 0) ? ((Convert.ToDouble(dt.Rows[0]["small_qty"].ToString()) / Convert.ToDouble(qty_small)) - Convert.ToDouble(qty)) : 0).ToString("#,##0.##");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
        public static string Custom(string barcode, string qty_small, string qty, string cost)
        {
            try
            {
                DataTable dt;
                double item_qty; // จำนวนปรับหน่วยที่เลือก
                double item_qty_begin, item_qty_end; // จำนวนเริ่มกับจำนวนจบหน่วยที่เลือก
                double small_qty_begin,small_qty,small_qty_end; // หน่วยเล็ก
                double medium_qty_end = 0,large_qty_end = 0;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // select item
                        cmd_sqlite.CommandText = "SELECT code, group_main, group_sub, name, " +
                            "small_barcode, small_unit, small_price, small_cost_last, small_cost_avg, small_qty, " +
                            "medium_barcode, medium_unit, medium_price, medium_cost_last, medium_cost_avg, medium_qty, medium_qty_small, " +
                            "large_barcode, large_unit, large_price, large_cost_last, large_cost_avg, large_qty, large_qty_small, " +
                            "sale_vat, sale_negative, item_weight, effective_promotion, effective_member, effective_hotkey " +
                            "FROM Item " +
                            "Where status = '1' " +
                            "and " +
                            "(small_barcode = '" + barcode + "' or " +
                            "medium_barcode = '" + barcode + "' or " +
                            "large_barcode = '" + barcode + "') "
                                                ;
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count != 1)
                        {
                            return null!;
                        }
                        //
                       // หาจำนวนปรับ ตามหน่วยที่เลือก
                       
                            item_qty = Convert.ToDouble(qty) -
                                                   ((Convert.ToDouble(dt.Rows[0]["small_qty"]) != 0) ?
                                                   (Convert.ToDouble(dt.Rows[0]["small_qty"]) / Convert.ToDouble(qty_small)) : 0);
                       
                        // เล็กตั้งต้น
                        small_qty_begin = Convert.ToDouble(dt.Rows[0]["small_qty"]);
                        // ปรับเล็ก
                        small_qty = item_qty * Convert.ToDouble(qty_small);
                        // เล็กจบ
                        small_qty_end = small_qty_begin + small_qty;
                        // จำนวนตั้งต้น ตามหน่วยที่เลือก
                        item_qty_begin = ((small_qty_begin != 0) ? small_qty_begin / Convert.ToDouble(qty_small) : 0);
                        // จำนวนจบ ตามหน่วยที่เลือก
                        item_qty_end = item_qty_begin + item_qty;
                        if (dt.Rows[0]["medium_barcode"].ToString() != string.Empty)
                        {
                            // จำนวนกลางจบ
                            medium_qty_end = ((small_qty_end != 0) ? small_qty_end / Convert.ToDouble(dt.Rows[0]["medium_qty_small"]) : 0);
                            if (dt.Rows[0]["large_barcode"].ToString() != string.Empty)
                            {
                                // จำนวนใหญ่จบ
                                large_qty_end = ((small_qty_end != 0) ? small_qty_end / Convert.ToDouble(dt.Rows[0]["large_qty_small"]) : 0);
                            }
                        }
                        
                        // update item
                        cmd_sqlite.CommandText = "UPDATE Item SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "small_qty = '" + small_qty_end + "' ";
                        // ลดเหลือ 0 avg จะ 0 ทั้งหมด
                        if (small_qty_end == 0)
                        {
                            cmd_sqlite.CommandText += ", small_cost_avg = '0' " +
                                ", medium_cost_avg = '0' " +
                                ", large_cost_avg = '0' ";
                        }
                        if (dt.Rows[0]["medium_barcode"].ToString() != string.Empty)
                        {
                            cmd_sqlite.CommandText += ", medium_qty = '" + medium_qty_end + "' ";
                            if (dt.Rows[0]["large_barcode"].ToString() != string.Empty)
                            {
                                cmd_sqlite.CommandText += ",large_qty = '" + large_qty_end + "' ";
                            }
                        }
                        cmd_sqlite.CommandText += " where code = '" + dt.Rows[0]["code"].ToString() + "'";
                        cmd_sqlite.ExecuteNonQuery();

                        // insert transaction

                        // จำนวนเล็กเริ่มต้นมากกว่าหรือเท่ากับ 0 หรือ จำนวนปรับน้อยกว่าหรือเท่ากับสินค้าเริ่มต้น abs
                        if(small_qty_begin >= 0 ||(item_qty <= Math.Abs(item_qty_begin)))
                        {
                             cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                      "(created_by,created_date,updated_by,updated_date," +
                                                      "trans_type,trans_desc," +
                                                      "item_code,item_barcode," +
                                                      "item_qty_begin,item_qty,item_qty_end," +
                                                      "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                      "small_barcode," +
                                                      "small_qty_begin,small_qty,small_qty_end," +
                                                      "small_cost_begin,small_cost,small_cost_end) " +
                                                      "VALUES(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + ((item_qty < 0)?Class_Parameter.Adjust_Decrease:Class_Parameter.Adjust_Increase) + "'," + // trans_type
                                                      "''," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'" + item_qty_begin + "'," + // item_qty_begin
                                                      "'" + item_qty + "'," + // item_qty
                                                      "'" + item_qty_end + "'," + // item_qty_end
                                                      "'" + cost + "'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'" + ((small_qty_end != 0) ? cost : 0) + "'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'" + small_qty_begin + "'," + // small_qty_begin
                                                      "'" + small_qty + "'," + // small_qty
                                                      "'" + small_qty_end + "'," + // small_qty_end
                                                      "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost_begin
                                                      "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost
                                                      "'" + ((small_qty_end != 0) ? dt.Rows[0]["small_cost_avg"].ToString() : 0) + "'" +  // small_cost_end
                                                      ")";
                           
                           
                        }
                        else // จำนวนเริ่มต้นน้อยกว่า 0 และมีการกำหนดมากกว่า 0 ต้องทำให้ 0 ก่อน 
                        {      
                            // จากลบให้เป็น 0
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                      "(created_by,created_date,updated_by,updated_date," +
                                                      "trans_type,trans_desc," +
                                                      "item_code,item_barcode," +
                                                      "item_qty_begin,item_qty,item_qty_end," +
                                                      "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                      "small_barcode," +
                                                      "small_qty_begin,small_qty,small_qty_end," +
                                                      "small_cost_begin,small_cost,small_cost_end) " +
                                                      "VALUES(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + ((item_qty < 0) ? Class_Parameter.Adjust_Decrease : Class_Parameter.Adjust_Increase) + "'," + // trans_type
                                                      "''," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'" + item_qty_begin + "'," + // item_qty_begin
                                                      "'" + Math.Abs(item_qty_begin) + "'," + // item_qty
                                                      "'0'," + // item_qty_end
                                                      "'0'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'0'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'" + small_qty_begin + "'," + // small_qty_begin
                                                      "'" + Math.Abs(small_qty_begin) + "'," + // small_qty
                                                      "'0'," + // small_qty_end
                                                      "'0'," + // small_cost_begin
                                                      "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost
                                                      "'0'" +  // small_cost_end
                                                      "),";
                            // เพิ่มจากจำนวน 0
                            cmd_sqlite.CommandText += "(" +
                                                      "'" + Class_Parameter.User_Login + "'," +
                                                      "datetime('now', 'localtime')," +
                                                      "''," +
                                                      "''," +
                                                      "'" + ((item_qty < 0) ? Class_Parameter.Adjust_Decrease : Class_Parameter.Adjust_Increase) + "'," + // trans_type
                                                      "''," + // trans_desc
                                                      "'" + dt.Rows[0]["code"].ToString() + "'," + // code
                                                      "'" + barcode + "'," + // barcode
                                                      "'0'," + // item_qty_begin
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) + "'," + // item_qty
                                                      "'"+ (item_qty - Math.Abs(item_qty_begin)) + "'," + // item_qty_end
                                                      "'0'," + // item_cost_begin
                                                      "'" + cost + "'," + // item_cost
                                                      "'" + cost + "'," + // item_cost_end
                                                      "'" + qty_small + "'," + // item_qty_small
                                                      "'" + dt.Rows[0]["small_barcode"].ToString() + "'," + // small_barcode
                                                      "'0'," + // small_qty_begin
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) * Convert.ToDouble(qty_small) + "'," + // small_qty
                                                      "'" + (item_qty - Math.Abs(item_qty_begin)) * Convert.ToDouble(qty_small) + "'," + // small_qty_end
                                                      "'0'," + // small_cost_begin
                                                      "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'," + // small_cost
                                                      "'" + dt.Rows[0]["small_cost_avg"].ToString() + "'" +  // small_cost_end
                                                      ")";
                           
                        }
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
                        return item_qty_end.ToString("#,##0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }
    }
}
