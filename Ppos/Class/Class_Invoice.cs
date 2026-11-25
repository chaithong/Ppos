using PdfiumViewer;
using QRCoder;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkiaSharp;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ZXing;
using ZXing.SkiaSharp;
using static System.Net.Mime.MediaTypeNames;

namespace Ppos.Class
{
    internal class Class_Invoice
    {
   
        public static void Generate(bool inv_sale, string trx_no,string id_member,int dec_point,int inc_point ,double transfer , double cash, double cash_change)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                string fontRegularPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Font", "Sarabun-Regular.ttf");
                string fontBoldPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Font", "Sarabun-Bold.ttf");

                if (File.Exists(fontRegularPath)) FontManager.RegisterFontFromFile(fontRegularPath);
                if (File.Exists(fontBoldPath)) FontManager.RegisterFontFromFile(fontBoldPath);

                // path save
               
                string path_save;
                if (!System.IO.Directory.Exists(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1])))
                {
                    System.IO.Directory.CreateDirectory(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1]));
                }
                // สร้าง path sale
                if (inv_sale)
                {
                    if (!System.IO.Directory.Exists(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Sale")))
                    {
                        System.IO.Directory.CreateDirectory(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Sale"));
                    }
                    path_save = Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Sale",trx_no+".pdf");
                }
                else
                {
                    if (!System.IO.Directory.Exists(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Void")))
                    {
                        System.IO.Directory.CreateDirectory(Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Void"));
                    }
                    path_save = Path.Combine(Form_Login.invoice_path, trx_no.Split("-")[1], "Void",trx_no+".pdf");
                }
                // สร้าง pdf
                gen_trx_no( inv_sale,  trx_no,  id_member,  dec_point,  inc_point,  transfer,  cash,  cash_change, Class_Parameter.inv_bar).GeneratePdf(path_save);

                // สั่งปริ้น
                if(Class_Parameter.inv_print_name != string.Empty && Class_Parameter.inv_print_name != "ไม่ปริ้น")
                {
                    PrintPdfFile(path_save, Class_Parameter.inv_print_name);
                }
                
                // เปิดไฟล์ PDF ด้วยโปรแกรมอ่าน PDF เริ่มต้นของ Windows
                //  Process.Start(new ProcessStartInfo(System.IO.Path.Combine(Form_Login.invoice_path, trx_no + ".pdf")) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static Document gen_trx_no(bool inv_sale, string trx_no, string id_member, int dec_point, int inc_point, double transfer, double cash, double cash_change,string bar)
        {
            try
            {
               

                string trx_no_master = "INV-01012026-0001";
                // ตั้งค่าความละเอียดของภาพ (ค่าเริ่มต้นคือ 72 DPI ซึ่งอาจจะเบลอ แนะนำ 150 - 300 DPI)
                var imageSettings = new ImageGenerationSettings
                {
                    ImageFormat = QuestPDF.Infrastructure.ImageFormat.Png,
                    RasterDpi = 200
                };

              
                      return  Document.Create(container =>
                        {
                            using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                            {
                                con_sqlite.Open();
                                using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                                {

                                    // ข้อมูลสาขา
                                    cmd_sqlite.CommandText = "SELECT store_no, store_name, tax_id, address, sub_district, district, province, postal_code, phone, email FROM Store";
                                    SQLiteDataReader er = cmd_sqlite.ExecuteReader();
                                    DataTable dt_store = new DataTable();
                                    dt_store.Load(er);
                                    string store_name = dt_store.Rows[0]["store_name"].ToString()!;
                                    string address = dt_store.Rows[0]["address"].ToString() + " " +
                                        dt_store.Rows[0]["sub_district"].ToString() + " " +
                                        dt_store.Rows[0]["district"].ToString() + " " +
                                        dt_store.Rows[0]["province"].ToString() + " " +
                                        dt_store.Rows[0]["postal_code"].ToString();
                                    string phone = dt_store.Rows[0]["phone"].ToString()!;
                                    string tax_id = dt_store.Rows[0]["tax_id"].ToString()!;
                                    // สินค้า
                                    DataTable dt_item = new DataTable();
                                    if (trx_no != string.Empty)
                                    {
                                        cmd_sqlite.CommandText = "SELECT trx_no, small_barcode, item_barcode, item_code, item_name, item_qty, item_unit, " +
                                      "item_price, item_price_sum, item_cost_avg, small_qty, qty_small, " +
                                      "pro_id, pro_type, pro_desc, criterion_type, criterion_value, offer_type, offer_value, discount_type, repeat, " +
                                      "discount_promotion, id_member, percent_discount_member, discount_member, discount_custom, discount_point, discount_round, " +
                                      "price_net, price_non_vat, price_vat, vat, sale_vat, premium, effective_member " +
                                      "FROM Invoice_Body " +
                                      "where trx_no = '" + trx_no + "' and void = false";
                                        er = cmd_sqlite.ExecuteReader();
                                        dt_item.Load(er);
                                    }
                                    else
                                    {
                                        // master
                                        dt_item.Columns.Add("item_name", typeof(string));
                                        dt_item.Columns.Add("item_qty", typeof(string));
                                        dt_item.Columns.Add("item_price", typeof(string));
                                        dt_item.Columns.Add("discount_promotion", typeof(string));
                                        dt_item.Columns.Add("discount_member", typeof(string));
                                        dt_item.Columns.Add("discount_custom", typeof(string));
                                        dt_item.Columns.Add("discount_point", typeof(string));
                                        dt_item.Columns.Add("price_net", typeof(string));
                                        dt_item.Columns.Add("price_non_vat", typeof(string));
                                        dt_item.Columns.Add("price_vat", typeof(string));
                                        dt_item.Columns.Add("vat", typeof(string));


                                        dt_item.Rows.Add("หมวกแก๊ป สีดำ", "1", "199", "0", "0", "0", "0", "199", "199", "0", "0");
                                        dt_item.Rows.Add("เสื้อยืดคอกลม สีดำ (L)", "2", "290", "50", "24.58", "5", "100", "400", "0", "373.8317757009346", "26.16822429906542");
                                        dt_item.Rows.Add("กางเกงยีนส์ขาสั้น (32)", "1", "450", "0", "0", "0", "0", "450", "0", "420.5607476635514", "29.4392523364486");

                                    }

                                    double qtyTotal = 0;
                                    double priceTotal = 0;
                                    double disPro = 0;
                                    double disMember = 0;
                                    double disCustom = 0;
                                    double disPoint = 0;
                                    double disRound = 0;
                                    double priceNet = 0;
                                    double price_non_vat = 0;
                                    double price_vat = 0;
                                    double vat = 0;


                                    container.Page(page =>
                                    {
                                        // ตั้งขนาดสลิป 80mm ความยาวปรับตามเนื้อหาอัตโนมัติ
                                        page.ContinuousSize(Class_Parameter.inv_width, Unit.Millimetre);
                                        page.Margin(Class_Parameter.inv_margin, Unit.Millimetre);
                                        page.DefaultTextStyle(x => x.FontFamily("Sarabun").FontSize(9));

                                        // ==========================================
                                        // 1. ส่วนหัวใบเสร็จ (โลโก้ด้านบน + ข้อมูลร้าน)
                                        // ==========================================
                                        page.Header().Column(col =>
                                        {
                                            // แสดง logo
                                            if (Class_Parameter.inv_logo)
                                            {
                                                // โหลดรูปโลโก้จาก Path โดยตรง (เช็กก่อนว่ามีไฟล์อยู่จริง)
                                                if (File.Exists(Form_Login.logo_path + @"\Logo.Png"))
                                                {
                                                    float w = (Class_Parameter.inv_width - (Class_Parameter.inv_margin * 2)) * (Class_Parameter.inv_logo_width / 100);
                                                    using (FileStream bitmapFile = new FileStream(Form_Login.logo_path + @"\Logo.Png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                                    {
                                                        System.Drawing.Image img = new Bitmap(bitmapFile);
                                                        using (var ms = new MemoryStream())
                                                        {
                                                            // บันทึกเป็น PNG เพื่อรักษาคุณภาพและความโปร่งใส (ถ้ามี)
                                                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                                                            col.Item().AlignCenter().Width(w, Unit.Millimetre).Image(ms.ToArray());
                                                        }

                                                    }

                                                }
                                            }
                                            // ชื่อร้าน
                                            // ตัวหนา
                                            if (Class_Parameter.inv_name_bold)
                                            {
                                                col.Item().PaddingTop(4).AlignCenter().Text(store_name).FontSize(Class_Parameter.inv_name_fontsize).Bold();
                                            }
                                            else
                                            {
                                                col.Item().PaddingTop(4).AlignCenter().Text(store_name).FontSize(Class_Parameter.inv_name_fontsize);
                                            }


                                            // แสดงที่อยู่
                                            if (Class_Parameter.inv_address)
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_address_bold)
                                                {
                                                    col.Item().AlignCenter().Text(address).FontSize(Class_Parameter.inv_address_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    col.Item().AlignCenter().Text(address).FontSize(Class_Parameter.inv_address_fontsize);
                                                }
                                            }
                                            // แสดงเบอร์โทร
                                            if (Class_Parameter.inv_phone)
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_phone_bold)
                                                {
                                                    col.Item().AlignCenter().Text("เบอร์โทร " + phone).FontSize(Class_Parameter.inv_phone_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    col.Item().AlignCenter().Text("เบอร์โทร : " + phone).FontSize(Class_Parameter.inv_phone_fontsize);
                                                }
                                            }
                                            // แสดง tax_id
                                            if (Class_Parameter.inv_tax_id)
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_tax_id_bold)
                                                {
                                                    col.Item().AlignCenter().Text("Tax ID : " + tax_id).FontSize(Class_Parameter.inv_tax_id_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    col.Item().AlignCenter().Text("Tax ID : " + tax_id).FontSize(Class_Parameter.inv_tax_id_fontsize);
                                                }
                                            }
                                            // ประเภทใบเสร็จ
                                            if (inv_sale)
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_type_bold)
                                                {
                                                    col.Item().PaddingTop(4).AlignCenter().Text("ใบเสร็จรับเงิน").FontSize(Class_Parameter.inv_type_fontsize).Bold();

                                                }
                                                else
                                                {
                                                    col.Item().PaddingTop(4).AlignCenter().Text("ใบเสร็จรับเงิน").FontSize(Class_Parameter.inv_type_fontsize);

                                                }
                                            }
                                            else
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_type_bold)
                                                {
                                                    col.Item().PaddingTop(4).AlignCenter().Text("ยกเลิกใบเสร็จรับเงิน").FontSize(Class_Parameter.inv_type_fontsize).Bold();

                                                }
                                                else
                                                {
                                                    col.Item().PaddingTop(4).AlignCenter().Text("ยกเลิกใบเสร็จรับเงิน").FontSize(Class_Parameter.inv_type_fontsize);

                                                }
                                            }

                                            // เส้นเป็นจุด
                                            if (Class_Parameter.inv_line_point)
                                            {
                                                col.Item().PaddingTop(6).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                            }
                                            else
                                            {
                                                col.Item().PaddingTop(6).LineHorizontal(0.5f);
                                            }
                                            // เลขบิลกับเวลา
                                            col.Item().PaddingTop(4).Row(row =>
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_trx_no_bold)
                                                {
                                                    row.RelativeItem().Text((trx_no != "") ? trx_no : trx_no_master).FontSize(Class_Parameter.inv_trx_no_fontsize).Bold();
                                                    row.RelativeItem().AlignRight().Text($"{DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(Class_Parameter.inv_trx_no_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    row.RelativeItem().Text((trx_no != "") ? trx_no : trx_no_master).FontSize(Class_Parameter.inv_trx_no_fontsize);
                                                    row.RelativeItem().AlignRight().Text($"{DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(Class_Parameter.inv_trx_no_fontsize);

                                                }
                                            });
                                            // เส้นเป็นจุด
                                            if (Class_Parameter.inv_line_point)
                                            {
                                                col.Item().PaddingVertical(4).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                            }
                                            else
                                            {
                                                col.Item().PaddingVertical(4).LineHorizontal(0.5f);
                                            }
                                        });

                                        // ==========================================
                                        // 2. ส่วนเนื้อหา (ตารางรายการสินค้า + สรุปยอด)
                                        // ==========================================
                                        page.Content().Table(table =>
                                        {
                                            table.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(float.Parse(Class_Parameter.inv_column_size.Split("|")[0])); // ชื่อสินค้า
                                                columns.RelativeColumn(float.Parse(Class_Parameter.inv_column_size.Split("|")[1])); // จำนวน
                                                columns.RelativeColumn(float.Parse(Class_Parameter.inv_column_size.Split("|")[2])); // ราคารวม
                                            });

                                            // หัวตาราง
                                            table.Header(header =>
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_head_bold)
                                                {
                                                    header.Cell().Text("รายการ").FontSize(Class_Parameter.inv_head_fontsize).Bold();
                                                    header.Cell().AlignRight().Text("จำนวน").FontSize(Class_Parameter.inv_head_fontsize).Bold();
                                                    header.Cell().AlignRight().Text("รวม").FontSize(Class_Parameter.inv_head_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    header.Cell().Text("รายการ").FontSize(Class_Parameter.inv_head_fontsize);
                                                    header.Cell().AlignRight().Text("จำนวน").FontSize(Class_Parameter.inv_head_fontsize);
                                                    header.Cell().AlignRight().Text("รวม").FontSize(Class_Parameter.inv_head_fontsize);
                                                }

                                                // เส้นเป็นจุด
                                                if (Class_Parameter.inv_line_point)
                                                {
                                                    header.Cell().ColumnSpan(3).PaddingVertical(2).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                                }
                                                else
                                                {
                                                    header.Cell().ColumnSpan(3).PaddingVertical(2).LineHorizontal(0.5f);
                                                }

                                            });

                                            // วนลูปแสดงรายการสินค้า

                                            foreach (DataRow row in dt_item.Rows)
                                            {
                                                // ตัวหนา
                                                if (Class_Parameter.inv_item_bold)
                                                {
                                                    table.Cell().PaddingVertical(2).Text(row["item_name"].ToString()).FontSize(Class_Parameter.inv_item_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(Convert.ToDouble(row["item_qty"]).ToString("#,##0.###")).FontSize(Class_Parameter.inv_item_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text((Convert.ToDouble(row["item_qty"]) * Convert.ToDouble(row["item_price"])).ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_item_fontsize).Bold();

                                                }
                                                else
                                                {
                                                    table.Cell().PaddingVertical(2).Text(row["item_name"].ToString()).FontSize(Class_Parameter.inv_item_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(Convert.ToDouble(row["item_qty"]).ToString("#,##0.###")).FontSize(Class_Parameter.inv_item_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text((Convert.ToDouble(row["item_qty"]) * Convert.ToDouble(row["item_price"])).ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_item_fontsize);

                                                }

                                                qtyTotal += Convert.ToDouble(row["item_qty"]);
                                                priceTotal += Convert.ToDouble(row["item_qty"]) * Convert.ToDouble(row["item_price"]);
                                                disPro += Convert.ToDouble(row["discount_promotion"]);
                                                disMember += Convert.ToDouble(row["discount_member"]);
                                                disCustom += Convert.ToDouble(row["discount_custom"]);
                                                disPoint += Convert.ToDouble(row["discount_point"]);
                                                priceNet += Convert.ToDouble(row["price_net"]);
                                                price_non_vat += Convert.ToDouble(row["price_non_vat"]);
                                                price_vat += Convert.ToDouble(row["price_vat"]);
                                                vat += Convert.ToDouble(row["vat"]);
                                            }

                                            // เส้นคั่นและยอดรวมสุทธิ
                                            // เส้นเป็นจุด
                                            if (Class_Parameter.inv_line_point)
                                            {
                                                table.Cell().ColumnSpan(3).PaddingVertical(4).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                            }
                                            else
                                            {
                                                table.Cell().ColumnSpan(3).PaddingVertical(4).LineHorizontal(0.5f);
                                            }
                                            // sum
                                            // ตัวหนา
                                            if (Class_Parameter.inv_sum_bold)
                                            {
                                                table.Cell().PaddingVertical(2).Text("จำนวนรวม").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                table.Cell().PaddingVertical(2).AlignRight().Text(qtyTotal.ToString("#,##0.###")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                table.Cell().PaddingVertical(2).AlignRight().Text(priceTotal.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();

                                                // ลดโปรโมชั่น
                                                disPro = Math.Round(disPro, 2);
                                                if (disPro > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดโปรโมชั่น").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disPro.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                                // ลดสมาชิก
                                                disMember = Math.Round(disMember, 2);
                                                if (disMember > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดสมาชิก").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disMember.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                                // ลดกำหนด
                                                disCustom = Math.Round(disCustom, 2);
                                                if (disCustom > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดกำหนด").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disCustom.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                                // ลดแต้ม
                                                disPoint = Math.Round(disPoint);
                                                if (disPoint > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดแต้มสมาชิก").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disPoint.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                                // ลดปัดเศษ
                                                disRound = Math.Round(priceTotal - disPro - disMember - disCustom - disPoint - Math.Round(priceNet), 2);

                                                if (disRound > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดปัดเศษ").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disRound.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                            }
                                            else
                                            {
                                                table.Cell().PaddingVertical(2).Text("จำนวนรวม").FontSize(Class_Parameter.inv_sum_fontsize);
                                                table.Cell().PaddingVertical(2).AlignRight().Text(qtyTotal.ToString("#,##0.###")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                table.Cell().PaddingVertical(2).AlignRight().Text(priceTotal.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);

                                                // ลดโปรโมชั่น
                                                disPro = Math.Round(disPro, 2);
                                                if (disPro > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดโปรโมชั่น").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disPro.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                                // ลดสมาชิก
                                                disMember = Math.Round(disMember, 2);
                                                if (disMember > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดสมาชิก").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disMember.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                                // ลดกำหนด
                                                disCustom = Math.Round(disCustom, 2);
                                                if (disCustom > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดกำหนด").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disCustom.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                                // ลดแต้ม
                                                disPoint = Math.Round(disPoint);
                                                if (disPoint > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดแต้มสมาชิก").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disPoint.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                                // ลดปัดเศษ
                                                disRound = Math.Round(priceTotal - disPro - disMember - disCustom - disPoint - Math.Round(priceNet), 2);

                                                if (disRound > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดปัดเศษ").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(disRound.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                            }


                                            // สุทธิ
                                            // ตัวหนา
                                            if (Class_Parameter.inv_net_bold)
                                            {
                                                table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ยอดรวมสุทธิ").FontSize(Class_Parameter.inv_net_fontsize).Bold();
                                                table.Cell().PaddingVertical(2).AlignRight().Text(priceNet.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_net_fontsize).Bold();

                                            }
                                            else
                                            {
                                                table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ยอดรวมสุทธิ").FontSize(Class_Parameter.inv_net_fontsize);
                                                table.Cell().PaddingVertical(2).AlignRight().Text(priceNet.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_net_fontsize);
                                            }

                                            // ตัวหนา
                                            if (Class_Parameter.inv_sum_bold)
                                            {
                                                // เงินโอน     
                                                if (transfer > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินโอน").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(transfer.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                }
                                                // เงินสด
                                                if (cash > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินสด").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(cash.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    // เงินทอน                                   
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินทอน").FontSize(Class_Parameter.inv_sum_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(cash_change.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize).Bold();

                                                }
                                            }
                                            else
                                            {
                                                // เงินโอน     
                                                if (transfer > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินโอน").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(transfer.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                }
                                                // เงินสด
                                                if (cash > 0)
                                                {
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินสด").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(cash.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);
                                                    // เงินทอน                                   
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินทอน").FontSize(Class_Parameter.inv_sum_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(cash_change.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_fontsize);

                                                }
                                            }
                                            // แสดง sum_vat
                                            if (Class_Parameter.inv_sum_vat)
                                            {
                                                // เส้นเป็นจุด
                                                if (Class_Parameter.inv_line_point)
                                                {
                                                    table.Cell().ColumnSpan(3).PaddingVertical(4).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                                }
                                                else
                                                {
                                                    table.Cell().ColumnSpan(3).PaddingVertical(4).LineHorizontal(0.5f);
                                                }
                                                // ตัวหนา
                                                if (Class_Parameter.inv_sum_vat_bold)
                                                {
                                                    // สินค้าไม่มีภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("สินค้าไม่มีภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(price_non_vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();

                                                    // สินค้ามีภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("สินค้ามีภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(price_vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();

                                                    // ภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize).Bold();

                                                }
                                                else
                                                {
                                                    // สินค้าไม่มีภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("สินค้าไม่มีภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(price_non_vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize);

                                                    // สินค้ามีภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("สินค้ามีภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(price_vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize);

                                                    // ภาษี                              
                                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ภาษี").FontSize(Class_Parameter.inv_sum_vat_fontsize);
                                                    table.Cell().PaddingVertical(2).AlignRight().Text(vat.ToString(Class_Parameter.inv_point_0 ? "#,##0.00" : "#,##0.##")).FontSize(Class_Parameter.inv_sum_vat_fontsize);

                                                }

                                            }
                                        });

                                        // ==========================================
                                        // 3. ส่วนท้ายใบเสร็จ (QR Code ด้านล่าง)
                                        // ==========================================
                                        page.Footer().Column(col =>
                                        {
                                            // ถ้ามีโปร
                                            if (disPro > 0 && Class_Parameter.inv_pro)
                                            {
                                                // เส้นเป็นจุด
                                                if (Class_Parameter.inv_line_point)
                                                {
                                                    col.Item().PaddingTop(5).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                                }
                                                else
                                                {
                                                    col.Item().PaddingTop(5).LineHorizontal(0.5f);
                                                }
                                                // ตัวหนา
                                                if (Class_Parameter.inv_pro_head_bold)
                                                {
                                                    col.Item().PaddingTop(5).AlignLeft().Text("โปรโมชั่น").FontSize(Class_Parameter.inv_pro_head_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    col.Item().PaddingTop(5).AlignLeft().Text("โปรโมชั่น").FontSize(Class_Parameter.inv_pro_head_fontsize);
                                                }

                                                if (trx_no != string.Empty)
                                                {
                                                    cmd_sqlite.CommandText = "SELECT pro_desc FROM Invoice_Body " +
                                                                             "where trx_no = '" + trx_no + "' and void = false and pro_desc <> ''" +
                                                                             "group by pro_desc";
                                                    er = cmd_sqlite.ExecuteReader();
                                                    DataTable dt_pro = new DataTable();
                                                    dt_pro.Load(er);
                                                    if (dt_pro.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow dr in dt_pro.Rows)
                                                        {
                                                            // ตัวหนา
                                                            if (Class_Parameter.inv_pro_bold)
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text(dr["pro_desc"].ToString()).FontSize(Class_Parameter.inv_pro_fontsize).Bold();

                                                            }
                                                            else
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text(dr["pro_desc"].ToString()).FontSize(Class_Parameter.inv_pro_fontsize);

                                                            }
                                                        }
                                                    }
                                                }
                                                else // master
                                                {
                                                    // ตัวหนา
                                                    if (Class_Parameter.inv_pro_bold)
                                                    {
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ซื้อเสื้อ 2 ตัว ลด 50 บาท").FontSize(Class_Parameter.inv_pro_fontsize).Bold();
                                                    }
                                                    else
                                                    {
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ซื้อเสื้อ 2 ตัว ลด 50 บาท").FontSize(Class_Parameter.inv_pro_fontsize);
                                                    }

                                                }

                                            }

                                            // ถ้ามีสมาชิก
                                            if (disMember > 0 && Class_Parameter.inv_member)
                                            {
                                                // เส้นเป็นจุด
                                                if (Class_Parameter.inv_line_point)
                                                {
                                                    col.Item().PaddingTop(5).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                                }
                                                else
                                                {
                                                    col.Item().PaddingTop(5).LineHorizontal(0.5f);
                                                }


                                                if (id_member != string.Empty)
                                                {
                                                    cmd_sqlite.CommandText = "SELECT phone, sex, nick_name, first_name, last_name, address, sub_district, district, province, postal_code, discount_percent, sale_total, sale_ineffective_member, sale_effective_member, sale_per_point, point_increase, point_decrease, point_balance, status " +
                                                                        "FROM Member " +
                                                                        "WHERE id= " + id_member;
                                                    er = cmd_sqlite.ExecuteReader();
                                                    DataTable dt_member = new DataTable();
                                                    dt_member.Load(er);
                                                    if (dt_member.Rows.Count > 0)
                                                    {
                                                        // ต้วหนา
                                                        if (Class_Parameter.inv_member_head_bold)
                                                        {
                                                            col.Item().PaddingTop(5).AlignLeft().Text("สมาชิก : " + dt_member.Rows[0]["phone"].ToString()).FontSize(Class_Parameter.inv_member_head_fontsize).Bold();

                                                        }
                                                        else
                                                        {
                                                            col.Item().PaddingTop(5).AlignLeft().Text("สมาชิก : " + dt_member.Rows[0]["phone"].ToString()).FontSize(Class_Parameter.inv_member_head_fontsize);

                                                        }

                                                        if (inv_sale)
                                                        {
                                                            // ต้วหนา
                                                            if (Class_Parameter.inv_member_bold)
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : " + (Convert.ToInt32(dt_member.Rows[0]["point_balance"]) + dec_point - inc_point).ToString()).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                            }
                                                            else
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : " + (Convert.ToInt32(dt_member.Rows[0]["point_balance"]) + dec_point - inc_point).ToString()).FontSize(Class_Parameter.inv_member_fontsize);

                                                            }
                                                        }
                                                        else
                                                        {
                                                            // ต้วหนา
                                                            if (Class_Parameter.inv_member_bold)
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : " + (Convert.ToInt32(dt_member.Rows[0]["point_balance"]) - dec_point + inc_point).ToString()).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                            }
                                                            else
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : " + (Convert.ToInt32(dt_member.Rows[0]["point_balance"]) - dec_point + inc_point).ToString()).FontSize(Class_Parameter.inv_member_fontsize);

                                                            }
                                                        }

                                                        if (dec_point > 0 || inc_point > 0)
                                                        {
                                                            if (dec_point > 0)
                                                            {
                                                                if (inv_sale)
                                                                {
                                                                    // ต้วหนา
                                                                    if (Class_Parameter.inv_member_bold)
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ใช้แต้ม : -" + dec_point).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                                    }
                                                                    else
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ใช้แต้ม : -" + dec_point).FontSize(Class_Parameter.inv_member_fontsize);

                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    // ต้วหนา
                                                                    if (Class_Parameter.inv_member_bold)
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("คืนแต้ม : +" + dec_point).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                                    }
                                                                    else
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("คืนแต้ม : +" + dec_point).FontSize(Class_Parameter.inv_member_fontsize);

                                                                    }
                                                                }
                                                            }
                                                            if (inc_point > 0)
                                                            {
                                                                if (inv_sale)
                                                                {
                                                                    // ต้วหนา
                                                                    if (Class_Parameter.inv_member_bold)
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ได้แต้ม : +" + inc_point).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                                    }
                                                                    else
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ได้แต้ม : +" + inc_point).FontSize(Class_Parameter.inv_member_fontsize);

                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    // ต้วหนา
                                                                    if (Class_Parameter.inv_member_bold)
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ดึงแต้ม : -" + inc_point).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                                    }
                                                                    else
                                                                    {
                                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ดึงแต้ม : -" + inc_point).FontSize(Class_Parameter.inv_member_fontsize);

                                                                    }
                                                                }

                                                            }
                                                            // ต้วหนา
                                                            if (Class_Parameter.inv_member_bold)
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือสุทธิ : " + dt_member.Rows[0]["point_balance"].ToString()).FontSize(Class_Parameter.inv_member_fontsize).Bold();

                                                            }
                                                            else
                                                            {
                                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือสุทธิ : " + dt_member.Rows[0]["point_balance"].ToString()).FontSize(Class_Parameter.inv_member_fontsize);

                                                            }
                                                        }

                                                    }
                                                }
                                                else // master
                                                {
                                                    // ต้วหนา
                                                    if (Class_Parameter.inv_member_head_bold)
                                                    {
                                                        col.Item().PaddingTop(5).AlignLeft().Text("สมาชิก : 0987654321").FontSize(Class_Parameter.inv_member_head_fontsize).Bold();
                                                    }
                                                    else
                                                    {
                                                        col.Item().PaddingTop(5).AlignLeft().Text("สมาชิก : 0987654321").FontSize(Class_Parameter.inv_member_head_fontsize);
                                                    }

                                                    // ตัวหนา
                                                    if (Class_Parameter.inv_member_bold)
                                                    {

                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : 200").FontSize(Class_Parameter.inv_member_fontsize).Bold();
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ใช้แต้ม : -100").FontSize(Class_Parameter.inv_member_fontsize).Bold();
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ได้แต้ม : +10").FontSize(Class_Parameter.inv_member_fontsize).Bold();
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือสุทธิ : 110").FontSize(Class_Parameter.inv_member_fontsize).Bold();
                                                    }
                                                    else
                                                    {
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : 200").FontSize(Class_Parameter.inv_member_fontsize);
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ใช้แต้ม : -100").FontSize(Class_Parameter.inv_member_fontsize);
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ได้แต้ม : +10").FontSize(Class_Parameter.inv_member_fontsize);
                                                        col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือสุทธิ : 110").FontSize(Class_Parameter.inv_member_fontsize);
                                                    }

                                                }

                                            }
                                            //// บาร์โค้ดท้ายบิล
                                            // เส้นเป็นจุด
                                            if (Class_Parameter.inv_line_point)
                                            {
                                                col.Item().PaddingTop(5).LineHorizontal(0.5f).LineDashPattern(new float[] { 1, 2 });
                                            }
                                            else
                                            {
                                                col.Item().PaddingTop(5).LineHorizontal(0.5f);
                                            }

                                            // บาร์
                                            if (Class_Parameter.inv_bar != "ไม่แสดง")
                                            {

                                                /*  // ตัวหนา
                                                  if (Class_Parameter.inv_bar_bold)
                                                  {
                                                      col.Item().PaddingTop(5).AlignCenter().Text("สแกนเพื่อตรวจสอบใบเสร็จ").FontSize(Class_Parameter.inv_bar_fontsize).Bold();
                                                  }
                                                  else
                                                  {
                                                      col.Item().PaddingTop(5).AlignCenter().Text("สแกนเพื่อตรวจสอบใบเสร็จ").FontSize(Class_Parameter.inv_bar_fontsize);
                                                  }*/

                                                // Qr
                                                if(bar != "Barcode")
                                                {
                                                    // วาง QR Code ตรงกลาง กว้าง 75pt
                                                    col.Item().PaddingVertical(5).AlignCenter().Width(75).Image((bar == "Barcode") ? GenerateBarCodeBytes((trx_no != "") ? trx_no : trx_no_master) : GenerateQrCodeBytes((trx_no != "") ? trx_no : trx_no_master)).FitWidth();

                                                }
                                                else 
                                                {
                                                    col.Item().PaddingVertical(5).AlignCenter().Image((bar == "Barcode") ? GenerateBarCodeBytes((trx_no != "") ? trx_no : trx_no_master) : GenerateQrCodeBytes((trx_no != "") ? trx_no : trx_no_master)).FitWidth();

                                                }
                                              


                                                // ตัวหนา
                                                if (Class_Parameter.inv_bar_bold)
                                                {
                                                    col.Item().AlignCenter().Text((trx_no != "") ? trx_no : trx_no_master).FontSize(Class_Parameter.inv_bar_fontsize).Bold();
                                                }
                                                else
                                                {
                                                    col.Item().AlignCenter().Text((trx_no != "") ? trx_no : trx_no_master).FontSize(Class_Parameter.inv_bar_fontsize);
                                                }


                                            }
                                            // ตัวหนา
                                            if (Class_Parameter.inv_thank_bold)
                                            {
                                                col.Item().PaddingTop(4).AlignCenter().Text(Class_Parameter.inv_thank_desc).FontSize(Class_Parameter.inv_thank_fontsize).Bold();
                                            }
                                            else
                                            {
                                                col.Item().PaddingTop(4).AlignCenter().Text(Class_Parameter.inv_thank_desc).FontSize(Class_Parameter.inv_thank_fontsize);
                                            }

                                        });

                                    });
                                }
                            }

                        });

                      

                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null!;
            }
        }

        public static void PrintPdfFile(string pdfPath, string printerName)
        {
            try
            {
                using (var document = PdfDocument.Load(pdfPath))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        // ระบุชื่อเครื่องพิมพ์
                        printDocument.PrinterSettings.PrinterName = printerName;

                        // ซ่อนหน้าต่างแสดงสถานะการพิมพ์
                        printDocument.PrintController = new StandardPrintController();

                        // สั่งพิมพ์ทันที
                        printDocument.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static byte[] GenerateQrCodeBytes(string content)
        {
            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q))
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    return qrCode.GetGraphic(20);
                }
            }
            catch
            {
                return null!;
            }

        }
        private static byte[] GenerateBarCodeBytes(string content)
        {
            try
            {
                // 2. สร้างภาพบาร์โค้ดด้วย ZXing.Net + SkiaSharp
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128, // เลือกรูปแบบบาร์โค้ด เช่น CODE_128, QR_CODE, EAN_13
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 400,
                        Height = 50,
                        Margin = 5,
                        PureBarcode = true
                    }
                };
                using SKBitmap bitmap = barcodeWriter.Write(content);
                using SKImage image = SKImage.FromBitmap(bitmap);
                using SKData encodedData = image.Encode(SKEncodedImageFormat.Png, 100);
                return encodedData.ToArray();
            }
            catch
            {
                return null!;
            }

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                // บันทึกเป็น PNG เพื่อรักษาคุณภาพและความโปร่งใส (ถ้ามี)
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
