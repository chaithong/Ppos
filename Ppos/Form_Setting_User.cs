using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Ppos.Class;
using System.Reflection;

namespace Ppos
{
    public partial class Form_Setting_User : Form
    {
        DataTable dt;
        public Form_Setting_User()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dataGridView_user.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_user, true, null);

            foreach (DataGridViewColumn column in dataGridView_user.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            new Class_TouchGrid(dataGridView_user);
            dataGridView_user.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView_user.EnableHeadersVisualStyles = false;

            button_add_user.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(40, 40));
            // เพิ่ม Code นี้ใน Constructor หรือ Form_Load เพื่อผูก Event
            dataGridView_user.MouseWheel += new MouseEventHandler(dataGridView_user_MouseWheel);
        }

        // ฟังก์ชันควบคุมการเลื่อนเมื่อหมุน Mouse Wheel
        private void dataGridView_user_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_user.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_user.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_user.RowCount)
            {
                newIndex = dataGridView_user.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_user.FirstDisplayedScrollingRowIndex = newIndex;
        }

        private void Form_Setting_User_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT user,password,save_user,save_pass,status From User where status = '1'";
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);
                        //// ถ้ามีใน user
                        if (dt.Rows.Count > 0)
                        {
                            Image trash;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                trash = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30));
                                /// ถ้าเป็น user login จะไม่แสดงลบ
                                if (dt.Rows[i][0].ToString() == Class_Parameter.User_Login)
                                {
                                    trash = new Bitmap(20, 20);
                                }
                                dataGridView_user.Rows.Insert(0,
                                    "",
                                    dt.Rows[i][0].ToString(),
                                    dt.Rows[i][1].ToString(),
                                    trash,
                                    "");
                            }
                            dataGridView_user.ClearSelection();
                        }
                    }
                    con_sqlite.Close();
                }
                textBox_user.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void button_add_user_Click(object sender, EventArgs e)
        {
            try
            {
                button_add_user.Enabled = false;
                if (textBox_user.Text != string.Empty && textBox_pass.Text != string.Empty)
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = "SELECT user From User where status = '1'";
                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);
                            bool user_pass = true;
                            //// ตรวจสอบชื่อซ้ำ
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["user"].ToString() == textBox_user.Text)
                                    {
                                        user_pass = false;
                                        MessageBox.Show("มีชื่อซ้ำกัน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                            }
                            if (user_pass)
                            {
                                cmd_sqlite.CommandText = "INSERT INTO User(created_by,created_date,updated_by,updated_date,user,password,save_user,save_pass,status) " +
                                                    "VALUES('" + Class_Parameter.User_Login + "',datetime('now', 'localtime'),'','','" + textBox_user.Text + "','" + textBox_pass.Text + "',false,false,true)";
                                cmd_sqlite.ExecuteNonQuery();
                                dataGridView_user.Rows.Insert(0,
                                    "",
                                    textBox_user.Text,
                                    textBox_pass.Text,
                                    Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30)),
                                    "");

                                dataGridView_user.Rows[0].Selected = true;

                                textBox_user.Text = "";
                                textBox_pass.Text = "";

                                textBox_user.Focus();
                            }

                        }
                        con_sqlite.Close();
                    }
                }
                button_add_user.Enabled = true;
            }
            catch (Exception ex)
            {
                button_add_user.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView_user_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    /// ถ้ากด delete และ ไม่ใช่ user login
                    if (e.ColumnIndex == dataGridView_user.Columns["delete"]!.Index &&
                       dataGridView_user.Rows[dataGridView_user.CurrentRow!.Index].Cells[dataGridView_user.Columns["user"]!.Index].Value!.ToString() != Class_Parameter.User_Login
                    )
                    {
                        if (MessageBox.Show("ต้องการลบ " +
                            dataGridView_user.Rows[dataGridView_user.CurrentRow.Index].Cells[dataGridView_user.Columns["user"]!.Index].Value!.ToString() +
                            "ใช่หรือไม่ ?"
                            , "แจ้งเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {


                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    cmd_sqlite.CommandText = "UPDATE User set updated_date = datetime('now', 'localtime'), updated_by = '" + Class_Parameter.User_Login + "', " +
                                        "status = '0' " +
                                        "where user = '" + dataGridView_user.Rows[dataGridView_user.CurrentRow.Index].Cells[dataGridView_user.Columns["user"]!.Index].Value!.ToString() + "'";
                                    cmd_sqlite.ExecuteNonQuery();
                                }
                                con_sqlite.Close();
                            }
                            dataGridView_user.Rows.RemoveAt(dataGridView_user.CurrentRow.Index);
                            dataGridView_user.ClearSelection();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void textBox_user_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_user.Text != string.Empty)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (textBox_pass.Text != string.Empty)
                        {
                            button_add_user_Click(sender, e);
                        }
                        else
                        {
                            textBox_pass.Focus();
                        }
                    }
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
                if (textBox_pass.Text != string.Empty)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (textBox_user.Text != string.Empty)
                        {
                            button_add_user_Click(sender, e);
                        }
                        else
                        {
                            textBox_user.Focus();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void textBox_pass_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ตรวจสอบว่าถ้ากดปุ่ม Space (เว้นวรรค)
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // ยกเลิกการพิมพ์ตัวอักษรนั้น
            }
        }

        private void dataGridView_user_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    // dataGridView_user.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255); // สีที่ต้องการตอนชี้
                    dataGridView_user.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);

                }
            }
            catch
            { }
        }

        private void dataGridView_user_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // dataGridView_user.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้

                    dataGridView_user.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular);

                }
            }
            catch
            { }
        }

        private void button_add_user_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_add_user.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(35, 35));
            }
            catch
            {

            }
        }

        private void button_add_user_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_add_user.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(40, 40));
            }
            catch
            {

            }
        }

       
    }
}
