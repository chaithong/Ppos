using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ppos
{
    public partial class Form_Item_Group : Form
    {
        DataTable dt;
        public Form_Item_Group()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                dataGridView_group.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_group, true, null);

                foreach (DataGridViewColumn column in dataGridView_group.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_group);
                dataGridView_group.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dataGridView_group.EnableHeadersVisualStyles = false;

                button_add_group.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(40, 40));

                dataGridView_group.Location = new System.Drawing.Point((panel_back.Width / 2) - (dataGridView_group.Width / 2), 0);

                // เพิ่ม Code นี้ใน Constructor หรือ Form_Load เพื่อผูก Event
                dataGridView_group.MouseWheel += new MouseEventHandler(dataGridView_group_MouseWheel);

                textBox_TextChanged(new System.Windows.Forms.TextBox(), EventArgs.Empty);
            }
            catch
            {
                this.Close();
            }
           

           
        }
        // ฟังก์ชันควบคุมการเลื่อนเมื่อหมุน Mouse Wheel
        private void dataGridView_group_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_group.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_group.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_group.RowCount)
            {
                newIndex = dataGridView_group.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_group.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void Form_Item_Group_Load(object sender, EventArgs e)
        {
            try
            {
              
                textBox_maingroup.Focus();
            }
            catch { }
        }
        private void button_add_group_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_maingroup.Text != string.Empty && textBox_subgroup.Text != string.Empty)
                {
                    if (textBox_maingroup.Text != Class_Parameter.Group_Main && textBox_subgroup.Text != Class_Parameter.Group_Main &&
                       textBox_maingroup.Text != Class_Parameter.Group_Sub && textBox_subgroup.Text != Class_Parameter.Group_Sub)
                    {
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                cmd_sqlite.CommandText = "select 1 from Item_Group " +
                                    "where (group_sub = '" + textBox_subgroup.Text + "' " +
                                    "or group_main = '" + textBox_subgroup.Text + "' " +
                                    "or group_sub = '" + textBox_maingroup.Text + "') " +
                                    "and status = 1";
                                var er = cmd_sqlite.ExecuteReader();
                                dt = new DataTable();
                                dt.Load(er);
                                // กลุ่มย่อยต้องไม่เหมือนกับกลุ่มทั้งหมด
                                if (dt.Rows.Count == 0)
                                {
                                    cmd_sqlite.CommandText = "INSERT INTO Item_Group(created_by,created_date,updated_by,updated_date,group_main,group_sub,status) " +
                                                           "VALUES('" + Class_Parameter.User_Login + "',datetime('now', 'localtime'),'',''," +
                                                           "'" + textBox_maingroup.Text.Trim() + "','" + textBox_subgroup.Text.Trim() + "',1)";
                                    cmd_sqlite.ExecuteNonQuery();

                                    textBox_maingroup.Text = "";
                                    textBox_subgroup.Text = "";

                                    textBox_TextChanged(sender, e);

                                    textBox_maingroup.Focus();
                                }
                                else
                                {

                                    MessageBox.Show("ชื่อกลุ่มซ้ำกัน ซ้ำกัน !!"+Environment.NewLine +
                                        "ชื่อกลุ่มหลักเหมือนกันได้"+Environment.NewLine+
                                        "แต่ชื่อกลุ่มย่อยต้องไม่เหมือนกัน"+Environment.NewLine+
                                        "และชื่อกลุ่มย่อยต้องไม่เหมือนชื่อกลุ่มหลัก"
                                        , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    textBox_subgroup.Focus();

                                }
                            }
                            con_sqlite.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("กลุ่มหลักห้ามใช้คำว่า กลุ่มหลัก" + Environment.NewLine +
                            "กลุ่มย่อยห้ามใช้คำว่า กลุ่มย่อย", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox_subgroup.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                dataGridView_group.Rows.Clear();
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT ig.group_main ,ig.group_sub  " +
                            "FROM Item_Group ig " +
                            "WHERE ig.group_main <> 'กลุ่มหลัก' " +
                            "and ig.status = 1 ";
                        if (textBox_maingroup.Text != "")
                        {
                            cmd_sqlite.CommandText += "and ig.group_main like '%" + textBox_maingroup.Text + "%' ";
                        }
                        if (textBox_subgroup.Text != "")
                        {
                            cmd_sqlite.CommandText += "and ig.group_sub like '%" + textBox_subgroup.Text + "%' ";
                        }
                        cmd_sqlite.CommandText += "order by ig.group_main ,ig.group_sub";
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            Image image = Class_Image.resizeImage(Ppos.Properties.Resources.exits, new Size(30, 30));
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView_group.Rows.Add(
                                    "",
                                    dt.Rows[i][0].ToString()!,
                                    dt.Rows[i][1].ToString()!,
                                    image,
                                    "");
                            }
                            dataGridView_group.ClearSelection();
                        }

                    }
                    con_sqlite.Close();
                }

            }
            catch
            {

            }
        }

        private void dataGridView_group_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == dataGridView_group.Columns["delete"]!.Index)
                    {
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                cmd_sqlite.CommandText = "SELECT count(code) from Item " +
                                    "where group_main = '" + dataGridView_group.Rows[e.RowIndex].Cells["maingroup"].Value!.ToString() + "' " +
                                    "and group_sub = '" + dataGridView_group.Rows[e.RowIndex].Cells["subgroup"].Value!.ToString() + "' " +
                                    "and status = 1";
                                var er = cmd_sqlite.ExecuteReader();
                                dt = new DataTable();
                                dt.Load(er);

                                if (dt.Rows[0][0].ToString() == "0")
                                {
                                    if (MessageBox.Show("ต้องการลบ " + Environment.NewLine +
                                                    "กลุ่มหลัก : " + dataGridView_group.Rows[e.RowIndex].Cells["maingroup"].Value!.ToString() + Environment.NewLine +
                                                    "กลุ่มย่อย : " + dataGridView_group.Rows[e.RowIndex].Cells["subgroup"].Value!.ToString() + Environment.NewLine +
                                                    "ใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        cmd_sqlite.CommandText = "UPDATE Item_Group set updated_date = datetime('now', 'localtime'), updated_by = '" + Class_Parameter.User_Login + "', " +
                                            "status = '0' " +
                                            "where group_main = '" + dataGridView_group.Rows[e.RowIndex].Cells["maingroup"].Value!.ToString() + "'" +
                                            "and group_sub = '" + dataGridView_group.Rows[e.RowIndex].Cells["subgroup"].Value!.ToString() + "'";
                                        cmd_sqlite.ExecuteNonQuery();

                                        dataGridView_group.Rows.RemoveAt(e.RowIndex);
                                        dataGridView_group.ClearSelection();


                                    }
                                }
                                else
                                {
                                    MessageBox.Show("กลุ่มหลัก : " + dataGridView_group.Rows[e.RowIndex].Cells["maingroup"].Value!.ToString() + Environment.NewLine +
                                                    "กลุ่มย่อย : " + dataGridView_group.Rows[e.RowIndex].Cells["subgroup"].Value!.ToString() + Environment.NewLine +
                                                    "ไม่สามารถลบได้ เนื่องจากใช้งานกับสินค้าแล้ว " + dt.Rows[0][0].ToString() + " รายการ"
                                        , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void textBox_maingroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (textBox_maingroup.Text != string.Empty)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        textBox_subgroup.Focus();
                    }

                }
            }
            catch
            {

            }
        }

        private void textBox_subgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button_add_group_Click(sender, e);
                }
            }
            catch
            {

            }
        }


        private void dataGridView_group_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
            if (e.RowIndex >= 0)
            {
                // dataGridView_group.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192); // สีที่ต้องการตอนชี้
                dataGridView_group.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            }
        }

        private void dataGridView_group_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    //  dataGridView_group.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    dataGridView_group.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular);

                }
            }
            catch
            { }
        }

        private void button_add_group_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_add_group.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(35, 35));
            }
            catch
            {

            }
        }

        private void button_add_group_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_add_group.Image = Class_Image.resizeImage(Ppos.Properties.Resources.create, new Size(40, 40));
            }
            catch
            {

            }
        }
    }
}
