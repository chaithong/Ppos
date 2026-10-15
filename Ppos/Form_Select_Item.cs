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
    public partial class Form_Select_Item : Form
    {
        public bool exit = true;
        int count_search = 0, set_search = 5;
        int Limit = 50;
        string set_item_total;
        public string barcode;
        public Form_Select_Item()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;



                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);
                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
                dataGridView_item.EnableHeadersVisualStyles = false;
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);
            }
            catch
            {
                this.Close();
            }
        }
        private void dataGridView_item_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_item.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_item.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_item.RowCount)
            {
                newIndex = dataGridView_item.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_item.FirstDisplayedScrollingRowIndex = newIndex;
        }
        private void Form_Select_Item_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // โปรทั้งหมด
                        cmd_sqlite.CommandText = "select count(code) from Item where status = 1";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                dataGridView_item.Columns["picture"]!.HeaderText = "0/" + Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                                set_item_total = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
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

        private string script()
        {
            try
            {
                string script;
                script = "SELECT small_barcode,code,group_main,group_sub,name," +
                         "small_barcode as barcode,small_unit as unit,small_price as price," +
                         "small_cost_last as cost_last,small_cost_avg as cost_avg,small_qty as qty,1 as qty_small ,'S' as size " +
                         "from Item " +
                         "where status = 1 ";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or small_barcode like '%" + textBox_search.Text + "%' ) ";
                }
                script += "union all " +
                          "SELECT small_barcode,code,group_main,group_sub,name," +
                          "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small,'M' " +
                          "from Item " +
                          "where status = 1 " +
                          "and medium_barcode <> '' ";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or medium_barcode like '%" + textBox_search.Text + "%' ) ";
                }
                script += "union all " +
                          "SELECT small_barcode,code,group_main,group_sub,name," +
                          "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small,'L' " +
                          "from Item " +
                          "where status = 1 " +
                          "and large_barcode <> ''";
                if (textBox_search.Text != "")
                {
                    script += "and (name like '%" + textBox_search.Text + "%' or large_barcode like '%" + textBox_search.Text + "%' ) ";
                }
                script += "order by code desc ";
                if (Limit > 0)
                {
                    script += "limit " + Limit;
                }


                return script;
            }
            catch
            {
                return null!;
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
                        cmd_sqlite.CommandText = script();
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            Image picture;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //////////// ค้นหาภาพ
                                if (System.IO.File.Exists(Form_Login.item_path + @"\" + dt.Rows[i]["small_barcode"].ToString() + ".Png"))
                                {
                                    using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + dt.Rows[i]["small_barcode"].ToString() + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                    {
                                        picture = new Bitmap(bitmapFile);

                                    }
                                }
                                else
                                {
                                    picture = Ppos.Properties.Resources.picture_dark;
                                }

                                dataGridView_item.Rows.Add(
                               dt.Rows[i]["code"].ToString()!,
                               picture,
                               dt.Rows[i]["barcode"].ToString()!,
                               dt.Rows[i]["name"].ToString()!,
                               Convert.ToDouble(dt.Rows[i]["qty"]).ToString("#,##0.###")!,
                               dt.Rows[i]["unit"].ToString()!,
                               Convert.ToDouble(dt.Rows[i]["price"]).ToString("#,##0.##")!,
                               Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(40, 40))
                               );

                                // แสดงจำนวนบรรทัดสินค้า
                                dataGridView_item.Columns["picture"]!.HeaderText = dataGridView_item.RowCount.ToString() + "/" + set_item_total;
                                dataGridView_item.ClearSelection();
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
                textBox_search.Enabled = true;
                dataGridView_item.Enabled = true;
                textBox_search.Focus();
                timer_search.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Style.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // สีที่ต้องการตอนชี้

                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Style.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
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

                    textBox_search.Enabled = false;
                    dataGridView_item.Rows.Clear();
                    dataGridView_item.Enabled = false;
                    count_search = 0;

                    // แสดงจำนวนบรรทัดสินค้า
                    dataGridView_item.Columns["picture"]!.HeaderText = "0/" + set_item_total;
                    backgroundWorker_search.RunWorkerAsync();
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
                count_search = 0;
                if (!timer_search.Enabled)
                {
                    timer_search.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    if (e.ColumnIndex == dataGridView_item.Columns["select"]!.Index)
                    {
                        exit = false;
                        barcode = dataGridView_item.Rows[e.RowIndex].Cells["item_barcode"].Value!.ToString()!;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_item_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {


                    exit = false;
                    barcode = dataGridView_item.Rows[e.RowIndex].Cells["item_barcode"].Value!.ToString()!;
                    this.Close();

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

        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Escape)
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
