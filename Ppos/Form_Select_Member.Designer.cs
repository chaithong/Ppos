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
            customGroupBox_back = new CustomGroupBox();
            timer_search = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            customGroupBox_back.SuspendLayout();
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
            dataGridView_member.Size = new Size(868, 547);
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
            textBox_search.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_search.Enabled = false;
            textBox_search.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_search.Location = new Point(3, 24);
            textBox_search.Name = "textBox_search";
            textBox_search.Size = new Size(862, 51);
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
            tableLayoutPanel_back.Controls.Add(textBox_search, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(20, 23);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(868, 647);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BorderColor = Color.Cyan;
            customGroupBox_back.BorderRadius = 10;
            customGroupBox_back.BorderThickness = 10;
            customGroupBox_back.Controls.Add(tableLayoutPanel_back);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(20);
            customGroupBox_back.Size = new Size(908, 690);
            customGroupBox_back.TabIndex = 3;
            customGroupBox_back.TabStop = false;
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
            Controls.Add(customGroupBox_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Select_Member";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ค้นหาสมาชิก";
            Load += Form_Select_Member_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_member).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back.PerformLayout();
            customGroupBox_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_member;
        private TextBox textBox_search;
        private System.ComponentModel.BackgroundWorker backgroundWorker_search;
        private TableLayoutPanel tableLayoutPanel_back;
        private CustomGroupBox customGroupBox_back;
        private System.Windows.Forms.Timer timer_search;
        private DataGridViewTextBoxColumn id;
        private DataGridViewImageColumn sex;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn point_balance;
        private DataGridViewImageColumn select;
    }
}