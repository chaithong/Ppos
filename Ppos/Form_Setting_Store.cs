using Hardware.Info;
using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Setting_Store : Form
    {
        bool edit_save = true;
        int Corners = 30; // มุม
        System.Data.DataTable dt;
        public Form_Setting_Store()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                customGroupBox.Location = new System.Drawing.Point(
                               (panel_detail.Width / 2) - (customGroupBox.Width / 2),
                               10);

                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));

                button_cancel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(40, 40));

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);
                // ค้นหาภาพ
                if (System.IO.File.Exists(Form_Login.logo_path + @"\Logo.Png"))
                {
                    using (FileStream bitmapFile = new FileStream(Form_Login.logo_path + @"\Logo.Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        pictureBox.Image = new Bitmap(bitmapFile);

                    }
                }
                else
                {
                    pictureBox.Image = Ppos.Properties.Resources.logo_Ppos;
                }
                Enabled(false);
                getStore();
            }
            catch
            {
                this.Close();
            }

        }
        private void Enabled(bool e)
        {
            try
            {
                pictureBox.Enabled = e;
                store_no.Enabled = e;
                store_name.Enabled = e;
                tax_id.Enabled = e;
                address.Enabled = e;
                sub_district.Enabled = e;
                district.Enabled = e;
                province.Enabled = e;
                postal_code.Enabled = e;
                phone.Enabled = e;
                email.Enabled = e;

                if (e)
                {
                    store_no.BackColor = Color.White;
                    store_name.BackColor = Color.White;
                    tax_id.BackColor = Color.White;
                    address.BackColor = Color.White;
                    sub_district.BackColor = Color.White;
                    district.BackColor = Color.White;
                    province.BackColor = Color.White;
                    postal_code.BackColor = Color.White;
                    phone.BackColor = Color.White;
                    email.BackColor = Color.White;
                }
                else
                {
                    store_no.BackColor = Color.FromArgb(192, 255, 255);
                    store_name.BackColor = Color.FromArgb(192, 255, 255);
                    tax_id.BackColor = Color.FromArgb(192, 255, 255);
                    address.BackColor = Color.FromArgb(192, 255, 255);
                    sub_district.BackColor = Color.FromArgb(192, 255, 255);
                    district.BackColor = Color.FromArgb(192, 255, 255);
                    province.BackColor = Color.FromArgb(192, 255, 255);
                    postal_code.BackColor = Color.FromArgb(192, 255, 255);
                    phone.BackColor = Color.FromArgb(192, 255, 255);
                    email.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch
            {

            }
        }
        private void button_edit_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit_save)
                {
                    Enabled(true);

                    store_no.Focus();

                    // ปุ่มแก้ไข
                    edit_save = false;
                    button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(45, 45));
                    button_edit_save.Text = "บันทึก";

                    // เปิดปุ่มยกเลิก
                    button_cancel.Enabled = true;

                }
                else
                {
                    if(store_no.Text.Trim() != string.Empty)
                    {
                        if(store_name.Text.Trim() != string.Empty)
                        {
                            // ถ้ามีภาพ master
                            if (System.IO.File.Exists(Form_Login.logo_path + @"\master.Png"))
                            {
                                // ถ้ามีภาพเดิม ชื่อเดิมจะทำการลบก่อน
                                if (System.IO.File.Exists(Form_Login.logo_path + @"\Logo.Png"))
                                {

                                    System.IO.File.Delete(Form_Login.logo_path + @"\Logo.Png");
                                }
                                // เปลี่ยนชื่อ master เป็น barcode
                                System.IO.File.Move(Form_Login.logo_path + @"\master.Png", Form_Login.logo_path + @"\Logo.Png");
                            }
                            insertStore();
                            Enabled(false);
                            // ปุ่มแก้ไข
                            edit_save = true;
                            button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                            button_edit_save.Text = "แก้ไข";

                            // ปิดปุ่มยกเลิก
                            button_cancel.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรองชื่อร้านก่อนบันทึก !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            store_name.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรองรหัสร้านก่อนบันทึก !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        store_no.Focus();
                    }

                }
            }
            catch
            {

            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                // ลบภาพ master
                if (System.IO.File.Exists(Form_Login.logo_path + @"\master.Png"))
                {
                    System.IO.File.Delete(Form_Login.logo_path + @"\master.Png");

                }
                // ค้นหาภาพ
                if (System.IO.File.Exists(Form_Login.logo_path + @"\Logo.Png"))
                {
                    using (FileStream bitmapFile = new FileStream(Form_Login.logo_path + @"\Logo.Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        pictureBox.Image = new Bitmap(bitmapFile);

                    }
                }
                else
                {
                    pictureBox.Image = Ppos.Properties.Resources.logo_Ppos;
                }

                getStore();

                Enabled(false);
                // ปุ่มแก้ไข
                edit_save = true;
                button_edit_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));
                button_edit_save.Text = "แก้ไข";

                // เปิดปุ่มยกเลิก
                button_cancel.Enabled = false;
            }
            catch
            {

            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "เลือกรูปภาพ Logo";
                openFileDialog.Filter = "Image Files|*.png|Image Files|*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var bitmaps = new Bitmap(openFileDialog.FileName);
                    var bitmap = resizeBitmap(bitmaps);
                    if (bitmap is not null)
                    {
                        if (System.IO.File.Exists(Form_Login.logo_path + @"\master.Png"))
                        {
                            System.IO.File.Delete(Form_Login.logo_path + @"\master.Png");
                        }
                        Class_RoundedCorners.CreateRoundedCorners(bitmap, Corners).Save(Form_Login.logo_path + @"\master.Png", ImageFormat.Png);

                        pictureBox.Image = Class_RoundedCorners.CreateRoundedCorners(bitmap, Corners);
                    }
                    else
                    {
                        pictureBox.Image = Ppos.Properties.Resources.picture;
                    }
                }
            }
            catch
            {

            }
        }
        public static Bitmap resizeBitmap(Bitmap bitmaps)
        {
            try
            {
                if (bitmaps.Height > 200)
                {
                    bitmaps = new Bitmap(bitmaps, new Size((bitmaps.Width * 200) / bitmaps.Height, 200));
                }
                return bitmaps;
            }
            catch
            {
                return null;
            }
        }
        public void getStore()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT store_no,store_name,tax_id,address,sub_district,district,province,postal_code,phone,email from Store";
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count == 1)
                        {
                            store_no.Text = dt.Rows[0]["store_no"].ToString();
                            store_name.Text = dt.Rows[0]["store_name"].ToString();
                            tax_id.Text = dt.Rows[0]["tax_id"].ToString();
                            address.Text = dt.Rows[0]["address"].ToString();
                            sub_district.Text = dt.Rows[0]["sub_district"].ToString();
                            district.Text = dt.Rows[0]["district"].ToString();
                            province.Text = dt.Rows[0]["province"].ToString();
                            postal_code.Text = dt.Rows[0]["postal_code"].ToString();
                            phone.Text = dt.Rows[0]["phone"].ToString();
                            email.Text = dt.Rows[0]["email"].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public void insertStore()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "Update Store set " +
                            "updated_by = '" + Class_Parameter.User_Login + "'," +
                            "updated_date = datetime('now', 'localtime')," +
                            "store_no = '" + store_no.Text.Replace("'", "").Trim() + "'," +
                            "store_name = '" + store_name.Text.Replace("'", "").Trim() + "'," +
                            "tax_id = '" + tax_id.Text.Replace("'", "").Trim() + "'," +
                            "address = '" + address.Text.Replace("'", "").Trim() + "'," +
                            "sub_district = '" + sub_district.Text.Replace("'", "").Trim() + "'," +
                            "district = '" + district.Text.Replace("'", "").Trim() + "'," +
                            "province = '" + province.Text.Replace("'", "").Trim() + "'," +
                            "postal_code = '" + postal_code.Text.Replace("'", "").Trim() + "'," +
                            "phone = '" + phone.Text.Replace("'", "").Trim() + "'," +
                            "email = '" + email.Text.Replace("'", "").Trim() + "'";
                        cmd_sqlite.ExecuteNonQuery();

                        Class_Parameter.store_name = store_name.Text.Replace("'", "").Trim();
                        Class_Parameter.store_no = store_no.Text.Replace("'", "").Trim();
                    }
                }
            }
            catch
            {

            }
        }

        private void data_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
                    if (textBox.Name == "store_no")
                    {
                        store_name.Focus();
                    }
                    else if (textBox.Name == "store_name")
                    {
                        tax_id.Focus();
                    }
                    else if (textBox.Name == "tax_id")
                    {
                        address.Focus();
                    }
                    else if (textBox.Name == "address")
                    {
                        sub_district.Focus();
                    }
                    else if (textBox.Name == "sub_district")
                    {
                        district.Focus();
                    }
                    else if (textBox.Name == "district")
                    {
                        province.Focus();
                    }
                    else if (textBox.Name == "province")
                    {
                        postal_code.Focus();
                    }
                    else if (textBox.Name == "postal_code")
                    {
                        phone.Focus();
                    }
                    else if (textBox.Name == "phone")
                    {
                        email.Focus();
                    }
                    else if (textBox.Name == "email")
                    {
                        store_no.Focus();
                    }
                }

            }
            catch { }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size + 2, button.Font.Style);
            }
            catch
            {

            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size - 2, button.Font.Style);
            }
            catch
            {

            }
        }
    }
}
