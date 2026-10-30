using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Ppos
{
    public partial class Form_Point_Trans : Form
    {
        string set_member_total;
        string path_load;
        string sort = "desc";
        int Limit = 20, Limit_trans = 0; // จำนวนแสดงผล
        string set_id = "";
        int set_search_member = 5, count_set_search_member = 0;
        System.Data.DataTable dt, dt_trans;
        DateTime currentDate = DateTime.Now;
        BackgroundWorker worker;
        public Form_Point_Trans()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                Class_DoubleBuffer.EnableDoubleBuffering(tableLayoutPanel_back);

                dataGridView_member.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_member, true, null);

                foreach (DataGridViewColumn column in dataGridView_member.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_member);

                dataGridView_member.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                dataGridView_member.EnableHeadersVisualStyles = false;

                dataGridView_trans.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_member, true, null);

                foreach (DataGridViewColumn column in dataGridView_trans.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_trans);

                dataGridView_trans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                dataGridView_trans.EnableHeadersVisualStyles = false;

                button_excel.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Excel, new Size(40, 40));

                button_sort.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(30, 40));

                label_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
                                label_search.Text = Convert.ToInt32(reader[0].ToString()).ToString("#,##0");
                            }
                            set_member_total = label_search.Text;
                        }
                    }
                }
                dataGridView_trans.Columns["point_begin"]!.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                dataGridView_trans.Columns["point_begin"]!.HeaderCell.Style.ForeColor = Color.Black;
                dataGridView_trans.Columns["point_begin"]!.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["point_begin"]!.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);

                dataGridView_trans.Columns["point_inc_dec"]!.DefaultCellStyle.BackColor = Color.FromArgb(160, 255, 160);
                dataGridView_trans.Columns["point_inc_dec"]!.HeaderCell.Style.ForeColor = Color.Black;
                dataGridView_trans.Columns["point_inc_dec"]!.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["point_inc_dec"]!.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);

                dataGridView_trans.Columns["point_end"]!.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                dataGridView_trans.Columns["point_end"]!.HeaderCell.Style.ForeColor = Color.Black;
                dataGridView_trans.Columns["point_end"]!.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
                dataGridView_trans.Columns["point_end"]!.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);

                search_member();
            }
            catch
            {
                this.Close();
            }

        }

        private void Form_Point_Trans_Load(object sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void search_member()
        {
            try
            {
                dataGridView_member.Rows.Clear();

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "select id,phone,sex,nick_name,first_name,last_name,address,sub_district,district,province,postal_code,discount_percent,sale_total,sale_ineffective_member,sale_effective_member,sale_per_point,point_increase,point_decrease,point_balance,status " +
                                                 "from Member " +
                                                 "where status = true ";
                        if (textBox_search.Text != "")
                        {
                            cmd_sqlite.CommandText += "and ( phone like '%" + textBox_search.Text + "%' or " +
                                                             "nick_name like '%" + textBox_search.Text + "%' or " +
                                                             "first_name like '%" + textBox_search.Text + "%' or " +
                                                             "last_name like '%" + textBox_search.Text + "%' ) ";
                        }
                        cmd_sqlite.CommandText += "order by id desc ";
                        if (Limit > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit;
                        }


                        var er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);

                        if (dt.Rows.Count > 0)
                        {
                            bool selected = false;

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                dataGridView_member.Rows.Add(
                                     dt.Rows[i]["id"].ToString()!,
                                     dt.Rows[i]["phone"].ToString()!,
                                     dt.Rows[i]["sex"].ToString()!,
                                     dt.Rows[i]["nick_name"].ToString()!,
                                     dt.Rows[i]["first_name"].ToString()!,
                                     dt.Rows[i]["last_name"].ToString()!,
                                     dt.Rows[i]["address"].ToString()!,
                                     dt.Rows[i]["sub_district"].ToString()!,
                                     dt.Rows[i]["district"].ToString()!,
                                     dt.Rows[i]["province"].ToString()!,
                                     dt.Rows[i]["postal_code"].ToString()!,
                                     dt.Rows[i]["discount_percent"].ToString()!,
                                     dt.Rows[i]["sale_total"].ToString()!,
                                     dt.Rows[i]["sale_ineffective_member"].ToString()!,
                                     dt.Rows[i]["sale_effective_member"].ToString()!,
                                     dt.Rows[i]["sale_per_point"].ToString()!,
                                     dt.Rows[i]["point_increase"].ToString()!,
                                     dt.Rows[i]["point_decrease"].ToString()!,
                                     dt.Rows[i]["point_balance"].ToString()!);
                                // ถ้าเป็นข้อมูลที่เลือกไว้ จะ select ให้
                                if (dt.Rows[i]["id"].ToString() == set_id)
                                {
                                    selected = true;
                                    dataGridView_member.Rows[i].Selected = true;
                                    dataGridView_member.CurrentCell = dataGridView_member.Rows[i].Cells["phone"];
                                }
                            }
                            // ถ้าไม่มีข้อมูลเดิมจะไม่เลือก
                            if (!selected)
                            {
                                dataGridView_member.ClearSelection();
                            }

                        }
                    }
                }
                // นับจำนวนค้นหา
                label_search.Text = set_member_total;
                if (dataGridView_member.RowCount > 0)
                {
                    label_search.Text = dt.Rows.Count.ToString("#,##0") + " / " + set_member_total;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_search_member_Tick(object sender, EventArgs e)
        {
            try
            {
                count_set_search_member++;
                if (count_set_search_member >= set_search_member)
                {
                    timer_search_member.Stop();
                    count_set_search_member = 0;
                    search_member();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_member.Stop();
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!timer_search_member.Enabled)
                {
                    timer_search_member.Start();
                }
                count_set_search_member = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer_search_member.Stop();
            }
        }

        private void textBox_search_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch
            {

            }
        }

        private void dataGridView_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    // ป้องการกดซ้ำ
                    if (dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString() != set_id)
                    {
                        tableLayoutPanel_top.Enabled = false;
                        tableLayoutPanel_top.Enabled = false;
                        dataGridView_member.Enabled = false;
                        dataGridView_trans.Rows.Clear();

                        label_member_name.Text = dataGridView_member.Rows[e.RowIndex].Cells["first_name"].Value!.ToString() + " " +
                                           dataGridView_member.Rows[e.RowIndex].Cells["last_name"].Value!.ToString() + " (" +
                                           dataGridView_member.Rows[e.RowIndex].Cells["nick_name"].Value!.ToString() + ")";

                        set_id = dataGridView_member.Rows[e.RowIndex].Cells["id"].Value!.ToString()!;

                        search_trans();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_sort_Click(object sender, EventArgs e)
        {
            try
            {
                if (set_id != string.Empty && dataGridView_trans.RowCount > 0)
                {
                    tableLayoutPanel_top.Enabled = false;
                    dataGridView_member.Enabled = false;
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

        private void search_trans()
        {
            try
            {
                Class_Parameter.runbackground = true;
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT STRFTIME('%d/%m/%Y',date(created_date)) as date , 
                                                 time(created_date) as time, 
                                                 id_member, 
                                                 trans_type, 
                                                 trans_desc, 
                                                 sale_per_point, 
                                                 point_begin, 
                                                 case when point_increase > 0 then point_increase  else point_decrease *-1 end as point_inc_dec ,
                                                 point_end
                                                 FROM Member_Point_Balance
                                                   WHERE id_member= " + set_id + " " +
                                                   " and date(created_date) = '" + currentDate.ToString("yyyy-MM-dd") + "' " +
                                                   "order by id " + sort + " ";
                        if (Limit_trans > 0)
                        {
                            cmd_sqlite.CommandText += "limit " + Limit_trans;
                        }
                        var er = cmd_sqlite.ExecuteReader();
                        dt_trans = new System.Data.DataTable();
                        dt_trans.Load(er);

                        if (dt_trans.Rows.Count > 0)
                        {
                            button_excel.Visible = true;
                            dataGridView_trans.ScrollBars = System.Windows.Forms.ScrollBars.None;
                            backgroundWorker_point.RunWorkerAsync();

                        }
                        else
                        {
                            button_excel.Visible = false;
                            tableLayoutPanel_top.Enabled = true;
                            dataGridView_member.Enabled = true;
                            Class_Parameter.runbackground = false;
                        }

                    }
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

        private void button_back_date_Click(object sender, EventArgs e)
        {
            try
            {

                currentDate = currentDate.AddDays(-1); // บวกเพิ่ม 1 วัน
                label_date.Text = currentDate.ToString("dd/MM/yyyy");
                if (label_member_name.Text != string.Empty)
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
                if (label_member_name.Text != string.Empty)
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

                    if (label_member_name.Text != string.Empty)
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
        private void label_MouseEnter(object sender, EventArgs e)
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

        private void label_MouseLeave(object sender, EventArgs e)
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

        private void backgroundWorker_point_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < dt_trans.Rows.Count; i++)
                {
                    dataGridView_trans.Rows.Add(
                        "",
                   dt_trans.Rows[i]["date"].ToString()!,
                   dt_trans.Rows[i]["time"].ToString()!,
                   dt_trans.Rows[i]["trans_type"].ToString()!,
                   dt_trans.Rows[i]["trans_desc"].ToString()!,
                   dt_trans.Rows[i]["sale_per_point"].ToString()!,
                   Convert.ToDouble(dt_trans.Rows[i]["point_begin"]).ToString("#,##0")!,
                   Convert.ToDouble(dt_trans.Rows[i]["point_inc_dec"]).ToString("#,##0")!,
                   Convert.ToDouble(dt_trans.Rows[i]["point_end"]).ToString("#,##0")!,
                   ""
                   );
                    dataGridView_trans.ClearSelection();
                }
            }
            catch
            {

            }
        }

        private void backgroundWorker_point_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                tableLayoutPanel_top.Enabled = true;
                dataGridView_member.Enabled = true;
                dataGridView_trans.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                Class_Parameter.runbackground = false;
            }
            catch
            {

            }
        }
        private void dataGridView_member_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // สีที่ต้องการตอนชี้
                    dataGridView_member.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้

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
                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    dataGridView_member.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้

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
                        saveFileDialoge.FileName = "เคลือนไหวแต้ม_" +
                            dataGridView_member.Rows[dataGridView_member.CurrentRow!.Index].Cells["phone"].Value!.ToString() +"_"+
                            DateTime.Now.ToString("ddMMyyyy_HHmmss");
                        saveFileDialoge.DefaultExt = ".Xlsx";
                        saveFileDialoge.Filter = "Xlsx|*.Xlsx";
                        saveFileDialoge.Title = "บันทึกไฟล์สินค้า";


                        if (saveFileDialoge.ShowDialog(this) == DialogResult.OK)
                        {
                            path_load = saveFileDialoge.FileName;
                            dataGridView_trans.Focus();

                            tableLayoutPanel_top.Enabled = false;

                            dataGridView_member.Enabled = false;

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
        // สรรหาฟังก์ชันจากภายนอกมาช่วยดึง Process ID ของหน้าต่าง Excel
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
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

                    worksheet.Name = dataGridView_member.Rows[dataGridView_member.CurrentRow!.Index].Cells["phone"].Value!.ToString();

                    worksheet.Columns[1].ColumnWidth = 30;

                    worksheet.Rows[1].Font.Size = 14;
                    worksheet.Rows[1].Font.Bold = true;

                    worksheet.Cells[1, 1] = " วันที่ ";
                    worksheet.Cells[1, 1].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[1].NumberFormat = "@";

                    worksheet.Cells[1, 2] = " เวลา ";
                    worksheet.Cells[1, 2].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[2].NumberFormat = "@";

                  //  worksheet.Cells[1, 3] = "  ";
                    worksheet.Cells[1, 3].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[3].NumberFormat = "@";

                   // worksheet.Cells[1, 4] = " รายละเอียด ";
                    worksheet.Cells[1, 4].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[4].NumberFormat = "@";

                    worksheet.Cells[1, 5] = " แต้มเริ่มต้น ";
                    worksheet.Cells[1, 5].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[5].NumberFormat = "General";

                    worksheet.Cells[1, 6] = " ปรับแต้ม ";
                    worksheet.Cells[1, 6].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[6].NumberFormat = "General";

                    worksheet.Cells[1, 7] = " แต้มคงเหลือ ";
                    worksheet.Cells[1, 7].Interior.Color = ColorTranslator.ToOle(Color.Silver);
                    worksheet.Columns[7].NumberFormat = "General";

                   

                    worksheet.Activate();
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;

                    // สร้างเส้น                
                    Excel.Range rangeAllBorders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]];
                    rangeAllBorders.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rangeAllBorders.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rangeAllBorders.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    // เริ่มใส่ข้อมูล
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT STRFTIME('%d/%m/%Y',date(created_date)) as date , 
                                                 time(created_date) as time, 
                                                 id_member, 
                                                 trans_type, 
                                                 trans_desc, 
                                                 sale_per_point, 
                                                 point_begin, 
                                                 case when point_increase > 0 then point_increase  else point_decrease *-1 end as point_inc_dec ,
                                                 point_end
                                                 FROM Member_Point_Balance
                                                   WHERE id_member= " + set_id + " " +
                                                   "order by id " + sort + " ";

                            var er = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
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
                                    worksheet.Cells[i + 2, 5] = dt.Rows[i]["point_begin"].ToString();
                                    worksheet.Cells[i + 2, 6] = dt.Rows[i]["point_inc_dec"].ToString();
                                    worksheet.Cells[i + 2, 7] = dt.Rows[i]["point_end"].ToString();
                                   

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

                dataGridView_member.Enabled = true;

                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Point_Trans_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // 1. ตรวจสอบว่า BackgroundWorker กำลังทำงานอยู่หรือไม่
                if (backgroundWorker_point.IsBusy)
                {
                    // 2. ส่งสัญญาณสั่งยกเลิกลูป (ทำงานร่วมกับ CancellationPending ใน DoWork)
                    backgroundWorker_point.CancelAsync();

                    // 3. เพื่อความปลอดภัยสูงสุด: วนลูปสั้นๆ รอให้ Thread ปิดตัวเองลงจริงๆ
                    // (ป้องกันไม่ให้ฟอร์มปิดตัวไปก่อนที่ Thread จะจัดการล้างข้อมูลเสร็จ)
                    while (backgroundWorker_point.IsBusy)
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
