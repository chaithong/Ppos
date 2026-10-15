using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Ppos.Class
{
    internal class Class_Check_Pro
    {
        public static bool Desc(string proDesc , string proId)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "SELECT p.pro_desc from Promotion p where p.status = 1 " +
                                                 "and p.pro_desc = '" + proDesc + "' ";
                        if(proId != "")
                        {
                            cmd_sqlite.CommandText += "and p.pro_id <> "+proId;
                        }
                        var e = cmd_sqlite.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(e);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(
                                "รายละเอียด : "+ proDesc + Environment.NewLine +
                                "มีอยู่แล้ว กรุณาใช้ชื่อใหม่"
                                ,
                                "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Edit_Pro(string proId)
        {
            try
            {
                if(proId != "")
                {
                    using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                    {
                        con_sqlite.Open();
                        using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                        {
                            cmd_sqlite.CommandText = @"SELECT 1 from Invoice_Body_Temp ibt 
                                                       where ibt.void = false and ibt.pro_id = "+proId;

                            var e = cmd_sqlite.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(e);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(                                
                                    "ไม่สามารถแก้ไขโปรนี้ได้ เนื่องจากมีสินค้าอยู่ที่หน้าขายสินค้า !!",
                                    "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public static bool Item_Duplicate(DataGridView itemPro, DataGridView itemPremiumPro, string offerType)
        {
            try
            {
                if (offerType == Class_Parameter.offer_type_premium)
                {
                    bool isDuplicate = false;

                    foreach (DataGridViewRow row1 in itemPro.Rows)
                    {
                        if (row1.Cells["item_code_pro"].Value == null) continue;
                        string code1 = row1.Cells["item_code_pro"].Value!.ToString()!;

                        foreach (DataGridViewRow row2 in itemPremiumPro.Rows)
                        {
                            if (row2.Cells["item_code_premium_pro"].Value == null) continue;
                            string code2 = row2.Cells["item_code_premium_pro"].Value!.ToString()!;

                            if (code1 == code2)
                            {
                                isDuplicate = true;
                                break; // เจอซ้ำแล้ว สั่งหยุด Loop ด้านในทันที
                            }
                        }
                        if (isDuplicate) break; // หยุด Loop ด้านนอกด้วย
                    }

                    if (isDuplicate)
                    {
                        MessageBox.Show(
                                   "สินค้าโปร ซ้ำกับ สินค้าแถม !!" + Environment.NewLine +
                                   "ถ้าต้องการแถมสินค้าเดียวกัน"+Environment.NewLine+
                                   "ใช้โปรต่อสินค้า และเลือกลดราคา ต่อมูลค่า",
                                   "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool Items(DataGridView itemPro , DataGridView itemPremiumPro, string proId)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // ค้นหา item pro
                        for (int i = 0; i < itemPro.Rows.Count; i++)
                        {
                            cmd_sqlite.CommandText = "SELECT p.pro_desc ,p.pro_type,coalesce(pi.item_name,pip.item_name) as item_name " +
                                                     "from Promotion p " +
                                                     "left join Promotion_Items pi on pi.pro_id = p.pro_id and pi.item_code = " + itemPro.Rows[i].Cells["item_code_pro"].Value!.ToString() + " " +
                                                     "left join Promotion_Items_Premium pip on pip.pro_id = p.pro_id and pip.item_code = " + itemPro.Rows[i].Cells["item_code_pro"].Value!.ToString() +" "+
                                                     "where p.status = 1  and coalesce(pi.item_name,pip.item_name) not null " ;
                            if (proId != "") // บันทึกจากแก้ไข
                            {
                                cmd_sqlite.CommandText += "and p.pro_id <> " + proId;
                            }

                            var e = cmd_sqlite.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(e);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(
                                    "มีสินค้าอยู่ในโปรโมชั่นแล้ว !!" + Environment.NewLine +
                                    "สินค้า : " + dt.Rows[0]["item_name"].ToString() + Environment.NewLine +
                                    "ชื่อโปร : " + dt.Rows[0]["pro_desc"].ToString(),
                                    "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        // ค้นหา item premium
                        for (int i = 0; i < itemPremiumPro.Rows.Count; i++)
                        {
                            cmd_sqlite.CommandText = "SELECT p.pro_desc ,p.pro_type,coalesce(pi.item_name,pip.item_name) as item_name " +
                                                     "from Promotion p " +
                                                     "left join Promotion_Items pi on pi.pro_id = p.pro_id and pi.item_code = " + itemPremiumPro.Rows[i].Cells["item_code_premium_pro"].Value!.ToString() + " " +
                                                     "left join Promotion_Items_Premium pip on pip.pro_id = p.pro_id and pip.item_code = " + itemPremiumPro.Rows[i].Cells["item_code_premium_pro"].Value!.ToString() + " "+
                                                     "where p.status = 1  and coalesce(pi.item_name,pip.item_name) not null ";
                            if (proId != "") // บันทึกจากแก้ไข
                            {
                                cmd_sqlite.CommandText += "and p.pro_id <> " + proId;
                            }

                            var e = cmd_sqlite.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(e);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(
                                    "มีสินค้าอยู่ในโปรโมชั่นแล้ว !!" + Environment.NewLine +
                                    "สินค้า : " + dt.Rows[0]["item_name"].ToString() + Environment.NewLine +
                                    "ชื่อโปร : " + dt.Rows[0]["pro_desc"].ToString(),
                                    "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                      
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        public static bool Amounts(
            string proDesc,
            string criterionType , 
            string criterionValue,
            string offerType,
            string offerValue,
            string discountType,
            DataGridView itemPro
            )
        {
            try
            {
                // โปรต่อสินค้า
                if(proDesc == Class_Parameter.pro_base_item)
                {
                    // โปรต่อสินค้า เกณฑ์จำนวน
                    if (criterionType == Class_Parameter.criterion_type_qty)
                    {
                        // โปรต่อสินค้า เกณฑ์จำนวน ประเภทลดราคา
                        if (offerType == Class_Parameter.offer_type_discount)
                        {
                            // โปรต่อสินค้า เกณฑ์จำนวน ประเภทลดราคา ต่อหน่วย
                            if(discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // จะเทียบส่วนลดต่อหน่วยทุกสินค้า
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("ลดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรต่อสินค้า เกณฑ์จำนวน ประเภทลดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // จะเทียบส่วนลดต่อจำนวนหน่วย criterion ทุกสินค้า
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                        Convert.ToDouble(criterionValue))
                                    {
                                        MessageBox.Show("ลดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "มูลค่าขาย "+ criterionValue + " หน่วย : " + (Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) * Convert.ToDouble(criterionValue)).ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                        // โปรต่อสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา
                        else if (offerType == Class_Parameter.offer_type_set_value)
                        {
                            // โปรต่อสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // จะกำหนดไม่เกินราคาขายปกติ ต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้ากำหนดมากกว่าหรือเท่ากับราคาขาย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("กำหนดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขายต่อหน่วย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรต่อสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // จะกำหนดไม่เกินราคาขายต่อจำนวนหน่วย criterion
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้ากำหนดมากกว่าหรือเท่ากับราคาขายต่อจำนวนหน่วย criterion จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                        Convert.ToDouble(criterionValue))
                                    {
                                        MessageBox.Show("กำหนดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "มูลค่าขาย " + criterionValue + " หน่วย : " + (Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) * Convert.ToDouble(criterionValue)).ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                        // โปรต่อสินค้า เกณฑ์จำนวน ประเภทแถมสินค้า
                        else if (offerType == Class_Parameter.offer_type_premium)
                        {
                            // โปรต่อสินค้า เกณฑ์จำนวน ประเภทแถมสินค้า ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // การแถมจะไม่ตรวจสอบราคา 
                             
                            }                          
                        }
                    }
                    // โปรต่อสินค้า เกณฑ์มูลค่า
                    else if (criterionType == Class_Parameter.criterion_type_value)
                    {
                        // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทลดราคา
                        if (offerType == Class_Parameter.offer_type_discount)
                        {
                            // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทลดราคา ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // มูลค่าจะต้องมากกว่าหรือเท่ากับ ราคาขายต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้าเกณฑ์มูลค่า น้อยกว่า ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(criterionValue) <
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("มูลค่า ต้องมากกว่าหรือเท่ากับ ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                    // ถ้าลดมากกว่าราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                       Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("ลดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทลดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // มูลค่า ต้องมากกว่า ส่วนลด
                                if(Convert.ToDouble(criterionValue) <= Convert.ToDouble(offerValue))
                                {
                                    MessageBox.Show("มูลค่า ต้องมากกว่า ลดราคา"
                                   , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                // เกณฑ์มูลค่าต้องมากกว่าราคาต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้าเกณฑ์มูลค่า น้อยกว่า ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(criterionValue) <
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("มูลค่า ต้องมากกว่าหรือเท่ากับ ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }                                   
                                }
                            }
                        }
                        // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทกำหนดราคา
                        else if (offerType == Class_Parameter.offer_type_set_value)
                        {
                            // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทกำหนดราคา ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // มูลค่าจะต้องมากกว่าหรือเท่ากับ ราคาขายต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้าเกณฑ์มูลค่า น้อยกว่า ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(criterionValue) <
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("มูลค่า ต้องมากกว่าหรือเท่ากับ ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                    // ถ้ากำหนดมากกว่าหรือเท่ากับ ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                       Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("กำหนดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทกำหนดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // มูลค่า ต้องมากกว่า ส่วนลด
                                if (Convert.ToDouble(criterionValue) <= Convert.ToDouble(offerValue))
                                {
                                    MessageBox.Show("มูลค่า ต้องมากกว่า กำหนดราคา"
                                   , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                // เกณฑ์มูลค่าต้องมากกว่าหรือเท่ากับราคาต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้าเกณฑ์มูลค่า น้อยกว่า ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(criterionValue) <
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("มูลค่า ต้องมากกว่าหรือเท่ากับ ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                        // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทแถมสินค้า
                        else if (offerType == Class_Parameter.offer_type_premium)
                        {
                            // โปรต่อสินค้า เกณฑ์มูลค่า ประเภทแถมสินค้า ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // เกณฑ์มูลค่าต้องมากกว่าหรือเท่ากับราคาต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้าเกณฑ์มูลค่า น้อยกว่า ราคาขายต่อหน่วย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(criterionValue) <
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("มูลค่า ต้องมากกว่าหรือเท่ากับ ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                // โปรคละสินค้า 
                else if(proDesc == Class_Parameter.pro_mix_item)
                {
                    // โปรคละสินค้า เกณฑ์จำนวน // * เกณฑ์จะจำนวนเสมอ
                    if (criterionType == Class_Parameter.criterion_type_qty)
                    {
                        // โปรคละสินค้า เกณฑ์จำนวน ประเภทลดราคา
                        if (offerType == Class_Parameter.offer_type_discount)
                        {
                            // โปรคละสินค้า เกณฑ์จำนวน ประเภทลดราคา ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // จะเทียบส่วนลดต่อหน่วยทุกสินค้า
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("ลดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรคละสินค้า เกณฑ์จำนวน ประเภทลดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // จะเทียบส่วนลดต่อจำนวนหน่วย criterion ทุกสินค้า
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                        Convert.ToDouble(criterionValue))
                                    {
                                        MessageBox.Show("ลดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "มูลค่าขาย " + criterionValue + " หน่วย : " + (Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) * Convert.ToDouble(criterionValue)).ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                        // โปรคละสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา
                        else if (offerType == Class_Parameter.offer_type_set_value)
                        {
                            // โปรคละสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // จะกำหนดไม่เกินราคาขายปกติ ต่อหน่วย
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้ากำหนดมากกว่าหรือเท่ากับราคาขาย จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                    {
                                        MessageBox.Show("กำหนดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "ราคาขายต่อหน่วย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            // โปรคละสินค้า เกณฑ์จำนวน ประเภทกำหนดราคา ต่อมูลค่า
                            else if (discountType == Class_Parameter.discount_type_per_value)
                            {
                                // จะกำหนดไม่เกินราคาขายต่อจำนวนหน่วย criterion
                                foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                                {
                                    // ถ้ากำหนดมากกว่าหรือเท่ากับราคาขายต่อจำนวนหน่วย criterion จะบันทึกไม่ได้
                                    if (Convert.ToDouble(offerValue) >=
                                        Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                        Convert.ToDouble(criterionValue))
                                    {
                                        MessageBox.Show("กำหนดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                           "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                            "มูลค่าขาย " + criterionValue + " หน่วย : " + (Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) * Convert.ToDouble(criterionValue)).ToString()
                                            , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                        // โปรคละสินค้า เกณฑ์จำนวน ประเภทแถมสินค้า
                        else if (offerType == Class_Parameter.offer_type_premium)
                        {
                            // โปรคละสินค้า เกณฑ์จำนวน ประเภทแถมสินค้า ต่อหน่วย
                            if (discountType == Class_Parameter.discount_type_per_qty)
                            {
                                // การแถมจะไม่ตรวจสอบราคา 
                            }
                        }
                    }
                }
                // โปรชุดสินค้า
                else if(proDesc == Class_Parameter.pro_set_item)
                {
                    // โปรชุดสินค้า ประเภทลดราคา
                    if (offerType == Class_Parameter.offer_type_discount)
                    {
                        // โปรชุดสินค้า ประเภทลดราคา ต่อหน่วย
                        if (discountType == Class_Parameter.discount_type_per_qty)
                        {
                            // จะเทียบส่วนลดต่อหน่วยทุกสินค้า
                            foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                            {
                                if (Convert.ToDouble(offerValue) >=
                                    Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                {
                                    MessageBox.Show("ลดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                       "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                        "ราคาขาย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                        , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        // โปรชุดสินค้า ประเภทลดราคา ต่อมูลค่า
                        else if (discountType == Class_Parameter.discount_type_per_value)
                        {

                            // ต้องหาราคารวมของชุดสินค้า
                            double sum_price = 0 , sum_qty = 0;
                            foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                            {
                                sum_price += Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                    Convert.ToDouble(rowItemPro.Cells["item_set_qty_pro"].Value);

                                sum_qty += Convert.ToDouble(rowItemPro.Cells["item_set_qty_pro"].Value);
                            }
                            if (Convert.ToDouble(offerValue) >= sum_price)
                            {
                                MessageBox.Show("ลดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                    "มูลค่าขาย 1 ชุด "+sum_qty+" หน่วย : " + sum_price 
                                    , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                    // โปรชุดสินค้า ประเภทกำหนดราคา
                    else if (offerType == Class_Parameter.offer_type_set_value)
                    {
                        // โปรชุดสินค้า ประเภทกำหนดราคา ต่อหน่วย
                        if (discountType == Class_Parameter.discount_type_per_qty)
                        {
                            // จะกำหนดไม่เกินราคาขายปกติ ต่อหน่วย
                            foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                            {
                                // ถ้ากำหนดมากกว่าหรือเท่ากับราคาขาย จะบันทึกไม่ได้
                                if (Convert.ToDouble(offerValue) >=
                                    Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value))
                                {
                                    MessageBox.Show("กำหนดราคา ต้องน้อยกว่า ราคาขาย" + Environment.NewLine +
                                       "สินค้า : " + rowItemPro.Cells["item_name_pro"].Value!.ToString() + Environment.NewLine +
                                        "ราคาขายต่อหน่วย : " + rowItemPro.Cells["item_price_pro"].Value!.ToString()
                                        , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        // โปรชุดสินค้า ประเภทกำหนดราคา ต่อมูลค่า
                        else if (discountType == Class_Parameter.discount_type_per_value)
                        {
                            // กำหนดต้องน้อยกว่า มูลค่ารวม
                            // ต้องหาราคารวมของชุดสินค้า
                            double sum_price = 0, sum_qty = 0;
                            foreach (DataGridViewRow rowItemPro in itemPro.Rows)
                            {
                                sum_price += Convert.ToDouble(rowItemPro.Cells["item_price_pro"].Value) *
                                    Convert.ToDouble(rowItemPro.Cells["item_set_qty_pro"].Value);

                                sum_qty += Convert.ToDouble(rowItemPro.Cells["item_set_qty_pro"].Value);
                            }
                            if (Convert.ToDouble(offerValue) >= sum_price)
                            {
                                MessageBox.Show("กำหนดราคา ต้องน้อยกว่า มูลค่าขาย" + Environment.NewLine +
                                    "มูลค่าขาย 1 ชุด " + sum_qty + " หน่วย : " + sum_price
                                    , "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                    // โปรชุดสินค้า ประเภทแถมสินค้า
                    else if (offerType == Class_Parameter.offer_type_premium)
                    {
                        // โปรชุดสินค้า ประเภทแถมสินค้า ต่อหน่วย
                        if (discountType == Class_Parameter.discount_type_per_qty)
                        {
                            // การแถมจะไม่ตรวจสอบราคา 
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
       
    }
}
