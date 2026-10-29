using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Member_Detail
    {
        public static void Add(
            string phone,
            string sex,
            string nick_name,
            string first_name,
            string last_name,
            string address,
            string sub_district,
            string district,
            string province,
            string postal_code,
            string discount_percent,
            string sale_per_point  
            )
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "INSERT INTO Member(created_by,created_date,updated_by,updated_date," +
                            "phone,sex,nick_name,first_name,last_name," +
                            "address,sub_district,district,province,postal_code,discount_percent," +
                            "sale_total,sale_ineffective_member,sale_effective_member," +
                            "sale_per_point,point_increase,point_decrease,point_balance,status) " +
                            "VALUES(" +
                            "'" + Class_Parameter.User_Login + "'," +
                            "datetime('now', 'localtime')," +
                            "''," +
                            "''," +
                            "'" + phone + "'," +
                            "'" + sex + "'," +
                            "'" + nick_name + "'," +
                            "'" + first_name + "'," +
                            "'" + last_name + "'," +
                            "'" + address + "'," +
                            "'" + sub_district + "'," +
                            "'" + district + "'," +
                            "'" + province + "'," +
                            "'" + postal_code + "'," +
                            "" + discount_percent + "," +
                            "0," +
                            "0," +
                            "0," +
                            "" + sale_per_point + "," +
                            "0," +
                            "0," +
                            "0," +
                            "1)";
                            
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Edit(
            string id,
            string phone,
            string sex,
            string nick_name,
            string first_name,
            string last_name,
            string address,
            string sub_district,
            string district,
            string province,
            string postal_code,           
            string discount_percent,
            string sale_per_point,
            string point_increase,
            string point_decrease           
            )
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        // ถ้ามีการปรับแต้ม
                        if (Convert.ToDouble(point_increase) > 0)
                        {
                            cmd_sqlite.CommandText = "INSERT INTO Member_Point_Balance(created_by, created_date, id_member, trans_type, trans_desc ,sale_per_point, point_begin, point_increase, point_decrease, point_end) " +
                                                     "SELECT " +
                                                     "'" + Class_Parameter.User_Login + "', " +
                                                     "datetime('now', 'localtime'), " +                                                   
                                                     "" + id + ", " +
                                                     "'เพิ่มแต้ม', " +
                                                     "''," +
                                                     "sale_per_point," +
                                                     "point_balance," +
                                                     ""+ point_increase + "," +
                                                     "0," +
                                                     "point_balance + "+ point_increase + " " +
                                                     "from Member where id = " + id;
                            cmd_sqlite.ExecuteNonQuery();
                        }

                        cmd_sqlite.CommandText = "UPDATE Member SET " +
                            "updated_date = datetime('now', 'localtime'), " +
                            "updated_by = '" + Class_Parameter.User_Login + "', " +
                            "phone = '" + phone + "'," +
                            "sex = '" + sex + "'," +
                            "nick_name = '" + nick_name + "'," +
                            "first_name = '" + first_name + "'," +
                            "last_name = '" + last_name + "'," +
                            "address = '" + address + "'," +
                            "sub_district = '" + sub_district + "'," +
                            "district = '" + district + "'," +
                            "province = '" + province + "'," +
                            "postal_code = '" + postal_code + "'," +
                            "discount_percent = " + discount_percent + "," +
                            "sale_per_point = " + sale_per_point + ", " +
                            "point_increase = point_increase + " + point_increase + ", " +
                            "point_decrease = point_decrease + " + point_decrease + ", " +
                            "point_balance = point_balance + " + Convert.ToDouble(point_increase) + " " +
                            "where id = " + id;

                        cmd_sqlite.ExecuteNonQuery();

                        // ปรับลดแต้ม
                        if (Convert.ToDouble(point_decrease) > 0)
                        {
                            cmd_sqlite.CommandText = "INSERT INTO Member_Point_Balance(created_by, created_date, id_member, trans_type, trans_desc,sale_per_point, point_begin, point_increase, point_decrease, point_end) " +
                                                    "SELECT " +
                                                    "'" + Class_Parameter.User_Login + "', " +
                                                    "datetime('now', 'localtime'), " +                                                 
                                                    "" + id + ", " +
                                                    "'ลดแต้ม', " +
                                                    "''," +
                                                    "sale_per_point," +
                                                    "point_balance," +
                                                    "0," +
                                                    "" + point_decrease + "," +                                                 
                                                    "point_balance - " + point_decrease + " " +
                                                    "from Member where id = " + id;
                            cmd_sqlite.ExecuteNonQuery();
                        }

                        cmd_sqlite.CommandText = "UPDATE Member SET " +
                             "updated_date = datetime('now', 'localtime'), " +
                             "updated_by = '" + Class_Parameter.User_Login + "', " +
                             "phone = '" + phone + "'," +
                             "sex = '" + sex + "'," +
                             "nick_name = '" + nick_name + "'," +
                             "first_name = '" + first_name + "'," +
                             "last_name = '" + last_name + "'," +
                             "address = '" + address + "'," +
                             "sub_district = '" + sub_district + "'," +
                             "district = '" + district + "'," +
                             "province = '" + province + "'," +
                             "postal_code = '" + postal_code + "'," +
                             "discount_percent = " + discount_percent + "," +
                             "sale_per_point = " + sale_per_point + ", " +
                             "point_increase = point_increase + " + point_increase + ", " +
                             "point_decrease = point_decrease + " + point_decrease + ", " +
                             "point_balance = point_balance + " + -Convert.ToDouble(point_decrease) + " " +
                             "where id = " +id;

                        cmd_sqlite.ExecuteNonQuery();

                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void increase_point(string id_member,double sale_total,double sale_ineffective_member, double sale_effective_member, int point_increase ,string trans_type,string trans_desc)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "INSERT INTO Member_Point_Balance(created_by, created_date, id_member, trans_type, trans_desc,sale_per_point, point_begin, point_increase, point_decrease, point_end) " +
                                                    "SELECT " +
                                                    "'" + Class_Parameter.User_Login + "', " +
                                                    "datetime('now', 'localtime'), " +
                                                    "" + id_member + ", " +
                                                    "'"+trans_type+"', " +
                                                    "'"+trans_desc+"'," +
                                                    "sale_per_point," +
                                                    "point_balance," +
                                                    "" + point_increase + "," +
                                                    "0," +
                                                    "point_balance + " + point_increase + " " +
                                                    "from Member where id = " + id_member;
                        cmd_sqlite.ExecuteNonQuery();


                        cmd_sqlite.CommandText = "UPDATE Member SET " +
                             "updated_date = datetime('now', 'localtime'), " +
                             "updated_by = '" + Class_Parameter.User_Login + "', " +
                             "sale_total = sale_total + " + sale_total + ", " +
                             "sale_ineffective_member = sale_ineffective_member + " + sale_ineffective_member + ", " +
                             "sale_effective_member = sale_effective_member + " + sale_effective_member + ", " +
                             "point_increase = point_increase + " + point_increase + ", " +
                             "point_balance = point_balance + " + point_increase + " "+
                             "where id = " + id_member ;

                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void decrease_point(string id_member, double sale_total, double sale_ineffective_member, double sale_effective_member, int point_decrease, string trans_type, string trans_desc)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "INSERT INTO Member_Point_Balance(created_by, created_date, id_member, trans_type, trans_desc,sale_per_point, point_begin, point_increase, point_decrease, point_end) " +
                                                   "SELECT " +
                                                   "'" + Class_Parameter.User_Login + "', " +
                                                   "datetime('now', 'localtime'), " +
                                                   "" + id_member + ", " +
                                                   "'" + trans_type + "', " +
                                                   "'" + trans_desc + "'," +
                                                   "sale_per_point," +
                                                   "point_balance," +
                                                   "0," +
                                                   "" + point_decrease + "," +
                                                   "point_balance - " + point_decrease + " " +
                                                   "from Member where id = " + id_member;
                        cmd_sqlite.ExecuteNonQuery();


                        cmd_sqlite.CommandText = "UPDATE Member SET " +
                            "updated_date = datetime('now', 'localtime'), " +
                            "updated_by = '" + Class_Parameter.User_Login + "', " +
                            "point_decrease = point_decrease + " + point_decrease + ", " +
                            "point_balance = point_balance - " + point_decrease + " " +
                            "where id = " + id_member;

                        cmd_sqlite.ExecuteNonQuery();
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
