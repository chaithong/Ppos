using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Member_Detail : Form
    {
        string set_sex = "";

        // int set_timer_count = 10, timer_count = 0;
        bool add_save = true, edit_save = true;
        int Limit = 20;

        string set_pro_total;

        string set_id = "";

        int set_search_member = 5, count_set_search_member = 0;


        DataTable dt;
        public Form_Member_Detail()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                customGroupBox_detail.Location = new Point(
                (panel_detail.Width / 2) - (customGroupBox_detail.Width / 2), 20);
                dataGridView_member.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_member, true, null);

                foreach (DataGridViewColumn column in dataGridView_member.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_member);

                dataGridView_member.ColumnHeadersDefaultCellStyle.BackColor = Color.Lime;
                dataGridView_member.EnableHeadersVisualStyles = false;

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);



                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));

                button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));

                button_cancel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

                button_sex_male.Image = Class_Image.resizeImage(Ppos.Properties.Resources.male, new Size(25, 30));

                button_sex_female.Image = Class_Image.resizeImage(Ppos.Properties.Resources.female, new Size(25, 30));

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // โปรทั้งหมด
                        cmd_sqlite.CommandText = "select count(id) from Member where status = 1";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                label_search.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }
                            set_pro_total = label_search.Text;
                        }
                    }
                }


            }
            catch
            {
                this.Close();
            }


        }
        private void Form_Member_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                search_member();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sex_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                // ปุ่มชาย
                if (button.Name == "button_sex_male" && set_sex != "ชาย")
                {
                    set_sex = "ชาย";
                    // ปุ่มชาย
                    button_sex_male.ForeColor = System.Drawing.Color.Black;
                    button_sex_male.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                    // ปุ่มหญิง
                    button_sex_female.ForeColor = System.Drawing.Color.Gray;
                    button_sex_female.BackColor = System.Drawing.Color.Transparent;
                }
                else if (button.Name == "button_sex_female" && set_sex != "หญิง") // หญิง
                {
                    set_sex = "หญิง";
                    // ปุ่มชาย
                    button_sex_male.ForeColor = System.Drawing.Color.Gray;
                    button_sex_male.BackColor = System.Drawing.Color.Transparent;

                    // ปุ่มหญิง
                    button_sex_female.ForeColor = System.Drawing.Color.Black;
                    button_sex_female.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void search_member()
        {
            try
            {
                dataGridView_member.Rows.Clear();

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "select id,phone,sex,nick_name,first_name,last_name,address,sub_district,district,province,postal_code,discount_percent,sale_total,sale_ineffective_member,sale_effective_member,sale_per_point,point_increase,point_decrease,point_balance,status " +
                                                 "from Member " +
                                                 "where status = true ";
                        if (textBox_search.Text != "")
                        {
                            cmd_sqlite.CommandText += "and phone like '%" + textBox_search.Text + "%' ";
                        }
                        cmd_sqlite.CommandText += "order by id desc ";
                        if (Limit > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit;
                        }


                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            bool selected = false;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                dataGridView_member.Rows.Add(
                                     dt.Rows[i]["id"].ToString()!,
                                     dt.Rows[i]["phone"].ToString()!,
                                     dt.Rows[i]["sex"].ToString()!,
                                     dt.Rows[i]["nick_name"].ToString()!,
                                     dt.Rows[i]["first_name"].ToString()!,
                                     dt.Rows[i]["last_name"].ToString()!,
                                     dt.Rows[i]["address"].ToString()!,
                                     dt.Rows[i]["sub_district"].ToString()!,
                                     dt.Rows[i]["district"].ToString()!,
                                     dt.Rows[i]["province"].ToString()!,
                                     dt.Rows[i]["postal_code"].ToString()!,
                                     dt.Rows[i]["discount_percent"].ToString()!,
                                     dt.Rows[i]["sale_total"].ToString()!,
                                     dt.Rows[i]["sale_ineffective_member"].ToString()!,
                                     dt.Rows[i]["sale_effective_member"].ToString()!,
                                     dt.Rows[i]["sale_per_point"].ToString()!,
                                     dt.Rows[i]["point_increase"].ToString()!,
                                     dt.Rows[i]["point_decrease"].ToString()!,
                                     dt.Rows[i]["point_balance"].ToString()!,
                                    Class_Image.resizeImage(Ppos.Properties.Resources.deleteMember, new Size(30, 30)));
                                // ถ้าเป็นข้อมูลที่เลือกไว้ จะ select ให้
                                if (dt.Rows[i]["id"].ToString() == set_id)
                                {
                                    selected = true;
                                    dataGridView_member.Rows[i].Selected = true;
                                    dataGridView_member.CurrentCell = dataGridView_member.Rows[i].Cells["phone"];
                                }
                            }
                            // ถ้าไม่มีข้อมูลเดิมจะไม่เลือก
                            if (!selected)
                            {
                                dataGridView_member.ClearSelection();
                            }

                        }
                    }
                }
                // นับจำนวนค้นหา
                label_search.Text = set_pro_total;
                if (dataGridView_member.RowCount > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_pro_total;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_member_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    dataGridView_member.Rows[e.RowIndex].Cells["phone"].Style.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_member_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_member.Rows[e.RowIndex].Cells["phone"].Style.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_member_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    dataGridView_member.Rows[e.RowIndex].Selected = true;
                    set_id = dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;
                    textBox_phone.Text = dataGridView_member.Rows[e.RowIndex].Cells["phone"].Value!.ToString()!;
                    if (dataGridView_member.Rows[e.RowIndex].Cells["sex"].Value!.ToString()! == "ชาย")
                    {
                        set_sex = "ชาย";
                        // ปุ่มชาย

                        button_sex_male.ForeColor = System.Drawing.Color.Black;
                        button_sex_male.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                        // ปุ่มหญิง

                        button_sex_female.ForeColor = System.Drawing.Color.Gray;
                        button_sex_female.BackColor = System.Drawing.Color.Transparent;

                    }
                    else // หญิง
                    {
                        set_sex = "หญิง";
                        // ปุ่มชาย

                        button_sex_male.ForeColor = System.Drawing.Color.Gray;
                        button_sex_male.BackColor = System.Drawing.Color.Transparent;


                        // ปุ่มหญิง

                        button_sex_female.ForeColor = System.Drawing.Color.Black;
                        button_sex_female.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);

                    }
                    textBox_nick_name.Text = dataGridView_member.Rows[e.RowIndex].Cells["nick_name"].Value!.ToString()!;
                    textBox_first_name.Text = dataGridView_member.Rows[e.RowIndex].Cells["first_name"].Value!.ToString()!;
                    textBox_last_name.Text = dataGridView_member.Rows[e.RowIndex].Cells["last_name"].Value!.ToString()!;
                    textBox_address.Text = dataGridView_member.Rows[e.RowIndex].Cells["address"].Value!.ToString()!;
                    textBox_sub_district.Text = dataGridView_member.Rows[e.RowIndex].Cells["sub_district"].Value!.ToString()!;
                    textBox_district.Text = dataGridView_member.Rows[e.RowIndex].Cells["district"].Value!.ToString()!;
                    textBox_province.Text = dataGridView_member.Rows[e.RowIndex].Cells["province"].Value!.ToString()!;
                    textBox_postal_code.Text = dataGridView_member.Rows[e.RowIndex].Cells["postal_code"].Value!.ToString()!;

                    textBox_discount_percent.Text = dataGridView_member.Rows[e.RowIndex].Cells["discount_percent"].Value!.ToString()!;
                    label_sale_total.Text = Convert.ToDouble(dataGridView_member.Rows[e.RowIndex].Cells["sale_total"].Value).ToString("#,##0.##")!;
                    label_sale_ineffective_member.Text = Convert.ToDouble(dataGridView_member.Rows[e.RowIndex].Cells["sale_ineffective_member"].Value).ToString("#,##0.##")!;
                    label_sale_effective_member.Text = Convert.ToDouble(dataGridView_member.Rows[e.RowIndex].Cells["sale_effective_member"].Value).ToString("#,##0.##")!;
                    textBox_sale_per_point.Text = dataGridView_member.Rows[e.RowIndex].Cells["sale_per_point"].Value!.ToString()!;

                    label_point_balance.Text = Convert.ToDouble(dataGridView_member.Rows[e.RowIndex].Cells["point_balance"].Value).ToString("#,##0.##")!;

                    textBox_increase_point.Text = "0";
                    textBox_decrease_point.Text = "0";

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.Lime;
                    // กดลบ
                    if (e.ColumnIndex == dataGridView_member.Columns["delete"]!.Index)
                    {
                        if (MessageBox.Show("ต้องการลบ " + dataGridView_member.Rows[e.RowIndex].Cells["phone"].Value!.ToString() + " ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // ปุ่มแก้ไข
                            edit_save = true;
                            button_edit_save.Enabled = false;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                            button_edit_save.Text = "แก้ไข";
                            button_edit_save.FlatStyle = FlatStyle.Flat;
                            button_edit_save.BackColor = Color.Lime;
                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    cmd_sqlite.CommandText = "UPDATE Member SET status = 0, " +
                                         "updated_date = datetime('now', 'localtime'), " +
                                         "updated_by = '" + Class_Parameter.User_Login + "' " +
                                       "WHERE id = " + dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString();
                                    cmd_sqlite.ExecuteNonQuery();

                                    // ลบโปรทั้งหมดอีก 1 รายการ
                                    set_pro_total = (Convert.ToInt32(set_pro_total) - 1).ToString();

                                    stringempty();

                                    search_member();
                                }
                            }

                        }
                    }
                }

                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_search_member_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search_member++;
                if (count_set_search_member >= set_search_member)
                {
                    timer_search_member.Stop();
                    count_set_search_member = 0;
                    search_member();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_member.Stop();
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search_member.Enabled)
                {
                    timer_search_member.Start();
                }
                count_set_search_member = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_member.Stop();
            }
        }
        private void Enabled(bool e)
        {
            try
            {
                textBox_search.Enabled = !e;
                dataGridView_member.Enabled = !e;

                textBox_phone.Enabled = e;

                button_sex_male.Enabled = e;


                button_sex_female.Enabled = e;


                textBox_nick_name.Enabled = e;
                textBox_first_name.Enabled = e;
                textBox_last_name.Enabled = e;
                textBox_address.Enabled = e;
                textBox_sub_district.Enabled = e;
                textBox_district.Enabled = e;
                textBox_province.Enabled = e;
                textBox_postal_code.Enabled = e;

                textBox_discount_percent.Enabled = e;
                label_sale_total.Enabled = e;
                label_sale_ineffective_member.Enabled = e;
                label_sale_effective_member.Enabled = e;
                textBox_sale_per_point.Enabled = e;

                label_point_balance.Enabled = e;



                if (e)
                {
                    textBox_phone.BackColor = Color.White;
                    textBox_nick_name.BackColor = Color.White;
                    textBox_first_name.BackColor = Color.White;
                    textBox_last_name.BackColor = Color.White;
                    textBox_address.BackColor = Color.White;
                    textBox_sub_district.BackColor = Color.White;
                    textBox_district.BackColor = Color.White;
                    textBox_province.BackColor = Color.White;
                    textBox_postal_code.BackColor = Color.White;
                    textBox_discount_percent.BackColor = Color.White;
                    textBox_sale_per_point.BackColor = Color.White;

                    if (!edit_save) // แก้ไข
                    {
                        textBox_decrease_point.BackColor = Color.White;
                        textBox_increase_point.BackColor = Color.White;
                        textBox_decrease_point.Enabled = true;
                        textBox_increase_point.Enabled = true;
                    }

                }
                else
                {
                    textBox_phone.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_nick_name.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_first_name.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_last_name.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_address.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_sub_district.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_district.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_province.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_postal_code.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_discount_percent.BackColor = Color.FromArgb(192, 255, 192);
                    textBox_sale_per_point.BackColor = Color.FromArgb(192, 255, 192);

                    if (!edit_save || !add_save) // แก้ไข หรือ เพิ่ม
                    {
                        textBox_decrease_point.BackColor = Color.FromArgb(192, 255, 192);
                        textBox_increase_point.BackColor = Color.FromArgb(192, 255, 192);
                        textBox_decrease_point.Enabled = false;
                        textBox_increase_point.Enabled = false;
                    }
                    else
                    {
                        textBox_decrease_point.Enabled = true;
                        textBox_increase_point.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button_edit_save_Click(object sender, EventArgs e)
        {
            try
            {

                button_edit_save.Enabled = false;

                if (edit_save) // กดแก้ไข
                {
                    if (set_id != "")
                    {
                        // ปุ่มแก้ไข
                        edit_save = false;
                        button_edit_save.Enabled = true;
                        button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editSaveMember, new Size(50, 50));
                        button_edit_save.Text = "บันทึก";
                        button_edit_save.FlatStyle = FlatStyle.Standard;
                        button_edit_save.BackColor = Color.FromArgb(192, 255, 192);

                        // ปุ่มเพิ่ม
                        add_save = true;
                        button_add_save.Enabled = false;
                        button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));
                        button_add_save.Text = "เพิ่ม";
                        button_add_save.FlatStyle = FlatStyle.Flat;
                        button_add_save.BackColor = Color.Lime;

                        // เปิดปุ่มยกเลิก
                        button_cancel.Enabled = true;
                        button_cancel.FlatStyle = FlatStyle.Standard;
                        button_cancel.BackColor = Color.FromArgb(192, 255, 192);

                        // เปิดการแก้ไข
                        Enabled(true);



                        textBox_phone.Focus();
                    }
                }
                else // กดบันทึก
                {
                    if (check_save())
                    {
                        if (Class_Check_Member.Phone(textBox_phone.Text.Trim(), set_id))
                        {
                            // เริ่มบันทึก

                            // ปิดการแก้ไข
                            Enabled(false);

                            // ปุ่มแก้ไข
                            edit_save = true;
                            button_edit_save.Enabled = true;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                            button_edit_save.Text = "แก้ไข";
                            button_edit_save.FlatStyle = FlatStyle.Standard;
                            button_edit_save.BackColor = Color.Lime;

                            // ปุ่มเพิ่ม
                            add_save = true;
                            button_add_save.Enabled = true;
                            button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));
                            button_add_save.Text = "เพิ่ม";
                            button_add_save.FlatStyle = FlatStyle.Standard;
                            button_add_save.BackColor = Color.Lime;

                            // ปุ่มยกเลิก
                            button_cancel.Enabled = false;
                            button_cancel.FlatStyle = FlatStyle.Flat;
                            button_cancel.BackColor = Color.Lime;

                            // 
                            // เริ่ม แก้ไข
                            Class_Member_Detail.Edit(
                                set_id,
                                 textBox_phone.Text,
                                 set_sex,
                                 textBox_nick_name.Text,
                                 textBox_first_name.Text,
                                 textBox_last_name.Text,
                                 textBox_address.Text,
                                 textBox_sub_district.Text,
                                 textBox_district.Text,
                                 textBox_province.Text,
                                 textBox_postal_code.Text,
                                 textBox_discount_percent.Text,
                                 textBox_sale_per_point.Text,
                                 textBox_increase_point.Text,
                                 textBox_decrease_point.Text
                                 );


                            // ค้นหาอีกครั้ง
                            search_member();

                            // กดเลือกอีกครั้ง
                            dataGridView_member_CellMouseDown(dataGridView_member, new DataGridViewCellMouseEventArgs(1, dataGridView_member.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));

                            textBox_search.Focus();
                        }
                    }

                }
                button_edit_save.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_edit_save.Enabled = true;
            }
        }

        private void button_add_save_Click(object sender, EventArgs e)
        {
            try
            {
                button_add_save.Enabled = false;

                if (add_save) // กดเพิ่ม
                {


                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.Lime;

                    // ปุ่มเพิ่ม
                    add_save = false;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addSaveMember, new Size(50, 50));
                    button_add_save.Text = "บันทึก";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(192, 255, 192);

                    // เปิดปุ่มยกเลิก
                    button_cancel.Enabled = true;
                    button_cancel.FlatStyle = FlatStyle.Standard;
                    button_cancel.BackColor = Color.FromArgb(192, 255, 192);


                    // เปิดการแก้ไข
                    Enabled(true);

                    stringempty();

                    textBox_phone.Focus();
                }
                else // กดบันทึก เพิ่ม
                {
                    if (check_save())
                    {
                        if (Class_Check_Member.Phone(textBox_phone.Text.Trim(), ""))
                        {
                            // เปิดการแก้ไข
                            Enabled(false);

                            // ปุ่มแก้ไข
                            edit_save = true;
                            button_edit_save.Enabled = true;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                            button_edit_save.Text = "แก้ไข";
                            button_edit_save.FlatStyle = FlatStyle.Standard;
                            button_edit_save.BackColor = Color.Lime;

                            // ปุ่มเพิ่ม
                            add_save = true;
                            button_add_save.Enabled = true;
                            button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));
                            button_add_save.Text = "เพิ่ม";
                            button_add_save.FlatStyle = FlatStyle.Standard;
                            button_add_save.BackColor = Color.Lime;

                            // ปิดปุ่มยกเลิก
                            button_cancel.Enabled = false;
                            button_cancel.FlatStyle = FlatStyle.Flat;
                            button_cancel.BackColor = Color.Lime;

                            // เริ่ม เพิ่ม
                            Class_Member_Detail.Add(
                                textBox_phone.Text,
                                set_sex,
                                textBox_nick_name.Text,
                                textBox_first_name.Text,
                                textBox_last_name.Text,
                                textBox_address.Text,
                                textBox_sub_district.Text,
                                textBox_district.Text,
                                textBox_province.Text,
                                textBox_postal_code.Text,
                                textBox_discount_percent.Text,
                                textBox_sale_per_point.Text
                                );

                            // ใส่ค่าค้นหา
                            textBox_search.Text = textBox_phone.Text;

                            // เพิ่มค่าทังหมด
                            set_pro_total = (Convert.ToInt32(set_pro_total) + 1).ToString();

                            // ค้นหา
                            search_member();

                            // กดเลือกอีกครั้ง
                            dataGridView_member_CellMouseDown(dataGridView_member, new DataGridViewCellMouseEventArgs(1, dataGridView_member.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));



                            textBox_search.Focus();
                        }
                    }


                }
                button_add_save.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_add_save.Enabled = true;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                // ปุ่มยกเลิก
                button_cancel.Enabled = false;
                button_cancel.FlatStyle = FlatStyle.Flat;
                button_cancel.BackColor = Color.Lime;

                Enabled(false);

                if (!edit_save) // ยกเลิกของแก้ไข
                {
                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.Lime;

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.Lime;

                    // กดเลือกสินค้าเพื่อคืนค่า
                    dataGridView_member_CellMouseDown(dataGridView_member,
                    new DataGridViewCellMouseEventArgs(1, dataGridView_member.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                }
                if (!add_save) // ยกเลิกของเพิ่ม
                {
                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.Lime;

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.Lime;

                    stringempty();
                }


                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stringempty()
        {
            try
            {
                set_sex = "";

                textBox_phone.Text = "";

                // ปุ่มชาย
                button_sex_male.ForeColor = System.Drawing.Color.Gray;
                button_sex_male.BackColor = System.Drawing.Color.Transparent;

                // ปุ่มหญิง
                button_sex_female.ForeColor = System.Drawing.Color.Gray;
                button_sex_female.BackColor = System.Drawing.Color.Transparent;

                textBox_nick_name.Text = "";
                textBox_first_name.Text = "";
                textBox_last_name.Text = "";
                textBox_address.Text = "";
                textBox_sub_district.Text = "";
                textBox_district.Text = "";
                textBox_province.Text = "";
                textBox_postal_code.Text = "";

                textBox_discount_percent.Text = "0";
                label_sale_total.Text = "0";
                label_sale_ineffective_member.Text = "0";
                label_sale_effective_member.Text = "0";
                textBox_sale_per_point.Text = "1";

                label_point_balance.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool check_save()
        {
            try
            {
                if (textBox_phone.Text.Trim() != string.Empty &&
                   textBox_sale_per_point.Text.Trim() != string.Empty)
                {
                    if (Convert.ToDouble(textBox_sale_per_point.Text) > 0)
                    {
                        if(textBox_discount_percent.Text == string.Empty)
                        {
                            textBox_discount_percent.Text = "0";
                        }
                        if (textBox_increase_point.Text == string.Empty)
                        {
                            textBox_increase_point.Text = "0";
                        }
                        if (textBox_decrease_point.Text == string.Empty)
                        {
                            textBox_decrease_point.Text = "0";
                        }

                        if ((Convert.ToDouble(label_point_balance.Text) +
                            Convert.ToDouble(textBox_increase_point.Text) -
                            Convert.ToDouble(textBox_decrease_point.Text)) >= 0)
                        {
                            textBox_sale_per_point.Text = Convert.ToDouble(textBox_sale_per_point.Text).ToString("0.##");

                            if (set_sex == "")
                            {
                                set_sex = "ชาย";
                            }

                            return true;
                        }
                        else
                        {
                            MessageBox.Show("เพิ่มลดแต้ม ไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("ราคาขายต่อ 1 แต้ม : ต้องมากกว่า 0", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        private void textBox_sale_per_point_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // อนุญาตเฉพาะตัวเลข (0-9) และปุ่ม Control (เช่น Backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // ปฏิเสธปุ่มอื่นๆ ทั้งหมด
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_discount_percent_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดปุ่มควบคุมพื้นฐานได้ (เช่น Backspace, Delete)
                if (char.IsControl(e.KeyChar))
                {
                    return;
                }

                // 2. ตรวจสอบการกดปุ่ม "จุดทศนิยม"
                if (e.KeyChar == '.')
                {
                    // ถ้าใน TextBox มีจุดอยู่แล้ว ห้ามใส่จุดซ้ำอีก
                    if (txt.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                    return;
                }

                // 3. อนุญาตให้กดเฉพาะตัวเลข 0-9 เท่านั้น
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // 4. ตรวจสอบเงื่อนไขทศนิยม 2 ตำแหน่ง
                if (txt.Text.Contains("."))
                {
                    // หาตำแหน่งของจุดทศนิยมในข้อความ
                    int dotIndex = txt.Text.IndexOf('.');

                    // คำนวณหาตำแหน่งที่เคอร์เซอร์ (Cursor) กำลังกะพริบอยู่ปัจจุบัน
                    int cursorPosition = txt.SelectionStart;

                    // เงื่อนไข: ถ้าเคอร์เซอร์อยู่หลังจุดทศนิยม และข้อมูลหลังจุดพิมพ์ครบ 2 ตัวแล้ว
                    // และไม่มีการไฮไลท์ข้อความเพื่อพิมพ์ทับ (SelectionLength == 0)
                    if (cursorPosition > dotIndex && (txt.Text.Length - 1 - dotIndex) >= 2 && txt.SelectionLength == 0)
                    {
                        e.Handled = true; // บล็อกไม่ให้พิมพ์เพิ่ม
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size + 1, button.Font.Style);
            }
            catch
            {

            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size - 1, button.Font.Style);
            }
            catch
            {

            }
        }

        private void textBox_phone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (textBox_phone.Focused)
                    {
                        textBox_nick_name.Focus();
                    }
                    else if (textBox_nick_name.Focused)
                    {
                        textBox_first_name.Focus();
                    }
                    else if (textBox_first_name.Focused)
                    {
                        textBox_last_name.Focus();
                    }
                    else if (textBox_last_name.Focused)
                    {
                        textBox_address.Focus();
                    }
                    else if (textBox_address.Focused)
                    {
                        textBox_sub_district.Focus();
                    }
                    else if (textBox_sub_district.Focused)
                    {
                        textBox_district.Focus();
                    }
                    else if (textBox_district.Focused)
                    {
                        textBox_province.Focus();
                    }
                    else if (textBox_province.Focused)
                    {
                        textBox_postal_code.Focus();
                    }
                    else if (textBox_postal_code.Focused)
                    {
                        textBox_discount_percent.Focus();
                    }
                    else if (textBox_discount_percent.Focused)
                    {
                        textBox_sale_per_point.Focus();
                    }
                    else if (textBox_sale_per_point.Focused && textBox_increase_point.Enabled)
                    {
                        textBox_increase_point.Focus();
                    }
                    else if (textBox_increase_point.Focused && textBox_decrease_point.Enabled)
                    {
                        textBox_decrease_point.Focus();
                    }
                   
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
