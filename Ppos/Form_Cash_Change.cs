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
    public partial class Form_Cash_Change : Form
    {
        public Form_Cash_Change()
        {
            InitializeComponent();
            try
            {
                label_cash_change.Text = Form_Pay.cash_change;
                button_OK.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new System.Drawing.Size(100, 100));
            }
            catch
            {

            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
            }
            catch
            {

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
        private void button_OK_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_OK.Font = new System.Drawing.Font(button_OK.Font.FontFamily, button_OK.Font.Size + 5, button_OK.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_OK_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_OK.Font = new System.Drawing.Font(button_OK.Font.FontFamily, button_OK.Font.Size - 5, button_OK.Font.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
