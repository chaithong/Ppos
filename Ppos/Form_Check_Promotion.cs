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
    public partial class Form_Check_Promotion : Form
    {
        int count_search, set_search = 5;
        public static string pro_id;
        public Form_Check_Promotion()
        {
            InitializeComponent();
            this.DoubleBuffered = true;


            dataGridView_promotion.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_promotion, true, null);
            foreach (DataGridViewColumn column in dataGridView_promotion.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            new Class_TouchGrid(dataGridView_promotion);
            dataGridView_promotion.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView_promotion.EnableHeadersVisualStyles = false;
            dataGridView_promotion.MouseWheel += new MouseEventHandler(dataGridView_invoice_MouseWheel!);

            textBox_search.LostFocus += TextBox_search_LostFocus;

           
        }
        private void TextBox_search_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch
            {

            }
        }

        private void dataGridView_invoice_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_promotion.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_promotion.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_promotion.RowCount)
            {
                newIndex = dataGridView_promotion.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_promotion.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void Form_Check_Promotion_Load(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = true;
                backgroundWorker_search.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_search_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // 
                        cmd_sqlite.CommandText = @"SELECT  p.pro_desc,p.pro_id,p.pro_type,p.pro_desc ,
                                                    p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                    strftime('%d/%m/%Y',p.start_datetime) as start_date,
                                                    strftime('%d/%m/%Y',p.end_datetime) as end_date,
                                                    strftime('%H:%M',p.start_datetime) as start_time,
                                                    strftime('%H:%M',p.end_datetime) as end_time,
                                                    p.mon,p.tue,p.wed,p.thu,p.fri,p.sat,p.sun
                                                    from  Promotion p   
                                                    where p.status = '1'
                                                     and date(p.start_datetime) <= date('now', 'localtime') 
                                                     and date(p.end_datetime) >= date('now', 'localtime') 
                                                     and case 
                                                         when time(p.end_datetime) <> '00:00:00' then
                                                              time(p.start_datetime) <= strftime('%H:%M:%S', 'now', 'localtime')
                                                         and  time(p.end_datetime) >= strftime('%H:%M:%S', 'now', 'localtime') 
                                                         else 1
                                                     end
                                                     and case 
    	                                                    when strftime('%w', 'now', 'localtime') = '0' then p.sun = 1
                                                         when strftime('%w', 'now', 'localtime') = '1' then p.mon = 1
                                                         when strftime('%w', 'now', 'localtime') = '2' then p.tue = 1
                                                         when strftime('%w', 'now', 'localtime') = '3' then p.wed = 1
                                                         when strftime('%w', 'now', 'localtime') = '4' then p.thu = 1
                                                         when strftime('%w', 'now', 'localtime') = '5' then p.fri = 1
                                                         when strftime('%w', 'now', 'localtime') = '6' then p.sat = 1
                                                     end ";
                        if (textBox_search.Text.Trim() != string.Empty)
                        {
                            cmd_sqlite.CommandText += "and p.pro_desc like '%" + textBox_search.Text.Trim() + "%' ";
                        }

                        cmd_sqlite.CommandText += "order by p.end_datetime ,p.pro_type ,p.created_date  ";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);

                        dataGridView_promotion.Columns["seq"]!.HeaderText = "0";
                        if (dt.Rows.Count > 0)
                        {
                            string time_start_end = "", day;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[0]["end_time"].ToString()! != "00:00")
                                {
                                    time_start_end = dt.Rows[i]["start_time"] + " ถึง " + dt.Rows[i]["end_time"];
                                }
                                else
                                {
                                    time_start_end = "24 ชั่งโมง";
                                }
                                // วัน
                                day = "";
                                if (Convert.ToBoolean(dt.Rows[i]["mon"]))
                                {
                                    day += "จันทร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["tue"]))
                                {
                                    day += "อังคาร ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["wed"]))
                                {
                                    day += "พุธ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["thu"]))
                                {
                                    day += "พฤหัส ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["fri"]))
                                {
                                    day += "ศุกร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["sat"]))
                                {
                                    day += "เสาร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[i]["sun"]))
                                {
                                    day += "อาทิตย์";
                                }
                                // เชค all day
                                if (day == "จันทร์ อังคาร พุธ พฤหัส ศุกร์ เสาร์ อาทิตย์")
                                {
                                    day = "ทุกวัน";
                                }
                                dataGridView_promotion.Rows.Add("",
                                (i + 1),
                                Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(30, 30)),
                                dt.Rows[i]["pro_id"],
                                dt.Rows[i]["pro_type"],
                                dt.Rows[i]["pro_desc"],
                                dt.Rows[i]["start_date"] + " ถึง " + dt.Rows[i]["end_date"],
                                time_start_end,
                                day,
                                ""
                                );
                                dataGridView_promotion.Columns["seq"]!.HeaderText = (i + 1).ToString();
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
        private void backgroundWorker_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dataGridView_promotion.Enabled = true;
                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_promotion_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_promotion.Rows[e.RowIndex].Cells["detail"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(40, 40));

                    dataGridView_promotion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Lime;
                    dataGridView_promotion.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Lime;
                }
            }
            catch
            {

            }
        }

        private void dataGridView_promotion_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_promotion.Rows[e.RowIndex].Cells["detail"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(30, 30));

                    dataGridView_promotion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView_promotion.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch
            {

            }
        }

        private void timer_search_Tick(object sender, EventArgs e)
        {
            try
            {
                count_search++;
                if (count_search == set_search)
                {
                    count_search = 0;
                    timer_search.Stop();
                    dataGridView_promotion.Rows.Clear();
                    dataGridView_promotion.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Check_Promotion_Shown(object sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                count_search = 0;
                if (!timer_search.Enabled)
                {
                    timer_search.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_promotion_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dataGridView_promotion.Columns["detail"]!.Index)
                    {
                        pro_id = dataGridView_promotion.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;
                        open_detail();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_promotion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    pro_id = dataGridView_promotion.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;
                    open_detail();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void open_detail()
        {
            try
            {
               
                Form_Promotion_Detail form_Promotion_Detail = new Form_Promotion_Detail();
                form_Promotion_Detail.Size = new Size(this.Width / 2, this.Height * 9 / 10);
                form_Promotion_Detail.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
