namespace Ppos
{
    partial class Form_Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Check));
            customGroupBox_back = new CustomGroupBox();
            panel_check = new Panel();
            customGroupBox_button = new CustomGroupBox();
            tableLayoutPanel_button = new TableLayoutPanel();
            button_check_item = new Button();
            button_check_promotion = new Button();
            button_check_member = new Button();
            button_exit = new Button();
            button_check_invoice = new Button();
            tableLayoutPanel_back = new TableLayoutPanel();
            customGroupBox_back.SuspendLayout();
            customGroupBox_button.SuspendLayout();
            tableLayoutPanel_button.SuspendLayout();
            tableLayoutPanel_back.SuspendLayout();
            SuspendLayout();
            // 
            // customGroupBox_back
            // 
            customGroupBox_back.BackColor = Color.Transparent;
            customGroupBox_back.BorderColor = Color.White;
            customGroupBox_back.BorderRadius = 30;
            customGroupBox_back.BorderThickness = 20;
            customGroupBox_back.Controls.Add(panel_check);
            customGroupBox_back.Dock = DockStyle.Fill;
            customGroupBox_back.Font = new Font("Segoe UI", 1F);
            customGroupBox_back.Location = new Point(0, 120);
            customGroupBox_back.Margin = new Padding(0, 0, 10, 3);
            customGroupBox_back.Name = "customGroupBox_back";
            customGroupBox_back.Padding = new Padding(10);
            customGroupBox_back.Size = new Size(720, 327);
            customGroupBox_back.TabIndex = 1;
            customGroupBox_back.TabStop = false;
            customGroupBox_back.Text = " ";
            // 
            // panel_check
            // 
            panel_check.BackColor = Color.White;
            panel_check.Dock = DockStyle.Fill;
            panel_check.Location = new Point(10, 13);
            panel_check.Name = "panel_check";
            panel_check.Size = new Size(700, 304);
            panel_check.TabIndex = 2;
            // 
            // customGroupBox_button
            // 
            customGroupBox_button.BackColor = Color.Transparent;
            customGroupBox_button.BorderColor = Color.White;
            customGroupBox_button.BorderRadius = 30;
            customGroupBox_button.BorderThickness = 20;
            customGroupBox_button.Controls.Add(tableLayoutPanel_button);
            customGroupBox_button.Dock = DockStyle.Fill;
            customGroupBox_button.Font = new Font("Segoe UI", 1F);
            customGroupBox_button.Location = new Point(0, 0);
            customGroupBox_button.Margin = new Padding(0, 0, 10, 10);
            customGroupBox_button.Name = "customGroupBox_button";
            customGroupBox_button.Padding = new Padding(10);
            customGroupBox_button.Size = new Size(720, 110);
            customGroupBox_button.TabIndex = 2;
            customGroupBox_button.TabStop = false;
            customGroupBox_button.Text = " ";
            // 
            // tableLayoutPanel_button
            // 
            tableLayoutPanel_button.BackColor = Color.White;
            tableLayoutPanel_button.ColumnCount = 5;
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.000494F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0005016F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0005035F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9985027F));
            tableLayoutPanel_button.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999981F));
            tableLayoutPanel_button.Controls.Add(button_check_item, 0, 0);
            tableLayoutPanel_button.Controls.Add(button_check_promotion, 1, 0);
            tableLayoutPanel_button.Controls.Add(button_check_member, 2, 0);
            tableLayoutPanel_button.Controls.Add(button_exit, 4, 0);
            tableLayoutPanel_button.Controls.Add(button_check_invoice, 3, 0);
            tableLayoutPanel_button.Dock = DockStyle.Fill;
            tableLayoutPanel_button.Location = new Point(10, 13);
            tableLayoutPanel_button.Name = "tableLayoutPanel_button";
            tableLayoutPanel_button.RowCount = 1;
            tableLayoutPanel_button.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_button.Size = new Size(700, 87);
            tableLayoutPanel_button.TabIndex = 0;
            // 
            // button_check_item
            // 
            button_check_item.BackColor = Color.White;
            button_check_item.Dock = DockStyle.Fill;
            button_check_item.FlatAppearance.BorderSize = 0;
            button_check_item.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_check_item.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_check_item.FlatStyle = FlatStyle.Flat;
            button_check_item.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_check_item.Location = new Point(3, 3);
            button_check_item.Name = "button_check_item";
            button_check_item.Size = new Size(134, 81);
            button_check_item.TabIndex = 0;
            button_check_item.Text = "สินค้า";
            button_check_item.TextAlign = ContentAlignment.MiddleRight;
            button_check_item.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_check_item.UseVisualStyleBackColor = false;
            button_check_item.Click += Check_Click;
            button_check_item.MouseEnter += button_check_item_MouseEnter;
            button_check_item.MouseLeave += button_check_item_MouseLeave;
            // 
            // button_check_promotion
            // 
            button_check_promotion.BackColor = Color.White;
            button_check_promotion.Dock = DockStyle.Fill;
            button_check_promotion.FlatAppearance.BorderSize = 0;
            button_check_promotion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_check_promotion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_check_promotion.FlatStyle = FlatStyle.Flat;
            button_check_promotion.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_check_promotion.Location = new Point(143, 3);
            button_check_promotion.Name = "button_check_promotion";
            button_check_promotion.Size = new Size(134, 81);
            button_check_promotion.TabIndex = 0;
            button_check_promotion.Text = "โปรโมชั่น";
            button_check_promotion.TextAlign = ContentAlignment.MiddleRight;
            button_check_promotion.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_check_promotion.UseVisualStyleBackColor = false;
            button_check_promotion.Click += Check_Click;
            button_check_promotion.MouseEnter += button_check_item_MouseEnter;
            button_check_promotion.MouseLeave += button_check_item_MouseLeave;
            // 
            // button_check_member
            // 
            button_check_member.BackColor = Color.White;
            button_check_member.Dock = DockStyle.Fill;
            button_check_member.FlatAppearance.BorderSize = 0;
            button_check_member.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_check_member.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_check_member.FlatStyle = FlatStyle.Flat;
            button_check_member.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_check_member.Location = new Point(283, 3);
            button_check_member.Name = "button_check_member";
            button_check_member.Size = new Size(134, 81);
            button_check_member.TabIndex = 0;
            button_check_member.Text = "สมาชิก";
            button_check_member.TextAlign = ContentAlignment.MiddleRight;
            button_check_member.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_check_member.UseVisualStyleBackColor = false;
            button_check_member.Click += Check_Click;
            button_check_member.MouseEnter += button_check_item_MouseEnter;
            button_check_member.MouseLeave += button_check_item_MouseLeave;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.Transparent;
            button_exit.Dock = DockStyle.Fill;
            button_exit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_exit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_exit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_exit.Location = new Point(562, 3);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(135, 81);
            button_exit.TabIndex = 1;
            button_exit.Text = "ออก";
            button_exit.TextAlign = ContentAlignment.MiddleRight;
            button_exit.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            button_exit.MouseEnter += button_check_item_MouseEnter;
            button_exit.MouseLeave += button_check_item_MouseLeave;
            // 
            // button_check_invoice
            // 
            button_check_invoice.BackColor = Color.White;
            button_check_invoice.BackgroundImageLayout = ImageLayout.Zoom;
            button_check_invoice.Dock = DockStyle.Fill;
            button_check_invoice.FlatAppearance.BorderSize = 0;
            button_check_invoice.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_check_invoice.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_check_invoice.FlatStyle = FlatStyle.Flat;
            button_check_invoice.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            button_check_invoice.Location = new Point(423, 3);
            button_check_invoice.Name = "button_check_invoice";
            button_check_invoice.Size = new Size(133, 81);
            button_check_invoice.TabIndex = 2;
            button_check_invoice.Text = "บิลขาย";
            button_check_invoice.TextAlign = ContentAlignment.MiddleRight;
            button_check_invoice.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_check_invoice.UseVisualStyleBackColor = false;
            button_check_invoice.Click += Check_Click;
            button_check_invoice.MouseEnter += button_check_item_MouseEnter;
            button_check_invoice.MouseLeave += button_check_item_MouseLeave;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(customGroupBox_button, 0, 0);
            tableLayoutPanel_back.Controls.Add(customGroupBox_back, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0, 0, 10, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 2;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Size = new Size(730, 450);
            tableLayoutPanel_back.TabIndex = 3;
            // 
            // Form_Check
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cyan;
            ClientSize = new Size(730, 450);
            ControlBox = false;
            Controls.Add(tableLayoutPanel_back);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "Form_Check";
            StartPosition = FormStartPosition.CenterParent;
            FormClosing += Form_Check_FormClosing;
            customGroupBox_back.ResumeLayout(false);
            customGroupBox_button.ResumeLayout(false);
            tableLayoutPanel_button.ResumeLayout(false);
            tableLayoutPanel_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private CustomGroupBox customGroupBox_back;
        private CustomGroupBox customGroupBox_button;
        private TableLayoutPanel tableLayoutPanel_button;
        private Button button_check_item;
        private Button button_check_promotion;
        private Button button_check_member;
        private Button button_exit;
        private Panel panel_check;
        private Button button_check_invoice;
        private TableLayoutPanel tableLayoutPanel_back;
    }
}