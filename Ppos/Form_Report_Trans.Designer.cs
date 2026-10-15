namespace Ppos
{
    partial class Form_Report_Trans
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            dataGridView_item = new DataGridView();
            small_barcode = new DataGridViewTextBoxColumn();
            code = new DataGridViewTextBoxColumn();
            group_main = new DataGridViewTextBoxColumn();
            group_sub = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            panel_search = new Panel();
            label_search = new Label();
            textBox_search = new TextBox();
            dataGridView_trans = new DataGridView();
            trans_date = new DataGridViewTextBoxColumn();
            trans_time = new DataGridViewTextBoxColumn();
            trnas_type = new DataGridViewTextBoxColumn();
            trans_desc = new DataGridViewTextBoxColumn();
            item_barcode = new DataGridViewTextBoxColumn();
            item_qty = new DataGridViewTextBoxColumn();
            item_unit = new DataGridViewTextBoxColumn();
            item_cost = new DataGridViewTextBoxColumn();
            small_qty_begin = new DataGridViewTextBoxColumn();
            small_qty = new DataGridViewTextBoxColumn();
            small_qty_end = new DataGridViewTextBoxColumn();
            small_unit = new DataGridViewTextBoxColumn();
            small_cost_begin = new DataGridViewTextBoxColumn();
            small_cost = new DataGridViewTextBoxColumn();
            small_cost_end = new DataGridViewTextBoxColumn();
            small_cost_total = new DataGridViewTextBoxColumn();
            fill = new DataGridViewTextBoxColumn();
            tableLayoutPanel_top = new TableLayoutPanel();
            button_excel = new Button();
            panel_item_detail = new Panel();
            textBox_item_name = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox_item_group_sub = new TextBox();
            textBox1 = new TextBox();
            textBox_item_group_main = new TextBox();
            pictureBox_item = new PictureBox();
            button_sort = new Button();
            timer_search = new System.Windows.Forms.Timer(components);
            backgroundWorker_excel = new System.ComponentModel.BackgroundWorker();
            backgroundWorker_report = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).BeginInit();
            panel_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_trans).BeginInit();
            tableLayoutPanel_top.SuspendLayout();
            panel_item_detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Lime;
            tableLayoutPanel_back.ColumnCount = 2;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(dataGridView_item, 0, 1);
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
            tableLayoutPanel_back.Size = new Size(1186, 574);
            tableLayoutPanel_back.TabIndex = 0;
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
            dataGridViewCellStyle1.BackColor = Color.Gray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item.ColumnHeadersHeight = 40;
            dataGridView_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item.Columns.AddRange(new DataGridViewColumn[] { small_barcode, code, group_main, group_sub, name });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView_item.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridView_item.Size = new Size(400, 454);
            dataGridView_item.TabIndex = 2;
            dataGridView_item.TabStop = false;
            dataGridView_item.CellClick += dataGridView_item_CellClick;
            dataGridView_item.CellMouseEnter += dataGridView_item_CellMouseEnter;
            dataGridView_item.CellMouseLeave += dataGridView_item_CellMouseLeave;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            name.DefaultCellStyle = dataGridViewCellStyle2;
            name.HeaderText = "";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.Gray;
            dataGridViewCellStyle4.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle4.SelectionForeColor = Color.Gray;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView_trans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView_trans.ColumnHeadersHeight = 40;
            dataGridView_trans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_trans.Columns.AddRange(new DataGridViewColumn[] { trans_date, trans_time, trnas_type, trans_desc, item_barcode, item_qty, item_unit, item_cost, small_qty_begin, small_qty, small_qty_end, small_unit, small_cost_begin, small_cost, small_cost_end, small_cost_total, fill });
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = SystemColors.Window;
            dataGridViewCellStyle21.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle21.ForeColor = Color.DimGray;
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle21.SelectionForeColor = Color.Black;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.False;
            dataGridView_trans.DefaultCellStyle = dataGridViewCellStyle21;
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
            dataGridView_trans.Size = new Size(776, 454);
            dataGridView_trans.TabIndex = 4;
            dataGridView_trans.CellMouseEnter += dataGridView_trans_CellMouseEnter;
            dataGridView_trans.CellMouseLeave += dataGridView_trans_CellMouseLeave;
            // 
            // trans_date
            // 
            trans_date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            trans_date.DefaultCellStyle = dataGridViewCellStyle5;
            trans_date.HeaderText = "";
            trans_date.MinimumWidth = 6;
            trans_date.Name = "trans_date";
            trans_date.ReadOnly = true;
            trans_date.Width = 23;
            // 
            // trans_time
            // 
            trans_time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            trans_time.DefaultCellStyle = dataGridViewCellStyle6;
            trans_time.HeaderText = "";
            trans_time.MinimumWidth = 6;
            trans_time.Name = "trans_time";
            trans_time.ReadOnly = true;
            trans_time.Width = 23;
            // 
            // trnas_type
            // 
            trnas_type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            trnas_type.DefaultCellStyle = dataGridViewCellStyle7;
            trnas_type.HeaderText = "";
            trnas_type.MinimumWidth = 6;
            trnas_type.Name = "trnas_type";
            trnas_type.ReadOnly = true;
            trnas_type.Width = 23;
            // 
            // trans_desc
            // 
            trans_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            trans_desc.DefaultCellStyle = dataGridViewCellStyle8;
            trans_desc.HeaderText = "";
            trans_desc.MinimumWidth = 6;
            trans_desc.Name = "trans_desc";
            trans_desc.ReadOnly = true;
            trans_desc.Width = 23;
            // 
            // item_barcode
            // 
            item_barcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            item_barcode.DefaultCellStyle = dataGridViewCellStyle9;
            item_barcode.HeaderText = "";
            item_barcode.MinimumWidth = 6;
            item_barcode.Name = "item_barcode";
            item_barcode.ReadOnly = true;
            item_barcode.Width = 23;
            // 
            // item_qty
            // 
            item_qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            item_qty.DefaultCellStyle = dataGridViewCellStyle10;
            item_qty.HeaderText = "";
            item_qty.MinimumWidth = 6;
            item_qty.Name = "item_qty";
            item_qty.ReadOnly = true;
            item_qty.Width = 23;
            // 
            // item_unit
            // 
            item_unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            item_unit.DefaultCellStyle = dataGridViewCellStyle11;
            item_unit.HeaderText = "";
            item_unit.MinimumWidth = 6;
            item_unit.Name = "item_unit";
            item_unit.ReadOnly = true;
            item_unit.Width = 23;
            // 
            // item_cost
            // 
            item_cost.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            item_cost.DefaultCellStyle = dataGridViewCellStyle12;
            item_cost.HeaderText = "";
            item_cost.MinimumWidth = 6;
            item_cost.Name = "item_cost";
            item_cost.ReadOnly = true;
            item_cost.Width = 23;
            // 
            // small_qty_begin
            // 
            small_qty_begin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_qty_begin.DefaultCellStyle = dataGridViewCellStyle13;
            small_qty_begin.HeaderText = "";
            small_qty_begin.MinimumWidth = 6;
            small_qty_begin.Name = "small_qty_begin";
            small_qty_begin.ReadOnly = true;
            small_qty_begin.Width = 23;
            // 
            // small_qty
            // 
            small_qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_qty.DefaultCellStyle = dataGridViewCellStyle14;
            small_qty.HeaderText = "";
            small_qty.MinimumWidth = 6;
            small_qty.Name = "small_qty";
            small_qty.ReadOnly = true;
            small_qty.Width = 23;
            // 
            // small_qty_end
            // 
            small_qty_end.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_qty_end.DefaultCellStyle = dataGridViewCellStyle15;
            small_qty_end.HeaderText = "";
            small_qty_end.MinimumWidth = 6;
            small_qty_end.Name = "small_qty_end";
            small_qty_end.ReadOnly = true;
            small_qty_end.Width = 23;
            // 
            // small_unit
            // 
            small_unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            small_unit.DefaultCellStyle = dataGridViewCellStyle16;
            small_unit.HeaderText = "";
            small_unit.MinimumWidth = 6;
            small_unit.Name = "small_unit";
            small_unit.ReadOnly = true;
            small_unit.Width = 23;
            // 
            // small_cost_begin
            // 
            small_cost_begin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_cost_begin.DefaultCellStyle = dataGridViewCellStyle17;
            small_cost_begin.HeaderText = "";
            small_cost_begin.MinimumWidth = 6;
            small_cost_begin.Name = "small_cost_begin";
            small_cost_begin.ReadOnly = true;
            small_cost_begin.Width = 23;
            // 
            // small_cost
            // 
            small_cost.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_cost.DefaultCellStyle = dataGridViewCellStyle18;
            small_cost.HeaderText = "";
            small_cost.MinimumWidth = 6;
            small_cost.Name = "small_cost";
            small_cost.ReadOnly = true;
            small_cost.Width = 23;
            // 
            // small_cost_end
            // 
            small_cost_end.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleRight;
            small_cost_end.DefaultCellStyle = dataGridViewCellStyle19;
            small_cost_end.HeaderText = "";
            small_cost_end.MinimumWidth = 6;
            small_cost_end.Name = "small_cost_end";
            small_cost_end.ReadOnly = true;
            small_cost_end.Width = 23;
            // 
            // small_cost_total
            // 
            small_cost_total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.True;
            small_cost_total.DefaultCellStyle = dataGridViewCellStyle20;
            small_cost_total.HeaderText = "";
            small_cost_total.MinimumWidth = 6;
            small_cost_total.Name = "small_cost_total";
            small_cost_total.ReadOnly = true;
            small_cost_total.Width = 23;
            // 
            // fill
            // 
            fill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fill.HeaderText = "";
            fill.MinimumWidth = 6;
            fill.Name = "fill";
            fill.ReadOnly = true;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 3;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_top.Controls.Add(button_excel, 2, 0);
            tableLayoutPanel_top.Controls.Add(panel_item_detail, 1, 0);
            tableLayoutPanel_top.Controls.Add(button_sort, 0, 0);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(410, 0);
            tableLayoutPanel_top.Margin = new Padding(10, 0, 0, 0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 1;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.Size = new Size(776, 120);
            tableLayoutPanel_top.TabIndex = 5;
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
            button_excel.Location = new Point(629, 3);
            button_excel.Name = "button_excel";
            button_excel.Size = new Size(144, 114);
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
            // panel_item_detail
            // 
            panel_item_detail.BackColor = Color.Transparent;
            panel_item_detail.Controls.Add(textBox_item_name);
            panel_item_detail.Controls.Add(textBox3);
            panel_item_detail.Controls.Add(textBox2);
            panel_item_detail.Controls.Add(textBox_item_group_sub);
            panel_item_detail.Controls.Add(textBox1);
            panel_item_detail.Controls.Add(textBox_item_group_main);
            panel_item_detail.Controls.Add(pictureBox_item);
            panel_item_detail.Dock = DockStyle.Fill;
            panel_item_detail.Location = new Point(50, 0);
            panel_item_detail.Margin = new Padding(0);
            panel_item_detail.Name = "panel_item_detail";
            panel_item_detail.Size = new Size(576, 120);
            panel_item_detail.TabIndex = 1;
            // 
            // textBox_item_name
            // 
            textBox_item_name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_name.BackColor = Color.White;
            textBox_item_name.BorderStyle = BorderStyle.None;
            textBox_item_name.Enabled = false;
            textBox_item_name.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_name.ForeColor = Color.Black;
            textBox_item_name.Location = new Point(371, 82);
            textBox_item_name.Name = "textBox_item_name";
            textBox_item_name.Size = new Size(202, 31);
            textBox_item_name.TabIndex = 1;
            textBox_item_name.Text = "-";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Left;
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox3.ForeColor = Color.DimGray;
            textBox3.Location = new Point(256, 82);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(109, 31);
            textBox3.TabIndex = 1;
            textBox3.Text = "ชื่อสินค้า :";
            textBox3.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left;
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox2.ForeColor = Color.DimGray;
            textBox2.Location = new Point(256, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(109, 31);
            textBox2.TabIndex = 1;
            textBox2.Text = "กลุ่มย่อย :";
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox_item_group_sub
            // 
            textBox_item_group_sub.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_group_sub.BackColor = Color.White;
            textBox_item_group_sub.BorderStyle = BorderStyle.None;
            textBox_item_group_sub.Enabled = false;
            textBox_item_group_sub.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_group_sub.ForeColor = Color.Black;
            textBox_item_group_sub.Location = new Point(371, 45);
            textBox_item_group_sub.Name = "textBox_item_group_sub";
            textBox_item_group_sub.Size = new Size(202, 31);
            textBox_item_group_sub.TabIndex = 1;
            textBox_item_group_sub.Text = "-";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(256, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(109, 31);
            textBox1.TabIndex = 1;
            textBox1.Text = "กลุ่มหลัก :";
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox_item_group_main
            // 
            textBox_item_group_main.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_item_group_main.BackColor = Color.White;
            textBox_item_group_main.BorderStyle = BorderStyle.None;
            textBox_item_group_main.Enabled = false;
            textBox_item_group_main.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            textBox_item_group_main.ForeColor = Color.Black;
            textBox_item_group_main.Location = new Point(371, 8);
            textBox_item_group_main.Name = "textBox_item_group_main";
            textBox_item_group_main.Size = new Size(202, 31);
            textBox_item_group_main.TabIndex = 1;
            textBox_item_group_main.Text = "-";
            // 
            // pictureBox_item
            // 
            pictureBox_item.Dock = DockStyle.Left;
            pictureBox_item.Location = new Point(0, 0);
            pictureBox_item.Name = "pictureBox_item";
            pictureBox_item.Size = new Size(250, 120);
            pictureBox_item.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_item.TabIndex = 0;
            pictureBox_item.TabStop = false;
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
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // backgroundWorker_excel
            // 
            backgroundWorker_excel.DoWork += backgroundWorker_excel_DoWork;
            backgroundWorker_excel.RunWorkerCompleted += backgroundWorker_excel_RunWorkerCompleted;
            // 
            // backgroundWorker_report
            // 
            backgroundWorker_report.DoWork += backgroundWorker_report_DoWork;
            backgroundWorker_report.RunWorkerCompleted += backgroundWorker_report_RunWorkerCompleted;
            // 
            // Form_Report_Trans
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(1186, 574);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Report_Trans";
            Text = "Form_Report_Trans";
            Load += Form_Report_Trans_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_item).EndInit();
            panel_search.ResumeLayout(false);
            panel_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_trans).EndInit();
            tableLayoutPanel_top.ResumeLayout(false);
            panel_item_detail.ResumeLayout(false);
            panel_item_detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_item).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private DataGridView dataGridView_item;
        private Panel panel_search;
        private Label label_search;
        private TextBox textBox_search;
        private System.Windows.Forms.Timer timer_search;
        private DataGridView dataGridView_trans;
        private TableLayoutPanel tableLayoutPanel_top;
        private Button button_excel;
        private Panel panel_item_detail;
        private TextBox textBox_item_group_main;
        private PictureBox pictureBox_item;
        private TextBox textBox_item_group_sub;
        private TextBox textBox_item_name;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn small_barcode;
        private DataGridViewTextBoxColumn code;
        private DataGridViewTextBoxColumn group_main;
        private DataGridViewTextBoxColumn group_sub;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn trans_date;
        private DataGridViewTextBoxColumn trans_time;
        private DataGridViewTextBoxColumn trnas_type;
        private DataGridViewTextBoxColumn trans_desc;
        private DataGridViewTextBoxColumn item_barcode;
        private DataGridViewTextBoxColumn item_qty;
        private DataGridViewTextBoxColumn item_unit;
        private DataGridViewTextBoxColumn item_cost;
        private DataGridViewTextBoxColumn small_qty_begin;
        private DataGridViewTextBoxColumn small_qty;
        private DataGridViewTextBoxColumn small_qty_end;
        private DataGridViewTextBoxColumn small_unit;
        private DataGridViewTextBoxColumn small_cost_begin;
        private DataGridViewTextBoxColumn small_cost;
        private DataGridViewTextBoxColumn small_cost_end;
        private DataGridViewTextBoxColumn small_cost_total;
        private DataGridViewTextBoxColumn fill;
        private System.ComponentModel.BackgroundWorker backgroundWorker_excel;
        private Button button_sort;
        private System.ComponentModel.BackgroundWorker backgroundWorker_report;
    }
}