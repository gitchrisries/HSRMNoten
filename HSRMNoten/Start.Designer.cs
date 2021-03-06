
namespace HSRMNoten
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.rbNonDual = new System.Windows.Forms.RadioButton();
            this.rbDual = new System.Windows.Forms.RadioButton();
            this.rbFirefox = new System.Windows.Forms.RadioButton();
            this.rbChrome = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSaveUserData = new System.Windows.Forms.CheckBox();
            this.lblgetData = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(178, 166);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(125, 27);
            this.tbPassword.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(398, 232);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 29);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Start";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(43, 141);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(78, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(176, 141);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // rbNonDual
            // 
            this.rbNonDual.AutoSize = true;
            this.rbNonDual.Checked = true;
            this.rbNonDual.Location = new System.Drawing.Point(59, 44);
            this.rbNonDual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbNonDual.Name = "rbNonDual";
            this.rbNonDual.Size = new System.Drawing.Size(44, 24);
            this.rbNonDual.TabIndex = 5;
            this.rbNonDual.TabStop = true;
            this.rbNonDual.Text = "AI";
            this.rbNonDual.UseVisualStyleBackColor = true;
            this.rbNonDual.CheckedChanged += new System.EventHandler(this.rbNonDual_CheckedChanged);
            // 
            // rbDual
            // 
            this.rbDual.AutoSize = true;
            this.rbDual.Location = new System.Drawing.Point(113, 44);
            this.rbDual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbDual.Name = "rbDual";
            this.rbDual.Size = new System.Drawing.Size(79, 24);
            this.rbDual.TabIndex = 6;
            this.rbDual.Text = "AI Dual";
            this.rbDual.UseVisualStyleBackColor = true;
            this.rbDual.CheckedChanged += new System.EventHandler(this.rbDual_CheckedChanged);
            // 
            // rbFirefox
            // 
            this.rbFirefox.AutoSize = true;
            this.rbFirefox.Location = new System.Drawing.Point(130, 25);
            this.rbFirefox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbFirefox.Name = "rbFirefox";
            this.rbFirefox.Size = new System.Drawing.Size(77, 24);
            this.rbFirefox.TabIndex = 7;
            this.rbFirefox.TabStop = true;
            this.rbFirefox.Text = "FireFox";
            this.rbFirefox.UseVisualStyleBackColor = true;
            this.rbFirefox.CheckedChanged += new System.EventHandler(this.rbFirefox_CheckedChanged);
            // 
            // rbChrome
            // 
            this.rbChrome.AutoSize = true;
            this.rbChrome.Checked = true;
            this.rbChrome.Location = new System.Drawing.Point(42, 25);
            this.rbChrome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbChrome.Name = "rbChrome";
            this.rbChrome.Size = new System.Drawing.Size(82, 24);
            this.rbChrome.TabIndex = 8;
            this.rbChrome.TabStop = true;
            this.rbChrome.Text = "Chrome";
            this.rbChrome.UseVisualStyleBackColor = true;
            this.rbChrome.CheckedChanged += new System.EventHandler(this.rbChrome_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbFirefox);
            this.panel1.Controls.Add(this.rbChrome);
            this.panel1.Location = new System.Drawing.Point(222, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 100);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Selected browser must be installed.";
            // 
            // cbSaveUserData
            // 
            this.cbSaveUserData.AutoSize = true;
            this.cbSaveUserData.Location = new System.Drawing.Point(323, 169);
            this.cbSaveUserData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSaveUserData.Name = "cbSaveUserData";
            this.cbSaveUserData.Size = new System.Drawing.Size(131, 24);
            this.cbSaveUserData.TabIndex = 10;
            this.cbSaveUserData.Text = "Save User Data";
            this.cbSaveUserData.UseVisualStyleBackColor = true;
            // 
            // lblgetData
            // 
            this.lblgetData.AutoSize = true;
            this.lblgetData.Location = new System.Drawing.Point(235, 236);
            this.lblgetData.Name = "lblgetData";
            this.lblgetData.Size = new System.Drawing.Size(157, 20);
            this.lblgetData.TabIndex = 11;
            this.lblgetData.Text = "Get Data... Please Wait";
            this.lblgetData.Visible = false;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(46, 166);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(127, 27);
            this.tbUser.TabIndex = 0;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 276);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblgetData);
            this.Controls.Add(this.cbSaveUserData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbDual);
            this.Controls.Add(this.rbNonDual);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.tbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Start_FormClosing);
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.RadioButton rbNonDual;
        private System.Windows.Forms.RadioButton rbDual;
        private System.Windows.Forms.RadioButton rbFirefox;
        private System.Windows.Forms.RadioButton rbChrome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSaveUserData;
        private System.Windows.Forms.Label lblgetData;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label1;
    }
}