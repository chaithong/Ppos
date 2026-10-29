using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Pro_Set_Item : Form
    {

        object senders;
        int set_timer_count = 10, timer_count = 0;
        bool add_save = true, edit_save = true;
        int Limit = 50;

        string set_pro_total;

        string set_pro_id = "";

        int set_search_pro = 5, count_set_search_pro = 0;
        int set_search_item = 5, count_set_search_item = 0;
        int set_search_item_premium = 5, count_set_search_item_premium = 0;

        int shows = 0;

        DataTable dt;

        Color E_Day = Color.WhiteSmoke;
        Color D_Day = Color.White;
        public Form_Pro_Set_Item()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                Class_DoubleBuffer.EnableDoubleBuffering(tableLayoutPanel_back);
                groupBox_detail.Text = Class_Parameter.pro_base_item;

                groupBox_detail.Location = new Point(
                   (panel_detail.Width / 2) - (groupBox_detail.Width / 2),
                   0);

                groupBox_datetime.Location = new Point(groupBox_detail.Location.X, groupBox_detail.Height);

                groupBox_item.Location = new Point(groupBox_detail.Location.X, groupBox_detail.Height + groupBox_datetime.Height);

                groupBox_premium.Location = new Point(groupBox_detail.Location.X, groupBox_detail.Height + groupBox_datetime.Height + groupBox_item.Height);
                Enable(false);
                //////
                dataGridView_promotion.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_promotion, true, null);

                foreach (DataGridViewColumn column in dataGridView_promotion.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_promotion);

                dataGridView_promotion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128,255,128);
                dataGridView_promotion.EnableHeadersVisualStyles = false;
                /////
                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);

                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);

                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                dataGridView_item.EnableHeadersVisualStyles = false;
                /////
                dataGridView_item_pro.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item_pro, true, null);

                foreach (DataGridViewColumn column in dataGridView_item_pro.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item_pro);

                dataGridView_item_pro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                dataGridView_item_pro.EnableHeadersVisualStyles = false;

                dataGridView_item_pro.MouseWheel += new MouseEventHandler(dataGridView_item_pro_MouseWheel!);
                //////
                /// /////
                dataGridView_item_premium.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item_premium, true, null);

                foreach (DataGridViewColumn column in dataGridView_item_premium.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item_premium);

                dataGridView_item_premium.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                dataGridView_item_premium.EnableHeadersVisualStyles = false;
                /////
                /// /////
                dataGridView_item_premium_pro.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item_premium_pro, true, null);

                foreach (DataGridViewColumn column in dataGridView_item_premium_pro.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item_premium_pro);

                dataGridView_item_premium_pro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                dataGridView_item_premium_pro.EnableHeadersVisualStyles = false;

                dataGridView_item_premium_pro.MouseWheel += new MouseEventHandler(dataGridView_item_premium_pro_MouseWheel!);
                /////

                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));

                button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));

                button_cancel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

                label_up_hour_start.Image = Class_Image.resizeImage(Ppos.Properties.Resources.ups, new Size(20, 20));
                label_down_hour_start.Image = Class_Image.resizeImage(Ppos.Properties.Resources.downs, new Size(20, 20));

                label_up_hour_end.Image = Class_Image.resizeImage(Ppos.Properties.Resources.ups, new Size(20, 20));
                label_down_hour_end.Image = Class_Image.resizeImage(Ppos.Properties.Resources.downs, new Size(20, 20));

                label_up_second_start.Image = Class_Image.resizeImage(Ppos.Properties.Resources.ups, new Size(20, 20));
                label_down_second_start.Image = Class_Image.resizeImage(Ppos.Properties.Resources.downs, new Size(20, 20));

                label_up_second_end.Image = Class_Image.resizeImage(Ppos.Properties.Resources.ups, new Size(20, 20));
                label_down_second_end.Image = Class_Image.resizeImage(Ppos.Properties.Resources.downs, new Size(20, 20));

                label_item_pro.Text = "ใช้โปร " + dataGridView_item_pro.RowCount.ToString("#,##0") + " รายการ";
                label_item_premium_pro.Text = "ใช้โปร " + dataGridView_item_premium_pro.RowCount.ToString("#,##0") + " รายการ";

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);

                // เลือก combobox
                comboBox_offer.Items.Add(Class_Parameter.offer_type_discount);
                comboBox_offer.Items.Add(Class_Parameter.offer_type_set_value);
                comboBox_offer.Items.Add(Class_Parameter.offer_type_premium);
                comboBox_offer.SelectedIndex = 0;

                comboBox_discount_type.Items.Add(Class_Parameter.discount_type_per_qty);
                comboBox_discount_type.Items.Add(Class_Parameter.discount_type_per_value);
                comboBox_discount_type.SelectedIndex = 0;

                comboBox_repeat.Items.Add(Class_Parameter.repeat);
                comboBox_repeat.Items.Add(Class_Parameter.not_repeat);
                comboBox_repeat.SelectedIndex = 0;

                // กำหนดวันล่าสุด
                label_date_start.Text = DateTime.Now.ToString("dd-MM-yyyy");
                label_date_end.Text = DateTime.Now.ToString("dd-MM-yyyy");
                // กำหนดเวลา

                // ปรับภาพ วันมีผลโปร
                // วันจันทร์
                if (Class_Parameter.pro_mon)
                {
                    button_mon.BackColor = E_Day;
                    button_mon.ForeColor = Color.Black;
                }
                else
                {
                    button_mon.BackColor = D_Day;
                    button_mon.ForeColor = Color.Gray;
                }
                // วันอังคาร
                if (Class_Parameter.pro_tue)
                {
                    button_tue.BackColor = E_Day;
                    button_tue.ForeColor = Color.Black;
                }
                else
                {
                    button_tue.BackColor = D_Day;
                    button_tue.ForeColor = Color.Gray;
                }
                // วันพูธ
                if (Class_Parameter.pro_wed)
                {
                    button_wed.BackColor = E_Day;
                    button_wed.ForeColor = Color.Black;
                }
                else
                {
                    button_wed.BackColor = D_Day;
                    button_wed.ForeColor = Color.Gray;
                }
                // วันพฤหัส
                if (Class_Parameter.pro_thu)
                {
                    button_thu.BackColor = E_Day;
                    button_thu.ForeColor = Color.Black;
                }
                else
                {
                    button_thu.BackColor = D_Day;
                    button_thu.ForeColor = Color.Gray;
                }
                // วันศุกร์
                if (Class_Parameter.pro_fri)
                {
                    button_fri.BackColor = E_Day;
                    button_fri.ForeColor = Color.Black;
                }
                else
                {
                    button_fri.BackColor = D_Day;
                    button_fri.ForeColor = Color.Gray;
                }
                // วันเสาร์
                if (Class_Parameter.pro_sat)
                {
                    button_sat.BackColor = E_Day;
                    button_sat.ForeColor = Color.Black;
                }
                else
                {
                    button_sat.BackColor = D_Day;
                    button_sat.ForeColor = Color.Gray;
                }
                // วันอาทิตย์
                if (Class_Parameter.pro_sun)
                {
                    button_sun.BackColor = E_Day;
                    button_sun.ForeColor = Color.Black;
                }
                else
                {
                    button_sun.BackColor = D_Day;
                    button_sun.ForeColor = Color.Gray;
                }

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // โปรทั้งหมด
                        cmd_sqlite.CommandText = "select count(pro_id) from Promotion where status = 1 and pro_type = '" + Class_Parameter.pro_set_item + "'";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void dataGridView_item_pro_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item_pro.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item_pro.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item_pro.RowCount)
            {
                newIndex = dataGridView_item_pro.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item_pro.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void dataGridView_item_premium_pro_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item_premium_pro.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item_premium_pro.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item_premium_pro.RowCount)
            {
                newIndex = dataGridView_item_premium_pro.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item_premium_pro.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void timer_show_Tick(object sender, EventArgs e)
        {
            try
            {
                shows++;
                if (shows == 1)
                {
                    groupBox_detail.Visible = true;
                }
                else if (shows == 2)
                {
                    groupBox_datetime.Visible = true;
                }
                else
                {
                    groupBox_item.Visible = true;
                    timer_show.Stop();
                }


            }
            catch (Exception ex)
            {
                timer_show.Stop();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Enable(bool e)
        {
            try
            {
                dataGridView_promotion.Enabled = !e;
                textBox_search.Enabled = !e;

                groupBox_detail.Enabled = e;
                groupBox_datetime.Enabled = e;

                textBox_search_item.Visible = e;
                textBox_search_item_pro.Visible = e;
                dataGridView_item_pro.Columns["delete_item_pro"]!.Visible = e;
                //  groupBox_item.Enabled = e;               

                textBox_search_item_premium.Visible = e;
                textBox_search_item_premium_pro.Visible = e;
                dataGridView_item_premium_pro.Columns["delete_item_premium_pro"]!.Visible = e;
                //   groupBox_premium.Enabled = e;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Form_Pro_Set_Item_Load(object sender, EventArgs e)
        {
            try
            {
                search_pro();
                timer_show.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void search_pro()
        {
            try
            {
                dataGridView_promotion.Rows.Clear();

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT " +
                           "pro_id, pro_type, pro_desc, " +
                           "criterion_type, criterion_value, " +
                           "offer_type, offer_value, discount_type, repeat, " +
                           "STRFTIME('%d-%m-%Y',start_datetime) as start_date ,STRFTIME('%H:%M',start_datetime) as start_time , " +
                           "STRFTIME('%d-%m-%Y',end_datetime) as end_date, STRFTIME('%H:%M',end_datetime) as end_time," +
                           "mon, tue, wed, thu, fri, sat, sun " +
                                               "FROM Promotion " +
                                               "WHERE status = 1 and pro_type = '" + Class_Parameter.pro_set_item + "' ";
                        if (textBox_search.Text != "")
                        {
                            cmd_sqlite.CommandText += "and pro_desc like '%" + textBox_search.Text + "%' ";
                        }
                        cmd_sqlite.CommandText += "order by pro_id desc ";
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
                            System.Drawing.Image active;

                            // 1. สร้างตัวแปรมารองรับผลลัพธ์การแปลงวันที่
                            DateTime date_start;
                            DateTime date_end;
                            DateTime date_now;
                            bool isValid_start, isValid_end;
                            bool isValid_now = DateTime.TryParseExact(DateTime.Now.ToString("dd-MM-yyyy"),
                                                     "dd-MM-yyyy",
                                                     CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None,
                                                     out date_now);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                // 2. แปลงข้อความจากทั้ง 2 Label (แนะนำใช้ TryParse เพื่อความปลอดภัย)

                                isValid_start = DateTime.TryParseExact(dt.Rows[i]["start_date"].ToString(),
                                                     "dd-MM-yyyy",
                                                     CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None,
                                                     out date_start);

                                isValid_end = DateTime.TryParseExact(dt.Rows[i]["end_date"].ToString(),
                                                    "dd-MM-yyyy",
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out date_end);

                                active = new Bitmap(40, 40);
                                if (isValid_start && isValid_end && isValid_now)
                                {
                                    if (date_now >= date_start && date_now <= date_end)
                                    {
                                        active = Class_Image.resizeImage(Ppos.Properties.Resources.clock, new Size(35, 35));
                                    }


                                }

                                dataGridView_promotion.Rows.Add(
                                     dt.Rows[i]["pro_id"].ToString()!,
                                     dt.Rows[i]["pro_type"].ToString()!,
                                     active,
                                     dt.Rows[i]["pro_desc"].ToString()!,
                                     dt.Rows[i]["criterion_type"].ToString()!,
                                     dt.Rows[i]["criterion_value"].ToString()!,
                                     dt.Rows[i]["offer_type"].ToString()!,
                                     dt.Rows[i]["offer_value"].ToString()!,
                                     dt.Rows[i]["discount_type"].ToString()!,
                                     dt.Rows[i]["repeat"].ToString()!,
                                     dt.Rows[i]["start_date"].ToString()!,
                                     dt.Rows[i]["start_time"].ToString()!,
                                     dt.Rows[i]["end_date"].ToString()!,
                                     dt.Rows[i]["end_time"].ToString()!,
                                     dt.Rows[i]["mon"].ToString()!,
                                     dt.Rows[i]["tue"].ToString()!,
                                     dt.Rows[i]["wed"].ToString()!,
                                     dt.Rows[i]["thu"].ToString()!,
                                     dt.Rows[i]["fri"].ToString()!,
                                     dt.Rows[i]["sat"].ToString()!,
                                     dt.Rows[i]["sun"].ToString()!,
                                    Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)));
                                // ถ้าเป็นข้อมูลที่เลือกไว้ จะ select ให้
                                if (dt.Rows[i]["pro_id"].ToString() == set_pro_id)
                                {
                                    selected = true;
                                    dataGridView_promotion.Rows[i].Selected = true;
                                    dataGridView_promotion.CurrentCell = dataGridView_promotion.Rows[i].Cells["pro_desc"];
                                }
                            }
                            // ถ้าไม่มีข้อมูลเดิมจะไม่เลือก
                            if (!selected)
                            {
                                dataGridView_promotion.ClearSelection();
                            }

                        }
                    }
                }
                // นับจำนวนค้นหา
                label_search.Text = set_pro_total;
                if (dataGridView_promotion.RowCount > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_pro_total;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_offer.SelectedIndex == 2) // ของแถม
                {
                    groupBox_premium.Visible = true;
                    label_unit_type.Text = "หน่วย";

                    comboBox_discount_type.SelectedIndex = 0;
                    comboBox_discount_type.Enabled = false;
                }
                else // ส่วนลด กับ กำหนดราคา
                {
                    groupBox_premium.Visible = false;
                    label_unit_type.Text = "บาท";

                    comboBox_discount_type.Enabled = true;
                }
                textBox_offer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_repeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_offer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void day_click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                if (button.Name == "button_mon")
                {
                    if (Class_Parameter.pro_mon)
                    {
                        Class_Parameter.pro_mon = false;
                        button_mon.BackColor = D_Day;
                        button_mon.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_mon = true;
                        button_mon.BackColor = E_Day;
                        button_mon.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_tue")
                {
                    if (Class_Parameter.pro_tue)
                    {
                        Class_Parameter.pro_tue = false;
                        button_tue.BackColor = D_Day;
                        button_tue.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_tue = true;
                        button_tue.BackColor = E_Day;
                        button_tue.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_wed")
                {
                    if (Class_Parameter.pro_wed)
                    {
                        Class_Parameter.pro_wed = false;
                        button_wed.BackColor = D_Day;
                        button_wed.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_wed = true;
                        button_wed.BackColor = E_Day;
                        button_wed.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_thu")
                {
                    if (Class_Parameter.pro_thu)
                    {
                        Class_Parameter.pro_thu = false;
                        button_thu.BackColor = D_Day;
                        button_thu.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_thu = true;
                        button_thu.BackColor = E_Day;
                        button_thu.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_fri")
                {
                    if (Class_Parameter.pro_fri)
                    {
                        Class_Parameter.pro_fri = false;
                        button_fri.BackColor = D_Day;
                        button_fri.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_fri = true;
                        button_fri.BackColor = E_Day;
                        button_fri.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_sat")
                {
                    if (Class_Parameter.pro_sat)
                    {
                        Class_Parameter.pro_sat = false;
                        button_sat.BackColor = D_Day;
                        button_sat.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_sat = true;
                        button_sat.BackColor = E_Day;
                        button_sat.ForeColor = Color.Black;
                    }
                }
                else if (button.Name == "button_sun")
                {
                    if (Class_Parameter.pro_sun)
                    {
                        Class_Parameter.pro_sun = false;
                        button_sun.BackColor = D_Day;
                        button_sun.ForeColor = Color.Gray;
                    }
                    else
                    {
                        Class_Parameter.pro_sun = true;
                        button_sun.BackColor = E_Day;
                        button_sun.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label_date_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                if (label.Name == "label_date_start")
                {
                    Class_Parameter.calendar_title = "วันที่เริ่มใช้งาน";

                    Class_Parameter.calendar_day = label_date_start.Text.Split("-")[0];
                    Class_Parameter.calendar_month = label_date_start.Text.Split("-")[1];
                    Class_Parameter.calendar_year = label_date_start.Text.Split("-")[2];
                }
                else
                {
                    Class_Parameter.calendar_title = "วันสุดท้ายใช้งาน";

                    Class_Parameter.calendar_day = label_date_end.Text.Split("-")[0];
                    Class_Parameter.calendar_month = label_date_end.Text.Split("-")[1];
                    Class_Parameter.calendar_year = label_date_end.Text.Split("-")[2];
                }

                Form_Calendar form_Calendar = new Form_Calendar();
                form_Calendar.ShowDialog(this);

                if (!form_Calendar.cancel)
                {
                    label.Text = form_Calendar.label_set_days.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                ((Label)sender).BackColor = Color.WhiteSmoke;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                ((Label)sender).BackColor = Color.White;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void KeyPress_Number(object sender, KeyPressEventArgs e)
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
        private void label_mouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                senders = sender;
                timer_up_down.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_up_down.Stop();
                timer_count = 0;
            }

        }

        private void label_mouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                up_down_hour_second(sender);
                timer_up_down.Stop();
                timer_count = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_up_down.Stop();
                timer_count = 0;
            }
        }

        private void timer_up_down_Tick(object sender, EventArgs e)
        {
            try
            {
                timer_count++;
                if (timer_count >= set_timer_count)
                {
                    up_down_hour_second(senders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_up_down.Stop();
                timer_count = 0;
            }
        }
        private void up_down_hour_second(object sender)
        {
            try
            {
                Label label = (Label)sender;
                if (label.Name == "label_up_hour_start")
                {

                    if (Convert.ToInt16(textBox_hour_start.Text) >= 23)
                    {
                        textBox_hour_start.Text = "00";
                    }
                    else
                    {
                        textBox_hour_start.Text = (Convert.ToInt16(textBox_hour_start.Text) + 1).ToString("00");
                    }
                }
                else if (label.Name == "label_down_hour_start")
                {

                    if (Convert.ToInt16(textBox_hour_start.Text) <= 0)
                    {
                        textBox_hour_start.Text = "23";
                    }
                    else
                    {
                        textBox_hour_start.Text = (Convert.ToInt16(textBox_hour_start.Text) - 1).ToString("00");
                    }
                }
                else if (label.Name == "label_up_second_start")
                {
                    if (Convert.ToInt16(textBox_second_start.Text) >= 59)
                    {
                        textBox_second_start.Text = "00";
                    }
                    else
                    {
                        textBox_second_start.Text = (Convert.ToInt16(textBox_second_start.Text) + 1).ToString("00");
                    }
                }
                else if (label.Name == "label_down_second_start")
                {
                    if (Convert.ToInt16(textBox_second_start.Text) <= 0)
                    {
                        textBox_second_start.Text = "59";
                    }
                    else
                    {
                        textBox_second_start.Text = (Convert.ToInt16(textBox_second_start.Text) - 1).ToString("00");
                    }
                }
                else if (label.Name == "label_up_hour_end")
                {
                    if (Convert.ToInt16(textBox_hour_end.Text) >= 23)
                    {
                        textBox_hour_end.Text = "00";
                    }
                    else
                    {
                        textBox_hour_end.Text = (Convert.ToInt16(textBox_hour_end.Text) + 1).ToString("00");
                    }
                }
                else if (label.Name == "label_down_hour_end")
                {
                    if (Convert.ToInt16(textBox_hour_end.Text) <= 0)
                    {
                        textBox_hour_end.Text = "23";
                    }
                    else
                    {
                        textBox_hour_end.Text = (Convert.ToInt16(textBox_hour_end.Text) - 1).ToString("00");
                    }
                }
                else if (label.Name == "label_up_second_end")
                {
                    if (Convert.ToInt16(textBox_second_end.Text) >= 59)
                    {
                        textBox_second_end.Text = "00";
                    }
                    else
                    {
                        textBox_second_end.Text = (Convert.ToInt16(textBox_second_end.Text) + 1).ToString("00");
                    }
                }
                else if (label.Name == "label_down_second_end")
                {
                    if (Convert.ToInt16(textBox_second_end.Text) <= 0)
                    {
                        textBox_second_end.Text = "59";
                    }
                    else
                    {
                        textBox_second_end.Text = (Convert.ToInt16(textBox_second_end.Text) - 1).ToString("00");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_up_down.Stop();
                timer_count = 0;
            }
        }
        private void button_edit_save_Click(object sender, EventArgs e)
        {
            try
            {
                button_edit_save.Enabled = false;


                if (Class_Check_Pro.Edit_Pro(set_pro_id))
                {

                    if (edit_save) // กดแก้ไข
                    {
                        if (textBox_desc.Text != "")
                        {
                            textBox_search_item.Text = "";
                            textBox_search_item_pro.Text = "";
                            textBox_search_item_premium.Text = "";
                            textBox_search_item_premium_pro.Text = "";

                            dataGridView_item.Rows.Clear();
                            dataGridView_item_premium.Rows.Clear();

                            // ปุ่มแก้ไข
                            edit_save = false;
                            button_edit_save.Enabled = true;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(45, 45));
                            button_edit_save.Text = "บันทึก";
                            button_edit_save.FlatStyle = FlatStyle.Standard;
                            button_edit_save.BackColor = Color.FromArgb(192, 255, 192);

                            // ปุ่มเพิ่ม
                            add_save = true;
                            button_add_save.Enabled = false;
                            button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                            button_add_save.Text = "เพิ่ม";
                            button_add_save.FlatStyle = FlatStyle.Flat;
                            button_add_save.BackColor = Color.FromArgb(128,255,128);

                            // เปิดปุ่มยกเลิก
                            button_cancel.Enabled = true;
                            button_cancel.FlatStyle = FlatStyle.Standard;
                            button_cancel.BackColor = Color.FromArgb(192, 255, 192);

                            Enable(true);

                            textBox_desc.Focus();
                        }
                    }
                    else // กดบันทึก
                    {
                        if (check_text_empty() && check_number() && check_date() && check_time())
                        {
                            if (Class_Check_Pro.Desc(textBox_desc.Text.Trim(), set_pro_id) &&
                                Class_Check_Pro.Items(
                                dataGridView_item_pro,
                                dataGridView_item_premium_pro,
                                set_pro_id) &&
                                Class_Check_Pro.Amounts(
                                Class_Parameter.pro_set_item,
                                "",
                                "",
                                comboBox_offer.Text,
                                textBox_offer.Text,
                                comboBox_discount_type.Text,
                                dataGridView_item_pro) &&
                                 Class_Check_Pro.Item_Duplicate(
                                dataGridView_item_pro,
                                dataGridView_item_premium_pro,
                                comboBox_offer.Text)
                                )
                            {
                                // เริ่มบันทึก

                                textBox_search_item.Text = "";
                                textBox_search_item_pro.Text = "";
                                textBox_search_item_premium.Text = "";
                                textBox_search_item_premium_pro.Text = "";

                                dataGridView_item.Rows.Clear();
                                dataGridView_item_premium.Rows.Clear();

                                // ปิดการแก้ไข
                                Enable(false);

                                // ปุ่มแก้ไข
                                edit_save = true;
                                button_edit_save.Enabled = true;
                                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                                button_edit_save.Text = "แก้ไข";
                                button_edit_save.FlatStyle = FlatStyle.Standard;
                                button_edit_save.BackColor = Color.FromArgb(128,255,128);

                                // ปุ่มเพิ่ม
                                add_save = true;
                                button_add_save.Enabled = true;
                                button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                                button_add_save.Text = "เพิ่ม";
                                button_add_save.FlatStyle = FlatStyle.Standard;
                                button_add_save.BackColor = Color.FromArgb(128,255,128);

                                // ปุ่มยกเลิก
                                button_cancel.Enabled = false;
                                button_cancel.FlatStyle = FlatStyle.Flat;
                                button_cancel.BackColor = Color.FromArgb(128,255,128);

                                // 
                                // เริ่ม แก้ไข
                                set_pro_id = Class_Promotion.Pro_Item(
                                    set_pro_id,
                                    Class_Parameter.pro_set_item,
                                    textBox_desc.Text,
                                    "",
                                    "0",
                                    comboBox_offer.Text,
                                    textBox_offer.Text,
                                    comboBox_discount_type.Text,
                                    comboBox_repeat.Text,
                                    label_date_start.Text.Split("-")[2] + "-" + label_date_start.Text.Split("-")[1] + "-" + label_date_start.Text.Split("-")[0] + " " +
                                    textBox_hour_start.Text + ":" + textBox_second_start.Text + ":00",
                                    label_date_end.Text.Split("-")[2] + "-" + label_date_end.Text.Split("-")[1] + "-" + label_date_end.Text.Split("-")[0] + " " +
                                    textBox_hour_end.Text + ":" + textBox_second_end.Text + ":00",
                                    Class_ConvertDGVToDT.DGVToDT(dataGridView_item_pro),
                                    Class_ConvertDGVToDT.DGVToDT(dataGridView_item_premium_pro)
                                    );


                                // ค้นหาอีกครั้ง
                                search_pro();
                                //
                                dataGridView_item_pro.Rows.Clear();
                                dataGridView_item_premium_pro.Rows.Clear();
                                // กดเลือกอีกครั้ง
                                dataGridView_promotion_CellMouseDown(dataGridView_promotion, new DataGridViewCellMouseEventArgs(2, dataGridView_promotion.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));

                                textBox_search.Focus();

                            }
                        }
                    }
                }
                
                textBox_search.Focus();
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
                    dataGridView_promotion.ClearSelection();

                    textBox_search_item.Text = "";
                    textBox_search_item_pro.Text = "";
                    textBox_search_item_premium.Text = "";
                    textBox_search_item_premium_pro.Text = "";

                    dataGridView_item.Rows.Clear();
                    dataGridView_item_premium.Rows.Clear();
                    dataGridView_item_pro.Rows.Clear();
                    dataGridView_item_premium_pro.Rows.Clear();

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = false;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(45, 45));
                    button_add_save.Text = "บันทึก";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(192, 255, 192);

                    // เปิดปุ่มยกเลิก
                    button_cancel.Enabled = true;
                    button_cancel.FlatStyle = FlatStyle.Standard;
                    button_cancel.BackColor = Color.FromArgb(192, 255, 192);


                    Enable(true);

                    stringempty();

                    textBox_desc.Focus();
                }
                else // กดบันทึก เพิ่ม
                {
                    if (check_text_empty() && check_number() && check_date() && check_time())
                    {
                        if (Class_Check_Pro.Desc(textBox_desc.Text.Trim(), "") &&
                            Class_Check_Pro.Items(
                            dataGridView_item_pro,
                            dataGridView_item_premium_pro,
                            "") &&
                            Class_Check_Pro.Amounts(
                            Class_Parameter.pro_set_item,
                            "",
                            "",
                            comboBox_offer.Text,
                            textBox_offer.Text,
                            comboBox_discount_type.Text,
                            dataGridView_item_pro) &&
                             Class_Check_Pro.Item_Duplicate(
                            dataGridView_item_pro,
                            dataGridView_item_premium_pro,
                            comboBox_offer.Text)
                            )
                        {
                            textBox_search_item.Text = "";
                            textBox_search_item_pro.Text = "";
                            textBox_search_item_premium.Text = "";
                            textBox_search_item_premium_pro.Text = "";

                            dataGridView_item.Rows.Clear();
                            dataGridView_item_premium.Rows.Clear();


                            // ปุ่มแก้ไข
                            edit_save = true;
                            button_edit_save.Enabled = true;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                            button_edit_save.Text = "แก้ไข";
                            button_edit_save.FlatStyle = FlatStyle.Standard;
                            button_edit_save.BackColor = Color.FromArgb(128,255,128);

                            // ปุ่มเพิ่ม
                            add_save = true;
                            button_add_save.Enabled = true;
                            button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                            button_add_save.Text = "เพิ่ม";
                            button_add_save.FlatStyle = FlatStyle.Standard;
                            button_add_save.BackColor = Color.FromArgb(128,255,128);

                            // ปิดปุ่มยกเลิก
                            button_cancel.Enabled = false;
                            button_cancel.FlatStyle = FlatStyle.Flat;
                            button_cancel.BackColor = Color.FromArgb(128,255,128);

                            // เริ่ม เพิ่ม
                            set_pro_id = Class_Promotion.Pro_Item(
                                "",
                                Class_Parameter.pro_set_item,
                                textBox_desc.Text,
                                "",
                                "0",
                                comboBox_offer.Text,
                                textBox_offer.Text,
                                comboBox_discount_type.Text,
                                comboBox_repeat.Text,
                                label_date_start.Text.Split("-")[2] + "-" + label_date_start.Text.Split("-")[1] + "-" + label_date_start.Text.Split("-")[0] + " " +
                                textBox_hour_start.Text + ":" + textBox_second_start.Text + ":00",
                                label_date_end.Text.Split("-")[2] + "-" + label_date_end.Text.Split("-")[1] + "-" + label_date_end.Text.Split("-")[0] + " " +
                                textBox_hour_end.Text + ":" + textBox_second_end.Text + ":00",
                                Class_ConvertDGVToDT.DGVToDT(dataGridView_item_pro),
                                Class_ConvertDGVToDT.DGVToDT(dataGridView_item_premium_pro)
                                );

                            // ใส่ค่าค้นหา
                            textBox_search.Text = textBox_desc.Text;
                            // เพิ่มค่าทังหมด
                            set_pro_total = (Convert.ToInt32(set_pro_total.Replace(",", "")) + 1).ToString();

                            // ค้นหา
                            search_pro();

                            dataGridView_item_pro.Rows.Clear();
                            dataGridView_item_premium_pro.Rows.Clear();

                            // กดเลือกอีกครั้ง
                            dataGridView_promotion_CellMouseDown(dataGridView_promotion, new DataGridViewCellMouseEventArgs(2, dataGridView_promotion.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));


                            Enable(false);

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
                button_cancel.BackColor = Color.FromArgb(128,255,128);

                textBox_search_item.Text = "";
                textBox_search_item_pro.Text = "";
                textBox_search_item_premium.Text = "";
                textBox_search_item_premium_pro.Text = "";

                dataGridView_item.Rows.Clear();
                dataGridView_item_premium.Rows.Clear();
                dataGridView_item_pro.Rows.Clear();
                dataGridView_item_premium_pro.Rows.Clear();

                if (!edit_save) // ยกเลิกของแก้ไข
                {
                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(128,255,128);

                    // กดเลือกสินค้าเพื่อคืนค่า
                    dataGridView_promotion_CellMouseDown(dataGridView_promotion,
                    new DataGridViewCellMouseEventArgs(2, dataGridView_promotion.CurrentRow!.Index, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                }
                if (!add_save) // ยกเลิกของเพิ่ม
                {

                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Flat;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // ปุ่มเพิ่ม
                    add_save = true;
                    button_add_save.Enabled = true;
                    button_add_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.add_item, new Size(50, 50));
                    button_add_save.Text = "เพิ่ม";
                    button_add_save.FlatStyle = FlatStyle.Standard;
                    button_add_save.BackColor = Color.FromArgb(128,255,128);

                    stringempty();
                }

                Enable(false);

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
                label_item_pro.Text = "ใช้โปร 0 รายการ";

                label_item_premium_pro.Text = "ใช้โปร 0 รายการ";

                textBox_desc.Text = "";
                textBox_offer.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_promotion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {


                    dataGridView_promotion.Rows[e.RowIndex].Selected = true;

                    set_pro_id = dataGridView_promotion.Rows[e.RowIndex].Cells["pro_id"].Value!.ToString()!;

                    textBox_desc.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["pro_desc"].Value!.ToString();
                    comboBox_offer.SelectedItem = dataGridView_promotion.Rows[e.RowIndex].Cells["offer_type"].Value!.ToString();
                    textBox_offer.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["offer_value"].Value!.ToString();

                    comboBox_discount_type.SelectedItem = dataGridView_promotion.Rows[e.RowIndex].Cells["discount_type"].Value!.ToString();
                    comboBox_repeat.SelectedItem = dataGridView_promotion.Rows[e.RowIndex].Cells["repeat"].Value!.ToString();


                    label_date_start.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["start_date"].Value!.ToString();
                    label_date_end.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["end_date"].Value!.ToString();


                    textBox_hour_start.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["start_time"].Value!.ToString()!.Split(":")[0];
                    textBox_second_start.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["start_time"].Value!.ToString()!.Split(":")[1];

                    textBox_hour_end.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["end_time"].Value!.ToString()!.Split(":")[0];
                    textBox_second_end.Text = dataGridView_promotion.Rows[e.RowIndex].Cells["end_time"].Value!.ToString()!.Split(":")[1];


                    // วันจันทร์
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["mon"].Value!.ToString()))
                    {
                        Class_Parameter.pro_mon = true;
                        button_mon.BackColor = E_Day;
                        button_mon.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_mon = false;
                        button_mon.BackColor = D_Day;
                        button_mon.ForeColor = Color.Gray;
                    }
                    // วันอังคาร
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["tue"].Value!.ToString()))
                    {
                        Class_Parameter.pro_tue = true;
                        button_tue.BackColor = E_Day;
                        button_tue.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_tue = false;
                        button_tue.BackColor = D_Day;
                        button_tue.ForeColor = Color.Gray;
                    }
                    // วันพูธ
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["wed"].Value!.ToString()))
                    {
                        Class_Parameter.pro_wed = true;
                        button_wed.BackColor = E_Day;
                        button_wed.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_wed = false;
                        button_wed.BackColor = D_Day;
                        button_wed.ForeColor = Color.Gray;
                    }
                    // วันพฤหัส
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["thu"].Value!.ToString()))
                    {
                        Class_Parameter.pro_thu = true;
                        button_thu.BackColor = E_Day;
                        button_thu.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_thu = false;
                        button_thu.BackColor = D_Day;
                        button_thu.ForeColor = Color.Gray;
                    }
                    // วันศุกร์
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["fri"].Value!.ToString()))
                    {
                        Class_Parameter.pro_fri = true;
                        button_fri.BackColor = E_Day;
                        button_fri.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_fri = false;
                        button_fri.BackColor = D_Day;
                        button_fri.ForeColor = Color.Gray;
                    }
                    // วันเสาร์
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["sat"].Value!.ToString()))
                    {
                        Class_Parameter.pro_sat = true;
                        button_sat.BackColor = E_Day;
                        button_sat.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_sat = false;
                        button_sat.BackColor = D_Day;
                        button_sat.ForeColor = Color.Gray;
                    }
                    // วันอาทิตย์
                    if (Convert.ToBoolean(dataGridView_promotion.Rows[e.RowIndex].Cells["sun"].Value!.ToString()))
                    {
                        Class_Parameter.pro_sun = true;
                        button_sun.BackColor = E_Day;
                        button_sun.ForeColor = Color.Black;
                    }
                    else
                    {
                        Class_Parameter.pro_sun = false;
                        button_sun.BackColor = D_Day;
                        button_sun.ForeColor = Color.Gray;
                    }

                    // ค้นหาสินค้า
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // สินค้าโปร
                            cmd_sqlite.CommandText = "SELECT item_code,item_name,item_price,item_set_qty,barcode_small,barcode_medium,barcode_large " +
                                                     "from Promotion_Items pi " +
                                                      "where pi.pro_id = " + set_pro_id;
                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);
                            dataGridView_item_pro.Rows.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dataGridView_item_pro.Rows.Add(dt.Rows[i]["item_code"].ToString()!,
                                                               dt.Rows[i]["item_name"].ToString()!,
                                                               dt.Rows[i]["item_price"].ToString()!,
                                                               dt.Rows[i]["item_set_qty"].ToString()!,
                                                               Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                                               dt.Rows[i]["barcode_small"].ToString()!,
                                                               dt.Rows[i]["barcode_medium"].ToString()!,
                                                               dt.Rows[i]["barcode_large"].ToString()!
                                                               );
                                }
                                label_item_pro.Text = "ใช้โปร " + dataGridView_item_pro.RowCount.ToString("#,##0") + " รายการ";
                                dataGridView_item_pro.ClearSelection();
                            }

                            // สินค้าแถม
                            cmd_sqlite.CommandText = "SELECT item_code,item_name,item_price,barcode_small,barcode_medium,barcode_large " +
                                                     "from Promotion_Items_Premium pip " +
                                                      "where pip.pro_id = " + set_pro_id;
                            er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);
                            dataGridView_item_premium_pro.Rows.Clear();
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dataGridView_item_premium_pro.Rows.Add(dt.Rows[i]["item_code"].ToString()!,
                                                               dt.Rows[i]["item_name"].ToString()!,
                                                               dt.Rows[i]["item_price"].ToString()!,
                                                               Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                                               dt.Rows[i]["barcode_small"].ToString()!,
                                                               dt.Rows[i]["barcode_medium"].ToString()!,
                                                               dt.Rows[i]["barcode_large"].ToString()!
                                                               );
                                }
                                label_item_premium_pro.Text = "ใช้โปร " + dataGridView_item_premium_pro.RowCount.ToString("#,##0") + " รายการ";
                                dataGridView_item_premium_pro.ClearSelection();
                            }
                        }
                    }


                    // ปุ่มแก้ไข
                    edit_save = true;
                    button_edit_save.Enabled = true;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                    button_edit_save.Text = "แก้ไข";
                    button_edit_save.FlatStyle = FlatStyle.Standard;
                    button_edit_save.BackColor = Color.FromArgb(128,255,128);

                    // กดลบ
                    if (e.ColumnIndex == dataGridView_promotion.Columns["delete"]!.Index)
                    {
                        if (Class_Check_Pro.Edit_Pro(set_pro_id))
                        {
                            if (MessageBox.Show("ต้องการลบ " + dataGridView_promotion.Rows[e.RowIndex].Cells["pro_desc"].Value!.ToString() + " ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // ปุ่มแก้ไข
                                edit_save = true;
                                button_edit_save.Enabled = false;
                                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                                button_edit_save.Text = "แก้ไข";
                                button_edit_save.FlatStyle = FlatStyle.Flat;
                                button_edit_save.BackColor = Color.FromArgb(128,255,128);
                                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                                {
                                    con_sqlite.Open();
                                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                    {
                                        cmd_sqlite.CommandText = "UPDATE Promotion SET status = 0, " +
                                             "updated_date = datetime('now', 'localtime'), " +
                                             "updated_by = '" + Class_Parameter.User_Login + "' " +
                                           "WHERE pro_id = " + dataGridView_promotion.Rows[e.RowIndex].Cells["pro_id"].Value!.ToString();
                                        cmd_sqlite.ExecuteNonQuery();

                                        // ลบโปรทั้งหมดอีก 1 รายการ
                                        set_pro_total = (Convert.ToInt32(set_pro_total.Replace(",", "")) - 1).ToString();

                                        stringempty();
                                        dataGridView_item.Rows.Clear();
                                        dataGridView_item_pro.Rows.Clear();
                                        dataGridView_item_premium.Rows.Clear();
                                        dataGridView_item_premium_pro.Rows.Clear();

                                        search_pro();
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer_search_pro_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search_pro++;
                if (count_set_search_pro >= set_search_pro)
                {
                    timer_search_pro.Stop();
                    count_set_search_pro = 0;
                    search_pro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_pro.Stop();
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search_pro.Enabled)
                {
                    timer_search_pro.Start();
                }
                count_set_search_pro = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_pro.Stop();
            }
        }
        private void search_item()
        {
            try
            {
                dataGridView_item.Rows.Clear();

                if (textBox_search_item.Text != "")
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = "SELECT code,group_main,group_sub,name," +
                                                   "small_barcode,small_unit," +
                                                   "round(case when cast(large_price as real) / cast(large_qty_small as real) is not null " +
                                                   "then min(small_price,cast(medium_price as real) / cast(medium_qty_small as real) ,cast(large_price as real) / cast(large_qty_small as real)) " +
                                                   "when cast(medium_price as real) / cast(medium_qty_small as real) is not null " +
                                                   "then min(small_price,cast(medium_price as real) / cast(medium_qty_small as real)) " +
                                                   "else small_price end,2) as small_price," +
                                                   "small_cost_last,small_cost_avg,small_qty," +
                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status " +
                                                   "from Item " +
                                                   "WHERE status = 1 and effective_promotion = 1 ";
                            /* if (dataGridView_item_pro.RowCount > 0)
                             {
                                 cmd_sqlite.CommandText += "and " +
                                                           "code not in(";
                                 for (int i = 0; i < dataGridView_item_pro.RowCount; i++)
                                 {
                                     cmd_sqlite.CommandText += dataGridView_item_pro.Rows[i].Cells["item_code_pro"].Value.ToString() + ",";
                                 }
                                 cmd_sqlite.CommandText = cmd_sqlite.CommandText.Substring(0, cmd_sqlite.CommandText.Length - 1) + ") ";
                             }*/

                            cmd_sqlite.CommandText += "and " +
                                                    "(name like '%" + textBox_search_item.Text + "%' or " +
                                                    "small_barcode like '%" + textBox_search_item.Text + "%' or " +
                                                    "medium_barcode like '%" + textBox_search_item.Text + "%' or " +
                                                    "large_barcode like '%" + textBox_search_item.Text + "%') "
                                                    ;

                            cmd_sqlite.CommandText += "order by code desc ";

                            cmd_sqlite.CommandText += "limit 10";

                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);

                            if (dt.Rows.Count > 0)
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dataGridView_item.Rows.Add(
                                         dt.Rows[i]["code"].ToString()!,
                                         dt.Rows[i]["name"].ToString()!,
                                         dt.Rows[i]["small_price"].ToString()!,
                                         Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(25, 25)),
                                         dt.Rows[i]["small_barcode"].ToString()!,
                                         dt.Rows[i]["medium_barcode"].ToString()!,
                                         dt.Rows[i]["large_barcode"].ToString()!
                                         );

                                }

                                dataGridView_item.ClearSelection();


                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer_search_item_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search_item++;
                if (count_set_search_item >= set_search_item)
                {
                    timer_search_item.Stop();
                    count_set_search_item = 0;
                    search_item();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_item.Stop();
            }
        }

        private void textBox_search_item_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search_item.Enabled)
                {
                    timer_search_item.Start();
                }
                count_set_search_item = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_item.Stop();
            }
        }
        private void search_item_premium()
        {
            try
            {
                dataGridView_item_premium.Rows.Clear();

                if (textBox_search_item_premium.Text != "")
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = "SELECT code,group_main,group_sub,name," +
                                                   "small_barcode,small_unit," +
                                                   "round(case when cast(large_price as real) / cast(large_qty_small as real) is not null " +
                                                   "then min(small_price,cast(medium_price as real) / cast(medium_qty_small as real) ,cast(large_price as real) / cast(large_qty_small as real)) " +
                                                   "when cast(medium_price as real) / cast(medium_qty_small as real) is not null " +
                                                   "then min(small_price,cast(medium_price as real) / cast(medium_qty_small as real)) " +
                                                   "else small_price end,2) as small_price," +
                                                   "small_cost_last,small_cost_avg,small_qty," +
                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status " +
                                                   "from Item " +
                                                   "WHERE status = 1 and effective_promotion = 1 ";
                             if (dataGridView_item_premium_pro.RowCount > 0)
                             {
                                 cmd_sqlite.CommandText += "and " +
                                                           "code not in(";
                                 for (int i = 0; i < dataGridView_item_premium_pro.RowCount; i++)
                                 {
                                     cmd_sqlite.CommandText += dataGridView_item_premium_pro.Rows[i].Cells["item_code_premium_pro"].Value!.ToString() + ",";
                                 }
                                 cmd_sqlite.CommandText = cmd_sqlite.CommandText.Substring(0, cmd_sqlite.CommandText.Length - 1) + ") ";
                             }

                            cmd_sqlite.CommandText += "and " +
                                                    "(name like '%" + textBox_search_item_premium.Text + "%' or " +
                                                    "small_barcode like '%" + textBox_search_item_premium.Text + "%' or " +
                                                    "medium_barcode like '%" + textBox_search_item_premium.Text + "%' or " +
                                                    "large_barcode like '%" + textBox_search_item_premium.Text + "%') "
                                                    ;

                            cmd_sqlite.CommandText += "order by code desc ";

                            cmd_sqlite.CommandText += "limit 10";

                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);

                            if (dt.Rows.Count > 0)
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    dataGridView_item_premium.Rows.Add(
                                         dt.Rows[i]["code"].ToString()!,
                                         dt.Rows[i]["name"].ToString()!,
                                         dt.Rows[i]["small_price"].ToString()!,
                                         Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(25, 25)),
                                         dt.Rows[i]["small_barcode"].ToString()!,
                                         dt.Rows[i]["medium_barcode"].ToString()!,
                                         dt.Rows[i]["large_barcode"].ToString()!
                                         );

                                }

                                dataGridView_item_premium.ClearSelection();


                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_search_item_premium_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search_item_premium++;
                if (count_set_search_item_premium >= set_search_item_premium)
                {
                    timer_search_item_premium.Stop();
                    count_set_search_item_premium = 0;
                    search_item_premium();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_item_premium.Stop();
            }
        }

        private void textBox_search_item_premium_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search_item_premium.Enabled)
                {
                    timer_search_item_premium.Start();
                }
                count_set_search_item_premium = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_item_premium.Stop();
            }
        }
        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    // dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // สีที่ต้องการตอนชี้
                    if (dataGridView.Name != "dataGridView_item_pro")
                    {
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                    }
                    else
                    {
                        dataGridView.Rows[e.RowIndex].Cells["item_name_pro"].Style.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    // dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    if (dataGridView.Name != "dataGridView_item_pro")
                    {
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                    }
                    else
                    {
                        dataGridView.Rows[e.RowIndex].Cells["item_name_pro"].Style.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_offer_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (dataGridView != null)
                {

                    if (dataGridView.Name == "dataGridView_item")
                    {
                        if (e.RowIndex != -1)
                        {
                            if (e.ColumnIndex == dataGridView_item.Columns["add_item_pro"]!.Index)
                            {
                                bool isRowMatched = false;
                                foreach (DataGridViewRow dataGridViewRow in dataGridView_item_pro.Rows)
                                {
                                    if (dataGridViewRow.Cells["item_code_pro"].Value!.ToString() == dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_code"].Value!.ToString())
                                    {
                                        dataGridViewRow.Cells["item_set_qty_pro"].Value = Convert.ToInt16(dataGridViewRow.Cells["item_set_qty_pro"].Value) + 1;
                                        dataGridView_item_pro.CurrentCell = dataGridViewRow.Cells[1];
                                        isRowMatched = true;
                                        break;
                                    }
                                }
                                if (!isRowMatched)
                                {
                                    // เริ่ม add
                                    dataGridView_item_pro.Rows.Add(dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["item_code"].Value!,
                                                                   dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_name"].Value!,
                                                                   dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_price"].Value!,
                                                                   "1",
                                                                   Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                                                   dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_barcode_small"].Value!,
                                                                   dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_barcode_medium"].Value!,
                                                                   dataGridView_item.Rows[dataGridView_item.CurrentRow.Index].Cells["item_barcode_large"].Value!
                                                                   );
                                    dataGridView_item_pro.CurrentCell = dataGridView_item_pro.Rows[dataGridView_item_pro.Rows.Count - 1].Cells[1];
                                    //
                                }


                                label_item_pro.Text = "ใช้โปร " + dataGridView_item_pro.RowCount.ToString("#,##0") + " รายการ";
                                textBox_search_item_pro_TextChanged(sender, e);
                            }
                        }

                        textBox_search_item.Focus();
                        textBox_search_item.SelectAll();
                    }
                    else if (dataGridView.Name == "dataGridView_item_pro")
                    {
                        if (e.RowIndex != -1)
                        {
                            if (e.ColumnIndex == dataGridView_item_pro.Columns["delete_item_pro"]!.Index)
                            {
                                dataGridView_item_pro.Rows.RemoveAt(e.RowIndex);

                                label_item_pro.Text = "ใช้โปร " + dataGridView_item_pro.RowCount.ToString("#,##0") + " รายการ";

                                search_item();
                                textBox_search_item_pro_TextChanged(sender, e);
                            }
                        }

                        textBox_search_item_pro.Focus();
                        textBox_search_item_pro.SelectAll();
                    }
                    else if (dataGridView.Name == "dataGridView_item_premium")
                    {
                        if (e.RowIndex != -1)
                        {
                            if (e.ColumnIndex == dataGridView_item_premium.Columns["add_item_premium_pro"]!.Index)
                            {
                                dataGridView_item_premium_pro.Rows.Add(dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow!.Index].Cells["item_code_premium"].Value!,
                                                                       dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow.Index].Cells["item_name_premium"].Value!,
                                                                       dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow.Index].Cells["item_price_premium"].Value!,
                                                                       Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                                                       dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow.Index].Cells["item_premium_barcode_small"].Value!,
                                                                       dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow.Index].Cells["item_premium_barcode_medium"].Value!,
                                                                       dataGridView_item_premium.Rows[dataGridView_item_premium.CurrentRow.Index].Cells["item_premium_barcode_large"].Value!
                                                                       );

                                dataGridView_item_premium_pro.CurrentCell = dataGridView_item_premium_pro.Rows[dataGridView_item_premium_pro.Rows.Count - 1].Cells[1];

                                label_item_premium_pro.Text = "ใช้โปร " + dataGridView_item_premium_pro.RowCount.ToString("#,##0") + " รายการ";

                                search_item_premium();
                                textBox_search_item_premium_pro_TextChanged(sender, e);
                            }
                        }

                        textBox_search_item_premium.Focus();
                        textBox_search_item_premium.SelectAll();
                    }
                    else if (dataGridView.Name == "dataGridView_item_premium_pro")
                    {
                        if (e.RowIndex != -1)
                        {
                            if (e.ColumnIndex == dataGridView_item_premium_pro.Columns["delete_item_premium_pro"]!.Index)
                            {
                                dataGridView_item_premium_pro.Rows.RemoveAt(e.RowIndex);

                                label_item_premium_pro.Text = "ใช้โปร " + dataGridView_item_premium_pro.RowCount.ToString("#,##0") + " รายการ";

                                search_item_premium();
                                textBox_search_item_premium_pro_TextChanged(sender, e);
                            }
                        }

                        textBox_search_item_premium_pro.Focus();
                        textBox_search_item_premium_pro.SelectAll();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_search_item_pro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_item_pro.RowCount > 0)
                {
                    string searchText = textBox_search_item_pro.Text.Trim().ToLower();

                    // 1. เคลียร์การเลือกช่อง (CurrentCell) เป็น null ก่อน 
                    // เพื่อป้องกันระบบค้าง/Error เวลาแถวที่กำลังถูกไฮไลต์อยู่โดนสั่งซ่อน (Visible = false)
                    dataGridView_item_pro.CurrentCell = null;

                    // 2. เริ่มวนลูปตรวจสอบทีละแถว (Row)
                    foreach (DataGridViewRow row in dataGridView_item_pro.Rows)
                    {
                        // ข้ามแถวว่างสุดท้ายที่ระบบสร้างไว้สำหรับให้ผู้ใช้คลิกพิมพ์เพิ่มข้อมูลใหม่
                        if (row.IsNewRow) continue;

                        // สร้างตัวแปรไว้เก็บสถานะว่า "เจอคำค้นหาในแถวนี้ไหม" (เริ่มต้นให้เป็น false ก่อน)
                        bool isRowMatched = false;

                        // 3. วนลูปเจาะลึกเข้าไปเช็กทุก ๆ คอลัมน์ (Cell) ในแถวนั้น ๆ
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                string cellValue = cell.Value.ToString()!.ToLower();

                                // ถ้าเจอคำค้นหาใน Cell ใด Cell หนึ่งของแถวนี้ ให้ถือว่าผ่านทันที
                                if (cellValue.Contains(searchText))
                                {
                                    isRowMatched = true;
                                    break; // เจอแล้ว 1 ช่องในแถวนี้ ไม่ต้องเสียเวลาวนลูปเช็กช่องอื่นในแถวนี้ต่อ
                                }
                            }
                        }

                        // 4. สั่งการแสดงผลของแถวนี้: ถ้าเจอคำค้นหาให้แสดง (true) ถ้าไม่เจอเลยให้ซ่อน (false)
                        row.Visible = isRowMatched;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox_search_item_premium_pro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_item_premium_pro.RowCount > 0)
                {
                    string searchText = textBox_search_item_premium_pro.Text.Trim().ToLower();

                    // 1. เคลียร์การเลือกช่อง (CurrentCell) เป็น null ก่อน 
                    // เพื่อป้องกันระบบค้าง/Error เวลาแถวที่กำลังถูกไฮไลต์อยู่โดนสั่งซ่อน (Visible = false)
                    dataGridView_item_premium_pro.CurrentCell = null;

                    // 2. เริ่มวนลูปตรวจสอบทีละแถว (Row)
                    foreach (DataGridViewRow row in dataGridView_item_premium_pro.Rows)
                    {
                        // ข้ามแถวว่างสุดท้ายที่ระบบสร้างไว้สำหรับให้ผู้ใช้คลิกพิมพ์เพิ่มข้อมูลใหม่
                        if (row.IsNewRow) continue;

                        // สร้างตัวแปรไว้เก็บสถานะว่า "เจอคำค้นหาในแถวนี้ไหม" (เริ่มต้นให้เป็น false ก่อน)
                        bool isRowMatched = false;

                        // 3. วนลูปเจาะลึกเข้าไปเช็กทุก ๆ คอลัมน์ (Cell) ในแถวนั้น ๆ
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                string cellValue = cell.Value.ToString()!.ToLower();

                                // ถ้าเจอคำค้นหาใน Cell ใด Cell หนึ่งของแถวนี้ ให้ถือว่าผ่านทันที
                                if (cellValue.Contains(searchText))
                                {
                                    isRowMatched = true;
                                    break; // เจอแล้ว 1 ช่องในแถวนี้ ไม่ต้องเสียเวลาวนลูปเช็กช่องอื่นในแถวนี้ต่อ
                                }
                            }
                        }

                        // 4. สั่งการแสดงผลของแถวนี้: ถ้าเจอคำค้นหาให้แสดง (true) ถ้าไม่เจอเลยให้ซ่อน (false)
                        row.Visible = isRowMatched;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool check_text_empty()
        {
            try
            {
                if (textBox_desc.Text != "" && textBox_desc.Text != string.Empty &&
                   textBox_offer.Text != "" && textBox_offer.Text != string.Empty &&
                   textBox_hour_start.Text != "" && textBox_hour_start.Text != string.Empty &&
                   textBox_hour_end.Text != "" && textBox_hour_end.Text != string.Empty &&
                   textBox_second_start.Text != "" && textBox_second_start.Text != string.Empty &&
                   textBox_second_end.Text != "" && textBox_second_end.Text != string.Empty &&
                   dataGridView_item_pro.RowCount > 1
                    )
                {
                    if (comboBox_offer.SelectedIndex == 2) // แถมสินค้า
                    {
                        if (dataGridView_item_premium_pro.RowCount > 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("กรุณาเพิ่มสินค้าของแถม", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (dataGridView_item_pro.RowCount == 1)
                    {
                        MessageBox.Show("สินค้าโปรต้องมี 2 รายการขึ้นไป", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool check_number()
        {
            try
            {
                double number_offer, number_hst, number_hen, number_sst, number_sen;
                if (double.TryParse(textBox_offer.Text, out number_offer) &&
                   double.TryParse(textBox_hour_start.Text, out number_hst) &&
                   double.TryParse(textBox_hour_end.Text, out number_hen) &&
                   double.TryParse(textBox_second_start.Text, out number_sst) &&
                   double.TryParse(textBox_second_end.Text, out number_sen)
                  )
                {
                    if (Convert.ToDouble(textBox_offer.Text) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("ข้อมูลไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("ข้อมูลไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool check_date()
        {
            try
            {
                // 1. สร้างตัวแปรมารองรับผลลัพธ์การแปลงวันที่
                DateTime date_start;
                DateTime date_end;

                // 2. แปลงข้อความจากทั้ง 2 Label (แนะนำใช้ TryParse เพื่อความปลอดภัย)

                bool isValid_start = DateTime.TryParseExact(label_date_start.Text,
                                      "dd-MM-yyyy",
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None,
                                      out date_start);

                bool isValid_end = DateTime.TryParseExact(label_date_end.Text,
                                     "dd-MM-yyyy",
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out date_end);

                if (isValid_start && isValid_end)
                {
                    // 3. นำวันที่มาลบกัน จะได้วัตถุ TimeSpan
                    // แนะนำใช้ .Date เพื่อคิดเฉพาะวันที่ ไม่เอาเรื่อง "ชั่วโมง/นาที" มาคำนวณปน
                    if (date_start.Date > date_end.Date)
                    {
                        MessageBox.Show("วันที่เริ่ม ต้องน้อยกว่า วันสุดท้าย", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("วันที่มีปัญหา !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool check_time()
        {
            try
            {
                if (Convert.ToInt16(textBox_hour_start.Text) <= 23 &&
                   Convert.ToInt16(textBox_hour_end.Text) <= 23 &&
                   Convert.ToInt16(textBox_second_start.Text) <= 59 &&
                   Convert.ToInt16(textBox_second_end.Text) <= 59
                    )
                {
                    if (textBox_hour_start.Text == "0")
                    {
                        textBox_hour_start.Text = "00";
                    }
                    if (textBox_hour_end.Text == "0")
                    {
                        textBox_hour_end.Text = "00";
                    }
                    if (textBox_second_start.Text == "0")
                    {
                        textBox_second_start.Text = "00";
                    }
                    if (textBox_hour_end.Text == "0")
                    {
                        textBox_hour_end.Text = "00";

                    }
                    // ถ้าเป็น 00:00 ให้บันทีกได้
                    if (textBox_hour_start.Text == "00" &&
                       textBox_hour_end.Text == "00" &&
                       textBox_second_start.Text == "00" &&
                       textBox_second_end.Text == "00")
                    {
                        return true;
                    }
                    // 1. สร้างตัวแปรมารองรับผลลัพธ์การแปลงวันที่
                    DateTime time_start;
                    DateTime time_end;

                    // 2. แปลงข้อความจากทั้ง 2 Label (แนะนำใช้ TryParse เพื่อความปลอดภัย)

                    bool isValid_start = DateTime.TryParseExact(textBox_hour_start.Text + ":" + textBox_second_start.Text + ":00",
                                          "HH:mm:ss",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          out time_start);

                    bool isValid_end = DateTime.TryParseExact(textBox_hour_end.Text + ":" + textBox_second_end.Text + ":00",
                                         "HH:mm:ss",
                                         CultureInfo.InvariantCulture,
                                         DateTimeStyles.None,
                                         out time_end);

                    if (isValid_start && isValid_end)
                    {

                        if (time_start >= time_end)
                        {
                            MessageBox.Show("เวลาเริ่มต้น ต้องน้อยกว่า เวลาสุดท้าย", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("เวลามีปัญหา !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("เวลาไม่ถูกต้อง !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.Font = new Font("Segoe UI", button.Font.Size - 1, button.Font.Style);
            }
            catch
            {

            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.Font = new Font("Segoe UI", button.Font.Size + 1, button.Font.Style);
            }
            catch
            {

            }
        }
        private void label_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                label.Font = new Font("Segoe UI", label.Font.Size + 1, label.Font.Style);
            }
            catch
            {

            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                label.Font = new Font("Segoe UI", label.Font.Size - 1, label.Font.Style);
            }
            catch
            {

            }
        }

       
    }
}
