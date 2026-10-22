using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_PromptPay : Form
    {
        public string amount;
        public bool exit = true;
        public Form_PromptPay()
        {
            InitializeComponent();
            button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(70, 70));
            button_ok.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(60, 60));
            //  button_exit.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

           // 
        }



        private void Form_PromptPay_Load(object sender, EventArgs e)
        {
            try
            {
                if (Form_Pay.amount_promptpay != "")
                {
                    textBox_amount.Text = Form_Pay.amount_promptpay;
                    //  button_ok_Click(sender, e);

                    this.Text += " โอนได้ไม่เกิน " + Convert.ToDouble(Form_Pay.amount_promptpay).ToString("#,##0.##") + " บาท";
                }
                textBox_amount.Focus();
            }
            catch
            {

            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_amount.Text != string.Empty)
                {
                    if (double.TryParse(textBox_amount.Text, out double am))
                    {
                        if (am > 0)
                        {                        
                            Image qr = Class_PromptPay.Generate(Convert.ToDouble(textBox_amount.Text).ToString());
                            if (qr is not null)
                            {
                                label_amount.Text = Convert.ToDouble(textBox_amount.Text).ToString("#,##0.##");
                                pictureBox_QRCode.Image = qr;
                                textBox_amount.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถสร้าง QR Code ได้ !!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                           
                        }

                    }

                }
            }
            catch
            {

            }
        }

        private void textBox_amount_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_amount.Focus();

            }
            catch
            {

            }
        }
        private void textBox_amount_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (txt.TextLength >= 5) // ไม่เกิน 5 หลัก
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void keypad_click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (button.Name == "button_delete")
                {
                    SendKeys.Send("{BACKSPACE}");
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

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_amount.Text != string.Empty)
                {
                    amount = label_amount.Text;
                    exit = false;
                    this.Close();
                }

            }
            catch
            {

            }
        }

        private void textBox_amount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_amount.Text != string.Empty)
                    {
                        button_ok_Click(sender, e);
                    }
                    else
                    {
                        button_confirm_Click(sender, e);
                    }

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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
                Button button = (Button)sender;
                // button.ForeColor = Color.Black;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size + 3, button.Font.Style);
            }
            catch
            {

            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                //  button.ForeColor = Color.Gray;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size - 3, button.Font.Style);
            }
            catch
            {

            }
        }

        private void Form_PromptPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {

                }
            }
            catch
            {

            }
        }

        private void textBox_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDouble(textBox_amount.Text) > Convert.ToDouble(Form_Pay.amount_promptpay))
                {
                    textBox_amount.Text = Form_Pay.amount_promptpay;
                    textBox_amount.SelectionStart = textBox_amount.TextLength;
                }
            }
            catch
            {

            }
        }
    }
}
