namespace Wczytywanie_ZPliku
{
    partial class Form1
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
            this.btnWybierz = new System.Windows.Forms.Button();
            this.tbScieszka = new System.Windows.Forms.TextBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tbScieszka2 = new System.Windows.Forms.TextBox();
            this.btnWybierz2 = new System.Windows.Forms.Button();
            this.buttonGeneruj = new System.Windows.Forms.Button();
            this.lbMacierz = new System.Windows.Forms.Label();
            this.cBMetryki = new System.Windows.Forms.ComboBox();
            this.comboBoxK = new System.Windows.Forms.ComboBox();
            this.lblK = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWybierz
            // 
            this.btnWybierz.Location = new System.Drawing.Point(560, 16);
            this.btnWybierz.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierz.Name = "btnWybierz";
            this.btnWybierz.Size = new System.Drawing.Size(31, 19);
            this.btnWybierz.TabIndex = 0;
            this.btnWybierz.Text = "...";
            this.btnWybierz.UseVisualStyleBackColor = true;
            this.btnWybierz.Click += new System.EventHandler(this.btnWybierz_Click);
            // 
            // tbScieszka
            // 
            this.tbScieszka.Location = new System.Drawing.Point(8, 16);
            this.tbScieszka.Margin = new System.Windows.Forms.Padding(2);
            this.tbScieszka.Name = "tbScieszka";
            this.tbScieszka.ReadOnly = true;
            this.tbScieszka.Size = new System.Drawing.Size(548, 20);
            this.tbScieszka.TabIndex = 1;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // tbScieszka2
            // 
            this.tbScieszka2.Location = new System.Drawing.Point(8, 40);
            this.tbScieszka2.Margin = new System.Windows.Forms.Padding(2);
            this.tbScieszka2.Name = "tbScieszka2";
            this.tbScieszka2.ReadOnly = true;
            this.tbScieszka2.Size = new System.Drawing.Size(548, 20);
            this.tbScieszka2.TabIndex = 3;
            // 
            // btnWybierz2
            // 
            this.btnWybierz2.Location = new System.Drawing.Point(560, 40);
            this.btnWybierz2.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierz2.Name = "btnWybierz2";
            this.btnWybierz2.Size = new System.Drawing.Size(31, 19);
            this.btnWybierz2.TabIndex = 2;
            this.btnWybierz2.Text = "...";
            this.btnWybierz2.UseVisualStyleBackColor = true;
            this.btnWybierz2.Click += new System.EventHandler(this.btnWybierz2_Click);
            // 
            // buttonGeneruj
            // 
            this.buttonGeneruj.Location = new System.Drawing.Point(515, 396);
            this.buttonGeneruj.Name = "buttonGeneruj";
            this.buttonGeneruj.Size = new System.Drawing.Size(75, 23);
            this.buttonGeneruj.TabIndex = 4;
            this.buttonGeneruj.Text = "Generuj";
            this.buttonGeneruj.UseVisualStyleBackColor = true;
            this.buttonGeneruj.Click += new System.EventHandler(this.buttonGeneruj_Click);
            // 
            // lbMacierz
            // 
            this.lbMacierz.AutoSize = true;
            this.lbMacierz.Location = new System.Drawing.Point(12, 104);
            this.lbMacierz.Name = "lbMacierz";
            this.lbMacierz.Size = new System.Drawing.Size(0, 13);
            this.lbMacierz.TabIndex = 5;
            // 
            // cBMetryki
            // 
            this.cBMetryki.FormattingEnabled = true;
            this.cBMetryki.Items.AddRange(new object[] {
            "Metryka Euklidesowa",
            "Metryka Manhattan",
            "Metryka Canberra",
            "Metryka Czebyszewa"});
            this.cBMetryki.Location = new System.Drawing.Point(440, 65);
            this.cBMetryki.Name = "cBMetryki";
            this.cBMetryki.Size = new System.Drawing.Size(150, 21);
            this.cBMetryki.TabIndex = 6;
            // 
            // comboBoxK
            // 
            this.comboBoxK.FormattingEnabled = true;
            this.comboBoxK.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxK.Location = new System.Drawing.Point(284, 65);
            this.comboBoxK.Name = "comboBoxK";
            this.comboBoxK.Size = new System.Drawing.Size(150, 21);
            this.comboBoxK.TabIndex = 7;
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(265, 68);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(13, 13);
            this.lblK.TabIndex = 8;
            this.lblK.Text = "k";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(12, 409);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(205, 13);
            this.lblAutor.TabIndex = 9;
            this.lblAutor.Text = "Krzysztof Biernacki ISI 26.04.2016 ver 1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 431);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblK);
            this.Controls.Add(this.comboBoxK);
            this.Controls.Add(this.cBMetryki);
            this.Controls.Add(this.lbMacierz);
            this.Controls.Add(this.buttonGeneruj);
            this.Controls.Add(this.tbScieszka2);
            this.Controls.Add(this.btnWybierz2);
            this.Controls.Add(this.tbScieszka);
            this.Controls.Add(this.btnWybierz);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Klasyfikator k − NN Krzysztof Biernacki";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWybierz;
        private System.Windows.Forms.TextBox tbScieszka;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox tbScieszka2;
        private System.Windows.Forms.Button btnWybierz2;
        private System.Windows.Forms.Button buttonGeneruj;
        private System.Windows.Forms.Label lbMacierz;
        private System.Windows.Forms.ComboBox cBMetryki;
        private System.Windows.Forms.ComboBox comboBoxK;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblAutor;
    }
}

