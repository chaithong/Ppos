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
    public partial class Form_Check_Item : Form
    {
        int count_search, set_search = 5;
        public Form_Check_Item()
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
                textBox_search.Focus();
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
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                count_search = 0;
                if (textBox_search.Text != string.Empty)
                {

                    if (!timer_search.Enabled)
                    {
                        timer_search.Start();
                    }


                }
                else
                {
                    dataGridView_item.Rows.Clear();
                    if (timer_search.Enabled)
                    {
                        timer_search.Stop();
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
                if (count_search == set_search)
                {
                    count_search = 0;
                    timer_search.Stop();
                    dataGridView_item.Rows.Clear();
                    search_item();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_item()
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = @"SELECT  i.code,i.small_barcode,i.barcode,i.code,i.group_main,i.group_sub,i.name,i.qty,i.unit,i.price,
                                                    coalesce(p.pro_type,pp.pro_type,'') as pro_type,
                                                    coalesce(p.pro_desc,pp.pro_desc,'') as pro_desc,
                                                    coalesce(p.criterion_type,pp.criterion_type,'') as criterion_type,
                                                    coalesce(p.criterion_value,pp.criterion_value,0) as criterion_value,
                                                    coalesce(p.offer_type,pp.offer_type,'') as offer_type,
                                                    coalesce(p.offer_value,pp.offer_value,0) as offer_value,
                                                    coalesce(p.discount_type,pp.discount_type,'') as discount_type,
                                                    coalesce(p.repeat,pp.repeat,'') as repeat,
                                                    coalesce(p.start_date,pp.start_date,'') as start_date,
                                                    coalesce(p.end_date,pp.end_date,'') as end_date,
                                                    coalesce(p.start_time,pp.start_time,'') as start_time,
                                                    coalesce(p.end_time,pp.end_time,'') as end_time,
                                                    coalesce(p.mon,pp.mon,0) as mon,
                                                    coalesce(p.tue,pp.tue,0) as tue,
                                                    coalesce(p.wed,pp.wed,0) as wed,
                                                    coalesce(p.thu,pp.thu,0) as thu,
                                                    coalesce(p.fri,pp.fri,0) as fri,
                                                    coalesce(p.sat,pp.sat,0) as sat,
                                                    coalesce(p.sun,pp.sun,0) as sun,
                                                    coalesce(cast(p.item_code as text),'') as pro,
                                                    coalesce(cast(pp.item_code as text),'') as premium
                                                    from ( 
                                                    SELECT code,small_barcode,small_barcode as barcode,code,group_main,group_sub,name,
                                                    small_qty as qty,small_unit as unit,small_price as price 
                                                    from Item 
                                                    where status = 1                                                  
                                                    union all 
                                                    SELECT code, small_barcode,medium_barcode,code,group_main,group_sub,name,
                                                    medium_qty,medium_unit,medium_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and medium_barcode <> '' 
                                                    union all 
                                                    SELECT code, small_barcode,large_barcode,code,group_main,group_sub,name,
                                                    large_qty,large_unit,large_price 
                                                    from Item 
                                                    where status = 1                                            
                                                    and large_barcode <> '') i 
                                                    left join (SELECT  p.pro_desc,p.pro_id,p.pro_type,p.pro_desc ,
                                                    p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                    pi.item_code,pi.item_name,
                                                    strftime('%d/%m/%Y',p.start_datetime) as start_date,
                                                    strftime('%d/%m/%Y',p.end_datetime) as end_date,
                                                    strftime('%H:%M',p.start_datetime) as start_time,
                                                    strftime('%H:%M',p.end_datetime) as end_time,
                                                    p.mon,p.tue,p.wed,p.thu,p.fri,p.sat,p.sun
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
                                                     end ) p on p.item_code = i.code
                                                     left join (select p.pro_desc,p.pro_id,p.pro_type,p.pro_desc ,
                                                     p.criterion_type,p.criterion_value,p.offer_type,p.offer_value,p.discount_type,p.repeat,
                                                    pp.item_code,pp.item_name,
                                                    strftime('%d/%m/%Y',p.start_datetime) as start_date,
                                                    strftime('%d/%m/%Y',p.end_datetime) as end_date,
                                                    strftime('%H:%M',p.start_datetime) as start_time,
                                                    strftime('%H:%M',p.end_datetime) as end_time,
                                                    p.mon,p.tue,p.wed,p.thu,p.fri,p.sat,p.sun
                                                    from Promotion_Items_Premium pp
                                                    join Promotion p on p.pro_id = pp.pro_id                                                 
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
                                                     end ) pp on pp.item_code = i.code 
                                                    where i.barcode like '%" + textBox_search.Text.Trim() + "%' " +
                                                    "or i.name like '%" + textBox_search.Text.Trim() + "%'";
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        DataTable dt = new System.Data.DataTable();
                        dt.Load(er);
                      //  if (dt.Rows.Count >= 1 && dt.Rows.Count <= 3)
                            if (dt.Rows.Count > 0)
                            {
           
                            dataGridView_item.Rows.Add("บาร์โค้ด :", dt.Rows[0]["barcode"].ToString()!);
                            dataGridView_item.Rows.Add("ชื่อสินค้า :", dt.Rows[0]["name"].ToString()!);
                            dataGridView_item.Rows.Add("คงเหลือ :", Convert.ToDouble(dt.Rows[0]["qty"]).ToString("#,##0.###") + " " + dt.Rows[0]["unit"].ToString()!);
                            dataGridView_item.Rows.Add("ราคา :", Convert.ToDouble(dt.Rows[0]["price"]).ToString("#,##0.##"));
                           
                            if (dt.Rows[0]["pro_type"].ToString()! != string.Empty)
                            {
         
                                if(dt.Rows[0]["pro"].ToString()! != string.Empty)
                                {
                                    dataGridView_item.Rows.Add("สินค้าโปรโมชั่น :", "สินค้าโปร");
                                }
                                else
                                {
                                    dataGridView_item.Rows.Add("สินค้าโปรโมชั่น :", "สินค้าแถม");
                                }
                                dataGridView_item.Rows.Add("ประเภทโปรโมชั่น :", dt.Rows[0]["pro_type"].ToString()!);
                                dataGridView_item.Rows.Add("ชื่อโปรโมชั่น :", dt.Rows[0]["pro_desc"].ToString()!);

                                if(dt.Rows[0]["pro_type"].ToString()! != Class_Parameter.pro_set_item)
                                {
                                    dataGridView_item.Rows.Add("เกณฑ์ส่วนลด :", dt.Rows[0]["criterion_type"].ToString()! + " " + dt.Rows[0]["criterion_value"].ToString()!);
                                }

                                dataGridView_item.Rows.Add("ประเภทส่วนลด :", dt.Rows[0]["offer_type"].ToString()! + " " + dt.Rows[0]["offer_value"].ToString()! +" "+ dt.Rows[0]["discount_type"].ToString()!);
                                dataGridView_item.Rows.Add("การใช้งานต่อบิล :", dt.Rows[0]["repeat"].ToString()!);
                                dataGridView_item.Rows.Add("วันที่ใช้งาน :", dt.Rows[0]["start_date"].ToString()! +" ถึง "+ dt.Rows[0]["end_date"].ToString()!);
                                if( dt.Rows[0]["end_time"].ToString()! != "00:00")
                                {
                                    dataGridView_item.Rows.Add("เวลาใช้งาน :", dt.Rows[0]["start_time"].ToString()! + " ถึง " + dt.Rows[0]["end_time"].ToString()!);
                                }
                                else
                                {
                                    dataGridView_item.Rows.Add("เวลาใช้งาน :", "24 ชั่งโมง");
                                }
                                string day = "";
                                if(Convert.ToBoolean(dt.Rows[0]["mon"]))
                                {
                                    day += "จันทร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["tue"]))
                                {
                                    day += "อังคาร ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["wed"]))
                                {
                                    day += "พุธ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["thu"]))
                                {
                                    day += "พฤหัส ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["fri"]))
                                {
                                    day += "ศุกร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["sat"]))
                                {
                                    day += "เสาร์ ";
                                }
                                if (Convert.ToBoolean(dt.Rows[0]["sun"]))
                                {
                                    day += "อาทิตย์";
                                }
                                // เชค all day
                                if (day == "จันทร์ อังคาร พุธ พฤหัส ศุกร์ เสาร์ อาทิตย์")
                                {
                                    day = "ทุกวัน";
                                }
                                dataGridView_item.Rows.Add("วันใช้งาน :", day);
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




        private void dataGridView_item_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Bold); // สีที่ต้องการตอนชี้

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
            catch
            {

            }
        }

        private void dataGridView_item_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(
                        dataGridView_item.DefaultCellStyle.Font!.FontFamily,
                        dataGridView_item.DefaultCellStyle.Font!.Size,
                        FontStyle.Regular); // สีที่ต้องการตอนไม่ชี้

                    // dataGridView_item.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch
            {

            }
        }

        private void Form_Check_Item_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

      

        private void Form_Check_Item_Shown(object sender, EventArgs e)
        {
            try
            {
                textBox_search.Focus();
            }
            catch
            {

            }
        }

      
    }
}
