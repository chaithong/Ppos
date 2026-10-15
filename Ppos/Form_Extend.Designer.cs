namespace Ppos
{
    partial class Form_Extend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Extend));
            textBox_Renewal_Code = new TextBox();
            button_Confirm_Code = new Button();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            pictureBox_load = new PictureBox();
            label_exp = new Label();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_confirm = new TableLayoutPanel();
            progressBar = new ProgressBar();
            button_MB = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_load).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_confirm.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Renewal_Code
            // 
            textBox_Renewal_Code.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_Renewal_Code.BackColor = Color.Cyan;
            textBox_Renewal_Code.BorderStyle = BorderStyle.None;
            textBox_Renewal_Code.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Renewal_Code.Location = new Point(0, 114);
            textBox_Renewal_Code.Margin = new Padding(0);
            textBox_Renewal_Code.Name = "textBox_Renewal_Code";
            textBox_Renewal_Code.Size = new Size(800, 31);
            textBox_Renewal_Code.TabIndex = 0;
            textBox_Renewal_Code.TextAlign = HorizontalAlignment.Center;
            textBox_Renewal_Code.Visible = false;
            textBox_Renewal_Code.TextChanged += textBox_Renewal_Code_TextChanged;
            textBox_Renewal_Code.KeyPress += textBox_Renewal_Code_KeyPress;
            // 
            // button_Confirm_Code
            // 
            button_Confirm_Code.BackColor = Color.Cyan;
            button_Confirm_Code.BackgroundImageLayout = ImageLayout.Stretch;
            button_Confirm_Code.Dock = DockStyle.Fill;
            button_Confirm_Code.FlatAppearance.BorderSize = 0;
            button_Confirm_Code.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_Confirm_Code.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_Confirm_Code.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            button_Confirm_Code.Location = new Point(300, 0);
            button_Confirm_Code.Margin = new Padding(0);
            button_Confirm_Code.Name = "button_Confirm_Code";
            button_Confirm_Code.Size = new Size(200, 70);
            button_Confirm_Code.TabIndex = 3;
            button_Confirm_Code.TabStop = false;
            button_Confirm_Code.Text = " ยืนยันรหัส";
            button_Confirm_Code.UseVisualStyleBackColor = false;
            button_Confirm_Code.Visible = false;
            button_Confirm_Code.Click += button_Confirm_Code_Click;
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // pictureBox_load
            // 
            pictureBox_load.Dock = DockStyle.Top;
            pictureBox_load.Image = (Image)resources.GetObject("pictureBox_load.Image");
            pictureBox_load.Location = new Point(3, 228);
            pictureBox_load.Name = "pictureBox_load";
            pictureBox_load.Size = new Size(794, 104);
            pictureBox_load.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_load.TabIndex = 4;
            pictureBox_load.TabStop = false;
            // 
            // label_exp
            // 
            label_exp.BackColor = Color.Transparent;
            label_exp.Dock = DockStyle.Fill;
            label_exp.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label_exp.Location = new Point(3, 5);
            label_exp.Name = "label_exp";
            label_exp.Size = new Size(794, 100);
            label_exp.TabIndex = 5;
            label_exp.Text = "--";
            label_exp.TextAlign = ContentAlignment.MiddleCenter;
            label_exp.Visible = false;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(pictureBox_load, 0, 4);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_confirm, 0, 3);
            tableLayoutPanel_back.Controls.Add(textBox_Renewal_Code, 0, 2);
            tableLayoutPanel_back.Controls.Add(progressBar, 0, 0);
            tableLayoutPanel_back.Controls.Add(label_exp, 0, 1);
            tableLayoutPanel_back.Controls.Add(button_MB, 0, 6);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(0, 0);
            tableLayoutPanel_back.Margin = new Padding(0);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 7;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.Size = new Size(800, 450);
            tableLayoutPanel_back.TabIndex = 6;
            // 
            // tableLayoutPanel_confirm
            // 
            tableLayoutPanel_confirm.ColumnCount = 3;
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel_confirm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_confirm.Controls.Add(button_Confirm_Code, 1, 0);
            tableLayoutPanel_confirm.Dock = DockStyle.Fill;
            tableLayoutPanel_confirm.Location = new Point(0, 155);
            tableLayoutPanel_confirm.Margin = new Padding(0);
            tableLayoutPanel_confirm.Name = "tableLayoutPanel_confirm";
            tableLayoutPanel_confirm.RowCount = 1;
            tableLayoutPanel_confirm.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_confirm.Size = new Size(800, 70);
            tableLayoutPanel_confirm.TabIndex = 7;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.White;
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(0, 0);
            progressBar.Margin = new Padding(0);
            progressBar.Maximum = 10000;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(800, 5);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 0;
            // 
            // button_MB
            // 
            button_MB.BackColor = Color.Cyan;
            button_MB.Dock = DockStyle.Fill;
            button_MB.FlatAppearance.BorderSize = 0;
            button_MB.FlatAppearance.MouseOverBackColor = Color.Cyan;
            button_MB.FlatStyle = FlatStyle.Flat;
            button_MB.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_MB.Location = new Point(0, 400);
            button_MB.Margin = new Padding(0);
            button_MB.Name = "button_MB";
            button_MB.Size = new Size(800, 50);
            button_MB.TabIndex = 8;
            button_MB.Text = "--";
            button_MB.UseVisualStyleBackColor = false;
            button_MB.Visible = false;
            button_MB.Click += button_MB_Click;
            // 
            // Form_Extend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel_back);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Extend";
            Text = "Form_Extend";
            Load += Form_Extend_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_load).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_back.PerformLayout();
            tableLayoutPanel_confirm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox_Renewal_Code;
        private Button button_Confirm_Code;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private PictureBox pictureBox_load;
        private Label label_exp;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_confirm;
        private ProgressBar progressBar;
        private Button button_MB;
    }
}