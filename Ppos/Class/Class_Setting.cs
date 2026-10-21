using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Ppos.Class
{
    internal class Class_Setting
    {
        public static void Get()
        {
            try
            {
                DataTable dt;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // สาขา
                        cmd_sqlite.CommandText = "SELECT store_no,store_name FROM Store ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Class_Parameter.store_no = reader[0].ToString()!;
                                Class_Parameter.store_name = reader[1].ToString()!;
                            }

                        }
                        // กล้อง
                        cmd_sqlite.CommandText = "SELECT device_name FROM Setting_Camera ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Class_Parameter.device_name = reader[0].ToString()!;
                            }

                        }
                        // ตั้งค่า
                        cmd_sqlite.CommandText = "SELECT title,status  FROM Setting_Configure ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["title"].ToString() == "login_program")
                                    {
                                        Class_Parameter.login_program = Convert.ToBoolean(dt.Rows[i]["status"].ToString());
                                    }
                                   /* else if (dt.Rows[i]["title"].ToString() == "hide_menu")
                                    {
                                        Class_Parameter.hide_menu = Convert.ToBoolean(dt.Rows[i]["status"].ToString());
                                    }*/
                                    else if (dt.Rows[i]["title"].ToString() == "use_item_medium_large")
                                    {
                                        Class_Parameter.use_item_medium_large = Convert.ToBoolean(dt.Rows[i]["status"].ToString());
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "custom_cost_adjust")
                                    {
                                        Class_Parameter.custom_cost_adjust = Convert.ToBoolean(dt.Rows[i]["status"].ToString());
                                    }
                                }
                            }

                        }
                        // hotkey
                        cmd_sqlite.CommandText = "SELECT title,value FROM Item_Hotkey_Set ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["title"].ToString() == "column_count")
                                    {
                                        Class_Parameter.column_count = Convert.ToInt16(dt.Rows[i]["value"].ToString());
                               
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "row_height")
                                    {

                                        Class_Parameter.row_height = float.Parse(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "font_size")
                                    {

                                        Class_Parameter.font_size = float.Parse(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "image_type")
                                    {

                                        Class_Parameter.image_type = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "button_color")
                                    {

                                        Class_Parameter.button_color = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "font_color")
                                    {

                                        Class_Parameter.font_color = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_title_1")
                                    {

                                        Class_Parameter.hotkey_title_1 = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_title_2")
                                    {

                                        Class_Parameter.hotkey_title_2 = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_title_3")
                                    {

                                        Class_Parameter.hotkey_title_3 = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_hot_sale_back_date")
                                    {

                                        Class_Parameter.hotkey_hot_sale_back_date = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_hot_sale_limit")
                                    {

                                        Class_Parameter.hotkey_hot_sale_limit = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_last_sale_back_date")
                                    {

                                        Class_Parameter.hotkey_last_sale_back_date = dt.Rows[i]["value"].ToString()!;
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "hotkey_last_sale_limit")
                                    {

                                        Class_Parameter.hotkey_last_sale_limit = dt.Rows[i]["value"].ToString()!;
                                    }
                                }
                            }

                        }
                        // หน้าจอขาย
                        cmd_sqlite.CommandText = "SELECT title,value  FROM Sale_Display_Set ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["title"].ToString() == "sale_left_width")
                                    {
                                        Class_Parameter.sale_left_width = float.Parse(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "sale_hotkey_left")
                                    {
                                        Class_Parameter.sale_hotkey_left = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "visible_sum_qty")
                                    {
                                        Class_Parameter.visible_sum_qty = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "visible_sum_price")
                                    {
                                        Class_Parameter.visible_sum_price = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "visible_dis_pro")
                                    {
                                        Class_Parameter.visible_dis_pro = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "visible_dis_member")
                                    {
                                        Class_Parameter.visible_dis_member = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "visible_dis_round")
                                    {
                                        Class_Parameter.visible_dis_round = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "keypad_numeric")
                                    {
                                        Class_Parameter.keypad_numeric = Convert.ToBoolean(dt.Rows[i]["value"].ToString()!);
                                    }
                                    else if (dt.Rows[i]["title"].ToString() == "pay_left_width")
                                    {
                                        Class_Parameter.pay_left_width = float.Parse(dt.Rows[i]["value"].ToString()!);
                                    }

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
      
    }
}
