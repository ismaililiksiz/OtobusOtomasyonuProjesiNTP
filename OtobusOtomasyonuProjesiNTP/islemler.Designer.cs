namespace OtobusOtomasyonuProjesiNTP
{
    partial class islemler
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
            this.İşlemler = new System.Windows.Forms.GroupBox();
            this.cikisbtn = new System.Windows.Forms.Button();
            this.biletbtn = new System.Windows.Forms.Button();
            this.uyebtn = new System.Windows.Forms.Button();
            this.seferbtn = new System.Windows.Forms.Button();
            this.İşlemler.SuspendLayout();
            this.SuspendLayout();
            // 
            // İşlemler
            // 
            this.İşlemler.Controls.Add(this.cikisbtn);
            this.İşlemler.Controls.Add(this.biletbtn);
            this.İşlemler.Controls.Add(this.uyebtn);
            this.İşlemler.Controls.Add(this.seferbtn);
            this.İşlemler.Location = new System.Drawing.Point(46, 47);
            this.İşlemler.Name = "İşlemler";
            this.İşlemler.Size = new System.Drawing.Size(673, 278);
            this.İşlemler.TabIndex = 0;
            this.İşlemler.TabStop = false;
            this.İşlemler.Text = "groupBox1";
            // 
            // cikisbtn
            // 
            this.cikisbtn.Location = new System.Drawing.Point(47, 216);
            this.cikisbtn.Name = "cikisbtn";
            this.cikisbtn.Size = new System.Drawing.Size(115, 37);
            this.cikisbtn.TabIndex = 1;
            this.cikisbtn.Text = "Çıkış";
            this.cikisbtn.UseVisualStyleBackColor = true;
            this.cikisbtn.Click += new System.EventHandler(this.cikisbtn_Click);
            // 
            // biletbtn
            // 
            this.biletbtn.Location = new System.Drawing.Point(453, 104);
            this.biletbtn.Name = "biletbtn";
            this.biletbtn.Size = new System.Drawing.Size(147, 57);
            this.biletbtn.TabIndex = 2;
            this.biletbtn.Text = "Bilet İşlemleri";
            this.biletbtn.UseVisualStyleBackColor = true;
            this.biletbtn.Click += new System.EventHandler(this.biletbtn_Click);
            // 
            // uyebtn
            // 
            this.uyebtn.Location = new System.Drawing.Point(251, 104);
            this.uyebtn.Name = "uyebtn";
            this.uyebtn.Size = new System.Drawing.Size(147, 57);
            this.uyebtn.TabIndex = 1;
            this.uyebtn.Text = "Üye İşlemleri";
            this.uyebtn.UseVisualStyleBackColor = true;
            this.uyebtn.Click += new System.EventHandler(this.uyebtn_Click);
            // 
            // seferbtn
            // 
            this.seferbtn.Location = new System.Drawing.Point(47, 104);
            this.seferbtn.Name = "seferbtn";
            this.seferbtn.Size = new System.Drawing.Size(147, 57);
            this.seferbtn.TabIndex = 0;
            this.seferbtn.Text = "Sefer İşlemleri";
            this.seferbtn.UseVisualStyleBackColor = true;
            this.seferbtn.Click += new System.EventHandler(this.seferbtn_Click);
            // 
            // islemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.İşlemler);
            this.Name = "islemler";
            this.Text = "islemler";
            this.İşlemler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox İşlemler;
        private System.Windows.Forms.Button biletbtn;
        private System.Windows.Forms.Button uyebtn;
        private System.Windows.Forms.Button seferbtn;
        private System.Windows.Forms.Button cikisbtn;
    }
}