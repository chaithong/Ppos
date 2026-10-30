using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Invoice_Detail : Form
    {
        public bool void_bill = false;
        public Form_Invoice_Detail()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;



                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);
                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dataGridView_item.EnableHeadersVisualStyles = false;
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);

                this.Text = "บิล" + Form_Check_Invoice.trx_no_status + " " + Form_Check_Invoice.trx_no_detail;

                if (Form_Check_Invoice.trx_no_status == "ขาย")
                {
                    button_void.Visible = true;
                    button_void.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new System.Drawing.Size(40, 40));
                }


            }
            catch
            {
                this.Close();
            }
        }
        private void dataGridView_item_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item.RowCount)
            {
                newIndex = dataGridView_item.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Style.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Style.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // 

                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Invoice_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ดึงข้อมูลมาใส่ตาราง
                        cmd_sqlite.CommandText = @"SELECT id,void,return,small_barcode,item_barcode,
                                                          item_code,item_name,item_qty,item_unit,item_price,
                                                          item_price_sum,small_qty,qty_small,
                                                          pro_id,pro_type,pro_desc,
                                                          criterion_type,criterion_value,
                                                          offer_type,offer_value,
                                                          discount_type,repeat,
                                                          discount_promotion,
                                                          id_member,
                                                          percent_discount_member,
                                                          discount_member,
                                                          discount_custom,
                                                          discount_point,
                                                          discount_round,
                                                          price_net,
                                                          price_non_vat,
                                                          price_vat,
                                                          vat,
                                                          sale_vat,
                                                          premium,
                                                          effective_member
                                                          FROM Invoice_Body where void = false 
                                                          and trx_no = '" + Form_Check_Invoice.trx_no_detail + "'";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            Image pro;
                            double sum_qty = 0, sum_price = 0, dis_pro = 0, dis_member = 0, dis_point = 0,dis_custom = 0, dis_round = 0, price_net = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                pro = new Bitmap(30, 30);

                                if (dt.Rows[i]["pro_type"].ToString() != string.Empty)
                                {
                                    pro = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(30, 30));

                                }
                                dataGridView_item.Rows.Add(
                              (i + 1),
                              dt.Rows[i]["id"].ToString()!,
                              dt.Rows[i]["item_code"].ToString()!,
                              dt.Rows[i]["small_barcode"].ToString()!,
                              dt.Rows[i]["item_barcode"].ToString()!,
                              dt.Rows[i]["item_name"].ToString()!,
                              Convert.ToDouble(dt.Rows[i]["item_qty"]).ToString("#,##0.000"),
                              dt.Rows[i]["item_unit"].ToString()!,
                              Convert.ToDouble(dt.Rows[i]["item_price"]).ToString("#,##0.00"),
                              (Convert.ToDouble(dt.Rows[i]["item_qty"]) * Convert.ToDouble(dt.Rows[i]["item_price"])).ToString("#,##0.00"),
                              pro,
                              dt.Rows[i]["pro_id"].ToString()!,
                              dt.Rows[i]["pro_type"].ToString()!,
                              dt.Rows[i]["pro_desc"].ToString()!,
                              dt.Rows[i]["criterion_type"].ToString()!,
                              dt.Rows[i]["criterion_value"].ToString()!,
                              dt.Rows[i]["offer_type"].ToString()!,
                              dt.Rows[i]["offer_value"].ToString()!,
                              dt.Rows[i]["discount_type"].ToString()!,
                              dt.Rows[i]["repeat"].ToString()!,
                              dt.Rows[i]["premium"].ToString()!,
                              dt.Rows[i]["effective_member"].ToString()!, // effective_member
                              dt.Rows[i]["sale_vat"].ToString()!
                              );

                                dataGridView_item.ClearSelection();

                                dataGridView_item.Columns["seq"]!.HeaderText = (i + 1).ToString();

                                sum_qty += Convert.ToDouble(dt.Rows[i]["item_qty"]);
                                label_sum_qty.Text = sum_qty.ToString("#,##0.000");

                                sum_price += Convert.ToDouble(dt.Rows[i]["item_qty"]) * Convert.ToDouble(dt.Rows[i]["item_price"]);
                                label_sum_price.Text = sum_price.ToString("#,##0.00");

                                dis_pro += Convert.ToDouble(dt.Rows[i]["discount_promotion"]);
                                label_dis_pro.Text = dis_pro.ToString("#,##0.00");

                                dis_member += Convert.ToDouble(dt.Rows[i]["discount_member"]);
                                label_dis_member.Text = dis_member.ToString("#,##0.00");

                                dis_point += Convert.ToDouble(dt.Rows[i]["discount_point"]);
                                label_dis_point.Text = dis_point.ToString("#,##0.00");

                                dis_custom += Convert.ToDouble(dt.Rows[i]["discount_custom"]);
                                label_dis_custom.Text = dis_custom.ToString("#,##0.00");

                                dis_round += Convert.ToDouble(dt.Rows[i]["discount_round"]);
                                label_dis_round.Text = dis_round.ToString("#,##0.00");

                                price_net += Convert.ToDouble(dt.Rows[i]["price_net"]);
                                label_price_net.Text = price_net.ToString("#,##0.00");


                            }
                            // ดึงชื่อสมาชิก
                            if (Form_Check_Invoice.id_member_void != string.Empty)
                            {
                                cmd_sqlite.CommandText = @"SELECT id,phone,sex,nick_name,first_name,last_name,
                                                               address,sub_district,district,province,postal_code,
                                                               discount_percent,sale_total,sale_ineffective_member,
                                                               sale_effective_member,sale_per_point,
                                                               point_increase,point_decrease,point_balance
                                                               FROM Member WHERE id = " + Form_Check_Invoice.id_member_void;
                                reader = cmd_sqlite.ExecuteReader();
                                dt = new System.Data.DataTable();
                                dt.Load(reader);
                                if (dt.Rows.Count > 0)
                                {
                                    string nick_name = "";
                                    if (dt.Rows[0]["nick_name"].ToString() != String.Empty)
                                    {
                                        nick_name = " (" + dt.Rows[0]["nick_name"].ToString() + ")";
                                    }

                                    label_member.Text = dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString() + nick_name;

                                }
                                else
                                {
                                    label_member_title.Visible = false;
                                }
                            }
                            else
                            {
                                label_member_title.Visible = false;
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

        private void button_void_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("ต้องการยกเลิกบิล " + Form_Check_Invoice.trx_no_detail + " ใช่หรือไม่ ?", "ยกเลิกบิล", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    backgroundWorker_void.RunWorkerAsync();
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
                Class_Void.update_void(Form_Check_Invoice.trx_no_detail, Form_Check_Invoice.id_member_void, Form_Check_Invoice.point_use, Form_Check_Invoice.point_inc);

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
                void_bill = true;
                this.Close();
            }
            catch
            {

            }
        }

        private void button_void_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_void.Font = new Font(button_void.Font.FontFamily, button_void.Font.Size + 2, button_void.Font.Style);
            }
            catch
            {

            }
        }

        private void button_void_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_void.Font = new Font(button_void.Font.FontFamily, button_void.Font.Size - 2, button_void.Font.Style);
            }
            catch
            {

            }
        }
    }
}
