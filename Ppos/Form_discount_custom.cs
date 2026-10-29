using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ppos
{
    public partial class Form_discount_custom : Form
    {
        public bool exit = true;
        public string price_discount;
        public Form_discount_custom()
        {
            InitializeComponent();
            try
            {
                button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new System.Drawing.Size(60, 60));

                this.Text = "ลดได้ไม่เกิน " + Convert.ToDouble(Form_Pay.discount_price.Replace(",", "")).ToString("#,##0.##") + " บาท";

                label_title.Text = this.Text;

                label_price_net.Text = Form_Sale.price_net;
            }
            catch
            {
                this.Close();
            }
          

        }

        private void Form_discount_custom_Load(object sender, EventArgs e)
        {
            try
            {
                textBox_discount_price.Focus();
            }
            catch
            {

            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_discount_price.Text != string.Empty)
                {
                    if (double.TryParse(textBox_discount_price.Text, out _))
                    {
                        price_discount = textBox_discount_price.Text;
                        exit = false;
                        this.Close();
                    }
                }


            }
            catch
            {

            }
        }

        private void textBox_discount_price_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_discount_price.Focus();
            }
            catch
            {

            }
        }

        private void textBox_discount_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // อนุญาตให้พิมพ์เฉพาะ ตัวเลข (0-9) และปุ่ม Backspace (\b)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // บล็อกไม่ให้พิมพ์อักขระนั้นลงใน TextBox
                }
            }
            catch
            {

            }

        }

        private void textBox_discount_price_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button_confirm_Click(sender, e);
                }
            }
            catch
            {

            }
        }

        private void textBox_discount_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox_discount_price.Text.Replace(",", "")) > Convert.ToDouble(Form_Pay.discount_price.Replace(",", "")))
                {
                    textBox_discount_price.Text = Form_Pay.discount_price;
                    textBox_discount_price.SelectionStart = textBox_discount_price.TextLength;
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
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
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
        private void button_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
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
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                //  button.ForeColor = Color.Gray;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size - 3, button.Font.Style);
            }
            catch
            {

            }
        }
        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                // button.ForeColor = Color.Black;
                label.Font = new Font(label.Font.FontFamily, label.Font.Size + 3, label.Font.Style);
            }
            catch
            {

            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                // button.ForeColor = Color.Black;
                label.Font = new Font(label.Font.FontFamily, label.Font.Size - 3, label.Font.Style);
            }
            catch
            {

            }
        }
    }
}
