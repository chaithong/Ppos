namespace Ppos
{
    partial class Form_Point_Trans
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            dataGridView_member = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            phone = new DataGridViewTextBoxColumn();
            sex = new DataGridViewTextBoxColumn();
            nick_name = new DataGridViewTextBoxColumn();
            first_name = new DataGridViewTextBoxColumn();
            last_name = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            sub_district = new DataGridViewTextBoxColumn();
            district = new DataGridViewTextBoxColumn();
            province = new DataGridViewTextBoxColumn();
            postal_code = new DataGridViewTextBoxColumn();
            discount_percent = new DataGridViewTextBoxColumn();
            sale_total = new DataGridViewTextBoxColumn();
            sale_ineffective_member = new DataGridViewTextBoxColumn();
            sale_effective_member = new DataGridViewTextBoxColumn();
            sale_per_point = new DataGridViewTextBoxColumn();
            point_increase = new DataGridViewTextBoxColumn();
            point_decrease = new DataGridViewTextBoxColumn();
            point_balance = new DataGridViewTextBoxColumn();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
            dataGridView_trans = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            trans_type = new DataGridViewTextBoxColumn();
            trans_desc = new DataGridViewTextBoxColumn();
            per_point = new DataGridViewTextBoxColumn();
            point_begin = new DataGridViewTextBoxColumn();
            point_inc_dec = new DataGridViewTextBoxColumn();
            point_end = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            tableLayoutPanel_top = new TableLayoutPanel();
            button_sort = new Button();
            pictureBox_sex = new PictureBox();
            tableLayoutPanel_name = new TableLayoutPanel();
            tableLayoutPanel_date = new TableLayoutPanel();
            label_date = new Label();
            button_back_date = new Button();
            button_next_date = new Button();
            label_member_name = new Label();
            button_excel = new Button();
            timer_search_member = new System.Windows.Forms.Timer(components);
            backgroundWorker_point = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_excel = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).BeginInit();
            panel_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_trans).BeginInit();
            tableLayoutPanel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_sex).BeginInit();
            tableLayoutPanel_name.SuspendLayout();
            tableLayoutPanel_date.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.FromArgb(128, 255, 128);
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(dataGridView_member, 0, 1);
            tableLayoutPanel_back.Controls.Add(panel_search, 0, 0);
            tableLayoutPanel_back.Controls.Add(dataGridView_trans, 1, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1158, 740);
            tableLayoutPanel_back.TabIndex = 1;
            // 
            // dataGridView_member
            // 
            dataGridView_member.AllowUserToAddRows = false;
            dataGridView_member.AllowUserToDeleteRows = false;
            dataGridView_member.AllowUserToResizeColumns = false;
            dataGridView_member.AllowUserToResizeRows = false;
            dataGridView_member.BackgroundColor = Color.White;
            dataGridView_member.BorderStyle = BorderStyle.None;
            dataGridView_member.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_member.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_member.ColumnHeadersHeight = 40;
            dataGridView_member.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_member.Columns.AddRange(new DataGridViewColumn[] { id, phone, sex, nick_name, first_name, last_name, address, sub_district, district, province, postal_code, discount_percent, sale_total, sale_ineffective_member, sale_effective_member, sale_per_point, point_increase, point_decrease, point_balance });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView_member.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_member.Dock = DockStyle.Fill;
            dataGridView_member.GridColor = Color.FromArgb(192, 255, 192);
            dataGridView_member.Location = new Point(0, 120);
            dataGridView_member.Margin = new Padding(0);
            dataGridView_member.MultiSelect = false;
            dataGridView_member.Name = "dataGridView_member";
            dataGridView_member.ReadOnly = true;
            dataGridView_member.RowHeadersVisible = false;
            dataGridView_member.RowHeadersWidth = 51;
            dataGridView_member.RowTemplate.Height = 50;
            dataGridView_member.ScrollBars = ScrollBars.None;
            dataGridView_member.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_member.ShowCellToolTips = false;
            dataGridView_member.Size = new Size(400, 620);
            dataGridView_member.TabIndex = 6;
            dataGridView_member.TabStop = false;
            dataGridView_member.CellClick += dataGridView_member_CellClick;
            dataGridView_member.CellMouseEnter += dataGridView_member_CellMouseEnter;
            dataGridView_member.CellMouseLeave += dataGridView_member_CellMouseLeave;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 125;
            // 
            // phone
            // 
            phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            phone.HeaderText = "";
            phone.MinimumWidth = 6;
            phone.Name = "phone";
            phone.ReadOnly = true;
            // 
            // sex
            // 
            sex.HeaderText = "sex";
            sex.MinimumWidth = 6;
            sex.Name = "sex";
            sex.ReadOnly = true;
            sex.Visible = false;
            sex.Width = 125;
            // 
            // nick_name
            // 
            nick_name.HeaderText = "nick_name";
            nick_name.MinimumWidth = 6;
            nick_name.Name = "nick_name";
            nick_name.ReadOnly = true;
            nick_name.Visible = false;
            nick_name.Width = 125;
            // 
            // first_name
            // 
            first_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            first_name.DefaultCellStyle = dataGridViewCellStyle2;
            first_name.HeaderText = "first_name";
            first_name.MinimumWidth = 6;
            first_name.Name = "first_name";
            first_name.ReadOnly = true;
            first_name.Visible = false;
            // 
            // last_name
            // 
            last_name.HeaderText = "last_name";
            last_name.MinimumWidth = 6;
            last_name.Name = "last_name";
            last_name.ReadOnly = true;
            last_name.Visible = false;
            last_name.Width = 125;
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            address.DefaultCellStyle = dataGridViewCellStyle3;
            address.HeaderText = "address";
            address.MinimumWidth = 6;
            address.Name = "address";
            address.ReadOnly = true;
            address.Visible = false;
            address.Width = 125;
            // 
            // sub_district
            // 
            sub_district.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            sub_district.DefaultCellStyle = dataGridViewCellStyle4;
            sub_district.HeaderText = "sub_district";
            sub_district.MinimumWidth = 6;
            sub_district.Name = "sub_district";
            sub_district.ReadOnly = true;
            sub_district.Visible = false;
            sub_district.Width = 125;
            // 
            // district
            // 
            district.HeaderText = "district";
            district.MinimumWidth = 6;
            district.Name = "district";
            district.ReadOnly = true;
            district.Visible = false;
            district.Width = 125;
            // 
            // province
            // 
            province.HeaderText = "province";
            province.MinimumWidth = 6;
            province.Name = "province";
            province.ReadOnly = true;
            province.Visible = false;
            province.Width = 125;
            // 
            // postal_code
            // 
            postal_code.HeaderText = "postal_code";
            postal_code.MinimumWidth = 6;
            postal_code.Name = "postal_code";
            postal_code.ReadOnly = true;
            postal_code.Visible = false;
            postal_code.Width = 125;
            // 
            // discount_percent
            // 
            discount_percent.HeaderText = "discount_percent";
            discount_percent.MinimumWidth = 6;
            discount_percent.Name = "discount_percent";
            discount_percent.ReadOnly = true;
            discount_percent.Visible = false;
            discount_percent.Width = 125;
            // 
            // sale_total
            // 
            sale_total.HeaderText = "sale_total";
            sale_total.MinimumWidth = 6;
            sale_total.Name = "sale_total";
            sale_total.ReadOnly = true;
            sale_total.Visible = false;
            sale_total.Width = 125;
            // 
            // sale_ineffective_member
            // 
            sale_ineffective_member.HeaderText = "sale_ineffective_member";
            sale_ineffective_member.MinimumWidth = 6;
            sale_ineffective_member.Name = "sale_ineffective_member";
            sale_ineffective_member.ReadOnly = true;
            sale_ineffective_member.Visible = false;
            sale_ineffective_member.Width = 125;
            // 
            // sale_effective_member
            // 
            sale_effective_member.HeaderText = "sale_effective_member";
            sale_effective_member.MinimumWidth = 6;
            sale_effective_member.Name = "sale_effective_member";
            sale_effective_member.ReadOnly = true;
            sale_effective_member.Visible = false;
            sale_effective_member.Width = 125;
            // 
            // sale_per_point
            // 
            sale_per_point.HeaderText = "sale_per_point";
            sale_per_point.MinimumWidth = 6;
            sale_per_point.Name = "sale_per_point";
            sale_per_point.ReadOnly = true;
            sale_per_point.Visible = false;
            sale_per_point.Width = 125;
            // 
            // point_increase
            // 
            point_increase.HeaderText = "point_increase";
            point_increase.MinimumWidth = 6;
            point_increase.Name = "point_increase";
            point_increase.ReadOnly = true;
            point_increase.Visible = false;
            point_increase.Width = 125;
            // 
            // point_decrease
            // 
            point_decrease.HeaderText = "point_decrease";
            point_decrease.MinimumWidth = 6;
            point_decrease.Name = "point_decrease";
            point_decrease.ReadOnly = true;
            point_decrease.Visible = false;
            point_decrease.Width = 125;
            // 
            // point_balance
            // 
            point_balance.HeaderText = "point_balance";
            point_balance.MinimumWidth = 6;
            point_balance.Name = "point_balance";
            point_balance.ReadOnly = true;
            point_balance.Visible = false;
            point_balance.Width = 125;
            // 
            // panel_search
            // 
            panel_search.Controls.Add(label_search);
            panel_search.Controls.Add(textBox_search);
            panel_search.Dock = DockStyle.Fill;
            panel_search.Location = new Point(0, 0);
            panel_search.Margin = new Padding(0);
            panel_search.Name = "panel_search";
            panel_search.Size = new Size(400, 120);
            panel_search.TabIndex = 3;
            // 
            // label_search
            // 
            label_search.BackColor = Color.Transparent;
            label_search.Dock = DockStyle.Fill;
            label_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label_search.ForeColor = Color.Gray;
            label_search.Location = new Point(0, 0);
            label_search.Name = "label_search";
            label_search.Size = new Size(400, 84);
            label_search.TabIndex = 1;
            label_search.TextAlign = ContentAlignment.BottomRight;
            // 
            // textBox_search
            // 
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Bottom;
            textBox_search.Font = new Font("Segoe UI", 16.2F);
            textBox_search.Location = new Point(0, 84);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(400, 36);
            textBox_search.TabIndex = 0;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            textBox_search.Leave += textBox_search_Leave;
            // 
            // dataGridView_trans
            // 
            dataGridView_trans.AllowUserToAddRows = false;
            dataGridView_trans.AllowUserToDeleteRows = false;
            dataGridView_trans.AllowUserToResizeColumns = false;
            dataGridView_trans.AllowUserToResizeRows = false;
            dataGridView_trans.BackgroundColor = Color.White;
            dataGridView_trans.BorderStyle = BorderStyle.None;
            dataGridView_trans.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_trans.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.Gray;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle6.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView_trans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView_trans.ColumnHeadersHeight = 40;
            dataGridView_trans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_trans.Columns.AddRange(new DataGridViewColumn[] { Column2, date, time, trans_type, trans_desc, per_point, point_begin, point_inc_dec, point_end, Column1 });
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle14.ForeColor = Color.DimGray;
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle14.SelectionForeColor = Color.Black;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dataGridView_trans.DefaultCellStyle = dataGridViewCellStyle14;
            dataGridView_trans.Dock = DockStyle.Fill;
            dataGridView_trans.GridColor = Color.Lime;
            dataGridView_trans.Location = new Point(410, 120);
            dataGridView_trans.Margin = new Padding(10, 0, 0, 0);
            dataGridView_trans.Name = "dataGridView_trans";
            dataGridView_trans.ReadOnly = true;
            dataGridView_trans.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_trans.RowHeadersVisible = false;
            dataGridView_trans.RowHeadersWidth = 51;
            dataGridView_trans.RowTemplate.Height = 50;
            dataGridView_trans.RowTemplate.ReadOnly = true;
            dataGridView_trans.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView_trans.ScrollBars = ScrollBars.None;
            dataGridView_trans.Size = new Size(748, 620);
            dataGridView_trans.TabIndex = 4;
            dataGridView_trans.CellMouseEnter += dataGridView_trans_CellMouseEnter;
            dataGridView_trans.CellMouseLeave += dataGridView_trans_CellMouseLeave;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            date.DefaultCellStyle = dataGridViewCellStyle7;
            date.HeaderText = "วันที่";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.ReadOnly = true;
            date.Width = 80;
            // 
            // time
            // 
            time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            time.DefaultCellStyle = dataGridViewCellStyle8;
            time.HeaderText = "เวลา";
            time.MinimumWidth = 6;
            time.Name = "time";
            time.ReadOnly = true;
            time.Width = 81;
            // 
            // trans_type
            // 
            trans_type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            trans_type.DefaultCellStyle = dataGridViewCellStyle9;
            trans_type.HeaderText = "";
            trans_type.MinimumWidth = 6;
            trans_type.Name = "trans_type";
            trans_type.ReadOnly = true;
            trans_type.Width = 23;
            // 
            // trans_desc
            // 
            trans_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            trans_desc.DefaultCellStyle = dataGridViewCellStyle10;
            trans_desc.HeaderText = "";
            trans_desc.MinimumWidth = 6;
            trans_desc.Name = "trans_desc";
            trans_desc.ReadOnly = true;
            trans_desc.Width = 23;
            // 
            // per_point
            // 
            per_point.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            per_point.HeaderText = "";
            per_point.MinimumWidth = 6;
            per_point.Name = "per_point";
            per_point.ReadOnly = true;
            per_point.Visible = false;
            per_point.Width = 125;
            // 
            // point_begin
            // 
            point_begin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            point_begin.DefaultCellStyle = dataGridViewCellStyle11;
            point_begin.HeaderText = "เริ่มต้น";
            point_begin.MinimumWidth = 6;
            point_begin.Name = "point_begin";
            point_begin.ReadOnly = true;
            point_begin.Width = 97;
            // 
            // point_inc_dec
            // 
            point_inc_dec.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            point_inc_dec.DefaultCellStyle = dataGridViewCellStyle12;
            point_inc_dec.HeaderText = "ปรับแต้ม";
            point_inc_dec.MinimumWidth = 6;
            point_inc_dec.Name = "point_inc_dec";
            point_inc_dec.ReadOnly = true;
            point_inc_dec.Width = 113;
            // 
            // point_end
            // 
            point_end.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            point_end.DefaultCellStyle = dataGridViewCellStyle13;
            point_end.HeaderText = "คงเหลือ";
            point_end.MinimumWidth = 6;
            point_end.Name = "point_end";
            point_end.ReadOnly = true;
            point_end.Width = 107;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 5;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_top.Controls.Add(button_sort, 0, 0);
            tableLayoutPanel_top.Controls.Add(pictureBox_sex, 1, 0);
            tableLayoutPanel_top.Controls.Add(tableLayoutPanel_name, 2, 0);
            tableLayoutPanel_top.Controls.Add(button_excel, 4, 0);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(410, 0);
            tableLayoutPanel_top.Margin = new Padding(10, 0, 0, 0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 1;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.Size = new Size(748, 120);
            tableLayoutPanel_top.TabIndex = 5;
            // 
            // button_sort
            // 
            button_sort.Dock = DockStyle.Fill;
            button_sort.FlatAppearance.BorderSize = 0;
            button_sort.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_sort.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sort.FlatStyle = FlatStyle.Flat;
            button_sort.Location = new Point(3, 3);
            button_sort.Name = "button_sort";
            button_sort.Size = new Size(44, 114);
            button_sort.TabIndex = 2;
            button_sort.UseVisualStyleBackColor = true;
            button_sort.Click += button_sort_Click;
            button_sort.MouseEnter += button_sort_MouseEnter;
            button_sort.MouseLeave += button_sort_MouseLeave;
            // 
            // pictureBox_sex
            // 
            pictureBox_sex.Dock = DockStyle.Fill;
            pictureBox_sex.Location = new Point(50, 0);
            pictureBox_sex.Margin = new Padding(0);
            pictureBox_sex.Name = "pictureBox_sex";
            pictureBox_sex.Size = new Size(150, 120);
            pictureBox_sex.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_sex.TabIndex = 0;
            pictureBox_sex.TabStop = false;
            // 
            // tableLayoutPanel_name
            // 
            tableLayoutPanel_name.ColumnCount = 1;
            tableLayoutPanel_name.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_name.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_name.Controls.Add(tableLayoutPanel_date, 0, 0);
            tableLayoutPanel_name.Controls.Add(label_member_name, 0, 1);
            tableLayoutPanel_name.Dock = DockStyle.Fill;
            tableLayoutPanel_name.Location = new Point(200, 0);
            tableLayoutPanel_name.Margin = new Padding(0);
            tableLayoutPanel_name.Name = "tableLayoutPanel_name";
            tableLayoutPanel_name.RowCount = 2;
            tableLayoutPanel_name.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_name.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_name.Size = new Size(348, 120);
            tableLayoutPanel_name.TabIndex = 3;
            // 
            // tableLayoutPanel_date
            // 
            tableLayoutPanel_date.ColumnCount = 5;
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_date.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_date.Controls.Add(label_date, 2, 0);
            tableLayoutPanel_date.Controls.Add(button_back_date, 1, 0);
            tableLayoutPanel_date.Controls.Add(button_next_date, 3, 0);
            tableLayoutPanel_date.Dock = DockStyle.Fill;
            tableLayoutPanel_date.Location = new Point(0, 0);
            tableLayoutPanel_date.Margin = new Padding(0);
            tableLayoutPanel_date.Name = "tableLayoutPanel_date";
            tableLayoutPanel_date.RowCount = 1;
            tableLayoutPanel_date.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_date.Size = new Size(348, 60);
            tableLayoutPanel_date.TabIndex = 2;
            // 
            // label_date
            // 
            label_date.Dock = DockStyle.Fill;
            label_date.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_date.Location = new Point(77, 0);
            label_date.Name = "label_date";
            label_date.Size = new Size(194, 60);
            label_date.TabIndex = 0;
            label_date.Text = "dd/MM/yyyy";
            label_date.TextAlign = ContentAlignment.MiddleCenter;
            label_date.Click += label_date_Click;
            label_date.MouseEnter += label_MouseEnter;
            label_date.MouseLeave += label_MouseLeave;
            // 
            // button_back_date
            // 
            button_back_date.BackgroundImage = Properties.Resources.back;
            button_back_date.BackgroundImageLayout = ImageLayout.Zoom;
            button_back_date.Dock = DockStyle.Fill;
            button_back_date.FlatAppearance.BorderSize = 0;
            button_back_date.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_back_date.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_back_date.FlatStyle = FlatStyle.Flat;
            button_back_date.Location = new Point(27, 3);
            button_back_date.Name = "button_back_date";
            button_back_date.Size = new Size(44, 54);
            button_back_date.TabIndex = 1;
            button_back_date.UseVisualStyleBackColor = true;
            button_back_date.Click += button_back_date_Click;
            // 
            // button_next_date
            // 
            button_next_date.BackgroundImage = Properties.Resources.next;
            button_next_date.BackgroundImageLayout = ImageLayout.Zoom;
            button_next_date.Dock = DockStyle.Fill;
            button_next_date.FlatAppearance.BorderSize = 0;
            button_next_date.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_next_date.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_next_date.FlatStyle = FlatStyle.Flat;
            button_next_date.Location = new Point(277, 3);
            button_next_date.Name = "button_next_date";
            button_next_date.Size = new Size(44, 54);
            button_next_date.TabIndex = 1;
            button_next_date.UseVisualStyleBackColor = true;
            button_next_date.Click += button_next_date_Click;
            // 
            // label_member_name
            // 
            label_member_name.Dock = DockStyle.Fill;
            label_member_name.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_member_name.Location = new Point(3, 60);
            label_member_name.Name = "label_member_name";
            label_member_name.Size = new Size(342, 60);
            label_member_name.TabIndex = 3;
            label_member_name.TextAlign = ContentAlignment.MiddleCenter;
            label_member_name.MouseEnter += label_MouseEnter;
            label_member_name.MouseLeave += label_MouseLeave;
            // 
            // button_excel
            // 
            button_excel.BackColor = Color.Transparent;
            button_excel.BackgroundImageLayout = ImageLayout.Zoom;
            button_excel.Dock = DockStyle.Fill;
            button_excel.FlatAppearance.BorderSize = 0;
            button_excel.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_excel.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_excel.FlatStyle = FlatStyle.Flat;
            button_excel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_excel.ForeColor = Color.Black;
            button_excel.Location = new Point(651, 3);
            button_excel.Name = "button_excel";
            button_excel.Size = new Size(94, 114);
            button_excel.TabIndex = 0;
            button_excel.Text = "โหลด";
            button_excel.TextAlign = ContentAlignment.BottomCenter;
            button_excel.TextImageRelation = TextImageRelation.ImageAboveText;
            button_excel.UseVisualStyleBackColor = false;
            button_excel.Visible = false;
            button_excel.Click += button_excel_Click;
            button_excel.MouseEnter += button_excel_MouseEnter;
            button_excel.MouseLeave += button_excel_MouseLeave;
            // 
            // timer_search_member
            // 
            timer_search_member.Tick += timer_search_member_Tick;
            // 
            // backgroundWorker_point
            // 
            backgroundWorker_point.DoWork += backgroundWorker_point_DoWork;
            backgroundWorker_point.RunWorkerCompleted += backgroundWorker_point_RunWorkerCompleted;
            // 
            // backgroundWorker_excel
            // 
            backgroundWorker_excel.DoWork += backgroundWorker_excel_DoWork;
            backgroundWorker_excel.RunWorkerCompleted += backgroundWorker_excel_RunWorkerCompleted;
            // 
            // Form_Point_Trans
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1158, 740);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Point_Trans";
            FormClosed += Form_Point_Trans_FormClosed;
            Load += Form_Point_Trans_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).EndInit();
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_trans).EndInit();
            tableLayoutPanel_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_sex).EndInit();
            tableLayoutPanel_name.ResumeLayout(false);
            tableLayoutPanel_date.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private Panel panel_search;
        private Label label_search;
        private TextBox textBox_search;
        private DataGridView dataGridView_trans;
        private TableLayoutPanel tableLayoutPanel_top;
        private Button button_sort;
        private PictureBox pictureBox_sex;
        private TableLayoutPanel tableLayoutPanel_name;
        private TableLayoutPanel tableLayoutPanel_date;
        private Label label_date;
        private Button button_back_date;
        private Button button_next_date;
        private Label label_member_name;
        private Button button_excel;
        private DataGridView dataGridView_member;
        private System.Windows.Forms.Timer timer_search_member;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn sex;
        private DataGridViewTextBoxColumn nick_name;
        private DataGridViewTextBoxColumn first_name;
        private DataGridViewTextBoxColumn last_name;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn sub_district;
        private DataGridViewTextBoxColumn district;
        private DataGridViewTextBoxColumn province;
        private DataGridViewTextBoxColumn postal_code;
        private DataGridViewTextBoxColumn discount_percent;
        private DataGridViewTextBoxColumn sale_total;
        private DataGridViewTextBoxColumn sale_ineffective_member;
        private DataGridViewTextBoxColumn sale_effective_member;
        private DataGridViewTextBoxColumn sale_per_point;
        private DataGridViewTextBoxColumn point_increase;
        private DataGridViewTextBoxColumn point_decrease;
        private DataGridViewTextBoxColumn point_balance;
        private System.ComponentModel.BackgroundWorker backgroundWorker_point;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn trans_type;
        private DataGridViewTextBoxColumn trans_desc;
        private DataGridViewTextBoxColumn per_point;
        private DataGridViewTextBoxColumn point_begin;
        private DataGridViewTextBoxColumn point_inc_dec;
        private DataGridViewTextBoxColumn point_end;
        private DataGridViewTextBoxColumn Column1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_excel;
    }
}