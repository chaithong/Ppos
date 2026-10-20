namespace Ppos
{
    partial class Form_Promotion_Detail
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Promotion_Detail));
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            label_name = new Label();
            label_criterion = new Label();
            label_offer = new Label();
            label_repeat = new Label();
            label_date = new Label();
            label_time = new Label();
            label_day = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            tableLayoutPanel_bottom = new TableLayoutPanel();
            dataGridView_item_premium = new DataGridView();
            seq_premium = new DataGridViewTextBoxColumn();
            item_name_premium = new DataGridViewTextBoxColumn();
            item_qty_premium = new DataGridViewTextBoxColumn();
            item_unit_premium = new DataGridViewTextBoxColumn();
            dataGridView_item_pro = new DataGridView();
            seq_pro = new DataGridViewTextBoxColumn();
            item_name_pro = new DataGridViewTextBoxColumn();
            item_qty_pro = new DataGridViewTextBoxColumn();
            item_unit_pro = new DataGridViewTextBoxColumn();
            label_item_pro = new Label();
            label_item_premium = new Label();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            tableLayoutPanel_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item_premium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item_pro).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_bottom, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(800, 586);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.ColumnCount = 2;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(label_name, 1, 0);
            tableLayoutPanel_top.Controls.Add(label_criterion, 1, 1);
            tableLayoutPanel_top.Controls.Add(label_offer, 1, 2);
            tableLayoutPanel_top.Controls.Add(label_repeat, 1, 3);
            tableLayoutPanel_top.Controls.Add(label_date, 1, 4);
            tableLayoutPanel_top.Controls.Add(label_time, 1, 5);
            tableLayoutPanel_top.Controls.Add(label_day, 1, 6);
            tableLayoutPanel_top.Controls.Add(label1, 0, 0);
            tableLayoutPanel_top.Controls.Add(label2, 0, 1);
            tableLayoutPanel_top.Controls.Add(label3, 0, 2);
            tableLayoutPanel_top.Controls.Add(label4, 0, 3);
            tableLayoutPanel_top.Controls.Add(label5, 0, 4);
            tableLayoutPanel_top.Controls.Add(label7, 0, 6);
            tableLayoutPanel_top.Controls.Add(label6, 0, 5);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(3, 3);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 7;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel_top.Size = new Size(794, 294);
            tableLayoutPanel_top.TabIndex = 0;
            // 
            // label_name
            // 
            label_name.AutoEllipsis = true;
            label_name.Dock = DockStyle.Fill;
            label_name.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_name.Location = new Point(400, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(391, 42);
            label_name.TabIndex = 0;
            label_name.TextAlign = ContentAlignment.MiddleLeft;
            label_name.MouseEnter += label_enter;
            label_name.MouseLeave += label_leave;
            // 
            // label_criterion
            // 
            label_criterion.AutoEllipsis = true;
            label_criterion.Dock = DockStyle.Fill;
            label_criterion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_criterion.Location = new Point(400, 42);
            label_criterion.Name = "label_criterion";
            label_criterion.Size = new Size(391, 42);
            label_criterion.TabIndex = 0;
            label_criterion.TextAlign = ContentAlignment.MiddleLeft;
            label_criterion.MouseEnter += label_enter;
            label_criterion.MouseLeave += label_leave;
            // 
            // label_offer
            // 
            label_offer.AutoEllipsis = true;
            label_offer.Dock = DockStyle.Fill;
            label_offer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_offer.Location = new Point(400, 84);
            label_offer.Name = "label_offer";
            label_offer.Size = new Size(391, 42);
            label_offer.TabIndex = 0;
            label_offer.TextAlign = ContentAlignment.MiddleLeft;
            label_offer.MouseEnter += label_enter;
            label_offer.MouseLeave += label_leave;
            // 
            // label_repeat
            // 
            label_repeat.AutoEllipsis = true;
            label_repeat.Dock = DockStyle.Fill;
            label_repeat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_repeat.Location = new Point(400, 126);
            label_repeat.Name = "label_repeat";
            label_repeat.Size = new Size(391, 42);
            label_repeat.TabIndex = 0;
            label_repeat.TextAlign = ContentAlignment.MiddleLeft;
            label_repeat.MouseEnter += label_enter;
            label_repeat.MouseLeave += label_leave;
            // 
            // label_date
            // 
            label_date.AutoEllipsis = true;
            label_date.Dock = DockStyle.Fill;
            label_date.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_date.Location = new Point(400, 168);
            label_date.Name = "label_date";
            label_date.Size = new Size(391, 42);
            label_date.TabIndex = 0;
            label_date.TextAlign = ContentAlignment.MiddleLeft;
            label_date.MouseEnter += label_enter;
            label_date.MouseLeave += label_leave;
            // 
            // label_time
            // 
            label_time.AutoEllipsis = true;
            label_time.Dock = DockStyle.Fill;
            label_time.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_time.Location = new Point(400, 210);
            label_time.Name = "label_time";
            label_time.Size = new Size(391, 42);
            label_time.TabIndex = 0;
            label_time.TextAlign = ContentAlignment.MiddleLeft;
            label_time.MouseEnter += label_enter;
            label_time.MouseLeave += label_leave;
            // 
            // label_day
            // 
            label_day.AutoEllipsis = true;
            label_day.Dock = DockStyle.Fill;
            label_day.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_day.Location = new Point(400, 252);
            label_day.Name = "label_day";
            label_day.Size = new Size(391, 42);
            label_day.TabIndex = 0;
            label_day.TextAlign = ContentAlignment.MiddleLeft;
            label_day.MouseEnter += label_enter;
            label_day.MouseLeave += label_leave;
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(391, 42);
            label1.TabIndex = 0;
            label1.Text = "ชื่อโปรโมชั่น :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(3, 42);
            label2.Name = "label2";
            label2.Size = new Size(391, 42);
            label2.TabIndex = 0;
            label2.Text = "เกณฑ์ส่วนลด :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.MouseEnter += label_enter;
            label2.MouseLeave += label_leave;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(3, 84);
            label3.Name = "label3";
            label3.Size = new Size(391, 42);
            label3.TabIndex = 0;
            label3.Text = "ประเภทส่วนลด :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.MouseEnter += label_enter;
            label3.MouseLeave += label_leave;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(3, 126);
            label4.Name = "label4";
            label4.Size = new Size(391, 42);
            label4.TabIndex = 0;
            label4.Text = "การใช้งานต่อบิล :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.MouseEnter += label_enter;
            label4.MouseLeave += label_leave;
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(3, 168);
            label5.Name = "label5";
            label5.Size = new Size(391, 42);
            label5.TabIndex = 0;
            label5.Text = "วันที่ใช้งาน :";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.MouseEnter += label_enter;
            label5.MouseLeave += label_leave;
            // 
            // label7
            // 
            label7.AutoEllipsis = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(3, 252);
            label7.Name = "label7";
            label7.Size = new Size(391, 42);
            label7.TabIndex = 0;
            label7.Text = "วันใช้งาน :";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.MouseEnter += label_enter;
            label7.MouseLeave += label_leave;
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(3, 210);
            label6.Name = "label6";
            label6.Size = new Size(391, 42);
            label6.TabIndex = 0;
            label6.Text = "เวลาใช้งาน :";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.MouseEnter += label_enter;
            label6.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_bottom
            // 
            tableLayoutPanel_bottom.ColumnCount = 2;
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_bottom.Controls.Add(dataGridView_item_premium, 1, 1);
            tableLayoutPanel_bottom.Controls.Add(dataGridView_item_pro, 0, 1);
            tableLayoutPanel_bottom.Controls.Add(label_item_pro, 0, 0);
            tableLayoutPanel_bottom.Controls.Add(label_item_premium, 1, 0);
            tableLayoutPanel_bottom.Dock = DockStyle.Fill;
            tableLayoutPanel_bottom.Location = new Point(3, 303);
            tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            tableLayoutPanel_bottom.RowCount = 2;
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.Size = new Size(794, 280);
            tableLayoutPanel_bottom.TabIndex = 1;
            // 
            // dataGridView_item_premium
            // 
            dataGridView_item_premium.AllowUserToAddRows = false;
            dataGridView_item_premium.AllowUserToDeleteRows = false;
            dataGridView_item_premium.AllowUserToResizeColumns = false;
            dataGridView_item_premium.AllowUserToResizeRows = false;
            dataGridView_item_premium.BackgroundColor = Color.White;
            dataGridView_item_premium.BorderStyle = BorderStyle.None;
            dataGridView_item_premium.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_item_premium.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_item_premium.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_item_premium.ColumnHeadersHeight = 4;
            dataGridView_item_premium.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item_premium.Columns.AddRange(new DataGridViewColumn[] { seq_premium, item_name_premium, item_qty_premium, item_unit_premium });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.White;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView_item_premium.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView_item_premium.Dock = DockStyle.Fill;
            dataGridView_item_premium.GridColor = Color.FromArgb(192, 255, 192);
            dataGridView_item_premium.Location = new Point(400, 50);
            dataGridView_item_premium.Margin = new Padding(3, 0, 0, 0);
            dataGridView_item_premium.MultiSelect = false;
            dataGridView_item_premium.Name = "dataGridView_item_premium";
            dataGridView_item_premium.ReadOnly = true;
            dataGridView_item_premium.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_item_premium.RowHeadersVisible = false;
            dataGridView_item_premium.RowHeadersWidth = 51;
            dataGridView_item_premium.RowTemplate.Height = 40;
            dataGridView_item_premium.RowTemplate.ReadOnly = true;
            dataGridView_item_premium.ScrollBars = ScrollBars.None;
            dataGridView_item_premium.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item_premium.Size = new Size(394, 230);
            dataGridView_item_premium.TabIndex = 10;
            dataGridView_item_premium.TabStop = false;
            dataGridView_item_premium.CellMouseEnter += dataGridView_item_premium_CellMouseEnter;
            dataGridView_item_premium.CellMouseLeave += dataGridView_item_premium_CellMouseLeave;
            // 
            // seq_premium
            // 
            seq_premium.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            seq_premium.DefaultCellStyle = dataGridViewCellStyle2;
            seq_premium.HeaderText = "";
            seq_premium.MinimumWidth = 6;
            seq_premium.Name = "seq_premium";
            seq_premium.ReadOnly = true;
            seq_premium.Width = 6;
            // 
            // item_name_premium
            // 
            item_name_premium.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            item_name_premium.DefaultCellStyle = dataGridViewCellStyle3;
            item_name_premium.HeaderText = "";
            item_name_premium.MinimumWidth = 6;
            item_name_premium.Name = "item_name_premium";
            item_name_premium.ReadOnly = true;
            // 
            // item_qty_premium
            // 
            item_qty_premium.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            item_qty_premium.DefaultCellStyle = dataGridViewCellStyle4;
            item_qty_premium.HeaderText = "";
            item_qty_premium.MinimumWidth = 6;
            item_qty_premium.Name = "item_qty_premium";
            item_qty_premium.ReadOnly = true;
            item_qty_premium.Width = 6;
            // 
            // item_unit_premium
            // 
            item_unit_premium.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            item_unit_premium.DefaultCellStyle = dataGridViewCellStyle5;
            item_unit_premium.HeaderText = "";
            item_unit_premium.MinimumWidth = 6;
            item_unit_premium.Name = "item_unit_premium";
            item_unit_premium.ReadOnly = true;
            item_unit_premium.Width = 6;
            // 
            // dataGridView_item_pro
            // 
            dataGridView_item_pro.AllowUserToAddRows = false;
            dataGridView_item_pro.AllowUserToDeleteRows = false;
            dataGridView_item_pro.AllowUserToResizeColumns = false;
            dataGridView_item_pro.AllowUserToResizeRows = false;
            dataGridView_item_pro.BackgroundColor = Color.White;
            dataGridView_item_pro.BorderStyle = BorderStyle.None;
            dataGridView_item_pro.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_item_pro.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView_item_pro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridView_item_pro.ColumnHeadersHeight = 4;
            dataGridView_item_pro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_item_pro.Columns.AddRange(new DataGridViewColumn[] { seq_pro, item_name_pro, item_qty_pro, item_unit_pro });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = Color.White;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dataGridView_item_pro.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridView_item_pro.Dock = DockStyle.Fill;
            dataGridView_item_pro.GridColor = Color.FromArgb(192, 255, 192);
            dataGridView_item_pro.Location = new Point(0, 50);
            dataGridView_item_pro.Margin = new Padding(0, 0, 3, 0);
            dataGridView_item_pro.MultiSelect = false;
            dataGridView_item_pro.Name = "dataGridView_item_pro";
            dataGridView_item_pro.ReadOnly = true;
            dataGridView_item_pro.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_item_pro.RowHeadersVisible = false;
            dataGridView_item_pro.RowHeadersWidth = 51;
            dataGridView_item_pro.RowTemplate.Height = 40;
            dataGridView_item_pro.RowTemplate.ReadOnly = true;
            dataGridView_item_pro.ScrollBars = ScrollBars.None;
            dataGridView_item_pro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_item_pro.Size = new Size(394, 230);
            dataGridView_item_pro.TabIndex = 9;
            dataGridView_item_pro.TabStop = false;
            dataGridView_item_pro.CellMouseEnter += dataGridView_item_pro_CellMouseEnter;
            dataGridView_item_pro.CellMouseLeave += dataGridView_item_pro_CellMouseLeave;
            // 
            // seq_pro
            // 
            seq_pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            seq_pro.DefaultCellStyle = dataGridViewCellStyle8;
            seq_pro.HeaderText = "";
            seq_pro.MinimumWidth = 6;
            seq_pro.Name = "seq_pro";
            seq_pro.ReadOnly = true;
            seq_pro.Width = 6;
            // 
            // item_name_pro
            // 
            item_name_pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            item_name_pro.DefaultCellStyle = dataGridViewCellStyle9;
            item_name_pro.HeaderText = "";
            item_name_pro.MinimumWidth = 6;
            item_name_pro.Name = "item_name_pro";
            item_name_pro.ReadOnly = true;
            // 
            // item_qty_pro
            // 
            item_qty_pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            item_qty_pro.DefaultCellStyle = dataGridViewCellStyle10;
            item_qty_pro.HeaderText = "";
            item_qty_pro.MinimumWidth = 6;
            item_qty_pro.Name = "item_qty_pro";
            item_qty_pro.ReadOnly = true;
            item_qty_pro.Visible = false;
            item_qty_pro.Width = 125;
            // 
            // item_unit_pro
            // 
            item_unit_pro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            item_unit_pro.DefaultCellStyle = dataGridViewCellStyle11;
            item_unit_pro.HeaderText = "";
            item_unit_pro.MinimumWidth = 6;
            item_unit_pro.Name = "item_unit_pro";
            item_unit_pro.ReadOnly = true;
            item_unit_pro.Visible = false;
            item_unit_pro.Width = 125;
            // 
            // label_item_pro
            // 
            label_item_pro.BackColor = Color.Cyan;
            label_item_pro.Dock = DockStyle.Fill;
            label_item_pro.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_item_pro.Location = new Point(0, 0);
            label_item_pro.Margin = new Padding(0, 0, 3, 0);
            label_item_pro.Name = "label_item_pro";
            label_item_pro.Size = new Size(394, 50);
            label_item_pro.TabIndex = 0;
            label_item_pro.Text = "สินค้าโปร";
            label_item_pro.TextAlign = ContentAlignment.MiddleCenter;
            label_item_pro.MouseEnter += label_enter;
            label_item_pro.MouseLeave += label_leave;
            // 
            // label_item_premium
            // 
            label_item_premium.BackColor = Color.Cyan;
            label_item_premium.Dock = DockStyle.Fill;
            label_item_premium.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label_item_premium.Location = new Point(400, 0);
            label_item_premium.Margin = new Padding(3, 0, 0, 0);
            label_item_premium.Name = "label_item_premium";
            label_item_premium.Size = new Size(394, 50);
            label_item_premium.TabIndex = 0;
            label_item_premium.Text = "สินค้าแถม";
            label_item_premium.TextAlign = ContentAlignment.MiddleCenter;
            label_item_premium.MouseEnter += label_enter;
            label_item_premium.MouseLeave += label_leave;
            // 
            // Form_Promotion_Detail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 586);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Promotion_Detail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "รายละเอียดโปรโมชั่น";
            Load += Form_Promotion_Detail_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            tableLayoutPanel_bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_item_premium).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_item_pro).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_top;
        private Label label_name;
        private Label label_criterion;
        private Label label_offer;
        private Label label_repeat;
        private Label label_date;
        private Label label_time;
        private Label label_day;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel_bottom;
        private Label label_item_pro;
        private Label label_item_premium;
        private DataGridView dataGridView_item_pro;
        private DataGridView dataGridView_item_premium;
        private DataGridViewTextBoxColumn seq_premium;
        private DataGridViewTextBoxColumn item_name_premium;
        private DataGridViewTextBoxColumn item_qty_premium;
        private DataGridViewTextBoxColumn item_unit_premium;
        private DataGridViewTextBoxColumn seq_pro;
        private DataGridViewTextBoxColumn item_name_pro;
        private DataGridViewTextBoxColumn item_qty_pro;
        private DataGridViewTextBoxColumn item_unit_pro;
    }
}