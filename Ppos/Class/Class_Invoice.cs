using QRCoder;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Ppos.Class
{
    internal class Class_Invoice
    {
   
        public static void Generate(string trx_no,string id_member,int dec_point,int inc_point ,double cash,double transfer , double change)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                string fontRegularPath = System.IO.Path.Combine(Application.StartupPath, "Font", "Sarabun-Regular.ttf");
                string fontBoldPath = System.IO.Path.Combine(Application.StartupPath, "Font", "Sarabun-Bold.ttf");

                if (File.Exists(fontRegularPath)) FontManager.RegisterFontFromFile(fontRegularPath);
                if (File.Exists(fontBoldPath)) FontManager.RegisterFontFromFile(fontBoldPath);
        
                byte[] qrCodeBytes = GenerateQrCodeBytes(trx_no);
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
                        // สินค้า
                        cmd_sqlite.CommandText = "SELECT trx_no, small_barcode, item_barcode, item_code, item_name, item_qty, item_unit, item_price, item_price_sum, item_cost_avg, small_qty, qty_small, pro_id, pro_type, pro_desc, criterion_type, criterion_value, offer_type, offer_value, discount_type, repeat, discount_promotion, id_member, percent_discount_member, discount_member, discount_custom, discount_point, discount_round, price_net, price_non_vat, price_vat, vat, sale_vat, premium, effective_member FROM Invoice_Body " +
                            "where trx_no = '"+trx_no+"' and void = false";
                        er = cmd_sqlite.ExecuteReader();
                        DataTable dt_item = new DataTable();
                        dt_item.Load(er);

                        double qtyTotal = 0;
                        double priceTotal = 0;
                        double disPro = 0;
                        double disMember = 0;
                        double disCustom = 0;
                        double disPoint = 0;
                        double disRound = 0;
                        double priceNet = 0;
                        // สร้างเอกสาร PDF
                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                // ตั้งขนาดสลิป 80mm ความยาวปรับตามเนื้อหาอัตโนมัติ
                                page.ContinuousSize(80, Unit.Millimetre);
                                page.Margin(5, Unit.Millimetre);
                                page.DefaultTextStyle(x => x.FontFamily("Sarabun").FontSize(9));

                                // ==========================================
                                // 1. ส่วนหัวใบเสร็จ (โลโก้ด้านบน + ข้อมูลร้าน)
                                // ==========================================
                                page.Header().Column(col =>
                                {
                                    // โหลดรูปโลโก้จาก Path โดยตรง (เช็กก่อนว่ามีไฟล์อยู่จริง)
                                    if (File.Exists(Form_Login.logo_path + @"\Logo.Png"))
                                    {
                                        col.Item().AlignCenter().Width(70).Image(Form_Login.logo_path + @"\Logo.Png");
                                    }

                                    col.Item().PaddingTop(4).AlignCenter().Text(store_name).FontSize(13).Bold();
                                    col.Item().AlignCenter().Text(address).FontSize(8);
                                    col.Item().AlignCenter().Text("โทร : "+phone).FontSize(8);
                                    col.Item().AlignCenter().Text("ใบเสร็จรับเงิน").FontSize(8);

                                    col.Item().PaddingTop(6).LineHorizontal(0.5f);
                                    col.Item().PaddingTop(4).Row(row =>
                                    {
                                        row.RelativeItem().Text($"เลขบิล: {trx_no}").FontSize(8);
                                        row.RelativeItem().AlignRight().Text($"{DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8);
                                    });
                                    col.Item().PaddingVertical(4).LineHorizontal(0.5f);
                                });

                                // ==========================================
                                // 2. ส่วนเนื้อหา (ตารางรายการสินค้า + สรุปยอด)
                                // ==========================================
                                page.Content().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(4); // ชื่อสินค้า
                                        columns.RelativeColumn(1); // จำนวน
                                        columns.RelativeColumn(2); // ราคารวม
                                    });

                                    // หัวตาราง
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("รายการ").Bold();
                                        header.Cell().AlignRight().Text("จำนวน").Bold();
                                        header.Cell().AlignRight().Text("รวม").Bold();
                                        header.Cell().ColumnSpan(3).PaddingVertical(2).LineHorizontal(0.5f);
                                    });

                                    // วนลูปแสดงรายการสินค้า
                                   
                                    foreach (DataRow row in dt_item.Rows)
                                    {                         

                                        table.Cell().PaddingVertical(2).Text(row["item_name"].ToString());
                                        table.Cell().PaddingVertical(2).AlignRight().Text(Convert.ToDouble(row["item_qty"]).ToString("#,##0.###"));
                                        table.Cell().PaddingVertical(2).AlignRight().Text((Convert.ToDouble(row["item_qty"]) * Convert.ToDouble(row["item_price"])).ToString("#,##0.00"));

                                        qtyTotal += Convert.ToDouble(row["item_qty"]);
                                        priceTotal += Convert.ToDouble(row["item_qty"]) * Convert.ToDouble(row["item_price"]);
                                        disPro += Convert.ToDouble(row["discount_promotion"]);
                                        disMember += Convert.ToDouble(row["discount_member"]);
                                        disCustom += Convert.ToDouble(row["discount_custom"]);
                                        disPoint += Convert.ToDouble(row["discount_point"]);
                                        priceNet += Convert.ToDouble(row["price_net"]);
                                    }

                                    // เส้นคั่นและยอดรวมสุทธิ
                                    table.Cell().ColumnSpan(3).PaddingVertical(4).LineHorizontal(0.5f);
                                    table.Cell().PaddingVertical(2).Text("จำนวนรวม").FontSize(9);
                                    table.Cell().PaddingVertical(2).AlignRight().Text(qtyTotal.ToString("#,##0.###")).FontSize(9);
                                    table.Cell().PaddingVertical(2).AlignRight().Text(priceTotal.ToString("#,##0.00")).FontSize(9);

                                    // ลดโปรโมชั่น
                                    disPro = Math.Round(disPro, 2);
                                    if (disPro > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดโปรโมชั่น").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(disPro.ToString("0.00")).FontSize(9);
                                    }
                                    // ลดสมาชิก
                                    disMember = Math.Round(disMember, 2);
                                    if (disMember > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดสมาชิก").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(disMember.ToString("0.00")).FontSize(9);
                                    }
                                    // ลดกำหนด
                                    disCustom = Math.Round(disCustom, 2);
                                    if (disCustom > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดกำหนด").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(disCustom.ToString("0.00")).FontSize(9);
                                    }
                                    // ลดแต้ม
                                    disPoint = Math.Round(disPoint);
                                    if (disPoint > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดแต้มสมาชิก").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(disPoint.ToString("0.00")).FontSize(9);
                                    }
                                    // ลดปัดเศษ
                                    disRound = Math.Round(priceTotal - disPro - disMember - disCustom - Math.Round(priceNet), 2);

                                    if (disRound >0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ส่วนลดปัดเศษ").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(disRound.ToString("0.00")).FontSize(9);
                                    }
                                    // สุทธิ
                                    table.Cell().ColumnSpan(2).PaddingVertical(2).Text("ยอดรวมสุทธิ").FontSize(10).Bold();
                                    table.Cell().PaddingVertical(2).AlignRight().Text(priceNet.ToString("#,##0.00")).FontSize(10).Bold();

                                    // เงินโอน                                
                                    if (transfer > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินโอน").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(transfer.ToString("0.00")).FontSize(9);
                                    }
                                    // เงินสด
                                    if (cash > 0)
                                    {
                                        table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินสด").FontSize(9);
                                        table.Cell().PaddingVertical(2).AlignRight().Text(cash.ToString("0.00")).FontSize(9);
                                        // เงินทอน
                                        if (change > 0)
                                        {
                                            table.Cell().ColumnSpan(2).PaddingVertical(2).Text("เงินทอน").FontSize(9);
                                            table.Cell().PaddingVertical(2).AlignRight().Text(change.ToString("0.00")).FontSize(9);
                                        }
                                    }


                                });
                               
                                // ==========================================
                                // 3. ส่วนท้ายใบเสร็จ (QR Code ด้านล่าง)
                                // ==========================================
                                page.Footer().PaddingTop(5).Column(col =>
                                {
                                    // ถ้ามีโปร
                                    if (disPro > 0)
                                    {
                                        col.Item().LineHorizontal(0.5f);
                                        col.Item().PaddingTop(5).AlignLeft().Text("โปรโมชั่น").FontSize(9).Bold();

                                        cmd_sqlite.CommandText = "SELECT pro_desc FROM Invoice_Body " +
                                                                 "where trx_no = '"+trx_no+"' and void = false and pro_desc <> ''" +
                                                                 "group by pro_desc";
                                        er = cmd_sqlite.ExecuteReader();
                                        DataTable dt_pro = new DataTable();
                                        dt_pro.Load(er);
                                        if(dt_pro.Rows.Count >0)
                                        {
                                            foreach (DataRow dr in dt_pro.Rows)
                                            {
                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text(dr["pro_desc"].ToString()).FontSize(9);
                                            }
                                        }
                                    }
                                    // ถ้ามีสมาชิก
                                    if (disMember > 0 && id_member != "")
                                    {

                                        col.Item().PaddingTop(5).LineHorizontal(0.5f);
                                       

                                        cmd_sqlite.CommandText = "SELECT phone, sex, nick_name, first_name, last_name, address, sub_district, district, province, postal_code, discount_percent, sale_total, sale_ineffective_member, sale_effective_member, sale_per_point, point_increase, point_decrease, point_balance, status "+
                                                                 "FROM Member "+
                                                                 "WHERE id= "+id_member;
                                        er = cmd_sqlite.ExecuteReader();
                                        DataTable dt_member = new DataTable();
                                        dt_member.Load(er);
                                        if (dt_member.Rows.Count > 0)
                                        {
                                            col.Item().PaddingTop(5).AlignLeft().Text("สมาชิก : "+ dt_member.Rows[0]["phone"].ToString()).FontSize(9).Bold();
                                            col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือ : "+
                                                (Convert.ToInt32(dt_member.Rows[0]["point_balance"]) + dec_point - inc_point).ToString()).FontSize(9);
                                            if(dec_point > 0 || inc_point >0)
                                            {
                                                if(dec_point > 0)
                                                {
                                                    col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ใช้แต้ม : " + dec_point).FontSize(8);
                                                }
                                                if(inc_point >0)
                                                {
                                                    col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("ได้แต้ม : " + inc_point).FontSize(8);
                                                }
                                                
                                                col.Item().PaddingTop(2).PaddingLeft(5).AlignLeft().Text("แต้มคงเหลือสุทธิ : " + dt_member.Rows[0]["point_balance"].ToString()).FontSize(9);
                                            }
                                            
                                        }
                                    }
                                    //// บาร์โค้ดท้ายบิล
                                    col.Item().PaddingTop(5).LineHorizontal(0.5f);
                                    col.Item().PaddingTop(5).AlignCenter().Text("สแกน QR Code เพื่อตรวจสอบใบเสร็จ").FontSize(8);

                                    // วาง QR Code ตรงกลาง กว้าง 75pt
                                    col.Item().PaddingVertical(4).AlignCenter().Width(75).Image(qrCodeBytes).FitWidth();

                                    col.Item().AlignCenter().Text(trx_no).FontSize(7);
                                    col.Item().PaddingTop(4).AlignCenter().Text("..ขอบคุณที่ใช้บริการ..").FontSize(9).Bold();
                                });

                            });
                        })
                .GeneratePdf(System.IO.Path.Combine(Form_Login.invoice_path, trx_no + ".pdf"));
                    }
                }
                // เปิดไฟล์ PDF ด้วยโปรแกรมอ่าน PDF เริ่มต้นของ Windows
               //  Process.Start(new ProcessStartInfo(System.IO.Path.Combine(Form_Login.invoice_path, trx_no + ".pdf")) { UseShellExecute = true });
            }
            catch
            {

            }
           
        }
        public static byte[] GenerateQrCodeBytes(string content)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                return qrCode.GetGraphic(20);
            }
        }
    }
}
