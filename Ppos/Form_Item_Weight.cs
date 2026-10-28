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
    public partial class Form_Item_Weight : Form
    {
        public string weight;
        public bool exit = true;
        Image set_image = null;
        int c = 0;
        bool keypad = false;
        public Form_Item_Weight()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            try
            {
                if (System.IO.File.Exists(Form_Login.item_path + @"\" + Form_Sale.W_image_bar + ".Png"))
                {
                    using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + Form_Sale.W_image_bar + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (Bitmap bitmap = new Bitmap(bitmapFile))
                        {
                            pictureBox_item.Image = Class_Image.resizeImage(bitmap, new Size((pictureBox_item.Height - 10) * bitmap.Width / bitmap.Height, pictureBox_item.Height - 10));
                            if (pictureBox_item.Image.Width > pictureBox_item.Width)
                            {
                                pictureBox_item.Image = Class_Image.resizeImage(pictureBox_item.Image, new Size(pictureBox_item.Width - 10, (pictureBox_item.Width - 10) * pictureBox_item.Image.Height / pictureBox_item.Image.Width));
                            }
                        }
                    }
                }
                else
                {
                    pictureBox_item.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size((pictureBox_item.Height - 10) * Properties.Resources.picture_dark.Width / Properties.Resources.picture_dark.Height, pictureBox_item.Height - 10));
                    if (pictureBox_item.Image.Width > pictureBox_item.Width)
                    {
                        pictureBox_item.Image = Class_Image.resizeImage(pictureBox_item.Image, new Size(pictureBox_item.Width - 10, (pictureBox_item.Width - 10) * pictureBox_item.Image.Height / pictureBox_item.Image.Width));
                    }
                }
                set_image = pictureBox_item.Image;

                label_barcode.Text = Form_Sale.W_item_bar;
                label_item_name.Text = Form_Sale.W_item_name;
                label_item_unit.Text = Form_Sale.W_item_unit;
                label_item_price.Text = Form_Sale.W_item_price;

                button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(50, 50));
             

            }
            catch
            {
                this.Close();
            }


        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            try
            {

                this.Close();
            }
            catch
            {

            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (textBox_weight.Text != string.Empty)
            {
                if (double.TryParse(textBox_weight.Text, out double w))
                {
                    if (w > 0)
                    {
                        weight = Convert.ToDouble(textBox_weight.Text).ToString("#,##0.000");
                        exit = false;
                        this.Close();
                    }
                }
            }

        }

        private void textBox_weight_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    button_confirm_Click(sender, e);
                }
                else if(e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }

            }
            catch
            {

            }
        }

        private void textBox_weight_Leave(object sender, EventArgs e)
        {
            textBox_weight.Focus();
        }
        private void Form_Item_Weight_Shown(object sender, EventArgs e)
        {
            try
            {
              
                textBox_weight.Focus();

            }
            catch
            {

            }
        }

       

        private void textBox_weight_KeyPress(object sender, KeyPressEventArgs e)
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

                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 3 ตำแหน่ง
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

                        if ((postDotText.Length - selectedLengthAfterDot) >= 3)
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
        private void pictureBox_item_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_item.Image = Class_Image.resizeImage(set_image, new Size(set_image.Width + 10, set_image.Height + 10));
            }
            catch
            {

            }
        }
        private void pictureBox_item_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_item.Image = Class_Image.resizeImage(set_image, new Size(set_image.Width - 10, set_image.Height - 10));
            }
            catch
            {

            }
        }



        private void bar_enter(object sender, EventArgs e)
        {
            try
            {
                Label lagel = (Label)sender;
                lagel.ForeColor = Color.Black;
                lagel.Font = new Font(lagel.Font.FontFamily, lagel.Font.Size + 2, lagel.Font.Style);
            }
            catch
            {

            }
        }

        private void bar_leave(object sender, EventArgs e)
        {
            try
            {
                Label lagel = (Label)sender;
                lagel.ForeColor = Color.Gray;
                lagel.Font = new Font(lagel.Font.FontFamily, lagel.Font.Size - 2, lagel.Font.Style);
            }
            catch
            {

            }
        }

        private void weight_enter(object sender, EventArgs e)
        {
            try
            {
                label_weight.Font = new Font(label_weight.Font.FontFamily, label_weight.Font.Size + 4, label_weight.Font.Style);
            }
            catch
            {

            }
        }

        private void weight_leave(object sender, EventArgs e)
        {
            try
            {
                label_weight.Font = new Font(label_weight.Font.FontFamily, label_weight.Font.Size - 4, label_weight.Font.Style);
            }
            catch
            {

            }
        }

        private void button_confirm_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_confirm.Font = new Font(label_weight.Font.FontFamily, label_weight.Font.Size + 2, label_weight.Font.Style);
            }
            catch
            {

            }
        }

        private void button_confirm_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_confirm.Font = new Font(label_weight.Font.FontFamily, label_weight.Font.Size - 2, label_weight.Font.Style);
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

        private void button_enter(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.ForeColor = Color.Black;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size + 5, button.Font.Style);
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
                button.ForeColor = Color.Gray;
                button.Font = new Font(button.Font.FontFamily, button.Font.Size - 5, button.Font.Style);
            }
            catch
            {

            }
        }
    }
}
