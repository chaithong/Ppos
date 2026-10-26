using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Select_Member : Form
    {
        public string id_member;
        public bool exit = true , add_member = false;
        int count_search = 0, set_search = 5;
        string set_member_total;
        int Limit = 20;
        public Form_Select_Member()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;



                dataGridView_member.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_member, true, null);
                foreach (DataGridViewColumn column in dataGridView_member.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_member);
                dataGridView_member.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
                dataGridView_member.EnableHeadersVisualStyles = false;
                dataGridView_member.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);

                button_add_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(40, 40));
            }
            catch
            {
                this.Close();
            }
        }
        private void dataGridView_item_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_member.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_member.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_member.RowCount)
            {
                newIndex = dataGridView_member.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_member.FirstDisplayedScrollingRowIndex = newIndex;
        }


        private void Form_Select_Member_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // โปรทั้งหมด
                        cmd_sqlite.CommandText = "select count(id) from Member where status = 1";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                dataGridView_member.Columns["sex"]!.HeaderText = "0/" + Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                                set_member_total = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }

                        }
                    }
                }
                backgroundWorker_search.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void backgroundWorker_search_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT id, phone, sex, nick_name, first_name, last_name, address, sub_district, district, province, postal_code, discount_percent, sale_total, sale_ineffective_member, sale_effective_member, sale_per_point, point_increase, point_decrease, point_balance, status
                                                   FROM Member
                                                   WHERE status = true ";
                        if (textBox_search.Text != string.Empty)
                        {
                            cmd_sqlite.CommandText += " and (phone like '%" + textBox_search.Text.Trim() + "%' or " +
                                                            "nick_name like '%" + textBox_search.Text.Trim() + "%' or " +
                                                            "first_name like '%" + textBox_search.Text.Trim() + "%' or " +
                                                            "last_name like '%" + textBox_search.Text.Trim() + "%') ";
                        }
                        cmd_sqlite.CommandText += "Limit " + Limit;
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            Image sex;
                            string nick_name = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                if (dt.Rows[i]["sex"].ToString()! == "ชาย")
                                {
                                    sex = Class_Image.resizeImage(Ppos.Properties.Resources.male, new Size(30, 30));
                                }
                                else
                                {
                                    sex = Class_Image.resizeImage(Ppos.Properties.Resources.female, new Size(30, 30));
                                }
                                nick_name = "";
                                if (dt.Rows[i]["nick_name"].ToString()! != string.Empty)
                                {
                                    nick_name = " (" + dt.Rows[i]["nick_name"].ToString()! + ")";
                                }
                                dataGridView_member.Rows.Add(
                               dt.Rows[i]["id"].ToString()!,
                               sex,
                               dt.Rows[i]["phone"].ToString()!,
                               dt.Rows[i]["first_name"].ToString()! + " " + dt.Rows[i]["last_name"].ToString()! + nick_name,
                               Convert.ToDouble(dt.Rows[i]["point_balance"]).ToString("#,##0")!,
                               Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(40, 40))
                               );

                                // แสดงจำนวนบรรทัดสินค้า
                                dataGridView_member.Columns["sex"]!.HeaderText = dataGridView_member.RowCount.ToString() + "/" + set_member_total;
                                dataGridView_member.ClearSelection();
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
               // textBox_search.Enabled = true;
                dataGridView_member.Enabled = true;
                textBox_search.Focus();
                //dataGridView_member.ScrollBars = ScrollBars.Both;
                if (textBox_search.Text != string.Empty && dataGridView_member.RowCount == 0 && int.TryParse(textBox_search.Text, out _))
                {
                    button_add_member.Visible = true;
                }
                else
                {
                    button_add_member.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView_member_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    if (e.ColumnIndex == dataGridView_member.Columns["select"]!.Index)
                    {
                        exit = false;
                        id_member = dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_member_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    exit = false;
                    id_member = dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(!backgroundWorker_search.IsBusy)
                {
                    count_search = 0;
                    button_add_member.Visible = false;
                    if (!timer_search.Enabled)
                    {
                        timer_search.Start();
                    }
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_search_Tick(object sender, EventArgs e)
        {
            try
            {
                count_search++;
                if (count_search >= set_search)
                {

                    timer_search.Stop();

                   // textBox_search.Enabled = false;
                    dataGridView_member.Rows.Clear();
                    dataGridView_member.Enabled = false;
                    count_search = 0;
                    dataGridView_member.Columns["sex"]!.HeaderText = "0/" + set_member_total;
                  //  dataGridView_member.ScrollBars = ScrollBars.None;
                    backgroundWorker_search.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView_member_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_member.Rows[e.RowIndex].Cells["name"].Style.Font = new System.Drawing.Font(
                        dataGridView_member.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_member.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    dataGridView_member.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_member_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_member.Rows[e.RowIndex].Cells["name"].Style.Font = new System.Drawing.Font(
                        dataGridView_member.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_member.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // สีที่ต้องการตอนชี้

                    dataGridView_member.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void button_add_member_Click(object sender, EventArgs e)
        {
            try
            {
                button_add_member.Visible = false;
                // เริ่ม เพิ่ม
                Class_Member_Detail.Add(
                    textBox_search.Text.Trim(),
                    "ชาย",
                    "",
                    DateTime.Now.ToString("dd/MM/yyyy"),
                    DateTime.Now.ToString("HH:mm:ss"),
                    "",
                    "",
                    "",
                    "",
                    "",
                    "0",
                    "1"
                    );
                add_member = true;
               // textBox_search.Enabled = false;
                dataGridView_member.Enabled = false;
               // dataGridView_member.ScrollBars = ScrollBars.None;
                backgroundWorker_search.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_add_member_MouseEnter(object sender, EventArgs e)
        {
            button_add_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(50, 50));

        }

        private void button_add_member_MouseLeave(object sender, EventArgs e)
        {
            button_add_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(40, 40));

        }
    }
}
