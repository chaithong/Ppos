namespace Ppos
{
    partial class Form_Item_Group
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_back_top = new TableLayoutPanel();
            button_add_group = new Button();
            textBox_subgroup = new TextBox();
            textBox_maingroup = new TextBox();
            panel_back = new Panel();
            dataGridView_group = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            maingroup = new DataGridViewTextBoxColumn();
            subgroup = new DataGridViewTextBoxColumn();
            delete = new DataGridViewImageColumn();
            Column2 = new DataGridViewTextBoxColumn();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_back_top.SuspendLayout();
            panel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_group).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_back_top, 0, 0);
            tableLayoutPanel_back.Controls.Add(panel_back, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(969, 500);
            tableLayoutPanel_back.TabIndex = 0;
            // 
            // tableLayoutPanel_back_top
            // 
            tableLayoutPanel_back_top.BackColor = Color.Lime;
            tableLayoutPanel_back_top.ColumnCount = 5;
            tableLayoutPanel_back_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_back_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel_back_top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            tableLayoutPanel_back_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back_top.Controls.Add(button_add_group, 3, 0);
            tableLayoutPanel_back_top.Controls.Add(textBox_subgroup, 2, 0);
            tableLayoutPanel_back_top.Controls.Add(textBox_maingroup, 1, 0);
            tableLayoutPanel_back_top.Dock = DockStyle.Fill;
            tableLayoutPanel_back_top.Location = new Point(0, 0);
            tableLayoutPanel_back_top.Margin = new Padding(0);
            tableLayoutPanel_back_top.Name = "tableLayoutPanel_back_top";
            tableLayoutPanel_back_top.RowCount = 1;
            tableLayoutPanel_back_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back_top.Size = new Size(969, 50);
            tableLayoutPanel_back_top.TabIndex = 1;
            // 
            // button_add_group
            // 
            button_add_group.BackColor = Color.Transparent;
            button_add_group.BackgroundImageLayout = ImageLayout.Zoom;
            button_add_group.Dock = DockStyle.Fill;
            button_add_group.FlatAppearance.BorderSize = 0;
            button_add_group.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_add_group.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_add_group.FlatStyle = FlatStyle.Flat;
            button_add_group.Location = new Point(722, 0);
            button_add_group.Margin = new Padding(0);
            button_add_group.Name = "button_add_group";
            button_add_group.Size = new Size(125, 50);
            button_add_group.TabIndex = 1;
            button_add_group.TabStop = false;
            button_add_group.UseVisualStyleBackColor = false;
            button_add_group.Click += button_add_group_Click;
            button_add_group.MouseEnter += button_add_group_MouseEnter;
            button_add_group.MouseLeave += button_add_group_MouseLeave;
            // 
            // textBox_subgroup
            // 
            textBox_subgroup.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_subgroup.BorderStyle = BorderStyle.None;
            textBox_subgroup.Font = new Font("Segoe UI", 16.2F);
            textBox_subgroup.Location = new Point(425, 7);
            textBox_subgroup.Margin = new Padding(3, 0, 0, 0);
            textBox_subgroup.Name = "textBox_subgroup";
            textBox_subgroup.Size = new Size(297, 36);
            textBox_subgroup.TabIndex = 1;
            textBox_subgroup.TextAlign = HorizontalAlignment.Center;
            textBox_subgroup.TextChanged += textBox_TextChanged;
            textBox_subgroup.KeyDown += textBox_subgroup_KeyDown;
            // 
            // textBox_maingroup
            // 
            textBox_maingroup.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_maingroup.BorderStyle = BorderStyle.None;
            textBox_maingroup.Font = new Font("Segoe UI", 16.2F);
            textBox_maingroup.Location = new Point(122, 7);
            textBox_maingroup.Margin = new Padding(0, 0, 3, 0);
            textBox_maingroup.Name = "textBox_maingroup";
            textBox_maingroup.Size = new Size(297, 36);
            textBox_maingroup.TabIndex = 0;
            textBox_maingroup.TextAlign = HorizontalAlignment.Center;
            textBox_maingroup.TextChanged += textBox_TextChanged;
            textBox_maingroup.KeyDown += textBox_maingroup_KeyDown;
            // 
            // panel_back
            // 
            panel_back.AutoScroll = true;
            panel_back.BackColor = Color.White;
            panel_back.Controls.Add(dataGridView_group);
            panel_back.Dock = DockStyle.Fill;
            panel_back.Location = new Point(0, 50);
            panel_back.Margin = new Padding(0);
            panel_back.Name = "panel_back";
            panel_back.Size = new Size(969, 450);
            panel_back.TabIndex = 2;
            // 
            // dataGridView_group
            // 
            dataGridView_group.AllowUserToAddRows = false;
            dataGridView_group.AllowUserToDeleteRows = false;
            dataGridView_group.AllowUserToResizeColumns = false;
            dataGridView_group.AllowUserToResizeRows = false;
            dataGridView_group.BackgroundColor = Color.White;
            dataGridView_group.BorderStyle = BorderStyle.None;
            dataGridView_group.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_group.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_group.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_group.ColumnHeadersHeight = 50;
            dataGridView_group.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_group.Columns.AddRange(new DataGridViewColumn[] { Column1, maingroup, subgroup, delete, Column2 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 13.8F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView_group.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView_group.Dock = DockStyle.Fill;
            dataGridView_group.GridColor = Color.FromArgb(128, 255, 128);
            dataGridView_group.Location = new Point(0, 0);
            dataGridView_group.Margin = new Padding(0);
            dataGridView_group.MultiSelect = false;
            dataGridView_group.Name = "dataGridView_group";
            dataGridView_group.ReadOnly = true;
            dataGridView_group.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_group.RowHeadersVisible = false;
            dataGridView_group.RowHeadersWidth = 51;
            dataGridView_group.RowTemplate.Height = 50;
            dataGridView_group.ScrollBars = ScrollBars.None;
            dataGridView_group.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_group.ShowCellToolTips = false;
            dataGridView_group.Size = new Size(969, 450);
            dataGridView_group.TabIndex = 0;
            dataGridView_group.TabStop = false;
            dataGridView_group.CellClick += dataGridView_group_CellClick;
            dataGridView_group.CellMouseEnter += dataGridView_group_CellMouseEnter;
            dataGridView_group.CellMouseLeave += dataGridView_group_CellMouseLeave;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // maingroup
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            maingroup.DefaultCellStyle = dataGridViewCellStyle2;
            maingroup.HeaderText = "กลุ่มหลัก";
            maingroup.MinimumWidth = 6;
            maingroup.Name = "maingroup";
            maingroup.ReadOnly = true;
            maingroup.Width = 300;
            // 
            // subgroup
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            subgroup.DefaultCellStyle = dataGridViewCellStyle3;
            subgroup.HeaderText = "กลุ่มย่อย";
            subgroup.MinimumWidth = 6;
            subgroup.Name = "subgroup";
            subgroup.ReadOnly = true;
            subgroup.Width = 300;
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
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Form_Item_Group
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(969, 500);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form_Item_Group";
            Text = "Form_Item_Group";
            Load += Form_Item_Group_Load;
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back_top.ResumeLayout(false);
            tableLayoutPanel_back_top.PerformLayout();
            panel_back.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_group).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_main;
        private DataGridView dataGridView_group;
        private TableLayoutPanel tableLayoutPanel_back_top;
        private TextBox textBox_subgroup;
        private Button button_add_group;
        private TextBox textBox_maingroup;
        private Panel panel_back;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn maingroup;
        private DataGridViewTextBoxColumn subgroup;
        private DataGridViewImageColumn delete;
        private DataGridViewTextBoxColumn Column2;
    }
}