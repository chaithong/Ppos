using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ppos.Class
{
    internal class Class_Item_Detail
    {
        public static void Created(string group_main, string group_sub, string name, 
            string small_barcode,string small_unit,string small_price,string small_cost_last,string small_cost_avg,string small_qty,
            string medium_barcode,string medium_unit,string medium_price,string medium_cost_last,string medium_cost_avg,string medium_qty,string medium_qty_small,
            string large_barcode,string large_unit,string large_price,string large_cost_last,string large_cost_avg,string large_qty,string large_qty_small,
            bool sale_vat,bool sale_negative,bool item_weight,bool effective_promotion,bool effective_member,bool effective_hotkey
            )
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        double cost;
                        // สร้าง insert
                        // มีแต่สินค้าเล็ก
                        if (medium_barcode.Trim() == "" && large_barcode.Trim() == "")
                        {
                            // set 0 medium
                            medium_unit = "";
                            medium_price = "0";
                            medium_qty = "0";
                            medium_qty_small = "0";
                            medium_cost_last = "0";
                            medium_cost_avg = "0";

                            // set 0 large
                            large_unit = "";
                            large_price = "0";
                            large_qty = "0";
                            large_qty_small = "0";
                            large_cost_last = "0";
                            large_cost_avg = "0";

                            // มีจำนวนตัวเล็ก
                            if (Convert.ToDouble(small_qty) > 0) 
                            {
                                // มีทุนเล็ก
                                if(Convert.ToDouble(small_cost_last) > 0)
                                {
                                    // avg จะ เท่ากับ last
                                    small_cost_avg = small_cost_last;
                                }
                                // ไม่มีทุนเล็ก
                                else if(Convert.ToDouble(small_cost_last) == 0)
                                {
                                    small_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            // ไม่มีจำนวนตัวเล็ก
                            else if (Convert.ToDouble(small_qty) <= 0)
                            {
                                small_cost_last = "0";
                                small_cost_avg = "0";
                            }
                            else
                            {
                                MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                           
                        }
                        // มีหน่วยเล็ก มีหน่วยกลาง ไม่มีหน่วยใหญ่ ////////////////////////////////////////////////////////////////////////////////////////////
                        else if (medium_barcode.Trim() != "" && large_barcode.Trim() == "")
                        {
                            // set 0 large
                            large_unit = "";
                            large_price = "0";
                            large_qty = "0";
                            large_qty_small = "0";
                            large_cost_last = "0";
                            large_cost_avg = "0";

                            
                            // มีจำนวนตัวเล็ก // มีจำนวนตัวกลาง
                            if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) > 0)
                            {

                                // มีทุนตัวเล็ก // มีทุนตัวกลาง
                                if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                                   (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last));
                                    cost = cost / (Convert.ToDouble(small_qty) + (Convert.ToDouble(medium_qty)* Convert.ToDouble(medium_qty_small)));

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();
                                }
                                // มีทุนตัวเล็ก // ไม่มีมีทุนตัวกลาง
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    // avg จะ เท่ากับ last
                                    small_cost_avg = small_cost_last;

                                    medium_cost_avg = (Convert.ToDouble(small_cost_last) * Convert.ToDouble(medium_qty_small)).ToString();
                                }
                                // ไม่มีทุนตัวเล็ก // มีมีทุนตัวกลาง
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    // ถ้ามีแต่ทุนกลาง จะหาทุนทั้งหมดของตัวกลาง แล้วเอามาหารจำนวนทั้งหมดกลาง จะได้ราคาต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last);
                                    cost = cost / (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small));

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();
                                }
                                // ไม่มีทุนตัวเล็ก // ไม่มีมีทุนตัวกลาง
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    // ไม่มีทุนเลย มีแต่จำนวน last ก้บ avg จะเป็น 0
                                    small_cost_avg = "0";
                                    medium_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) + (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small))).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();


                            }
                            // มีจำนวนตัวเล็ก ไม่มีจำนวนตัวกลาง
                            else if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) <= 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยกลาง cost last จะเป็น 0
                                medium_cost_last = "0";

                                // มีทุนตัวเล็ก 
                                if (Convert.ToDouble(small_cost_last) > 0)
                                {
                                    // เล็ก avg จะ เท่ากับ เล็ก last
                                    small_cost_avg = small_cost_last;

                                    // ทุนกลางจะเท่ากับเฉลี่ยตัวเล็ก คูณ จำนวนตัวเล็กในตัวกลาง
                                    medium_cost_avg = (Convert.ToDouble(small_cost_avg) * Convert.ToDouble(medium_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก และไม่มีทุนกลางเพราะจำนวนกลางไม่มี
                                else if(Convert.ToDouble(small_cost_last) == 0)
                                {
                                    small_cost_avg = "0";
                                    medium_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }


                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) + (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small))).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                            }
                            // ไม่มีจำนวนตัวเล็ก มีจำนวนตัวกลาง
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) > 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยเล็ก cost last จะเป็น 0
                                small_cost_last = "0";
                                // มีทุนตัวกลาง
                                if (Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    // เล็ก avg จะหาจากทุนล่าสุดของกลาง หาร จำนวนหน่วยเล็กของกลาง
                                    small_cost_avg = (Convert.ToDouble(medium_cost_last) / Convert.ToDouble(medium_qty_small)).ToString();

                                    // กลาง avg จะเท่ากับ ทุนกลางล่าสุด
                                    medium_cost_avg = medium_cost_last;
                                }
                                // ไม่มีทุนกลาง และไม่มีทุนเล็กเพราะจำนวนเล็กไม่มี
                                else if(Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    small_cost_avg = "0";
                                    medium_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) + (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small))).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();
                            }
                            // ไม่มีจำนวนตัวเล็ก ไม่มีจำนวนตัวกลาง
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) <= 0)
                            {
                                // ต้นทุนจะ 0 หมด 
                                small_cost_last = "0";
                                small_cost_avg = "0";

                                medium_cost_last = "0";
                                medium_cost_avg = "0";
                            }
                            else // ผิดพลาด
                            {
                                MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // มีทั้ง 3 หน่วย //////////////////////////////////////////////////////////////////////////////////////////////////////
                        else if (medium_barcode.Trim() != "" && large_barcode.Trim() != "")
                        {
                            // มีจำนวนตัวเล็ก // มีจำนวนตัวกลาง // มีจำนวนหน่วยใหญ่
                            if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) > 0 && Convert.ToDouble(large_qty) > 0)
                            {
                                // มีทุนเล็ก // มีทุนกลาง // มีทุนใหญ่
                                if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_cost_last));
                                    cost = cost / (Convert.ToDouble(small_qty) + 
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนเล็ก // มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last));
                                    cost = cost / 
                                           (Convert.ToDouble(small_qty) +
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small))
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนเล็ก // ไม่มีทุนกลาง // มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_cost_last));
                                    cost = cost / (Convert.ToDouble(small_qty) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(small_cost_last);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // มีทุนกลาง // มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_cost_last));
                                    cost = cost / 
                                           ((Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(medium_cost_last) / Convert.ToDouble(medium_qty_small) ;

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // ไม่มีทุนกลาง // มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(large_cost_last) / Convert.ToDouble(large_qty_small);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) + 
                                            (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) +
                                            (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                            ).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // มีจำนวนตัวเล็ก // มีจำนวนตัวกลาง // ไม่มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) > 0 && Convert.ToDouble(large_qty) <= 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยใหญ่ cost last จะเป็น 0
                                large_cost_last = "0";

                                // มีทุนเล็ก // มีทุนกลาง // ไม่มีทุนใหญ่
                                if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last)
                                           );
                                    cost = cost / (Convert.ToDouble(small_qty) +
                                           (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small))                                         
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(small_cost_last) ;

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(medium_cost_last) / Convert.ToDouble(medium_qty_small);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) +
                                            (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) 
                                            ).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();

                            }
                            // มีจำนวนตัวเล็ก // ไม่มีจำนวนตัวกลาง // มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) <= 0 && Convert.ToDouble(large_qty) > 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยกลาง cost last จะเป็น 0
                                medium_cost_last = "0";
                                // มีทุนเล็ก // ไม่มีทุนกลาง // มีทุนใหญ่ 
                                if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(small_qty) * Convert.ToDouble(small_cost_last)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_cost_last)
                                           );
                                    cost = cost / (Convert.ToDouble(small_qty) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                           );

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) > 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(small_cost_last);                                       

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // ไม่มีทุนกลาง // มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(large_cost_last) / Convert.ToDouble(large_qty_small);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก // ไม่มีทุนกลาง // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(small_cost_last) == 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(small_qty) +
                                            (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                            ).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // มีจำนวนตัวเล็ก // ไม่มีจำนวนตัวกลาง // ไม่มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) > 0 && Convert.ToDouble(medium_qty) <= 0 && Convert.ToDouble(large_qty) <= 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยกลางกับหน่วยใหญ่ cost last จะเป็น 0
                                medium_cost_last = "0";
                                large_cost_last = "0";
                                // มีทุนเล็ก 
                                if (Convert.ToDouble(small_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(small_cost_last);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนเล็ก
                                else if (Convert.ToDouble(small_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // ไม่มีจำนวนตัวเล็ก // มีจำนวนตัวกลาง // มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) > 0 && Convert.ToDouble(large_qty) > 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยเล็ก cost last จะเป็น 0
                                small_cost_last = "0";

                                // มีทุนกลาง // มีทุนใหญ่ 
                                if (Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_cost_last)) +
                                           (Convert.ToDouble(large_qty) * Convert.ToDouble(large_cost_last));
                                    cost = cost / ((Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) +
                                                  (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small)));

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // มีทุนกลาง // ไม่มีทุนใหญ่ 
                                else if (Convert.ToDouble(medium_cost_last) > 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(medium_cost_last) / Convert.ToDouble(medium_qty_small);                                   

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนกลาง // มีทุนใหญ่ 
                                else if (Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(large_cost_last) / Convert.ToDouble(large_qty_small);                                    

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนกลาง // ไม่มีทุนใหญ่ 
                                else if (Convert.ToDouble(medium_cost_last) == 0 && Convert.ToDouble(large_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = ((Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)) +
                                            (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small))
                                            ).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // ไม่มีจำนวนตัวเล็ก // มีจำนวนตัวกลาง // ไม่มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) > 0 && Convert.ToDouble(large_qty) <= 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยเล็กกับหน่วยใหญ่ cost last จะเป็น 0
                                small_cost_last = "0";
                                large_cost_last = "0";

                                // มีทุนกลาง
                                if (Convert.ToDouble(medium_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(medium_cost_last) / Convert.ToDouble(medium_qty_small);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนกลาง
                                else if (Convert.ToDouble(medium_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(medium_qty) * Convert.ToDouble(medium_qty_small)).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // ไม่มีจำนวนตัวเล็ก // ไม่มีจำนวนตัวกลาง // มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) <= 0 && Convert.ToDouble(large_qty) > 0)
                            {
                                // ถ้าไม่มีจำนวนหน่วยเล็กกับหน่วยกลาง cost last จะเป็น 0
                                small_cost_last = "0";
                                medium_cost_last = "0";
                                // มีทุนใหญ่
                                if (Convert.ToDouble(large_cost_last) > 0)
                                {
                                    // หาทุนต่อหน่วยเล็ก
                                    cost = Convert.ToDouble(large_cost_last) / Convert.ToDouble(large_qty_small);

                                    small_cost_avg = cost.ToString();

                                    medium_cost_avg = (cost * Convert.ToDouble(medium_qty_small)).ToString();

                                    large_cost_avg = (cost * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                // ไม่มีทุนใหญ่
                                else if (Convert.ToDouble(large_cost_last) == 0)
                                {
                                    small_cost_avg = "0";

                                    medium_cost_avg = "0";

                                    large_cost_avg = "0";
                                }
                                else
                                {
                                    MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                // เปลี่ยนจำนวน
                                small_qty = (Convert.ToDouble(large_qty) * Convert.ToDouble(large_qty_small)).ToString();
                                medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();

                                large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                            }
                            // ไม่มีจำนวนตัวเล็ก // ไม่มีจำนวนตัวกลาง // ไม่มีจำนวนหน่วยใหญ่
                            else if (Convert.ToDouble(small_qty) <= 0 && Convert.ToDouble(medium_qty) <= 0 && Convert.ToDouble(large_qty) <= 0)
                            {
                                // ไม่มีจำนวนหมดเลย cost last จะเป็น 0
                                small_cost_last = "0";
                                medium_cost_last = "0";
                                large_cost_last = "0";

                                // ไม่มีจำนวนหมดเลย cost avg จะเป็น 0
                                small_cost_avg = "0";
                                medium_cost_avg = "0";
                                large_cost_avg = "0";
                            }
                            else // ผิดพลาด
                            {
                                MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else  // ผิดพลาด
                        {
                            MessageBox.Show("สร้างข้อมูลไม่ได้ !!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // insert item
                        cmd_sqlite.CommandText = "INSERT INTO Item " +
                                                                   "(created_by,created_date,updated_by,updated_date,code,group_main,group_sub,name," +
                                                                   "small_barcode,small_unit,small_price,small_cost_last,small_cost_avg,small_qty," +
                                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status) " +
                                                                   "VALUES(" +
                                                                   "'" + Class_Parameter.User_Login + "'," +
                                                                   "datetime('now', 'localtime')," +
                                                                   "''," +
                                                                   "''," +
                                                                   "(select COALESCE(max(code),0)+1 from Item)," +
                                                                   "'" + group_main.Trim() + "'," +
                                                                   "'" + group_sub.Trim() + "'," +
                                                                   "'" + name.Trim() + "'," +

                                                                   "'" + small_barcode + "'," +
                                                                   "'" + small_unit.Trim() + "'," +
                                                                   "'" + small_price.Trim() + "'," +
                                                                   "'" + small_cost_last.Trim() + "'," +
                                                                   "'" + small_cost_avg.Trim() + "'," +
                                                                   "'" + small_qty.Trim() + "'," +

                                                                   "'" + medium_barcode.Trim() + "'," +
                                                                   "'" + medium_unit.Trim() + "'," +
                                                                   "'" + medium_price.Trim() + "'," +
                                                                   "'" + medium_cost_last.Trim() + "'," +
                                                                   "'" + medium_cost_avg.Trim() + "'," +
                                                                   "'" + medium_qty.Trim() + "'," +
                                                                   "'" + medium_qty_small.Trim() + "'," +

                                                                   "'" + large_barcode.Trim() + "'," +
                                                                   "'" + large_unit.Trim() + "'," +
                                                                   "'" + large_price.Trim() + "'," +
                                                                   "'" + large_cost_last.Trim() + "'," +
                                                                   "'" + large_cost_avg.Trim() + "'," +
                                                                   "'" + large_qty.Trim() + "'," +
                                                                   "'" + large_qty_small.Trim() + "'," +

                                                                   "" + sale_vat + "," +
                                                                   "" + sale_negative + "," +
                                                                   "" + item_weight + "," +
                                                                   "" + effective_promotion + "," +
                                                                   "" + effective_member + "," +
                                                                   "" + effective_hotkey + "," +
                                                                   "'1')";
                        cmd_sqlite.ExecuteNonQuery();
                        // insert item history
                        /*cmd_sqlite.CommandText = "INSERT INTO Item_History " +
                                                                   "(created_by,created_date,history_type,code,group_main,group_sub,name," +
                                                                   "small_barcode,small_unit,small_price,small_cost_last,small_cost_avg,small_qty," +
                                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status) " +
                                                                   "VALUES(" +
                                                                   "'" + Class_Parameter.User_Login + "'," +
                                                                   "datetime('now', 'localtime')," +
                                                                   "'"+Class_Parameter.Create_Item_History+"'," +
                                                                   "(select COALESCE(max(code),0) from Item)," +
                                                                   "'" + group_main.Trim() + "'," +
                                                                   "'" + group_sub.Trim() + "'," +
                                                                   "'" + name.Trim() + "'," +

                                                                   "'" + small_barcode + "'," +
                                                                   "'" + small_unit.Trim() + "'," +
                                                                   "'" + small_price.Trim() + "'," +
                                                                   "'" + small_cost_last.Trim() + "'," +
                                                                   "'" + small_cost_avg.Trim() + "'," +
                                                                   "'" + small_qty.Trim() + "'," +

                                                                   "'" + medium_barcode.Trim() + "'," +
                                                                   "'" + medium_unit.Trim() + "'," +
                                                                   "'" + medium_price.Trim() + "'," +
                                                                   "'" + medium_cost_last.Trim() + "'," +
                                                                   "'" + medium_cost_avg.Trim() + "'," +
                                                                   "'" + medium_qty.Trim() + "'," +
                                                                   "'" + medium_qty_small.Trim() + "'," +

                                                                   "'" + large_barcode.Trim() + "'," +
                                                                   "'" + large_unit.Trim() + "'," +
                                                                   "'" + large_price.Trim() + "'," +
                                                                   "'" + large_cost_last.Trim() + "'," +
                                                                   "'" + large_cost_avg.Trim() + "'," +
                                                                   "'" + large_qty.Trim() + "'," +
                                                                   "'" + large_qty_small.Trim() + "'," +

                                                                   "" + sale_vat + "," +
                                                                   "" + sale_negative + "," +
                                                                   "" + item_weight + "," +
                                                                   "" + effective_promotion + "," +
                                                                   "" + effective_member + "," +
                                                                   "" + effective_hotkey + "," +
                                                                   "'1')";
                        cmd_sqlite.ExecuteNonQuery();*/

                        // insert trans
                        cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                                 "(created_by,created_date,updated_by,updated_date," +
                                                                 "trans_type,trans_desc," +
                                                                 "item_code,item_barcode," +
                                                                 "item_qty_begin,item_qty,item_qty_end," +
                                                                 "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                                 "small_barcode," +
                                                                 "small_qty_begin,small_qty,small_qty_end," +
                                                                 "small_cost_begin,small_cost,small_cost_end) " +
                                                                 "VALUES(" +
                                                                 "'" + Class_Parameter.User_Login + "'," +
                                                                 "datetime('now', 'localtime')," +
                                                                 "''," +
                                                                 "''," +
                                                                 "'"+Class_Parameter.Create_Item_Small+"'," + // trans_type
                                                                 "''," + // trans_desc
                                                                 "(select COALESCE(max(code),0) from Item)," + // item_code
                                                                 "'" + small_barcode + "'," + // item_barcode
                                                                 "'0'," + // item_qty_begin
                                                                 "'" + small_qty.Trim() + "'," + // item_qty
                                                                 "'" + small_qty.Trim() + "'," + // item_qty_end
                                                                 "'0'," + // item_cost_begin
                                                                 "'" + small_cost_avg.Trim() + "'," + // item_cost
                                                                 "'" + small_cost_avg.Trim() + "'," + // item_cost_end
                                                                 "'1'," + // item_qty_small
                                                                 "'" + small_barcode + "'," + // small_barcode
                                                                 "'0'," + // small_qty_begin
                                                                 "'" + small_qty.Trim() + "'," + // small_qty
                                                                 "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                 "'0'," + // small_cost_begin
                                                                 "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                 "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                             ")";
                        // มีบาร์กลาง
                        if(medium_barcode.Trim() != "") 
                        {
                            cmd_sqlite.CommandText += ",(" +
                                                                 "'" + Class_Parameter.User_Login + "'," +
                                                                 "datetime('now', 'localtime')," +
                                                                 "''," +
                                                                 "''," +
                                                                 "'" + Class_Parameter.Create_Item_Medium + "'," + // trans_type
                                                                 "''," + // trans_desc
                                                                 "(select COALESCE(max(code),0) from Item)," + // item_code                                                               
                                                                 "'" + medium_barcode + "'," + // item_barcode
                                                                 "'0'," + // item_qty_begin
                                                                 "'" + medium_qty.Trim() + "'," + // item_qty
                                                                 "'" + medium_qty.Trim() + "'," + // item_qty_end
                                                                 "'0'," + // item_cost_begin
                                                                 "'" + medium_cost_avg.Trim() + "'," + // item_cost
                                                                 "'" + medium_cost_avg.Trim() + "'," + // item_cost_end
                                                                 "'" + medium_qty_small.Trim() + "'," + // item_qty_small
                                                                 "'" + small_barcode + "'," + // small_barcode
                                                                 "'0'," + // small_qty_begin
                                                                 "'" + small_qty.Trim() + "'," + // small_qty
                                                                 "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                 "'0'," + // small_cost_begin
                                                                 "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                 "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                             ")";
                            // มีบาร์ใหญ่
                            if (large_barcode.Trim() != "")
                            {
                                cmd_sqlite.CommandText += ",(" +
                                                                     "'" + Class_Parameter.User_Login + "'," +
                                                                     "datetime('now', 'localtime')," +
                                                                     "''," +
                                                                     "''," +
                                                                     "'" + Class_Parameter.Create_Item_Large + "'," + // trans_type
                                                                     "''," + // trans_desc
                                                                     "(select COALESCE(max(code),0) from Item)," + // item_code
                                                                     "'" + large_barcode + "'," + // item_barcode
                                                                     "'0'," + // item_qty_begin
                                                                     "'" + large_qty.Trim() + "'," + // item_qty
                                                                     "'" + large_qty.Trim() + "'," + // item_qty_end
                                                                     "'0'," + // item_cost_begin
                                                                     "'" + large_cost_avg.Trim() + "'," + // item_cost
                                                                     "'" + large_cost_avg.Trim() + "'," + // item_cost_end
                                                                     "'" + large_qty_small.Trim() + "'," + // item_qty_small
                                                                     "'" + small_barcode + "'," + // small_barcode
                                                                     "'0'," + // small_qty_begin
                                                                     "'" + small_qty.Trim() + "'," + // small_qty
                                                                     "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                     "'0'," + // small_cost_begin
                                                                     "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                     "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                                 ")";
                            }
                        }
                       
                        cmd_sqlite.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        public static void Edit(string code,
          string group_main, 
          string group_sub, 
          string name,
          string small_barcode, 
          string small_unit, 
          string small_price,
          string small_cost_last,
          string small_cost_avg, 
          string small_qty,
          string medium_barcode, 
          string medium_unit, 
          string medium_price,
          string medium_cost_last,
          string medium_cost_avg,
          string medium_qty,
          string medium_qty_small,
          string large_barcode, 
          string large_unit, 
          string large_price,
          string large_cost_last,
          string large_cost_avg,
          string large_qty,
          string large_qty_small,
          bool sale_vat, 
          bool sale_negative, 
          bool item_weight, 
          bool effective_promotion, 
          bool effective_member, 
          bool effective_hotkey,
          string set_group_main,
          string set_group_sub,
          string set_name,
          string set_small_barcode,
          string set_small_unit,
          string set_small_price,
          string set_small_cost_avg,
          string set_small_qty,
          string set_medium_barcode,
          string set_medium_unit,
          string set_medium_price,
          string set_medium_cost_avg,
          string set_medium_qty,
          string set_medium_qty_small,
          string set_large_barcode,
          string set_large_unit,
          string set_large_price,
          string set_large_cost_avg,
          string set_large_qty,
          string set_large_qty_small,
          bool set_sale_vat,
          bool set_sale_negative,
          bool set_item_weight,
          bool set_effective_promotion,
          bool set_effective_member,
          bool set_effective_hotkey
          )
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        cmd_sqlite.CommandText = "UPDATE Item SET " +
                         "updated_date = datetime('now', 'localtime'), " +
                         "updated_by = '" + Class_Parameter.User_Login + "' ";

                        if (group_main != set_group_main)
                        {
                            cmd_sqlite.CommandText += ",group_main = '" + group_main+"' ";
                        }
                        if (group_sub != set_group_sub)
                        {
                            cmd_sqlite.CommandText += ",group_sub = '" + group_sub + "' ";
                        }
                        if (name != set_name)
                        {
                            cmd_sqlite.CommandText += ",name = '" + name + "' ";
                        }
                        if (small_barcode != set_small_barcode)
                        {
                            cmd_sqlite.CommandText += ",small_barcode = '" + small_barcode + "' ";
                            update_bar_in_trans(set_small_barcode, small_barcode, true);
                        }
                        if (small_unit != set_small_unit)
                        {
                            cmd_sqlite.CommandText += ",small_unit = '" + small_unit + "' ";
                        }
                        // ราคาขาย
                        if (small_price != Convert.ToDouble(set_small_price).ToString("0.##"))
                        {
                            cmd_sqlite.CommandText += ",small_price = '" + small_price + "' ";
                        } 
                        else
                        {
                            small_price = set_small_price;
                        }
                        // ทุนตัวเล็ก
                        if(small_cost_avg != Convert.ToDouble(set_small_cost_avg).ToString("0.##"))
                        {
                            cmd_sqlite.CommandText += ",small_cost_avg = '" + small_cost_avg + "' ";
                        }
                        else
                        {
                            small_cost_avg = set_small_cost_avg;
                        }
                        // จำนวนตัวเล็ก
                        if(small_qty != Convert.ToDouble(set_small_qty).ToString("0.##"))
                        {
                            cmd_sqlite.CommandText += ",small_qty = '" + small_qty.Trim() + "' ";
                        }
                        else
                        {  
                            small_qty = set_small_qty;
                        }
                        // มีบาร์ตัวกลาง
                        if (medium_barcode != string.Empty)
                        {
                            // บาร์ตัวกลาง
                            if(medium_barcode != set_medium_barcode)
                            {
                                cmd_sqlite.CommandText += ",medium_barcode = '" + medium_barcode + "' ";
                                // เป็นการแก้ไข ไม่ใช่การเพิ่มใหม่
                                if(set_medium_barcode != string.Empty)
                                {
                                    // เปลี่ยน barcode ใน trans
                                    update_bar_in_trans(set_medium_barcode, medium_barcode, false);
                                }
                                
                            }
                            // หน่วยตัวกลาง
                            if (medium_unit != set_medium_unit)
                            {
                                cmd_sqlite.CommandText += ",medium_unit = '" + medium_unit + "' ";
                            }                         
                            // ราคาตัวกลาง
                            if (medium_price != Convert.ToDouble(set_medium_price).ToString("0.##"))
                            {
                                cmd_sqlite.CommandText += ",medium_price = '" + medium_price + "' ";
                            } 
                            else
                            {
                                medium_price = set_medium_price;
                            }
                            // จำนวนหน่วยเล็ก
                            if (medium_qty_small != Convert.ToDouble(set_medium_qty_small).ToString("0.##"))
                            {
                                cmd_sqlite.CommandText += ",medium_qty_small = '" + medium_qty_small + "' ";          
                            }
                            else
                            {
                                medium_qty_small = set_medium_qty_small;
                            }
                            // จำนวนหน่วยกลาง // ถ้ามีการเปลี่ยนแปลงจำนวนหน่วยเล็ก
                            if (small_qty != Convert.ToDouble(set_small_qty).ToString("0.##") || medium_qty_small != Convert.ToDouble(set_medium_qty_small).ToString("0"))
                            {
                                // ถ้ามีการเปลี่ยนแปลงจำนวนหน่วยเล็ก มากกว่า 0
                                if(Convert.ToDouble(small_qty) > 0)
                                {
                                    cmd_sqlite.CommandText += ",medium_qty = '" + (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)) + "' ";
                                    medium_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(medium_qty_small)).ToString();
                                }
                                else
                                {
                                    cmd_sqlite.CommandText += ",medium_qty = '0' ";
                                    medium_qty = "0";
                                }
                            }
                            else
                            {
                                medium_qty = set_medium_qty;
                            }
                            // ทุนเฉลี่ยหน่วยกลาง
                            if(small_cost_avg != Convert.ToDouble(set_small_cost_avg).ToString("0.##") || medium_qty_small != Convert.ToDouble(set_medium_qty_small).ToString("0"))
                            {
                                cmd_sqlite.CommandText += ",medium_cost_avg = '" + (Convert.ToDouble(small_cost_avg) * Convert.ToDouble(medium_qty_small)) + "' ";
                                medium_cost_avg = (Convert.ToDouble(small_cost_avg) * Convert.ToDouble(medium_qty_small)).ToString();
                            }
                            else
                            {
                                medium_cost_avg = set_medium_cost_avg;
                            }
                            // มีบาร์ตัวใหญ่
                            if (large_barcode != string.Empty)
                            {
                                // บาร์ตัวใหญ่
                                if (large_barcode != set_large_barcode)
                                {
                                    cmd_sqlite.CommandText += ",large_barcode = '" + large_barcode + "' ";
                                    // เป็นการแก้ไข ไม่ใช่การเพิ่มใหม่
                                    if (set_large_barcode != string.Empty)
                                    {
                                        // เปลี่ยน barcode ใน trans
                                        update_bar_in_trans(set_large_barcode, large_barcode, false);
                                    }
                                   
                                }
                                // หน่วยตัวใหญ่
                                if (large_unit != set_large_unit)
                                {
                                    cmd_sqlite.CommandText += ",large_unit = '" + large_unit + "' ";
                                }
                                // ราคาตัวใหญ่
                                if (large_price != Convert.ToDouble(set_large_price).ToString("0.##"))
                                {
                                    cmd_sqlite.CommandText += ",large_price = '" + large_price + "' ";
                                }
                                else
                                {
                                    large_price = set_large_price;
                                }
                                // จำนวนหน่วยเล็ก
                                if (large_qty_small != Convert.ToDouble(set_large_qty_small).ToString("0.##"))
                                {
                                    cmd_sqlite.CommandText += ",large_qty_small = '" + large_qty_small + "' ";
                                }
                                else
                                {
                                    large_qty_small = set_large_qty_small;
                                }
                                // จำนวนหน่วยใหญ่ // ถ้ามีการเปลี่ยนแปลงจำนวนหน่วยเล็ก
                                if (small_qty != Convert.ToDouble(set_small_qty).ToString("0.##") || large_qty_small != Convert.ToDouble(set_large_qty_small).ToString("0"))
                                {
                                    if (Convert.ToDouble(small_qty) > 0)
                                    {
                                        cmd_sqlite.CommandText += ",large_qty = '" + (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)) + "' ";
                                        large_qty = (Convert.ToDouble(small_qty) / Convert.ToDouble(large_qty_small)).ToString();
                                    }
                                    else
                                    {
                                        cmd_sqlite.CommandText += ",large_qty = '0' ";
                                        large_qty = "0";
                                    }
                                }
                                else
                                {
                                    large_qty = set_large_qty;
                                }
                                // ทุนเฉลี่ยหน่วยใหญ่
                                if(small_cost_avg != Convert.ToDouble(set_small_cost_avg).ToString("0.##") || large_qty_small != Convert.ToDouble(set_large_qty_small).ToString("0"))
                                {
                                    cmd_sqlite.CommandText += ",large_cost_avg = '" + (Convert.ToDouble(small_cost_avg) * Convert.ToDouble(large_qty_small)) + "' ";
                                    large_cost_avg = (Convert.ToDouble(small_cost_avg) * Convert.ToDouble(large_qty_small)).ToString();
                                }
                                else
                                {
                                    large_cost_avg = set_large_cost_avg;
                                }
                            }
                            // ไม่มีบาร์ใหญ่
                            else
                            {
                                // บาร์ตัวใหญ่                      
                                cmd_sqlite.CommandText += ",large_barcode = '' ";
                                // หน่วยตัวใหญ่                        
                                cmd_sqlite.CommandText += ",large_unit = '' ";
                                // ราคาตัวใหญ่                    
                                cmd_sqlite.CommandText += ",large_price = '0' ";
                                // จำนวนหน่วยเล็ก                         
                                cmd_sqlite.CommandText += ",large_qty_small = '0' ";
                                // จำนวนหน่วยใหญ่ 
                                cmd_sqlite.CommandText += ",large_qty = '0' ";
                                // ทุนล่าสุดหน่วยใหญ่                    
                                cmd_sqlite.CommandText += ",large_cost_last = '0' ";
                                // ทุนเฉลี่ยหน่วยใหญ่                    
                                cmd_sqlite.CommandText += ",large_cost_avg = '0' ";

                                // set 0 large
                                large_unit = "";
                                large_price = "0";
                                large_qty = "0";
                                large_qty_small = "0";
                                large_cost_last = "0";
                                large_cost_avg = "0";
                            }
                        }
                        // ไม่มีตัวกลาง
                        else
                        {
                            // บาร์ตัวกลาง                       
                                cmd_sqlite.CommandText += ",medium_barcode = '' ";                            
                            // หน่วยตัวกลาง                        
                                cmd_sqlite.CommandText += ",medium_unit = '' ";                            
                            // ราคาตัวกลาง                    
                                cmd_sqlite.CommandText += ",medium_price = '0' ";                          
                            // จำนวนหน่วยเล็ก                         
                                cmd_sqlite.CommandText += ",medium_qty_small = '0' ";                           
                            // จำนวนหน่วยกลาง 
                                cmd_sqlite.CommandText += ",medium_qty = '0' ";
                            // ทุนล่าสุดหน่วยกลาง                    
                            cmd_sqlite.CommandText += ",medium_cost_last = '0' ";
                            // ทุนเฉลี่ยหน่วยกลาง                    
                            cmd_sqlite.CommandText += ",medium_cost_avg = '0' ";

                            // set 0 medium
                            medium_unit = "";
                            medium_price = "0";
                            medium_qty = "0";
                            medium_qty_small = "0";
                            medium_cost_last = "0";
                            medium_cost_avg = "0";

                            // บาร์ตัวใหญ่                      
                            cmd_sqlite.CommandText += ",large_barcode = '' ";
                            // หน่วยตัวใหญ่                        
                            cmd_sqlite.CommandText += ",large_unit = '' ";
                            // ราคาตัวใหญ่                    
                            cmd_sqlite.CommandText += ",large_price = '0' ";
                            // จำนวนหน่วยเล็ก                         
                            cmd_sqlite.CommandText += ",large_qty_small = '0' ";
                            // จำนวนหน่วยใหญ่ 
                            cmd_sqlite.CommandText += ",large_qty = '0' ";
                            // ทุนล่าสุดหน่วยใหญ่                    
                            cmd_sqlite.CommandText += ",large_cost_last = '0' ";
                            // ทุนเฉลี่ยหน่วยใหญ่                    
                            cmd_sqlite.CommandText += ",large_cost_avg = '0' ";

                            // set 0 large // ต้องใส่ 0 เพราะไม่มีตั้งแต่ตัวกลาง
                            large_unit = "";
                            large_price = "0";
                            large_qty = "0";
                            large_qty_small = "0";
                            large_cost_last = "0";
                            large_cost_avg = "0";

                        }
                        // สถานะ
                        if(sale_vat != set_sale_vat)
                        {
                            cmd_sqlite.CommandText += ",sale_vat = " + sale_vat + " ";
                        }
                        if(sale_negative != set_sale_negative)
                        {
                            cmd_sqlite.CommandText += ",sale_negative = " + sale_negative + " ";
                        }
                        if(item_weight != set_item_weight)
                        {
                            cmd_sqlite.CommandText += ",item_weight = " + item_weight + " ";
                        }
                        if(effective_promotion != set_effective_promotion)
                        {
                            cmd_sqlite.CommandText += ",effective_promotion = " + effective_promotion + " ";
                        }
                        if(effective_member != set_effective_member)
                        {
                            cmd_sqlite.CommandText += ",effective_member = " + effective_member + " ";
                        }
                        if(effective_hotkey != set_effective_hotkey)
                        {
                            cmd_sqlite.CommandText += ",effective_hotkey = " + effective_hotkey + " ";
                        }
                        
                        cmd_sqlite.CommandText += "WHERE code = '" + code +"'";

                        // update item
                        cmd_sqlite.ExecuteNonQuery();

                        // insert item history
                       
                       /* cmd_sqlite.CommandText = "INSERT INTO Item_History " +
                                                                   "(created_by,created_date,history_type,code,group_main,group_sub,name," +
                                                                   "small_barcode,small_unit,small_price,small_cost_last,small_cost_avg,small_qty," +
                                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status) " +
                                                                   "VALUES(" +
                                                                   "'" + Class_Parameter.User_Login + "'," +
                                                                   "datetime('now', 'localtime')," +
                                                                   "'" + Class_Parameter.Edit_Item_History + "'," +
                                                                   "'"+code+"'," +
                                                                   "'" + group_main.Trim() + "'," +
                                                                   "'" + group_sub.Trim() + "'," +
                                                                   "'" + name.Trim() + "'," +

                                                                   "'" + small_barcode + "'," +
                                                                   "'" + small_unit.Trim() + "'," +
                                                                   "'" + small_price.Trim() + "'," +
                                                                   "'" + small_cost_last.Trim() + "'," +
                                                                   "'" + small_cost_avg.Trim() + "'," +
                                                                   "'" + small_qty.Trim() + "'," +

                                                                   "'" + medium_barcode.Trim() + "'," +
                                                                   "'" + medium_unit.Trim() + "'," +
                                                                   "'" + medium_price.Trim() + "'," +
                                                                   "'" + medium_cost_last.Trim() + "'," +
                                                                   "'" + medium_cost_avg.Trim() + "'," +
                                                                   "'" + medium_qty.Trim() + "'," +
                                                                   "'" + medium_qty_small.Trim() + "'," +

                                                                   "'" + large_barcode.Trim() + "'," +
                                                                   "'" + large_unit.Trim() + "'," +
                                                                   "'" + large_price.Trim() + "'," +
                                                                   "'" + large_cost_last.Trim() + "'," +
                                                                   "'" + large_cost_avg.Trim() + "'," +
                                                                   "'" + large_qty.Trim() + "'," +
                                                                   "'" + large_qty_small.Trim() + "'," +

                                                                   "" + sale_vat + "," +
                                                                   "" + sale_negative + "," +
                                                                   "" + item_weight + "," +
                                                                   "" + effective_promotion + "," +
                                                                   "" + effective_member + "," +
                                                                   "" + effective_hotkey + "," +
                                                                   "'1')";
                        cmd_sqlite.ExecuteNonQuery();*/

                        // insert Transactions

                        if (small_qty != set_small_qty || // แก้ไขจำนวนตัวเล็ก
                           small_cost_avg != set_small_cost_avg || // แก้ไขทุนเฉลี่ยตัวเล็ก
                           (medium_qty_small != set_medium_qty_small && medium_barcode != string.Empty) || // แก้ไขจำนวนหน่วยเล็กของ กลาง และไม่ลบบาร์กลาง ถ้าลบออกไม่เข้า trans
                           (large_qty_small != set_large_qty_small && large_barcode != string.Empty)) // แก้ไขจำนวนหน่วยเล็กของ ใหญ่ และไม่ลบาร์ใหญ่ ถ้าลบออกไม่เข้า trans
                        {
                            // ปรับจำนวนจะเป็นการกำหนด
                            
                            cmd_sqlite.CommandText = "INSERT INTO Transactions " +
                                                                     "(created_by,created_date,updated_by,updated_date," +
                                                                     "trans_type,trans_desc," +
                                                                     "item_code,item_barcode," +
                                                                     "item_qty_begin,item_qty,item_qty_end," +
                                                                     "item_cost_begin,item_cost,item_cost_end,item_qty_small," +
                                                                     "small_barcode," +
                                                                     "small_qty_begin,small_qty,small_qty_end," +
                                                                     "small_cost_begin,small_cost,small_cost_end) " +
                                                                     "VALUES(" +
                                                                     "'" + Class_Parameter.User_Login + "'," +
                                                                     "datetime('now', 'localtime')," +
                                                                     "''," +
                                                                     "''," +
                                                                     "'" + Class_Parameter.Edit_Item + "'," + // trans_type
                                                                     "''," + // trans_desc
                                                                     "'"+code+"'," + // item_code
                                                                     "'" + small_barcode + "'," + // item_barcode
                                                                     "'" + set_small_qty.Trim() + "'," + // item_qty_begin
                                                                     "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // item_qty                                                                  
                                                                     "'" + small_qty.Trim() + "'," + // item_qty_end
                                                                     "'" + set_small_cost_avg.Trim() + "'," + // item_cost_begin
                                                                     "'" + small_cost_avg.Trim() + "'," + // item_cost
                                                                     "'" + small_cost_avg.Trim() + "'," + // item_cost_end
                                                                     "'1'," + // item_qty_small
                                                                     "'" + small_barcode + "'," + // small_barcode
                                                                     "'" + set_small_qty.Trim() + "'," + // small_qty_begin
                                                                     "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // small_qty
                                                                     "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                     "'" + set_small_cost_avg.Trim() + "'," + // small_cost_begin
                                                                     "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                     "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                                 ")";
                            // มีบาร์กลาง 
                            if (medium_barcode.Trim() != string.Empty)
                            {
                                // เคยมีแล้ว
                                if (set_medium_barcode.Trim() != string.Empty)
                                {
                                    cmd_sqlite.CommandText += ",(" +
                                                                    "'" + Class_Parameter.User_Login + "'," +
                                                                    "datetime('now', 'localtime')," +
                                                                    "''," +
                                                                    "''," +
                                                                    "'" + Class_Parameter.Edit_Item + "'," + // trans_type
                                                                    "''," + // trans_desc
                                                                    "'" + code + "'," + // item_code
                                                                    "'" + medium_barcode + "'," + // item_barcode
                                                                    "'" + set_medium_qty.Trim() + "'," + // item_qty_begin
                                                                    "'" + (Math.Round(Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(medium_qty_small.Trim()),2) - Math.Round(Convert.ToDouble(set_medium_qty.Trim()),2)) + "'," + // item_qty                                                                  
                                                                    "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_qty_end
                                                                    "'" + set_medium_cost_avg.Trim() + "'," + // item_cost_begin
                                                                    "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_cost
                                                                    "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_cost_end
                                                                    "'" + medium_qty_small.Trim() + "'," + // item_qty_small
                                                                    "'" + small_barcode + "'," + // small_barcode
                                                                    "'" + set_small_qty.Trim() + "'," + // small_qty_begin
                                                                    "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // small_qty
                                                                    "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                    "'" + set_small_cost_avg.Trim() + "'," + // small_cost_begin
                                                                    "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                    "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                                ")";
                                }
                                // แก้ไขและเพิ่มใหม่ บาร์กลาง 
                                else
                                {
                                    cmd_sqlite.CommandText += ",(" +
                                                              "'" + Class_Parameter.User_Login + "'," +
                                                              "datetime('now', 'localtime')," +
                                                              "''," +
                                                              "''," +
                                                              "'" + Class_Parameter.Create_Item_Medium + "'," + // trans_type
                                                              "''," + // trans_desc
                                                              "'" + code + "'," + // item_code
                                                              "'" + medium_barcode + "'," + // item_barcode
                                                              "'0'," + // item_qty_begin
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_qty                                                                  
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_qty_end
                                                              "'0'," + // item_cost_begin
                                                              "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_cost
                                                              "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(medium_qty_small.Trim())) + "'," + // item_cost_end
                                                              "'" + medium_qty_small.Trim() + "'," + // item_qty_small
                                                              "'" + small_barcode + "'," + // small_barcode
                                                              "'" + set_small_qty.Trim() + "'," + // small_qty_begin
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // small_qty
                                                              "'" + small_qty.Trim() + "'," + // small_qty_end
                                                              "'" + set_small_cost_avg.Trim() + "'," + // small_cost_begin
                                                              "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                              "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                              ")";

                                
                                }
                               
                            }
                            // มีบาร์ใหญ่ 
                            if (large_barcode.Trim() != string.Empty)
                            {
                                // เคยมีแล้ว
                                if(set_large_barcode.Trim() != string.Empty)
                                {
                                    cmd_sqlite.CommandText += ",(" +
                                                                     "'" + Class_Parameter.User_Login + "'," +
                                                                     "datetime('now', 'localtime')," +
                                                                     "''," +
                                                                     "''," +
                                                                     "'" + Class_Parameter.Edit_Item + "'," + // trans_type
                                                                     "''," + // trans_desc
                                                                     "'" + code + "'," + // item_code
                                                                     "'" + large_barcode + "'," + // item_barcode
                                                                     "'" + set_large_qty.Trim() + "'," + // item_qty_begin
                                                                     "'" + (Math.Round(Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(large_qty_small.Trim()),2) - Math.Round(Convert.ToDouble(set_large_qty.Trim()),2)) + "'," + // item_qty
                                                                     "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_qty_end
                                                                     "'" + set_large_cost_avg.Trim() + "'," + // item_cost_begin
                                                                     "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_cost
                                                                     "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_cost_end
                                                                     "'" + large_qty_small.Trim() + "'," + // item_qty_small
                                                                     "'" + small_barcode + "'," + // small_barcode
                                                                     "'" + set_small_qty.Trim() + "'," + // small_qty_begin
                                                                     "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // small_qty
                                                                     "'" + small_qty.Trim() + "'," + // small_qty_end
                                                                     "'" + set_small_cost_avg.Trim() + "'," + // small_cost_begin
                                                                     "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                                     "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                                                            ")";
                                }
                                // แก้ไขและเพิ่มใหม่ บาร์ใหญ่
                                else
                                {
                                    cmd_sqlite.CommandText += ",(" +
                                                              "'" + Class_Parameter.User_Login + "'," +
                                                              "datetime('now', 'localtime')," +
                                                              "''," +
                                                              "''," +
                                                              "'" + Class_Parameter.Create_Item_Large + "'," + // trans_type
                                                              "''," + // trans_desc
                                                              "'" + code + "'," + // item_code
                                                              "'" + large_barcode + "'," + // item_barcode
                                                              "'0'," + // item_qty_begin
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_qty                                                                  
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) / Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_qty_end
                                                              "'0'," + // item_cost_begin
                                                              "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_cost
                                                              "'" + (Convert.ToDouble(small_cost_avg.Trim()) * Convert.ToDouble(large_qty_small.Trim())) + "'," + // item_cost_end
                                                              "'" + large_qty_small.Trim() + "'," + // item_qty_small
                                                              "'" + small_barcode + "'," + // small_barcode
                                                              "'" + set_small_qty.Trim() + "'," + // small_qty_begin
                                                              "'" + (Convert.ToDouble(small_qty.Trim()) - Convert.ToDouble(set_small_qty.Trim())) + "'," + // small_qty
                                                              "'" + small_qty.Trim() + "'," + // small_qty_end
                                                              "'" + set_small_cost_avg.Trim() + "'," + // small_cost_begin
                                                              "'" + small_cost_avg.Trim() + "'," + // small_cost
                                                              "'" + small_cost_avg.Trim() + "'" + // small_cost_end
                                                              ")";

                                  
                                }
                                
                            }

                            cmd_sqlite.ExecuteNonQuery();
                        }
                       
                    }
                    con_sqlite.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void update_bar_in_trans(string barOld , string barNew , bool small)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // update trans
                        cmd_sqlite.CommandText = "update Transactions set item_barcode = '"+barNew+"' where item_barcode = '"+barOld+"'";
                        cmd_sqlite.ExecuteNonQuery();

                        if (small)
                        {
                            cmd_sqlite.CommandText = "update Transactions set small_barcode = '" + barNew + "' where small_barcode = '" + barOld + "'";
                            cmd_sqlite.ExecuteNonQuery();
                        }
                        // update hotkey
                        cmd_sqlite.CommandText = "update Item_Hotkey set barcode = '" + barNew + "' where barcode = '" + barOld + "'";
                        cmd_sqlite.ExecuteNonQuery();

                        if (small)
                        {
                            cmd_sqlite.CommandText = "update Item_Hotkey set small_barcode = '" + barNew + "' where small_barcode = '" + barOld + "'";
                            cmd_sqlite.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Delete(string code,
          string group_main,
          string group_sub,
          string name,
          string small_barcode,
          string small_unit,
          string small_price,
          string small_cost_last,
          string small_cost_avg,
          string small_qty,
          string medium_barcode,
          string medium_unit,
          string medium_price,
          string medium_cost_last,
          string medium_cost_avg,
          string medium_qty,
          string medium_qty_small,
          string large_barcode,
          string large_unit,
          string large_price,
          string large_cost_last,
          string large_cost_avg,
          string large_qty,
          string large_qty_small,
          bool sale_vat,
          bool sale_negative,
          bool item_weight,
          bool effective_promotion,
          bool effective_member,
          bool effective_hotkey)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {

                        cmd_sqlite.CommandText = "UPDATE Item SET status = 0, " +
                                          "updated_date = datetime('now', 'localtime'), " +
                                          "updated_by = '" + Class_Parameter.User_Login + "' " +
                                        "WHERE code = "+ code ;
                        cmd_sqlite.ExecuteNonQuery();

                        // insert item history

                       /* cmd_sqlite.CommandText = "INSERT INTO Item_History " +
                                                                   "(created_by,created_date,history_type,code,group_main,group_sub,name," +
                                                                   "small_barcode,small_unit,small_price,small_cost_last,small_cost_avg,small_qty," +
                                                                   "medium_barcode,medium_unit,medium_price,medium_cost_last,medium_cost_avg,medium_qty,medium_qty_small," +
                                                                   "large_barcode,large_unit,large_price,large_cost_last,large_cost_avg,large_qty,large_qty_small," +
                                                                   "sale_vat,sale_negative,item_weight,effective_promotion,effective_member,effective_hotkey,status) " +
                                                                   "VALUES(" +
                                                                   "'" + Class_Parameter.User_Login + "'," +
                                                                   "datetime('now', 'localtime')," +
                                                                   "'" + Class_Parameter.Delete_Item_History + "'," +
                                                                   "'" + code + "'," +
                                                                   "'" + group_main.Trim() + "'," +
                                                                   "'" + group_sub.Trim() + "'," +
                                                                   "'" + name.Trim() + "'," +

                                                                   "'" + small_barcode + "'," +
                                                                   "'" + small_unit.Trim() + "'," +
                                                                   "'" + small_price.Trim() + "'," +
                                                                   "'" + small_cost_last.Trim() + "'," +
                                                                   "'" + small_cost_avg.Trim() + "'," +
                                                                   "'" + small_qty.Trim() + "'," +

                                                                   "'" + medium_barcode.Trim() + "'," +
                                                                   "'" + medium_unit.Trim() + "'," +
                                                                   "'" + medium_price.Trim() + "'," +
                                                                   "'" + medium_cost_last.Trim() + "'," +
                                                                   "'" + medium_cost_avg.Trim() + "'," +
                                                                   "'" + medium_qty.Trim() + "'," +
                                                                   "'" + medium_qty_small.Trim() + "'," +

                                                                   "'" + large_barcode.Trim() + "'," +
                                                                   "'" + large_unit.Trim() + "'," +
                                                                   "'" + large_price.Trim() + "'," +
                                                                   "'" + large_cost_last.Trim() + "'," +
                                                                   "'" + large_cost_avg.Trim() + "'," +
                                                                   "'" + large_qty.Trim() + "'," +
                                                                   "'" + large_qty_small.Trim() + "'," +

                                                                   "" + sale_vat + "," +
                                                                   "" + sale_negative + "," +
                                                                   "" + item_weight + "," +
                                                                   "" + effective_promotion + "," +
                                                                   "" + effective_member + "," +
                                                                   "" + effective_hotkey + "," +
                                                                   "'0')";
                        cmd_sqlite.ExecuteNonQuery();*/
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
