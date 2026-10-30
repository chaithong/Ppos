namespace Ppos
{
    partial class Form_Cash_Change
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Cash_Change));
            button_OK = new Button();
            label_cash_change_title = new Label();
            tableLayoutPanel_back = new TableLayoutPanel();
            label_cash_change = new Label();
            tableLayoutPanel_back.SuspendLayout();
            SuspendLayout();
            // 
            // button_OK
            // 
            button_OK.Dock = DockStyle.Fill;
            button_OK.FlatAppearance.BorderSize = 0;
            button_OK.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_OK.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_OK.FlatStyle = FlatStyle.Flat;
            button_OK.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_OK.Location = new Point(3, 391);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(776, 188);
            button_OK.TabIndex = 0;
            button_OK.Text = "ตกลง";
            button_OK.TextAlign = ContentAlignment.MiddleRight;
            button_OK.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += button_OK_Click;
            button_OK.KeyDown += button_OK_KeyDown;
            button_OK.MouseEnter += button_OK_MouseEnter;
            button_OK.MouseLeave += button_OK_MouseLeave;
            // 
            // label_cash_change_title
            // 
            label_cash_change_title.AutoEllipsis = true;
            label_cash_change_title.Dock = DockStyle.Fill;
            label_cash_change_title.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_cash_change_title.Location = new Point(3, 0);
            label_cash_change_title.Name = "label_cash_change_title";
            label_cash_change_title.Size = new Size(776, 194);
            label_cash_change_title.TabIndex = 1;
            label_cash_change_title.Text = "เงินทอน";
            label_cash_change_title.TextAlign = ContentAlignment.MiddleCenter;
            label_cash_change_title.MouseEnter += label_enter;
            label_cash_change_title.MouseLeave += label_leave;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Controls.Add(label_cash_change_title, 0, 0);
            tableLayoutPanel_back.Controls.Add(button_OK, 0, 2);
            tableLayoutPanel_back.Controls.Add(label_cash_change, 0, 1);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 3;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_back.Size = new Size(782, 582);
            tableLayoutPanel_back.TabIndex = 2;
            // 
            // label_cash_change
            // 
            label_cash_change.AutoEllipsis = true;
            label_cash_change.Dock = DockStyle.Fill;
            label_cash_change.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_cash_change.Location = new Point(3, 194);
            label_cash_change.Name = "label_cash_change";
            label_cash_change.Size = new Size(776, 194);
            label_cash_change.TabIndex = 1;
            label_cash_change.Text = "-";
            label_cash_change.TextAlign = ContentAlignment.MiddleCenter;
            label_cash_change.MouseEnter += label_enter;
            label_cash_change.MouseLeave += label_leave;
            // 
            // Form_Cash_Change
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(782, 582);
            ControlBox = false;
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Cash_Change";
            StartPosition = FormStartPosition.CenterParent;
            tableLayoutPanel_back.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button_OK;
        private Label label_cash_change_title;
        private TableLayoutPanel tableLayoutPanel_back;
        private Label label_cash_change;
    }
}