using AForge.Video;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Check : Form
    {
        public Form_Check()
        {
            InitializeComponent();
            try
            {
                button_check_item.Image = Class_Image.resizeImage(Ppos.Properties.Resources.product, new Size(60, 60));
                button_check_promotion.Image = Class_Image.resizeImage(Ppos.Properties.Resources.promotions, new Size(60, 60));
               
                button_check_invoice.Image = Class_Image.resizeImage(Ppos.Properties.Resources.SDeatil, new Size(50, 50));
                button_exit.Image = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(50, 50));

                if (Class_Parameter.menu_check == 1) // ตรวจสอบสินค้า
                {
                    // เปลี่ยนสีปุ่ม
                    button_check_item.FlatStyle = FlatStyle.Standard;


                    Form_Check_Item form_show = new Form_Check_Item();
                    form_show.TopLevel = false;
                    panel_check.Controls.Add(form_show);
                    form_show.BringToFront();
                    form_show.Dock = DockStyle.Fill;
                    form_show.Show();
                }
                else if (Class_Parameter.menu_check == 2) // ตรวจสอบโปรโมชั่น
                {
                    // เปลี่ยนสีปุ่ม
                    button_check_promotion.FlatStyle = FlatStyle.Standard;

                    Form_Check_Promotion form_show = new Form_Check_Promotion();
                    form_show.TopLevel = false;
                    panel_check.Controls.Add(form_show);
                    form_show.BringToFront();
                    form_show.Dock = DockStyle.Fill;
                    form_show.Show();
                }              
                else if (Class_Parameter.menu_check == 3) // ตรวจสอบบิลขาย
                {
                    // เปลี่ยนสีปุ่ม
                    button_check_invoice.FlatStyle = FlatStyle.Standard;

                    Form_Check_Invoice form_show = new Form_Check_Invoice();
                    form_show.TopLevel = false;
                    panel_check.Controls.Add(form_show);
                    form_show.BringToFront();
                    form_show.Dock = DockStyle.Fill;
                    form_show.Show();
                }
                else
                {
                    this.Close();
                }

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
                foreach (Control ctrl in panel_check.Controls)
                {
                    if (ctrl is Form f)
                    {
                        f.Close();
                        ctrl.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                    }
                }
                this.Close();
            }
            catch
            {

            }

        }

        private void Check_Click(object sender, EventArgs e)
        {
            try
            {
                if(!Class_Parameter.runbackground)
                {
                    Button b = (Button)sender;
                    if (b.Name == "button_check_item" && Class_Parameter.menu_check != 1)
                    {
                        Class_Parameter.menu_check = 1;
                        foreach (Control ctrl in panel_check.Controls)
                        {
                            if (ctrl is Form f && ctrl.Name != "Form_Check_Item")
                            {
                                f.Close();
                                ctrl.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                            }
                        }
                        if (panel_check.Controls.Find("Form_Check_Item", true).FirstOrDefault() == null)
                        {
                            Form_Check_Item form_Check_Item = new Form_Check_Item();
                            form_Check_Item.TopLevel = false;
                            panel_check.Controls.Add(form_Check_Item);
                            form_Check_Item.BringToFront();
                            form_Check_Item.Dock = DockStyle.Fill;
                            form_Check_Item.Show();

                        }
                        // เปลี่ยนสีปุ่ม
                        button_check_item.FlatStyle = FlatStyle.Standard;
                        button_check_promotion.FlatStyle = FlatStyle.Flat;
                        button_check_invoice.FlatStyle = FlatStyle.Flat;
                    }
                    else if (b.Name == "button_check_promotion" && Class_Parameter.menu_check != 2)
                    {
                        Class_Parameter.menu_check = 2;
                        foreach (Control ctrl in panel_check.Controls)
                        {
                            if (ctrl is Form f && ctrl.Name != "Form_Check_Promotion")
                            {
                                f.Close();
                                ctrl.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                            }
                        }
                        if (panel_check.Controls.Find("Form_Check_Promotion", true).FirstOrDefault() == null)
                        {
                            Form_Check_Promotion form_Check_Promotion = new Form_Check_Promotion();
                            form_Check_Promotion.TopLevel = false;
                            panel_check.Controls.Add(form_Check_Promotion);
                            form_Check_Promotion.BringToFront();
                            form_Check_Promotion.Dock = DockStyle.Fill;
                            form_Check_Promotion.Show();

                        }
                        // เปลี่ยนสีปุ่ม
                        button_check_item.FlatStyle = FlatStyle.Flat;
                        button_check_promotion.FlatStyle = FlatStyle.Standard;
                        button_check_invoice.FlatStyle = FlatStyle.Flat;
                    }
                   
                    else if (b.Name == "button_check_invoice" && Class_Parameter.menu_check != 3)
                    {
                        Class_Parameter.menu_check = 3;
                        foreach (Control ctrl in panel_check.Controls)
                        {
                            if (ctrl is Form f && ctrl.Name != "Form_Check_Invoice")
                            {
                                f.Close();
                                ctrl.Dispose(); // สำคัญมาก: ต้อง Dispose เพื่อคืน RAM
                            }
                        }
                        if (panel_check.Controls.Find("Form_Check_Invoice", true).FirstOrDefault() == null)
                        {
                            Form_Check_Invoice form_Check_Invoice = new Form_Check_Invoice();
                            form_Check_Invoice.TopLevel = false;
                            panel_check.Controls.Add(form_Check_Invoice);
                            form_Check_Invoice.BringToFront();
                            form_Check_Invoice.Dock = DockStyle.Fill;
                            form_Check_Invoice.Show();

                        }
                        // เปลี่ยนสีปุ่ม
                        button_check_item.FlatStyle = FlatStyle.Flat;
                        button_check_promotion.FlatStyle = FlatStyle.Flat;
                        button_check_invoice.FlatStyle = FlatStyle.Standard;
                    }
                }
                
            }
            catch
            {

            }
        }

        private void button_check_item_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size + 4, FontStyle.Bold);
            }
            catch
            {

            }
        }

        private void button_check_item_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size - 4, FontStyle.Bold);
            }
            catch
            {

            }
        }

        private void Form_Check_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
