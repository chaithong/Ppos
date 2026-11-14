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
    public partial class Form_Load_Template : Form
    {
        public bool exit = true;
        public string group_main = "", group_sub = "";
        public Form_Load_Template()
        {
            InitializeComponent();
            try
            {
                button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(50, 50));

                comboBox_group_main.Items.Add("ทั้งหมด");
                comboBox_group_sub.Items.Add("ทั้งหมด");
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT ig.group_main from Item_Group ig group by ig.group_main ORDER by ig.created_date ";

                        SQLiteDataReader dr = cmd_sqlite.ExecuteReader();
                        DataTable dt = new System.Data.DataTable();
                        dt.Load(dr);
                        if (dt.Rows.Count > 0)
                        {
                           
                            foreach (DataRow row in dt.Rows)
                            {
                                comboBox_group_main.Items.Add(row[0].ToString()!); // ใช้เลข 0 แทนชื่อคอลัมน์ได้เลย
                            }
                            
                        }

                        cmd_sqlite.CommandText = "SELECT ig.group_sub from Item_Group ig group by ig.group_sub ORDER by ig.created_date ";

                        dr = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(dr);
                        if (dt.Rows.Count > 0)
                        {
                           
                            foreach (DataRow row in dt.Rows)
                            {
                                comboBox_group_sub.Items.Add(row[0].ToString()!); // ใช้เลข 0 แทนชื่อคอลัมน์ได้เลย
                            }
                           
                        }
                    }
                }
                comboBox_group_main.SelectedIndex = 0;
                comboBox_group_sub.SelectedIndex = 0;
            }
            catch
            {
                this.Close();
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox_group_main.Text != string.Empty && comboBox_group_sub.Text != string.Empty)
                {
                    if (comboBox_group_main.Text != "ทั้งหมด" || comboBox_group_sub.Text != "ทั้งหมด")
                    {
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                if (comboBox_group_main.Text != "ทั้งหมด")
                                {
                                    // หาชื่อกลุ่มหลักมีหรือไม่
                                    cmd_sqlite.CommandText = "SELECT ig.group_main from Item_Group ig where ig.group_main = '"+comboBox_group_main.Text+"' group by ig.group_main ORDER by ig.created_date ";

                                    SQLiteDataReader dr = cmd_sqlite.ExecuteReader();
                                    DataTable dt = new System.Data.DataTable();
                                    dt.Load(dr);
                                    if (dt.Rows.Count == 0)
                                    {
                                        return;
                                    }
                                }
                                if (comboBox_group_sub.Text != "ทั้งหมด")
                                {
                                    // หาชื่อกลุ่มย่อยมีหรือไม่
                                    cmd_sqlite.CommandText = "SELECT ig.group_sub from Item_Group ig where ig.group_sub = '"+comboBox_group_sub.Text+"' group by ig.group_sub ORDER by ig.created_date ";

                                    SQLiteDataReader dr = cmd_sqlite.ExecuteReader();
                                    DataTable dt = new System.Data.DataTable();
                                    dt.Load(dr);
                                    if (dt.Rows.Count == 0)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                   
                    group_main = comboBox_group_main.Text;
                    group_sub = comboBox_group_sub.Text;
                    exit = false;
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
                button_confirm.Font = new System.Drawing.Font(button_confirm.Font.FontFamily, button_confirm.Font.Size + 2, button_confirm.Font.Style);


            }
            catch
            {

            }
        }
        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                button_confirm.Font = new System.Drawing.Font(button_confirm.Font.FontFamily, button_confirm.Font.Size - 2, button_confirm.Font.Style);

            }
            catch
            {

            }
        }
        private void label_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label lagel = (System.Windows.Forms.Label)sender;
                lagel.Font = new System.Drawing.Font(lagel.Font.FontFamily, lagel.Font.Size + 2, lagel.Font.Style);
            }
            catch
            {

            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label lagel = (System.Windows.Forms.Label)sender;
                lagel.Font = new System.Drawing.Font(lagel.Font.FontFamily, lagel.Font.Size - 2, lagel.Font.Style);
            }
            catch
            {

            }
        }
    }
}
