namespace projekt
{
    partial class formularzwydawnictwo
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textKraj = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textMiasto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textAdres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNazwa = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(385, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 59);
            this.button1.TabIndex = 68;
            this.button1.TabStop = false;
            this.button1.Text = "Powrót";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(385, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 59);
            this.button2.TabIndex = 67;
            this.button2.TabStop = false;
            this.button2.Text = "Dodaj";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textKraj
            // 
            this.textKraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textKraj.Location = new System.Drawing.Point(137, 192);
            this.textKraj.Margin = new System.Windows.Forms.Padding(2);
            this.textKraj.MaxLength = 50;
            this.textKraj.Name = "textKraj";
            this.textKraj.Size = new System.Drawing.Size(152, 29);
            this.textKraj.TabIndex = 66;
            this.textKraj.Validating += new System.ComponentModel.CancelEventHandler(this.textKraj_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(70, 195);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 24);
            this.label9.TabIndex = 65;
            this.label9.Text = "Kraj";
            // 
            // textMiasto
            // 
            this.textMiasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textMiasto.Location = new System.Drawing.Point(137, 150);
            this.textMiasto.Margin = new System.Windows.Forms.Padding(2);
            this.textMiasto.MaxLength = 30;
            this.textMiasto.Name = "textMiasto";
            this.textMiasto.Size = new System.Drawing.Size(152, 29);
            this.textMiasto.TabIndex = 64;
            this.textMiasto.Validating += new System.ComponentModel.CancelEventHandler(this.textMiasto_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(55, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 63;
            this.label8.Text = "Miasto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(52, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 62;
            this.label7.Text = "Adres";
            // 
            // textAdres
            // 
            this.textAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textAdres.Location = new System.Drawing.Point(137, 108);
            this.textAdres.Margin = new System.Windows.Forms.Padding(2);
            this.textAdres.MaxLength = 30;
            this.textAdres.Name = "textAdres";
            this.textAdres.Size = new System.Drawing.Size(152, 29);
            this.textAdres.TabIndex = 61;
            this.textAdres.Validating += new System.ComponentModel.CancelEventHandler(this.textAdres_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(52, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 60;
            this.label1.Text = "Nazwa";
            // 
            // textNazwa
            // 
            this.textNazwa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textNazwa.Location = new System.Drawing.Point(137, 66);
            this.textNazwa.Margin = new System.Windows.Forms.Padding(2);
            this.textNazwa.MaxLength = 30;
            this.textNazwa.Name = "textNazwa";
            this.textNazwa.Size = new System.Drawing.Size(152, 29);
            this.textNazwa.TabIndex = 59;
            this.textNazwa.Validating += new System.ComponentModel.CancelEventHandler(this.textNazwa_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // formularzwydawnictwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textKraj);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textMiasto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textAdres);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNazwa);
            this.Name = "formularzwydawnictwo";
            this.Text = "formularzwydawnictwo";
            this.Load += new System.EventHandler(this.formularzwydawnictwo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textKraj;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textMiasto;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textAdres;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textNazwa;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.ErrorProvider errorProvider2;
        public System.Windows.Forms.ErrorProvider errorProvider3;
        public System.Windows.Forms.ErrorProvider errorProvider4;
    }
}