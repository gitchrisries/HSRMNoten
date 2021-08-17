
namespace HSRMNoten.Forms
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbMinimizeTray = new System.Windows.Forms.CheckBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.cbStartUp = new System.Windows.Forms.CheckBox();
            this.cbStartMinimzed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(187, 161);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbMinimizeTray
            // 
            this.cbMinimizeTray.AutoSize = true;
            this.cbMinimizeTray.Location = new System.Drawing.Point(31, 24);
            this.cbMinimizeTray.Name = "cbMinimizeTray";
            this.cbMinimizeTray.Size = new System.Drawing.Size(141, 24);
            this.cbMinimizeTray.TabIndex = 2;
            this.cbMinimizeTray.Text = "Minimize to Tray";
            this.cbMinimizeTray.UseVisualStyleBackColor = true;
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.Location = new System.Drawing.Point(31, 84);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(104, 24);
            this.cbAutoLogin.TabIndex = 3;
            this.cbAutoLogin.Text = "Auto Login";
            this.cbAutoLogin.UseVisualStyleBackColor = true;
            this.cbAutoLogin.CheckedChanged += new System.EventHandler(this.cbAutoLogin_CheckedChanged);
            // 
            // cbStartUp
            // 
            this.cbStartUp.AutoSize = true;
            this.cbStartUp.Location = new System.Drawing.Point(31, 54);
            this.cbStartUp.Name = "cbStartUp";
            this.cbStartUp.Size = new System.Drawing.Size(190, 24);
            this.cbStartUp.TabIndex = 4;
            this.cbStartUp.Text = "Run at Windows Startup";
            this.cbStartUp.UseVisualStyleBackColor = true;
            // 
            // cbStartMinimzed
            // 
            this.cbStartMinimzed.AutoSize = true;
            this.cbStartMinimzed.Enabled = false;
            this.cbStartMinimzed.Location = new System.Drawing.Point(31, 114);
            this.cbStartMinimzed.Name = "cbStartMinimzed";
            this.cbStartMinimzed.Size = new System.Drawing.Size(136, 24);
            this.cbStartMinimzed.TabIndex = 5;
            this.cbStartMinimzed.Text = "Start minimized";
            this.cbStartMinimzed.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 203);
            this.Controls.Add(this.cbStartMinimzed);
            this.Controls.Add(this.cbStartUp);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.cbMinimizeTray);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbMinimizeTray;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.CheckBox cbStartUp;
        private System.Windows.Forms.CheckBox cbStartMinimzed;
    }
}