using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Check_Invoice : Form
    {
        public static string trx_no_void = "", id_member_void = "";
        public static int point_use, point_inc;

        int count_search, set_search = 5;

        public static string trx_no_detail = "", trx_no_status = "";

        DateTime currentDate = DateTime.Now;

        public Form_Check_Invoice()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;



                dataGridView_invoice.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_invoice, true, null);
                foreach (DataGridViewColumn column in dataGridView_invoice.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_invoice);
                dataGridView_invoice.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dataGridView_invoice.EnableHeadersVisualStyles = false;
                dataGridView_invoice.MouseWheel += new MouseEventHandler(dataGridView_invoice_MouseWheel!);

                label_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

                textBox_search.LostFocus += TextBox_search_LostFocus;

            }
            catch
            {

            }
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
            if (dataGridView_invoice.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_invoice.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_invoice.RowCount)
            {
                newIndex = dataGridView_invoice.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_invoice.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void Form_Check_Invoice_Load(object sender, EventArgs e)
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

        private void dataGridView_invoice_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    // กดลบ
                    if (e.ColumnIndex == dataGridView_invoice.Columns["void_bill"]!.Index &&
                        dataGridView_invoice.Rows[e.RowIndex].Cells["status"].Value!.ToString() == "ขาย")
                    {
                        if (MessageBox.Show("ต้องการยกเลิกบิล " + dataGridView_invoice.Rows[e.RowIndex].Cells["trx_no"].Value!.ToString() + " ใช่หรือไม่ ?", "ยกเลิกบิล", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            trx_no_void = dataGridView_invoice.Rows[e.RowIndex].Cells["trx_no"].Value!.ToString()!;
                            id_member_void = dataGridView_invoice.Rows[e.RowIndex].Cells["id_member"].Value!.ToString()!;


                            point_use = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["discount_point"].Value!.ToString()!);
                            point_inc = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["point_increase"].Value!.ToString()!);

                            backgroundWorker_void.RunWorkerAsync();

                        }
                    }
                    else if (e.ColumnIndex == dataGridView_invoice.Columns["detail"]!.Index)
                    {
                        trx_no_status = dataGridView_invoice.Rows[e.RowIndex].Cells["status"].Value!.ToString()!;

                        trx_no_detail = dataGridView_invoice.Rows[e.RowIndex].Cells["trx_no"].Value!.ToString()!;

                        id_member_void = dataGridView_invoice.Rows[e.RowIndex].Cells["id_member"].Value!.ToString()!;

                        point_use = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["discount_point"].Value!.ToString()!);
                        point_inc = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["point_increase"].Value!.ToString()!);

                        open_detail();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_invoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    trx_no_status = dataGridView_invoice.Rows[e.RowIndex].Cells["status"].Value!.ToString()!;

                    trx_no_detail = dataGridView_invoice.Rows[e.RowIndex].Cells["trx_no"].Value!.ToString()!;

                    id_member_void = dataGridView_invoice.Rows[e.RowIndex].Cells["id_member"].Value!.ToString()!;

                    point_use = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["discount_point"].Value!.ToString()!);
                    point_inc = (int)double.Parse(dataGridView_invoice.Rows[e.RowIndex].Cells["point_increase"].Value!.ToString()!);

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
                Form_Invoice_Detail form_Invoice_Detail = new Form_Invoice_Detail();
                form_Invoice_Detail.Size = new Size(this.Width / 2, this.Height * 9 / 10);
                form_Invoice_Detail.ShowDialog(this);
                if (form_Invoice_Detail.void_bill)
                {
                    dataGridView_invoice.Rows[dataGridView_invoice.CurrentRow!.Index].Cells["status"].Value = "ยกเลิก";
                    dataGridView_invoice.Rows[dataGridView_invoice.CurrentRow!.Index].Cells["void_bill"].Value = new Bitmap(40, 40);
                }
            }
            catch
            {

            }
        }
        private void backgroundWorker_void_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Class_Void.update_void(trx_no_void, id_member_void, point_use, point_inc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_void_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dataGridView_invoice.Rows[dataGridView_invoice.CurrentRow!.Index].Cells["status"].Value = "ยกเลิก";
                dataGridView_invoice.Rows[dataGridView_invoice.CurrentRow!.Index].Cells["void_bill"].Value = new Bitmap(40, 40);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Form_Check_Invoice_Shown(object sender, EventArgs e)
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

                if (textBox_search.Text != string.Empty)
                {
                    tableLayoutPanel_date.Visible = false;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dataGridView_invoice.Rows.Clear();
                   // dataGridView_invoice.ScrollBars = ScrollBars.None;
                    dataGridView_invoice.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_invoice_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    /*  dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(
                          dataGridView_invoice.DefaultCellStyle.Font!.FontFamily,
                          dataGridView_invoice.DefaultCellStyle.Font!.Size,
                          FontStyle.Bold); // สีที่ต้องการตอนชี้*/

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                    if (dataGridView_invoice.Rows[e.RowIndex].Cells["status"].Value!.ToString() == "ขาย")
                    {
                        dataGridView_invoice.Rows[e.RowIndex].Cells["void_bill"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30));
                    }
                    dataGridView_invoice.Rows[e.RowIndex].Cells["detail"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(30, 30));

                    dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch
            {

            }
        }

        private void dataGridView_invoice_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    /* dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(
                         dataGridView_invoice.DefaultCellStyle.Font!.FontFamily,
                         dataGridView_invoice.DefaultCellStyle.Font!.Size,
                         FontStyle.Bold); // สีที่ต้องการตอนชี้*/

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                    if (dataGridView_invoice.Rows[e.RowIndex].Cells["status"].Value!.ToString() == "ขาย")
                    {
                        dataGridView_invoice.Rows[e.RowIndex].Cells["void_bill"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(40, 40));

                    }
                    dataGridView_invoice.Rows[e.RowIndex].Cells["detail"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(40, 40));

                    dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    dataGridView_invoice.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Blue;
                }
            }
            catch
            {

            }
        }

        private void backgroundWorker_search_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // 
                            cmd_sqlite.CommandText = @"SELECT ih.id,ih.created_by,strftime('%d/%m/%Y',ih.created_date) as date,time(ih.created_date) as time, ih.status, ih.trx_no, ih.item_qty, ih.price_sum, ih.id_member, 
                                                   ih.percent_discount_member, ih.point_increase, ih.discount_promotion,
                                                   ih.discount_member, ih.discount_custom, ih.discount_point, ih.discount_round, ih.price_net, ih.pay_cash, ih.pay_transfer, ih.change, 
                                                   ih.price_non_vat, ih.price_vat, ih.vat, ih.void_date, ih.return_date, ih.trx_no_reference,coalesce(m.phone,'') as phone
                                                   FROM Invoice_Head ih
                                                   left join Member m on m.id = ih.id_member 
                                                   where 1=1 ";
                            if (textBox_search.Text.Trim() != string.Empty)
                            {
                                cmd_sqlite.CommandText += "and (ih.trx_no = '" + textBox_search.Text.Trim() + "' or " +
                                                          "m.phone = '" + textBox_search.Text.Trim() + "') ";
                            }
                            else
                            {
                                cmd_sqlite.CommandText += "and date(ih.created_date) = '" + currentDate.ToString("yyyy-MM-dd") + "' ";
                            }
                            cmd_sqlite.CommandText += "order by ih.id desc";
                            SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt.Load(reader);

                            dataGridView_invoice.Columns["seq"]!.HeaderText = "0";
                            if (dt.Rows.Count > 0)
                            {
                                Image void_bill;
                                string status = "";
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["status"].ToString() == "C")
                                    {
                                        void_bill = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30));
                                    }
                                    else
                                    {
                                        void_bill = new Bitmap(40, 40);
                                    }
                                    if (dt.Rows[i]["status"].ToString() == "C")
                                    {
                                        status = "ขาย";
                                    }
                                    else if (dt.Rows[i]["status"].ToString() == "V")
                                    {
                                        status = "ยกเลิก";
                                    }
                                    dataGridView_invoice.Rows.Add("",
                                    (i + 1),
                                    Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(30, 30)),                                  
                                    dt.Rows[i]["id"],
                                    dt.Rows[i]["created_by"],
                                    dt.Rows[i]["date"],
                                    dt.Rows[i]["time"],
                                    status,
                                    dt.Rows[i]["trx_no"],
                                    dt.Rows[i]["id_member"],
                                    dt.Rows[i]["phone"],
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["item_qty"]), 3).ToString("#,##0.000"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["price_sum"]), 2).ToString("#,##0.00"),
                                    dt.Rows[i]["percent_discount_member"],
                                    dt.Rows[i]["point_increase"],
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["discount_promotion"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["discount_member"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["discount_custom"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["discount_point"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["discount_round"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["price_net"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["pay_cash"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["pay_transfer"]), 2).ToString("#,##0.00"),
                                    Math.Round(Convert.ToDouble(dt.Rows[i]["change"]), 2).ToString("#,##0.00"),
                                    dt.Rows[i]["price_non_vat"],
                                    dt.Rows[i]["price_vat"],
                                    dt.Rows[i]["vat"],
                                    dt.Rows[i]["void_date"],
                                    dt.Rows[i]["return_date"],
                                    dt.Rows[i]["trx_no_reference"],
                                    void_bill,
                                    ""
                                    );
                                    dataGridView_invoice.Columns["seq"]!.HeaderText = (i + 1).ToString();
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
            catch
            {

            }
        }

        private void backgroundWorker_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
               // dataGridView_invoice.ScrollBars = ScrollBars.Both;
                dataGridView_invoice.Enabled = true;
                tableLayoutPanel_date.Enabled = true;
                Class_Parameter.runbackground = false;
                if(textBox_search.Text == string.Empty)
                {
                    tableLayoutPanel_date.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_next_date_Click(object sender, EventArgs e)
        {
            try
            {
                currentDate = currentDate.AddDays(1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (textBox_search.Text == string.Empty)
                {
                    tableLayoutPanel_date.Enabled = false;
                    dataGridView_invoice.Rows.Clear();
                   // dataGridView_invoice.ScrollBars = ScrollBars.None;
                    dataGridView_invoice.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_back_date_Click(object sender, EventArgs e)
        {
            try
            {
                currentDate = currentDate.AddDays(-1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (textBox_search.Text == string.Empty)
                {
                    tableLayoutPanel_date.Enabled = false;
                    dataGridView_invoice.Rows.Clear();
                   // dataGridView_invoice.ScrollBars = ScrollBars.None;
                    dataGridView_invoice.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_date_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                currentDate = DateTime.Now; // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (textBox_search.Text == string.Empty)
                {
                    tableLayoutPanel_date.Enabled = false;
                    dataGridView_invoice.Rows.Clear();
                   // dataGridView_invoice.ScrollBars = ScrollBars.None;
                    dataGridView_invoice.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_date_Click(object sender, EventArgs e)
        {
            try
            {

            
                    Class_Parameter.calendar_title = "วันที่ขาย";

                    Class_Parameter.calendar_day = label_date.Text.Split("/")[0];
                    Class_Parameter.calendar_month = label_date.Text.Split("/")[1];
                    Class_Parameter.calendar_year = label_date.Text.Split("/")[2];
               

                Form_Calendar form_Calendar = new Form_Calendar();
                form_Calendar.ShowDialog(this);

                if (!form_Calendar.cancel)
                {
                    DateTime date;
                    label_date.Text = form_Calendar.label_set_days.Text.Replace("-", "/");
                    bool isValid = DateTime.TryParseExact(label_date.Text,
                                          "dd/MM/yyyy",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          out date);
                    if(isValid)
                    {
                        currentDate = date;
                    }
                   
                    tableLayoutPanel_date.Enabled = false;
                    dataGridView_invoice.Rows.Clear();
                   // dataGridView_invoice.ScrollBars = ScrollBars.None;
                    dataGridView_invoice.Enabled = false;
                    Class_Parameter.runbackground = true;
                    backgroundWorker_search.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
