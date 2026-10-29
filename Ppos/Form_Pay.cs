using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using QRCoder;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Pay : Form
    {

        public static string amount_promptpay = "", point_max = "",discount_price = "";
        public bool exit = true;

        bool complete = false;
        public Form_Pay()
        {

            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                button_discount.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new System.Drawing.Size(35, 35));
                button_cash.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new System.Drawing.Size(40, 40));
                button_transfer.Image = Class_Image.resizeImage(Ppos.Properties.Resources.QR_Code, new System.Drawing.Size(40, 40));
                button_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.editMember, new System.Drawing.Size(40, 40));


                button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new System.Drawing.Size(70, 70));
                button_exit.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new System.Drawing.Size(70, 70));

                button_1.Image = Class_Image.resizeImage(Ppos.Properties.Resources.coin_1, new System.Drawing.Size(100, 100));
                button_5.Image = Class_Image.resizeImage(Ppos.Properties.Resources.coin_5, new System.Drawing.Size(100, 100));
                button_10.Image = Class_Image.resizeImage(Ppos.Properties.Resources.coin_10, new System.Drawing.Size(100, 100));
                button_20.Image = Class_Image.resizeImage(Ppos.Properties.Resources._17th_20, new System.Drawing.Size(200, 100));
                button_50.Image = Class_Image.resizeImage(Ppos.Properties.Resources._17th_50, new System.Drawing.Size(210, 100));
                button_100.Image = Class_Image.resizeImage(Ppos.Properties.Resources._17th_100, new System.Drawing.Size(220, 100));
                button_500.Image = Class_Image.resizeImage(Ppos.Properties.Resources._17th_500, new System.Drawing.Size(225, 100));
                button_1000.Image = Class_Image.resizeImage(Ppos.Properties.Resources._17th_1000, new System.Drawing.Size(235, 100));

                button_numeric.Image = Class_Image.resizeImage(Ppos.Properties.Resources.key_number, new System.Drawing.Size(50, 50));

                button_coin.Image = Class_Image.resizeImage(Ppos.Properties.Resources.coin, new System.Drawing.Size(50, 40));

                // ถ้ามีสมาชิก
                if (Form_Sale.id_member != "")
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT 1 from Invoice_Body_Temp where effective_member = true and void = false and hole = false";

                            SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt.Load(reader);

                            // ถ้าไม่มีสินค้าที่มีผลกับสมาชิก จะไม่แสดง point
                            if (dt.Rows.Count == 0)
                            {
                                customGroupBox_point_back.Visible = false;
                            }
                        }
                    }

                }
                else
                {
                    // ไม่มีสมาชิกแล้วจะไม่แสดง point
                    customGroupBox_point_back.Visible = false;
                }
                tableLayoutPanel_back_pay.Controls.Clear();
                // แสดง keypad
                if (Class_Parameter.pay_show_keypad)
                {
                    // ปรับขนาดหน้าจอ
                    tableLayoutPanel_back_pay.ColumnStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel_back_pay.ColumnStyles[0].Width = Class_Parameter.pay_left_width;
                    tableLayoutPanel_back_pay.ColumnStyles[1].SizeType = SizeType.Percent;
                    tableLayoutPanel_back_pay.ColumnStyles[1].Width = 100 - Class_Parameter.pay_left_width;

                    if (Class_Parameter.sale_hotkey_left)
                    {
                        // hotkey อยู่ทางซ้าย

                        tableLayoutPanel_back_pay.Controls.Add(customGroupBox_left, 0, 0);
                        tableLayoutPanel_back_pay.Controls.Add(customGroupBox_right, 1, 0);

                    }
                    else
                    {
                        // hotkey อยู่ทางขวา                      

                        tableLayoutPanel_back_pay.Controls.Add(customGroupBox_right, 0, 0);
                        tableLayoutPanel_back_pay.Controls.Add(customGroupBox_left, 1, 0);
                    }

                    // ตัวเลข
                    if (Class_Parameter.keypad_numeric)
                    {
                        tableLayoutPanel_select_keypad.ColumnStyles[0].Width = 100;
                        tableLayoutPanel_select_keypad.ColumnStyles[1].Width = 0;
                    }
                    else
                    {
                        tableLayoutPanel_select_keypad.ColumnStyles[0].Width = 0;
                        tableLayoutPanel_select_keypad.ColumnStyles[1].Width = 100;
                    }
                }
                else // ไม่แสดง keypad
                {
                    // ปรับขนาดหน้าจอ
                    tableLayoutPanel_back_pay.ColumnStyles[0].SizeType = SizeType.Percent;
                    tableLayoutPanel_back_pay.ColumnStyles[0].Width = 50;
                    tableLayoutPanel_back_pay.ColumnStyles[1].SizeType = SizeType.Absolute;
                    tableLayoutPanel_back_pay.ColumnStyles[1].Width = 900;
                    tableLayoutPanel_back_pay.ColumnCount += 1;
                    tableLayoutPanel_back_pay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    // tableLayoutPanel_back_pay.Dispose();
                    // this.Controls.Add(customGroupBox_right);
                    tableLayoutPanel_back_pay.Controls.Add(customGroupBox_right, 1, 0);
                    // tableLayoutPanel_back_pay.Controls.Add(customGroupBox_left, 1, 0);

                }
                new TableLayoutResizer(tableLayoutPanel_back_pay);
                textBox_cash.LostFocus += TextBox_cash_LostFocus;
            }
            catch
            {
                this.Close();
            }

        }
        bool focus = true;
        private void TextBox_cash_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                if (focus)
                {
                    textBox_cash.Focus();
                }
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
                // button.ForeColor = Color.Black;
                button.Font = new System.Drawing.Font(button.Font.FontFamily, button.Font.Size + 5, button.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                //  button.ForeColor = Color.Gray;
                button.Font = new System.Drawing.Font(button.Font.FontFamily, button.Font.Size - 5, button.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            try
            {
                focus = false;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Pay_Shown(object sender, EventArgs e)
        {
            try
            {
                label_price_net.Text = Form_Sale.price_net;
                textBox_cash.Focus();

                button_cash_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void keypad_click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                if (button.Name == "button_delete")
                {
                    SendKeys.Send("{BACKSPACE}");
                }
                else if (button.Name == "button00")
                {
                    SendKeys.Send("00");
                }
                else
                {
                    SendKeys.Send(button.Text);
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
                // label.ForeColor = Color.Black;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size + 5, label.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                //  label.ForeColor = Color.DimGray;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size - 5, label.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox_cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0)
                    {
                        e.Handled = true;
                    }

                }

                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 2 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (dotIndex == -1)
                    {
                        if (txt.TextLength >= 6) // ไม่เกิน 6 หลัก
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_transfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_transfer.Text == "0")
                {
                    double cash = 0;
                    if (textBox_cash.Text != string.Empty)
                    {
                        cash = Convert.ToDouble(textBox_cash.Text.Replace(",", ""));
                    }


                    // ถ้ายังจ่ายเงินสดกับแต้มไม่ครบ
                    if (cash + Convert.ToDouble(label_point.Text.Replace(",", "")) < Convert.ToDouble(label_price_net.Text.Replace(",", "")))
                    {
                        amount_promptpay = (Convert.ToDouble(label_price_net.Text.Replace(",", "")) - cash - Convert.ToDouble(label_point.Text.Replace(",", ""))).ToString();
                        Form_PromptPay form_PromptPay = new Form_PromptPay();

                        form_PromptPay.ShowDialog(this);
                        if (!form_PromptPay.exit)
                        {
                            label_transfer.Text = form_PromptPay.amount.ToString();

                            button_transfer.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new System.Drawing.Size(35, 35));
                            cal_change();
                        }
                    }
                    amount_promptpay = "";
                }
                else
                {
                    label_transfer.Text = "0";

                    button_transfer.Image = Class_Image.resizeImage(Ppos.Properties.Resources.QR_Code, new System.Drawing.Size(40, 40));
                    cal_change();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_cash_Click(object sender, EventArgs e)
        {
            try
            {

                textBox_cash.Text = (Convert.ToDouble(label_price_net.Text.Replace(",", "")) -
                    Convert.ToDouble(label_transfer.Text.Replace(",", "")) -
                    Convert.ToDouble(label_point.Text.Replace(",", ""))).ToString("0.##");
                textBox_cash.SelectionStart = textBox_cash.Text.Length;
                cal_change();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cal_change()
        {
            try
            {
                double cash = 0;
                if (textBox_cash.Text != string.Empty)
                {
                    cash = Convert.ToDouble(textBox_cash.Text.Replace(",", ""));
                }
                double change =
                cash +
                Convert.ToDouble(label_transfer.Text.Replace(",", "")) +
                Convert.ToDouble(label_point.Text.Replace(",", "")) -
                Convert.ToDouble(label_price_net.Text.Replace(",", "")
                );
                if (change < 0)
                {
                    button_discount.Visible = true;
                    customGroupBox_price_net_back.BorderColor = Color.Red;
                    tableLayoutPanel_price_net.BackColor = Color.Red;
                    customGroupBox_right.BorderColor = Color.Red;
                    label_change.Text = "0";
                    complete = false;
                }
                else
                {
                    button_discount.Visible = false;
                    customGroupBox_price_net_back.BorderColor = Color.Lime;
                    tableLayoutPanel_price_net.BackColor = Color.Lime;
                    customGroupBox_right.BorderColor = Color.Lime;
                    label_change.Text = change.ToString("#,##0.##");
                    complete = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_cash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Escape)
                {
                    e.SuppressKeyPress = true;
                    button_exit_Click(sender, e);

                }
                else if (e.KeyCode == Keys.Enter && complete)// ถ้ากด enter และมูลค่าพร้อมจ่าย
                {
                    e.SuppressKeyPress = true;
                    button_confirm_Click(sender, e);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cal_change();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_cash_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                textBox_cash.Font = new System.Drawing.Font(textBox_cash.Font.FontFamily, textBox_cash.Font.Size + 5, textBox_cash.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_cash_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                textBox_cash.Font = new System.Drawing.Font(textBox_cash.Font.FontFamily, textBox_cash.Font.Size - 5, textBox_cash.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_member_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_point.Text == "0")
                {
                    double cash = 0;
                    if (textBox_cash.Text != string.Empty)
                    {
                        cash = Convert.ToDouble(textBox_cash.Text.Replace(",", ""));
                    }
                    // หาค่าแต้มสูงสุดที่ใช้ได้ โดยไม่คิด สินค้าที่ ปิดใช้กับสมาชิก
                    // ราคาคงเหลือที่ต้องจ่าย

                    point_max = Math.Floor(Math.Round(Convert.ToDouble(label_price_net.Text.Replace(",", "")) - cash - Convert.ToDouble(label_transfer.Text.Replace(",", "")), 2)).ToString();

                    // ถ้าคงเหลือมากกว่า ราคาที่มีผลสมาชิก
                    if (Convert.ToDouble(point_max.Replace(",", "")) > Class_Pay.price_net_effective_member())
                    {
                        // ค่าแต้มสูงสุดจะเท่ากับราคาที่มีผลสมาชิก
                        point_max = Math.Floor(Math.Round(Class_Pay.price_net_effective_member(), 2)).ToString();

                    }
                    // ถ้าเหลือมูลค่าที่ต้องจ่าย
                    if (Convert.ToDouble(point_max.Replace(",", "")) > 0)
                    {


                        Form_Redeem_Point form_Redeem_Point = new Form_Redeem_Point();
                        form_Redeem_Point.ShowDialog(this);
                        if (!form_Redeem_Point.exit)
                        {
                            label_point.Text = Convert.ToDouble(form_Redeem_Point.point.Replace(",", "")).ToString("#,##0");
                            button_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new System.Drawing.Size(35, 35));
                            cal_change();
                        }
                    }


                }
                else
                {
                    label_point.Text = "0";

                    button_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new System.Drawing.Size(40, 40));
                    cal_change();
                }

            }
            catch
            {

            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (complete)
                {
                    this.Enabled = false;
                    // ส่งค่า discount_price
                    if (Convert.ToDouble(Form_Sale.price_net.Replace(",", "")) > Convert.ToDouble(label_price_net.Text.Replace(",","")))
                    {
                        discount_price = (Convert.ToDouble(Form_Sale.price_net.Replace(",", "")) - Convert.ToDouble(label_price_net.Text.Replace(",", ""))).ToString();
                    }
                    backgroundWorker_confirm.RunWorkerAsync();

                }


            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_confirm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                double cash = 0;
                if (textBox_cash.Text != string.Empty)
                {
                    cash = Convert.ToDouble(textBox_cash.Text.Replace(",", ""));
                }
              
                Class_Pay.update_pay(cash,
                                     Convert.ToDouble(label_transfer.Text.Replace(",", "")),
                                     Convert.ToInt32(label_point.Text.Replace(",", "")),
                                     Convert.ToDouble(label_change.Text.Replace(",", ""))
                                     );
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_confirm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                exit = false;
                button_exit_Click(sender, e);
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_numeric_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Class_Parameter.keypad_numeric)
                {
                    Class_Parameter.keypad_numeric = true;
                    tableLayoutPanel_select_keypad.ColumnStyles[0].Width = 100;
                    tableLayoutPanel_select_keypad.ColumnStyles[1].Width = 0;
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'True' " +
                                                     "where title = 'keypad_numeric'";

                            cmd_sqlite.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_coin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class_Parameter.keypad_numeric)
                {
                    Class_Parameter.keypad_numeric = false;
                    tableLayoutPanel_select_keypad.ColumnStyles[0].Width = 0;
                    tableLayoutPanel_select_keypad.ColumnStyles[1].Width = 100;

                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'keypad_numeric'";

                            cmd_sqlite.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void coin_click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

                if (button.Text != "ลบ")
                {
                    double cash = 0;
                    if (textBox_cash.Text == string.Empty)
                    {
                        cash = 0;
                    }
                    else
                    {
                        cash = Convert.ToDouble(textBox_cash.Text);
                        textBox_cash.Text = "";
                    }

                    SendKeys.Send((Convert.ToDouble(cash) + Convert.ToDouble(button.Text)).ToString());
                }
                else
                {
                    textBox_cash.Text = "";
                }

            }
            catch
            {

            }
        }

        private void button_discount_Click(object sender, EventArgs e)
        {
            try
            {
                double cash = 0 , rate = 1;
                if (textBox_cash.Text != string.Empty)
                {
                    cash = Convert.ToDouble(textBox_cash.Text.Replace(",", ""));
                }
               
                // ถ้ายังจ่ายไม่ครบ
                if (cash + Convert.ToDouble(label_transfer.Text.Replace(",", "")) + Convert.ToDouble(label_point.Text.Replace(",", "")) < 
                    Convert.ToDouble(label_price_net.Text.Replace(",", "")))
                {
                    // ถ้ามีจ่ายบ้างแล้ว จะลดได้เต็มจำนวน
                    if (cash + Convert.ToDouble(label_transfer.Text.Replace(",", "")) + Convert.ToDouble(label_point.Text.Replace(",", "")) > 0)
                    {
                        rate = 0;
                    }
                    discount_price = (Convert.ToDouble(label_price_net.Text.Replace(",", "")) - 
                        cash - 
                        Convert.ToDouble(label_transfer.Text.Replace(",", "")) - 
                        Convert.ToDouble(label_point.Text.Replace(",", "")) -
                        rate
                        ).ToString();
             
                    Form_discount_custom form_Discount_Custom = new Form_discount_custom();
                    form_Discount_Custom.ShowDialog(this);
                    if (!form_Discount_Custom.exit)
                    {
                        label_price_net.Text = (Convert.ToDouble(Form_Sale.price_net.Replace(",","")) -
                                               Convert.ToDouble(form_Discount_Custom.price_discount.Replace(",", ""))).ToString("#,##0");
                        cal_change();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
