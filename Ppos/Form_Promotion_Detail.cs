using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Promotion_Detail : Form
    {
        public Form_Promotion_Detail()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
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

                dataGridView_item_premium.MouseWheel += new MouseEventHandler(dataGridView_item_premium_MouseWheel!);

               
            }
            catch
            {
                this.Close();
            }
        }
        private void Form_Promotion_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                search_pro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void dataGridView_item_premium_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item_premium.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item_premium.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item_premium.RowCount)
            {
                newIndex = dataGridView_item_premium.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item_premium.FirstDisplayedScrollingRowIndex = newIndex;
        }

        private void search_pro()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // 
                        cmd_sqlite.CommandText = @" SELECT  p.pro_desc,p.pro_id,p.pro_type,p.pro_desc ,
                                                    p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                    strftime('%d/%m/%Y',p.start_datetime) as start_date,
                                                    strftime('%d/%m/%Y',p.end_datetime) as end_date,
                                                    strftime('%H:%M',p.start_datetime) as start_time,
                                                    strftime('%H:%M',p.end_datetime) as end_time,
                                                    p.mon,p.tue,p.wed,p.thu,p.fri,p.sat,p.sun,
                                                    pi.item_code,pi.item_name ,pi.item_set_qty,i.small_unit 
                                                    from Promotion p   
                                                    join Promotion_Items pi on pi.pro_id = p.pro_id 
                                                    join Item i on i.code = pi.item_code 
                                                    where  p.pro_id = " + Form_Check_Promotion.pro_id;

                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            // ถ้าไม่ใช่ของแถม จะปิดของแถม
                            if (dt.Rows[0]["offer_type"].ToString() != Class_Parameter.offer_type_premium)
                            {
                                tableLayoutPanel_bottom.ColumnStyles[1].Width = 0;
                            }
                            // ถ้าเป็นโปรชุดสินค้า
                            if (dt.Rows[0]["pro_type"].ToString() == Class_Parameter.pro_set_item)
                            {
                                dataGridView_item_pro.Columns["item_qty_pro"]!.Visible = true;
                                dataGridView_item_pro.Columns["item_unit_pro"]!.Visible = true;
                            }
                            //
                            this.Text += " " + dt.Rows[0]["pro_type"].ToString();
                            label_name.Text = dt.Rows[0]["pro_desc"].ToString();

                            if (dt.Rows[0]["pro_type"].ToString()! != Class_Parameter.pro_set_item)
                            {
                                label_criterion.Text = dt.Rows[0]["criterion_type"].ToString() + " " + dt.Rows[0]["criterion_value"].ToString();
                            }
                            else
                            {
                                tableLayoutPanel_top.RowStyles[1].Height = 0;
                            }

                            label_offer.Text = dt.Rows[0]["offer_type"].ToString() + " " + dt.Rows[0]["offer_value"].ToString() + " " + dt.Rows[0]["discount_type"].ToString();

                            label_repeat.Text = dt.Rows[0]["repeat"].ToString();

                            label_date.Text = dt.Rows[0]["start_date"].ToString() + " ถึง " + dt.Rows[0]["end_date"].ToString();

                            if (dt.Rows[0]["end_time"].ToString()! != "00:00")
                            {
                                label_time.Text = dt.Rows[0]["start_time"] + " ถึง " + dt.Rows[0]["end_time"];
                            }
                            else
                            {
                                label_time.Text = "24 ชั่งโมง";
                            }
                            // วัน
                            string day = "";
                            if (Convert.ToBoolean(dt.Rows[0]["mon"]))
                            {
                                day += "จันทร์ ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["tue"]))
                            {
                                day += "อังคาร ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["wed"]))
                            {
                                day += "พุธ ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["thu"]))
                            {
                                day += "พฤหัส ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["fri"]))
                            {
                                day += "ศุกร์ ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["sat"]))
                            {
                                day += "เสาร์ ";
                            }
                            if (Convert.ToBoolean(dt.Rows[0]["sun"]))
                            {
                                day += "อาทิตย์";
                            }
                            // เชค all day
                            if (day == "จันทร์ อังคาร พุธ พฤหัส ศุกร์ เสาร์ อาทิตย์")
                            {
                                day = "ทุกวัน";
                            }
                            label_day.Text = day;

                            // เริ่มใส่สินค้า

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                label_item_pro.Text = "สินค้าโปร (" + (i + 1) + ")";
                                dataGridView_item_pro.Rows.Add(
                                     (i + 1) + ".",
                                     dt.Rows[i]["item_name"].ToString()!,
                                     dt.Rows[i]["item_set_qty"].ToString()!,
                                     dt.Rows[i]["small_unit"].ToString()!
                                    );
                            }

                            if (dt.Rows[0]["offer_type"].ToString() == Class_Parameter.offer_type_premium) // ถ้าเป็นของแถม
                            {
                                // เริ่มใส่ของแถม
                                // 
                                cmd_sqlite.CommandText = @"SELECT  p.pro_desc,p.pro_id,p.pro_type,p.pro_desc ,
                                                    p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                    strftime('%d/%m/%Y',p.start_datetime) as start_date,
                                                    strftime('%d/%m/%Y',p.end_datetime) as end_date,
                                                    strftime('%H:%M',p.start_datetime) as start_time,
                                                    strftime('%H:%M',p.end_datetime) as end_time,
                                                    p.mon,p.tue,p.wed,p.thu,p.fri,p.sat,p.sun,
                                                    pi.item_code,pi.item_name ,i.small_unit 
                                                    from Promotion p   
                                                    join Promotion_Items_Premium pi on pi.pro_id = p.pro_id 
                                                    join Item i on i.code = pi.item_code 
                                                    where  p.pro_id = " + Form_Check_Promotion.pro_id;

                                reader = cmd_sqlite.ExecuteReader();
                                dt = new System.Data.DataTable();
                                dt.Load(reader);
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {

                                        label_item_premium.Text = "สินค้าแถม (" + (i + 1) + ")";
                                        dataGridView_item_premium.Rows.Add(
                                             (i + 1) + ".",
                                             dt.Rows[i]["item_name"].ToString()!,
                                             dt.Rows[i]["offer_value"].ToString()!,
                                             dt.Rows[i]["small_unit"].ToString()!
                                            );
                                    }
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            this.Close();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                // label.ForeColor = Color.Lime;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size + 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                // label.ForeColor = Color.Black;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            }
            catch
            {

            }
        }
        private void dataGridView_item_pro_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item_pro.Rows[e.RowIndex].Cells["item_name_pro"].Style.Font = new System.Drawing.Font(
                        dataGridView_item_pro.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item_pro.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_pro_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item_pro.Rows[e.RowIndex].Cells["item_name_pro"].Style.Font = new System.Drawing.Font(
                        dataGridView_item_pro.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item_pro.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // 

                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_item_premium_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item_premium.Rows[e.RowIndex].Cells["item_name_premium"].Style.Font = new System.Drawing.Font(
                        dataGridView_item_premium.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item_premium.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_premium_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item_premium.Rows[e.RowIndex].Cells["item_name_premium"].Style.Font = new System.Drawing.Font(
                        dataGridView_item_premium.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item_premium.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // 

                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
