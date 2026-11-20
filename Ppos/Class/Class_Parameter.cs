using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppos.Class
{
    internal class Class_Parameter
    {
        public static string Version = "Ppos V 1.2";
        public static bool runbackground { get; set; } = false;
        public static bool Active { get; set; } = false; // ชื่อไฟล์ txt เก็บข้อมูล Renewal Code ที่ทำการต่ออายุ
        public static string STtxt = "ST.txt"; // ชื่อไฟล์ txt เก็บข้อมูลวันเริ่มใช้งาน
        public static string RCtxt = "RC.txt"; // ชื่อไฟล์ txt เก็บข้อมูล Renewal Code ที่ทำการต่ออายุ

        public static string vat_rate { get; set; } = "7";

        public static string Group_Main = "กลุ่มหลัก";
        public static string Group_Sub = "กลุ่มย่อย";

        public static string store_no { get; set; } = "";
        public static string store_name { get; set; } = "";
        public static string User_Login { get; set; } = "Admin";

        // member
        public static string sale_per_point { get; set; } = "100";

        // ใน trans
        public static string Create_Item_Small = "สร้างสินค้าหน่วยเล็ก";
        public static string Create_Item_Medium = "สร้างสินค้าหน่วยกลาง";
        public static string Create_Item_Large = "สร้างสินค้าหน่วยใหญ่";
        public static string Edit_Item = "แก้ไขสินค้า";
        public static string Adjust_Decrease = "ปรับลด";
        public static string Adjust_Increase = "ปรับเพิ่ม";
        public static string Adjust_Custom = "ปรับกำหนด";

        // ใน history
        public static string Create_Item_History = "สร้างสินค้า";
        public static string Edit_Item_History = "แก้ไขสินค้า";
        public static string Delete_Item_History = "ลบสินค้า";

        // calendar

        public static string calendar_title { get; set; }

        public static string calendar_day { get; set; }
        public static string calendar_month { get; set; }
        public static string calendar_year { get; set; }

        // ปรับจำนวน
        public static int inc_dec_custom { get; set; } = 1;
        public static int last_avg_custom { get; set; } = 2;
        public static bool cost_per_unit { get; set; } = true;

        // promotion

        public static string pro_base_item = "โปรต่อสินค้า";

        public static string pro_mix_item = "โปรคละสินค้า";

        public static string pro_set_item = "โปรชุดสินค้า";

        public static string pro_bill_value = "โปรมูลค่าท้ายบิล";


        public static string criterion_type_qty = "จำนวน";

        public static string criterion_type_value = "มูลค่า";

       
        public static string offer_type_discount = "ลดราคา";

        public static string offer_type_set_value = "กำหนดราคา";

        public static string offer_type_premium = "แถมสินค้า";


        public static string discount_type_per_qty = "ต่อหน่วย";

        public static string discount_type_per_value = "ต่อมูลค่า";


        public static string repeat = "ทำซ้ำ";

        public static string not_repeat = "ไม่ทำซ้ำ";

        public static bool pro_mon { get; set; } = true;
        public static bool pro_tue { get; set; } = true;
        public static bool pro_wed { get; set; } = true;
        public static bool pro_thu { get; set; } = true;
        public static bool pro_fri { get; set; } = true;
        public static bool pro_sat { get; set; } = true;
        public static bool pro_sun { get; set; } = true;

        // item_hotkey_set

        public static int hotkey_pag { get; set; } = 1;
        public static int column_count { get; set; } = 1;
        public static float row_height { get; set; } = 200;
        public static float font_size { get; set; } = 16;
        public static string image_type { get; set; } = "บน";
        public static string button_color { get; set; } = "White";
        public static string font_color { get; set; } = "Black";
        public static string hotkey_title_1 { get; set; } = "คีย์ลัด1";
        public static string hotkey_title_2 { get; set; } = "คีย์ลัด2";
        public static string hotkey_title_3 { get; set; } = "คีย์ลัด3";

        public static string hotkey_hot_sale_back_date { get; set; } = "7";
        public static string hotkey_hot_sale_limit { get; set; } = "10";
        public static string hotkey_last_sale_back_date { get; set; } = "7";
        public static string hotkey_last_sale_limit { get; set; } = "10";


        // Camera
        public static string device_name { get; set; } = "";

        ////// configure

        public static bool login_program { get; set; } = true;
        public static bool use_item_medium_large { get; set; } = true;
        public static bool custom_cost_adjust { get; set; } = true;
        public static bool sale_show_hotkey { get; set; } = true;
        public static bool pay_show_keypad { get; set; } = true;
        public static bool pay_show_change { get; set; } = true;

        ////// Sale
        public static int id_body_temp { get; set; } = 0;
        public static int menu_check { get; set; } = 1;
        public static bool sale_hotkey_left { get; set; } = true;

        public static float sale_left_width { get; set; } = 50;
        public static float pay_left_width { get; set; } = 50;
        public static bool visible_sum_qty { get; set; } = true;
        public static bool visible_sum_price { get; set; } = true;
        public static bool visible_dis_pro { get; set; } = true;
        public static bool visible_dis_member { get; set; } = true;
        public static bool visible_dis_round { get; set; } = true;

        public static bool keypad_numeric { get; set; } = true;

        // Invoice set

        public static bool inv_print { get; set; } = true;
        public static string inv_print_name { get; set; } = "";

        public static float inv_width { get; set; } = 80;
        public static float inv_margin { get; set; } = 5;

        public static bool inv_logo { get; set; } = true;
        public static float inv_logo_width { get; set; } = 50;

        public static float inv_name_fontsize { get; set; } = 13;
        public static bool inv_name_bold { get; set; } = true;

        public static bool inv_address { get; set; } = true;
        public static float inv_address_fontsize { get; set; } = 8;
        public static bool inv_address_bold { get; set; } = false;

        public static bool inv_phone { get; set; } = true;
        public static float inv_phone_fontsize { get; set; } = 8;
        public static bool inv_phone_bold { get; set; } = true;

        public static float inv_type_fontsize { get; set; } = 8;
        public static bool inv_type_bold { get; set; } = true;

        public static bool inv_line_point { get; set; } = true;

        public static float inv_trx_no_fontsize { get; set; } = 9;
        public static bool inv_trx_no_bold { get; set; } = true;

        public static float inv_head_fontsize { get; set; } = 9;
        public static bool inv_head_bold { get; set; } = true;

        public static float inv_item_fontsize { get; set; } = 8;
        public static bool inv_item_bold { get; set; } = false;

        public static float inv_sum_fontsize { get; set; } 
        public static bool inv_sum_bold { get; set; } 

        public static float inv_net_fontsize { get; set; } 
        public static bool inv_net_bold { get; set; } 

        public static bool inv_sum_vat { get; set; } 

        public static bool inv_pro { get; set; } 
        public static float inv_pro_head_fontsize { get; set; }
        public static bool inv_pro_head_bold { get; set; } 
        public static float inv_pro_fontsize { get; set; } 
        public static bool inv_pro_bold { get; set; } 

        public static bool inv_member { get; set; } 
        public static float inv_member_head_fontsize { get; set; } 
        public static bool inv_member_head_bold { get; set; } 
        public static float inv_member_fontsize { get; set; } 
        public static bool inv_member_bold { get; set; }

        public static bool inv_bar { get; set; }
        public static float inv_bar_fontsize { get; set; }
        public static bool inv_bar_bold { get; set; }

        public static float inv_thank_fontsize { get; set; }
        public static bool inv_thank_bold { get; set; }

    }
}
