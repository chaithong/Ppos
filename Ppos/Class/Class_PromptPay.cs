using QRCoder;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;

namespace Ppos.Class
{
    internal class Class_PromptPay
    {
        public static Image Generate(string total)
        {
            try
            {
                string targetId = "";
                // ดึงเบอร์โทรร้าน
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = "SELECT phone FROM Store";
                        SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                        DataTable dt = new System.Data.DataTable();
                        dt.Load(er);
                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["phone"].ToString()) &&
                                dt.Rows[0]["phone"].ToString()!.Length == 10 &&
                                dt.Rows[0]["phone"].ToString()!.StartsWith("0") &&
                                long.TryParse(dt.Rows[0]["phone"].ToString()!, out _))
                            {
                                targetId = Regex.Replace(dt.Rows[0]["phone"].ToString()!,"^0","0066");
                            }
                            else
                            {                              
                                return null!;
                            }
                        }
                        else
                        {
                            return null!;
                        }
                    }
                }
       
                // 1. กำหนดข้อมูลผู้รับเงิน (เลือกอย่างใดอย่างหนึ่ง)
                // - เบอร์มือถือ: ตัด 0 ตัวแรกออก แล้วแทนด้วย 66 เช่น 0812345678 -> 0066812345678
                // - เลขบัตรประชาชน / เลขทะเบียนนิติบุคคล 13 หลัก: ใส่ตรงๆ ได้เลย
                decimal? amount = Convert.ToDecimal(total); // ใส่จำนวนเงิน (หากไม่ระบุให้ใส่ null เพื่อให้ลูกค้ากรอกเอง)

                // 2. สร้างข้อความตามมาตรฐาน PromptPay (EMVCo)
                string promptPayPayload = GeneratePromptPayPayload(targetId, amount);
                // Console.WriteLine($"Payload: {promptPayPayload}");

                // 3. นำ Payload มาสร้างเป็นภาพ QR Code ด้วย QRCoder
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(promptPayPayload, QRCodeGenerator.ECCLevel.Q))
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeBytes = qrCode.GetGraphic(20); // เลข 20 คือขนาดพิกเซลต่อบล็อก

                    // บันทึกไฟล์ภาพเป็น PNG
                  //  string outputPath = Path.Combine(Directory.GetCurrentDirectory(), total);
                   // File.WriteAllBytes(outputPath, qrCodeBytes);
                    // 4. แปลงจาก byte[] เป็น Image แล้วส่งให้ PictureBox
                    using (MemoryStream ms = new MemoryStream(qrCodeBytes))
                    {
                        // โหลดภาพเข้า PictureBox
                        return Image.FromStream(ms);

                        // ปรับขนาดรูปภาพให้พอดีกับขนาดของ PictureBox อัตโนมัติ
                        // pictureBox_promptpay.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                }
            }
            catch
            {
                return null!;
            }

        }
        /// <summary>
        /// ฟังก์ชันคำนวณ CRC16 (CCITT-FALSE) สำหรับต่อท้ายตาราง EMVCo
        /// </summary>
        private static string CalculateCRC16(string input)
        {
            ushort crc = 0xFFFF;
            byte[] bytes = Encoding.ASCII.GetBytes(input);

            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    else
                        crc = (ushort)(crc << 1);
                }
            }
            return crc.ToString("X4"); // คืนค่าเป็นเลขฐาน 16 ตัวพิมพ์ใหญ่ 4 หลัก
        }

        /// <summary>
        /// ฟังก์ชันจัดรูปแบบข้อความ EMVCo ตามมาตรฐาน PromptPay
        /// </summary>
        private static string GeneratePromptPayPayload(string target, decimal? amount)
        {
            // ทำความสะอาดข้อมูลเบอร์หรือเลขสิบสามหลัก
            target = target.Replace("-", "").Trim();

            StringBuilder payload = new StringBuilder();

            // ข้อมูลพื้นฐานของ QR Code (Payload Format Indicator, Point of Initiation Method)
            payload.Append("000201"); // Tag 00: เวอร์ชั่นระบบ (01)
            payload.Append(amount.HasValue ? "010212" : "010211"); // Tag 01: 11 = ใช้ซ้ำได้ (ไม่ระบุยอดเงิน), 12 = ใช้ครั้งเดียว (ระบุยอดเงิน)

            // Merchant Account Information (PromptPay ID)
            StringBuilder merchantInfo = new StringBuilder();
            merchantInfo.Append("0016A000000677010111"); // Global Unique Identifier ของ PromptPay

            if (target.Length == 13)
            {
                merchantInfo.Append($"0213{target}"); // Tag 02: เลขบัตรประชาชน / เลขนิติบุคคล (13 หลัก)
            }
            else
            {
                // หากเป็นเบอร์มือถือที่ขึ้นต้นด้วย 0 ให้แปลงเป็นฟอร์แมต 0066...
                if (target.StartsWith("0") && target.Length == 10)
                {
                    target = "0066" + target.Substring(1);
                }
                merchantInfo.Append($"0113{target.PadLeft(13, '0')}"); // Tag 01: เบอร์โทรศัพท์ (ความยาวล็อกไว้ที่ 13 ตัวอักษร)
            }

            payload.Append($"29{merchantInfo.Length:D2}{merchantInfo}");
            payload.Append("5303764"); // Tag 53: สกุลเงิน THB (764)

            // ตรวจสอบข้อมูลจำนวนเงิน (Tag 54)
            if (amount.HasValue)
            {
                string amountStr = amount.Value.ToString("F2"); // กำหนดทศนิยม 2 ตำแหน่ง
                payload.Append($"54{amountStr.Length:D2}{amountStr}");
            }

            payload.Append("5802TH"); // Tag 58: ประเทศผู้รับเงิน (TH)
            payload.Append("6304");   // Tag 63: ฟิลด์สำหรับ CRC16 (ความยาวข้อมูลถัดไปคือ 04 ตัวอักษร)

            // คำนวณค่า CRC จากสตริงทั้งหมดแล้วต่อท้าย
            string crc = CalculateCRC16(payload.ToString());
            payload.Append(crc);

            return payload.ToString();
        }
    }
}
