
using System.Data.SQLite;


namespace Ppos.Class
{
    internal class Class_Create_DB
    {
        public static void Create_DB(string date,string sr_mb)
        {
            try
            {
                


                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        // สร้าง connection
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Connection (
                                                   OPEN_DATE TEXT(25),
                                                   Code TEXT
                                                   )";
                         cmd_sqlite.ExecuteNonQuery();

                        cmd_sqlite.CommandText = @"INSERT INTO Connection(OPEN_DATE,Code) "+
                                                 "SELECT '" + date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2) + "','"+ sr_mb + "' " +
                                                 "WHERE NOT EXISTS(SELECT 1 from Connection)";

                        cmd_sqlite.ExecuteNonQuery();

                        // สร้าง User
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS User (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    user TEXT,
                                    password TEXT,
                                    save_user BOOLEAN,
                                    save_pass BOOLEAN,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item_group
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_Group (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    group_main TEXT,
                                    group_sub TEXT,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // insert item_group  ตั้งต้น
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Group(created_by, created_date, updated_by, updated_date, group_main, group_sub, status) " +
                                                  "select '',datetime('now', 'localtime'), '', '', '" + Class_Parameter.Group_Main +"', '"+Class_Parameter.Group_Sub+"', 1 "+
                                                  "WHERE NOT EXISTS(SELECT 1 from Item_Group where group_main = '"+Class_Parameter.Group_Main+"' and group_sub = '"+Class_Parameter.Group_Sub+"')";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item (   
                                    created_by TEXT(255),
                                    created_date DATETIME,
                                    updated_by TEXT(255),
                                    updated_date DATETIME,
                                    code INTEGER,                                   
                                    group_main TEXT,
                                    group_sub TEXT,                                                                       
                                    name TEXT,                                                                                                                                             
                                    small_barcode TEXT(255),
                                    small_unit TEXT(255), 
                                    small_price DOUBLE,
                                    small_cost_last DOUBLE,
                                    small_cost_avg DOUBLE,
                                    small_qty DOUBLE,                                   
                                    medium_barcode TEXT(255),
                                    medium_unit TEXT(255), 
                                    medium_price DOUBLE,
                                    medium_cost_last DOUBLE,
                                    medium_cost_avg DOUBLE,
                                    medium_qty DOUBLE,
                                    medium_qty_small DOUBLE,
                                    large_barcode TEXT(255),
                                    large_unit TEXT(255), 
                                    large_price DOUBLE,
                                    large_cost_last DOUBLE,
                                    large_cost_avg DOUBLE,
                                    large_qty DOUBLE,
                                    large_qty_small DOUBLE,                                                                  
                                    sale_vat BOOLEAN,
                                    sale_negative BOOLEAN,
                                    item_weight BOOLEAN,
                                    effective_promotion BOOLEAN,
                                    effective_member BOOLEAN,
                                    effective_hotkey BOOLEAN,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item_hotkey
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_Hotkey(   
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,  
                                    pag INTEGER,
                                    item_code INTEGER,
                                    small_barcode TEXT(255),
                                    barcode TEXT(255),
                                    column INTEGER ,
                                    row INTEGER 
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item_hotkey_set
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_Hotkey_Set(   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    title TEXT,
                                    value TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();

                        // ColumnCount
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'column_count', '4' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'column_count') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // RowHeight
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'row_height', '150' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'row_height') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // FontSize
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'font_size', '12' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'font_size') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // ImageType
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'image_type', 'บน' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'image_type') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // ButtonColor
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'button_color', 'White' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'button_color') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // FontColor
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'font_color', 'Black' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'font_color') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // title_1
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_title_1', 'คีย์ลัด1' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_title_1') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // title_2
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_title_2', 'คีย์ลัด2' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_title_2') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // title_3
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_title_3', 'คีย์ลัด3' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_title_3') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // hotkey_hot_sale_back_date
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_hot_sale_back_date', '7' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_hot_sale_back_date') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // hotkey_hot_sale_limit
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_hot_sale_limit', '20' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_hot_sale_limit') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // hotkey_last_sale_back_date
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_last_sale_back_date', '7' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_last_sale_back_date') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // hotkey_last_sale_limit
                        cmd_sqlite.CommandText = @"INSERT INTO Item_Hotkey_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'hotkey_last_sale_limit', '20' 
                                                   WHERE NOT EXISTS(SELECT 1 from Item_Hotkey_Set WHERE title = 'hotkey_last_sale_limit') ";
                        cmd_sqlite.ExecuteNonQuery();

                        // สร้าง sale_display_set
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Sale_Display_Set(   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    title TEXT,
                                    value TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // sale_left_width
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'sale_left_width', '50' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'sale_left_width') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // sale_hotkey_left
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'sale_hotkey_left', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'sale_hotkey_left') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // visible_sum_qty
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'visible_sum_qty', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'visible_sum_qty') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // visible_sum_price
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'visible_sum_price', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'visible_sum_price') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // visible_dis_pro
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'visible_dis_pro', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'visible_dis_pro') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // visible_dis_member
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'visible_dis_member', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'visible_dis_member') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // visible_dis_round
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'visible_dis_round', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'visible_dis_round') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // keypad_numeric
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'keypad_numeric', 'True' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'keypad_numeric') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // pay_left_width
                        cmd_sqlite.CommandText = @"INSERT INTO Sale_Display_Set(created_by, created_date, updated_by, updated_date, title, value) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'pay_left_width', '50' 
                                                   WHERE NOT EXISTS(SELECT 1 from Sale_Display_Set WHERE title = 'pay_left_width') ";
                        cmd_sqlite.ExecuteNonQuery();

                        // สร้าง item_temp_excel
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_Temp_Excel (    
                                    id INTEGER PRIMARY KEY,
                                    group_main TEXT,
                                    group_sub TEXT,                                                                                                                                                                                                                                                       
                                    small_barcode TEXT(255),
                                    name TEXT,
                                    small_unit TEXT(255), 
                                    small_price TEXT,
                                    small_cost_last TEXT,
                                    small_qty TEXT,
                                    status TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item_temp_excel_qty
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_Temp_Excel_Qty (    
                                    id INTEGER PRIMARY KEY,
                                    group_main TEXT,
                                    group_sub TEXT,                                                                                                                                                                                                                                                       
                                    barcode TEXT(255),
                                    name TEXT,
                                    qty TEXT(255),
                                    unit TEXT(255), 
                                    inc TEXT,
                                    dec TEXT,
                                    cus TEXT,
                                    cost TEXT,
                                    status TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง item history
                       /* cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Item_History (   
                                    created_by TEXT(255),
                                    created_date DATETIME,
                                    history_type TEXT,
                                    code INTEGER,                                   
                                    group_main TEXT,
                                    group_sub TEXT,                                                                       
                                    name TEXT,                                                                                                                                             
                                    small_barcode TEXT(255),
                                    small_unit TEXT(255), 
                                    small_price DOUBLE,
                                    small_cost_last DOUBLE,
                                    small_cost_avg DOUBLE,
                                    small_qty DOUBLE,                                   
                                    medium_barcode TEXT(255),
                                    medium_unit TEXT(255), 
                                    medium_price DOUBLE,
                                    medium_cost_last DOUBLE,
                                    medium_cost_avg DOUBLE,
                                    medium_qty DOUBLE,
                                    medium_qty_small DOUBLE,
                                    large_barcode TEXT(255),
                                    large_unit TEXT(255), 
                                    large_price DOUBLE,
                                    large_cost_last DOUBLE,
                                    large_cost_avg DOUBLE,
                                    large_qty DOUBLE,
                                    large_qty_small DOUBLE,                                                                  
                                    sale_vat BOOLEAN,
                                    sale_negative BOOLEAN,
                                    item_weight BOOLEAN,
                                    effective_promotion BOOLEAN,
                                    effective_member BOOLEAN,
                                    effective_hotkey BOOLEAN,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();*/

                        // สร้าง promotion
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Promotion (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    pro_id INTEGER,
                                    pro_type TEXT,
                                    pro_desc TEXT,
                                    criterion_type TEXT,
                                    criterion_value DOUBLE,
                                    offer_type TEXT,
                                    offer_value DOUBLE,
                                    discount_type TEXT,
                                    repeat TEXT,
                                    start_datetime DATETIME,
                                    end_datetime DATETIME,
                                    mon BOOLEAN,
                                    tue BOOLEAN,
                                    wed BOOLEAN,
                                    thu BOOLEAN,
                                    fri BOOLEAN,
                                    sat BOOLEAN,
                                    sun BOOLEAN,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        
                        // สร้าง Promotion_Items
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Promotion_Items (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    pro_id INTEGER,
                                    pro_type TEXT,
                                    item_code INTEGER,
                                    item_name TEXT,
                                    item_price DOUBLE,
                                    item_set_qty INTEGER,
                                    barcode_small TEXT,
                                    barcode_medium TEXT,
                                    barcode_large TEXT,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง Promotion_Items_Premium
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Promotion_Items_Premium (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    pro_id INTEGER,
                                    pro_type TEXT,
                                    item_code INTEGER,
                                    item_name TEXT,
                                    item_price DOUBLE,
                                    barcode_small TEXT,
                                    barcode_medium TEXT,
                                    barcode_large TEXT,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง Member
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Member ( 
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,                                   
                                    phone TEXT(25),                                  
                                    sex TEXT(25),
                                    nick_name TEXT,
                                    first_name TEXT,
                                    last_name TEXT,
                                    address TEXT,
                                    sub_district TEXT,
                                    district TEXT,
                                    province TEXT,
                                    postal_code TEXT,
                                    discount_percent DOUBLE,
                                    sale_total DOUBLE,
                                    sale_ineffective_member DOUBLE,
                                    sale_effective_member DOUBLE,   
                                    sale_per_point DOUBLE,
                                    point_increase DOUBLE,
                                    point_decrease DOUBLE,
                                    point_balance DOUBLE,                                  
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง Member_Point_Balance
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Member_Point_Balance ( 
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,   
                                    id_member INTEGER,
                                    trans_type TEXT,
                                    trans_desc TEXT,
                                    sale_per_point DOUBLE,
                                    point_begin DOUBLE,
                                    point_increase DOUBLE,
                                    point_decrease DOUBLE,
                                    point_end DOUBLE
                                    )";
                        cmd_sqlite.ExecuteNonQuery();


                        // สร้าง Transactio
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Transactions (  
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    trans_type TEXT,
                                    trans_desc TEXT,
                                    item_code INTEGER,
                                    item_barcode TEXT,
                                    item_qty_begin DOUBLE, 
                                    item_qty DOUBLE,  
                                    item_qty_end DOUBLE, 
                                    item_cost_begin DOUBLE,
                                    item_cost DOUBLE,
                                    item_cost_end DOUBLE,
                                    item_qty_small DOUBLE,                         
                                    small_barcode TEXT,
                                    small_qty_begin DOUBLE,
                                    small_qty DOUBLE, 
                                    small_qty_end DOUBLE,
                                    small_cost_begin DOUBLE,
                                    small_cost DOUBLE,
                                    small_cost_end DOUBLE
                                    )";
                        cmd_sqlite.ExecuteNonQuery();


                        // สร้าง Setting_Camera
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Setting_Camera (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    device_name TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Camera(created_by, created_date, updated_by, updated_date, device_name) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', '' 
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Camera) ";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง Setting_Configure
                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Setting_Configure(   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    title TEXT,
                                    status BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Configure(created_by, created_date, updated_by, updated_date, title, status) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'login_program', 1 
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Configure WHERE title = 'login_program') ";
                        cmd_sqlite.ExecuteNonQuery();

                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Configure(created_by, created_date, updated_by, updated_date, title, status) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'use_item_medium_large', 1  
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Configure WHERE title = 'use_item_medium_large') ";
                        cmd_sqlite.ExecuteNonQuery();
                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Configure(created_by, created_date, updated_by, updated_date, title, status) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'custom_cost_adjust', 1 
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Configure WHERE title = 'custom_cost_adjust') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // show hotkey
                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Configure(created_by, created_date, updated_by, updated_date, title, status) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'sale_show_hotkey', 1 
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Configure WHERE title = 'sale_show_hotkey') ";
                        cmd_sqlite.ExecuteNonQuery();
                        // show keypad
                        cmd_sqlite.CommandText = @"INSERT INTO Setting_Configure(created_by, created_date, updated_by, updated_date, title, status) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', 'pay_show_keypad', 1 
                                                   WHERE NOT EXISTS(SELECT 1 from Setting_Configure WHERE title = 'pay_show_keypad') ";
                        cmd_sqlite.ExecuteNonQuery();

                        // สร้าง store

                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Store (   
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME,
                                    store_no TEXT(25),                                  
                                    store_name TEXT,
                                    tax_id TEXT,
                                    address TEXT,
                                    sub_district TEXT,
                                    district TEXT,
                                    province TEXT,
                                    postal_code TEXT,
                                    phone TEXT,
                                    email TEXT
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        cmd_sqlite.CommandText = @"INSERT INTO Store(created_by, created_date, updated_by, updated_date, 
                                                   store_no,store_name,tax_id,address,sub_district,
                                                   district,province,postal_code,phone,email) 
                                                   SELECT '',datetime('now', 'localtime'), '', '', '1234' ,'Ppos','','','','','','','',''
                                                   WHERE NOT EXISTS(SELECT 1 from Store) ";
                        cmd_sqlite.ExecuteNonQuery();

                        // สร้าง Invoice_Head

                          cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Invoice_Head ( 
                                      id INTEGER PRIMARY KEY,
                                      created_by TEXT(25),
                                      created_date DATETIME,
                                      updated_by TEXT(25),
                                      updated_date DATETIME,
                                      status TEXT(25),
                                      trx_no TEXT(25),                                       
                                      item_qty DOUBLE,
                                      price_sum DOUBLE,
                                      id_member TEXT(25),
                                      percent_discount_member DOUBLE,
                                      point_increase INTEGER,
                                      discount_promotion DOUBLE,
                                      discount_member DOUBLE,
                                      discount_custom DOUBLE,                                      
                                      discount_point DOUBLE,
                                      discount_round DOUBLE, 
                                      price_net DOUBLE,                                   
                                      pay_cash DOUBLE,
                                      pay_transfer DOUBLE,
                                      change DOUBLE,
                                      price_non_vat DOUBLE,
                                      price_vat DOUBLE,
                                      vat DOUBLE,
                                      void_date DATETIME,
                                      return_date DATETIME,
                                      trx_no_reference TEXT(25)                                    
                                      )";
                          cmd_sqlite.ExecuteNonQuery();

                        // สร้าง Invoice_Body

                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Invoice_Body (  
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME, 
                                    trx_no TEXT(25),
                                    void BOOLEAN,
                                    return BOOLEAN,
                                    small_barcode TEXT,
                                    item_barcode TEXT,
                                    item_code INTEGER,
                                    item_name TEXT,
                                    item_qty DOUBLE,
                                    item_unit TEXT(25),
                                    item_price DOUBLE,
                                    item_price_sum DOUBLE,
                                    item_cost_avg DOUBLE,
                                    small_qty DOUBLE, 
                                    qty_small INTEGER,
                                    pro_id INTEGER,
                                    pro_type TEXT,
                                    pro_desc TEXT,
                                    criterion_type TEXT,
                                    criterion_value DOUBLE,
                                    offer_type TEXT,
                                    offer_value DOUBLE,
                                    discount_type TEXT,
                                    repeat TEXT,
                                    discount_promotion DOUBLE,
                                    id_member TEXT(25),
                                    percent_discount_member DOUBLE,
                                    discount_member DOUBLE,
                                    discount_custom DOUBLE,                                  
                                    discount_point DOUBLE,
                                    discount_round DOUBLE,
                                    price_net DOUBLE,
                                    price_non_vat DOUBLE,
                                    price_vat DOUBLE,
                                    vat DOUBLE,
                                    sale_vat BOOLEAN,
                                    premium BOOLEAN,
                                    effective_member BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();
                        // สร้าง Invoice_Body_Temp

                        cmd_sqlite.CommandText = @"CREATE TABLE IF NOT EXISTS Invoice_Body_Temp (  
                                    id INTEGER PRIMARY KEY,
                                    created_by TEXT(25),
                                    created_date DATETIME,
                                    updated_by TEXT(25),
                                    updated_date DATETIME, 
                                    void BOOLEAN,
                                    return BOOLEAN,
                                    small_barcode TEXT,
                                    item_barcode TEXT,
                                    item_code INTEGER,
                                    item_name TEXT,
                                    item_qty DOUBLE,
                                    item_unit TEXT(25),
                                    item_price DOUBLE,
                                    item_price_sum DOUBLE,
                                    item_cost_avg DOUBLE,
                                    small_qty DOUBLE, 
                                    qty_small INTEGER,
                                    pro_id INTEGER,
                                    pro_type TEXT,
                                    pro_desc TEXT,
                                    criterion_type TEXT,
                                    criterion_value DOUBLE,
                                    offer_type TEXT,
                                    offer_value DOUBLE,
                                    discount_type TEXT,
                                    repeat TEXT,
                                    discount_promotion DOUBLE,
                                    id_member TEXT(25),
                                    percent_discount_member DOUBLE,
                                    discount_member DOUBLE,
                                    discount_custom DOUBLE,                                  
                                    discount_point DOUBLE,
                                    discount_round DOUBLE,
                                    price_net DOUBLE,
                                    price_non_vat DOUBLE,
                                    price_vat DOUBLE,
                                    vat DOUBLE,
                                    sale_vat BOOLEAN,
                                    premium BOOLEAN,
                                    effective_member BOOLEAN,
                                    hole BOOLEAN
                                    )";
                        cmd_sqlite.ExecuteNonQuery();

                      
                    }
                    con_sqlite.Close();
                }
            }
            catch { }
           
        }
    }
}
