namespace Ppos
{
    partial class Form_Item_Hotkey
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            timer_search = new System.Windows.Forms.Timer(components);
            panel_detail = new Panel();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
            dataGridView_item = new DataGridView();
            small_barcode = new DataGridViewTextBoxColumn();
            barcode = new DataGridViewTextBoxColumn();
            code = new DataGridViewTextBoxColumn();
            group_main = new DataGridViewTextBoxColumn();
            group_sub = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            unit = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_back_detail = new TableLayoutPanel();
            panel_set = new Panel();
            tableLayoutPanel_set_hotkey = new TableLayoutPanel();
            tableLayoutPanel_hot = new TableLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            comboBox_hot_back_date = new ComboBox();
            comboBox_hot_limit = new ComboBox();
            tableLayoutPanel_sethotkey = new TableLayoutPanel();
            comboBox_button_color = new ComboBox();
            comboBox_font_color = new ComboBox();
            comboBox_image_type = new ComboBox();
            comboBox_font_size = new ComboBox();
            comboBox_row_height = new ComboBox();
            comboBox_column_count = new ComboBox();
            label_button_color = new Label();
            label_font_color = new Label();
            label_image_type = new Label();
            label_font_size = new Label();
            label_row_height = new Label();
            label_column_count = new Label();
            textBox_title = new TextBox();
            label1 = new Label();
            label7 = new Label();
            tableLayoutPanel_last = new TableLayoutPanel();
            comboBox_last_back_date = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboBox_last_limit = new ComboBox();
            label2 = new Label();
            tableLayoutPanel_set = new TableLayoutPanel();
            button_hotkey_1 = new Button();
            button_hotkey_2 = new Button();
            button_hotkey_3 = new Button();
            button_sort = new Button();
            button_delete = new Button();
            backgroundWorker_load = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_sort = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_row_height = new System.ComponentModel.BackgroundWorker();
            timer_title = new System.Windows.Forms.Timer(components);
            panel_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_back_detail.SuspendLayout();
            panel_set.SuspendLayout();
            tableLayoutPanel_set_hotkey.SuspendLayout();
            tableLayoutPanel_hot.SuspendLayout();
            tableLayoutPanel_sethotkey.SuspendLayout();
            tableLayoutPanel_last.SuspendLayout();
            tableLayoutPanel_set.SuspendLayout();
            SuspendLayout();
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // panel_detail
            // 
            panel_detail.AutoScroll = true;
            panel_detail.BackColor = Color.White;
            panel_detail.Dock = DockStyle.Fill;
            panel_detail.Location = new Point(10, 10);
            panel_detail.Margin = new Padding(10, 10, 0, 0);
            panel_detail.Name = "panel_detail";
            panel_detail.Size = new Size(244, 786);
            panel_detail.TabIndex = 4;
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
            label_search.BackColor = Color.Lime;
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
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = Color.Gray;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridView_item.ColumnHeadersHeight = 10;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { small_barcode, barcode, code, group_main, group_sub, name, unit, price });
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.White;
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle16.ForeColor = Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle16.SelectionForeColor = Color.Black;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle16;
            dataGridView_item.Dock = DockStyle.Fill;
            dataGridView_item.GridColor = Color.Lime;
            dataGridView_item.Location = new Point(0, 120);
            dataGridView_item.Margin = new Padding(0);
            dataGridView_item.MultiSelect = false;
            dataGridView_item.Name = "dataGridView_item";
            dataGridView_item.ReadOnly = true;
            dataGridView_item.RowHeadersVisible = false;
            dataGridView_item.RowHeadersWidth = 51;
            dataGridView_item.RowTemplate.Height = 50;
            dataGridView_item.ScrollBars = ScrollBars.None;
            dataGridView_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item.ShowCellToolTips = false;
            dataGridView_item.Size = new Size(400, 796);
            dataGridView_item.TabIndex = 2;
            dataGridView_item.TabStop = false;
            dataGridView_item.CellMouseDown += dataGridView_item_CellMouseDown;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
            dataGridView_item.CellMouseMove += dataGridView_item_CellMouseMove;
            dataGridView_item.CellMouseUp += dataGridView_item_CellMouseUp;
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
            // code
            // 
            code.HeaderText = "code";
            code.MinimumWidth = 6;
            code.Name = "code";
            code.ReadOnly = true;
            code.Visible = false;
            code.Width = 50;
            // 
            // group_main
            // 
            group_main.HeaderText = "group_main";
            group_main.MinimumWidth = 6;
            group_main.Name = "group_main";
            group_main.ReadOnly = true;
            group_main.Visible = false;
            group_main.Width = 125;
            // 
            // group_sub
            // 
            group_sub.HeaderText = "group_sub";
            group_sub.MinimumWidth = 6;
            group_sub.Name = "group_sub";
            group_sub.ReadOnly = true;
            group_sub.Visible = false;
            group_sub.Width = 125;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            name.DefaultCellStyle = dataGridViewCellStyle14;
            name.HeaderText = "";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // unit
            // 
            unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            unit.DefaultCellStyle = dataGridViewCellStyle15;
            unit.HeaderText = "";
            unit.MinimumWidth = 6;
            unit.Name = "unit";
            unit.ReadOnly = true;
            unit.Width = 6;
            // 
            // price
            // 
            price.HeaderText = "price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.ReadOnly = true;
            price.Visible = false;
            price.Width = 125;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Lime;
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(dataGridView_item, 0, 1);
            tableLayoutPanel_back.Controls.Add(panel_search, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_back_detail, 1, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_set, 1, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1054, 916);
            tableLayoutPanel_back.TabIndex = 1;
            // 
            // tableLayoutPanel_back_detail
            // 
            tableLayoutPanel_back_detail.BackColor = Color.Lime;
            tableLayoutPanel_back_detail.ColumnCount = 2;
            tableLayoutPanel_back_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_back_detail.Controls.Add(panel_detail, 0, 0);
            tableLayoutPanel_back_detail.Controls.Add(panel_set, 1, 0);
            tableLayoutPanel_back_detail.Dock = DockStyle.Fill;
            tableLayoutPanel_back_detail.Location = new Point(400, 120);
            tableLayoutPanel_back_detail.Margin = new Padding(0);
            tableLayoutPanel_back_detail.Name = "tableLayoutPanel_back_detail";
            tableLayoutPanel_back_detail.RowCount = 1;
            tableLayoutPanel_back_detail.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_detail.Size = new Size(654, 796);
            tableLayoutPanel_back_detail.TabIndex = 6;
            // 
            // panel_set
            // 
            panel_set.AutoScroll = true;
            panel_set.AutoSize = true;
            panel_set.BackColor = Color.White;
            panel_set.Controls.Add(tableLayoutPanel_set_hotkey);
            panel_set.Dock = DockStyle.Fill;
            panel_set.Location = new Point(254, 10);
            panel_set.Margin = new Padding(0, 10, 0, 0);
            panel_set.Name = "panel_set";
            panel_set.Size = new Size(400, 786);
            panel_set.TabIndex = 5;
            // 
            // tableLayoutPanel_set_hotkey
            // 
            tableLayoutPanel_set_hotkey.Anchor = AnchorStyles.Top;
            tableLayoutPanel_set_hotkey.AutoScroll = true;
            tableLayoutPanel_set_hotkey.ColumnCount = 1;
            tableLayoutPanel_set_hotkey.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_set_hotkey.Controls.Add(tableLayoutPanel_hot, 0, 4);
            tableLayoutPanel_set_hotkey.Controls.Add(tableLayoutPanel_sethotkey, 0, 0);
            tableLayoutPanel_set_hotkey.Controls.Add(label7, 0, 3);
            tableLayoutPanel_set_hotkey.Controls.Add(tableLayoutPanel_last, 0, 2);
            tableLayoutPanel_set_hotkey.Controls.Add(label2, 0, 1);
            tableLayoutPanel_set_hotkey.Location = new Point(10, 3);
            tableLayoutPanel_set_hotkey.Name = "tableLayoutPanel_set_hotkey";
            tableLayoutPanel_set_hotkey.RowCount = 5;
            tableLayoutPanel_set_hotkey.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_set_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_set_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel_set_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_set_hotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel_set_hotkey.Size = new Size(381, 601);
            tableLayoutPanel_set_hotkey.TabIndex = 6;
            // 
            // tableLayoutPanel_hot
            // 
            tableLayoutPanel_hot.ColumnCount = 3;
            tableLayoutPanel_hot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel_hot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_hot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_hot.Controls.Add(label5, 0, 0);
            tableLayoutPanel_hot.Controls.Add(label6, 0, 1);
            tableLayoutPanel_hot.Controls.Add(comboBox_hot_back_date, 1, 0);
            tableLayoutPanel_hot.Controls.Add(comboBox_hot_limit, 1, 1);
            tableLayoutPanel_hot.Dock = DockStyle.Fill;
            tableLayoutPanel_hot.Location = new Point(0, 521);
            tableLayoutPanel_hot.Margin = new Padding(0);
            tableLayoutPanel_hot.Name = "tableLayoutPanel_hot";
            tableLayoutPanel_hot.RowCount = 2;
            tableLayoutPanel_hot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_hot.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_hot.Size = new Size(381, 80);
            tableLayoutPanel_hot.TabIndex = 0;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(196, 40);
            label5.TabIndex = 0;
            label5.Text = "ย้อนหลัง :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.MouseEnter += label_enter;
            label5.MouseLeave += label_leave;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(0, 40);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(196, 40);
            label6.TabIndex = 0;
            label6.Text = "แสดง :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.MouseEnter += label_enter;
            label6.MouseLeave += label_leave;
            // 
            // comboBox_hot_back_date
            // 
            comboBox_hot_back_date.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_hot_back_date.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_hot_back_date.Font = new Font("Segoe UI", 12F);
            comboBox_hot_back_date.FormattingEnabled = true;
            comboBox_hot_back_date.Items.AddRange(new object[] { "1", "2", "3", "7", "15", "30", "60" });
            comboBox_hot_back_date.Location = new Point(196, 2);
            comboBox_hot_back_date.Margin = new Padding(0);
            comboBox_hot_back_date.Name = "comboBox_hot_back_date";
            comboBox_hot_back_date.Size = new Size(100, 36);
            comboBox_hot_back_date.TabIndex = 1;
            comboBox_hot_back_date.TabStop = false;
            comboBox_hot_back_date.SelectedIndexChanged += comboBox_hot_back_date_SelectedIndexChanged;
            // 
            // comboBox_hot_limit
            // 
            comboBox_hot_limit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_hot_limit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_hot_limit.Font = new Font("Segoe UI", 12F);
            comboBox_hot_limit.FormattingEnabled = true;
            comboBox_hot_limit.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            comboBox_hot_limit.Location = new Point(196, 42);
            comboBox_hot_limit.Margin = new Padding(0);
            comboBox_hot_limit.Name = "comboBox_hot_limit";
            comboBox_hot_limit.Size = new Size(100, 36);
            comboBox_hot_limit.TabIndex = 1;
            comboBox_hot_limit.TabStop = false;
            comboBox_hot_limit.SelectedIndexChanged += comboBox_hot_limit_SelectedIndexChanged;
            // 
            // tableLayoutPanel_sethotkey
            // 
            tableLayoutPanel_sethotkey.AutoSize = true;
            tableLayoutPanel_sethotkey.BackColor = Color.White;
            tableLayoutPanel_sethotkey.ColumnCount = 3;
            tableLayoutPanel_sethotkey.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel_sethotkey.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_sethotkey.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_button_color, 1, 6);
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_font_color, 1, 5);
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_image_type, 1, 4);
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_font_size, 1, 3);
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_row_height, 1, 2);
            tableLayoutPanel_sethotkey.Controls.Add(comboBox_column_count, 1, 1);
            tableLayoutPanel_sethotkey.Controls.Add(label_button_color, 0, 6);
            tableLayoutPanel_sethotkey.Controls.Add(label_font_color, 0, 5);
            tableLayoutPanel_sethotkey.Controls.Add(label_image_type, 0, 4);
            tableLayoutPanel_sethotkey.Controls.Add(label_font_size, 0, 3);
            tableLayoutPanel_sethotkey.Controls.Add(label_row_height, 0, 2);
            tableLayoutPanel_sethotkey.Controls.Add(label_column_count, 0, 1);
            tableLayoutPanel_sethotkey.Controls.Add(textBox_title, 1, 0);
            tableLayoutPanel_sethotkey.Controls.Add(label1, 0, 0);
            tableLayoutPanel_sethotkey.Dock = DockStyle.Fill;
            tableLayoutPanel_sethotkey.Location = new Point(10, 10);
            tableLayoutPanel_sethotkey.Margin = new Padding(10, 10, 0, 0);
            tableLayoutPanel_sethotkey.Name = "tableLayoutPanel_sethotkey";
            tableLayoutPanel_sethotkey.RowCount = 7;
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel_sethotkey.Size = new Size(371, 311);
            tableLayoutPanel_sethotkey.TabIndex = 5;
            // 
            // comboBox_button_color
            // 
            comboBox_button_color.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_button_color.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_button_color.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox_button_color.FormattingEnabled = true;
            comboBox_button_color.Location = new Point(189, 272);
            comboBox_button_color.Margin = new Padding(0);
            comboBox_button_color.Name = "comboBox_button_color";
            comboBox_button_color.Size = new Size(100, 36);
            comboBox_button_color.TabIndex = 1;
            comboBox_button_color.TabStop = false;
            comboBox_button_color.SelectedIndexChanged += comboBox_button_color_SelectedIndexChanged;
            // 
            // comboBox_font_color
            // 
            comboBox_font_color.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_font_color.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_font_color.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox_font_color.FormattingEnabled = true;
            comboBox_font_color.Location = new Point(189, 232);
            comboBox_font_color.Margin = new Padding(0);
            comboBox_font_color.Name = "comboBox_font_color";
            comboBox_font_color.Size = new Size(100, 36);
            comboBox_font_color.TabIndex = 1;
            comboBox_font_color.TabStop = false;
            comboBox_font_color.SelectedIndexChanged += comboBox_font_color_SelectedIndexChanged;
            // 
            // comboBox_image_type
            // 
            comboBox_image_type.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_image_type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_image_type.Font = new Font("Segoe UI", 12F);
            comboBox_image_type.FormattingEnabled = true;
            comboBox_image_type.Items.AddRange(new object[] { "บน", "ซ้าย", "กลาง", "ไม่มี" });
            comboBox_image_type.Location = new Point(189, 192);
            comboBox_image_type.Margin = new Padding(0);
            comboBox_image_type.Name = "comboBox_image_type";
            comboBox_image_type.Size = new Size(100, 36);
            comboBox_image_type.TabIndex = 1;
            comboBox_image_type.SelectedIndexChanged += comboBox_image_type_SelectedIndexChanged;
            // 
            // comboBox_font_size
            // 
            comboBox_font_size.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_font_size.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_font_size.Font = new Font("Segoe UI", 12F);
            comboBox_font_size.FormattingEnabled = true;
            comboBox_font_size.Items.AddRange(new object[] { "10", "12", "14", "16", "18", "20", "22", "24", "26" });
            comboBox_font_size.Location = new Point(189, 152);
            comboBox_font_size.Margin = new Padding(0);
            comboBox_font_size.Name = "comboBox_font_size";
            comboBox_font_size.Size = new Size(100, 36);
            comboBox_font_size.TabIndex = 1;
            comboBox_font_size.SelectedIndexChanged += comboBox_font_size_SelectedIndexChanged;
            // 
            // comboBox_row_height
            // 
            comboBox_row_height.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_row_height.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_row_height.Font = new Font("Segoe UI", 12F);
            comboBox_row_height.FormattingEnabled = true;
            comboBox_row_height.Items.AddRange(new object[] { "100", "150", "200", "250", "300" });
            comboBox_row_height.Location = new Point(189, 112);
            comboBox_row_height.Margin = new Padding(0);
            comboBox_row_height.Name = "comboBox_row_height";
            comboBox_row_height.Size = new Size(100, 36);
            comboBox_row_height.TabIndex = 1;
            comboBox_row_height.SelectedIndexChanged += comboBox_row_height_SelectedIndexChanged;
            // 
            // comboBox_column_count
            // 
            comboBox_column_count.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_column_count.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_column_count.Font = new Font("Segoe UI", 12F);
            comboBox_column_count.FormattingEnabled = true;
            comboBox_column_count.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9" });
            comboBox_column_count.Location = new Point(189, 72);
            comboBox_column_count.Margin = new Padding(0);
            comboBox_column_count.Name = "comboBox_column_count";
            comboBox_column_count.Size = new Size(100, 36);
            comboBox_column_count.TabIndex = 1;
            comboBox_column_count.SelectedIndexChanged += comboBox_column_count_SelectedIndexChanged;
            // 
            // label_button_color
            // 
            label_button_color.Dock = DockStyle.Fill;
            label_button_color.Font = new Font("Segoe UI", 12F);
            label_button_color.ForeColor = Color.Black;
            label_button_color.Location = new Point(0, 270);
            label_button_color.Margin = new Padding(0);
            label_button_color.Name = "label_button_color";
            label_button_color.Size = new Size(189, 41);
            label_button_color.TabIndex = 0;
            label_button_color.Text = "สีคีย์ลัด :";
            label_button_color.TextAlign = ContentAlignment.MiddleRight;
            label_button_color.MouseEnter += label_enter;
            label_button_color.MouseLeave += label_leave;
            // 
            // label_font_color
            // 
            label_font_color.Dock = DockStyle.Fill;
            label_font_color.Font = new Font("Segoe UI", 12F);
            label_font_color.ForeColor = Color.Black;
            label_font_color.Location = new Point(0, 230);
            label_font_color.Margin = new Padding(0);
            label_font_color.Name = "label_font_color";
            label_font_color.Size = new Size(189, 40);
            label_font_color.TabIndex = 0;
            label_font_color.Text = "สีตัวอักษร :";
            label_font_color.TextAlign = ContentAlignment.MiddleRight;
            label_font_color.MouseEnter += label_enter;
            label_font_color.MouseLeave += label_leave;
            // 
            // label_image_type
            // 
            label_image_type.Dock = DockStyle.Fill;
            label_image_type.Font = new Font("Segoe UI", 12F);
            label_image_type.ForeColor = Color.Black;
            label_image_type.Location = new Point(0, 190);
            label_image_type.Margin = new Padding(0);
            label_image_type.Name = "label_image_type";
            label_image_type.Size = new Size(189, 40);
            label_image_type.TabIndex = 0;
            label_image_type.Text = "ตำแหน่งภาพ :";
            label_image_type.TextAlign = ContentAlignment.MiddleRight;
            label_image_type.MouseEnter += label_enter;
            label_image_type.MouseLeave += label_leave;
            // 
            // label_font_size
            // 
            label_font_size.Dock = DockStyle.Fill;
            label_font_size.Font = new Font("Segoe UI", 12F);
            label_font_size.ForeColor = Color.Black;
            label_font_size.Location = new Point(0, 150);
            label_font_size.Margin = new Padding(0);
            label_font_size.Name = "label_font_size";
            label_font_size.Size = new Size(189, 40);
            label_font_size.TabIndex = 0;
            label_font_size.Text = "ขนาดอักษร :";
            label_font_size.TextAlign = ContentAlignment.MiddleRight;
            label_font_size.MouseEnter += label_enter;
            label_font_size.MouseLeave += label_leave;
            // 
            // label_row_height
            // 
            label_row_height.Dock = DockStyle.Fill;
            label_row_height.Font = new Font("Segoe UI", 12F);
            label_row_height.ForeColor = Color.Black;
            label_row_height.Location = new Point(0, 110);
            label_row_height.Margin = new Padding(0);
            label_row_height.Name = "label_row_height";
            label_row_height.Size = new Size(189, 40);
            label_row_height.TabIndex = 0;
            label_row_height.Text = "ความสูง :";
            label_row_height.TextAlign = ContentAlignment.MiddleRight;
            label_row_height.MouseEnter += label_enter;
            label_row_height.MouseLeave += label_leave;
            // 
            // label_column_count
            // 
            label_column_count.Dock = DockStyle.Fill;
            label_column_count.Font = new Font("Segoe UI", 12F);
            label_column_count.ForeColor = Color.Black;
            label_column_count.Location = new Point(0, 70);
            label_column_count.Margin = new Padding(0);
            label_column_count.Name = "label_column_count";
            label_column_count.Size = new Size(189, 40);
            label_column_count.TabIndex = 0;
            label_column_count.Text = "คีย์ลัดหนึ่งแถว :";
            label_column_count.TextAlign = ContentAlignment.MiddleRight;
            label_column_count.MouseEnter += label_enter;
            label_column_count.MouseLeave += label_leave;
            // 
            // textBox_title
            // 
            textBox_title.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_title.BackColor = Color.White;
            textBox_title.BorderStyle = BorderStyle.None;
            textBox_title.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_title.Location = new Point(189, 19);
            textBox_title.Margin = new Padding(0);
            textBox_title.Name = "textBox_title";
            textBox_title.Size = new Size(100, 31);
            textBox_title.TabIndex = 1;
            textBox_title.TextChanged += textBox_title_TextChanged;
            textBox_title.KeyPress += textBox_title_KeyPress;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(189, 70);
            label1.TabIndex = 0;
            label1.Text = "ชื่อคีย์ลัด :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(0, 461);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(381, 60);
            label7.TabIndex = 0;
            label7.Text = "ขายดี";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.MouseEnter += label_enter;
            label7.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_last
            // 
            tableLayoutPanel_last.ColumnCount = 3;
            tableLayoutPanel_last.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel_last.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_last.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_last.Controls.Add(comboBox_last_back_date, 1, 0);
            tableLayoutPanel_last.Controls.Add(label3, 0, 0);
            tableLayoutPanel_last.Controls.Add(label4, 0, 1);
            tableLayoutPanel_last.Controls.Add(comboBox_last_limit, 1, 1);
            tableLayoutPanel_last.Dock = DockStyle.Fill;
            tableLayoutPanel_last.Location = new Point(0, 381);
            tableLayoutPanel_last.Margin = new Padding(0);
            tableLayoutPanel_last.Name = "tableLayoutPanel_last";
            tableLayoutPanel_last.RowCount = 2;
            tableLayoutPanel_last.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_last.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_last.Size = new Size(381, 80);
            tableLayoutPanel_last.TabIndex = 0;
            // 
            // comboBox_last_back_date
            // 
            comboBox_last_back_date.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_last_back_date.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_last_back_date.Font = new Font("Segoe UI", 12F);
            comboBox_last_back_date.FormattingEnabled = true;
            comboBox_last_back_date.Items.AddRange(new object[] { "1", "2", "3", "7", "15", "30", "60" });
            comboBox_last_back_date.Location = new Point(196, 2);
            comboBox_last_back_date.Margin = new Padding(0);
            comboBox_last_back_date.Name = "comboBox_last_back_date";
            comboBox_last_back_date.Size = new Size(100, 36);
            comboBox_last_back_date.TabIndex = 1;
            comboBox_last_back_date.TabStop = false;
            comboBox_last_back_date.SelectedIndexChanged += comboBox_last_back_date_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(196, 40);
            label3.TabIndex = 0;
            label3.Text = "ย้อนหลัง :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.MouseEnter += label_enter;
            label3.MouseLeave += label_leave;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 40);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(196, 40);
            label4.TabIndex = 0;
            label4.Text = "แสดง :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.MouseEnter += label_enter;
            label4.MouseLeave += label_leave;
            // 
            // comboBox_last_limit
            // 
            comboBox_last_limit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBox_last_limit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_last_limit.Font = new Font("Segoe UI", 12F);
            comboBox_last_limit.FormattingEnabled = true;
            comboBox_last_limit.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            comboBox_last_limit.Location = new Point(196, 42);
            comboBox_last_limit.Margin = new Padding(0);
            comboBox_last_limit.Name = "comboBox_last_limit";
            comboBox_last_limit.Size = new Size(100, 36);
            comboBox_last_limit.TabIndex = 1;
            comboBox_last_limit.TabStop = false;
            comboBox_last_limit.SelectedIndexChanged += comboBox_last_limit_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 321);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(381, 60);
            label2.TabIndex = 0;
            label2.Text = "ล่าสุด";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.MouseEnter += label_enter;
            label2.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_set
            // 
            tableLayoutPanel_set.BackColor = Color.White;
            tableLayoutPanel_set.ColumnCount = 7;
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_set.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_set.Controls.Add(button_hotkey_1, 0, 0);
            tableLayoutPanel_set.Controls.Add(button_hotkey_2, 1, 0);
            tableLayoutPanel_set.Controls.Add(button_hotkey_3, 2, 0);
            tableLayoutPanel_set.Controls.Add(button_sort, 3, 0);
            tableLayoutPanel_set.Controls.Add(button_delete, 4, 0);
            tableLayoutPanel_set.Dock = DockStyle.Fill;
            tableLayoutPanel_set.Location = new Point(410, 0);
            tableLayoutPanel_set.Margin = new Padding(10, 0, 0, 0);
            tableLayoutPanel_set.Name = "tableLayoutPanel_set";
            tableLayoutPanel_set.RowCount = 1;
            tableLayoutPanel_set.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_set.Size = new Size(644, 120);
            tableLayoutPanel_set.TabIndex = 7;
            // 
            // button_hotkey_1
            // 
            button_hotkey_1.BackColor = Color.White;
            button_hotkey_1.Dock = DockStyle.Fill;
            button_hotkey_1.FlatAppearance.BorderSize = 0;
            button_hotkey_1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_1.FlatStyle = FlatStyle.Flat;
            button_hotkey_1.Font = new Font("Segoe UI", 12F);
            button_hotkey_1.ForeColor = Color.Gray;
            button_hotkey_1.Location = new Point(3, 3);
            button_hotkey_1.Name = "button_hotkey_1";
            button_hotkey_1.Size = new Size(82, 114);
            button_hotkey_1.TabIndex = 4;
            button_hotkey_1.Text = "-";
            button_hotkey_1.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_1.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_1.UseVisualStyleBackColor = false;
            button_hotkey_1.Click += hotkey_click;
            button_hotkey_1.MouseEnter += hotkey_enter;
            button_hotkey_1.MouseLeave += hotkey_leave;
            // 
            // button_hotkey_2
            // 
            button_hotkey_2.BackColor = Color.White;
            button_hotkey_2.Dock = DockStyle.Fill;
            button_hotkey_2.FlatAppearance.BorderSize = 0;
            button_hotkey_2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_2.FlatStyle = FlatStyle.Flat;
            button_hotkey_2.Font = new Font("Segoe UI", 12F);
            button_hotkey_2.ForeColor = Color.Gray;
            button_hotkey_2.Location = new Point(91, 3);
            button_hotkey_2.Name = "button_hotkey_2";
            button_hotkey_2.Size = new Size(82, 114);
            button_hotkey_2.TabIndex = 4;
            button_hotkey_2.Text = "-";
            button_hotkey_2.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_2.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_2.UseVisualStyleBackColor = false;
            button_hotkey_2.Click += hotkey_click;
            button_hotkey_2.MouseEnter += hotkey_enter;
            button_hotkey_2.MouseLeave += hotkey_leave;
            // 
            // button_hotkey_3
            // 
            button_hotkey_3.Dock = DockStyle.Fill;
            button_hotkey_3.FlatAppearance.BorderSize = 0;
            button_hotkey_3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_hotkey_3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_hotkey_3.FlatStyle = FlatStyle.Flat;
            button_hotkey_3.Font = new Font("Segoe UI", 12F);
            button_hotkey_3.ForeColor = Color.Gray;
            button_hotkey_3.Location = new Point(179, 3);
            button_hotkey_3.Name = "button_hotkey_3";
            button_hotkey_3.Size = new Size(82, 114);
            button_hotkey_3.TabIndex = 4;
            button_hotkey_3.Text = "-";
            button_hotkey_3.TextAlign = ContentAlignment.BottomCenter;
            button_hotkey_3.TextImageRelation = TextImageRelation.ImageAboveText;
            button_hotkey_3.UseVisualStyleBackColor = true;
            button_hotkey_3.Click += hotkey_click;
            button_hotkey_3.MouseEnter += hotkey_enter;
            button_hotkey_3.MouseLeave += hotkey_leave;
            // 
            // button_sort
            // 
            button_sort.BackColor = Color.White;
            button_sort.Dock = DockStyle.Fill;
            button_sort.FlatAppearance.BorderSize = 0;
            button_sort.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_sort.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_sort.FlatStyle = FlatStyle.Flat;
            button_sort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_sort.Location = new Point(264, 0);
            button_sort.Margin = new Padding(0);
            button_sort.Name = "button_sort";
            button_sort.Size = new Size(88, 120);
            button_sort.TabIndex = 2;
            button_sort.Text = "( 0 )";
            button_sort.TextAlign = ContentAlignment.BottomCenter;
            button_sort.TextImageRelation = TextImageRelation.ImageAboveText;
            button_sort.UseVisualStyleBackColor = false;
            button_sort.Click += button_sort_Click;
            button_sort.MouseEnter += hotkey_enter;
            button_sort.MouseLeave += hotkey_leave;
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.White;
            button_delete.Dock = DockStyle.Fill;
            button_delete.FlatAppearance.BorderSize = 0;
            button_delete.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_delete.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_delete.Location = new Point(352, 0);
            button_delete.Margin = new Padding(0);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(88, 120);
            button_delete.TabIndex = 3;
            button_delete.Text = "ลบ";
            button_delete.TextAlign = ContentAlignment.BottomCenter;
            button_delete.TextImageRelation = TextImageRelation.ImageAboveText;
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            button_delete.MouseEnter += hotkey_enter;
            button_delete.MouseLeave += hotkey_leave;
            // 
            // backgroundWorker_load
            // 
            backgroundWorker_load.DoWork += backgroundWorker_load_DoWork;
            backgroundWorker_load.RunWorkerCompleted += backgroundWorker_load_RunWorkerCompleted;
            // 
            // backgroundWorker_sort
            // 
            backgroundWorker_sort.DoWork += backgroundWorker_sort_DoWork;
            backgroundWorker_sort.RunWorkerCompleted += backgroundWorker_sort_RunWorkerCompleted;
            // 
            // backgroundWorker_row_height
            // 
            backgroundWorker_row_height.DoWork += backgroundWorker_row_height_DoWork;
            backgroundWorker_row_height.RunWorkerCompleted += backgroundWorker_row_height_RunWorkerCompleted;
            // 
            // timer_title
            // 
            timer_title.Tick += timer_title_Tick;
            // 
            // Form_Item_Hotkey
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1054, 916);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Item_Hotkey";
            Text = "Form_Item_Hotkey";
            Shown += Form_Item_Hotkey_Shown;
            Resize += Form_Item_Hotkey_Resize;
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back_detail.ResumeLayout(false);
            tableLayoutPanel_back_detail.PerformLayout();
            panel_set.ResumeLayout(false);
            tableLayoutPanel_set_hotkey.ResumeLayout(false);
            tableLayoutPanel_set_hotkey.PerformLayout();
            tableLayoutPanel_hot.ResumeLayout(false);
            tableLayoutPanel_sethotkey.ResumeLayout(false);
            tableLayoutPanel_sethotkey.PerformLayout();
            tableLayoutPanel_last.ResumeLayout(false);
            tableLayoutPanel_set.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer_search;
        private Panel panel_detail;
        private Panel panel_search;
        private Label label_search;
        private TextBox textBox_search;
        private DataGridView dataGridView_item;
        private TableLayoutPanel tableLayoutPanel_back;
        private Label label_column_count;
        private ComboBox comboBox_row_height;
        private ComboBox comboBox_column_count;
        private Label label_row_height;
        private Label label_font_size;
        private ComboBox comboBox_font_size;
        private ComboBox comboBox_image_type;
        private Button button_sort;
        private Button button_delete;
        private ComboBox comboBox_button_color;
        private ComboBox comboBox_font_color;
        private Label label_font_color;
        private Label label_image_type;
        private Label label_button_color;
        private System.ComponentModel.BackgroundWorker backgroundWorker_load;
        private System.ComponentModel.BackgroundWorker backgroundWorker_sort;
        private System.ComponentModel.BackgroundWorker backgroundWorker_row_height;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn barcode;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn group_main;
        private DataGridViewTextBoxColumn group_sub;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn unit;
        private DataGridViewTextBoxColumn price;
        private TableLayoutPanel tableLayoutPanel_back_detail;
        private TableLayoutPanel tableLayoutPanel_sethotkey;
        private TableLayoutPanel tableLayoutPanel_set;
        private Button button_hotkey_1;
        private Button button_hotkey_2;
        private Button button_hotkey_3;
        private TextBox textBox_title;
        private Label label1;
        private Panel panel_set;
        private TableLayoutPanel tableLayoutPanel_set_hotkey;
        private TableLayoutPanel tableLayoutPanel_last;
        private ComboBox comboBox_last_back_date;
        private Label label3;
        private Label label4;
        private ComboBox comboBox_last_limit;
        private TableLayoutPanel tableLayoutPanel_hot;
        private Label label5;
        private Label label6;
        private ComboBox comboBox_hot_back_date;
        private ComboBox comboBox_hot_limit;
        private Label label2;
        private Label label7;
        private System.Windows.Forms.Timer timer_title;
    }
}