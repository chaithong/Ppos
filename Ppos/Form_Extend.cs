using System.Globalization;
using System.Text;
using System.Xml;
using Hardware.Info;
using Ppos.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;

namespace Ppos
{
    public partial class Form_Extend : Form
    {
        CultureInfo cultures = new CultureInfo("en-US");
        string SR_MB;
        public Form_Extend()
        {
            InitializeComponent();
            try
            {
                if (File.Exists(Class_Parameter.RCtxt) && File.ReadAllLines(Class_Parameter.RCtxt).Length > 0)  /// มีไฟล์แล้ว
                {
                    string DATE;
                    DATE = Class_Base64.RC_Base64ToString(File.ReadLines(Class_Parameter.RCtxt).Last()).Split("|")[4];

                    DATE = DATE.Substring(6, 2) + "-" + DATE.Substring(4, 2) + "-" + DATE.Substring(0, 4);

                    progressBar.Value = 9999;
                    // ถ้าวันหมดอายุมากกว่าวันปัจจุบัน
                    if (DateTime.Parse(DATE) > DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures)))
                    {
                        label_exp.Text = "ใช้งานได้อีก " +
                       (DateTime.Parse(DATE) - DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures))).TotalDays.ToString() + " วัน " +
                       "ถึงวันที่ " + DATE;
                    }
                    else if (DateTime.Parse(DATE) == DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures)))
                    {
                        label_exp.Text = "ใช้งานได้วันสุดท้าย" + Environment.NewLine + "แนะนำให้ลงทะเบียนเพิ่มก่อนหมดอายุ !!!";
                    }
                    else
                    {
                        progressBar.Value = 0;
                        label_exp.ForeColor = Color.Red;
                        label_exp.Text = "หมดอายุการใช้งาน เมื่อวันที่ " + DATE + Environment.NewLine + " ติดต่อผู้ดูแลระบบเพื่อต่ออายุการใช้งาน";
                    }

                }
                else
                {
                    label_exp.Text = "ยินดีต้อนรับสู่โปรแกรมขาย Ppos";
                }
            }
            catch
            {
                MessageBox.Show("โปรแกรมผิดพลาด ติดต่อผู้ดูแลระบบ !!!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Form_Extend_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker.RunWorkerAsync();
            }
            catch
            {

            }
        }



        public bool CheckRCDuplicate(string rc)
        {
            try
            {
                // รหัสต้องไม่เหมือนเดิม วันและเวลาต้องไม่เหมือนเดิม
                string RC_OLD;
                string RC_NEW = rc.Split("|")[1] + rc.Split("|")[2];
                foreach (string line in File.ReadLines(Class_Parameter.RCtxt))
                {

                    RC_OLD = Class_Base64.RC_Base64ToString(line).Split("|")[1] + Class_Base64.RC_Base64ToString(line).Split("|")[2];
                    if (RC_NEW == RC_OLD)
                    {
                        MessageBox.Show("รหัสถูกใช้งานแล้ว !!!", "รหัสใช้งานไม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                ///////    
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button_Confirm_Code_Click(object sender, EventArgs e)
        {
            try
            {
                string TO_DATE;
                button_Confirm_Code.Enabled = false;
                if (textBox_Renewal_Code.Text != string.Empty) /// ถ้ามี RC ไม่ใข่ค่าว่าง
                {
                    // มี | ไหม
                    if (Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Contains("|"))
                    {
                        // จำนวน | ต้อง 2
                        if (Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Count(c => c == '|') == 3)
                        {
                            // รหัสเครื่องก็ตรงกัน
                            if (Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[0] == SR_MB)
                            {
                                // วันที่ code ต้องตรงกับวันนี้
                                string CODE_DATE = Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text);
                                CODE_DATE = CODE_DATE.Split("|")[1];
                                CODE_DATE = CODE_DATE.Substring(0, 4) + "-" + CODE_DATE.Substring(4, 2) + "-" + CODE_DATE.Substring(6, 2);

                                if (CODE_DATE == DateTime.Now.ToString("yyyy-MM-dd", cultures))
                                {
                                    // ถ้ามีข้อมูลทั้งหมดนี้ เคยเปิดใช้มาแล้ว
                                    if (File.Exists(Class_Parameter.RCtxt)   // ต้องมี ไฟล์ RC
                                     && File.ReadAllLines(Class_Parameter.RCtxt).Length > 0  // ไฟล์ RC ต้องมีข้อมูล
                                     && File.Exists(Class_Parameter.STtxt)  // ต้องมี ไฟล์ ST
                                     && File.ReadAllLines(Class_Parameter.STtxt).Length == 1  // ไฟล์ ST ต้องมีข้อมูล 1 บรรทัด
                                     && File.Exists(Form_Login.path + @"\database.db") // ต้องมี Document\Ppos\database.db
                                       )
                                    {
                                        // รหัสต้องไม่ซ้ำกัน
                                        if (CheckRCDuplicate(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text)))
                                        {
                                            // ใช้ได้ถึงวันที่ล่าสุด

                                            TO_DATE = Class_Base64.RC_Base64ToString(File.ReadLines(Class_Parameter.RCtxt).Last()).Split("|")[4];
                                            TO_DATE = TO_DATE.Substring(0, 4) + "-" + TO_DATE.Substring(4, 2) + "-" + TO_DATE.Substring(6, 2);

                                            // วันหมดอายุมากกว่าวันปัจจุบัน
                                            if (DateTime.Parse(TO_DATE) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd", cultures)))
                                            {
                                                TO_DATE = DateTime.Parse(TO_DATE).AddDays(Convert.ToDouble(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[3])).ToString("yyyyMMdd");
                                                File.AppendAllText(Class_Parameter.RCtxt,
                                                Class_Base64.RC_StringToBase64(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text) + "|" + TO_DATE) + "\n");

                                            }
                                            else // วันหมดอายุ น้อยกว่าหรือเท่ากับวันปัจจุบัน ต้องใช้วันปัจจุบันเพิ่ม
                                            {
                                                TO_DATE = DateTime.Now.AddDays(Convert.ToDouble(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[3])).ToString("yyyyMMdd", cultures);
                                                File.AppendAllText(Class_Parameter.RCtxt,
                                                Class_Base64.RC_StringToBase64(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text) + "|" + TO_DATE) + "\n");
                                            }
                                            progressBar.Value = 9999;
                                            label_exp.ForeColor = Color.Black;
                                            label_exp.Text = TO_DATE.Substring(6, 2) + "-" + TO_DATE.Substring(4, 2) + "-" + TO_DATE.Substring(0, 4);

                                            label_exp.Text = "ใช้งานได้อีก " +
                                            (DateTime.Parse(label_exp.Text) - DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures))).TotalDays.ToString() + " วัน " +
                                            "ถึงวันที่ " + label_exp.Text;

                                            MessageBox.Show("เพิ่มเวลาการใช้งาน " + Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[3] + "วัน เรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Class_Parameter.Active = true;
                                        }

                                    }
                                    // ถ้าไม่มีไฟล์เลย จะเป็นการเปิดครั้งแรก
                                    else if (!File.Exists(Class_Parameter.RCtxt)   // ต้องไม่มี ไฟล์ RC
                                        && !File.Exists(Class_Parameter.STtxt)  // ต้องไม่มี ไฟล์ ST
                                        && !File.Exists(Form_Login.path + @"\database.db") // ต้องไม่มี Document\Ppos\database.db
                                        )
                                    {
                                        // กำหนดวันที่เริ่มใช้ครั้งแรก
                                        File.WriteAllText(Class_Parameter.STtxt, Class_Base64.ST_Base64());

                                        // ใส่ serial ครั้งแรก
                                        TO_DATE = DateTime.Now.AddDays(Convert.ToDouble(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[3])).ToString("yyyyMMdd", cultures);
                                        File.WriteAllText(Class_Parameter.RCtxt,
                                            Class_Base64.RC_StringToBase64(Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text) + "|" + TO_DATE)
                                            + "\n");

                                        // สร้าง path
                                        if (!System.IO.Directory.Exists(Form_Login.path))
                                        {
                                            System.IO.Directory.CreateDirectory(Form_Login.path);
                                        }
                                        // สร้าง DB
                                        Class_Create_DB.Create_DB(Class_Base64.ST_String(), SR_MB);

                                        // สร้าง path image
                                        if (!System.IO.Directory.Exists(Form_Login.item_path))
                                        {
                                            System.IO.Directory.CreateDirectory(Form_Login.item_path);
                                        }

                                        progressBar.Value = 9999;
                                        label_exp.ForeColor = Color.Black;
                                        label_exp.Text = TO_DATE.Substring(6, 2) + "-" + TO_DATE.Substring(4, 2) + "-" + TO_DATE.Substring(0, 4);

                                        label_exp.Text = "ใช้งานได้อีก " +
                                           (DateTime.Parse(label_exp.Text) - DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy", cultures))).TotalDays.ToString() + " วัน " +
                                           "ถึงวันที่ " + label_exp.Text;

                                        MessageBox.Show("เพิ่มเวลาการใช้งาน " + Class_Base64.RC_Base64ToString(textBox_Renewal_Code.Text).Split("|")[3] + "วัน เรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Class_Parameter.Active = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("ติดต่อผู้ดูแลระบบ !!", "ผิดพลาด(5)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ติดต่อผู้ดูแลระบบ !!", "ผิดพลาด(4)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("ติดต่อผู้ดูแลระบบ !!", "ผิดพลาด(3)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ติดต่อผู้ดูแลระบบ !!", "ผิดพลาด(2)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ติดต่อผู้ดูแลระบบ !!", "ผิดพลาด(1)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                button_Confirm_Code.Enabled = true;
            }
            catch (Exception ex)
            {
                button_Confirm_Code.Enabled = true;
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                IHardwareInfo hardwareInfo = new HardwareInfo();

                /* hardwareInfo.RefreshCPUList();
                 //// cpu
                 if (hardwareInfo.CpuList.Count > 0)
                 {
                     label_CPU.Text = Class_Base64.RC_StringToBase64(hardwareInfo.CpuList[0].ProcessorId);
                 }
                 hardwareInfo = new HardwareInfo();*/
                hardwareInfo.RefreshMotherboardList();
                ///// ถ้ามีข้อมูล mb ใน list
                if (hardwareInfo.MotherboardList.Count > 0)
                {
                    // เก็บไว้ตรวจสอบ
                    SR_MB = hardwareInfo.MotherboardList[0].SerialNumber.Replace("/", "");

                    // แปลงเป็น base64 แค่ครั้งเดียว 
                    button_MB.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(hardwareInfo.MotherboardList[0].SerialNumber.Replace("/", "")));
                }
                ///////
            }
            catch
            {

            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                pictureBox_load.Visible = false;
                label_exp.Visible = true;
                textBox_Renewal_Code.Visible = true;
                button_Confirm_Code.Visible = true;
                button_MB.Visible = true;

                textBox_Renewal_Code.Focus();
            }
            catch
            {

            }
        }



        private void textBox_Renewal_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ตรวจสอบว่าถ้ากดปุ่ม Space (เว้นวรรค)
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // ยกเลิกการพิมพ์ตัวอักษรนั้น
            }
        }

        private void textBox_Renewal_Code_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // ลบเว้นวรรคทั้งหมดออกจากข้อความ
                if (textBox_Renewal_Code.Text.Contains(" "))
                {
                    textBox_Renewal_Code.Text = textBox_Renewal_Code.Text.Replace(" ", "");

                    // เลื่อน Cursor ไปไว้ท้ายสุด (ป้องกัน Cursor กระโดดมาหน้าสุดหลังลบ)
                    textBox_Renewal_Code.SelectionStart = textBox_Renewal_Code.Text.Length;
                }
            }
            catch
            {

            }
        }

        private void button_MB_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(button_MB.Text);
                MessageBox.Show("คัดลอกรหัสเรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pictureBox_load.Focus();
            }
            catch
            {

            }
        }
    }
}
