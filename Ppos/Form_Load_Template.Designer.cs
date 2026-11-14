namespace Ppos
{
    partial class Form_Load_Template
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Load_Template));
            comboBox_group_sub = new ComboBox();
            tableLayoutPanel_group = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            comboBox_group_main = new ComboBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_confirm = new TableLayoutPanel();
            button_confirm = new Button();
            tableLayoutPanel_group.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_confirm.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_group_sub
            // 
            comboBox_group_sub.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_group_sub.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_group_sub.Dock = DockStyle.Fill;
            comboBox_group_sub.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_group_sub.FormattingEnabled = true;
            comboBox_group_sub.ItemHeight = 31;
            comboBox_group_sub.Location = new Point(391, 50);
            comboBox_group_sub.Name = "comboBox_group_sub";
            comboBox_group_sub.Size = new Size(382, 39);
            comboBox_group_sub.TabIndex = 1;
            // 
            // tableLayoutPanel_group
            // 
            tableLayoutPanel_group.ColumnCount = 2;
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_group.Controls.Add(comboBox_group_sub, 1, 1);
            tableLayoutPanel_group.Controls.Add(label1, 0, 0);
            tableLayoutPanel_group.Controls.Add(label2, 1, 0);
            tableLayoutPanel_group.Controls.Add(comboBox_group_main, 0, 1);
            tableLayoutPanel_group.Dock = DockStyle.Fill;
            tableLayoutPanel_group.Location = new Point(3, 3);
            tableLayoutPanel_group.Name = "tableLayoutPanel_group";
            tableLayoutPanel_group.RowCount = 2;
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_group.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_group.Size = new Size(776, 94);
            tableLayoutPanel_group.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(382, 47);
            label1.TabIndex = 1;
            label1.Text = "กลุ่มหลัก";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.MouseEnter += label_enter;
            label1.MouseLeave += label_leave;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(391, 0);
            label2.Name = "label2";
            label2.Size = new Size(382, 47);
            label2.TabIndex = 1;
            label2.Text = "กลุ่มหลัก";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.MouseEnter += label_enter;
            label2.MouseLeave += label_leave;
            // 
            // comboBox_group_main
            // 
            comboBox_group_main.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_group_main.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_group_main.Dock = DockStyle.Fill;
            comboBox_group_main.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_group_main.FormattingEnabled = true;
            comboBox_group_main.ItemHeight = 31;
            comboBox_group_main.Location = new Point(3, 50);
            comboBox_group_main.Name = "comboBox_group_main";
            comboBox_group_main.Size = new Size(382, 39);
            comboBox_group_main.TabIndex = 0;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_confirm, 0, 1);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_group, 0, 0);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(782, 183);
            tableLayoutPanel_back.TabIndex = 3;
            // 
            // tableLayoutPanel_confirm
            // 
            tableLayoutPanel_confirm.ColumnCount = 3;
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_confirm.Controls.Add(button_confirm, 1, 0);
            tableLayoutPanel_confirm.Dock = DockStyle.Fill;
            tableLayoutPanel_confirm.Location = new Point(0, 100);
            tableLayoutPanel_confirm.Margin = new Padding(0);
            tableLayoutPanel_confirm.Name = "tableLayoutPanel_confirm";
            tableLayoutPanel_confirm.RowCount = 1;
            tableLayoutPanel_confirm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_confirm.Size = new Size(782, 83);
            tableLayoutPanel_confirm.TabIndex = 4;
            // 
            // button_confirm
            // 
            button_confirm.Dock = DockStyle.Fill;
            button_confirm.FlatAppearance.BorderSize = 0;
            button_confirm.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_confirm.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_confirm.FlatStyle = FlatStyle.Flat;
            button_confirm.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_confirm.Location = new Point(294, 3);
            button_confirm.Name = "button_confirm";
            button_confirm.Size = new Size(194, 77);
            button_confirm.TabIndex = 2;
            button_confirm.TabStop = false;
            button_confirm.Text = "ยืนยัน";
            button_confirm.TextAlign = ContentAlignment.MiddleRight;
            button_confirm.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_confirm.UseVisualStyleBackColor = true;
            button_confirm.Click += button_confirm_Click;
            button_confirm.MouseEnter += button_enter;
            button_confirm.MouseLeave += button_leave;
            // 
            // Form_Load_Template
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(782, 183);
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Load_Template";
            StartPosition = FormStartPosition.CenterParent;
            Text = "เลือกกลุ่มสินค้า";
            tableLayoutPanel_group.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_confirm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBox_group_sub;
        private TableLayoutPanel tableLayoutPanel_group;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel_back;
        private ComboBox comboBox_group_main;
        private Button button_confirm;
        private TableLayoutPanel tableLayoutPanel_confirm;
    }
}