using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Dashboard : Form
    {
        BackgroundWorker worker;
        DateTime currentDate = DateTime.Now;
        public Form_Dashboard()
        {
            InitializeComponent();
            try
            {

                label_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

                button_next_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(70, 70));

                button_back_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(70, 70));
            }
            catch
            {
                this.Close();
            }
        }
        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker_load.RunWorkerAsync();
            }
            catch
            {

            }
        }
        private void backgroundWorker_load_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                worker = (BackgroundWorker)sender;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = @"SELECT 
                                                   coalesce(count(distinct ih.trx_no),0) as bill,
                                                   coalesce(count(distinct ib.item_code),0) as item,
                                                   coalesce(sum(ib.item_qty),0) as qty,
                                                   coalesce(sum(ib.item_price_sum),0) as price_sum,
                                                   coalesce(sum(ib.discount_promotion),0) as dis_pro,
                                                   coalesce(sum(ib.discount_member),0) as dis_member,
                                                   coalesce(sum(ib.discount_point),0) as dis_point,
                                                   coalesce(sum(ib.discount_custom),0) as dis_custom,
                                                   coalesce(sum(ib.discount_round),0) as dis_round,
                                                   coalesce(sum(ib.price_net),0) as price_net
                                                   from Invoice_Head ih 
                                                   join Invoice_Body ib on ib.trx_no = ih.trx_no and ib.void = false
                                                   where ih.status = 'C'
                                                   and date(ih.created_date) = '" + currentDate.ToString("yyyy-MM-dd") + "'";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);

                        if (dt.Rows.Count > 0)
                        {
                            label_sum_bill.Text = Convert.ToDouble(dt.Rows[0]["bill"]).ToString("#,##0");
                           

                           
                            label_sum_price.Text = Convert.ToDouble(dt.Rows[0]["price_sum"]).ToString("#,##0.##");
                            label_sum_dis_pro.Text = Convert.ToDouble(dt.Rows[0]["dis_pro"]).ToString("#,##0.##");
                            label_sum_dis_member.Text = Convert.ToDouble(dt.Rows[0]["dis_member"]).ToString("#,##0.##");
                            label_dis_point.Text = Convert.ToDouble(dt.Rows[0]["dis_point"]).ToString("#,##0.##");
                            label_dis_custom.Text = Convert.ToDouble(dt.Rows[0]["dis_custom"]).ToString("#,##0.##");

                            label_sum_price_net.Text = Convert.ToDouble(dt.Rows[0]["price_net"]).ToString("#,##0.##");

                            label_sum_round.Text = (Convert.ToDouble(label_sum_price.Text) -
                                                   Convert.ToDouble(label_sum_dis_pro.Text) -
                                                   Convert.ToDouble(label_sum_dis_member.Text) -
                                                   Convert.ToDouble(label_dis_point.Text) -
                                                   Convert.ToDouble(label_dis_custom.Text) -
                                                   Convert.ToDouble(label_sum_price_net.Text)
                                                  ).ToString("#,##0.##");
                        }
                        else
                        {
                            label_sum_bill.Text = "0";
                           
                            label_sum_price.Text = "0";
                            label_sum_dis_pro.Text = "0";
                            label_sum_dis_member.Text = "0";
                            label_dis_point.Text = "0";
                            label_dis_custom.Text = "";
                            label_sum_round.Text = "0";
                            label_sum_price_net.Text = "0";
                        }
                    }
                }

            }
            catch
            {

            }
        }

        private void Form_Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 1. ตรวจสอบว่า BackgroundWorker กำลังทำงานอยู่หรือไม่
                if (backgroundWorker_load.IsBusy)
                {
                    // 2. ส่งสัญญาณสั่งยกเลิกลูป (ทำงานร่วมกับ CancellationPending ใน DoWork)
                    backgroundWorker_load.CancelAsync();

                    // 3. เพื่อความปลอดภัยสูงสุด: วนลูปสั้นๆ รอให้ Thread ปิดตัวเองลงจริงๆ
                    // (ป้องกันไม่ให้ฟอร์มปิดตัวไปก่อนที่ Thread จะจัดการล้างข้อมูลเสร็จ)
                    while (backgroundWorker_load.IsBusy)
                    {
                        // ป้องกัน UI ค้างระหว่างรอ Thread ปิดตัว
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_back_date_Click(object sender, EventArgs e)
        {
            try
            {
                label_date.Focus();
                tableLayoutPanel_date.Enabled = false;
                currentDate = currentDate.AddDays(-1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                backgroundWorker_load.RunWorkerAsync();
            }
            catch
            {

            }
        }

        private void button_next_date_Click(object sender, EventArgs e)
        {
            try
            {
                label_date.Focus();
                tableLayoutPanel_date.Enabled = false;
                currentDate = currentDate.AddDays(1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                backgroundWorker_load.RunWorkerAsync();
            }
            catch
            {

            }
        }

        private void backgroundWorker_load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                tableLayoutPanel_date.Enabled = true;
            }
            catch
            {

            }
        }

        private void label_mouse_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;

                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size + 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void label_mouse_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;

                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                if (button.Name == "button_next_date")
                {
                    button_next_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(80, 80));
                }
                else
                {
                    button_back_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(80, 80));
                }

            }
            catch
            {

            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                if (button.Name == "button_next_date")
                {
                    button_next_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(70, 70));
                }
                else
                {
                    button_back_date.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(70, 70));
                }
            }
            catch
            {

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
                    if (isValid)
                    {
                        currentDate = date;
                    }
                    tableLayoutPanel_date.Enabled = false;
                    backgroundWorker_load.RunWorkerAsync() ;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
