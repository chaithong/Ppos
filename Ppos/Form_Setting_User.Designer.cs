namespace Ppos
{
    partial class Form_Setting_User
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_top = new TableLayoutPanel();
            button_add_user = new Button();
            textBox_pass = new TextBox();
            textBox_user = new TextBox();
            dataGridView_user = new DataGridView();
            customGroupBox_back = new CustomGroupBox();
            tableLayoutPanel_bottom = new TableLayoutPanel();
            user = new DataGridViewTextBoxColumn();
            pass = new DataGridViewTextBoxColumn();
            delete = new DataGridViewImageColumn();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_user).BeginInit();
            customGroupBox_back.SuspendLayout();
            tableLayoutPanel_bottom.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.Cyan;
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_bottom, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(10, 13);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(994, 742);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_top
            // 
            tableLayoutPanel_top.BackColor = Color.White;
            tableLayoutPanel_top.ColumnCount = 5;
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_top.Controls.Add(button_add_user, 3, 0);
            tableLayoutPanel_top.Controls.Add(textBox_pass, 2, 0);
            tableLayoutPanel_top.Controls.Add(textBox_user, 1, 0);
            tableLayoutPanel_top.Dock = DockStyle.Fill;
            tableLayoutPanel_top.Location = new Point(0, 0);
            tableLayoutPanel_top.Margin = new Padding(0);
            tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            tableLayoutPanel_top.RowCount = 1;
            tableLayoutPanel_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_top.Size = new Size(994, 50);
            tableLayoutPanel_top.TabIndex = 3;
            // 
            // button_add_user
            // 
            button_add_user.BackColor = Color.Transparent;
            button_add_user.BackgroundImageLayout = ImageLayout.Zoom;
            button_add_user.Dock = DockStyle.Fill;
            button_add_user.FlatAppearance.BorderSize = 0;
            button_add_user.FlatAppearance.MouseDownBackColor = Color.Cyan;
            button_add_user.FlatAppearance.MouseOverBackColor = Color.Cyan;
            button_add_user.FlatStyle = FlatStyle.Flat;
            button_add_user.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_add_user.Location = new Point(734, 0);
            button_add_user.Margin = new Padding(0);
            button_add_user.Name = "button_add_user";
            button_add_user.Size = new Size(125, 50);
            button_add_user.TabIndex = 1;
            button_add_user.TabStop = false;
            button_add_user.Tag = "";
            button_add_user.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_add_user.UseVisualStyleBackColor = false;
            button_add_user.Click += button_add_user_Click;
            button_add_user.MouseEnter += button_add_user_MouseEnter;
            button_add_user.MouseLeave += button_add_user_MouseLeave;
            // 
            // textBox_pass
            // 
            textBox_pass.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_pass.Font = new Font("Segoe UI", 16.2F);
            textBox_pass.Location = new Point(437, 3);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(294, 43);
            textBox_pass.TabIndex = 1;
            textBox_pass.TextAlign = HorizontalAlignment.Center;
            textBox_pass.KeyDown += textBox_pass_KeyDown;
            textBox_pass.KeyPress += textBox_KeyPress;
            textBox_pass.KeyUp += textBox_pass_KeyUp;
            // 
            // textBox_user
            // 
            textBox_user.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_user.Font = new Font("Segoe UI", 16.2F);
            textBox_user.Location = new Point(137, 3);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(294, 43);
            textBox_user.TabIndex = 0;
            textBox_user.TextAlign = HorizontalAlignment.Center;
            textBox_user.KeyPress += textBox_KeyPress;
            textBox_user.KeyUp += textBox_user_KeyUp;
            // 
            // dataGridView_user
            // 
            dataGridView_user.AllowUserToAddRows = false;
            dataGridView_user.AllowUserToDeleteRows = false;
            dataGridView_user.AllowUserToResizeColumns = false;
            dataGridView_user.AllowUserToResizeRows = false;
            dataGridView_user.BackgroundColor = Color.White;
            dataGridView_user.BorderStyle = BorderStyle.None;
            dataGridView_user.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_user.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_user.ColumnHeadersHeight = 50;
            dataGridView_user.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_user.Columns.AddRange(new DataGridViewColumn[] { user, pass, delete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_user.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_user.Dock = DockStyle.Fill;
            dataGridView_user.GridColor = Color.FromArgb(128, 255, 255);
            dataGridView_user.Location = new Point(134, 0);
            dataGridView_user.Margin = new Padding(0);
            dataGridView_user.MultiSelect = false;
            dataGridView_user.Name = "dataGridView_user";
            dataGridView_user.ReadOnly = true;
            dataGridView_user.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 1F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(128, 255, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView_user.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView_user.RowHeadersVisible = false;
            dataGridView_user.RowHeadersWidth = 51;
            dataGridView_user.RowTemplate.Height = 50;
            dataGridView_user.ScrollBars = ScrollBars.None;
            dataGridView_user.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_user.ShowCellToolTips = false;
            dataGridView_user.Size = new Size(725, 692);
            dataGridView_user.TabIndex = 2;
            dataGridView_user.TabStop = false;
            dataGridView_user.CellClick += dataGridView_user_CellClick;
            dataGridView_user.CellMouseEnter += dataGridView_user_CellMouseEnter;
            dataGridView_user.CellMouseLeave += dataGridView_user_CellMouseLeave;
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BackColor = Color.Transparent;
            customGroupBox_back.BorderColor = Color.White;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(tableLayoutPanel_back);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 0);
            customGroupBox_back.Margin = new Padding(0);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(1014, 765);
            customGroupBox_back.TabIndex = 1;
            customGroupBox_back.TabStop = false;
            // 
            // tableLayoutPanel_bottom
            // 
            tableLayoutPanel_bottom.BackColor = Color.White;
            tableLayoutPanel_bottom.ColumnCount = 3;
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 725F));
            tableLayoutPanel_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_bottom.Controls.Add(dataGridView_user, 1, 0);
            tableLayoutPanel_bottom.Dock = DockStyle.Fill;
            tableLayoutPanel_bottom.Location = new Point(0, 50);
            tableLayoutPanel_bottom.Margin = new Padding(0);
            tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            tableLayoutPanel_bottom.RowCount = 1;
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_bottom.Size = new Size(994, 692);
            tableLayoutPanel_bottom.TabIndex = 4;
            // 
            // user
            // 
            user.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            user.HeaderText = "ชื่อ";
            user.MinimumWidth = 6;
            user.Name = "user";
            user.ReadOnly = true;
            // 
            // pass
            // 
            pass.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pass.HeaderText = "รหัส";
            pass.MinimumWidth = 6;
            pass.Name = "pass";
            pass.ReadOnly = true;
            // 
            // delete
            // 
            delete.HeaderText = "";
            delete.MinimumWidth = 6;
            delete.Name = "delete";
            delete.ReadOnly = true;
            delete.Resizable = DataGridViewTriState.True;
            delete.SortMode = DataGridViewColumnSortMode.Automatic;
            delete.Width = 125;
            // 
            // Form_Setting_User
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(1024, 768);
            Controls.Add(customGroupBox_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Setting_User";
            Padding = new Padding(0, 0, 10, 3);
            Text = "Form_Setting_User";
            Load += Form_Setting_User_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_top.ResumeLayout(false);
            tableLayoutPanel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_user).EndInit();
            customGroupBox_back.ResumeLayout(false);
            tableLayoutPanel_bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private Button button_add_user;
        private DataGridView dataGridView_user;
        private TableLayoutPanel tableLayoutPanel_top;
        private TextBox textBox_user;
        private TextBox textBox_pass;
        private CustomGroupBox customGroupBox_back;
        private TableLayoutPanel tableLayoutPanel_bottom;
        private DataGridViewTextBoxColumn user;
        private DataGridViewTextBoxColumn pass;
        private DataGridViewImageColumn delete;
    }
}