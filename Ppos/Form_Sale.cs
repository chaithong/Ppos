using Microsoft.Office.Interop.Excel;
using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.DataContracts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ppos
{
    public partial class Form_Sale : Form
    {
        TableLayoutPanel tableLayoutPanel_hotkey = new TableLayoutPanel();
        PictureBox pictureBox_load_hotkey = new PictureBox();
        System.Windows.Forms.Button button;
        System.Data.DataTable dt;
        int C = 0, R = 0;

        int set_X, set_Y;
        int seq_visible = 0;
        public static string id_member = "", percent_discount_member = "0";

        public static string price_net;
        public static double discount_round;

        public static string W_image_bar = "", W_item_bar = "", W_item_name = "", W_item_unit = "", W_item_price = "";
        bool hole_bill = false;
        bool discount_member = false;
        Panel parentPanel;
        public Form_Sale()
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
                dataGridView_item.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dataGridView_item.EnableHeadersVisualStyles = false;
                dataGridView_item.MouseWheel += new MouseEventHandler(dataGridView_item_MouseWheel!);

                button_hotkey_1.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_hotkey_2.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_hotkey_3.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_last_sale.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));
                button_hot_sale.Image = Class_Image.resizeImage(Ppos.Properties.Resources.additem, new Size(40, 40));

                button_sale.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(30, 30));
                button_member.Image = Class_Image.resizeImage(Ppos.Properties.Resources.addMember, new Size(40, 40));

                //  button_check.Image = Class_Image.resizeImage(Ppos.Properties.Resources.product, new Size(40, 40));
                button_hole_bill.Image = Class_Image.resizeImage(Ppos.Properties.Resources.bill, new Size(40, 40));
                button_other.Image = Class_Image.resizeImage(Ppos.Properties.Resources.file, new Size(40, 40));

                button_delete_all.Image = Class_Image.resizeImage(Ppos.Properties.Resources.clear, new Size(30, 30));
                button_pay.Image = Class_Image.resizeImage(Ppos.Properties.Resources.sales, new Size(70, 70));

                // ปรับขนาดหน้าจอ
                tableLayoutPanel_back.ColumnStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel_back.ColumnStyles[0].Width = Class_Parameter.sale_left_width;
                tableLayoutPanel_back.ColumnStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel_back.ColumnStyles[1].Width = 100 - Class_Parameter.sale_left_width;

                // ปรับตำแหน่งซ้ายขวก
                if (Class_Parameter.sale_hotkey_left)
                {
                    // hotkey อยู่ทางซ้าย

                    button_sale_display.Text = "<";

                    tableLayoutPanel_back.Controls.Clear();

                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 0, 0);
                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_right, 1, 0);

                }
                else
                {
                    // hotkey อยู่ทางขวา

                    button_sale_display.Text = ">";

                    tableLayoutPanel_back.Controls.Clear();

                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_right, 0, 0);
                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 1, 0);
                }

                // ใส่ข้อความ hotkey
                button_hotkey_1.Text = Class_Parameter.hotkey_title_1;
                button_hotkey_2.Text = Class_Parameter.hotkey_title_2;
                button_hotkey_3.Text = Class_Parameter.hotkey_title_3;

                new TableLayoutResizer(tableLayoutPanel_back);
                // ตรวจสอบสมาชิก
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT 1 from Member m where m.status = true";

                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            // ตรวจสอบส่วนลดสมาชิก
                            cmd_sqlite.CommandText = @"SELECT 1 from Member m where m.status = true and m.discount_percent >0";

                            er = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
                            dt.Load(er);
                            if (dt.Rows.Count > 0)
                            {
                                discount_member = true;
                            }
                        }
                        else // ไม่มีสมาชิก ปิด 
                        {
                            customGroupBox_member.Visible = false;
                            tableLayoutPanel_bill.RowStyles[1].Height = 0;
                        }
                    }
                }
                textBox_search.LostFocus += TextBox_search_LostFocus;
            }
            catch
            {
                this.Close();
            }

        }

        private void TextBox_search_LostFocus(object? sender, EventArgs e)
        {
            try
            {
                if (parentPanel.Controls.OfType<Form>().Count() == 1)
                {
                    textBox_search.Focus();

                }
            }
            catch
            {

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
        private void Form_Sale_Load(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.id_body_temp = Class_Sale.id_invoid_body_temp();

                hole_bill = Class_Sale.hole_invoid_body_temp();
                if (hole_bill)
                {
                    button_hole_bill.Text = "เรียกบิล";
                    button_hole_bill.BackColor = Color.FromArgb(255, 192, 192);
                }
                else
                {
                    button_hole_bill.Text = "พักบิล";
                    button_hole_bill.BackColor = Color.White;
                }

                if (Class_Parameter.hotkey_pag == 1) // 1
                {
                    button_hotkey_1.FlatStyle = FlatStyle.Standard;
                    button_hotkey_1.ForeColor = Color.Black;
                    button_hotkey_1.BackColor = Color.White;
                }
                else if (Class_Parameter.hotkey_pag == 2) // 2
                {
                    button_hotkey_2.FlatStyle = FlatStyle.Standard;
                    button_hotkey_2.ForeColor = Color.Black;
                    button_hotkey_2.BackColor = Color.White;
                }
                else if (Class_Parameter.hotkey_pag == 3)// 3
                {
                    button_hotkey_3.FlatStyle = FlatStyle.Standard;
                    button_hotkey_3.ForeColor = Color.Black;
                    button_hotkey_3.BackColor = Color.White;
                }
                else if (Class_Parameter.hotkey_pag == 4)// 4
                {
                    button_last_sale.FlatStyle = FlatStyle.Standard;
                    button_last_sale.ForeColor = Color.Black;
                    button_last_sale.BackColor = Color.White;
                }
                else if (Class_Parameter.hotkey_pag == 5)// 5
                {
                    button_hot_sale.FlatStyle = FlatStyle.Standard;
                    button_hot_sale.ForeColor = Color.Black;
                    button_hot_sale.BackColor = Color.White;
                }

                parentPanel = (Panel)this.Parent!;

                timer_load.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sort_hotkey()
        {
            try
            {
                tableLayoutPanel_hotkey_pag.Enabled = false;

                for (int i = panel_hotkey.Controls.Count - 1; i >= 0; i--)
                {
                    // นำคอนโทรลออกมาแล้วสั่งทำลายทิ้งจากหน่วยความจำ
                    panel_hotkey.Controls[i].Dispose();
                }
                panel_hotkey.Controls.Clear();

                pictureBox_load_hotkey = new PictureBox();
                panel_hotkey.Controls.Add(pictureBox_load_hotkey);
                pictureBox_load_hotkey.Size = new Size(200, 200);
                pictureBox_load_hotkey.Image = Ppos.Properties.Resources.load;
                pictureBox_load_hotkey.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox_load_hotkey.BackColor = System.Drawing.Color.Transparent;

                pictureBox_load_hotkey.Location = new System.Drawing.Point(
              panel_hotkey.Location.X + (panel_hotkey.Width / 2) - (pictureBox_load_hotkey.Width / 2),
              panel_hotkey.Location.Y + (panel_hotkey.Height / 2) - (pictureBox_load_hotkey.Height / 2));

                Class_Parameter.runbackground = true;
                backgroundWorker_hotkey.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backgroundWorker_hotkey_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                tableLayoutPanel_hotkey = new TableLayoutPanel();

                for (int i = 0; i < Class_Parameter.column_count; i++)
                {
                    tableLayoutPanel_hotkey.ColumnCount += 1;
                    tableLayoutPanel_hotkey.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                }
                tableLayoutPanel_hotkey.AutoSize = true;
                tableLayoutPanel_hotkey.Dock = DockStyle.Top;
                tableLayoutPanel_hotkey.Width = panel_hotkey.Width;
                tableLayoutPanel_hotkey.Name = "tableLayoutPanel_detail";
                tableLayoutPanel_hotkey.RowCount = 1;
                tableLayoutPanel_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT  i.small_barcode,i.barcode,i.code,i.group_main,i.group_sub,i.name,i.qty,i.unit,i.price,ih2.column ,ih2.row
                                                  from ( 
                                                    SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,name,small_qty as qty,small_unit as unit,small_price as price 
                                                    from Item 
                                                    where status = 1                                                  
                                                    union all 
                                                    SELECT small_barcode,medium_barcode,code,group_main,group_sub,name,medium_qty,medium_unit,medium_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT small_barcode,large_barcode,code,group_main,group_sub,name,large_qty,large_unit,large_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and large_barcode <> '') i 
                                                    join Item_Hotkey ih2 on ih2.item_code = i.code and ih2.barcode = i.barcode ";
                        cmd_sqlite.CommandText += "and ih2.pag = " + Class_Parameter.hotkey_pag + " ";
                        if (Class_Parameter.hotkey_pag == 4 || Class_Parameter.hotkey_pag == 5)
                        {
                            cmd_sqlite.CommandText += "order by ih2.id";
                        }
                        else
                        {
                            cmd_sqlite.CommandText += "order by ih2.row,ih2.column";
                        }

                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            C = R = 0;
                            // tableLayoutPanel_hotkey.Width = panel_hotkey.Width;
                            // ทำการเรียงใหม่และอัพเดท row column
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                button = new System.Windows.Forms.Button();
                                tableLayoutPanel_hotkey.Controls.Add(button, C, R);

                                button.Name = dt.Rows[i]["code"].ToString() + "|" + dt.Rows[i]["small_barcode"].ToString() + "|" + dt.Rows[i]["barcode"].ToString();

                                if (Class_Parameter.hotkey_pag == 4 || Class_Parameter.hotkey_pag == 5) // ถ้าเลือก pag ล่าสุดหรือขายดี
                                {
                                    button.Text = dt.Rows[i]["name"].ToString() + Environment.NewLine +
                                        "คงเหลือ : " + Convert.ToDouble(dt.Rows[i]["qty"]).ToString("#,##0.###") + " " + dt.Rows[i]["unit"].ToString() + Environment.NewLine +
                                 "ราคา : " + dt.Rows[i]["price"].ToString() + " บาท";
                                }
                                else
                                {
                                    button.Text = dt.Rows[i]["name"].ToString() + " (" + dt.Rows[i]["unit"].ToString() + ")" + Environment.NewLine +
                                  "ราคา : " + dt.Rows[i]["price"].ToString() + " บาท";
                                }


                                button_style(button, dt.Rows[i]["small_barcode"].ToString()!);

                                button.MouseDown += Button_MouseDown;
                                button.MouseUp += Button_MouseUp;
                                button.MouseEnter += Button_MouseEnter;
                                button.MouseLeave += Button_MouseLeave;

                                C++;
                                if (C == Class_Parameter.column_count)
                                {
                                    C = 0;
                                    R++;

                                    tableLayoutPanel_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, Class_Parameter.row_height));


                                }
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
        private void backgroundWorker_hotkey_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                panel_hotkey.Controls.Add(tableLayoutPanel_hotkey);
                tableLayoutPanel_hotkey.Dock = DockStyle.Top;
                Class_Scroll_Panel.EnableDragScroll(panel_hotkey);
                pictureBox_load_hotkey.Visible = false;
                textBox_search.Focus();
                tableLayoutPanel_hotkey_pag.Enabled = true;
                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer_load_Tick(object sender, EventArgs e)
        {
            try
            {

                seq_visible++;
                if (seq_visible == 1)
                {
                    button_hotkey_1.Visible = true;
                }
                else if (seq_visible == 2)
                {
                    button_hotkey_2.Visible = true;
                }
                else if (seq_visible == 3)
                {
                    button_hotkey_3.Visible = true;
                }
                else if (seq_visible == 4)
                {
                    button_last_sale.Visible = true;
                }
                else if (seq_visible == 5)
                {

                    button_hot_sale.Visible = true;
                }
                else if (seq_visible == 6)
                {
                    button_sale.Visible = true;
                }
                else if (seq_visible == 7)
                {
                    button_member.Visible = true;
                }
                else if (seq_visible == 8)
                {
                    //  button_check.Visible = true;
                }
                else if (seq_visible == 9)
                {
                    button_hole_bill.Visible = true;
                }
                else if (seq_visible == 10)
                {
                    button_other.Visible = true;
                }
                else if (seq_visible == 11)
                {
                    dataGridView_item.Visible = true;
                }
                else if (seq_visible == 12 && Class_Parameter.visible_sum_qty)
                {
                    tableLayoutPanel_sum_qty.Visible = true;
                }
                else if (seq_visible == 13 && Class_Parameter.visible_sum_price)
                {
                    tableLayoutPanel_sum_price.Visible = true;
                }
                else if (seq_visible == 14 && Class_Parameter.visible_dis_pro)
                {
                    tableLayoutPanel_discount_pro.Visible = true;
                }
                else if (seq_visible == 15 && discount_member && Class_Parameter.visible_dis_member)
                {
                    tableLayoutPanel_discount_member.Visible = true;
                }
                else if (seq_visible == 16 && Class_Parameter.visible_dis_round)
                {
                    tableLayoutPanel_discount_round.Visible = true;
                }
                else if (seq_visible == 17)
                {
                    tableLayoutPanel_sum_net.Visible = true;
                }
                else if (seq_visible >= 18)
                {
                    timer_load.Stop();
                    sort_hotkey();
                    Class_Parameter.runbackground = true;
                    backgroundWorker_load.RunWorkerAsync();
                    textBox_search.Focus();
                }
            }
            catch
            {
                Class_Parameter.runbackground = false;
                timer_load.Stop();
            }
        }
        private void backgroundWorker_load_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ดึงข้อมูลมาใส่ตาราง สินค้าเดิมที่ค้างหน้าจอ
                        cmd_sqlite.CommandText = @"SELECT id,void,return,small_barcode,item_barcode,
item_code,item_name,item_qty,item_unit,item_price,
item_price_sum,small_qty,qty_small,
pro_id,pro_type,pro_desc,
criterion_type,criterion_value,
offer_type,offer_value,
discount_type,repeat,
discount_promotion,
id_member,
percent_discount_member,
discount_member,
discount_custom,
discount_point,
discount_round,
price_net,
price_non_vat,
price_vat,
vat,
sale_vat,
premium,
effective_member,
hole FROM Invoice_Body_Temp where void = false and hole = false ";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt_temp = new System.Data.DataTable();
                        dt_temp.Load(reader);
                        if (dt_temp.Rows.Count > 0)
                        {
                            Image pro;
                            for (int i = 0; i < dt_temp.Rows.Count; i++)
                            {
                                pro = new Bitmap(30, 30);

                                if (dt_temp.Rows[i]["pro_type"].ToString() != string.Empty)
                                {
                                    pro = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(30, 30));

                                }

                                dataGridView_item.Rows.Add(
                                dt_temp.Rows[i]["id"].ToString()!,
                                dt_temp.Rows[i]["item_code"].ToString()!,
                                dt_temp.Rows[i]["small_barcode"].ToString()!,
                                dt_temp.Rows[i]["item_barcode"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                dt_temp.Rows[i]["item_name"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(30, 30)),
                                Convert.ToDouble(dt_temp.Rows[i]["item_qty"]).ToString("#,##0.000"),
                                dt_temp.Rows[i]["item_unit"].ToString()!,
                                Convert.ToDouble(dt_temp.Rows[i]["item_price"]).ToString("#,##0.00"),
                                (Convert.ToDouble(dt_temp.Rows[i]["item_qty"]) * Convert.ToDouble(dt_temp.Rows[i]["item_price"])).ToString("#,##0.00"),
                                pro,
                                dt_temp.Rows[i]["pro_id"].ToString()!,
                                dt_temp.Rows[i]["pro_type"].ToString()!,
                                dt_temp.Rows[i]["pro_desc"].ToString()!,
                                dt_temp.Rows[i]["criterion_type"].ToString()!,
                                dt_temp.Rows[i]["criterion_value"].ToString()!,
                                dt_temp.Rows[i]["offer_type"].ToString()!,
                                dt_temp.Rows[i]["offer_value"].ToString()!,
                                dt_temp.Rows[i]["discount_type"].ToString()!,
                                dt_temp.Rows[i]["repeat"].ToString()!,
                                dt_temp.Rows[i]["premium"].ToString()!,
                                dt_temp.Rows[i]["effective_member"].ToString()!, // effective_member
                                dt_temp.Rows[i]["sale_vat"].ToString()!
                                );

                                dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();

                                if (id_member == string.Empty && dt_temp.Rows[i]["id_member"].ToString()! != string.Empty)
                                {
                                    id_member = dt_temp.Rows[i]["id_member"].ToString()!;
                                    percent_discount_member = dt_temp.Rows[i]["percent_discount_member"].ToString()!;
                                }

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
        private void backgroundWorker_load_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // เลือกบรรทัดสุดท้าย
                if (dataGridView_item.RowCount > 0)
                {
                    dataGridView_item.FirstDisplayedScrollingRowIndex = dataGridView_item.RowCount - 1;

                    dataGridView_item.Rows[dataGridView_item.RowCount - 1].Selected = true;
                }
                // ดึงสมาชิก
                if (id_member != string.Empty)
                {
                    select_member(id_member);
                }

                // แสดงผลรวมด้านล่าง
                sum_total();

                dataGridView_item.Enabled = true;
                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Button_MouseDown(object? sender, MouseEventArgs e)
        {
            try
            {
                // MessageBox.Show(Cursor.Position.X.ToString() +" : "+ Cursor.Position.Y.ToString());
                set_X = Cursor.Position.X;
                set_Y = Cursor.Position.Y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {
                // ไม่ใช้การสไล
                if (e.Button == MouseButtons.Left &&
                    Cursor.Position.X > set_X - 10 && Cursor.Position.X < set_X + 10 &&
                    Cursor.Position.Y > set_Y - 10 && Cursor.Position.Y < set_Y + 10)
                {
                    string qty = "1.000";
                    bool custom_qty;
                    // ถ้ามีกำหนดจำนวนไว้ที่ช่องค้นหา
                    if (textBox_search.Text.Trim() != string.Empty)
                    {
                        // ถ้าไม่ใช่ตัวเลขจะ return
                        if (!double.TryParse(textBox_search.Text.Trim(), out double result))
                        {
                            textBox_search.Text = "";
                            return;
                        }
                        else if (result <= 0) // ถ้าเป็นตัวเลข จำนวนน้อยกว่าหรือเท่ากับ 0
                        {
                            textBox_search.Text = "";
                            return;
                        }
                        qty = result.ToString("#,##0.000");
                        custom_qty = true;
                    }
                    else
                    {
                        custom_qty = false;
                    }
                    button = (System.Windows.Forms.Button)sender!;


                    select_item(qty, script_search(button.Name.Split("|")[2]), custom_qty);
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

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (textBox_search.Text != string.Empty)
                    {
                        string qty = "1.000", script = "";
                        bool custom_qty;
                        if (textBox_search.Text.Trim().Contains("*"))
                        {
                            // มี * มากกว่า 1
                            if (textBox_search.Text.Trim().Count(c => c == '*') > 1)
                            {
                                textBox_search.Text = "";
                                return;
                            }
                            else if (textBox_search.Text.Trim().Split("*")[0] == string.Empty)
                            {
                                textBox_search.Text = "";
                                return;
                            }
                            else if (!double.TryParse(textBox_search.Text.Trim().Split("*")[0], out double result))
                            {
                                textBox_search.Text = "";
                                return;
                            }
                            else if (result <= 0)
                            {
                                textBox_search.Text = "";
                                return;
                            }
                            qty = Convert.ToDouble(textBox_search.Text.Trim().Split("*")[0]).ToString("#,##0.000");
                            script = script_search(textBox_search.Text.Trim().Split("*")[1]);
                            custom_qty = true;
                        }
                        else
                        {
                            script = script_search(textBox_search.Text.Trim());
                            custom_qty = false;
                        }

                        select_item(qty, script, custom_qty);

                    }
                    else
                    {
                        // ชำระ
                        button_pay_Click(sender, e);

                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool check_qty(string qty, string item_code, string small_qty, string qty_small)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT coalesce(sum(ibt.item_qty*ibt.qty_small),0) as qty
                          from Invoice_Body_Temp ibt 
                          where ibt.void = false and ibt.hole = false and ibt.item_code = " + item_code;
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {


                            if (Convert.ToDouble(dt.Rows[0]["qty"]) + (Convert.ToDouble(qty) * Convert.ToDouble(qty_small)) > Convert.ToDouble(small_qty))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void select_item(string qty, string script, bool custom_qty)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = script;
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        dt = new System.Data.DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            // ถ้าเป็นสินค้าน้ำหนัก และ ไม่ได้กำหนดน้ำหนักไว้ที่ช่องค้นหา
                            if (Convert.ToBoolean(dt.Rows[0]["item_weight"]) && !custom_qty)
                            {
                                // เริ่มปิด form weight กำหนดจำนวน 
                                // กำหนดรายละเอียดสินค้าส่งให้แสดงใน item weight
                                W_image_bar = dt.Rows[0]["small_barcode"].ToString()!;
                                W_item_bar = dt.Rows[0]["barcode"].ToString()!;
                                W_item_name = dt.Rows[0]["name"].ToString()!;
                                W_item_unit = dt.Rows[0]["unit"].ToString()!;
                                W_item_price = dt.Rows[0]["price"].ToString()!;

                                Form_Item_Weight form_Item_Weight = new Form_Item_Weight();
                                form_Item_Weight.Size = new Size(this.Width / 3, this.Height / 2);
                                form_Item_Weight.ShowDialog(this);
                                form_Item_Weight.StartPosition = FormStartPosition.CenterParent;
                                if (form_Item_Weight.exit)
                                {
                                    textBox_search.Text = "";
                                    return;
                                }
                                else
                                {
                                    qty = form_Item_Weight.weight;
                                }
                            }

                            // ตรวจสอบ sale negative

                            if (!Convert.ToBoolean(dt.Rows[0]["sale_negative"]))
                            {
                                if (!check_qty(qty, dt.Rows[0]["code"].ToString()!, dt.Rows[0]["small_qty"].ToString()!, dt.Rows[0]["qty_small"].ToString()!))
                                {
                                    MessageBox.Show("คงเหลือไม่มีเพียงพอขาย", "คงเหลือไม่มีเพียงพอขาย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textBox_search.Text = "";
                                    return;
                                }

                            }

                            /////////////////
                            // เริ่ม insert temp


                            Class_Sale.insert_invoice_body_temp(
                                false, // void
                                false, // return
                                dt.Rows[0]["small_barcode"].ToString()!, // small_barcode
                                dt.Rows[0]["barcode"].ToString()!, // item_barcode
                                dt.Rows[0]["code"].ToString()!, // item_code
                                dt.Rows[0]["name"].ToString()!, // item_name
                                qty.Replace(",", ""), // item_qty
                                dt.Rows[0]["unit"].ToString()!, // item_unit 
                                dt.Rows[0]["price"].ToString()!, // item_price
                                (Convert.ToDouble(qty.Replace(",", "")) * Convert.ToDouble(dt.Rows[0]["price"].ToString()!)).ToString(), // item_price_sum
                                dt.Rows[0]["cost_avg"].ToString()!, // ต้นทุน
                                dt.Rows[0]["small_qty"].ToString()!, // จำนวนหน่วยเล็ก
                                dt.Rows[0]["qty_small"].ToString()!, // จำนวนหน่วยเล็กของหน่วยใหญ่
                                dt.Rows[0]["pro_id"].ToString()!, // pro_id *ถ้ามีแสดงว่าเป็นสินค้าโปรตามวันเวลา
                                dt.Rows[0]["pro_type"].ToString()!, // pro_type *ประเภทโปร โปรต่อสินค้า โปรคละสินค้า โปรชุดสินค้า
                                dt.Rows[0]["pro_desc"].ToString()!, // pro_desc *รายละเอียดโปร
                                dt.Rows[0]["criterion_type"].ToString()!,
                                dt.Rows[0]["criterion_value"].ToString()!,
                                dt.Rows[0]["offer_type"].ToString()!,
                                dt.Rows[0]["offer_value"].ToString()!,
                                dt.Rows[0]["discount_type"].ToString()!,
                                dt.Rows[0]["repeat"].ToString()!,
                                "0", // discount_promotion *ส่วนลดโปร ใส่ 0 ไปก่อนแล้ว select มาคำนวนแล้ว update
                                id_member,
                                percent_discount_member,
                                "0", // discount_member *ส่วนลดสมาชิก ใส่ 0 ไปก่อนแล้ว select มาคำนวนแล้ว update
                                "0", // discount_custom *จะมีผลตอนกดชำระ ถ้ากำหนดส่วนลดเพิ่มค่อยมา update
                                "0", // discount_point // ไปอัพเดทตอนจบบิล
                                "0", // discount_round *ส่วนลดปัดเศษ ใส่ 0 ไปก่อนแล้ว select มาคำนวนแล้ว update
                                (Convert.ToDouble(qty.Replace(",", "")) * Convert.ToDouble(dt.Rows[0]["price"].ToString()!)).ToString(), // price_net
                                "0", // price_non_vat
                                "0", // price_vat
                                "0", // vat
                                Convert.ToBoolean(dt.Rows[0]["sale_vat"]), // sale_vat
                                (dt.Rows[0]["premium"].ToString() != "") ? true : false, // premium
                                Convert.ToBoolean(dt.Rows[0]["effective_member"]), // effective_member
                                false // hole
                                );

                            /////////////////
                            // เริ่ม select มาคำนวน แล้ว update 
                            // update discount pro
                            // หาสินค้าโปรเพื่อแสดงโปร
                            Image pro = new Bitmap(30, 30);

                            if (dt.Rows[0]["pro_type"].ToString() != string.Empty)
                            {
                                pro = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(30, 30));

                                Class_Sale.Pro(
                                   dt.Rows[0]["pro_id"].ToString()!,
                                   dt.Rows[0]["pro_type"].ToString()!,
                                   dt.Rows[0]["criterion_type"].ToString()!,
                                   dt.Rows[0]["criterion_value"].ToString()!,
                                   dt.Rows[0]["offer_type"].ToString()!,
                                   dt.Rows[0]["offer_value"].ToString()!,
                                   dt.Rows[0]["discount_type"].ToString()!,
                                   dt.Rows[0]["repeat"].ToString()!,
                                   dt.Rows[0]["code"].ToString()!
                                   );
                            }
                            // สามาชิก
                            if (id_member != string.Empty)
                            {
                                Class_Sale.update_member(id_member, percent_discount_member);
                            }

                            /////////////////
                            // เริ่มแสดงผลหน้าจอ
                            // แสดงในตารางสินค้า
                            Class_Parameter.id_body_temp++;
                            dataGridView_item.Rows.Add(
                                Class_Parameter.id_body_temp,
                                dt.Rows[0]["code"],
                                dt.Rows[0]["small_barcode"].ToString()!,
                                dt.Rows[0]["barcode"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                dt.Rows[0]["name"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(30, 30)),
                                Convert.ToDouble(qty.Replace(",", "")).ToString("#,##0.000"),
                                dt.Rows[0]["unit"].ToString()!,
                                Convert.ToDouble(dt.Rows[0]["price"]).ToString("#,##0.00"),
                                (Convert.ToDouble(qty.Replace(",", "")) * Convert.ToDouble(dt.Rows[0]["price"])).ToString("#,##0.00"),
                                pro, // pro ถ้าเป็นสินค้าโปรจะแสดงคำนวน โปร
                                dt.Rows[0]["pro_id"].ToString()!,
                                dt.Rows[0]["pro_type"].ToString()!,
                                dt.Rows[0]["pro_desc"].ToString()!,
                                dt.Rows[0]["criterion_type"].ToString()!,
                                dt.Rows[0]["criterion_value"].ToString()!,
                                dt.Rows[0]["offer_type"].ToString()!,
                                dt.Rows[0]["offer_value"].ToString()!,
                                dt.Rows[0]["discount_type"].ToString()!,
                                dt.Rows[0]["repeat"].ToString()!,
                                (dt.Rows[0]["premium"].ToString() != "") ? "True" : "False",
                                dt.Rows[0]["effective_member"].ToString()!, // effective_member
                                dt.Rows[0]["sale_vat"].ToString()!
                                );

                            // เลือกบรรทัดสุดท้าย
                            dataGridView_item.FirstDisplayedScrollingRowIndex = dataGridView_item.RowCount - 1;
                            dataGridView_item.Rows[dataGridView_item.RowCount - 1].Selected = true;

                            // แสดงจำนวนบรรทัดสินค้า
                            dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();

                            // แสดงผลรวมด้านล่าง
                            sum_total();
                        }
                        else // ไม่เจอสินค้าจะหาสมาชิก
                        {
                            cmd_sqlite.CommandText = @"SELECT id,phone,sex,nick_name,first_name,last_name,
                                                               address,sub_district,district,province,postal_code,
                                                               discount_percent,sale_total,sale_ineffective_member,
                                                               sale_effective_member,sale_per_point,
                                                               point_increase,point_decrease,point_balance
                                                               FROM Member WHERE status = true and phone = '" + textBox_search.Text.Trim() + "'";
                            reader = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                id_member = dt.Rows[0]["id"].ToString()!;
                                percent_discount_member = dt.Rows[0]["discount_percent"].ToString()!;

                                pictureBox_delete_member.Visible = true;

                                string nick_name = "";
                                if (dt.Rows[0]["nick_name"].ToString() != string.Empty)
                                {
                                    nick_name = " (" + dt.Rows[0]["nick_name"].ToString()! + ")";
                                }
                                textBox_member.Text = "  " + dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString() + nick_name +
                                    " (" + Convert.ToDouble(dt.Rows[0]["point_balance"]).ToString("#,##0") + ")";

                                Class_Sale.update_member(id_member, percent_discount_member);

                                // แสดงผลรวมด้านล่าง
                                sum_total();

                                textBox_search.Text = "";

                            }
                        }
                        textBox_search.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void select_member(string id_member)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT nick_name,first_name,last_name,point_balance
                                                               FROM Member WHERE status = true and id = " + id_member;
                        SQLiteDataReader reader_member = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt_member = new System.Data.DataTable();
                        dt_member.Load(reader_member);
                        if (dt_member.Rows.Count > 0)
                        {
                            if (!pictureBox_delete_member.Visible)
                            {
                                pictureBox_delete_member.Visible = true;
                            }
                            string nick_name = "";
                            if (dt_member.Rows[0]["nick_name"].ToString() != string.Empty)
                            {
                                nick_name = " (" + dt_member.Rows[0]["nick_name"].ToString()! + ")";
                            }

                            textBox_member.Text = "  " + dt_member.Rows[0]["first_name"].ToString() + " " + dt_member.Rows[0]["last_name"].ToString() + nick_name +
                                 " (" + Convert.ToDouble(dt_member.Rows[0]["point_balance"]).ToString("#,##0") + ")";

                        }

                    }
                }
            }
            catch
            {

            }
        }

        private string script_search(string bar)
        {
            try
            {
                return @"  SELECT i.small_barcode,i.barcode,i.code,i.name,i.unit,i.price,i.small_qty,i.qty_small,i.cost_avg,
                                i.sale_negative,i.item_weight,i.effective_promotion,i.effective_member ,i.sale_vat,
                                coalesce(pro.pro_id,pre.pro_id) as pro_id ,coalesce(pro.pro_type,pre.pro_type) as pro_type ,coalesce(pro.pro_desc,pre.pro_desc) as pro_desc,
                                coalesce(pro.criterion_type,pre.criterion_type) as criterion_type ,coalesce(pro.criterion_value,pre.criterion_value) as criterion_value,
                                coalesce(pro.offer_type,pre.offer_type) as offer_type ,coalesce(pro.offer_value,pre.offer_value) as offer_value,
                                coalesce(pro.discount_type,pre.discount_type) as discount_type ,coalesce(pro.repeat,pre.repeat) as repeat,
                                coalesce(pro.item_code,pre.item_code) as item_code ,coalesce(pro.item_name,pre.item_name) as item_name ,
                                pre.pro_id as premium
                                                    FROM 
                                                    (SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,
                                                    name,small_unit as unit,small_price as price,small_qty,1 as qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat,small_cost_avg as cost_avg
                                                    from Item 
                                                    where status = 1                                          
                                                    union all 
                                                    SELECT small_barcode,medium_barcode,code,group_main,group_sub,
                                                    name,medium_unit,medium_price ,small_qty,medium_qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat,medium_cost_avg
                                                    from Item 
                                                    where status = 1                                        
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT small_barcode,large_barcode,code,group_main,group_sub,
                                                    name,large_unit,large_price ,small_qty,large_qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat,large_cost_avg
                                                    from Item 
                                                    where status = 1                                       
                                                    and large_barcode <> '') i
                                                    left join ( 
                                                   SELECT  p.pro_id,p.pro_type,p.pro_desc ,
                                                   p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                   pi.item_code,pi.item_name
                                                   from Promotion_Items pi
                                                   join Promotion p on p.pro_id = pi.pro_id                                                 
                                                    and p.status = '1'
                                                    and date(p.start_datetime) <= date('now', 'localtime') 
                                                    and date(p.end_datetime) >= date('now', 'localtime') 
                                                    and case 
                                                        when time(p.end_datetime) <> '00:00:00' then
                                                             time(p.start_datetime) <= strftime('%H:%M:%S', 'now', 'localtime')
                                                        and  time(p.end_datetime) >= strftime('%H:%M:%S', 'now', 'localtime') 
                                                        else 1
                                                    end
                                                    and case 
                                                    	when strftime('%w', 'now', 'localtime') = '0' then p.sun = 1
                                                        when strftime('%w', 'now', 'localtime') = '1' then p.mon = 1
                                                        when strftime('%w', 'now', 'localtime') = '2' then p.tue = 1
                                                        when strftime('%w', 'now', 'localtime') = '3' then p.wed = 1
                                                        when strftime('%w', 'now', 'localtime') = '4' then p.thu = 1
                                                        when strftime('%w', 'now', 'localtime') = '5' then p.fri = 1
                                                        when strftime('%w', 'now', 'localtime') = '6' then p.sat = 1
                                                    end   ) pro on pro.item_code = i.code
                                                    left join ( 
                                                   SELECT p.pro_id,p.pro_type,p.pro_desc ,
                                                   p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                   pip.item_code,pip.item_name
                                                   from Promotion_Items_Premium pip
                                                   join Promotion p on p.pro_id = pip.pro_id                                                 
                                                    and p.status = '1'
                                                    and date(p.start_datetime) <= date('now', 'localtime') 
                                                    and date(p.end_datetime) >= date('now', 'localtime') 
                                                    and case 
                                                        when time(p.end_datetime) <> '00:00:00' then
                                                             time(p.start_datetime) <= strftime('%H:%M:%S', 'now', 'localtime')
                                                        and  time(p.end_datetime) >= strftime('%H:%M:%S', 'now', 'localtime') 
                                                        else 1
                                                    end
                                                    and case 
                                                    	when strftime('%w', 'now', 'localtime') = '0' then p.sun = 1
                                                        when strftime('%w', 'now', 'localtime') = '1' then p.mon = 1
                                                        when strftime('%w', 'now', 'localtime') = '2' then p.tue = 1
                                                        when strftime('%w', 'now', 'localtime') = '3' then p.wed = 1
                                                        when strftime('%w', 'now', 'localtime') = '4' then p.thu = 1
                                                        when strftime('%w', 'now', 'localtime') = '5' then p.fri = 1
                                                        when strftime('%w', 'now', 'localtime') = '6' then p.sat = 1
                                                    end   ) pre on pre.item_code = i.code
                                                    where i.barcode = '" + bar + "'";
            }
            catch
            {
                return "";
            }
        }
        private void dataGridView_item_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // กดลบ
                    if (e.ColumnIndex == dataGridView_item.Columns["delete"]!.Index)
                    {
                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {

                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                         "SET void = true, " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "' " +
                                                         "WHERE id = " + dataGridView_item.Rows[e.RowIndex].Cells["id_temp"].Value!.ToString()!;
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }
                        // ถ้าเป็นสินค้าโปร จะคำนวนใหม่
                        if (dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString() != "")
                        {

                            Class_Sale.Pro(
                                dataGridView_item.Rows[e.RowIndex].Cells["pro_id"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["criterion_type"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["criterion_value"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["offer_type"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["offer_value"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["discount_type"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["repeat"].Value!.ToString()!,
                                dataGridView_item.Rows[e.RowIndex].Cells["item_code"].Value!.ToString()!);


                        }
                        // คำนวนส่วนลดสมาชิก
                        if (id_member != string.Empty)
                        {
                            Class_Sale.update_member(id_member, percent_discount_member);
                        }

                        // แสดงผลรวมด้านล่าง
                        // จำนวนทั้งหมด
                        sum_total();

                        dataGridView_item.Rows.RemoveAt(e.RowIndex);
                        // แสดงจำนวนบรรทัดสินค้า
                        dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();
                    }
                    // แก้ไขจำนวน
                    else if (e.ColumnIndex == dataGridView_item.Columns["edit"]!.Index)
                    {
                        // แก้ไขจะใช้ form เดียวกับ weight
                        W_image_bar = dataGridView_item.Rows[e.RowIndex].Cells["small_barcode"].Value!.ToString()!;
                        W_item_bar = dataGridView_item.Rows[e.RowIndex].Cells["barcode"].Value!.ToString()!;
                        W_item_name = dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Value!.ToString()!;
                        W_item_unit = dataGridView_item.Rows[e.RowIndex].Cells["item_unit"].Value!.ToString()!;
                        W_item_price = dataGridView_item.Rows[e.RowIndex].Cells["item_price"].Value!.ToString()!;

                        Form_Item_Weight form_Item_Weight = new Form_Item_Weight();
                        form_Item_Weight.ShowDialog(this);
                        form_Item_Weight.StartPosition = FormStartPosition.CenterParent;
                        if (!form_Item_Weight.exit)
                        {


                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {
                                    // ตรวจสอบ sale negative
                                    cmd_sqlite.CommandText = @"SELECT i.sale_negative,i.code,i.small_qty,i.qty_small
                                                from(
                                                SELECT small_barcode,small_barcode as barcode,code,group_main,group_sub,
                                                    name,small_unit as unit,small_price as price,small_qty,1 as qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat
                                                    from Item 
                                                    where status = 1                                          
                                                    union all 
                                                    SELECT small_barcode,medium_barcode,code,group_main,group_sub,
                                                    name,medium_unit,medium_price ,small_qty,medium_qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat
                                                    from Item 
                                                    where status = 1                                        
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT small_barcode,large_barcode,code,group_main,group_sub,
                                                    name,large_unit,large_price ,small_qty,large_qty_small,
                                                    sale_negative,item_weight,effective_promotion,effective_member,sale_vat
                                                    from Item 
                                                    where status = 1                                       
                                                    and large_barcode <> '') i
                                                where i.barcode = '" + W_item_bar + "'";
                                    SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                                    System.Data.DataTable dt = new System.Data.DataTable();
                                    dt.Load(reader);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (!Convert.ToBoolean(dt.Rows[0]["sale_negative"]))
                                        {
                                            string small_qty = dt.Rows[0]["small_qty"].ToString()!,
                                                   qty_small = dt.Rows[0]["qty_small"].ToString()!;
                                            // ตรวจสอบไม่ติดลบ
                                            cmd_sqlite.CommandText = @"SELECT coalesce(sum(ibt.item_qty*ibt.qty_small),0) as qty
                                                                      from Invoice_Body_Temp ibt 
                                                                      where ibt.void = false and ibt.hole = false and ibt.item_code = " + dt.Rows[0]["code"].ToString()!;
                                            reader = cmd_sqlite.ExecuteReader();
                                            dt = new System.Data.DataTable();
                                            dt.Load(reader);
                                            if (dt.Rows.Count > 0)
                                            {
                                                //  ผลรวม ลบจำนวนเดิม บวกจำนวนใหม่

                                                if (Convert.ToDouble(dt.Rows[0]["qty"]) - (Convert.ToDouble(dataGridView_item.Rows[e.RowIndex].Cells["item_qty"].Value!.ToString()!) * Convert.ToDouble(qty_small))
                                                    + (Convert.ToDouble(form_Item_Weight.weight.Replace(",", "")) * Convert.ToDouble(qty_small)) > Convert.ToDouble(small_qty))
                                                {
                                                    MessageBox.Show(dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Value!.ToString()! + Environment.NewLine + "จำนวนคงเหลือ : " + dt.Rows[0]["qty"].ToString(), "คงเหลือไม่มีเพียงพอขาย", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    return;
                                                }
                                            }

                                        }
                                    }

                                    // จะต้อง update temp ด้วย

                                    cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                             "SET item_qty = " + form_Item_Weight.weight.Replace(",", "") + ", " +
                                                             "item_price_sum = " + form_Item_Weight.weight.Replace(",", "") + " * item_price, " +
                                                             "price_net = (" + form_Item_Weight.weight.Replace(",", "") + " * item_price) - discount_promotion - discount_member, " +
                                                             "updated_date = datetime('now', 'localtime'), " +
                                                             "updated_by = '" + Class_Parameter.User_Login + "' " +
                                                             "WHERE id = " + dataGridView_item.Rows[e.RowIndex].Cells["id_temp"].Value!.ToString()!;
                                    cmd_sqlite.ExecuteNonQuery();
                                }
                            }

                            // ถ้าเป็นสินค้าโปร จะคำนวนใหม่

                            if (dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString() != "")
                            {
                                Class_Sale.Pro(
                                    dataGridView_item.Rows[e.RowIndex].Cells["pro_id"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["criterion_type"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["criterion_value"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["offer_type"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["offer_value"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["discount_type"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["repeat"].Value!.ToString()!,
                                    dataGridView_item.Rows[e.RowIndex].Cells["item_code"].Value!.ToString()!);

                            }
                            // คำนวนส่วนลดสมาชิก
                            if (id_member != string.Empty)
                            {
                                Class_Sale.update_member(id_member, percent_discount_member);
                            }
                            // แสดงผลรวมด้านล่าง
                            // จำนวนทั้งหมด
                            sum_total();

                            // แสดงในตาราง
                            dataGridView_item.Rows[e.RowIndex].Cells["item_qty"].Value = form_Item_Weight.weight;
                            dataGridView_item.Rows[e.RowIndex].Cells["item_price_total"].Value =
                            (Convert.ToDouble(form_Item_Weight.weight.Replace(",", "")) * Convert.ToDouble(W_item_price.Replace(",", ""))).ToString("#,##0.00");
                        }
                    }
                    // กดดูโปร
                    else if (e.ColumnIndex == dataGridView_item.Columns["pro"]!.Index &&
                       dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString()! != string.Empty)
                    {

                        Form_Check_Promotion.pro_id = dataGridView_item.Rows[e.RowIndex].Cells["pro_id"].Value!.ToString()!;
                        Form_Promotion_Detail form_Promotion_Detail = new Form_Promotion_Detail();
                        form_Promotion_Detail.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_hole_bill_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hole_bill) // กด พักบิล
                {
                    if (dataGridView_item.RowCount > 0)
                    {
                        button_hole_bill.Enabled = false;
                        Class_Sale.update_hole_temp(true);

                        clear_bill();
                        // เปลี่ยนข้อความปุ่ม
                        button_hole_bill.Text = "เรียกบิล";
                        button_hole_bill.BackColor = Color.FromArgb(255, 192, 192);

                        button_hole_bill.Enabled = true;
                        hole_bill = true;
                    }


                }
                else // กด เรียกบิล
                {
                    // ถ้าไม่มีสินค้าจะสามารถเรียกบิลที่พักได้
                    if (dataGridView_item.RowCount == 0)
                    {
                        // ถ้าไม่มีการเลือกสมาชิกไว้
                        if (id_member == string.Empty)
                        {
                            button_hole_bill.Enabled = false;
                            dataGridView_item.Enabled = false;
                            Class_Parameter.runbackground = true;
                            backgroundWorker_bill_hole.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถเรียกบิลที่พักได้ !!" + Environment.NewLine + "เนื่องจากมีการเลือกสมาชิกไว้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถเรียกบิลที่พักได้ !!" + Environment.NewLine + "เนื่องจากมีสินค้าในรายการ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_bill_hole_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update hole เป็น false ยกเลิกการพัก
                        Class_Sale.update_hole_temp(false);

                        // ดึงข้อมูลมาใส่ตาราง ดึงทั้งหมด แล้วคัดสินค้าที่ไม่ลบ
                        cmd_sqlite.CommandText = @"SELECT id,void,return,small_barcode,item_barcode,
item_code,item_name,item_qty,item_unit,item_price,
item_price_sum,small_qty,qty_small,
pro_id,pro_type,pro_desc,
criterion_type,criterion_value,
offer_type,offer_value,
discount_type,repeat,
discount_promotion,
id_member,
percent_discount_member,
discount_member,
discount_custom,
discount_point,
discount_round,
price_net,
price_non_vat,
price_vat,
vat,
sale_vat,
premium,
effective_member,
hole FROM Invoice_Body_Temp where void = false ";
                        SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                        System.Data.DataTable dt_temp = new System.Data.DataTable();
                        dt_temp.Load(reader);
                        if (dt_temp.Rows.Count > 0)
                        {
                            Image pro;
                            for (int i = 0; i < dt_temp.Rows.Count; i++)
                            {
                                pro = new Bitmap(30, 30);

                                if (dt_temp.Rows[i]["pro_type"].ToString() != string.Empty)
                                {
                                    pro = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(30, 30));

                                }

                                dataGridView_item.Rows.Add(
                                dt_temp.Rows[i]["id"].ToString()!,
                                dt_temp.Rows[i]["item_code"].ToString()!,
                                dt_temp.Rows[i]["small_barcode"].ToString()!,
                                dt_temp.Rows[i]["item_barcode"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30)),
                                dt_temp.Rows[i]["item_name"].ToString()!,
                                Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(30, 30)),
                                Convert.ToDouble(dt_temp.Rows[i]["item_qty"]).ToString("#,##0.000"),
                                dt_temp.Rows[i]["item_unit"].ToString()!,
                                Convert.ToDouble(dt_temp.Rows[i]["item_price"]).ToString("#,##0.00"),
                                (Convert.ToDouble(dt_temp.Rows[i]["item_qty"]) * Convert.ToDouble(dt_temp.Rows[i]["item_price"])).ToString("#,##0.00"),
                                pro,
                                dt_temp.Rows[i]["pro_id"].ToString()!,
                                dt_temp.Rows[i]["pro_type"].ToString()!,
                                dt_temp.Rows[i]["pro_desc"].ToString()!,
                                dt_temp.Rows[i]["criterion_type"].ToString()!,
                                dt_temp.Rows[i]["criterion_value"].ToString()!,
                                dt_temp.Rows[i]["offer_type"].ToString()!,
                                dt_temp.Rows[i]["offer_value"].ToString()!,
                                dt_temp.Rows[i]["discount_type"].ToString()!,
                                dt_temp.Rows[i]["repeat"].ToString()!,
                                dt_temp.Rows[i]["premium"].ToString()!,
                                dt_temp.Rows[i]["effective_member"].ToString()!, // effective_member
                                dt_temp.Rows[i]["sale_vat"].ToString()!
                                );

                                dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();

                                if (id_member == string.Empty && dt_temp.Rows[i]["id_member"].ToString()! != string.Empty)
                                {
                                    id_member = dt_temp.Rows[i]["id_member"].ToString()!;
                                    percent_discount_member = dt_temp.Rows[i]["percent_discount_member"].ToString()!;
                                }

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

        private void backgroundWorker_bill_hole_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                // เลือกบรรทัดสุดท้าย
                if (dataGridView_item.RowCount > 0)
                {
                    dataGridView_item.FirstDisplayedScrollingRowIndex = dataGridView_item.RowCount - 1;

                    dataGridView_item.Rows[dataGridView_item.RowCount - 1].Selected = true;
                }


                // ดึงสมาชิก
                if (id_member != "")
                {
                    select_member(id_member);
                }
                // ค้นหา sum ใหม่

                sum_total();

                dataGridView_item.Enabled = true;
                // เปลี่ยนข้อความปุ่ม
                button_hole_bill.Text = "พักบิล";
                button_hole_bill.BackColor = Color.White;
                hole_bill = false;

                button_hole_bill.Enabled = true;
                Class_Parameter.runbackground = false;
            }
            catch (Exception ex)
            {
                Class_Parameter.runbackground = false;
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Button_MouseEnter(object? sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender!;
                button.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Bold); // สีที่ต้องการตอนชี้
                                                                                                              // button.ForeColor = Color.;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseLeave(object? sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender!;
                button.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Regular); // 
                                                                                                                 //  button.ForeColor = Color.FromName(Class_Parameter.font_color);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_style(System.Windows.Forms.Button b, string bar)
        {
            try
            {
                b.Dock = DockStyle.Fill;
                b.UseVisualStyleBackColor = true;
                b.Font = new System.Drawing.Font("Segoe UI", Class_Parameter.font_size, FontStyle.Regular);
                //  b.BackColor = b_backcolor;
                b.BackColor = Color.FromName(Class_Parameter.button_color);
                b.ForeColor = Color.FromName(Class_Parameter.font_color);

                // b.FlatStyle = FlatStyle.Flat;
                // b.FlatAppearance.BorderSize = 0;

                b.Image = null;
                // ค้นหาภาพ
                if (Class_Parameter.image_type != "ไม่มี")
                {
                    if (System.IO.File.Exists(Form_Login.item_path + @"\" + bar + ".Png"))
                    {
                        using (FileStream bitmapFile = new FileStream(Form_Login.item_path + @"\" + bar + ".Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (Bitmap bitmap = new Bitmap(bitmapFile))
                            {
                                if (Class_Parameter.image_type == "กลาง")
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size((b.Height - 10) * bitmap.Width / bitmap.Height, b.Height - 10));
                                    if (b.Image.Width > b.Width)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size(b.Width - 10, (b.Width - 10) * b.Image.Height / b.Image.Width));
                                    }
                                    b.TextImageRelation = TextImageRelation.Overlay;
                                    b.ImageAlign = ContentAlignment.MiddleCenter;
                                    b.TextAlign = ContentAlignment.MiddleCenter;
                                }
                                else if (Class_Parameter.image_type == "บน")
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size(b.Height / 2 * bitmap.Width / bitmap.Height, b.Height / 2));
                                    if (b.Image.Width > b.Width)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size(b.Width, b.Width * b.Image.Height / b.Image.Width));
                                    }
                                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                                    b.ImageAlign = ContentAlignment.TopCenter;
                                    b.TextAlign = ContentAlignment.BottomCenter;
                                }
                                else // ด้านซ้าย
                                {
                                    b.Image = Class_Image.resizeImage(bitmap, new Size(b.Width / 2, b.Width / 2 * bitmap.Height / bitmap.Width));
                                    if (b.Image.Height > b.Height)
                                    {
                                        b.Image = Class_Image.resizeImage(b.Image, new Size((b.Height - 10) * (b.Image.Width / b.Image.Height), b.Height - 10));
                                    }
                                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                                    b.ImageAlign = ContentAlignment.MiddleLeft;
                                    b.TextAlign = ContentAlignment.MiddleLeft;
                                }
                            }
                        }
                    }
                    else
                    {

                        if (Class_Parameter.image_type == "กลาง")
                        {
                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size((b.Height - 10) * Properties.Resources.picture_dark.Width / Properties.Resources.picture_dark.Height, b.Height - 10));
                            if (b.Image.Width > b.Width)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width - 10, (b.Width - 10) * b.Image.Height / b.Image.Width));
                            }
                            b.TextImageRelation = TextImageRelation.Overlay;
                            b.ImageAlign = ContentAlignment.MiddleCenter;
                            b.TextAlign = ContentAlignment.MiddleCenter;
                        }
                        else if (Class_Parameter.image_type == "บน")
                        {

                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Height / 2 * Properties.Resources.picture_dark.Width / Properties.Resources.picture_dark.Height, b.Height / 2));
                            if (b.Image.Width > b.Width)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width, b.Width * b.Image.Height / b.Image.Width));

                            }
                            b.TextImageRelation = TextImageRelation.ImageAboveText;
                            b.ImageAlign = ContentAlignment.TopCenter;
                            b.TextAlign = ContentAlignment.BottomCenter;


                        }
                        else // ด้านซ้าย
                        {
                            b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size(b.Width / 2, b.Width / 2 * Properties.Resources.picture_dark.Height / Properties.Resources.picture_dark.Width));
                            if (b.Image.Height > b.Height)
                            {
                                b.Image = Class_Image.resizeImage(Properties.Resources.picture_dark, new Size((b.Height - 10) * b.Image.Width / b.Image.Height, b.Height - 10));
                            }
                            b.TextImageRelation = TextImageRelation.ImageBeforeText;
                            b.ImageAlign = ContentAlignment.MiddleLeft;
                            b.TextAlign = ContentAlignment.MiddleLeft;
                        }

                    }
                }
                else
                {
                    b.TextImageRelation = TextImageRelation.Overlay;
                    b.ImageAlign = ContentAlignment.MiddleCenter;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form_Sale_Resize(object sender, EventArgs e)
        {
            try
            {


                pictureBox_load_hotkey.Location = new System.Drawing.Point(
             panel_hotkey.Location.X + (panel_hotkey.Width / 2) - (pictureBox_load_hotkey.Width / 2),
             panel_hotkey.Location.Y + (panel_hotkey.Height / 2) - (pictureBox_load_hotkey.Height / 2));



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void hotkey_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size + 2, FontStyle.Bold);


            }
            catch
            {

            }
        }
        private void hotkey_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                b.Font = new System.Drawing.Font(b.Font.FontFamily, b.Font.Size - 2, FontStyle.Regular);

            }
            catch
            {

            }
        }
        private void hotkey_click(object sender, EventArgs e)
        {
            try
            {

                System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
                if (b.Name == "button_hotkey_1" && Class_Parameter.hotkey_pag != 1) // 1
                {
                    Class_Parameter.hotkey_pag = 1;

                    button_hotkey_1.FlatStyle = FlatStyle.Standard;
                    button_hotkey_1.ForeColor = Color.Black;
                    button_hotkey_1.BackColor = Color.White;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    button_hotkey_2.ForeColor = Color.Gray;
                    button_hotkey_2.BackColor = Color.Transparent;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    button_hotkey_3.ForeColor = Color.Gray;
                    button_hotkey_3.BackColor = Color.Transparent;

                    button_last_sale.FlatStyle = FlatStyle.Flat;
                    button_last_sale.ForeColor = Color.Gray;
                    button_last_sale.BackColor = Color.Transparent;

                    button_hot_sale.FlatStyle = FlatStyle.Flat;
                    button_hot_sale.ForeColor = Color.Gray;
                    button_hot_sale.BackColor = Color.Transparent;

                    sort_hotkey();

                }
                else if (b.Name == "button_hotkey_2" && Class_Parameter.hotkey_pag != 2) // 2
                {
                    Class_Parameter.hotkey_pag = 2;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    button_hotkey_1.ForeColor = Color.Gray;
                    button_hotkey_1.BackColor = Color.Transparent;

                    button_hotkey_2.FlatStyle = FlatStyle.Standard;
                    button_hotkey_2.ForeColor = Color.Black;
                    button_hotkey_2.BackColor = Color.White;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    button_hotkey_3.ForeColor = Color.Gray;
                    button_hotkey_3.BackColor = Color.Transparent;

                    button_last_sale.FlatStyle = FlatStyle.Flat;
                    button_last_sale.ForeColor = Color.Gray;
                    button_last_sale.BackColor = Color.Transparent;

                    button_hot_sale.FlatStyle = FlatStyle.Flat;
                    button_hot_sale.ForeColor = Color.Gray;
                    button_hot_sale.BackColor = Color.Transparent;

                    sort_hotkey();
                }
                else if (b.Name == "button_hotkey_3" && Class_Parameter.hotkey_pag != 3)// 3
                {
                    Class_Parameter.hotkey_pag = 3;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    button_hotkey_1.ForeColor = Color.Gray;
                    button_hotkey_1.BackColor = Color.Transparent;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    button_hotkey_2.ForeColor = Color.Gray;
                    button_hotkey_2.BackColor = Color.Transparent;

                    button_hotkey_3.FlatStyle = FlatStyle.Standard;
                    button_hotkey_3.ForeColor = Color.Black;
                    button_hotkey_3.BackColor = Color.White;

                    button_last_sale.FlatStyle = FlatStyle.Flat;
                    button_last_sale.ForeColor = Color.Gray;
                    button_last_sale.BackColor = Color.Transparent;

                    button_hot_sale.FlatStyle = FlatStyle.Flat;
                    button_hot_sale.ForeColor = Color.Gray;
                    button_hot_sale.BackColor = Color.Transparent;

                    sort_hotkey();
                }
                else if (b.Name == "button_last_sale" && Class_Parameter.hotkey_pag != 4)// 4
                {
                    Class_Parameter.hotkey_pag = 4;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    button_hotkey_1.ForeColor = Color.Gray;
                    button_hotkey_1.BackColor = Color.Transparent;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    button_hotkey_2.ForeColor = Color.Gray;
                    button_hotkey_2.BackColor = Color.Transparent;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    button_hotkey_3.ForeColor = Color.Gray;
                    button_hotkey_3.BackColor = Color.Transparent;

                    button_last_sale.FlatStyle = FlatStyle.Standard;
                    button_last_sale.ForeColor = Color.Black;
                    button_last_sale.BackColor = Color.White;

                    button_hot_sale.FlatStyle = FlatStyle.Flat;
                    button_hot_sale.ForeColor = Color.Gray;
                    button_hot_sale.BackColor = Color.Transparent;

                    sort_hotkey();
                }
                else if (b.Name == "button_hot_sale" && Class_Parameter.hotkey_pag != 5)// 5
                {
                    Class_Parameter.hotkey_pag = 5;

                    button_hotkey_1.FlatStyle = FlatStyle.Flat;
                    button_hotkey_1.ForeColor = Color.Gray;
                    button_hotkey_1.BackColor = Color.Transparent;

                    button_hotkey_2.FlatStyle = FlatStyle.Flat;
                    button_hotkey_2.ForeColor = Color.Gray;
                    button_hotkey_2.BackColor = Color.Transparent;

                    button_hotkey_3.FlatStyle = FlatStyle.Flat;
                    button_hotkey_3.ForeColor = Color.Gray;
                    button_hotkey_3.BackColor = Color.Transparent;

                    button_last_sale.FlatStyle = FlatStyle.Flat;
                    button_last_sale.ForeColor = Color.Gray;
                    button_last_sale.BackColor = Color.Transparent;

                    button_hot_sale.FlatStyle = FlatStyle.Standard;
                    button_hot_sale.ForeColor = Color.Black;
                    button_hot_sale.BackColor = Color.White;

                    sort_hotkey();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pay_enter(object sender, EventArgs e)
        {
            try
            {
                button_pay.Font = new System.Drawing.Font(button_pay.Font.FontFamily, button_pay.Font.Size + 4, button_pay.Font.Style);
            }
            catch
            {

            }
        }
        private void pay_leave(object sender, EventArgs e)
        {
            try
            {
                button_pay.Font = new System.Drawing.Font(button_pay.Font.FontFamily, button_pay.Font.Size - 4, button_pay.Font.Style);

            }
            catch
            {

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

                    dataGridView_item.Rows[e.RowIndex].Cells["delete"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(35, 35));
                    dataGridView_item.Rows[e.RowIndex].Cells["edit"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(35, 35));
                    if (dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString() != string.Empty)
                    {
                        dataGridView_item.Rows[e.RowIndex].Cells["pro"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(35, 35));
                    }


                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
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
                    dataGridView_item.Rows[e.RowIndex].Cells["item_name"].Style.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); //  

                    dataGridView_item.Rows[e.RowIndex].Cells["delete"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.uncheck, new Size(30, 30));
                    dataGridView_item.Rows[e.RowIndex].Cells["edit"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.edits, new Size(30, 30));

                    if (dataGridView_item.Rows[e.RowIndex].Cells["pro_type"].Value!.ToString() != string.Empty)
                    {
                        dataGridView_item.Rows[e.RowIndex].Cells["pro"].Value = Class_Image.resizeImage(Ppos.Properties.Resources.P, new Size(30, 30));
                    }

                    //  dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button_sale_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Select_Item form_Select_Item = new Form_Select_Item();
                form_Select_Item.Size = new Size(this.Width / 2, this.Height * 2 / 3);
                form_Select_Item.ShowDialog(this);
                if (!form_Select_Item.exit)
                {
                    textBox_search.Focus();
                    if (textBox_search.Text != string.Empty)
                    {
                        textBox_search.Text += "*";
                    }
                    textBox_search.Text += form_Select_Item.barcode;
                    SendKeys.Send("{ENTER}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_member_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Select_Member form_Select_Member = new Form_Select_Member();
                form_Select_Member.Size = new Size(this.Width / 2, this.Height * 2 / 3);
                form_Select_Member.ShowDialog(this);
                // ถ้าเพิ่มสมาชิก
                if (form_Select_Member.add_member)
                {
                    // เปิดหน้าชื่อสมาชิก
                    customGroupBox_member.Visible = true;
                    tableLayoutPanel_bill.RowStyles[1].Height = 70;
                }
                // ถ้าเลือกสมาชิก
                if (!form_Select_Member.exit)
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT id,phone,sex,nick_name,first_name,last_name,
                                                               address,sub_district,district,province,postal_code,
                                                               discount_percent,sale_total,sale_ineffective_member,
                                                               sale_effective_member,sale_per_point,
                                                               point_increase,point_decrease,point_balance
                                                               FROM Member WHERE status = true and id = " + form_Select_Member.id_member;
                            SQLiteDataReader reader = cmd_sqlite.ExecuteReader();
                            dt = new System.Data.DataTable();
                            dt.Load(reader);
                            if (dt.Rows.Count > 0)
                            {
                                string nick_name = "";
                                if (dt.Rows[0]["nick_name"].ToString() != String.Empty)
                                {
                                    nick_name = " (" + dt.Rows[0]["nick_name"].ToString() + ")";
                                }
                                id_member = dt.Rows[0]["id"].ToString()!;
                                percent_discount_member = dt.Rows[0]["discount_percent"].ToString()!;

                                pictureBox_delete_member.Visible = true;
                                textBox_member.Text = "  " + dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString() + nick_name +
                                      " (" + Convert.ToDouble(dt.Rows[0]["point_balance"]).ToString("#,##0") + ")";

                                Class_Sale.update_member(id_member, percent_discount_member);

                                // แสดงผลรวมด้านล่าง
                                sum_total();

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


        private void sum_bill_enter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                // label.ForeColor = Color.Lime;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size + 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void sum_bill_leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                // label.ForeColor = Color.Black;
                label.Font = new System.Drawing.Font(label.Font.FontFamily, label.Font.Size - 2, label.Font.Style);
            }
            catch
            {

            }
        }

        private void pictureBox_delete_member_Click(object sender, EventArgs e)
        {
            try
            {
                id_member = "";
                percent_discount_member = "0";
                textBox_member.Text = "";
                pictureBox_delete_member.Visible = false;

                // update member temp
                Class_Sale.update_member("", "0");

                // คำนวนใหม่
                sum_total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button_sale_display_Click(object sender, EventArgs e)
        {
            try
            {
                Class_Parameter.sale_hotkey_left = !Class_Parameter.sale_hotkey_left;
                // ปรับตำแหน่งซ้ายขวก
                if (Class_Parameter.sale_hotkey_left)
                {
                    // hotkey อยู่ทางซ้าย

                    button_sale_display.Text = "<";

                    tableLayoutPanel_back.Controls.Clear();

                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 0, 0);
                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_right, 1, 0);

                }
                else
                {
                    // hotkey อยู่ทางขวา

                    button_sale_display.Text = ">";

                    tableLayoutPanel_back.Controls.Clear();

                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_right, 0, 0);
                    tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 1, 0);
                }

                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update
                        cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                 "updated_date = datetime('now', 'localtime'), " +
                                                 "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                 "value = '" + Class_Parameter.sale_hotkey_left.ToString() + "' " +
                                                 "where title = 'sale_hotkey_left'";
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void sum_total()
        {
            try
            {
                // แสดงผลรวมด้านล่าง
                // จำนวนทั้งหมด
                string[] result = Class_Sale.sum_price();
                label_sum_qty.Text = Convert.ToDouble(result[0]).ToString("#,##0.000");
                label_sum_price.Text = Convert.ToDouble(result[1]).ToString("#,##0.00");
                label_dis_pro.Text = Convert.ToDouble(result[2]).ToString("#,##0.00");
                label_dis_member.Text = Convert.ToDouble(result[3]).ToString("#,##0.00");
                label_dis_round.Text = Convert.ToDouble(result[4]).ToString("0.00");
                label_price_net.Text = Convert.ToDouble(result[5]).ToString("#,##0.00");

                discount_round = Convert.ToDouble(result[4]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView_item_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                // 1. กำหนดรูปแบบข้อความ (ลำดับบรรทัดเริ่มที่ 1)
                string rowNumber = (e.RowIndex + 1).ToString();

                // 2. ตั้งค่าฟอนต์และสีของตัวเลข (ใช้ฟอนต์เดียวกับ DataGridView)
                //System.Drawing.Font font = this.dataGridView_item.Font;
                System.Drawing.Font font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular);
                Brush brush = SystemBrushes.ControlText;


                // 3. คำนวณตำแหน่งสำหรับวาดตัวเลขให้อยู่กึ่งกลางของ RowHeader
                // คำนวณขนาดของข้อความตัวเลข
                SizeF textSize = e.Graphics.MeasureString(rowNumber, font);

                // หาพิกัด X (ขยับมาทางขวาของขอบ RowHeader เล็กน้อย)
                float x = e.RowBounds.Left + (this.dataGridView_item.RowHeadersWidth - textSize.Width) / 2;

                // หาพิกัด Y (กึ่งกลางความสูงของบรรทัดนั้นๆ)
                float y = e.RowBounds.Top + (e.RowBounds.Height - textSize.Height) / 2;

                // 4. วาดตัวเลขลงบน RowHeader
                e.Graphics.DrawString(rowNumber, font, brush, x + 5, y);
            }
            catch
            {

            }
        }
        private void button_pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_item.RowCount > 0 &&
                    label_price_net.Text != "0.00" &&
                    parentPanel.Controls.OfType<Form>().Count() == 1)
                {
                    // ส่งค่าให้ หน้า ชำระเงิน
                    price_net = label_price_net.Text.Split(".")[0];

                    Form_Pay form_Pay = new Form_Pay();


                    form_Pay.TopLevel = false;
                    parentPanel.Controls.Add(form_Pay);
                    form_Pay.BringToFront();
                  //  form_Pay.Size = new Size(this.Width, this.Height);
                    form_Pay.Dock = DockStyle.Fill;


                    // ดักจับ Event เมื่อ Form2 ปิดลง
                    form_Pay.FormClosed += (s, args) =>
                    {
                        textBox_search.Focus();      // สั่ง Focus ไปที่ TextBox ที่ต้องการ
                        // ถ้ากดตกลงจะทำการเครียเริ่มบิลใหม่
                        if (!form_Pay.exit)
                        {
                            // เริ่ม id แสดงผลใน datagridview ใหม่
                            Class_Parameter.id_body_temp = Class_Sale.id_invoid_body_temp();

                            clear_bill();
                            if (Class_Parameter.hotkey_pag == 4 || Class_Parameter.hotkey_pag == 5) // ถ้าเลือก pag ล่าสุดหรือขายดี
                            {
                                sort_hotkey();
                            }
                        }
                     
        
                       

                    };

                    form_Pay.Show();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clear_bill()
        {
            try
            {


                dataGridView_item.Rows.Clear();
                // แสดงจำนวนบรรทัดสินค้า
                dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();

                //sum_qty = 0;
                label_sum_qty.Text = "0.000";

                // sum_price = 0;
                label_sum_price.Text = "0.00";

                label_dis_pro.Text = "0.00";
                // tableLayoutPanel_discount_pro.Visible = false;

                label_dis_member.Text = "0.00";
                // tableLayoutPanel_discount_member.Visible = false;

                label_price_net.Text = "0.00";

                label_dis_round.Text = "0.00";

                // ถ้ามีสมาชิกจำทำการลบ
                if (id_member != string.Empty)
                {
                    pictureBox_delete_member_Click(null!, EventArgs.Empty);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void panel_bottom_bill_MouseEnter(object sender, EventArgs e)
        {
            panel_bottom_bill.BackColor = Color.Lime;
        }

        private void panel_bottom_bill_MouseLeave(object sender, EventArgs e)
        {
            panel_bottom_bill.BackColor = Color.Cyan;
        }

        private void title_doubleclick(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
                        if (label.Name == "label_sum_qty_title")
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'visible_sum_qty'";
                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_sum_qty = false;

                            tableLayoutPanel_sum_qty.Visible = false;
                        }
                        else if (label.Name == "label_sum_price_title")
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'visible_sum_price'";
                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_sum_price = false;

                            tableLayoutPanel_sum_price.Visible = false;
                        }
                        else if (label.Name == "label_dis_pro_title")
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'visible_dis_pro'";
                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_dis_pro = false;

                            tableLayoutPanel_discount_pro.Visible = false;
                        }
                        else if (label.Name == "label_dis_member_title")
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'visible_dis_member'";
                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_dis_member = false;

                            tableLayoutPanel_discount_member.Visible = false;
                        }
                        else if (label.Name == "label_dis_round_title")
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title = 'visible_dis_round'";

                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_dis_round = false;

                            tableLayoutPanel_discount_round.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_price_title_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        if (tableLayoutPanel_sum_qty.Visible &&
                            tableLayoutPanel_sum_price.Visible &&
                            tableLayoutPanel_discount_pro.Visible &&
                            // tableLayoutPanel_discount_member.Visible &&
                            tableLayoutPanel_discount_round.Visible)
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'False' " +
                                                     "where title in ('visible_sum_qty','visible_sum_price','visible_dis_pro','visible_dis_member','visible_dis_round')";

                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_sum_qty = false;
                            Class_Parameter.visible_sum_price = false;
                            Class_Parameter.visible_dis_pro = false;
                            Class_Parameter.visible_dis_member = false;
                            Class_Parameter.visible_dis_round = false;

                            tableLayoutPanel_sum_qty.Visible = false;
                            tableLayoutPanel_sum_price.Visible = false;
                            tableLayoutPanel_discount_pro.Visible = false;
                            tableLayoutPanel_discount_member.Visible = false;
                            tableLayoutPanel_discount_round.Visible = false;
                        }
                        else
                        {
                            // update
                            cmd_sqlite.CommandText = "UPDATE Sale_Display_Set SET " +
                                                     "updated_date = datetime('now', 'localtime'), " +
                                                     "updated_by = '" + Class_Parameter.User_Login + "', " +
                                                     "value = 'True' " +
                                                     "where title in ('visible_sum_qty','visible_sum_price','visible_dis_pro','visible_dis_member','visible_dis_round')";

                            cmd_sqlite.ExecuteNonQuery();

                            Class_Parameter.visible_sum_qty = true;
                            Class_Parameter.visible_sum_price = true;
                            Class_Parameter.visible_dis_pro = true;
                            Class_Parameter.visible_dis_member = true;
                            Class_Parameter.visible_dis_round = true;

                            tableLayoutPanel_sum_qty.Visible = true;
                            tableLayoutPanel_sum_price.Visible = true;
                            tableLayoutPanel_discount_pro.Visible = true;
                            if (discount_member)
                            {
                                tableLayoutPanel_discount_member.Visible = true;
                            }
                            tableLayoutPanel_discount_round.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_other_Click(object sender, EventArgs e)
        {
            try
            {

                Form_Check form_Check = new Form_Check();


                form_Check.TopLevel = false;
                parentPanel.Controls.Add(form_Check);
                form_Check.BringToFront();
                form_Check.Dock = DockStyle.Fill;
                //form_Check.Size = new Size(this.Width, this.Height);
                // ดักจับ Event เมื่อ Form2 ปิดลง
                form_Check.FormClosed += (s, args) =>
                {
                    textBox_search.Focus();      // สั่ง Focus ไปที่ TextBox ที่ต้องการ

                };
                form_Check.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_delete_all_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView_item.RowCount > 0 )
                {
                    if (MessageBox.Show("ต้องการลบสินค้าทั้งหมดใช่หรือไม่ ?", "แจ้งเตือน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                        {
                            con_sqlite.Open();
                            using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                            {
                                
                                cmd_sqlite.CommandText = "UPDATE Invoice_Body_Temp " +
                                                         "SET void = true, " +
                                                         "updated_date = datetime('now', 'localtime'), " +
                                                         "updated_by = '" + Class_Parameter.User_Login + "' " +
                                                         "WHERE hole = false";
                                cmd_sqlite.ExecuteNonQuery();
                            }
                        }

                        dataGridView_item.Rows.Clear();
                        // แสดงจำนวนบรรทัดสินค้า
                        dataGridView_item.Columns["delete"]!.HeaderText = dataGridView_item.RowCount.ToString();

                        //sum_qty = 0;
                        label_sum_qty.Text = "0.000";

                        // sum_price = 0;
                        label_sum_price.Text = "0.00";

                        label_dis_pro.Text = "0.00";
                        // tableLayoutPanel_discount_pro.Visible = false;

                        label_dis_member.Text = "0.00";
                        // tableLayoutPanel_discount_member.Visible = false;

                        label_price_net.Text = "0.00";

                        label_dis_round.Text = "0.00";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
