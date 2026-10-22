namespace Ppos
{
    partial class Form_Select_Member
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_Member));
            dataGridView_member = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            sex = new DataGridViewImageColumn();
            phone = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            point_balance = new DataGridViewTextBoxColumn();
            select = new DataGridViewImageColumn();
            textBox_search = new TextBox();
            backgroundWorker_search = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            customGroupBox1 = new CustomGroupBox();
            button_add_member = new Button();
            timer_search = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            customGroupBox1.SuspendLayout();
            SuspendLayout();
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
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_member.ColumnHeadersHeight = 50;
            dataGridView_member.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_member.Columns.AddRange(new DataGridViewColumn[] { id, sex, phone, name, point_balance, select });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(128, 255, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView_member.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_member.Dock = DockStyle.Fill;
            dataGridView_member.Enabled = false;
            dataGridView_member.GridColor = Color.Cyan;
            dataGridView_member.Location = new Point(0, 100);
            dataGridView_member.Margin = new Padding(0);
            dataGridView_member.MultiSelect = false;
            dataGridView_member.Name = "dataGridView_member";
            dataGridView_member.ReadOnly = true;
            dataGridView_member.RowHeadersVisible = false;
            dataGridView_member.RowHeadersWidth = 51;
            dataGridView_member.RowTemplate.Height = 50;
            dataGridView_member.RowTemplate.ReadOnly = true;
            dataGridView_member.ScrollBars = ScrollBars.None;
            dataGridView_member.Size = new Size(908, 590);
            dataGridView_member.TabIndex = 0;
            dataGridView_member.CellMouseDoubleClick += dataGridView_member_CellMouseDoubleClick;
            dataGridView_member.CellMouseEnter += dataGridView_member_CellMouseEnter;
            dataGridView_member.CellMouseLeave += dataGridView_member_CellMouseLeave;
            dataGridView_member.CellMouseUp += dataGridView_member_CellMouseUp;
            // 
            // id
            // 
            id.HeaderText = "";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 125;
            // 
            // sex
            // 
            sex.HeaderText = "0/0";
            sex.MinimumWidth = 6;
            sex.Name = "sex";
            sex.ReadOnly = true;
            sex.Resizable = DataGridViewTriState.True;
            sex.SortMode = DataGridViewColumnSortMode.Automatic;
            sex.Width = 125;
            // 
            // phone
            // 
            phone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            phone.DefaultCellStyle = dataGridViewCellStyle2;
            phone.HeaderText = "เบอร์โทร";
            phone.MinimumWidth = 6;
            phone.Name = "phone";
            phone.ReadOnly = true;
            phone.Width = 114;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            name.DefaultCellStyle = dataGridViewCellStyle3;
            name.HeaderText = "ชื่อสมาชิก";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // point_balance
            // 
            point_balance.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            point_balance.DefaultCellStyle = dataGridViewCellStyle4;
            point_balance.HeaderText = "แต้มคงเหลือ";
            point_balance.MinimumWidth = 6;
            point_balance.Name = "point_balance";
            point_balance.ReadOnly = true;
            point_balance.Width = 145;
            // 
            // select
            // 
            select.HeaderText = "";
            select.MinimumWidth = 6;
            select.Name = "select";
            select.ReadOnly = true;
            select.Resizable = DataGridViewTriState.True;
            select.SortMode = DataGridViewColumnSortMode.Automatic;
            select.Width = 125;
            // 
            // textBox_search
            // 
            textBox_search.BackColor = Color.FromArgb(128, 255, 255);
            textBox_search.BorderStyle = BorderStyle.None;
            textBox_search.Dock = DockStyle.Fill;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(10, 13);
            textBox_search.Margin = new Padding(0);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(380, 44);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = HorizontalAlignment.Center;
            textBox_search.TextChanged += textBox_search_TextChanged;
            textBox_search.KeyDown += textBox_search_KeyDown;
            textBox_search.Leave += textBox_search_Leave;
            // 
            // backgroundWorker_search
            // 
            backgroundWorker_search.DoWork += backgroundWorker_search_DoWork;
            backgroundWorker_search.RunWorkerCompleted += backgroundWorker_search_RunWorkerCompleted;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Transparent;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(dataGridView_member, 0, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(908, 690);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.ColumnCount = 3;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Controls.Add(customGroupBox1, 1, 1);
            tableLayoutPanel_top.Controls.Add(button_add_member, 2, 1);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(3, 3);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 3;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.Size = new Size(902, 94);
            tableLayoutPanel_top.TabIndex = 1;
            // 
            // customGroupBox1
            // 
            customGroupBox1.BorderColor = Color.FromArgb(128, 255, 255);
            customGroupBox1.BorderRadius = 30;
            customGroupBox1.BorderThickness = 20;
            customGroupBox1.Controls.Add(textBox_search);
            customGroupBox1.Dock = DockStyle.Fill;
            customGroupBox1.Font = new Font("Segoe UI", 1F);
            customGroupBox1.Location = new Point(251, 12);
            customGroupBox1.Margin = new Padding(0);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Padding = new Padding(10);
            customGroupBox1.Size = new Size(400, 70);
            customGroupBox1.TabIndex = 0;
            customGroupBox1.TabStop = false;
            // 
            // button_add_member
            // 
            button_add_member.Dock = DockStyle.Left;
            button_add_member.FlatAppearance.BorderSize = 0;
            button_add_member.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_add_member.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_add_member.FlatStyle = FlatStyle.Flat;
            button_add_member.Location = new Point(654, 15);
            button_add_member.Name = "button_add_member";
            button_add_member.Size = new Size(94, 64);
            button_add_member.TabIndex = 1;
            button_add_member.UseVisualStyleBackColor = true;
            button_add_member.Visible = false;
            button_add_member.Click += button_add_member_Click;
            button_add_member.MouseEnter += button_add_member_MouseEnter;
            button_add_member.MouseLeave += button_add_member_MouseLeave;
            // 
            // timer_search
            // 
            timer_search.Tick += timer_search_Tick;
            // 
            // Form_Select_Member
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(908, 690);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Select_Member";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ค้นหาสมาชิก";
            Load += Form_Select_Member_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            customGroupBox1.ResumeLayout(false);
            customGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_member;
        private TextBox textBox_search;
        private System.ComponentModel.BackgroundWorker backgroundWorker_search;
        private TableLayoutPanel tableLayoutPanel_back;
        private System.Windows.Forms.Timer timer_search;
        private DataGridViewTextBoxColumn id;
        private DataGridViewImageColumn sex;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn point_balance;
        private DataGridViewImageColumn select;
        private TableLayoutPanel tableLayoutPanel_top;
        private CustomGroupBox customGroupBox1;
        private Button button_add_member;
    }
}