namespace Ppos
{
    partial class Form_Check_Promotion
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            customGroupBox_search = new CustomGroupBox();
            textBox_search = new TextBox();
            dataGridView_promotion = new DataGridView();
            backgroundWorker_search = new System.ComponentModel.BackgroundWorker();
            timer_search = new System.Windows.Forms.Timer(components);
            Column1 = new DataGridViewTextBoxColumn();
            seq = new DataGridViewTextBoxColumn();
            detail = new DataGridViewImageColumn();
            id = new DataGridViewTextBoxColumn();
            pro_type = new DataGridViewTextBoxColumn();
            pro_desc = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            day = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            customGroupBox_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_promotion).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Cyan;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(dataGridView_promotion, 0, 2);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(1033, 630);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 3;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(customGroupBox_search, 1, 1);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(0, 0);
            tableLayoutPanel_top.Margin = new Padding(0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 3;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Size = new Size(1033, 100);
            tableLayoutPanel_top.TabIndex = 1;
            // 
            // customGroupBox_search
            // 
            customGroupBox_search.BackColor = Color.White;
            customGroupBox_search.BorderColor = Color.FromArgb(128, 255, 255);
            customGroupBox_search.BorderRadius = 30;
            customGroupBox_search.BorderThickness = 20;
            customGroupBox_search.Controls.Add(textBox_search);
            customGroupBox_search.Dock = DockStyle.Fill;
            customGroupBox_search.Font = new Font("Segoe UI", 1F);
            customGroupBox_search.Location = new Point(269, 18);
            customGroupBox_search.Name = "customGroupBox_search";
            customGroupBox_search.Padding = new Padding(10);
            customGroupBox_search.Size = new Size(494, 64);
            customGroupBox_search.TabIndex = 0;
            customGroupBox_search.TabStop = false;
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.FromArgb(128, 255, 255);
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Fill;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(10, 13);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(474, 44);
            textBox_search.TabIndex = 0;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            // 
            // dataGridView_promotion
            // 
            dataGridView_promotion.AllowUserToAddRows = false;
            dataGridView_promotion.AllowUserToDeleteRows = false;
            dataGridView_promotion.AllowUserToResizeColumns = false;
            dataGridView_promotion.AllowUserToResizeRows = false;
            dataGridView_promotion.BackgroundColor = Color.White;
            dataGridView_promotion.BorderStyle = BorderStyle.None;
            dataGridView_promotion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_promotion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_promotion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_promotion.ColumnHeadersHeight = 50;
            dataGridView_promotion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_promotion.Columns.AddRange(new DataGridViewColumn[] { Column1, seq, detail, id, pro_type, pro_desc, date, time, day, Column2 });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView_promotion.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView_promotion.Dock = DockStyle.Fill;
            dataGridView_promotion.Enabled = false;
            dataGridView_promotion.GridColor = Color.Cyan;
            dataGridView_promotion.Location = new Point(0, 105);
            dataGridView_promotion.Margin = new Padding(0);
            dataGridView_promotion.MultiSelect = false;
            dataGridView_promotion.Name = "dataGridView_promotion";
            dataGridView_promotion.ReadOnly = true;
            dataGridView_promotion.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_promotion.RowHeadersVisible = false;
            dataGridView_promotion.RowHeadersWidth = 51;
            dataGridView_promotion.RowTemplate.Height = 50;
            dataGridView_promotion.RowTemplate.ReadOnly = true;
            dataGridView_promotion.ScrollBars = ScrollBars.None;
            dataGridView_promotion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_promotion.Size = new Size(1033, 525);
            dataGridView_promotion.TabIndex = 0;
            dataGridView_promotion.CellMouseDoubleClick += dataGridView_promotion_CellMouseDoubleClick;
            dataGridView_promotion.CellMouseEnter += dataGridView_promotion_CellMouseEnter;
            dataGridView_promotion.CellMouseLeave += dataGridView_promotion_CellMouseLeave;
            dataGridView_promotion.CellMouseUp += dataGridView_promotion_CellMouseUp;
            // 
            // backgroundWorker_search
            // 
            backgroundWorker_search.DoWork += backgroundWorker_search_DoWork;
            backgroundWorker_search.RunWorkerCompleted += backgroundWorker_search_RunWorkerCompleted;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // seq
            // 
            seq.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            seq.DefaultCellStyle = dataGridViewCellStyle2;
            seq.HeaderText = "";
            seq.MinimumWidth = 6;
            seq.Name = "seq";
            seq.ReadOnly = true;
            seq.Width = 23;
            // 
            // detail
            // 
            detail.HeaderText = "";
            detail.MinimumWidth = 6;
            detail.Name = "detail";
            detail.ReadOnly = true;
            detail.Width = 125;
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
            // pro_type
            // 
            pro_type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            pro_type.DefaultCellStyle = dataGridViewCellStyle3;
            pro_type.HeaderText = "ประเภท";
            pro_type.MinimumWidth = 6;
            pro_type.Name = "pro_type";
            pro_type.ReadOnly = true;
            pro_type.Width = 116;
            // 
            // pro_desc
            // 
            pro_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            pro_desc.DefaultCellStyle = dataGridViewCellStyle4;
            pro_desc.HeaderText = "ชื่อโปรโมชั่น";
            pro_desc.MinimumWidth = 6;
            pro_desc.Name = "pro_desc";
            pro_desc.ReadOnly = true;
            pro_desc.Width = 168;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            date.DefaultCellStyle = dataGridViewCellStyle5;
            date.HeaderText = "วันที่ใช้งาน";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.ReadOnly = true;
            date.Width = 154;
            // 
            // time
            // 
            time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            time.DefaultCellStyle = dataGridViewCellStyle6;
            time.HeaderText = "เวลาใช้งาน";
            time.MinimumWidth = 6;
            time.Name = "time";
            time.ReadOnly = true;
            time.Width = 155;
            // 
            // day
            // 
            day.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            day.DefaultCellStyle = dataGridViewCellStyle7;
            day.HeaderText = "วันใช้งาน";
            day.MinimumWidth = 6;
            day.Name = "day";
            day.ReadOnly = true;
            day.Width = 138;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Form_Check_Promotion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1033, 630);
            Controls.Add(tableLayoutPanel_back);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Check_Promotion";
            Text = "Form_Check_Promotion";
            Load += Form_Check_Promotion_Load;
            Shown += Form_Check_Promotion_Shown;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            customGroupBox_search.ResumeLayout(false);
            customGroupBox_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_promotion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_top;
        private CustomGroupBox customGroupBox_search;
        private TextBox textBox_search;
        private DataGridView dataGridView_promotion;
        private System.ComponentModel.BackgroundWorker backgroundWorker_search;
        private System.Windows.Forms.Timer timer_search;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn seq;
        private DataGridViewImageColumn detail;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn pro_type;
        private DataGridViewTextBoxColumn pro_desc;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn day;
        private DataGridViewTextBoxColumn Column2;
    }
}