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
using AForge.Video;
using AForge.Video.DirectShow;
using Ppos.Class;

namespace Ppos
{
    public partial class Form_Setting_Camera : Form
    {
        int Corners = 30; /// มุม
        string set_device = "";
        public Form_Setting_Camera()
        {
            InitializeComponent();
            try
            {
                this.DoubleBuffered = true;

                // panel_video.Location = new Point((this.Width/2)-(panel_video.Width/2),10);
                customGroupBox_back.Location = new Point((this.Width / 2) - (customGroupBox_back.Width / 2), 10);
                customGroupBox_back.Height = this.Height -100;

                button_test.Image = Class_Image.resizeImage(Ppos.Properties.Resources.camera, new Size(40, 40));
                button_save.Image = Class_Image.resizeImage(Ppos.Properties.Resources.save, new Size(30, 30));
                button_refresh.Image = Class_Image.resizeImage(Ppos.Properties.Resources.Refresh, new Size(50, 50));

                dataGridView_device.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)!.SetValue(dataGridView_device, true, null);

                foreach (DataGridViewColumn column in dataGridView_device.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                new Class_TouchGrid(dataGridView_device);

                dataGridView_device.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
                dataGridView_device.EnableHeadersVisualStyles = false;

                // เรียกใช้ Class ส่วนกลาง แล้วส่ง Panel ของ Form นี้เข้าไป
                Class_Scroll_Panel.EnableDragScroll(panel_detail);
            }
            catch
            {

            }
        }

        private void Form_Setting_Camera_Load(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT device_name FROM Setting_Camera ";
                        using (var reader = cmd_sqlite.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                set_device = reader[0].ToString()!;
                            }
                        }
                    }
                    con_sqlite.Close();
                }
                button_refresh_Click(sender, e);

                // ถ้ามี device ใน DB จะเปิดทันที
               /* for (int i = 0; i < dataGridView_device.RowCount; i++)
                {
                    if (dataGridView_device.Rows[i].Cells["device_names"].Value.ToString() == set_device)
                    {
                        dataGridView_device.Rows[i].Selected = true;

                        textBox_device.Text = set_device;
                        textBox_device.BackColor = Color.Lime;
                        pictureBox_video.BackColor = Color.Lime;
                        button_save.BackColor = Color.Lime;

                        pictureBox_video.Image = null;

                        if (!string.IsNullOrEmpty(GetMonikerStringByDeviceName(set_device)))
                        {
                            Form_Main.videoSource = new VideoCaptureDevice(GetMonikerStringByDeviceName(set_device));

                            // ผูก Event ข้อมูลภาพใหม่เข้ากับฟังก์ชันวาดรูป
                            Form_Main.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                            Form_Main.videoSource.Start(); // เริ่มส่งสัญญาณวิดีโอ
                        }

                        break;
                    }
                }*/
            }
            catch
            {

            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            try
            {

                Form_Main.videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                dataGridView_device.Rows.Clear();
                button_test.Enabled = false;
                if (Form_Main.videoDevices.Count > 0)
                {
                    foreach (FilterInfo device in Form_Main.videoDevices)
                    {
                        dataGridView_device.Rows.Add(device.Name);
                        if (device.Name == set_device)
                        {
                            dataGridView_device.Rows[dataGridView_device.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.Cyan;
                        }

                    }
                    dataGridView_device.ClearSelection();


                }

                //////
            }
            catch
            {

            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            try
            {


                if (Form_Main.videoSource != null && Form_Main.videoSource.IsRunning)
                {
                    Form_Main.videoSource.SignalToStop(); // ส่งสัญญาณหยุดทำงาน
                    Form_Main.videoSource.WaitForStop();   // รอจนกระทั่งระบบหยุดเคลียร์ Thread ทั้งหมด

                }
                // เคลียภาพ
                pictureBox_video.Image = null;
                // ดึงค่า MonikerString ของกล้องที่เลือกมาใช้งาน
                string cameraName = dataGridView_device.Rows[dataGridView_device.CurrentRow!.Index].Cells["device_names"].Value!.ToString()!;
                // ใส่ชื่อ device ใน textbox
                textBox_device.Text = cameraName;
                button_save.Enabled = true;
                if (cameraName == set_device)
                {
                   // textBox_device.BackColor = Color.Lime;
                   // pictureBox_video.BackColor = Color.Lime;

                   // button_save.BackColor = Color.Lime;
                    button_save.Enabled = false;
                }
                else
                {
                   // textBox_device.BackColor = Color.White;
                  //  pictureBox_video.BackColor = Color.White;

                   // button_save.BackColor = Color.White;
                    button_save.Enabled = true;
                }

                if (!string.IsNullOrEmpty(GetMonikerStringByDeviceName(cameraName)))
                {
                    Form_Main.videoSource = new VideoCaptureDevice(GetMonikerStringByDeviceName(cameraName));

                    // ผูก Event ข้อมูลภาพใหม่เข้ากับฟังก์ชันวาดรูป
                    Form_Main.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    Form_Main.videoSource.Start(); // เริ่มส่งสัญญาณวิดีโอ
                }

            }
            catch
            {

            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_device.Text != "")
                {
                    button_save.Enabled = false;
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = "UPDATE Setting_Camera SET device_name = '" + textBox_device.Text + "', " +
                                              "updated_date = datetime('now', 'localtime'), " +
                                              "updated_by = '" + Class_Parameter.User_Login + "' ";
                            cmd_sqlite.ExecuteNonQuery();
                            // เปลี่ยนค่า parameter
                            Class_Parameter.device_name = textBox_device.Text;
                            // เปลี่ยนค่า set
                            set_device = textBox_device.Text;
                            // เปลี่ยนสี textbox
                           // textBox_device.BackColor = Color.Lime;
                           // pictureBox_video.BackColor = Color.Lime;
                           // button_save.BackColor = Color.Lime;

                        }
                        con_sqlite.Close();
                    }
                    button_save.Enabled = true;
                }

            }
            catch
            {
                button_save.Enabled = true;
            }
        }

        private void dataGridView_device_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    button_test.Enabled = true;

                }
            }
            catch
            {

            }
        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // โคลนภาพเฟรมปัจจุบันมาแปลงเป็นรูปแบบ Bitmap เพื่อแสดงผล
                Bitmap videoFrame = (Bitmap)eventArgs.Frame.Clone();

                // ภาพซ้าย - ขวาสลับกัน(เหมือนกระจกเงา / Mirror Effect) - เจอบ่อยที่สุดในเว็บแคม
                videoFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // ส่งภาพไปตัดมุมโค้ง (ตัวเลข 30 คือความโค้ง ยิ่งมากยิ่งโค้ง)
                Bitmap roundedFrame = Class_RoundedCorners.CreateRoundedCorners(videoFrame, Corners);

                // คืนหน่วยความจำภาพต้นฉบับทันทีเพื่อประหยัดแรม
                videoFrame.Dispose();

                // แสดงภาพบน PictureBox (จัดการ Thread ปลอดภัยด้วยการเปลี่ยนค่า Image โดยตรง)
                pictureBox_video.Image = roundedFrame;


            }
            catch
            {

            }

        }
        // ฟังก์ชันค้นหา MonikerString ด้วยชื่อกล้อง
        private string GetMonikerStringByDeviceName(string targetDeviceName)
        {
            try
            {
                // ดึงรายการอุปกรณ์วิดีโอทั้งหมดที่เชื่อมต่อกับคอมพิวเตอร์
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                // วนลูปค้นหากล้องที่มีชื่อตรงกับที่ระบุ
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name.Equals(targetDeviceName, StringComparison.OrdinalIgnoreCase))
                    {
                        return device.MonikerString; // คืนค่า MonikerString เมื่อเจอชื่อที่ตรงกัน
                    }
                }

                return null!; // คืนค่า null หากไม่พบกล้องชื่อนี้
            }
            catch
            {
                return null!; // คืนค่า null หากไม่พบกล้องชื่อนี้
            }

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
