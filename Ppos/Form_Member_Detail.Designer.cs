namespace Ppos
{
    partial class Form_Member_Detail
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
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_button = new TableLayoutPanel();
            button_cancel = new Button();
            button_add_save = new Button();
            button_edit_save = new Button();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
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
            delete = new DataGridViewImageColumn();
            panel_detail = new Panel();
            customGroupBox_detail = new CustomGroupBox();
            tableLayoutPanel_detail = new TableLayoutPanel();
            label_sale_effective_member = new Label();
            label_sale_ineffective_member = new Label();
            textBox_sale_per_point = new TextBox();
            textBox_discount_percent = new TextBox();
            label_sale_total = new Label();
            textBox_decrease_point = new TextBox();
            textBox_increase_point = new TextBox();
            label11 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            label19 = new Label();
            label18 = new Label();
            textBox_phone = new TextBox();
            label_phone = new Label();
            label8 = new Label();
            textBox_postal_code = new TextBox();
            label7 = new Label();
            textBox_province = new TextBox();
            label6 = new Label();
            textBox_district = new TextBox();
            label5 = new Label();
            textBox_sub_district = new TextBox();
            label4 = new Label();
            textBox_address = new TextBox();
            label2 = new Label();
            textBox_last_name = new TextBox();
            label3 = new Label();
            textBox_nick_name = new TextBox();
            label1 = new Label();
            textBox_first_name = new TextBox();
            label9 = new Label();
            panel_sex = new Panel();
            button_sex_female = new Button();
            button_sex_male = new Button();
            label17 = new Label();
            label_point_balance = new Label();
            timer_search_member = new System.Windows.Forms.Timer(components);
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_button.SuspendLayout();
            panel_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).BeginInit();
            panel_detail.SuspendLayout();
            customGroupBox_detail.SuspendLayout();
            tableLayoutPanel_detail.SuspendLayout();
            panel_sex.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Lime;
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_button, 1, 0);
            tableLayoutPanel_back.Controls.Add(panel_search, 0, 0);
            tableLayoutPanel_back.Controls.Add(dataGridView_member, 0, 1);
            tableLayoutPanel_back.Controls.Add(panel_detail, 1, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1534, 872);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_button
            // 
            tableLayoutPanel_button.BackColor = Color.Lime;
            tableLayoutPanel_button.ColumnCount = 5;
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel_button.Controls.Add(button_cancel, 3, 0);
            tableLayoutPanel_button.Controls.Add(button_add_save, 1, 0);
            tableLayoutPanel_button.Controls.Add(button_edit_save, 2, 0);
            tableLayoutPanel_button.Dock = DockStyle.Fill;
            tableLayoutPanel_button.Location = new Point(400, 0);
            tableLayoutPanel_button.Margin = new Padding(0);
            tableLayoutPanel_button.Name = "tableLayoutPanel_button";
            tableLayoutPanel_button.RowCount = 1;
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button.Size = new Size(1134, 100);
            tableLayoutPanel_button.TabIndex = 4;
            // 
            // button_cancel
            // 
            button_cancel.BackColor = Color.Lime;
            button_cancel.BackgroundImageLayout = ImageLayout.Zoom;
            button_cancel.Dock = DockStyle.Fill;
            button_cancel.Enabled = false;
            button_cancel.FlatAppearance.BorderSize = 0;
            button_cancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_cancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_cancel.FlatStyle = FlatStyle.Flat;
            button_cancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_cancel.Location = new Point(736, 0);
            button_cancel.Margin = new Padding(0);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(340, 100);
            button_cancel.TabIndex = 4;
            button_cancel.TabStop = false;
            button_cancel.Text = " ยกเลิก";
            button_cancel.TextAlign = ContentAlignment.BottomCenter;
            button_cancel.TextImageRelation = TextImageRelation.ImageAboveText;
            button_cancel.UseVisualStyleBackColor = false;
            button_cancel.Click += button_cancel_Click;
            button_cancel.MouseEnter += button_MouseEnter;
            button_cancel.MouseLeave += button_MouseLeave;
            // 
            // button_add_save
            // 
            button_add_save.BackColor = Color.Lime;
            button_add_save.BackgroundImageLayout = ImageLayout.Zoom;
            button_add_save.Dock = DockStyle.Fill;
            button_add_save.FlatAppearance.BorderSize = 0;
            button_add_save.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_add_save.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_add_save.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_add_save.Location = new Point(56, 0);
            button_add_save.Margin = new Padding(0);
            button_add_save.Name = "button_add_save";
            button_add_save.Size = new Size(340, 100);
            button_add_save.TabIndex = 3;
            button_add_save.TabStop = false;
            button_add_save.Text = " เพิ่ม";
            button_add_save.TextAlign = ContentAlignment.BottomCenter;
            button_add_save.TextImageRelation = TextImageRelation.ImageAboveText;
            button_add_save.UseVisualStyleBackColor = false;
            button_add_save.Click += button_add_save_Click;
            button_add_save.MouseEnter += button_MouseEnter;
            button_add_save.MouseLeave += button_MouseLeave;
            // 
            // button_edit_save
            // 
            button_edit_save.BackColor = Color.Lime;
            button_edit_save.BackgroundImageLayout = ImageLayout.Zoom;
            button_edit_save.Dock = DockStyle.Fill;
            button_edit_save.Enabled = false;
            button_edit_save.FlatAppearance.BorderSize = 0;
            button_edit_save.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 255, 192);
            button_edit_save.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
            button_edit_save.FlatStyle = FlatStyle.Flat;
            button_edit_save.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            button_edit_save.Location = new Point(396, 0);
            button_edit_save.Margin = new Padding(0);
            button_edit_save.Name = "button_edit_save";
            button_edit_save.Size = new Size(340, 100);
            button_edit_save.TabIndex = 2;
            button_edit_save.TabStop = false;
            button_edit_save.Text = "แก้ไข";
            button_edit_save.TextAlign = ContentAlignment.BottomCenter;
            button_edit_save.TextImageRelation = TextImageRelation.ImageAboveText;
            button_edit_save.UseVisualStyleBackColor = false;
            button_edit_save.Click += button_edit_save_Click;
            button_edit_save.MouseEnter += button_MouseEnter;
            button_edit_save.MouseLeave += button_MouseLeave;
            // 
            // panel_search
            // 
            panel_search.Controls.Add(label_search);
            panel_search.Controls.Add(textBox_search);
            panel_search.Dock = DockStyle.Fill;
            panel_search.Location = new Point(0, 0);
            panel_search.Margin = new Padding(0);
            panel_search.Name = "panel_search";
            panel_search.Size = new Size(400, 100);
            panel_search.TabIndex = 4;
            // 
            // label_search
            // 
            label_search.Dock = DockStyle.Fill;
            label_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold);
            label_search.ForeColor = Color.Gray;
            label_search.Location = new Point(0, 0);
            label_search.Name = "label_search";
            label_search.Size = new Size(400, 64);
            label_search.TabIndex = 2;
            label_search.Text = "--";
            label_search.TextAlign = ContentAlignment.BottomRight;
            // 
            // textBox_search
            // 
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Bottom;
            textBox_search.Font = new Font("Segoe UI", 16.2F);
            textBox_search.Location = new Point(0, 64);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(400, 36);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
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
            dataGridViewCellStyle1.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_member.ColumnHeadersHeight = 10;
            dataGridView_member.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_member.Columns.AddRange(new DataGridViewColumn[] { id, phone, sex, nick_name, first_name, last_name, address, sub_district, district, province, postal_code, discount_percent, sale_total, sale_ineffective_member, sale_effective_member, sale_per_point, point_increase, point_decrease, point_balance, delete });
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
            dataGridView_member.Location = new Point(0, 100);
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
            dataGridView_member.Size = new Size(400, 772);
            dataGridView_member.TabIndex = 2;
            dataGridView_member.TabStop = false;
            dataGridView_member.CellMouseDown += dataGridView_member_CellMouseDown;
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
            phone.HeaderText = "phone";
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
            // delete
            // 
            delete.HeaderText = "";
            delete.MinimumWidth = 6;
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.Width = 70;
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Controls.Add(customGroupBox_detail);
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(410, 110);
            panel_detail.Margin = new Padding(10, 10, 0, 0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(1124, 762);
            panel_detail.TabIndex = 3;
            // 
            // customGroupBox_detail
            // 
            customGroupBox_detail.Anchor = AnchorStyles.Top;
            customGroupBox_detail.BorderColor = Color.Lime;
            customGroupBox_detail.BorderRadius = 30;
            customGroupBox_detail.BorderThickness = 10;
            customGroupBox_detail.Controls.Add(tableLayoutPanel_detail);
            customGroupBox_detail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customGroupBox_detail.Location = new Point(130, 86);
            customGroupBox_detail.Name = "customGroupBox_detail";
            customGroupBox_detail.Padding = new Padding(8);
            customGroupBox_detail.Size = new Size(900, 513);
            customGroupBox_detail.TabIndex = 0;
            customGroupBox_detail.TabStop = false;
            // 
            // tableLayoutPanel_detail
            // 
            tableLayoutPanel_detail.AutoSize = true;
            tableLayoutPanel_detail.BackColor = Color.Transparent;
            tableLayoutPanel_detail.ColumnCount = 4;
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_detail.Controls.Add(label_sale_effective_member, 3, 3);
            tableLayoutPanel_detail.Controls.Add(label_sale_ineffective_member, 3, 2);
            tableLayoutPanel_detail.Controls.Add(textBox_sale_per_point, 3, 4);
            tableLayoutPanel_detail.Controls.Add(textBox_discount_percent, 3, 0);
            tableLayoutPanel_detail.Controls.Add(label_sale_total, 3, 1);
            tableLayoutPanel_detail.Controls.Add(textBox_decrease_point, 3, 9);
            tableLayoutPanel_detail.Controls.Add(textBox_increase_point, 3, 8);
            tableLayoutPanel_detail.Controls.Add(label11, 2, 4);
            tableLayoutPanel_detail.Controls.Add(label14, 2, 3);
            tableLayoutPanel_detail.Controls.Add(label13, 2, 2);
            tableLayoutPanel_detail.Controls.Add(label12, 2, 1);
            tableLayoutPanel_detail.Controls.Add(label10, 2, 0);
            tableLayoutPanel_detail.Controls.Add(label19, 2, 9);
            tableLayoutPanel_detail.Controls.Add(label18, 2, 8);
            tableLayoutPanel_detail.Controls.Add(textBox_phone, 1, 0);
            tableLayoutPanel_detail.Controls.Add(label_phone, 0, 0);
            tableLayoutPanel_detail.Controls.Add(label8, 0, 9);
            tableLayoutPanel_detail.Controls.Add(textBox_postal_code, 1, 9);
            tableLayoutPanel_detail.Controls.Add(label7, 0, 8);
            tableLayoutPanel_detail.Controls.Add(textBox_province, 1, 8);
            tableLayoutPanel_detail.Controls.Add(label6, 0, 7);
            tableLayoutPanel_detail.Controls.Add(textBox_district, 1, 7);
            tableLayoutPanel_detail.Controls.Add(label5, 0, 6);
            tableLayoutPanel_detail.Controls.Add(textBox_sub_district, 1, 6);
            tableLayoutPanel_detail.Controls.Add(label4, 0, 5);
            tableLayoutPanel_detail.Controls.Add(textBox_address, 1, 5);
            tableLayoutPanel_detail.Controls.Add(label2, 0, 4);
            tableLayoutPanel_detail.Controls.Add(textBox_last_name, 1, 4);
            tableLayoutPanel_detail.Controls.Add(label3, 0, 2);
            tableLayoutPanel_detail.Controls.Add(textBox_nick_name, 1, 2);
            tableLayoutPanel_detail.Controls.Add(label1, 0, 3);
            tableLayoutPanel_detail.Controls.Add(textBox_first_name, 1, 3);
            tableLayoutPanel_detail.Controls.Add(label9, 0, 1);
            tableLayoutPanel_detail.Controls.Add(panel_sex, 1, 1);
            tableLayoutPanel_detail.Controls.Add(label17, 2, 6);
            tableLayoutPanel_detail.Controls.Add(label_point_balance, 3, 6);
            tableLayoutPanel_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_detail.Location = new Point(8, 39);
            tableLayoutPanel_detail.Margin = new Padding(10, 10, 3, 10);
            tableLayoutPanel_detail.Name = "tableLayoutPanel_detail";
            tableLayoutPanel_detail.RowCount = 10;
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel_detail.Size = new Size(884, 466);
            tableLayoutPanel_detail.TabIndex = 1;
            // 
            // label_sale_effective_member
            // 
            label_sale_effective_member.Font = new Font("Segoe UI", 13.8F);
            label_sale_effective_member.ForeColor = Color.Gray;
            label_sale_effective_member.Location = new Point(740, 138);
            label_sale_effective_member.Margin = new Padding(6, 0, 3, 0);
            label_sale_effective_member.Name = "label_sale_effective_member";
            label_sale_effective_member.Size = new Size(141, 45);
            label_sale_effective_member.TabIndex = 1;
            label_sale_effective_member.Text = "0";
            label_sale_effective_member.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_sale_ineffective_member
            // 
            label_sale_ineffective_member.Font = new Font("Segoe UI", 13.8F);
            label_sale_ineffective_member.ForeColor = Color.Gray;
            label_sale_ineffective_member.Location = new Point(740, 92);
            label_sale_ineffective_member.Margin = new Padding(6, 0, 3, 0);
            label_sale_ineffective_member.Name = "label_sale_ineffective_member";
            label_sale_ineffective_member.Size = new Size(141, 45);
            label_sale_ineffective_member.TabIndex = 1;
            label_sale_ineffective_member.Text = "0";
            label_sale_ineffective_member.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_sale_per_point
            // 
            textBox_sale_per_point.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_sale_per_point.BackColor = Color.FromArgb(192, 255, 192);
            textBox_sale_per_point.Enabled = false;
            textBox_sale_per_point.Font = new Font("Segoe UI", 13.8F);
            textBox_sale_per_point.Location = new Point(742, 188);
            textBox_sale_per_point.Margin = new Padding(8, 3, 6, 3);
            textBox_sale_per_point.Name = "textBox_sale_per_point";
            textBox_sale_per_point.Size = new Size(136, 38);
            textBox_sale_per_point.TabIndex = 2;
            textBox_sale_per_point.TabStop = false;
            textBox_sale_per_point.Text = "1";
            textBox_sale_per_point.KeyDown += textBox_phone_KeyDown;
            textBox_sale_per_point.KeyPress += textBox_sale_per_point_KeyPress;
            // 
            // textBox_discount_percent
            // 
            textBox_discount_percent.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_discount_percent.BackColor = Color.FromArgb(192, 255, 192);
            textBox_discount_percent.Enabled = false;
            textBox_discount_percent.Font = new Font("Segoe UI", 13.8F);
            textBox_discount_percent.Location = new Point(742, 4);
            textBox_discount_percent.Margin = new Padding(8, 3, 6, 3);
            textBox_discount_percent.Name = "textBox_discount_percent";
            textBox_discount_percent.Size = new Size(136, 38);
            textBox_discount_percent.TabIndex = 2;
            textBox_discount_percent.TabStop = false;
            textBox_discount_percent.Text = "0";
            textBox_discount_percent.KeyDown += textBox_phone_KeyDown;
            textBox_discount_percent.KeyPress += textBox_discount_percent_KeyPress;
            // 
            // label_sale_total
            // 
            label_sale_total.BackColor = Color.Lime;
            label_sale_total.Font = new Font("Segoe UI", 13.8F);
            label_sale_total.ForeColor = Color.Gray;
            label_sale_total.Location = new Point(740, 46);
            label_sale_total.Margin = new Padding(6, 0, 0, 3);
            label_sale_total.Name = "label_sale_total";
            label_sale_total.Size = new Size(144, 42);
            label_sale_total.TabIndex = 1;
            label_sale_total.Text = "0";
            label_sale_total.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_decrease_point
            // 
            textBox_decrease_point.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_decrease_point.BackColor = Color.FromArgb(192, 255, 192);
            textBox_decrease_point.Enabled = false;
            textBox_decrease_point.Font = new Font("Segoe UI", 13.8F);
            textBox_decrease_point.Location = new Point(742, 421);
            textBox_decrease_point.Margin = new Padding(8, 3, 6, 3);
            textBox_decrease_point.Name = "textBox_decrease_point";
            textBox_decrease_point.Size = new Size(136, 38);
            textBox_decrease_point.TabIndex = 2;
            textBox_decrease_point.TabStop = false;
            textBox_decrease_point.Text = "0";
            textBox_decrease_point.KeyDown += textBox_phone_KeyDown;
            textBox_decrease_point.KeyPress += textBox_sale_per_point_KeyPress;
            // 
            // textBox_increase_point
            // 
            textBox_increase_point.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_increase_point.BackColor = Color.FromArgb(192, 255, 192);
            textBox_increase_point.Enabled = false;
            textBox_increase_point.Font = new Font("Segoe UI", 13.8F);
            textBox_increase_point.Location = new Point(742, 372);
            textBox_increase_point.Margin = new Padding(8, 3, 6, 3);
            textBox_increase_point.Name = "textBox_increase_point";
            textBox_increase_point.Size = new Size(136, 38);
            textBox_increase_point.TabIndex = 2;
            textBox_increase_point.TabStop = false;
            textBox_increase_point.Text = "0";
            textBox_increase_point.KeyDown += textBox_phone_KeyDown;
            textBox_increase_point.KeyPress += textBox_sale_per_point_KeyPress;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(487, 184);
            label11.Name = "label11";
            label11.Size = new Size(244, 46);
            label11.TabIndex = 1;
            label11.Text = "ราคาขายต่อ 1 แต้ม :";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(487, 138);
            label14.Name = "label14";
            label14.Size = new Size(244, 46);
            label14.TabIndex = 1;
            label14.Text = "สินค้าได้แต้ม :";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label13.ForeColor = Color.Gray;
            label13.Location = new Point(487, 92);
            label13.Name = "label13";
            label13.Size = new Size(244, 46);
            label13.TabIndex = 1;
            label13.Text = "สินค้าไม่ได้แต้ม :";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label12.ForeColor = Color.Gray;
            label12.Location = new Point(487, 46);
            label12.Name = "label12";
            label12.Size = new Size(244, 46);
            label12.TabIndex = 1;
            label12.Text = "รวมมูลค่าขาย :";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(487, 0);
            label10.Name = "label10";
            label10.Size = new Size(244, 46);
            label10.TabIndex = 1;
            label10.Text = "ส่วนลดต่อหน่วย(%) :";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.Dock = DockStyle.Fill;
            label19.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label19.ForeColor = Color.Gray;
            label19.Location = new Point(487, 414);
            label19.Name = "label19";
            label19.Size = new Size(244, 52);
            label19.TabIndex = 1;
            label19.Text = "ลดแต้ม :";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            label18.Dock = DockStyle.Fill;
            label18.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label18.ForeColor = Color.Gray;
            label18.Location = new Point(487, 368);
            label18.Name = "label18";
            label18.Size = new Size(244, 46);
            label18.TabIndex = 1;
            label18.Text = "เพิ่มแต้ม :";
            label18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_phone
            // 
            textBox_phone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_phone.BackColor = Color.FromArgb(192, 255, 192);
            textBox_phone.Enabled = false;
            textBox_phone.Font = new Font("Segoe UI", 13.8F);
            textBox_phone.Location = new Point(153, 4);
            textBox_phone.Name = "textBox_phone";
            textBox_phone.Size = new Size(328, 38);
            textBox_phone.TabIndex = 0;
            textBox_phone.TabStop = false;
            textBox_phone.KeyDown += textBox_phone_KeyDown;
            textBox_phone.KeyPress += textBox_sale_per_point_KeyPress;
            // 
            // label_phone
            // 
            label_phone.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_phone.ForeColor = Color.Gray;
            label_phone.Location = new Point(3, 0);
            label_phone.Name = "label_phone";
            label_phone.Size = new Size(144, 45);
            label_phone.TabIndex = 1;
            label_phone.Text = "เบอร์โทร :";
            label_phone.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(3, 414);
            label8.Name = "label8";
            label8.Size = new Size(144, 45);
            label8.TabIndex = 1;
            label8.Text = "ไปรษณีย์ :";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_postal_code
            // 
            textBox_postal_code.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_postal_code.BackColor = Color.FromArgb(192, 255, 192);
            textBox_postal_code.Enabled = false;
            textBox_postal_code.Font = new Font("Segoe UI", 13.8F);
            textBox_postal_code.Location = new Point(153, 421);
            textBox_postal_code.Name = "textBox_postal_code";
            textBox_postal_code.Size = new Size(328, 38);
            textBox_postal_code.TabIndex = 0;
            textBox_postal_code.TabStop = false;
            textBox_postal_code.KeyDown += textBox_phone_KeyDown;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(3, 368);
            label7.Name = "label7";
            label7.Size = new Size(144, 45);
            label7.TabIndex = 1;
            label7.Text = "จังหวัด :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_province
            // 
            textBox_province.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_province.BackColor = Color.FromArgb(192, 255, 192);
            textBox_province.Enabled = false;
            textBox_province.Font = new Font("Segoe UI", 13.8F);
            textBox_province.Location = new Point(153, 372);
            textBox_province.Name = "textBox_province";
            textBox_province.Size = new Size(328, 38);
            textBox_province.TabIndex = 0;
            textBox_province.TabStop = false;
            textBox_province.KeyDown += textBox_phone_KeyDown;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(3, 322);
            label6.Name = "label6";
            label6.Size = new Size(144, 45);
            label6.TabIndex = 1;
            label6.Text = "อำเภอ :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_district
            // 
            textBox_district.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_district.BackColor = Color.FromArgb(192, 255, 192);
            textBox_district.Enabled = false;
            textBox_district.Font = new Font("Segoe UI", 13.8F);
            textBox_district.Location = new Point(153, 326);
            textBox_district.Name = "textBox_district";
            textBox_district.Size = new Size(328, 38);
            textBox_district.TabIndex = 0;
            textBox_district.TabStop = false;
            textBox_district.KeyDown += textBox_phone_KeyDown;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(3, 276);
            label5.Name = "label5";
            label5.Size = new Size(144, 45);
            label5.TabIndex = 1;
            label5.Text = "ตำบล :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_sub_district
            // 
            textBox_sub_district.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_sub_district.BackColor = Color.FromArgb(192, 255, 192);
            textBox_sub_district.Enabled = false;
            textBox_sub_district.Font = new Font("Segoe UI", 13.8F);
            textBox_sub_district.Location = new Point(153, 280);
            textBox_sub_district.Name = "textBox_sub_district";
            textBox_sub_district.Size = new Size(328, 38);
            textBox_sub_district.TabIndex = 0;
            textBox_sub_district.TabStop = false;
            textBox_sub_district.KeyDown += textBox_phone_KeyDown;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(3, 230);
            label4.Name = "label4";
            label4.Size = new Size(144, 45);
            label4.TabIndex = 1;
            label4.Text = "ที่อยู่ :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_address
            // 
            textBox_address.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_address.BackColor = Color.FromArgb(192, 255, 192);
            textBox_address.Enabled = false;
            textBox_address.Font = new Font("Segoe UI", 13.8F);
            textBox_address.Location = new Point(153, 234);
            textBox_address.Name = "textBox_address";
            textBox_address.Size = new Size(328, 38);
            textBox_address.TabIndex = 0;
            textBox_address.TabStop = false;
            textBox_address.KeyDown += textBox_phone_KeyDown;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(3, 184);
            label2.Name = "label2";
            label2.Size = new Size(144, 45);
            label2.TabIndex = 1;
            label2.Text = "นามสกุล :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_last_name
            // 
            textBox_last_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_last_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_last_name.Enabled = false;
            textBox_last_name.Font = new Font("Segoe UI", 13.8F);
            textBox_last_name.Location = new Point(153, 188);
            textBox_last_name.Name = "textBox_last_name";
            textBox_last_name.Size = new Size(328, 38);
            textBox_last_name.TabIndex = 0;
            textBox_last_name.TabStop = false;
            textBox_last_name.KeyDown += textBox_phone_KeyDown;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(3, 92);
            label3.Name = "label3";
            label3.Size = new Size(144, 45);
            label3.TabIndex = 1;
            label3.Text = "ชื่อเล่น :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_nick_name
            // 
            textBox_nick_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_nick_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_nick_name.Enabled = false;
            textBox_nick_name.Font = new Font("Segoe UI", 13.8F);
            textBox_nick_name.Location = new Point(153, 96);
            textBox_nick_name.Name = "textBox_nick_name";
            textBox_nick_name.Size = new Size(328, 38);
            textBox_nick_name.TabIndex = 0;
            textBox_nick_name.TabStop = false;
            textBox_nick_name.KeyDown += textBox_phone_KeyDown;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(3, 138);
            label1.Name = "label1";
            label1.Size = new Size(144, 45);
            label1.TabIndex = 1;
            label1.Text = "ชื่อจริง :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_first_name
            // 
            textBox_first_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_first_name.BackColor = Color.FromArgb(192, 255, 192);
            textBox_first_name.Enabled = false;
            textBox_first_name.Font = new Font("Segoe UI", 13.8F);
            textBox_first_name.Location = new Point(153, 142);
            textBox_first_name.Name = "textBox_first_name";
            textBox_first_name.Size = new Size(328, 38);
            textBox_first_name.TabIndex = 0;
            textBox_first_name.TabStop = false;
            textBox_first_name.KeyDown += textBox_phone_KeyDown;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(3, 46);
            label9.Name = "label9";
            label9.Size = new Size(144, 45);
            label9.TabIndex = 1;
            label9.Text = "เพศ :";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel_sex
            // 
            panel_sex.Controls.Add(button_sex_female);
            panel_sex.Controls.Add(button_sex_male);
            panel_sex.Dock = DockStyle.Fill;
            panel_sex.Location = new Point(153, 49);
            panel_sex.Name = "panel_sex";
            panel_sex.Size = new Size(328, 40);
            panel_sex.TabIndex = 2;
            // 
            // button_sex_female
            // 
            button_sex_female.Dock = DockStyle.Left;
            button_sex_female.Enabled = false;
            button_sex_female.FlatAppearance.BorderSize = 0;
            button_sex_female.FlatAppearance.MouseDownBackColor = Color.White;
            button_sex_female.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sex_female.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_sex_female.ForeColor = Color.Gray;
            button_sex_female.Location = new Point(99, 0);
            button_sex_female.Margin = new Padding(3, 0, 3, 0);
            button_sex_female.Name = "button_sex_female";
            button_sex_female.Size = new Size(99, 40);
            button_sex_female.TabIndex = 0;
            button_sex_female.TabStop = false;
            button_sex_female.Text = "หญิง";
            button_sex_female.TextAlign = ContentAlignment.MiddleRight;
            button_sex_female.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sex_female.UseVisualStyleBackColor = true;
            button_sex_female.Click += button_sex_Click;
            button_sex_female.MouseEnter += button_MouseEnter;
            button_sex_female.MouseLeave += button_MouseLeave;
            // 
            // button_sex_male
            // 
            button_sex_male.BackColor = Color.Transparent;
            button_sex_male.BackgroundImageLayout = ImageLayout.Zoom;
            button_sex_male.Dock = DockStyle.Left;
            button_sex_male.Enabled = false;
            button_sex_male.FlatAppearance.BorderSize = 0;
            button_sex_male.FlatAppearance.MouseDownBackColor = Color.White;
            button_sex_male.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sex_male.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_sex_male.ForeColor = Color.Gray;
            button_sex_male.Location = new Point(0, 0);
            button_sex_male.Margin = new Padding(3, 0, 3, 0);
            button_sex_male.Name = "button_sex_male";
            button_sex_male.Size = new Size(99, 40);
            button_sex_male.TabIndex = 0;
            button_sex_male.TabStop = false;
            button_sex_male.Text = "ชาย";
            button_sex_male.TextAlign = ContentAlignment.MiddleRight;
            button_sex_male.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_sex_male.UseVisualStyleBackColor = false;
            button_sex_male.Click += button_sex_Click;
            button_sex_male.MouseEnter += button_MouseEnter;
            button_sex_male.MouseLeave += button_MouseLeave;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label17.ForeColor = Color.Gray;
            label17.Location = new Point(487, 276);
            label17.Name = "label17";
            label17.Size = new Size(244, 45);
            label17.TabIndex = 1;
            label17.Text = "แต้มคงเหลือ :";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_point_balance
            // 
            label_point_balance.BackColor = Color.Lime;
            label_point_balance.Font = new Font("Segoe UI", 13.8F);
            label_point_balance.ForeColor = Color.Gray;
            label_point_balance.Location = new Point(740, 276);
            label_point_balance.Margin = new Padding(6, 0, 0, 3);
            label_point_balance.Name = "label_point_balance";
            label_point_balance.Size = new Size(144, 42);
            label_point_balance.TabIndex = 1;
            label_point_balance.Text = "0";
            label_point_balance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer_search_member
            // 
            timer_search_member.Tick += timer_search_member_Tick;
            // 
            // Form_Member_Detail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1534, 872);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Member_Detail";
            Text = "Form_Member_Detail";
            Load += Form_Member_Detail_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_button.ResumeLayout(false);
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).EndInit();
            panel_detail.ResumeLayout(false);
            customGroupBox_detail.ResumeLayout(false);
            customGroupBox_detail.PerformLayout();
            tableLayoutPanel_detail.ResumeLayout(false);
            tableLayoutPanel_detail.PerformLayout();
            panel_sex.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private DataGridView dataGridView_member;
        private Panel panel_detail;
        private Panel panel_search;
        private Label label_search;
        private TextBox textBox_search;
        private TableLayoutPanel tableLayoutPanel_button;
        private Button button_edit_save;
        private Button button_add_save;
        private Button button_cancel;
        private CustomGroupBox customGroupBox_detail;
        private TableLayoutPanel tableLayoutPanel_detail;
        private TextBox textBox_phone;
        private Label label_phone;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox_first_name;
        private TextBox textBox_last_name;
        private TextBox textBox_nick_name;
        private TextBox textBox_address;
        private TextBox textBox_sub_district;
        private TextBox textBox_district;
        private TextBox textBox_province;
        private TextBox textBox_postal_code;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label17;
        private TextBox textBox_discount_percent;
        private TextBox textBox_sale_per_point;
        private Label label_sale_total;
        private Label label_sale_ineffective_member;
        private Label label_sale_effective_member;
        private Label label_point_balance;
        private Label label9;
        private Panel panel_sex;
        private Button button_sex_female;
        private Button button_sex_male;
        private System.Windows.Forms.Timer timer_search_member;
        private Label label18;
        private Label label19;
        private TextBox textBox_increase_point;
        private TextBox textBox_decrease_point;
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
        private DataGridViewImageColumn delete;
    }
}