namespace DOPAnote
{
    partial class ReplaceForm
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
            this.btnfind = new System.Windows.Forms.Button();
            this.btnreplace = new System.Windows.Forms.Button();
            this.lbfind = new System.Windows.Forms.Label();
            this.lbreplace = new System.Windows.Forms.Label();
            this.txtboxfind = new System.Windows.Forms.TextBox();
            this.txtboxreplace = new System.Windows.Forms.TextBox();
            this.btnreplaceall = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(33, 151);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(69, 20);
            this.btnfind.TabIndex = 0;
            this.btnfind.Text = "Find...";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // btnreplace
            // 
            this.btnreplace.Location = new System.Drawing.Point(110, 151);
            this.btnreplace.Name = "btnreplace";
            this.btnreplace.Size = new System.Drawing.Size(69, 20);
            this.btnreplace.TabIndex = 1;
            this.btnreplace.Text = "Replace";
            this.btnreplace.UseVisualStyleBackColor = true;
            this.btnreplace.Click += new System.EventHandler(this.btnreplace_Click);
            // 
            // lbfind
            // 
            this.lbfind.AutoSize = true;
            this.lbfind.Location = new System.Drawing.Point(30, 38);
            this.lbfind.Name = "lbfind";
            this.lbfind.Size = new System.Drawing.Size(57, 13);
            this.lbfind.TabIndex = 2;
            this.lbfind.Text = "Find Text: ";
            // 
            // lbreplace
            // 
            this.lbreplace.AutoSize = true;
            this.lbreplace.Location = new System.Drawing.Point(30, 100);
            this.lbreplace.Name = "lbreplace";
            this.lbreplace.Size = new System.Drawing.Size(72, 13);
            this.lbreplace.TabIndex = 3;
            this.lbreplace.Text = "Replace With";
            // 
            // txtboxfind
            // 
            this.txtboxfind.Location = new System.Drawing.Point(110, 35);
            this.txtboxfind.Name = "txtboxfind";
            this.txtboxfind.Size = new System.Drawing.Size(223, 20);
            this.txtboxfind.TabIndex = 4;
            // 
            // txtboxreplace
            // 
            this.txtboxreplace.Location = new System.Drawing.Point(109, 98);
            this.txtboxreplace.Name = "txtboxreplace";
            this.txtboxreplace.Size = new System.Drawing.Size(224, 20);
            this.txtboxreplace.TabIndex = 5;
            // 
            // btnreplaceall
            // 
            this.btnreplaceall.Location = new System.Drawing.Point(185, 151);
            this.btnreplaceall.Name = "btnreplaceall";
            this.btnreplaceall.Size = new System.Drawing.Size(69, 20);
            this.btnreplaceall.TabIndex = 6;
            this.btnreplaceall.Text = "Replace All";
            this.btnreplaceall.UseVisualStyleBackColor = true;
            this.btnreplaceall.Click += new System.EventHandler(this.btnreplaceall_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(264, 151);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(69, 20);
            this.btnclear.TabIndex = 7;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 208);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnreplaceall);
            this.Controls.Add(this.txtboxreplace);
            this.Controls.Add(this.txtboxfind);
            this.Controls.Add(this.lbreplace);
            this.Controls.Add(this.lbfind);
            this.Controls.Add(this.btnreplace);
            this.Controls.Add(this.btnfind);
            this.Name = "ReplaceForm";
            this.Text = "Replace Text";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReplaceForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button btnreplace;
        private System.Windows.Forms.Label lbfind;
        private System.Windows.Forms.Label lbreplace;
        private System.Windows.Forms.TextBox txtboxfind;
        private System.Windows.Forms.TextBox txtboxreplace;
        private System.Windows.Forms.Button btnreplaceall;
        private System.Windows.Forms.Button btnclear;
    }
}