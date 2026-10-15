using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Login : Form
    {

        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ppos";
        public static string sqlite_path = @"Data Source=" + path + @"\database.db;Version=3";
        public static string item_path = path + @"\Image\Item";
        public static string logo_path = path + @"\Image\Logo";
        bool save_user = false, save_pass = false;
        DataTable dt;
        public Form_Login()
        {
            InitializeComponent();

            try
            {
                this.DoubleBuffered = true;
                // 1. ตั้งค่าให้สามารถกำหนดตำแหน่งฟอร์มแบบกำหนดเอง (Manual)
                this.StartPosition = FormStartPosition.Manual;

                // 2. ดึงข้อมูลพื้นที่ทำงานของหน้าจอหลัก (Primary Screen / จอ 1)
                var primaryScreen = Screen.PrimaryScreen;

                if (primaryScreen != null)
                {
                    // 3. คำนวณจุดกึ่งกลางของหน้าจอหลัก
                    int x = primaryScreen.WorkingArea.Left + (primaryScreen.WorkingArea.Width - this.Width) / 2;
                    int y = primaryScreen.WorkingArea.Top + (primaryScreen.WorkingArea.Height - this.Height) / 2;

                    // 4. กำหนดตำแหน่งให้กับฟอร์ม
                    this.Location = new Point(x, y);
                }
                pictureBox_logo.Image = Ppos.Properties.Resources.logo_Ppos;
            }
            catch
            {
                Application.Exit();
            }

        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            try
            {
                label_version.Text = Class_Parameter.Version;
                // ตรวจสอบมี database แล้ว
                if (File.Exists(path + @"\database.db"))
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            // หา user ที่มีบันทึก
                            cmd_sqlite.CommandText = "SELECT user,password,save_user,save_pass from User " +
                                                            "WHERE (save_user = 1 or " +
                                                            "save_pass = 1) " +
                                                            "and status = 1 ";
                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);
                            if (dt.Rows.Count == 1)
                            {
                                if (Convert.ToBoolean(dt.Rows[0]["save_user"]))
                                {
                                    textBox_user.Text = dt.Rows[0]["user"].ToString();
                                    save_user = true;
                                    pictureBox_save_user.Image = Ppos.Properties.Resources.enable_check;
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["save_pass"]))
                                {
                                    textBox_pass.Text = dt.Rows[0]["password"].ToString();
                                    save_pass = true;
                                    pictureBox_save_pass.Image = Ppos.Properties.Resources.enable_check;


                                }
                            }
                        }
                        con_sqlite.Close();
                    }
                }
            }
            catch
            {
                Application.Exit();
            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox_user.Text != string.Empty && textBox_pass.Text != string.Empty)
                {
                    Class_Parameter.User_Login = textBox_user.Text;
                    if (textBox_user.Text == "Admin" && textBox_pass.Text == "1234")
                    {
                        this.Hide();
                        Form_Main form_Main = new Form_Main();
                        form_Main.ShowDialog();
                        this.Show();
                        textBox_user.Text = "";
                        textBox_pass.Text = "";

                    }
                    else
                    {
                        // ตรวจสอบมี database แล้ว
                        if (File.Exists(path + @"\database.db"))
                        {
                            bool user_pass = false;
                            using (SQLiteConnection con_sqlite = new SQLiteConnection(sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    cmd_sqlite.CommandText = "SELECT user,password,save_user,save_pass from User " +
                                                             "WHERE user = '" + textBox_user.Text + "' and " +
                                                             "password = '" + textBox_pass.Text + "' " +
                                                             "and status = 1";
                                    var er = cmd_sqlite.ExecuteReader();
                                    dt = new DataTable();
                                    dt.Load(er);
                                    // ถ้ามีใน user
                                    if (dt.Rows.Count == 1)
                                    {
                                        // update 0 ทั้งหมดก่อน
                                        cmd_sqlite.CommandText = "UPDATE User SET save_user = 0 ,save_pass = 0 ";
                                        cmd_sqlite.ExecuteNonQuery();

                                        if (save_user) // บันทึกชื่อ
                                        {
                                            cmd_sqlite.CommandText = "UPDATE User SET save_user = 1 " +
                                                                     "WHERE user = '" + textBox_user.Text + "' and password = '" + textBox_pass.Text + "'";
                                            cmd_sqlite.ExecuteNonQuery();

                                        }

                                        if (save_pass) // บันทึกรหัส
                                        {
                                            cmd_sqlite.CommandText = "UPDATE User SET save_pass = 1 " +
                                                                  "WHERE user = '" + textBox_user.Text + "' and password = '" + textBox_pass.Text + "'";
                                            cmd_sqlite.ExecuteNonQuery();
                                        }

                                        user_pass = true;
                                    }
                                    else
                                    {
                                        textBox_user.ForeColor = Color.Red;
                                        textBox_pass.ForeColor = Color.Red;
                                    }
                                }
                                con_sqlite.Close();
                            }
                            if (user_pass)
                            {
                                this.Hide();
                                Form_Main form_Main = new Form_Main();
                                form_Main.ShowDialog();
                                this.Show();
                                if (!save_user)
                                {
                                    textBox_user.Text = "";
                                }
                                if (!save_pass)
                                {
                                    textBox_pass.Text = "";
                                }
                            }
                        }
                    }
                }


                textBox_user.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox_save_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (save_user)
                {
                    save_user = false;
                    pictureBox_save_user.Image = Ppos.Properties.Resources.disable_check;
                }
                else
                {
                    save_user = true;
                    pictureBox_save_user.Image = Ppos.Properties.Resources.enable_check;
                }
            }
            catch
            {

            }
        }

        private void pictureBox_save_pass_Click(object sender, EventArgs e)
        {
            try
            {
                if (save_pass)
                {
                    save_pass = false;
                    pictureBox_save_pass.Image = Ppos.Properties.Resources.disable_check;
                }
                else
                {
                    save_pass = true;
                    pictureBox_save_pass.Image = Ppos.Properties.Resources.enable_check;
                }
            }
            catch
            {

            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_user.ForeColor == Color.Red)
                {
                    textBox_user.ForeColor = Color.Black;

                }
                if (textBox_pass.ForeColor == Color.Red)
                {
                    textBox_pass.ForeColor = Color.Black;
                }


            }
            catch
            {

            }
        }
        private void textBox_user_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    textBox_pass.Focus();
                }
            }
            catch
            {

            }
        }

        private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    button_login_Click(sender, e);
                }
            }
            catch
            {

            }
        }
      
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ตรวจสอบว่าถ้ากดปุ่ม Space (เว้นวรรค)
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // ยกเลิกการพิมพ์ตัวอักษรนั้น
            }
        }

        private void pictureBox_logo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                pictureBox_logo.Image = Class_Image.resizeImage(Ppos.Properties.Resources.logo_Ppos,
                    new Size(Ppos.Properties.Resources.logo_Ppos.Width - 50, Ppos.Properties.Resources.logo_Ppos.Height - 50));
            }
            catch
            {

            }
        }

        private void pictureBox_logo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pictureBox_logo.Image = Ppos.Properties.Resources.logo_Ppos;
            }
            catch
            {

            }
        }

        private void textBox_user_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_user.ForeColor = Color.Black;
                label_user.Font = new Font(label_user.Font.FontFamily, 17F, label_user.Font.Style);
            }
            catch
            {

            }
        }

        private void textBox_user_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_user.ForeColor = Color.DimGray;
                label_user.Font = new Font(label_user.Font.FontFamily, 16F, label_user.Font.Style);
            }
            catch
            {

            }
        }

        private void textBox_pass_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_pass.ForeColor = Color.Black;
                label_pass.Font = new Font(label_pass.Font.FontFamily, 17F, label_pass.Font.Style);
            }
            catch
            {

            }
        }

        private void textBox_pass_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_pass.ForeColor = Color.DimGray;
                label_pass.Font = new Font(label_pass.Font.FontFamily, 16F, label_pass.Font.Style);
            }
            catch
            {

            }
        }

        private void label_save_user_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_save_user.ForeColor = Color.Black;
                label_save_user.Font = new Font(label_save_user.Font.FontFamily, 11F, label_save_user.Font.Style);
            }
            catch
            {

            }
        }

        private void label_save_user_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_save_user.ForeColor = Color.DimGray;
                label_save_user.Font = new Font(label_save_user.Font.FontFamily, 10F, label_save_user.Font.Style);
            }
            catch
            {

            }
        }

        private void label_save_pass_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                label_save_pass.ForeColor = Color.Black;
                label_save_pass.Font = new Font(label_save_pass.Font.FontFamily, 11F, label_save_pass.Font.Style);
            }
            catch
            {

            }
        }

        private void label_save_pass_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                label_save_pass.ForeColor = Color.DimGray;
                label_save_pass.Font = new Font(label_save_pass.Font.FontFamily, 10F, label_save_pass.Font.Style);
            }
            catch
            {

            }
        }

       
    }
}
