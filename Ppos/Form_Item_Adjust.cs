using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Item_Adjust : Form
    {
        public static string item_barcode, item_name, item_unit, item_cost_last, item_cost_avg;
        DataTable dt;
        int Limit = 20;
        int set_search = 5, count_set_search = 0;
        string set_item_total, set_qty_small, set_cost_avg, set_cost_last, set_size;
        int shows = 0;
        public Form_Item_Adjust()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;
                customGroupBox.Location = new Point(
                 (panel_detail.Width / 2) - (customGroupBox.Width / 2),
                 10);
                Class_DoubleBuffer.EnableDoubleBuffering(tableLayoutPanel_back);
                if (!Class_Parameter.custom_cost_adjust)
                {
                    // tableLayoutPanel_group.Visible = false;
                    tableLayoutPanel_back_cost.Visible = false;
                    tableLayoutPanel_button_adjust.Visible = false;
                    tableLayoutPanel_per_unit.Visible = false;

                    customGroupBox.Height -= //tableLayoutPanel_group.Height +
                                             tableLayoutPanel_back_cost.Height +
                                             tableLayoutPanel_button_adjust.Height +
                                             tableLayoutPanel_per_unit.Height
                                             ;
                }



                dataGridView_item.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_item, true, null);

                foreach (DataGridViewColumn column in dataGridView_item.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_item);

                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128,255,128);
                dataGridView_item.EnableHeadersVisualStyles = false;

                // เพิ่ม Code นี้ใน Constructor หรือ Form_Load เพื่อผูก Event
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);

                button_increase.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustUp, new Size(40, 40));
                button_decrease.Image = Class_Image.resizeImage(Ppos.Properties.Resources.adjustDown, new Size(40, 40));
                button_custom.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(50, 50));

                pictureBox_item.Image = Ppos.Properties.Resources.picture_dark;

                // button_cost_avg.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(30, 30));
                // button_cost_last.Image = Class_Image.resizeImage(Ppos.Properties.Resources.last_cost, new Size(35, 30));
                // button_cost_custom.Image = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(30, 30));

                button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(50, 50));

                /////////
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // count item
                        cmd_sqlite.CommandText = "SELECT COUNT(small_barcode)+" +
                            "COUNT(case when medium_barcode <> '' then medium_barcode end)+ " +
                            "COUNT(case when large_barcode <> '' then large_barcode end) " +
                            "from Item WHERE status = 1 ";
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


                if (Class_Parameter.inc_dec_custom == 1)
                {
                    increaseActive();
                    if (Class_Parameter.last_avg_custom == 1)
                    {
                        costLast();
                        Class_Parameter.cost_per_unit = true;
                        cost_per_unit();
                    }
                    else if (Class_Parameter.last_avg_custom == 2)
                    {
                        costAVG();
                        Class_Parameter.cost_per_unit = true;
                        cost_per_unit();
                    }
                    else if (Class_Parameter.last_avg_custom == 3)
                    {
                        costCustom();
                        // ถ้ากำหนด จะเลือก ต่อหน่วยหรือทั้งหมดได้
                        if (Class_Parameter.cost_per_unit) // ทุนต่อหน่วย
                        {
                            cost_per_unit();
                        }
                        else // ทุนทั้งหมด
                        {
                            cost_all();
                        }
                    }
                }
                else if (Class_Parameter.inc_dec_custom == 2)
                {
                    decreaseActive();
                    Class_Parameter.last_avg_custom = 2;
                    costAVG();
                    Class_Parameter.cost_per_unit = true;
                    cost_per_unit();
                }
                else if (Class_Parameter.inc_dec_custom == 3)
                {
                    customActive();
                    Class_Parameter.last_avg_custom = 2;
                    costAVG();
                    Class_Parameter.cost_per_unit = true;
                    cost_per_unit();
                }

               
            }
            catch
            {
                this.Close();
            }

        }
        private void Form_Item_Adjust_Load(object sender, EventArgs e)
        {
            try
            {
                search();
                timer_show.Start();            

            }
            catch
            {

            }
        }
        private void timer_show_Tick(object sender, EventArgs e)
        {
            try
            {
                shows++;

                 if (shows == 1)
                {
                    tableLayoutPanel_group.Visible = true;

                }
                else if(shows == 2)
                {
                    tableLayoutPanel_item_detail.Visible = true;

                    if (!Class_Parameter.custom_cost_adjust)
                    {
                        textBox_search.Focus();
                        timer_show.Stop();
                    }
                }
                else if(shows == 3)
                {
                   
                    tableLayoutPanel_back_cost.Visible = true;
                    textBox_search.Focus();
                    timer_show.Stop();
                }
               
            }
            catch
            {
                timer_show.Stop();
            }
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
                MessageBox.Show(ex.Message);
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
                        cmd_sqlite.CommandText = script();
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
                                   dt.Rows[i]["name"].ToString()!,
                                   dt.Rows[i]["barcode"].ToString()!,
                                   Convert.ToDouble(dt.Rows[i]["qty"]).ToString("#,##0.###"),
                                   dt.Rows[i]["unit"].ToString()!,
                                   dt.Rows[i]["price"].ToString()!,
                                   dt.Rows[i]["cost_last"].ToString()!,
                                   dt.Rows[i]["cost_avg"].ToString()!,
                                   dt.Rows[i]["qty_small"].ToString()!,
                                   dt.Rows[i]["size"].ToString()!
                                    );
                                // ถ้าเป็นข้อมูลที่เลือกไว้ จะ select ให้
                                if (dt.Rows[i]["barcode"].ToString() == textBox_barcode.Text && textBox_barcode.Text != string.Empty)
                                {
                                    selected = true;
                                    dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(4, i, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                                }

                            }
                            // ถ้าไม่มีข้อมูลเดิมจะไม่เลือก
                            if (!selected)
                            {
                                dataGridView_item.ClearSelection();

                                if (dt.Rows.Count == 1) // มีรายการเดียว ทำการ กด
                                {
                                    dataGridView_item_CellMouseDown(dataGridView_item, new DataGridViewCellMouseEventArgs(4, 0, 0, 0, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0)));

                                }
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

                    if (dt.Rows.Count > 1)
                    {
                        textBox_search.Focus();
                        // textBox_search.SelectAll();
                    }
                    else
                    {
                        textBox_qty.Focus();
                    }
                }



            }
            catch
            {

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
            catch
            {

            }
        }

        private void button_type_adjust_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_barcode.Text == string.Empty)
                {
                    return;
                }
                Button button = (Button)sender;
                if (button.Name == "button_increase")
                {
                    if (Class_Parameter.inc_dec_custom != 1)
                    {
                        Class_Parameter.inc_dec_custom = 1;

                        increaseActive();
                        if (Class_Parameter.last_avg_custom == 1)
                        {
                            costLast();
                            Class_Parameter.cost_per_unit = true;
                            cost_per_unit();
                        }
                        else if (Class_Parameter.last_avg_custom == 2)
                        {
                            costAVG();
                            Class_Parameter.cost_per_unit = true;
                            cost_per_unit();
                        }
                        else if (Class_Parameter.last_avg_custom == 3)
                        {
                            costCustom();
                            // ถ้ากำหนด จะเลือก ต่อหน่วยหรือทั้งหมดได้
                            if (Class_Parameter.cost_per_unit) // ทุนต่อหน่วย
                            {
                                cost_per_unit();
                            }
                            else // ทุนทั้งหมด
                            {
                                cost_all();
                            }
                        }
                    }
                }
                else if (button.Name == "button_decrease")
                {
                    if (Class_Parameter.inc_dec_custom != 2)
                    {
                        Class_Parameter.inc_dec_custom = 2;

                        decreaseActive();

                        Class_Parameter.last_avg_custom = 2;
                        costAVG();
                        Class_Parameter.cost_per_unit = true;
                        cost_per_unit();
                    }
                }
                else if (button.Name == "button_custom")
                {
                    if (Class_Parameter.inc_dec_custom != 3)
                    {
                        Class_Parameter.inc_dec_custom = 3;

                        customActive();

                        Class_Parameter.last_avg_custom = 2;
                        costAVG();
                        Class_Parameter.cost_per_unit = true;
                        cost_per_unit();
                    }
                }
                textBox_qty.Focus();
            }
            catch
            {

            }
        }
        private void increaseActive()
        {
            try
            {
                // ปรับสีปุ่ม
                button_increase.FlatStyle = FlatStyle.Standard;
                button_increase.BackColor = Color.FromArgb(192, 255, 192);
                button_increase.ForeColor = Color.Black;


                button_decrease.FlatStyle = FlatStyle.Flat;
                button_decrease.BackColor = Color.FromArgb(128,255,128);
                button_decrease.ForeColor = Color.Gray;

                button_custom.FlatStyle = FlatStyle.Flat;
                button_custom.BackColor = Color.FromArgb(128,255,128);
                button_custom.ForeColor = Color.Gray;


                label_type_adjust.Text = button_increase.Text + " :";


            }
            catch
            {

            }
        }
        private void decreaseActive()
        {
            try
            {
                // ปรับสีปุ่ม
                button_increase.FlatStyle = FlatStyle.Flat;
                button_increase.BackColor = Color.FromArgb(128,255,128);
                button_increase.ForeColor = Color.Gray;

                button_decrease.FlatStyle = FlatStyle.Standard;
                button_decrease.BackColor = Color.FromArgb(192, 255, 192);
                button_decrease.ForeColor = Color.Black;

                button_custom.FlatStyle = FlatStyle.Flat;
                button_custom.BackColor = Color.FromArgb(128,255,128);
                button_custom.ForeColor = Color.Gray;


                label_type_adjust.Text = button_decrease.Text + " :";


            }
            catch
            {

            }
        }
        private void customActive()
        {
            try
            {
                // ปรับสีปุ่ม
                button_increase.FlatStyle = FlatStyle.Flat;
                button_increase.BackColor = Color.FromArgb(128,255,128);
                button_increase.ForeColor = Color.Gray;

                button_decrease.FlatStyle = FlatStyle.Flat;
                button_decrease.BackColor = Color.FromArgb(128,255,128);
                button_decrease.ForeColor = Color.Gray;

                button_custom.FlatStyle = FlatStyle.Standard;
                button_custom.BackColor = Color.FromArgb(192, 255, 192);
                button_custom.ForeColor = Color.Black;


                label_type_adjust.Text = button_custom.Text + " :";


            }
            catch
            {

            }
        }

        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมาส์ชี้อยู่ในแถวที่มีข้อมูล (ไม่ใช่แถวหัวคอลัมน์ Index -1)
                if (e.RowIndex >= 0)
                {
                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230); // สีที่ต้องการตอนชี้
                    dataGridView_item.Rows[e.RowIndex].Cells["name"].Style.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold); // สีที่ต้องการตอนชี้
                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(128,255,128); // สีที่ต้องการตอนชี้

                }
            }
            catch
            { }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // สีที่ต้องการตอนไม่ชี้
                    dataGridView_item.Rows[e.RowIndex].Cells["name"].Style.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular); // สีที่ต้องการตอนชี้
                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // สีที่ต้องการตอนชี้


                }
            }
            catch
            { }
        }

        private void dataGridView_item_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    textBox_qty.Text = string.Empty;
                    textBox_cost.Text = string.Empty;

                    dataGridView_item.Rows[e.RowIndex].Selected = true;
                    dataGridView_item.CurrentCell = dataGridView_item.Rows[e.RowIndex].Cells["name"];
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

                    textBox_group_main.Text = dataGridView_item.Rows[e.RowIndex].Cells["group_main"].Value!.ToString();
                    textBox_group_sub.Text = dataGridView_item.Rows[e.RowIndex].Cells["group_sub"].Value!.ToString();
                    textBox_name.Text = dataGridView_item.Rows[e.RowIndex].Cells["name"].Value!.ToString();
                    textBox_barcode.Text = dataGridView_item.Rows[e.RowIndex].Cells["barcode"].Value!.ToString();
                    textBox_qty_last.Text = dataGridView_item.Rows[e.RowIndex].Cells["qty"].Value!.ToString();
                    label_unit.Text = dataGridView_item.Rows[e.RowIndex].Cells["unit"].Value!.ToString();
                    label_onhand_unit.Text = label_unit.Text;

                    set_qty_small = dataGridView_item.Rows[e.RowIndex].Cells["qty_small"].Value!.ToString()!;
                    set_cost_avg = dataGridView_item.Rows[e.RowIndex].Cells["cost_avg"].Value!.ToString()!;
                    set_cost_last = dataGridView_item.Rows[e.RowIndex].Cells["cost_last"].Value!.ToString()!;
                    set_size = dataGridView_item.Rows[e.RowIndex].Cells["size"].Value!.ToString()!;

                    textBox_cost_last.Text = Convert.ToDouble(set_cost_last).ToString("#,##0.##");
                    textBox_cost_avg.Text = Convert.ToDouble(set_cost_avg).ToString("#,##0.##");

                    if (Class_Parameter.inc_dec_custom == 1)
                    {
                        increaseActive();
                        if (Class_Parameter.last_avg_custom == 1)
                        {
                            costLast();
                        }
                        else if (Class_Parameter.last_avg_custom == 2)
                        {
                            costAVG();
                        }
                        else if (Class_Parameter.last_avg_custom == 3)
                        {
                            costCustom();
                        }
                    }
                    else if (Class_Parameter.inc_dec_custom == 2)
                    {
                        decreaseActive();
                        Class_Parameter.last_avg_custom = 2;
                        costAVG();
                    }
                    else if (Class_Parameter.inc_dec_custom == 3)
                    {
                        customActive();
                        Class_Parameter.last_avg_custom = 2;
                        costAVG();
                    }
                }
                textBox_qty.Focus();
            }
            catch
            {

            }
        }

        private void textBox_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0)
                    {
                        e.Handled = true;
                    }

                }

                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 3 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 3)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void cost_type_click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_barcode.Text != string.Empty)
                {
                    if (Class_Parameter.inc_dec_custom == 1)
                    {
                        Button button = (Button)sender;
                        if (button.Name == "button_cost_last")
                        {
                            if (Class_Parameter.last_avg_custom != 1)
                            {
                                Class_Parameter.last_avg_custom = 1;
                                costLast();
                                Class_Parameter.cost_per_unit = true;
                                cost_per_unit();
                            }
                        }
                        else if (button.Name == "button_cost_avg")
                        {
                            if (Class_Parameter.last_avg_custom != 2)
                            {
                                Class_Parameter.last_avg_custom = 2;
                                costAVG();
                                Class_Parameter.cost_per_unit = true;
                                cost_per_unit();
                            }
                        }
                        else if (button.Name == "button_cost_custom")
                        {
                            if (Class_Parameter.last_avg_custom != 3)
                            {
                                Class_Parameter.last_avg_custom = 3;
                                costCustom();

                            }
                        }
                    }
                }


            }
            catch
            {

            }
        }
        private void cost_per_click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_barcode.Text != string.Empty)
                {
                    if (Class_Parameter.last_avg_custom == 3)
                    {
                        Button btn = (Button)sender;
                        if (btn.Name == "button_cost_per_unit")
                        {
                            if (!Class_Parameter.cost_per_unit)
                            {
                                Class_Parameter.cost_per_unit = true;

                                cost_per_unit();
                            }
                        }
                        else // cost_all
                        {
                            if (Class_Parameter.cost_per_unit)
                            {
                                Class_Parameter.cost_per_unit = false;

                                cost_all();
                            }
                        }
                    }
                }

            }
            catch
            {

            }
        }
        private void costLast()
        {
            try
            {
                // button_cost_last.FlatStyle = FlatStyle.Standard;
                button_cost_last.BackColor = Color.FromArgb(128,255,128);
                button_cost_last.ForeColor = Color.Black;

                // button_cost_avg.FlatStyle = FlatStyle.Flat;
                button_cost_avg.BackColor = Color.Transparent;
                button_cost_avg.ForeColor = Color.Gray;

                // button_cost_custom.FlatStyle = FlatStyle.Flat;
                button_cost_custom.BackColor = Color.Transparent;
                button_cost_custom.ForeColor = Color.Gray;

                textBox_cost.Enabled = false;
                if (textBox_barcode.Text != string.Empty)
                {
                    textBox_cost.Text = Convert.ToDouble(dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["cost_last"].Value).ToString("#,##0.##");

                }

                label_cost.Text = button_cost_last.Text + " :";

                textBox_qty.Focus();
            }
            catch
            {

            }
        }
        private void costAVG()
        {
            try
            {
                // button_cost_last.FlatStyle = FlatStyle.Flat;
                button_cost_last.BackColor = Color.Transparent;
                button_cost_last.ForeColor = Color.Gray;

                // button_cost_avg.FlatStyle = FlatStyle.Standard;
                button_cost_avg.BackColor = Color.FromArgb(128,255,128);
                button_cost_avg.ForeColor = Color.Black;

                //  button_cost_custom.FlatStyle = FlatStyle.Flat;
                button_cost_custom.BackColor = Color.Transparent;
                button_cost_custom.ForeColor = Color.Gray;

                textBox_cost.Enabled = false;
                if (textBox_barcode.Text != string.Empty)
                {
                    textBox_cost.Text = Convert.ToDouble(dataGridView_item.Rows[dataGridView_item.CurrentRow!.Index].Cells["cost_avg"].Value).ToString("#,##0.##");

                }

                label_cost.Text = button_cost_avg.Text + " :";

                textBox_qty.Focus();
            }
            catch
            {

            }
        }
        private void costCustom()
        {
            try
            {
                // button_cost_last.FlatStyle = FlatStyle.Flat;
                button_cost_last.BackColor = Color.Transparent;
                button_cost_last.ForeColor = Color.Gray;

                // button_cost_avg.FlatStyle = FlatStyle.Flat;
                button_cost_avg.BackColor = Color.Transparent;
                button_cost_avg.ForeColor = Color.Gray;

                //button_cost_custom.FlatStyle = FlatStyle.Standard;
                button_cost_custom.BackColor = Color.FromArgb(128,255,128);
                button_cost_custom.ForeColor = Color.Black;

                textBox_cost.Enabled = true;

                label_cost.Text = button_cost_custom.Text + " :";

                textBox_cost.Focus();
            }
            catch
            {

            }
        }
        private void cost_per_unit()
        {
            try
            {
                button_cost_per_unit.BackColor = Color.FromArgb(128,255,128);
                button_cost_per_unit.ForeColor = Color.Black;

                button_cost_all.BackColor = Color.Transparent;
                button_cost_all.ForeColor = Color.Gray;

                label_per_unit.Text = button_cost_per_unit.Text;
            }
            catch { }

        }
        private void cost_all()
        {
            try
            {
                button_cost_per_unit.BackColor = Color.Transparent;
                button_cost_per_unit.ForeColor = Color.Gray;

                button_cost_all.BackColor = Color.FromArgb(128,255,128);
                button_cost_all.ForeColor = Color.Black;

                label_per_unit.Text = button_cost_all.Text;
            }
            catch { }

        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {


                if (e.KeyCode == Keys.Enter)
                {
                   
                    if (textBox_barcode.Text != string.Empty)
                    {
                        e.SuppressKeyPress = true;
                        TextBox textBox = (TextBox)sender;
                        if (textBox.Name == "textBox_qty")
                        {
                            if (Class_Parameter.inc_dec_custom == 1 && Class_Parameter.last_avg_custom == 3)
                            {
                                textBox_cost.Focus();
                            }
                            else
                            {
                                confirmQty();
                            }
                        }
                        else if (textBox.Name == "textBox_cost")
                        {
                            confirmQty();
                        }
                    }
                }


            }
            catch
            {

            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                confirmQty();
            }
            catch
            {

            }
        }

        private void confirmQty()
        {
            try
            {
                if (textBox_barcode.Text != string.Empty)
                {
                    if (textBox_qty.Text == string.Empty || (Class_Parameter.inc_dec_custom == 1 && textBox_cost.Text == string.Empty))
                    {
                        //   MessageBox.Show("กรุณากรองข้อมูลให้ครบถ้วน !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // ลดมากกว่าคงเหลือ
                    if (Convert.ToDouble(textBox_qty.Text) > Convert.ToDouble(textBox_qty_last.Text) &&
                       Class_Parameter.inc_dec_custom == 2)
                    {
                        MessageBox.Show("ไม่สามารถปรับลดมากกว่าคงเหลือ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // ปรับเพิ่มหรือลด 0 หรือ กำหนดเท่ากับจำนวนคงเหลือ
                    if ((Convert.ToDouble(textBox_qty.Text) == 0 && Class_Parameter.inc_dec_custom != 3) ||
                        (Class_Parameter.inc_dec_custom == 3 && Convert.ToDouble(textBox_qty.Text) == Convert.ToDouble(textBox_qty_last.Text))
                       )
                    {
                        return;
                    }
                    // เริ่มปรับ
                    string respond = null;
                    // การเพิ่ม
                    if (Class_Parameter.inc_dec_custom == 1)
                    {
                        if (Class_Parameter.last_avg_custom == 1)
                        {
                            // ใช้ last
                            respond = Class_Item_Adjust.Increase(
                                 textBox_barcode.Text,
                                 set_qty_small,
                                 textBox_qty.Text,
                                 set_cost_last, 
                                 Class_Parameter.Adjust_Increase,
                                 "");
                        }
                        else if (Class_Parameter.last_avg_custom == 2)
                        {
                            // ใช้ avg
                            respond = Class_Item_Adjust.Increase(
                                textBox_barcode.Text,
                                set_qty_small,
                                textBox_qty.Text,
                                set_cost_avg, 
                                Class_Parameter.Adjust_Increase,
                                 "");
                        }
                        else
                        {
                            // ใช้ กำหนด
                            if (Class_Parameter.cost_per_unit)
                            {
                                respond = Class_Item_Adjust.Increase(
                                    textBox_barcode.Text,
                                    set_qty_small,
                                    textBox_qty.Text,
                                    textBox_cost.Text,
                                     Class_Parameter.Adjust_Increase,
                                    "");
                            }
                            else // cost_all
                            {
                                respond = Class_Item_Adjust.Increase(
                                     textBox_barcode.Text,
                                     set_qty_small,
                                     textBox_qty.Text,
                                     (Convert.ToDouble(textBox_cost.Text) / Convert.ToDouble(textBox_qty.Text)).ToString(),
                                      Class_Parameter.Adjust_Increase,
                                     "");
                            }

                        }

                    }
                    else if (Class_Parameter.inc_dec_custom == 2)  // ลด
                    {
                        // ใช้ avg
                        respond = Class_Item_Adjust.Decrease(
                            textBox_barcode.Text,
                            set_qty_small,
                            textBox_qty.Text,
                            set_cost_avg,
                            Class_Parameter.Adjust_Decrease,
                            "");
                    }
                    else // กำหนด
                    {
                        // ใช้ avg
                        respond = Class_Item_Adjust.Custom(
                          textBox_barcode.Text,
                          set_qty_small,
                          textBox_qty.Text,
                          set_cost_avg);
                    }
                    // จบการปรับ
                    if (respond is not null)
                    {
                        textBox_qty_last.Text = respond;
                        textBox_qty.Text = "";
                        search();
                        textBox_search.Focus();
                        textBox_search.SelectAll();
                    }
                }


            }
            catch
            {

            }
        }

        private void textBox_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;

                // 1. อนุญาตให้กดตัวเลข, backspace, จุดทศนิยม (.), 
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // 2. อนุญาตให้มีจุดทศนิยม (.) ได้เพียงจุดเดียวเท่านั้น
                if ((e.KeyChar == '.'))
                {
                    if (txt.Text.IndexOf('.') > -1 || txt.SelectionStart == 0)
                    {
                        e.Handled = true;
                    }

                }
                // 4. จำกัดตัวเลขหลังจุดทศนิยมไม่เกิน 2 ตำแหน่ง
                if (char.IsDigit(e.KeyChar))
                {
                    int dotIndex = txt.Text.IndexOf('.');

                    // ตรวจสอบว่ามีจุดทศนิยมแล้ว และเคอร์เซอร์อยู่หลังจุดทศนิยมหรือไม่
                    if (dotIndex > -1 && txt.SelectionStart > dotIndex)
                    {
                        // แยกข้อความหลังจุดทศนิยมมานับจำนวนหลัก โดยตัดข้อความที่ถูกคลุมดำเลือก (Selection) ออกก่อน
                        string postDotText = txt.Text.Substring(dotIndex + 1);

                        // ลบจำนวนตัวอักษรที่กำลังถูกไฮไลท์เลือกอยู่ เพราะผู้ใช้สามารถพิมพ์ทับได้
                        int selectedLengthAfterDot = Math.Max(0, txt.SelectionStart + txt.SelectionLength - (dotIndex + 1))
                                                     - Math.Max(0, txt.SelectionStart - (dotIndex + 1));

                        if ((postDotText.Length - selectedLengthAfterDot) >= 2)
                        {
                            e.Handled = true;
                        }
                    }
                }

            }
            catch
            {

            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size + 1, button.Font.Style);
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
                button.Font = new System.Drawing.Font("Segoe UI", button.Font.Size - 1, button.Font.Style);
            }
            catch
            {

            }
        }

      
    }
}
