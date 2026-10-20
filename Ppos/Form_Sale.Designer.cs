namespace Ppos
{
    partial class Form_Sale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Sale));
            backgroundWorker_hotkey = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_hotkey_pag = new TableLayoutPanel();
            button_hotkey_1 = new Button();
            button_hot_sale = new Button();
            button_last_sale = new Button();
            button_hotkey_2 = new Button();
            button_hotkey_3 = new Button();
            dataGridView_item = new DataGridView();
            id_temp = new DataGridViewTextBoxColumn();
            item_code = new DataGridViewTextBoxColumn();
            small_barcode = new DataGridViewTextBoxColumn();
            barcode = new DataGridViewTextBoxColumn();
            delete = new DataGridViewImageColumn();
            item_name = new DataGridViewTextBoxColumn();
            edit = new DataGridViewImageColumn();
            item_qty = new DataGridViewTextBoxColumn();
            item_unit = new DataGridViewTextBoxColumn();
            item_price = new DataGridViewTextBoxColumn();
            item_price_total = new DataGridViewTextBoxColumn();
            pro = new DataGridViewImageColumn();
            pro_id = new DataGridViewTextBoxColumn();
            pro_type = new DataGridViewTextBoxColumn();
            pro_desc = new DataGridViewTextBoxColumn();
            criterion_type = new DataGridViewTextBoxColumn();
            criterion_value = new DataGridViewTextBoxColumn();
            offer_type = new DataGridViewTextBoxColumn();
            offer_value = new DataGridViewTextBoxColumn();
            discount_type = new DataGridViewTextBoxColumn();
            repeat = new DataGridViewTextBoxColumn();
            premium = new DataGridViewTextBoxColumn();
            effective_member = new DataGridViewTextBoxColumn();
            sale_vat = new DataGridViewTextBoxColumn();
            button_pay = new Button();
            tableLayoutPanel_menu = new TableLayoutPanel();
            tableLayoutPanel_search = new TableLayoutPanel();
            button_sale = new Button();
            panel_search = new Panel();
            textBox_search = new TextBox();
            button_member = new Button();
            button_sale_display = new Button();
            button_hole_bill = new Button();
            button_other = new Button();
            customGroupBox_menu = new CustomGroupBox();
            customGroupBox_bill = new CustomGroupBox();
            tableLayoutPanel_bill = new TableLayoutPanel();
            customGroupBox_button_pay = new CustomGroupBox();
            panel_bill = new Panel();
            panel_bottom_bill = new Panel();
            tableLayoutPanel_sum_qty = new TableLayoutPanel();
            label_sum_qty_title = new Label();
            label_sum_qty = new Label();
            button_delete_all = new Button();
            tableLayoutPanel_sum_price = new TableLayoutPanel();
            label_sum_price_title = new Label();
            label_sum_price = new Label();
            tableLayoutPanel_discount_pro = new TableLayoutPanel();
            label_dis_pro_title = new Label();
            label_dis_pro = new Label();
            tableLayoutPanel_discount_member = new TableLayoutPanel();
            label_dis_member_title = new Label();
            label_dis_member = new Label();
            tableLayoutPanel_discount_round = new TableLayoutPanel();
            label_dis_round = new Label();
            label_dis_round_title = new Label();
            tableLayoutPanel_sum_net = new TableLayoutPanel();
            label_price_net = new Label();
            label_price_title = new Label();
            customGroupBox_member = new CustomGroupBox();
            tableLayoutPanel_member = new TableLayoutPanel();
            textBox_member = new TextBox();
            pictureBox_delete_member = new PictureBox();
            customGroupBox_hotkey = new CustomGroupBox();
            panel_hotkey = new Panel();
            customGroupBox_hotkey_pag = new CustomGroupBox();
            timer_load = new System.Windows.Forms.Timer(components);
            backgroundWorker_bill_hole = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_load = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_left = new TableLayoutPanel();
            tableLayoutPanel_right = new TableLayoutPanel();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_hotkey_pag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            tableLayoutPanel_menu.SuspendLayout();
            tableLayoutPanel_search.SuspendLayout();
            panel_search.SuspendLayout();
            customGroupBox_menu.SuspendLayout();
            customGroupBox_bill.SuspendLayout();
            tableLayoutPanel_bill.SuspendLayout();
            customGroupBox_button_pay.SuspendLayout();
            panel_bill.SuspendLayout();
            tableLayoutPanel_sum_qty.SuspendLayout();
            tableLayoutPanel_sum_price.SuspendLayout();
            tableLayoutPanel_discount_pro.SuspendLayout();
            tableLayoutPanel_discount_member.SuspendLayout();
            tableLayoutPanel_discount_round.SuspendLayout();
            tableLayoutPanel_sum_net.SuspendLayout();
            customGroupBox_member.SuspendLayout();
            tableLayoutPanel_member.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete_member).BeginInit();
            customGroupBox_hotkey.SuspendLayout();
            customGroupBox_hotkey_pag.SuspendLayout();
            tableLayoutPanel_left.SuspendLayout();
            tableLayoutPanel_right.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker_hotkey
            // 
            backgroundWorker_hotkey.DoWork += backgroundWorker_hotkey_DoWork;
            backgroundWorker_hotkey.RunWorkerCompleted += backgroundWorker_hotkey_RunWorkerCompleted;
            // 
            // tableLayoutPanel_hotkey_pag
            // 
            tableLayoutPanel_hotkey_pag.BackColor = Color.White;
            tableLayoutPanel_hotkey_pag.ColumnCount = 5;
            tableLayoutPanel_hotkey_pag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_hotkey_pag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_hotkey_pag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_hotkey_pag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_hotkey_pag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_hotkey_pag.Controls.Add(button_hotkey_1, 0, 0);
            tableLayoutPanel_hotkey_pag.Controls.Add(button_hot_sale, 4, 0);
            tableLayoutPanel_hotkey_pag.Controls.Add(button_last_sale, 3, 0);
            tableLayoutPanel_hotkey_pag.Controls.Add(button_hotkey_2, 1, 0);
            tableLayoutPanel_hotkey_pag.Controls.Add(button_hotkey_3, 2, 0);
            tableLayoutPanel_hotkey_pag.Dock = DockStyle.Fill;
            tableLayoutPanel_hotkey_pag.Location = new Point(10, 13);
            tableLayoutPanel_hotkey_pag.Margin = new Padding(0, 0, 10, 5);
            tableLayoutPanel_hotkey_pag.Name = "tableLayoutPanel_hotkey_pag";
            tableLayoutPanel_hotkey_pag.RowCount = 1;
            tableLayoutPanel_hotkey_pag.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_hotkey_pag.Size = new Size(610, 87);
            tableLayoutPanel_hotkey_pag.TabIndex = 1;
            // 
            // button_hotkey_1
            // 
            button_hotkey_1.BackColor = Color.Transparent;
            button_hotkey_1.Dock = DockStyle.Fill;
            button_hotkey_1.FlatAppearance.BorderSize = 0;
            button_hotkey_1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_1.FlatStyle = FlatStyle.Flat;
            button_hotkey_1.Font = new Font("Segoe UI", 12F);
            button_hotkey_1.ForeColor = Color.Gray;
            button_hotkey_1.Location = new Point(0, 0);
            button_hotkey_1.Margin = new Padding(0);
            button_hotkey_1.Name = "button_hotkey_1";
            button_hotkey_1.Size = new Size(122, 87);
            button_hotkey_1.TabIndex = 0;
            button_hotkey_1.TabStop = false;
            button_hotkey_1.Text = "-";
            button_hotkey_1.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_1.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_1.UseVisualStyleBackColor = false;
            button_hotkey_1.Visible = false;
            button_hotkey_1.Click += hotkey_click;
            button_hotkey_1.MouseEnter += hotkey_enter;
            button_hotkey_1.MouseLeave += hotkey_leave;
            // 
            // button_hot_sale
            // 
            button_hot_sale.BackColor = Color.Transparent;
            button_hot_sale.Dock = DockStyle.Fill;
            button_hot_sale.FlatAppearance.BorderSize = 0;
            button_hot_sale.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hot_sale.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hot_sale.FlatStyle = FlatStyle.Flat;
            button_hot_sale.Font = new Font("Segoe UI", 12F);
            button_hot_sale.ForeColor = Color.Gray;
            button_hot_sale.Location = new Point(488, 0);
            button_hot_sale.Margin = new Padding(0);
            button_hot_sale.Name = "button_hot_sale";
            button_hot_sale.Size = new Size(122, 87);
            button_hot_sale.TabIndex = 2;
            button_hot_sale.TabStop = false;
            button_hot_sale.Text = "ขายดี";
            button_hot_sale.TextAlign = ContentAlignment.BottomCenter;
            button_hot_sale.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hot_sale.UseVisualStyleBackColor = false;
            button_hot_sale.Visible = false;
            button_hot_sale.Click += hotkey_click;
            button_hot_sale.MouseEnter += hotkey_enter;
            button_hot_sale.MouseLeave += hotkey_leave;
            // 
            // button_last_sale
            // 
            button_last_sale.BackColor = Color.Transparent;
            button_last_sale.Dock = DockStyle.Fill;
            button_last_sale.FlatAppearance.BorderSize = 0;
            button_last_sale.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_last_sale.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_last_sale.FlatStyle = FlatStyle.Flat;
            button_last_sale.Font = new Font("Segoe UI", 12F);
            button_last_sale.ForeColor = Color.Gray;
            button_last_sale.Location = new Point(366, 0);
            button_last_sale.Margin = new Padding(0);
            button_last_sale.Name = "button_last_sale";
            button_last_sale.Size = new Size(122, 87);
            button_last_sale.TabIndex = 1;
            button_last_sale.TabStop = false;
            button_last_sale.Text = "ล่าสุด";
            button_last_sale.TextAlign = ContentAlignment.BottomCenter;
            button_last_sale.TextImageRelation = TextImageRelation.ImageAboveText;
            button_last_sale.UseVisualStyleBackColor = false;
            button_last_sale.Visible = false;
            button_last_sale.Click += hotkey_click;
            button_last_sale.MouseEnter += hotkey_enter;
            button_last_sale.MouseLeave += hotkey_leave;
            // 
            // button_hotkey_2
            // 
            button_hotkey_2.BackColor = Color.Transparent;
            button_hotkey_2.Dock = DockStyle.Fill;
            button_hotkey_2.FlatAppearance.BorderSize = 0;
            button_hotkey_2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_2.FlatStyle = FlatStyle.Flat;
            button_hotkey_2.Font = new Font("Segoe UI", 12F);
            button_hotkey_2.ForeColor = Color.Gray;
            button_hotkey_2.Location = new Point(122, 0);
            button_hotkey_2.Margin = new Padding(0);
            button_hotkey_2.Name = "button_hotkey_2";
            button_hotkey_2.Size = new Size(122, 87);
            button_hotkey_2.TabIndex = 0;
            button_hotkey_2.TabStop = false;
            button_hotkey_2.Text = "-";
            button_hotkey_2.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_2.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_2.UseVisualStyleBackColor = false;
            button_hotkey_2.Visible = false;
            button_hotkey_2.Click += hotkey_click;
            button_hotkey_2.MouseEnter += hotkey_enter;
            button_hotkey_2.MouseLeave += hotkey_leave;
            // 
            // button_hotkey_3
            // 
            button_hotkey_3.BackColor = Color.Transparent;
            button_hotkey_3.Dock = DockStyle.Fill;
            button_hotkey_3.FlatAppearance.BorderSize = 0;
            button_hotkey_3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_3.FlatStyle = FlatStyle.Flat;
            button_hotkey_3.Font = new Font("Segoe UI", 12F);
            button_hotkey_3.ForeColor = Color.Gray;
            button_hotkey_3.Location = new Point(244, 0);
            button_hotkey_3.Margin = new Padding(0);
            button_hotkey_3.Name = "button_hotkey_3";
            button_hotkey_3.Size = new Size(122, 87);
            button_hotkey_3.TabIndex = 0;
            button_hotkey_3.TabStop = false;
            button_hotkey_3.Text = "-";
            button_hotkey_3.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_3.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_3.UseVisualStyleBackColor = false;
            button_hotkey_3.Visible = false;
            button_hotkey_3.Click += hotkey_click;
            button_hotkey_3.MouseEnter += hotkey_enter;
            button_hotkey_3.MouseLeave += hotkey_leave;
            // 
            // dataGridView_item
            // 
            dataGridView_item.AllowUserToAddRows = false;
            dataGridView_item.AllowUserToDeleteRows = false;
            dataGridView_item.AllowUserToResizeColumns = false;
            dataGridView_item.AllowUserToResizeRows = false;
            dataGridView_item.BackgroundColor = Color.White;
            dataGridView_item.BorderStyle = BorderStyle.None;
            dataGridView_item.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_item.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 40;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { id_temp, item_code, small_barcode, barcode, delete, item_name, edit, item_qty, item_unit, item_price, item_price_total, pro, pro_id, pro_type, pro_desc, criterion_type, criterion_value, offer_type, offer_value, discount_type, repeat, premium, effective_member, sale_vat });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.Black;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.Enabled = false;
            dataGridView_item.GridColor = Color.Cyan;
            dataGridView_item.Location = new Point(0, 0);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.MultiSelect = false;
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView_item.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridView_item.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item.Size = new Size(611, 239);
            dataGridView_item.TabIndex = 2;
            dataGridView_item.TabStop = false;
            dataGridView_item.Visible = false;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
            dataGridView_item.CellMouseUp += dataGridView_item_CellMouseUp;
            dataGridView_item.RowPostPaint += dataGridView_item_RowPostPaint;
            // 
            // id_temp
            // 
            id_temp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            id_temp.HeaderText = "";
            id_temp.MinimumWidth = 6;
            id_temp.Name = "id_temp";
            id_temp.ReadOnly = true;
            id_temp.Visible = false;
            id_temp.Width = 125;
            // 
            // item_code
            // 
            item_code.HeaderText = "item_code";
            item_code.MinimumWidth = 6;
            item_code.Name = "item_code";
            item_code.ReadOnly = true;
            item_code.Visible = false;
            item_code.Width = 125;
            // 
            // small_barcode
            // 
            small_barcode.HeaderText = "small_barcode";
            small_barcode.MinimumWidth = 6;
            small_barcode.Name = "small_barcode";
            small_barcode.ReadOnly = true;
            small_barcode.Visible = false;
            small_barcode.Width = 125;
            // 
            // barcode
            // 
            barcode.HeaderText = "barcode";
            barcode.MinimumWidth = 6;
            barcode.Name = "barcode";
            barcode.ReadOnly = true;
            barcode.Visible = false;
            barcode.Width = 125;
            // 
            // delete
            // 
            delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            delete.HeaderText = "0";
            delete.MinimumWidth = 6;
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.Resizable = DataGridViewTriState.True;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Width = 60;
            // 
            // item_name
            // 
            item_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            item_name.HeaderText = "สินค้า";
            item_name.MinimumWidth = 6;
            item_name.Name = "item_name";
            item_name.ReadOnly = true;
            // 
            // edit
            // 
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            edit.HeaderText = "";
            edit.MinimumWidth = 6;
            edit.Name = "edit";
            edit.ReadOnly = true;
            edit.Resizable = DataGridViewTriState.True;
            edit.SortMode = DataGridViewColumnSortMode.Automatic;
            edit.Width = 60;
            // 
            // item_qty
            // 
            item_qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            item_qty.DefaultCellStyle = dataGridViewCellStyle2;
            item_qty.HeaderText = "จำนวน";
            item_qty.MinimumWidth = 6;
            item_qty.Name = "item_qty";
            item_qty.ReadOnly = true;
            item_qty.Width = 103;
            // 
            // item_unit
            // 
            item_unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            item_unit.DefaultCellStyle = dataGridViewCellStyle3;
            item_unit.HeaderText = "";
            item_unit.MinimumWidth = 6;
            item_unit.Name = "item_unit";
            item_unit.ReadOnly = true;
            item_unit.Width = 23;
            // 
            // item_price
            // 
            item_price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            item_price.DefaultCellStyle = dataGridViewCellStyle4;
            item_price.HeaderText = "ราคา";
            item_price.MinimumWidth = 6;
            item_price.Name = "item_price";
            item_price.ReadOnly = true;
            item_price.Width = 86;
            // 
            // item_price_total
            // 
            item_price_total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            item_price_total.DefaultCellStyle = dataGridViewCellStyle5;
            item_price_total.HeaderText = "รวม";
            item_price_total.MinimumWidth = 6;
            item_price_total.Name = "item_price_total";
            item_price_total.ReadOnly = true;
            item_price_total.Width = 75;
            // 
            // pro
            // 
            pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = Color.Red;
            dataGridViewCellStyle6.NullValue = resources.GetObject("dataGridViewCellStyle6.NullValue");
            dataGridViewCellStyle6.SelectionForeColor = Color.Red;
            pro.DefaultCellStyle = dataGridViewCellStyle6;
            pro.HeaderText = "";
            pro.MinimumWidth = 6;
            pro.Name = "pro";
            pro.ReadOnly = true;
            pro.Resizable = DataGridViewTriState.True;
            pro.Width = 50;
            // 
            // pro_id
            // 
            pro_id.HeaderText = "pro_id";
            pro_id.MinimumWidth = 6;
            pro_id.Name = "pro_id";
            pro_id.ReadOnly = true;
            pro_id.Visible = false;
            pro_id.Width = 125;
            // 
            // pro_type
            // 
            pro_type.HeaderText = "pro_type";
            pro_type.MinimumWidth = 6;
            pro_type.Name = "pro_type";
            pro_type.ReadOnly = true;
            pro_type.Visible = false;
            pro_type.Width = 125;
            // 
            // pro_desc
            // 
            pro_desc.HeaderText = "pro_desc";
            pro_desc.MinimumWidth = 6;
            pro_desc.Name = "pro_desc";
            pro_desc.ReadOnly = true;
            pro_desc.Visible = false;
            pro_desc.Width = 125;
            // 
            // criterion_type
            // 
            criterion_type.HeaderText = "criterion_type";
            criterion_type.MinimumWidth = 6;
            criterion_type.Name = "criterion_type";
            criterion_type.ReadOnly = true;
            criterion_type.Visible = false;
            criterion_type.Width = 125;
            // 
            // criterion_value
            // 
            criterion_value.HeaderText = "criterion_value";
            criterion_value.MinimumWidth = 6;
            criterion_value.Name = "criterion_value";
            criterion_value.ReadOnly = true;
            criterion_value.Visible = false;
            criterion_value.Width = 125;
            // 
            // offer_type
            // 
            offer_type.HeaderText = "offer_type";
            offer_type.MinimumWidth = 6;
            offer_type.Name = "offer_type";
            offer_type.ReadOnly = true;
            offer_type.Visible = false;
            offer_type.Width = 125;
            // 
            // offer_value
            // 
            offer_value.HeaderText = "offer_value";
            offer_value.MinimumWidth = 6;
            offer_value.Name = "offer_value";
            offer_value.ReadOnly = true;
            offer_value.Visible = false;
            offer_value.Width = 125;
            // 
            // discount_type
            // 
            discount_type.HeaderText = "discount_type";
            discount_type.MinimumWidth = 6;
            discount_type.Name = "discount_type";
            discount_type.ReadOnly = true;
            discount_type.Visible = false;
            discount_type.Width = 125;
            // 
            // repeat
            // 
            repeat.HeaderText = "repeat";
            repeat.MinimumWidth = 6;
            repeat.Name = "repeat";
            repeat.ReadOnly = true;
            repeat.Visible = false;
            repeat.Width = 125;
            // 
            // premium
            // 
            premium.HeaderText = "premium";
            premium.MinimumWidth = 6;
            premium.Name = "premium";
            premium.ReadOnly = true;
            premium.Visible = false;
            premium.Width = 125;
            // 
            // effective_member
            // 
            effective_member.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            effective_member.HeaderText = "effective_member";
            effective_member.MinimumWidth = 6;
            effective_member.Name = "effective_member";
            effective_member.ReadOnly = true;
            effective_member.Visible = false;
            effective_member.Width = 125;
            // 
            // sale_vat
            // 
            sale_vat.HeaderText = "sale_vat";
            sale_vat.MinimumWidth = 6;
            sale_vat.Name = "sale_vat";
            sale_vat.ReadOnly = true;
            sale_vat.Visible = false;
            sale_vat.Width = 125;
            // 
            // button_pay
            // 
            button_pay.BackColor = Color.Lime;
            button_pay.Dock = DockStyle.Fill;
            button_pay.FlatAppearance.BorderSize = 0;
            button_pay.FlatAppearance.MouseDownBackColor = Color.Lime;
            button_pay.FlatAppearance.MouseOverBackColor = Color.Lime;
            button_pay.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_pay.Location = new Point(10, 13);
            button_pay.Margin = new Padding(5, 0, 5, 5);
            button_pay.Name = "button_pay";
            button_pay.Size = new Size(585, 91);
            button_pay.TabIndex = 2;
            button_pay.TabStop = false;
            button_pay.Text = "ชำระเงิน";
            button_pay.TextAlign = ContentAlignment.MiddleRight;
            button_pay.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_pay.UseVisualStyleBackColor = false;
            button_pay.Click += button_pay_Click;
            button_pay.MouseEnter += pay_enter;
            button_pay.MouseLeave += pay_leave;
            // 
            // tableLayoutPanel_menu
            // 
            tableLayoutPanel_menu.BackColor = Color.White;
            tableLayoutPanel_menu.ColumnCount = 5;
            tableLayoutPanel_menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel_menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_menu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_menu.Controls.Add(tableLayoutPanel_search, 0, 0);
            tableLayoutPanel_menu.Controls.Add(button_member, 1, 0);
            tableLayoutPanel_menu.Controls.Add(button_sale_display, 4, 0);
            tableLayoutPanel_menu.Controls.Add(button_hole_bill, 2, 0);
            tableLayoutPanel_menu.Controls.Add(button_other, 3, 0);
            tableLayoutPanel_menu.Dock = DockStyle.Fill;
            tableLayoutPanel_menu.Location = new Point(10, 13);
            tableLayoutPanel_menu.Name = "tableLayoutPanel_menu";
            tableLayoutPanel_menu.RowCount = 1;
            tableLayoutPanel_menu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_menu.Size = new Size(611, 87);
            tableLayoutPanel_menu.TabIndex = 3;
            // 
            // tableLayoutPanel_search
            // 
            tableLayoutPanel_search.BackColor = Color.Transparent;
            tableLayoutPanel_search.ColumnCount = 1;
            tableLayoutPanel_search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_search.Controls.Add(button_sale, 0, 0);
            tableLayoutPanel_search.Controls.Add(panel_search, 0, 1);
            tableLayoutPanel_search.Dock = DockStyle.Fill;
            tableLayoutPanel_search.Location = new Point(0, 0);
            tableLayoutPanel_search.Margin = new Padding(0);
            tableLayoutPanel_search.Name = "tableLayoutPanel_search";
            tableLayoutPanel_search.RowCount = 2;
            tableLayoutPanel_search.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_search.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_search.Size = new Size(236, 87);
            tableLayoutPanel_search.TabIndex = 3;
            // 
            // button_sale
            // 
            button_sale.BackColor = Color.White;
            button_sale.Dock = DockStyle.Fill;
            button_sale.FlatAppearance.BorderSize = 0;
            button_sale.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_sale.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sale.Font = new Font("Segoe UI", 12F);
            button_sale.Location = new Point(0, 0);
            button_sale.Margin = new Padding(0);
            button_sale.Name = "button_sale";
            button_sale.Size = new Size(236, 43);
            button_sale.TabIndex = 1;
            button_sale.TabStop = false;
            button_sale.Text = "ค้นหาสินค้า";
            button_sale.TextAlign = ContentAlignment.MiddleRight;
            button_sale.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sale.UseVisualStyleBackColor = false;
            button_sale.Visible = false;
            button_sale.Click += button_sale_Click;
            button_sale.MouseEnter += hotkey_enter;
            button_sale.MouseLeave += hotkey_leave;
            // 
            // panel_search
            // 
            panel_search.BackColor = Color.White;
            panel_search.Controls.Add(textBox_search);
            panel_search.Dock = DockStyle.Fill;
            panel_search.Location = new Point(0, 46);
            panel_search.Margin = new Padding(0, 3, 0, 0);
            panel_search.Name = "panel_search";
            panel_search.Size = new Size(236, 41);
            panel_search.TabIndex = 4;
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.White;
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Bottom;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(0, -3);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(236, 44);
            textBox_search.TabIndex = 0;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.KeyDown += textBox_search_KeyDown;
            // 
            // button_member
            // 
            button_member.BackColor = Color.White;
            button_member.Dock = DockStyle.Fill;
            button_member.FlatAppearance.BorderSize = 0;
            button_member.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_member.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_member.Font = new Font("Segoe UI", 12F);
            button_member.Location = new Point(239, 0);
            button_member.Margin = new Padding(3, 0, 0, 0);
            button_member.Name = "button_member";
            button_member.Size = new Size(115, 87);
            button_member.TabIndex = 1;
            button_member.TabStop = false;
            button_member.Text = "สมาชิก";
            button_member.TextAlign = ContentAlignment.BottomCenter;
            button_member.TextImageRelation = TextImageRelation.ImageAboveText;
            button_member.UseVisualStyleBackColor = false;
            button_member.Visible = false;
            button_member.Click += button_member_Click;
            button_member.MouseEnter += hotkey_enter;
            button_member.MouseLeave += hotkey_leave;
            // 
            // button_sale_display
            // 
            button_sale_display.BackColor = Color.White;
            button_sale_display.Dock = DockStyle.Fill;
            button_sale_display.FlatAppearance.BorderSize = 0;
            button_sale_display.FlatAppearance.MouseDownBackColor = Color.White;
            button_sale_display.FlatAppearance.MouseOverBackColor = Color.White;
            button_sale_display.FlatStyle = FlatStyle.Flat;
            button_sale_display.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_sale_display.Location = new Point(590, 0);
            button_sale_display.Margin = new Padding(0);
            button_sale_display.Name = "button_sale_display";
            button_sale_display.Size = new Size(21, 87);
            button_sale_display.TabIndex = 4;
            button_sale_display.Text = "<";
            button_sale_display.UseVisualStyleBackColor = false;
            button_sale_display.Click += button_sale_display_Click;
            button_sale_display.MouseEnter += hotkey_enter;
            button_sale_display.MouseLeave += hotkey_leave;
            // 
            // button_hole_bill
            // 
            button_hole_bill.BackColor = Color.White;
            button_hole_bill.BackgroundImageLayout = ImageLayout.Zoom;
            button_hole_bill.Dock = DockStyle.Fill;
            button_hole_bill.FlatAppearance.BorderSize = 0;
            button_hole_bill.Font = new Font("Segoe UI", 12F);
            button_hole_bill.Location = new Point(357, 0);
            button_hole_bill.Margin = new Padding(3, 0, 0, 0);
            button_hole_bill.Name = "button_hole_bill";
            button_hole_bill.Size = new Size(115, 87);
            button_hole_bill.TabIndex = 2;
            button_hole_bill.TabStop = false;
            button_hole_bill.Text = "พักบิล";
            button_hole_bill.TextAlign = ContentAlignment.BottomCenter;
            button_hole_bill.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hole_bill.UseVisualStyleBackColor = false;
            button_hole_bill.Visible = false;
            button_hole_bill.Click += button_hole_bill_Click;
            button_hole_bill.MouseEnter += hotkey_enter;
            button_hole_bill.MouseLeave += hotkey_leave;
            // 
            // button_other
            // 
            button_other.BackColor = Color.White;
            button_other.Dock = DockStyle.Fill;
            button_other.FlatAppearance.BorderSize = 0;
            button_other.Font = new Font("Segoe UI", 12F);
            button_other.Location = new Point(475, 0);
            button_other.Margin = new Padding(3, 0, 0, 0);
            button_other.Name = "button_other";
            button_other.Size = new Size(115, 87);
            button_other.TabIndex = 1;
            button_other.TabStop = false;
            button_other.Text = "ข้อมูล";
            button_other.TextAlign = ContentAlignment.BottomCenter;
            button_other.TextImageRelation = TextImageRelation.ImageAboveText;
            button_other.UseVisualStyleBackColor = false;
            button_other.Visible = false;
            button_other.Click += button_other_Click;
            button_other.MouseEnter += hotkey_enter;
            button_other.MouseLeave += hotkey_leave;
            // 
            // customGroupBox_menu
            // 
            customGroupBox_menu.BorderColor = Color.White;
            customGroupBox_menu.BorderRadius = 30;
            customGroupBox_menu.BorderThickness = 20;
            customGroupBox_menu.Controls.Add(tableLayoutPanel_menu);
            customGroupBox_menu.Dock = DockStyle.Fill;
            customGroupBox_menu.Font = new Font("Segoe UI", 1F);
            customGroupBox_menu.Location = new Point(0, 0);
            customGroupBox_menu.Margin = new Padding(0, 0, 10, 10);
            customGroupBox_menu.Name = "customGroupBox_menu";
            customGroupBox_menu.Padding = new Padding(10);
            customGroupBox_menu.Size = new Size(631, 110);
            customGroupBox_menu.TabIndex = 11;
            customGroupBox_menu.TabStop = false;
            customGroupBox_menu.Text = " ";
            // 
            // customGroupBox_bill
            // 
            customGroupBox_bill.BackColor = Color.Transparent;
            customGroupBox_bill.BorderColor = Color.White;
            customGroupBox_bill.BorderRadius = 30;
            customGroupBox_bill.BorderThickness = 20;
            customGroupBox_bill.Controls.Add(tableLayoutPanel_bill);
            customGroupBox_bill.Dock = DockStyle.Fill;
            customGroupBox_bill.Font = new Font("Segoe UI", 1F);
            customGroupBox_bill.Location = new Point(0, 120);
            customGroupBox_bill.Margin = new Padding(0, 0, 10, 3);
            customGroupBox_bill.Name = "customGroupBox_bill";
            customGroupBox_bill.Padding = new Padding(10);
            customGroupBox_bill.Size = new Size(631, 682);
            customGroupBox_bill.TabIndex = 3;
            customGroupBox_bill.TabStop = false;
            customGroupBox_bill.Text = " ";
            // 
            // tableLayoutPanel_bill
            // 
            tableLayoutPanel_bill.BackColor = Color.White;
            tableLayoutPanel_bill.ColumnCount = 1;
            tableLayoutPanel_bill.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bill.Controls.Add(customGroupBox_button_pay, 0, 2);
            tableLayoutPanel_bill.Controls.Add(panel_bill, 0, 0);
            tableLayoutPanel_bill.Controls.Add(customGroupBox_member, 0, 1);
            tableLayoutPanel_bill.Dock = DockStyle.Fill;
            tableLayoutPanel_bill.Location = new Point(10, 13);
            tableLayoutPanel_bill.Margin = new Padding(0);
            tableLayoutPanel_bill.Name = "tableLayoutPanel_bill";
            tableLayoutPanel_bill.RowCount = 3;
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_bill.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_bill.Size = new Size(611, 659);
            tableLayoutPanel_bill.TabIndex = 0;
            // 
            // customGroupBox_button_pay
            // 
            customGroupBox_button_pay.BackColor = Color.White;
            customGroupBox_button_pay.BorderColor = Color.Lime;
            customGroupBox_button_pay.BorderRadius = 30;
            customGroupBox_button_pay.BorderThickness = 20;
            customGroupBox_button_pay.Controls.Add(button_pay);
            customGroupBox_button_pay.Dock = DockStyle.Fill;
            customGroupBox_button_pay.Font = new Font("Segoe UI", 1F);
            customGroupBox_button_pay.Location = new Point(3, 542);
            customGroupBox_button_pay.Name = "customGroupBox_button_pay";
            customGroupBox_button_pay.Padding = new Padding(10);
            customGroupBox_button_pay.Size = new Size(605, 114);
            customGroupBox_button_pay.TabIndex = 3;
            customGroupBox_button_pay.TabStop = false;
            customGroupBox_button_pay.Tag = " ";
            customGroupBox_button_pay.Text = " ";
            // 
            // panel_bill
            // 
            panel_bill.AutoScroll = true;
            panel_bill.AutoSize = true;
            panel_bill.BackColor = Color.White;
            panel_bill.Controls.Add(dataGridView_item);
            panel_bill.Controls.Add(panel_bottom_bill);
            panel_bill.Controls.Add(tableLayoutPanel_sum_qty);
            panel_bill.Controls.Add(tableLayoutPanel_sum_price);
            panel_bill.Controls.Add(tableLayoutPanel_discount_pro);
            panel_bill.Controls.Add(tableLayoutPanel_discount_member);
            panel_bill.Controls.Add(tableLayoutPanel_discount_round);
            panel_bill.Controls.Add(tableLayoutPanel_sum_net);
            panel_bill.Dock = DockStyle.Fill;
            panel_bill.Location = new Point(0, 0);
            panel_bill.Margin = new Padding(0);
            panel_bill.Name = "panel_bill";
            panel_bill.Size = new Size(611, 469);
            panel_bill.TabIndex = 0;
            // 
            // panel_bottom_bill
            // 
            panel_bottom_bill.BackColor = Color.Cyan;
            panel_bottom_bill.Dock = DockStyle.Bottom;
            panel_bottom_bill.Location = new Point(0, 239);
            panel_bottom_bill.Margin = new Padding(0);
            panel_bottom_bill.Name = "panel_bottom_bill";
            panel_bottom_bill.Size = new Size(611, 5);
            panel_bottom_bill.TabIndex = 1;
            panel_bottom_bill.MouseEnter += panel_bottom_bill_MouseEnter;
            panel_bottom_bill.MouseLeave += panel_bottom_bill_MouseLeave;
            // 
            // tableLayoutPanel_sum_qty
            // 
            tableLayoutPanel_sum_qty.AutoSize = true;
            tableLayoutPanel_sum_qty.ColumnCount = 4;
            tableLayoutPanel_sum_qty.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_qty.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_qty.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_sum_qty.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_qty.Controls.Add(label_sum_qty_title, 0, 0);
            tableLayoutPanel_sum_qty.Controls.Add(label_sum_qty, 1, 0);
            tableLayoutPanel_sum_qty.Controls.Add(button_delete_all, 3, 0);
            tableLayoutPanel_sum_qty.Dock = DockStyle.Bottom;
            tableLayoutPanel_sum_qty.Location = new Point(0, 244);
            tableLayoutPanel_sum_qty.Margin = new Padding(0);
            tableLayoutPanel_sum_qty.Name = "tableLayoutPanel_sum_qty";
            tableLayoutPanel_sum_qty.RowCount = 1;
            tableLayoutPanel_sum_qty.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_sum_qty.Size = new Size(611, 35);
            tableLayoutPanel_sum_qty.TabIndex = 2;
            tableLayoutPanel_sum_qty.Visible = false;
            // 
            // label_sum_qty_title
            // 
            label_sum_qty_title.Dock = DockStyle.Fill;
            label_sum_qty_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_qty_title.Location = new Point(0, 0);
            label_sum_qty_title.Margin = new Padding(0);
            label_sum_qty_title.Name = "label_sum_qty_title";
            label_sum_qty_title.Padding = new Padding(0, 0, 6, 0);
            label_sum_qty_title.Size = new Size(200, 35);
            label_sum_qty_title.TabIndex = 0;
            label_sum_qty_title.Text = "จำนวนรวม :";
            label_sum_qty_title.TextAlign = ContentAlignment.MiddleRight;
            label_sum_qty_title.DoubleClick += title_doubleclick;
            label_sum_qty_title.MouseEnter += sum_bill_enter;
            label_sum_qty_title.MouseLeave += sum_bill_leave;
            // 
            // label_sum_qty
            // 
            label_sum_qty.Dock = DockStyle.Fill;
            label_sum_qty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_qty.Location = new Point(200, 0);
            label_sum_qty.Margin = new Padding(0);
            label_sum_qty.Name = "label_sum_qty";
            label_sum_qty.Padding = new Padding(0, 0, 6, 0);
            label_sum_qty.Size = new Size(200, 35);
            label_sum_qty.TabIndex = 2;
            label_sum_qty.Text = "0.000";
            label_sum_qty.TextAlign = ContentAlignment.MiddleRight;
            label_sum_qty.MouseEnter += sum_bill_enter;
            label_sum_qty.MouseLeave += sum_bill_leave;
            // 
            // button_delete_all
            // 
            button_delete_all.BackColor = Color.Transparent;
            button_delete_all.BackgroundImageLayout = ImageLayout.Zoom;
            button_delete_all.Dock = DockStyle.Fill;
            button_delete_all.FlatAppearance.BorderSize = 0;
            button_delete_all.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_delete_all.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_delete_all.FlatStyle = FlatStyle.Flat;
            button_delete_all.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_delete_all.ForeColor = Color.Red;
            button_delete_all.Location = new Point(411, 0);
            button_delete_all.Margin = new Padding(0);
            button_delete_all.Name = "button_delete_all";
            button_delete_all.Size = new Size(200, 35);
            button_delete_all.TabIndex = 3;
            button_delete_all.Text = "ลบทั้งหมด";
            button_delete_all.TextAlign = ContentAlignment.MiddleRight;
            button_delete_all.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_delete_all.UseVisualStyleBackColor = false;
            button_delete_all.Click += button_delete_all_Click;
            button_delete_all.MouseEnter += hotkey_enter;
            button_delete_all.MouseLeave += hotkey_leave;
            // 
            // tableLayoutPanel_sum_price
            // 
            tableLayoutPanel_sum_price.AutoSize = true;
            tableLayoutPanel_sum_price.ColumnCount = 3;
            tableLayoutPanel_sum_price.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_price.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_price.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_sum_price.Controls.Add(label_sum_price_title, 0, 0);
            tableLayoutPanel_sum_price.Controls.Add(label_sum_price, 1, 0);
            tableLayoutPanel_sum_price.Dock = DockStyle.Bottom;
            tableLayoutPanel_sum_price.Location = new Point(0, 279);
            tableLayoutPanel_sum_price.Name = "tableLayoutPanel_sum_price";
            tableLayoutPanel_sum_price.RowCount = 1;
            tableLayoutPanel_sum_price.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_sum_price.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_sum_price.Size = new Size(611, 35);
            tableLayoutPanel_sum_price.TabIndex = 16;
            tableLayoutPanel_sum_price.Visible = false;
            // 
            // label_sum_price_title
            // 
            label_sum_price_title.Dock = DockStyle.Fill;
            label_sum_price_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_price_title.Location = new Point(0, 0);
            label_sum_price_title.Margin = new Padding(0);
            label_sum_price_title.Name = "label_sum_price_title";
            label_sum_price_title.Padding = new Padding(0, 0, 6, 0);
            label_sum_price_title.Size = new Size(200, 35);
            label_sum_price_title.TabIndex = 1;
            label_sum_price_title.Text = "ราคารวม :";
            label_sum_price_title.TextAlign = ContentAlignment.MiddleRight;
            label_sum_price_title.DoubleClick += title_doubleclick;
            label_sum_price_title.MouseEnter += sum_bill_enter;
            label_sum_price_title.MouseLeave += sum_bill_leave;
            // 
            // label_sum_price
            // 
            label_sum_price.Dock = DockStyle.Fill;
            label_sum_price.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_sum_price.Location = new Point(200, 0);
            label_sum_price.Margin = new Padding(0);
            label_sum_price.Name = "label_sum_price";
            label_sum_price.Padding = new Padding(0, 0, 6, 0);
            label_sum_price.Size = new Size(200, 35);
            label_sum_price.TabIndex = 2;
            label_sum_price.Text = "0.00";
            label_sum_price.TextAlign = ContentAlignment.MiddleRight;
            label_sum_price.MouseEnter += sum_bill_enter;
            label_sum_price.MouseLeave += sum_bill_leave;
            // 
            // tableLayoutPanel_discount_pro
            // 
            tableLayoutPanel_discount_pro.AutoSize = true;
            tableLayoutPanel_discount_pro.ColumnCount = 3;
            tableLayoutPanel_discount_pro.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_pro.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_pro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_discount_pro.Controls.Add(label_dis_pro_title, 0, 0);
            tableLayoutPanel_discount_pro.Controls.Add(label_dis_pro, 1, 0);
            tableLayoutPanel_discount_pro.Dock = DockStyle.Bottom;
            tableLayoutPanel_discount_pro.Location = new Point(0, 314);
            tableLayoutPanel_discount_pro.Margin = new Padding(0);
            tableLayoutPanel_discount_pro.Name = "tableLayoutPanel_discount_pro";
            tableLayoutPanel_discount_pro.RowCount = 1;
            tableLayoutPanel_discount_pro.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_discount_pro.Size = new Size(611, 35);
            tableLayoutPanel_discount_pro.TabIndex = 3;
            tableLayoutPanel_discount_pro.Visible = false;
            // 
            // label_dis_pro_title
            // 
            label_dis_pro_title.Dock = DockStyle.Fill;
            label_dis_pro_title.Font = new Font("Segoe UI", 12F);
            label_dis_pro_title.Location = new Point(0, 0);
            label_dis_pro_title.Margin = new Padding(0);
            label_dis_pro_title.Name = "label_dis_pro_title";
            label_dis_pro_title.Padding = new Padding(0, 0, 6, 0);
            label_dis_pro_title.Size = new Size(200, 35);
            label_dis_pro_title.TabIndex = 0;
            label_dis_pro_title.Text = "ส่วนลดโปรโมชั่น :";
            label_dis_pro_title.TextAlign = ContentAlignment.MiddleRight;
            label_dis_pro_title.DoubleClick += title_doubleclick;
            label_dis_pro_title.MouseEnter += sum_bill_enter;
            label_dis_pro_title.MouseLeave += sum_bill_leave;
            // 
            // label_dis_pro
            // 
            label_dis_pro.Dock = DockStyle.Fill;
            label_dis_pro.Font = new Font("Segoe UI", 12F);
            label_dis_pro.Location = new Point(200, 0);
            label_dis_pro.Margin = new Padding(0);
            label_dis_pro.Name = "label_dis_pro";
            label_dis_pro.Padding = new Padding(0, 0, 6, 0);
            label_dis_pro.Size = new Size(200, 35);
            label_dis_pro.TabIndex = 2;
            label_dis_pro.Text = "0.00";
            label_dis_pro.TextAlign = ContentAlignment.MiddleRight;
            label_dis_pro.MouseEnter += sum_bill_enter;
            label_dis_pro.MouseLeave += sum_bill_leave;
            // 
            // tableLayoutPanel_discount_member
            // 
            tableLayoutPanel_discount_member.AutoSize = true;
            tableLayoutPanel_discount_member.ColumnCount = 3;
            tableLayoutPanel_discount_member.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_member.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_member.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_discount_member.Controls.Add(label_dis_member_title, 0, 0);
            tableLayoutPanel_discount_member.Controls.Add(label_dis_member, 1, 0);
            tableLayoutPanel_discount_member.Dock = DockStyle.Bottom;
            tableLayoutPanel_discount_member.Location = new Point(0, 349);
            tableLayoutPanel_discount_member.Margin = new Padding(0);
            tableLayoutPanel_discount_member.Name = "tableLayoutPanel_discount_member";
            tableLayoutPanel_discount_member.RowCount = 1;
            tableLayoutPanel_discount_member.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_discount_member.Size = new Size(611, 35);
            tableLayoutPanel_discount_member.TabIndex = 4;
            tableLayoutPanel_discount_member.Visible = false;
            // 
            // label_dis_member_title
            // 
            label_dis_member_title.Dock = DockStyle.Fill;
            label_dis_member_title.Font = new Font("Segoe UI", 12F);
            label_dis_member_title.Location = new Point(0, 0);
            label_dis_member_title.Margin = new Padding(0);
            label_dis_member_title.Name = "label_dis_member_title";
            label_dis_member_title.Padding = new Padding(0, 0, 6, 0);
            label_dis_member_title.Size = new Size(200, 35);
            label_dis_member_title.TabIndex = 0;
            label_dis_member_title.Text = "ส่วนลดสมาชิก :";
            label_dis_member_title.TextAlign = ContentAlignment.MiddleRight;
            label_dis_member_title.DoubleClick += title_doubleclick;
            label_dis_member_title.MouseEnter += sum_bill_enter;
            label_dis_member_title.MouseLeave += sum_bill_leave;
            // 
            // label_dis_member
            // 
            label_dis_member.Dock = DockStyle.Fill;
            label_dis_member.Font = new Font("Segoe UI", 12F);
            label_dis_member.Location = new Point(200, 0);
            label_dis_member.Margin = new Padding(0);
            label_dis_member.Name = "label_dis_member";
            label_dis_member.Padding = new Padding(0, 0, 6, 0);
            label_dis_member.Size = new Size(200, 35);
            label_dis_member.TabIndex = 2;
            label_dis_member.Text = "0.00";
            label_dis_member.TextAlign = ContentAlignment.MiddleRight;
            label_dis_member.MouseEnter += sum_bill_enter;
            label_dis_member.MouseLeave += sum_bill_leave;
            // 
            // tableLayoutPanel_discount_round
            // 
            tableLayoutPanel_discount_round.AutoSize = true;
            tableLayoutPanel_discount_round.ColumnCount = 3;
            tableLayoutPanel_discount_round.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_round.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_discount_round.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_discount_round.Controls.Add(label_dis_round, 1, 0);
            tableLayoutPanel_discount_round.Controls.Add(label_dis_round_title, 0, 0);
            tableLayoutPanel_discount_round.Dock = DockStyle.Bottom;
            tableLayoutPanel_discount_round.Location = new Point(0, 384);
            tableLayoutPanel_discount_round.Name = "tableLayoutPanel_discount_round";
            tableLayoutPanel_discount_round.RowCount = 1;
            tableLayoutPanel_discount_round.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_discount_round.Size = new Size(611, 35);
            tableLayoutPanel_discount_round.TabIndex = 15;
            tableLayoutPanel_discount_round.Visible = false;
            // 
            // label_dis_round
            // 
            label_dis_round.Dock = DockStyle.Fill;
            label_dis_round.Font = new Font("Segoe UI", 12F);
            label_dis_round.Location = new Point(200, 0);
            label_dis_round.Margin = new Padding(0);
            label_dis_round.Name = "label_dis_round";
            label_dis_round.Padding = new Padding(0, 0, 6, 0);
            label_dis_round.Size = new Size(200, 35);
            label_dis_round.TabIndex = 2;
            label_dis_round.Text = "0.00";
            label_dis_round.TextAlign = ContentAlignment.MiddleRight;
            label_dis_round.MouseEnter += sum_bill_enter;
            label_dis_round.MouseLeave += sum_bill_leave;
            // 
            // label_dis_round_title
            // 
            label_dis_round_title.Dock = DockStyle.Fill;
            label_dis_round_title.Font = new Font("Segoe UI", 12F);
            label_dis_round_title.Location = new Point(0, 0);
            label_dis_round_title.Margin = new Padding(0);
            label_dis_round_title.Name = "label_dis_round_title";
            label_dis_round_title.Padding = new Padding(0, 0, 6, 0);
            label_dis_round_title.Size = new Size(200, 35);
            label_dis_round_title.TabIndex = 0;
            label_dis_round_title.Text = "ส่วนลดปัดเศษ :";
            label_dis_round_title.TextAlign = ContentAlignment.MiddleRight;
            label_dis_round_title.DoubleClick += title_doubleclick;
            label_dis_round_title.MouseEnter += sum_bill_enter;
            label_dis_round_title.MouseLeave += sum_bill_leave;
            // 
            // tableLayoutPanel_sum_net
            // 
            tableLayoutPanel_sum_net.AutoSize = true;
            tableLayoutPanel_sum_net.ColumnCount = 3;
            tableLayoutPanel_sum_net.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_net.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_sum_net.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_sum_net.Controls.Add(label_price_net, 1, 0);
            tableLayoutPanel_sum_net.Controls.Add(label_price_title, 0, 0);
            tableLayoutPanel_sum_net.Dock = DockStyle.Bottom;
            tableLayoutPanel_sum_net.Location = new Point(0, 419);
            tableLayoutPanel_sum_net.Margin = new Padding(0);
            tableLayoutPanel_sum_net.Name = "tableLayoutPanel_sum_net";
            tableLayoutPanel_sum_net.RowCount = 1;
            tableLayoutPanel_sum_net.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_sum_net.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_sum_net.Size = new Size(611, 50);
            tableLayoutPanel_sum_net.TabIndex = 5;
            tableLayoutPanel_sum_net.Visible = false;
            // 
            // label_price_net
            // 
            label_price_net.Dock = DockStyle.Fill;
            label_price_net.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_price_net.Location = new Point(200, 0);
            label_price_net.Margin = new Padding(0);
            label_price_net.Name = "label_price_net";
            label_price_net.Size = new Size(200, 50);
            label_price_net.TabIndex = 2;
            label_price_net.Text = "0.00";
            label_price_net.TextAlign = ContentAlignment.MiddleRight;
            label_price_net.MouseEnter += sum_bill_enter;
            label_price_net.MouseLeave += sum_bill_leave;
            // 
            // label_price_title
            // 
            label_price_title.Dock = DockStyle.Fill;
            label_price_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_price_title.Location = new Point(0, 0);
            label_price_title.Margin = new Padding(0);
            label_price_title.Name = "label_price_title";
            label_price_title.Size = new Size(200, 50);
            label_price_title.TabIndex = 1;
            label_price_title.Text = "ราคาสุทธิ :";
            label_price_title.TextAlign = ContentAlignment.MiddleRight;
            label_price_title.DoubleClick += label_price_title_DoubleClick;
            label_price_title.MouseEnter += sum_bill_enter;
            label_price_title.MouseLeave += sum_bill_leave;
            // 
            // customGroupBox_member
            // 
            customGroupBox_member.BorderColor = Color.FromArgb(192, 255, 192);
            customGroupBox_member.BorderRadius = 30;
            customGroupBox_member.BorderThickness = 20;
            customGroupBox_member.Controls.Add(tableLayoutPanel_member);
            customGroupBox_member.Dock = DockStyle.Fill;
            customGroupBox_member.Font = new Font("Segoe UI", 1F);
            customGroupBox_member.Location = new Point(3, 469);
            customGroupBox_member.Margin = new Padding(3, 0, 3, 0);
            customGroupBox_member.Name = "customGroupBox_member";
            customGroupBox_member.Padding = new Padding(10);
            customGroupBox_member.Size = new Size(605, 70);
            customGroupBox_member.TabIndex = 4;
            customGroupBox_member.TabStop = false;
            customGroupBox_member.Text = " ";
            // 
            // tableLayoutPanel_member
            // 
            tableLayoutPanel_member.BackColor = Color.FromArgb(192, 255, 192);
            tableLayoutPanel_member.ColumnCount = 2;
            tableLayoutPanel_member.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_member.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_member.Controls.Add(textBox_member, 1, 0);
            tableLayoutPanel_member.Controls.Add(pictureBox_delete_member, 0, 0);
            tableLayoutPanel_member.Dock = DockStyle.Fill;
            tableLayoutPanel_member.Location = new Point(10, 13);
            tableLayoutPanel_member.Margin = new Padding(0);
            tableLayoutPanel_member.Name = "tableLayoutPanel_member";
            tableLayoutPanel_member.RowCount = 1;
            tableLayoutPanel_member.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_member.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_member.Size = new Size(585, 47);
            tableLayoutPanel_member.TabIndex = 2;
            // 
            // textBox_member
            // 
            textBox_member.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_member.BackColor = Color.FromArgb(192, 255, 192);
            textBox_member.BorderStyle = BorderStyle.None;
            textBox_member.Enabled = false;
            textBox_member.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_member.Location = new Point(53, 5);
            textBox_member.Name = "textBox_member";
            textBox_member.Size = new Size(529, 36);
            textBox_member.TabIndex = 1;
            textBox_member.TabStop = false;
            // 
            // pictureBox_delete_member
            // 
            pictureBox_delete_member.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox_delete_member.Dock = DockStyle.Fill;
            pictureBox_delete_member.Image = Properties.Resources.uncheck;
            pictureBox_delete_member.Location = new Point(3, 3);
            pictureBox_delete_member.Name = "pictureBox_delete_member";
            pictureBox_delete_member.Size = new Size(44, 41);
            pictureBox_delete_member.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_delete_member.TabIndex = 2;
            pictureBox_delete_member.TabStop = false;
            pictureBox_delete_member.Visible = false;
            pictureBox_delete_member.Click += pictureBox_delete_member_Click;
            // 
            // customGroupBox_hotkey
            // 
            customGroupBox_hotkey.BackColor = Color.Transparent;
            customGroupBox_hotkey.BorderColor = Color.White;
            customGroupBox_hotkey.BorderRadius = 30;
            customGroupBox_hotkey.BorderThickness = 20;
            customGroupBox_hotkey.Controls.Add(panel_hotkey);
            customGroupBox_hotkey.Dock = DockStyle.Fill;
            customGroupBox_hotkey.Font = new Font("Segoe UI", 1F);
            customGroupBox_hotkey.Location = new Point(0, 120);
            customGroupBox_hotkey.Margin = new Padding(0, 0, 10, 3);
            customGroupBox_hotkey.Name = "customGroupBox_hotkey";
            customGroupBox_hotkey.Padding = new Padding(10);
            customGroupBox_hotkey.Size = new Size(630, 682);
            customGroupBox_hotkey.TabIndex = 4;
            customGroupBox_hotkey.TabStop = false;
            customGroupBox_hotkey.Text = " ";
            // 
            // panel_hotkey
            // 
            panel_hotkey.BackColor = Color.White;
            panel_hotkey.Dock = DockStyle.Fill;
            panel_hotkey.Location = new Point(10, 13);
            panel_hotkey.Margin = new Padding(0);
            panel_hotkey.Name = "panel_hotkey";
            panel_hotkey.Size = new Size(610, 659);
            panel_hotkey.TabIndex = 9;
            // 
            // customGroupBox_hotkey_pag
            // 
            customGroupBox_hotkey_pag.BorderColor = Color.White;
            customGroupBox_hotkey_pag.BorderRadius = 30;
            customGroupBox_hotkey_pag.BorderThickness = 20;
            customGroupBox_hotkey_pag.Controls.Add(tableLayoutPanel_hotkey_pag);
            customGroupBox_hotkey_pag.Dock = DockStyle.Fill;
            customGroupBox_hotkey_pag.Font = new Font("Segoe UI", 1F);
            customGroupBox_hotkey_pag.Location = new Point(0, 0);
            customGroupBox_hotkey_pag.Margin = new Padding(0, 0, 10, 10);
            customGroupBox_hotkey_pag.Name = "customGroupBox_hotkey_pag";
            customGroupBox_hotkey_pag.Padding = new Padding(10);
            customGroupBox_hotkey_pag.Size = new Size(630, 110);
            customGroupBox_hotkey_pag.TabIndex = 5;
            customGroupBox_hotkey_pag.TabStop = false;
            customGroupBox_hotkey_pag.Text = " ";
            // 
            // timer_load
            // 
            timer_load.Interval = 10;
            timer_load.Tick += timer_load_Tick;
            // 
            // backgroundWorker_bill_hole
            // 
            backgroundWorker_bill_hole.DoWork += backgroundWorker_bill_hole_DoWork;
            backgroundWorker_bill_hole.RunWorkerCompleted += backgroundWorker_bill_hole_RunWorkerCompleted;
            // 
            // backgroundWorker_load
            // 
            backgroundWorker_load.DoWork += backgroundWorker_load_DoWork;
            backgroundWorker_load.RunWorkerCompleted += backgroundWorker_load_RunWorkerCompleted;
            // 
            // tableLayoutPanel_left
            // 
            tableLayoutPanel_left.ColumnCount = 1;
            tableLayoutPanel_left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.Controls.Add(customGroupBox_hotkey, 0, 1);
            tableLayoutPanel_left.Controls.Add(customGroupBox_hotkey_pag, 0, 0);
            tableLayoutPanel_left.Dock = DockStyle.Fill;
            tableLayoutPanel_left.Location = new Point(0, 0);
            tableLayoutPanel_left.Margin = new Padding(0);
            tableLayoutPanel_left.Name = "tableLayoutPanel_left";
            tableLayoutPanel_left.RowCount = 2;
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_left.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_left.Size = new Size(640, 805);
            tableLayoutPanel_left.TabIndex = 0;
            // 
            // tableLayoutPanel_right
            // 
            tableLayoutPanel_right.ColumnCount = 1;
            tableLayoutPanel_right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_right.Controls.Add(customGroupBox_menu, 0, 0);
            tableLayoutPanel_right.Controls.Add(customGroupBox_bill, 0, 1);
            tableLayoutPanel_right.Dock = DockStyle.Fill;
            tableLayoutPanel_right.Location = new Point(640, 0);
            tableLayoutPanel_right.Margin = new Padding(0);
            tableLayoutPanel_right.Name = "tableLayoutPanel_right";
            tableLayoutPanel_right.RowCount = 2;
            tableLayoutPanel_right.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_right.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_right.Size = new Size(641, 805);
            tableLayoutPanel_right.TabIndex = 0;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_left, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_right, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 1;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1281, 805);
            tableLayoutPanel_back.TabIndex = 14;
            // 
            // Form_Sale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1281, 805);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Sale";
            Text = "Form_Sale";
            Load += Form_Sale_Load;
            Resize += Form_Sale_Resize;
            tableLayoutPanel_hotkey_pag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            tableLayoutPanel_menu.ResumeLayout(false);
            tableLayoutPanel_search.ResumeLayout(false);
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            customGroupBox_menu.ResumeLayout(false);
            customGroupBox_bill.ResumeLayout(false);
            tableLayoutPanel_bill.ResumeLayout(false);
            tableLayoutPanel_bill.PerformLayout();
            customGroupBox_button_pay.ResumeLayout(false);
            panel_bill.ResumeLayout(false);
            panel_bill.PerformLayout();
            tableLayoutPanel_sum_qty.ResumeLayout(false);
            tableLayoutPanel_sum_price.ResumeLayout(false);
            tableLayoutPanel_discount_pro.ResumeLayout(false);
            tableLayoutPanel_discount_member.ResumeLayout(false);
            tableLayoutPanel_discount_round.ResumeLayout(false);
            tableLayoutPanel_sum_net.ResumeLayout(false);
            customGroupBox_member.ResumeLayout(false);
            tableLayoutPanel_member.ResumeLayout(false);
            tableLayoutPanel_member.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete_member).EndInit();
            customGroupBox_hotkey.ResumeLayout(false);
            customGroupBox_hotkey_pag.ResumeLayout(false);
            tableLayoutPanel_left.ResumeLayout(false);
            tableLayoutPanel_right.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker_hotkey;
        private TableLayoutPanel tableLayoutPanel_hotkey_pag;
        private Button button_hotkey_1;
        private Button button_last_sale;
        private Button button_hot_sale;
        private Button button_pay;
        private TableLayoutPanel tableLayoutPanel_menu;
        private Button button_member;
        private Button button_hole_bill;
        private DataGridView dataGridView_item;
        private Button button_other;
        private TableLayoutPanel tableLayoutPanel_search;
        private TableLayoutPanel tableLayoutPanel_bill;
        private Panel panel_hotkey;
        private Button button_hotkey_2;
        private Button button_hotkey_3;
        private Button button_sale;
        private TextBox textBox_member;
        private Panel panel_bill;
        private Panel panel_net;
        private Panel panel_discount_member;
        private Panel panel_discount_pro;
        private Panel panel_bottom_bill;
        private TableLayoutPanel tableLayoutPanel_sum_net;
        private TableLayoutPanel tableLayoutPanel_discount_member;
        private TableLayoutPanel tableLayoutPanel_discount_pro;
        private TableLayoutPanel tableLayoutPanel_sum_qty;
        private Label label_dis_round_title;
        private Label label_dis_round;
        private Label label_price_title;
        private Label label_price_net;
        private Label label_dis_member_title;
        private Label label_dis_member;
        private Label label_dis_pro_title;
        private Label label_dis_pro;
        private Label label_sum_qty_title;
        private Label label_sum_price_title;
        private Label label_sum_qty;
        private Label label_sum_price;
        private System.Windows.Forms.Timer timer_load;
        private System.ComponentModel.BackgroundWorker backgroundWorker_bill_hole;
        private Button button_sale_display;
        public TextBox textBox_search;
        private System.ComponentModel.BackgroundWorker backgroundWorker_load;
        private TableLayoutPanel tableLayoutPanel_member;
        private PictureBox pictureBox_delete_member;
        private Panel panel_search;
        private CustomGroupBox customGroupBox_hotkey;
        private CustomGroupBox customGroupBox_hotkey_pag;
        private CustomGroupBox customGroupBox_menu;
        private CustomGroupBox customGroupBox_bill;
        private CustomGroupBox customGroupBox_button_pay;
        private CustomGroupBox customGroupBox_member;
        private TableLayoutPanel tableLayoutPanel_left;
        private TableLayoutPanel tableLayoutPanel_right;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_discount_round;
        private TableLayoutPanel tableLayoutPanel_sum_price;
        private DataGridViewTextBoxColumn id_temp;
        private DataGridViewTextBoxColumn item_code;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewImageColumn delete;
        private DataGridViewTextBoxColumn item_name;
        private DataGridViewImageColumn edit;
        private DataGridViewTextBoxColumn item_qty;
        private DataGridViewTextBoxColumn item_unit;
        private DataGridViewTextBoxColumn item_price;
        private DataGridViewTextBoxColumn item_price_total;
        private DataGridViewImageColumn pro;
        private DataGridViewTextBoxColumn pro_id;
        private DataGridViewTextBoxColumn pro_type;
        private DataGridViewTextBoxColumn pro_desc;
        private DataGridViewTextBoxColumn criterion_type;
        private DataGridViewTextBoxColumn criterion_value;
        private DataGridViewTextBoxColumn offer_type;
        private DataGridViewTextBoxColumn offer_value;
        private DataGridViewTextBoxColumn discount_type;
        private DataGridViewTextBoxColumn repeat;
        private DataGridViewTextBoxColumn premium;
        private DataGridViewTextBoxColumn effective_member;
        private DataGridViewTextBoxColumn sale_vat;
        private Button button_delete_all;
    }
}