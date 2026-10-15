using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ppos
{
    public partial class Form_Redeem_Point : Form
    {
        public bool exit = true;
        double max;
        public string point;
        public Form_Redeem_Point()
        {
            InitializeComponent();

            button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(70, 70));

            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT phone,sex,nick_name,first_name,last_name,
                                                               address,sub_district,district,province,postal_code,
                                                               discount_percent,sale_total,sale_ineffective_member,
                                                               sale_effective_member,sale_per_point,
                                                               point_increase,point_decrease,point_balance
                                                               FROM Member WHERE id = " + Form_Sale.id_member ;
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            label_member.Text = "  " + dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString() + " (" + dt.Rows[0]["nick_name"].ToString() + ")";

                            if (Convert.ToDouble(dt.Rows[0]["point_balance"]) > 0)
                            {
                                label_point_all.Text = Convert.ToDouble(dt.Rows[0]["point_balance"]).ToString("#,##0");
                            }
                            else
                            {
                                MessageBox.Show("สมาชิก " + label_member.Text + " ยังไม่มีแต้มสะสม !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
                if (Convert.ToDouble(label_point_all.Text.Replace(",", "")) > Convert.ToDouble(Form_Pay.point_max.Replace(",", "")))
                {
                    this.Text +=" ใช้ได้ไม่เกิน "+ Convert.ToDouble(Form_Pay.point_max.Replace(",", "")) +" แต้ม";
                }
                else
                {
                    this.Text += " ใช้ได้ไม่เกิน " + Convert.ToDouble(label_point_all.Text.Replace(",", "")) + " แต้ม";
                }
            }
            catch
            {

            }


        }

        private void textBox_point_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // 1. อนุญาตให้กดตัวเลข, backspace
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
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

        private void textBox_point_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (double.TryParse(textBox_point.Text, out double point))
                {
                    max = Convert.ToDouble(label_point_all.Text.Replace(",", ""));

                    if (Convert.ToDouble(label_point_all.Text.Replace(",", "")) > Convert.ToDouble(Form_Pay.point_max.Replace(",", "")))
                    {
                        max = Convert.ToDouble(Form_Pay.point_max.Replace(",", ""));
                    }
                    if (point > max)
                    {
                        textBox_point.Text = max.ToString();
                        // เลื่อนเคอร์เซอร์ไปท้ายสุด
                        textBox_point.SelectionStart = textBox_point.Text.Length;

                    }
                }
            }
            catch
            {

            }
        }

        private void Form_Redeem_Point_Load(object sender, EventArgs e)
        {
            try
            {
                textBox_point.Focus();
            }
            catch
            {

            }
        }

        private void textBox_point_Leave(object sender, EventArgs e)
        {
            textBox_point.Focus();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_point.Text != string.Empty)
                {
                    if (double.TryParse(textBox_point.Text, out double result))
                    {
                        if (result > 0 && result <= max)
                        {                        
                            point = textBox_point.Text;
                            exit = false;
                            this.Close();
                        }
                    }

                }

            }
            catch
            {

            }
        }

        private void textBox_point_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    button_confirm_Click (sender, e);
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
    }
}
