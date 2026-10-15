namespace Ppos
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            pictureBox_logo = new PictureBox();
            tableLayoutPanel_back = new TableLayoutPanel();
            tableLayoutPanel_user = new TableLayoutPanel();
            textBox_user = new TextBox();
            label_user = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label_pass = new Label();
            textBox_pass = new TextBox();
            panel_logo = new Panel();
            button_exit = new Button();
            label_version = new Label();
            button_login = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox_save_user = new PictureBox();
            pictureBox_save_pass = new PictureBox();
            label_save_user = new Label();
            label_save_pass = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            tableLayoutPanel_back.SuspendLayout();
            tableLayoutPanel_user.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel_logo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_save_user).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_save_pass).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Dock = DockStyle.Bottom;
            pictureBox_logo.Location = new Point(0, 16);
            pictureBox_logo.Margin = new Padding(0);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(380, 134);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 0;
            pictureBox_logo.TabStop = false;
            pictureBox_logo.MouseEnter += pictureBox_logo_MouseEnter;
            pictureBox_logo.MouseLeave += pictureBox_logo_MouseLeave;
            // 
            // tableLayoutPanel_back
            // 
            tableLayoutPanel_back.BackColor = Color.FromArgb(192, 255, 255);
            tableLayoutPanel_back.ColumnCount = 1;
            tableLayoutPanel_back.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel_user, 0, 2);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel_back.Controls.Add(panel_logo, 0, 0);
            tableLayoutPanel_back.Controls.Add(label_version, 0, 7);
            tableLayoutPanel_back.Controls.Add(button_login, 0, 5);
            tableLayoutPanel_back.Controls.Add(tableLayoutPanel1, 0, 4);
            tableLayoutPanel_back.Dock = DockStyle.Fill;
            tableLayoutPanel_back.Location = new Point(10, 10);
            tableLayoutPanel_back.Name = "tableLayoutPanel_back";
            tableLayoutPanel_back.RowCount = 8;
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_back.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_back.Size = new Size(380, 430);
            tableLayoutPanel_back.TabIndex = 1;
            // 
            // tableLayoutPanel_user
            // 
            tableLayoutPanel_user.ColumnCount = 2;
            tableLayoutPanel_user.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel_user.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel_user.Controls.Add(textBox_user, 1, 0);
            tableLayoutPanel_user.Controls.Add(label_user, 0, 0);
            tableLayoutPanel_user.Dock = DockStyle.Fill;
            tableLayoutPanel_user.Location = new Point(0, 155);
            tableLayoutPanel_user.Margin = new Padding(0);
            tableLayoutPanel_user.Name = "tableLayoutPanel_user";
            tableLayoutPanel_user.RowCount = 1;
            tableLayoutPanel_user.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_user.Size = new Size(380, 50);
            tableLayoutPanel_user.TabIndex = 1;
            // 
            // textBox_user
            // 
            textBox_user.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_user.BackColor = Color.Cyan;
            textBox_user.BorderStyle = BorderStyle.None;
            textBox_user.Font = new Font("Segoe UI", 18F);
            textBox_user.Location = new Point(110, 5);
            textBox_user.Margin = new Padding(0);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(270, 40);
            textBox_user.TabIndex = 0;
            textBox_user.TextChanged += textBox_TextChanged;
            textBox_user.KeyDown += textBox_user_KeyDown;
            textBox_user.KeyPress += textBox_KeyPress;
            textBox_user.MouseEnter += textBox_user_MouseEnter;
            textBox_user.MouseLeave += textBox_user_MouseLeave;
            // 
            // label_user
            // 
            label_user.Dock = DockStyle.Fill;
            label_user.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_user.ForeColor = Color.DimGray;
            label_user.Location = new Point(3, 0);
            label_user.Name = "label_user";
            label_user.Size = new Size(104, 50);
            label_user.TabIndex = 1;
            label_user.Text = "ผู้ใช้ :";
            label_user.TextAlign = ContentAlignment.MiddleRight;
            label_user.MouseEnter += textBox_user_MouseEnter;
            label_user.MouseLeave += textBox_user_MouseLeave;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label_pass, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox_pass, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 205);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(380, 50);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label_pass
            // 
            label_pass.Dock = DockStyle.Fill;
            label_pass.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label_pass.ForeColor = Color.DimGray;
            label_pass.Location = new Point(3, 0);
            label_pass.Name = "label_pass";
            label_pass.Size = new Size(104, 50);
            label_pass.TabIndex = 1;
            label_pass.Text = "รหัส :";
            label_pass.TextAlign = ContentAlignment.MiddleRight;
            label_pass.MouseEnter += textBox_pass_MouseEnter;
            label_pass.MouseLeave += textBox_pass_MouseLeave;
            // 
            // textBox_pass
            // 
            textBox_pass.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_pass.BackColor = Color.Cyan;
            textBox_pass.BorderStyle = BorderStyle.None;
            textBox_pass.Font = new Font("Segoe UI", 18F);
            textBox_pass.Location = new Point(110, 5);
            textBox_pass.Margin = new Padding(0);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.PasswordChar = '*';
            textBox_pass.Size = new Size(270, 40);
            textBox_pass.TabIndex = 1;
            textBox_pass.TextChanged += textBox_TextChanged;
            textBox_pass.KeyDown += textBox_pass_KeyDown;
            textBox_pass.KeyPress += textBox_KeyPress;
            textBox_pass.MouseEnter += textBox_pass_MouseEnter;
            textBox_pass.MouseLeave += textBox_pass_MouseLeave;
            // 
            // panel_logo
            // 
            panel_logo.BackColor = Color.Transparent;
            panel_logo.Controls.Add(button_exit);
            panel_logo.Controls.Add(pictureBox_logo);
            panel_logo.Dock = DockStyle.Fill;
            panel_logo.Location = new Point(0, 0);
            panel_logo.Margin = new Padding(0);
            panel_logo.Name = "panel_logo";
            panel_logo.Size = new Size(380, 150);
            panel_logo.TabIndex = 4;
            // 
            // button_exit
            // 
            button_exit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_exit.BackgroundImage = Properties.Resources.exitProgram;
            button_exit.BackgroundImageLayout = ImageLayout.Zoom;
            button_exit.FlatAppearance.BorderSize = 0;
            button_exit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_exit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_exit.FlatStyle = FlatStyle.Flat;
            button_exit.Location = new Point(337, 3);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(40, 30);
            button_exit.TabIndex = 1;
            button_exit.TabStop = false;
            button_exit.UseVisualStyleBackColor = true;
            button_exit.Click += button_exit_Click;
            // 
            // label_version
            // 
            label_version.Dock = DockStyle.Fill;
            label_version.Location = new Point(3, 410);
            label_version.Name = "label_version";
            label_version.Size = new Size(374, 20);
            label_version.TabIndex = 2;
            label_version.Text = "Version 1.1";
            label_version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_login
            // 
            button_login.BackgroundImageLayout = ImageLayout.Center;
            button_login.Dock = DockStyle.Fill;
            button_login.FlatAppearance.BorderSize = 0;
            button_login.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_login.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_login.FlatStyle = FlatStyle.Flat;
            button_login.Image = Properties.Resources.logins;
            button_login.Location = new Point(3, 318);
            button_login.Name = "button_login";
            button_login.Size = new Size(374, 84);
            button_login.TabIndex = 3;
            button_login.TabStop = false;
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox_save_user, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox_save_pass, 3, 0);
            tableLayoutPanel1.Controls.Add(label_save_user, 2, 0);
            tableLayoutPanel1.Controls.Add(label_save_pass, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 255);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(380, 60);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // pictureBox_save_user
            // 
            pictureBox_save_user.Dock = DockStyle.Fill;
            pictureBox_save_user.Image = Properties.Resources.disable_check;
            pictureBox_save_user.Location = new Point(40, 0);
            pictureBox_save_user.Margin = new Padding(0);
            pictureBox_save_user.Name = "pictureBox_save_user";
            pictureBox_save_user.Size = new Size(40, 60);
            pictureBox_save_user.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_save_user.TabIndex = 0;
            pictureBox_save_user.TabStop = false;
            pictureBox_save_user.Click += pictureBox_save_user_Click;
            pictureBox_save_user.MouseEnter += label_save_user_MouseEnter;
            pictureBox_save_user.MouseLeave += label_save_user_MouseLeave;
            // 
            // pictureBox_save_pass
            // 
            pictureBox_save_pass.Dock = DockStyle.Fill;
            pictureBox_save_pass.Image = Properties.Resources.disable_check;
            pictureBox_save_pass.Location = new Point(190, 0);
            pictureBox_save_pass.Margin = new Padding(0);
            pictureBox_save_pass.Name = "pictureBox_save_pass";
            pictureBox_save_pass.Size = new Size(40, 60);
            pictureBox_save_pass.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_save_pass.TabIndex = 0;
            pictureBox_save_pass.TabStop = false;
            pictureBox_save_pass.Click += pictureBox_save_pass_Click;
            pictureBox_save_pass.MouseEnter += label_save_pass_MouseEnter;
            pictureBox_save_pass.MouseLeave += label_save_pass_MouseLeave;
            // 
            // label_save_user
            // 
            label_save_user.Dock = DockStyle.Fill;
            label_save_user.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label_save_user.ForeColor = Color.DimGray;
            label_save_user.Location = new Point(83, 0);
            label_save_user.Name = "label_save_user";
            label_save_user.Size = new Size(104, 60);
            label_save_user.TabIndex = 1;
            label_save_user.Text = "บันทึกผู้ใช้";
            label_save_user.TextAlign = ContentAlignment.MiddleLeft;
            label_save_user.MouseEnter += label_save_user_MouseEnter;
            label_save_user.MouseLeave += label_save_user_MouseLeave;
            // 
            // label_save_pass
            // 
            label_save_pass.Dock = DockStyle.Fill;
            label_save_pass.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label_save_pass.ForeColor = Color.DimGray;
            label_save_pass.Location = new Point(233, 0);
            label_save_pass.Name = "label_save_pass";
            label_save_pass.Size = new Size(104, 60);
            label_save_pass.TabIndex = 1;
            label_save_pass.Text = "บันทึกรหัส";
            label_save_pass.TextAlign = ContentAlignment.MiddleLeft;
            label_save_pass.MouseEnter += label_save_pass_MouseEnter;
            label_save_pass.MouseLeave += label_save_pass_MouseLeave;
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Cyan;
            ClientSize = new Size(400, 450);
            ControlBox = false;
            Controls.Add(tableLayoutPanel_back);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Login";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form_Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            tableLayoutPanel_back.ResumeLayout(false);
            tableLayoutPanel_user.ResumeLayout(false);
            tableLayoutPanel_user.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel_logo.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_save_user).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_save_pass).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_logo;
        private Panel panel_back;
        private TableLayoutPanel tableLayoutPanel_back;
        private TableLayoutPanel tableLayoutPanel_user;
        private TextBox textBox_user;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_user;
        private Label label_pass;
        private TextBox textBox_pass;
        private Label label_version;
        private Button button_login;
        private Panel panel_logo;
        private Button button_exit;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_save_user;
        private PictureBox pictureBox_save_pass;
        private Label label_save_user;
        private Label label_save_pass;
    }
}