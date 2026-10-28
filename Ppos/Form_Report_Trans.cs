using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ppos
{
    public partial class Form_Report_Trans : Form
    {
        string set_item_total, set_small_barcode = "";
        string path_load;
        int set_search = 5, count_set_search = 0;
        DataTable dt_trans, dt;
        string sort = "desc";
        int Limit = 20, Limit_trans = 0; // จำนวนแสดงผล
        DateTime currentDate = DateTime.Now;
        BackgroundWorker worker;
        public Form_Report_Trans()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                dataGridView_trans.Columns["small_qty_begin"]!.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                dataGridView_trans.Columns["small_qty"]!.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                dataGridView_trans.Columns["small_qty_end"]!.DefaultCellStyle.BackColor = Color.FromArgb(160, 255, 160);
                // dataGridView_trans.Columns["small_unit"].DefaultCellStyle.BackColor = Color.FromArgb(228, 255, 228);
                dataGridView_trans.Columns["small_cost_begin"]!.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                dataGridView_trans.Columns["small_cost"]!.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                dataGridView_trans.Columns["small_cost_end"]!.DefaultCellStyle.BackColor = Color.FromArgb(160, 255, 160);
                dataGridView_trans.Columns["small_cost_total"]!.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);

                dataGridView_trans.Columns["fill"]!.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);

                dataGridView_trans.Columns["small_qty_begin"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_qty"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_qty_end"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_cost_begin"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_cost"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_cost_end"]!.HeaderCell.Style.ForeColor = Color.FromArgb(50, 50, 50);
                dataGridView_trans.Columns["small_cost_total"]!.HeaderCell.Style.ForeColor = Color.Black;

                dataGridView_trans.Columns["small_cost_total"]!.HeaderCell.Style.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);

                dataGridView_trans.Columns["small_qty_begin"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_qty"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_qty_end"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_cost_begin"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_cost"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_cost_end"]!.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["small_cost_total"]!.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);


                //  dataGridView_trans.Columns["small_qty_begin"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_qty"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_qty_end"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_unit"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_cost_begin"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_cost"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);
                //  dataGridView_trans.Columns["small_cost_end"].HeaderCell.Style.BackColor = Color.FromArgb(192, 255, 192);

                // dataGridView_trans.Columns["fill"].HeaderCell.Style.BackColor = Color.FromArgb(128,255,128);
                // dataGridView_trans.Columns["fill"].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);


                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);
                dataGridView_trans.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_trans, true, null);

                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn column in dataGridView_trans.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);
                new Class_TouchGrid(dataGridView_trans);

                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128,255,128);
                dataGridView_trans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128,255,128);
                dataGridView_item.EnableHeadersVisualStyles = false;
                dataGridView_trans.EnableHeadersVisualStyles = false;

                // เพิ่ม Code นี้ใน Constructor หรือ Form_Load เพื่อผูก Event
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);
                dataGridView_trans.MouseWheel += new MouseEventHandler(dataGridView_trans_MouseWheel!);

                pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;
                button_excel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(40, 40));

                button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(30, 40));

                label_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch
            {
                this.Close();
            }
        }
        // สรรหาฟังก์ชันจากภายนอกมาช่วยดึง Process ID ของหน้าต่าง Excel
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        // ฟังก์ชันควบคุมการเลื่อนเมื่อหมุน Mouse Wheel
        private void dataGridView_trans_MouseWheel(object sender, MouseEventArgs e)
        {
            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridView_trans.RowCount == 0) return;

            // ดึงค่าดัชนีแถวปัจจุบันที่แสดงอยู่บนสุด
            int currentIndex = dataGridView_trans.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 คือหมุนขึ้น (เลื่อนบรรทัดขึ้น), e.Delta < 0 คือหมุนลง (เลื่อนบรรทัดลง)
            int scrollLines = 1; // จำนวนแถวที่ต้องการให้เลื่อนต่อการหมุน 1 กริ๊ก
            int newIndex = currentIndex + (e.Delta > 0 ? -scrollLines : scrollLines);

            // ตรวจสอบไม่ให้ดัชนีหลุดขอบบนและขอบล่างของตาราง
            if (newIndex < 0)
            {
                newIndex = 0;
            }
            else if (newIndex >= dataGridView_trans.RowCount)
            {
                newIndex = dataGridView_trans.RowCount - 1;
            }

            // สั่งให้ตารางเลื่อนไปยังแถวที่คำนวณได้
            dataGridView_trans.FirstDisplayedScrollingRowIndex = newIndex;
        }
        // ฟังก์ชันควบคุมการเลื่อนเมื่อหมุน Mouse Wheel
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
        private void Form_Report_Trans_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // count item
                        cmd_sqlite.CommandText = "select count(code) from Item where status = 1";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // อ่านค่าจากคอลัมน์แรก (ดัชนี 0) มาใส่ใน Source
                                label_search.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }
                            set_item_total = label_search.Text;
                        }
                    }
                }
                search();
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
                if (!timer_search.Enabled)
                {
                    timer_search.Start();
                }
                count_set_search = 0;
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
                count_set_search++;
                if (count_set_search >= set_search)
                {
                    timer_search.Stop();
                    count_set_search = 0;
                    search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void search()
        {
            try
            {
                dataGridView_item.Rows.Clear();

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT small_barcode,code,group_main,group_sub,name " +
                                                 "from Item " +
                                                 "WHERE status = 1 ";
                        if (textBox_search.Text != "")
                        {
                            cmd_sqlite.CommandText += "and " +
                                                    "(name like '%" + textBox_search.Text + "%' or " +
                                                    "small_barcode like '%" + textBox_search.Text + "%' or " +
                                                    "medium_barcode like '%" + textBox_search.Text + "%' or " +
                                                    "large_barcode like '%" + textBox_search.Text + "%') "
                                                    ;
                        }
                        cmd_sqlite.CommandText += "order by code desc ";
                        if (Limit > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit;
                        }
                        var er = cmd_sqlite.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            bool selected = false;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView_item.Rows.Add(
                                   dt.Rows[i]["small_barcode"].ToString()!,
                                   dt.Rows[i]["code"].ToString()!,
                                   dt.Rows[i]["group_main"].ToString()!,
                                   dt.Rows[i]["group_sub"].ToString()!,
                                   dt.Rows[i]["name"].ToString()!
                                    );
                                if (dt.Rows[i]["small_barcode"].ToString() == set_small_barcode)
                                {
                                    selected = true;
                                    dataGridView_item.Rows[i].Selected = true;
                                }

                            }
                            if (!selected)
                            {
                                dataGridView_item.ClearSelection();
                            }

                        }
                    }
                    con_sqlite.Close();
                }
                // นับจำนวนค้นหา
                label_search.Text = set_item_total;
                if (dt.Rows.Count > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_item_total;
                }

                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString() != set_small_barcode)
                    {

                        dataGridView_item.Enabled = false;
                        dataGridView_trans.Rows.Clear();
                        set_small_barcode = dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString()!;
                        //////////// ค้นหาภาพ
                        if (System.IO.File.Exists(Form_Login.item_path + @"\" + dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString() + ".Png"))
                        {
                            using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString() + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                pictureBox_item.Image = new Bitmap(bitmapFile);

                            }
                        }
                        else
                        {
                            pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;
                        }

                        label_item_name.Text = dataGridView_item.Rows[e.RowIndex].Cells["name"].Value!.ToString();


                        search_trans();

                    }

                }

            }
            catch
            {
                dataGridView_item.Enabled = true;
            }
        }
        private void dataGridView_item_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button_sort_Click(object sender, EventArgs e)
        {
            try
            {
                if (set_small_barcode != string.Empty && dataGridView_trans.RowCount > 0)
                {
                    tableLayoutPanel_top.Enabled = false;
                    dataGridView_item.Enabled = false;
                    dataGridView_trans.Rows.Clear();
                    if (sort == "desc")
                    {
                        sort = "asc";
                        button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustDown, new Size(35, 45));
                    }
                    else
                    {
                        sort = "desc";
                        button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(35, 45));
                    }
                    search_trans();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sort_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (sort == "desc")
                {
                    button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(35, 45));
                }
                else
                {
                    button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustDown, new Size(35, 45));
                }
            }
            catch
            {

            }
        }

        private void button_sort_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (sort == "desc")
                {
                    button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(30, 40));
                }
                else
                {
                    button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustDown, new Size(30, 40));
                }
            }
            catch
            {

            }
        }
        private void backgroundWorker_report_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                worker = sender as BackgroundWorker;
                for (int i = 0; i < dt_trans.Rows.Count; i++)
                {
                    // ตรวจสอบว่าผู้ใช้กดปุ่ม Cancel หรือยังในทุกๆ รอบของลูป
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true; // บอกระบบว่างานนี้จบลงเพราะถูกยกเลิก
                        break;           // ออกจาก For Loop ทันที
                    }
                    dataGridView_trans.Rows.Add(
                       dt_trans.Rows[i]["date"].ToString()!,
                       dt_trans.Rows[i]["time"].ToString()!,
                       dt_trans.Rows[i]["trans_type"].ToString()!,
                       dt_trans.Rows[i]["trans_desc"].ToString()!,
                       dt_trans.Rows[i]["item_barcode"].ToString()!,
                       Convert.ToDouble(dt_trans.Rows[i]["item_qty"]).ToString("#,##0.00"),
                       dt_trans.Rows[i]["unit"].ToString()!,
                       Convert.ToDouble(dt_trans.Rows[i]["item_cost"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_qty_begin"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_qty"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_qty_end"]).ToString("#,##0.00"),
                       dt_trans.Rows[i]["small_unit"].ToString()!,
                       Convert.ToDouble(dt_trans.Rows[i]["small_cost_begin"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_cost"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_cost_end"]).ToString("#,##0.00"),
                       Convert.ToDouble(dt_trans.Rows[i]["small_cost_total"]).ToString("#,##0.00")
                        );
                    dataGridView_trans.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_report_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Class_Parameter.runbackground = false;
                dataGridView_trans.ScrollBars = ScrollBars.Both;
                dataGridView_item.Enabled = true;

                tableLayoutPanel_top.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void search_trans()
        {
            try
            {
                Class_Parameter.runbackground = true;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT STRFTIME('%d/%m/%Y',date(t.created_date)) as date , time(t.created_date) as time,
                                                   t.trans_type ,t.trans_desc ,t.item_barcode ,t.item_qty ,item_bar.unit,t.item_cost ,
                                                   t.small_qty_begin ,t.small_qty ,t.small_qty_end ,i.small_unit ,
                                                   t.small_cost_begin ,t.small_cost ,t.small_cost_end , t.small_qty_end * t.small_cost_end as small_cost_total 
                                                   from Transactions t 
                                                   join (SELECT i.small_barcode as barcode ,i.small_unit as unit from item i union all
                                                   SELECT i.medium_barcode ,i.medium_unit from item i where i.medium_barcode <> '' union all
                                                   SELECT i.large_barcode ,i.large_unit from item i where i.large_barcode <> '') item_bar on item_bar.barcode = t.item_barcode 
                                                   join item i on i.small_barcode = t.small_barcode 
                                                   where t.small_barcode = '" + set_small_barcode + "' and date(t.created_date) = '" + currentDate.ToString("yyyy-MM-dd") + "' " +
                                                   "order by t.id " + sort + " ";
                        if (Limit_trans > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit_trans;
                        }
                        var er = cmd_sqlite.ExecuteReader();
                        dt_trans = new DataTable();
                        dt_trans.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView_trans.Columns["trans_date"]!.HeaderText = "วันที่";
                            dataGridView_trans.Columns["trans_time"]!.HeaderText = "เวลา";
                            dataGridView_trans.Columns["item_barcode"]!.HeaderText = "บาร์โค้ด";
                            dataGridView_trans.Columns["item_qty"]!.HeaderText = "จำนวน";
                            dataGridView_trans.Columns["item_cost"]!.HeaderText = "ต้นทุน";

                            dataGridView_trans.Columns["small_qty_begin"]!.HeaderText = "เริ่มต้น";
                            dataGridView_trans.Columns["small_qty"]!.HeaderText = "จำนวน";
                            dataGridView_trans.Columns["small_qty_end"]!.HeaderText = "สุทธิ";

                            dataGridView_trans.Columns["small_cost_begin"]!.HeaderText = "เริ่มต้น";
                            dataGridView_trans.Columns["small_cost"]!.HeaderText = "ต้นทุน";
                            dataGridView_trans.Columns["small_cost_end"]!.HeaderText = "สุทธิ";

                            dataGridView_trans.Columns["small_cost_total"]!.HeaderText = "รวมต้นทุน";

                            button_excel.Visible = true;

                            dataGridView_trans.ScrollBars = ScrollBars.None;
                            backgroundWorker_report.RunWorkerAsync();
                        }
                        else
                        {
                            dataGridView_trans.Columns["trans_date"]!.HeaderText = "";
                            dataGridView_trans.Columns["trans_time"]!.HeaderText = "";
                            dataGridView_trans.Columns["item_barcode"]!.HeaderText = "";
                            dataGridView_trans.Columns["item_qty"]!.HeaderText = "";
                            dataGridView_trans.Columns["item_cost"]!.HeaderText = "";

                            dataGridView_trans.Columns["small_qty_begin"]!.HeaderText = "";
                            dataGridView_trans.Columns["small_qty"]!.HeaderText = "";
                            dataGridView_trans.Columns["small_qty_end"]!.HeaderText = "";

                            dataGridView_trans.Columns["small_cost_begin"]!.HeaderText = "";
                            dataGridView_trans.Columns["small_cost"]!.HeaderText = "";
                            dataGridView_trans.Columns["small_cost_end"]!.HeaderText = "";

                            dataGridView_trans.Columns["small_cost_total"]!.HeaderText = "";

                            button_excel.Visible = false;
                        }
                    }
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
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // สีที่ต้องการตอนชี้
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

                }
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
                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_trans_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    dataGridView_trans.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // สีที่ต้องการตอนชี้

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_trans_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_trans.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DimGray; // สีที่ต้องการตอนชี้

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_excel_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_trans.Focus();
                if (dataGridView_trans.RowCount > 0)
                {
                    using (SaveFileDialog saveFileDialoge = new SaveFileDialog())
                    {
                        saveFileDialoge.FileName = "รายงานเคลือนไหวสินค้า_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        saveFileDialoge.DefaultExt = ".Xlsx";
                        saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                        saveFileDialoge.Title = "บันทึกไฟล์สินค้า";


                        if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                        {
                            path_load = saveFileDialoge.FileName;
                            dataGridView_trans.Focus();

                            tableLayoutPanel_top.Enabled = false;

                            dataGridView_item.Enabled = false;

                            Class_Parameter.runbackground = true;

                            backgroundWorker_excel.RunWorkerAsync();
                        }
                    }
                }


            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_excel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                worker = sender as BackgroundWorker;
                // 2. ประกาศตัวแปร COM Objects
                Excel.Application App = new Excel.Application();
                Excel.Workbooks workbooks = App.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                uint excelProcessId = 0;
                GetWindowThreadProcessId((IntPtr)App.Hwnd, out excelProcessId);
                try
                {

                    worksheet.Name = "เคลื่อนไหวสินค้า";

                    worksheet.Columns[1].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;

                    worksheet.Cells[1, 1] = " วันที่ ";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[1, 2] = " เวลา ";
                    worksheet.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                    worksheet.Cells[1, 3] = " ประเภท ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[3].NumberFormat = "@";

                    worksheet.Cells[1, 4] = " รายละเอียด ";
                    worksheet.Cells[1, 4].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[4].NumberFormat = "@";

                    worksheet.Cells[1, 5] = " บาร์โค้ด ";
                    worksheet.Cells[1, 5].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[5].NumberFormat = "@";

                    worksheet.Cells[1, 6] = " จำนวน ";
                    worksheet.Cells[1, 6].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[6].NumberFormat = "General";

                    worksheet.Cells[1, 7] = " หน่วย ";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[7].NumberFormat = "@";

                    worksheet.Cells[1, 8] = " ต้นทุน ";
                    worksheet.Cells[1, 8].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[8].NumberFormat = "General";

                    worksheet.Cells[1, 9] = " เริ่มต้น ";
                    worksheet.Cells[1, 9].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[9].NumberFormat = "General";

                    worksheet.Cells[1, 10] = " จำนวน ";
                    worksheet.Cells[1, 10].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[10].NumberFormat = "General";

                    worksheet.Cells[1, 11] = " สุทธิ ";
                    worksheet.Cells[1, 11].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[11].NumberFormat = "General";

                    worksheet.Cells[1, 12] = " หน่วย ";
                    worksheet.Cells[1, 12].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[12].NumberFormat = "@";

                    worksheet.Cells[1, 13] = " เริ่มต้น ";
                    worksheet.Cells[1, 13].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[13].NumberFormat = "General";

                    worksheet.Cells[1, 14] = " ต้นทุน ";
                    worksheet.Cells[1, 14].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[14].NumberFormat = "General";

                    worksheet.Cells[1, 15] = " สุทธิ ";
                    worksheet.Cells[1, 15].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[15].NumberFormat = "General";

                    worksheet.Cells[1, 16] = " รวมต้นทุน ";
                    worksheet.Cells[1, 16].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[16].NumberFormat = "General";

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 16]];
                    rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    // เริ่มใส่ข้อมูล
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT STRFTIME('%d/%m/%Y',date(t.created_date)) as date , time(t.created_date) as time,
                                                   t.trans_type ,t.trans_desc ,t.item_barcode ,t.item_qty ,item_bar.unit,t.item_cost ,
                                                   t.small_qty_begin ,t.small_qty ,t.small_qty_end ,i.small_unit ,
                                                   t.small_cost_begin ,t.small_cost ,t.small_cost_end , t.small_qty_end * t.small_cost_end as small_cost_total 
                                                   from Transactions t 
                                                   join (SELECT i.small_barcode as barcode ,i.small_unit as unit from item i union all
                                                   SELECT i.medium_barcode ,i.medium_unit from item i where i.medium_barcode <> '' union all
                                                   SELECT i.large_barcode ,i.large_unit from item i where i.large_barcode <> '') item_bar on item_bar.barcode = t.item_barcode 
                                                   join item i on i.small_barcode = t.small_barcode 
                                                   where t.small_barcode = '" + dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["small_barcode"].Value!.ToString() + "' and date(t.created_date) = '" + currentDate.ToString("yyyy-MM-dd") + "' " +
                                                   "order by t.id " + sort;

                            var er = cmd_sqlite.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(er);

                            if (dt.Rows.Count > 0)
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    // ตรวจสอบว่าผู้ใช้กดปุ่ม Cancel หรือยังในทุกๆ รอบของลูป
                                    if (worker.CancellationPending)
                                    {
                                        e.Cancel = true; // บอกระบบว่างานนี้จบลงเพราะถูกยกเลิก
                                        break;           // ออกจาก For Loop ทันที
                                    }
                                    worksheet.Cells[i + 2, 1] = dt.Rows[i]["date"].ToString();
                                    worksheet.Cells[i + 2, 2] = dt.Rows[i]["time"].ToString();
                                    worksheet.Cells[i + 2, 3] = dt.Rows[i]["trans_type"].ToString();
                                    worksheet.Cells[i + 2, 4] = dt.Rows[i]["trans_desc"].ToString();
                                    worksheet.Cells[i + 2, 5] = dt.Rows[i]["item_barcode"].ToString();
                                    worksheet.Cells[i + 2, 6] = dt.Rows[i]["item_qty"].ToString();
                                    worksheet.Cells[i + 2, 7] = dt.Rows[i]["unit"].ToString();
                                    worksheet.Cells[i + 2, 8] = dt.Rows[i]["item_cost"].ToString();
                                    worksheet.Cells[i + 2, 9] = dt.Rows[i]["small_qty_begin"].ToString();
                                    worksheet.Cells[i + 2, 10] = dt.Rows[i]["small_qty"].ToString();
                                    worksheet.Cells[i + 2, 11] = dt.Rows[i]["small_qty_end"].ToString();
                                    worksheet.Cells[i + 2, 12] = dt.Rows[i]["small_unit"].ToString();
                                    worksheet.Cells[i + 2, 13] = dt.Rows[i]["small_cost_begin"].ToString();
                                    worksheet.Cells[i + 2, 14] = dt.Rows[i]["small_cost"].ToString();
                                    worksheet.Cells[i + 2, 15] = dt.Rows[i]["small_cost_end"].ToString();
                                    worksheet.Cells[i + 2, 16] = dt.Rows[i]["small_cost_total"].ToString();

                                    button_excel.Text = ((i + 1) * 100 / dt.Rows.Count).ToString("0.00") + " %";
                                }
                            }
                        }
                    }
                    worksheet.Columns.AutoFit();

                    // 4. บันทึกไฟล์ไปยัง Path ที่ผู้ใช้เลือกจาก Dialog
                    // ลบไฟล์เก่าทิ้งก่อน (ถ้ามีชื่อซ้ำและต้องการเซฟทับโดยไม่ให้ Excel ถามแจ้งเตือน)
                    App.DisplayAlerts = false;
                    App.Visible = false; // ซ่อนหน้าต่าง Excel ไว้เบื้องหลังขณะทำงาน

                    workbook.SaveAs(path_load);

                }
                finally
                {

                    // ปิดแบบนุ่มนวลก่อน
                    try { App.Quit(); } catch { }

                    // สั่งจัดการขั้นเด็ดขาดดึง Process เจาะจงตัวนี้มาสั่งปิดทันที [2]
                    if (excelProcessId != 0)
                    {
                        try
                        {
                            Process excelProcess = Process.GetProcessById((int)excelProcessId);
                            if (excelProcess != null && !excelProcess.HasExited)
                            {
                                excelProcess.Kill(); // ตัดจบกระบวนการทันที ไม่เหลือค้างแน่นอน [2]
                            }
                        }
                        catch { /* หากกระบวนการปิดไปแล้ว จะข้ามส่วนนี้อัตโนมัติ */}
                    }
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
            }
        }

        private void backgroundWorker_excel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show(path_load, "ดาวน์โหลดไฟล์ เรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button_excel.Text = "โหลด";

                tableLayoutPanel_top.Enabled = true;

                textBox_search.Enabled = true;

                dataGridView_item.Enabled = true;

                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_excel_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                button_excel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(50, 50));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_excel_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                button_excel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(40, 40));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_back_date_Click(object sender, EventArgs e)
        {
            try
            {

                currentDate = currentDate.AddDays(-1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (label_item_name.Text != string.Empty)
                {
                    tableLayoutPanel_top.Enabled = false;
                    dataGridView_trans.Rows.Clear();
                    search_trans();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_next_date_Click(object sender, EventArgs e)
        {
            try
            {
                currentDate = currentDate.AddDays(1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (label_item_name.Text != string.Empty)
                {
                    tableLayoutPanel_top.Enabled = false;
                    dataGridView_trans.Rows.Clear();
                    search_trans();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_date_Click(object sender, EventArgs e)
        {
            try
            {


                Class_Parameter.calendar_title = "วันที่";

                Class_Parameter.calendar_day = label_date.Text.Split("/")[0];
                Class_Parameter.calendar_month = label_date.Text.Split("/")[1];
                Class_Parameter.calendar_year = label_date.Text.Split("/")[2];


                Form_Calendar form_Calendar = new Form_Calendar();
                form_Calendar.ShowDialog(this);

                if (!form_Calendar.cancel)
                {
                    DateTime date;
                    label_date.Text = form_Calendar.label_set_days.Text.Replace("-", "/");
                    bool isValid = DateTime.TryParseExact(label_date.Text,
                                          "dd/MM/yyyy",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          out date);
                    if (isValid)
                    {
                        currentDate = date;
                    }

                    if (label_item_name.Text != string.Empty)
                    {
                        tableLayoutPanel_top.Enabled = false;
                        dataGridView_trans.Rows.Clear();
                        search_trans();
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_date_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;

                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size + 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void label_date_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;

                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void Form_Report_Trans_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 1. ตรวจสอบว่า BackgroundWorker กำลังทำงานอยู่หรือไม่
                if (backgroundWorker_report.IsBusy)
                {
                    // 2. ส่งสัญญาณสั่งยกเลิกลูป (ทำงานร่วมกับ CancellationPending ใน DoWork)
                    backgroundWorker_report.CancelAsync();

                    // 3. เพื่อความปลอดภัยสูงสุด: วนลูปสั้นๆ รอให้ Thread ปิดตัวเองลงจริงๆ
                    // (ป้องกันไม่ให้ฟอร์มปิดตัวไปก่อนที่ Thread จะจัดการล้างข้อมูลเสร็จ)
                    while (backgroundWorker_report.IsBusy)
                    {
                        // ป้องกัน UI ค้างระหว่างรอ Thread ปิดตัว
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                // 1. ตรวจสอบว่า BackgroundWorker กำลังทำงานอยู่หรือไม่
                if (backgroundWorker_excel.IsBusy)
                {
                    // 2. ส่งสัญญาณสั่งยกเลิกลูป (ทำงานร่วมกับ CancellationPending ใน DoWork)
                    backgroundWorker_excel.CancelAsync();

                    // 3. เพื่อความปลอดภัยสูงสุด: วนลูปสั้นๆ รอให้ Thread ปิดตัวเองลงจริงๆ
                    // (ป้องกันไม่ให้ฟอร์มปิดตัวไปก่อนที่ Thread จะจัดการล้างข้อมูลเสร็จ)
                    while (backgroundWorker_excel.IsBusy)
                    {
                        // ป้องกัน UI ค้างระหว่างรอ Thread ปิดตัว
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
