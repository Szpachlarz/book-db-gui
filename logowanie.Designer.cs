namespace projekt
{
    partial class logowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogPan = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GoToReg = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.PassLog = new System.Windows.Forms.TextBox();
            this.MailLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RegistryPan = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.ConfPassButton = new System.Windows.Forms.TextBox();
            this.PasswdReg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BackToLogPan = new System.Windows.Forms.Button();
            this.RegButton = new System.Windows.Forms.Button();
            this.NameReg = new System.Windows.Forms.TextBox();
            this.EmailReg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LogPan.SuspendLayout();
            this.RegistryPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogPan
            // 
            this.LogPan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogPan.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogPan.Controls.Add(this.button1);
            this.LogPan.Controls.Add(this.label4);
            this.LogPan.Controls.Add(this.GoToReg);
            this.LogPan.Controls.Add(this.LogButton);
            this.LogPan.Controls.Add(this.PassLog);
            this.LogPan.Controls.Add(this.MailLog);
            this.LogPan.Controls.Add(this.label3);
            this.LogPan.Controls.Add(this.label2);
            this.LogPan.Controls.Add(this.label1);
            this.LogPan.Location = new System.Drawing.Point(12, 12);
            this.LogPan.Margin = new System.Windows.Forms.Padding(1);
            this.LogPan.Name = "LogPan";
            this.LogPan.Size = new System.Drawing.Size(776, 426);
            this.LogPan.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(490, 247);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 50);
            this.button1.TabIndex = 16;
            this.button1.TabStop = false;
            this.button1.Text = "Powrót";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.returnToMain);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(297, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nie masz konta?\r\nZarejestruj się\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GoToReg
            // 
            this.GoToReg.BackColor = System.Drawing.SystemColors.Highlight;
            this.GoToReg.FlatAppearance.BorderSize = 0;
            this.GoToReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GoToReg.ForeColor = System.Drawing.SystemColors.Window;
            this.GoToReg.Location = new System.Drawing.Point(214, 346);
            this.GoToReg.Name = "GoToReg";
            this.GoToReg.Size = new System.Drawing.Size(261, 48);
            this.GoToReg.TabIndex = 14;
            this.GoToReg.TabStop = false;
            this.GoToReg.Text = "Rejestracja";
            this.GoToReg.UseVisualStyleBackColor = false;
            this.GoToReg.Click += new System.EventHandler(this.GoToReg_Click);
            // 
            // LogButton
            // 
            this.LogButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.LogButton.FlatAppearance.BorderSize = 0;
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogButton.ForeColor = System.Drawing.SystemColors.Window;
            this.LogButton.Location = new System.Drawing.Point(214, 247);
            this.LogButton.Margin = new System.Windows.Forms.Padding(0);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(261, 50);
            this.LogButton.TabIndex = 13;
            this.LogButton.TabStop = false;
            this.LogButton.Text = "Zaloguj się";
            this.LogButton.UseMnemonic = false;
            this.LogButton.UseVisualStyleBackColor = false;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // PassLog
            // 
            this.PassLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PassLog.Location = new System.Drawing.Point(214, 181);
            this.PassLog.MaxLength = 16;
            this.PassLog.Name = "PassLog";
            this.PassLog.PasswordChar = '•';
            this.PassLog.Size = new System.Drawing.Size(261, 29);
            this.PassLog.TabIndex = 1;
            // 
            // MailLog
            // 
            this.MailLog.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.MailLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MailLog.Location = new System.Drawing.Point(214, 99);
            this.MailLog.MaxLength = 30;
            this.MailLog.Name = "MailLog";
            this.MailLog.Size = new System.Drawing.Size(261, 29);
            this.MailLog.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(50, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasło";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(50, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Adres e-mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Logowanie";
            // 
            // RegistryPan
            // 
            this.RegistryPan.BackColor = System.Drawing.SystemColors.HotTrack;
            this.RegistryPan.Controls.Add(this.label11);
            this.RegistryPan.Controls.Add(this.ConfPassButton);
            this.RegistryPan.Controls.Add(this.PasswdReg);
            this.RegistryPan.Controls.Add(this.label10);
            this.RegistryPan.Controls.Add(this.BackToLogPan);
            this.RegistryPan.Controls.Add(this.RegButton);
            this.RegistryPan.Controls.Add(this.NameReg);
            this.RegistryPan.Controls.Add(this.EmailReg);
            this.RegistryPan.Controls.Add(this.label8);
            this.RegistryPan.Controls.Add(this.label6);
            this.RegistryPan.Controls.Add(this.label5);
            this.RegistryPan.Location = new System.Drawing.Point(12, 12);
            this.RegistryPan.Name = "RegistryPan";
            this.RegistryPan.Size = new System.Drawing.Size(776, 426);
            this.RegistryPan.TabIndex = 16;
            this.RegistryPan.TabStop = true;
            this.RegistryPan.Paint += new System.Windows.Forms.PaintEventHandler(this.RegistryPan_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(433, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 24);
            this.label11.TabIndex = 24;
            this.label11.Text = "Potwierdź hasło";
            // 
            // ConfPassButton
            // 
            this.ConfPassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConfPassButton.Location = new System.Drawing.Point(588, 154);
            this.ConfPassButton.MaxLength = 16;
            this.ConfPassButton.Name = "ConfPassButton";
            this.ConfPassButton.PasswordChar = '•';
            this.ConfPassButton.Size = new System.Drawing.Size(149, 29);
            this.ConfPassButton.TabIndex = 5;
            // 
            // PasswdReg
            // 
            this.PasswdReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PasswdReg.Location = new System.Drawing.Point(588, 87);
            this.PasswdReg.MaxLength = 16;
            this.PasswdReg.Name = "PasswdReg";
            this.PasswdReg.PasswordChar = '•';
            this.PasswdReg.Size = new System.Drawing.Size(149, 29);
            this.PasswdReg.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(433, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "Hasło";
            // 
            // BackToLogPan
            // 
            this.BackToLogPan.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackToLogPan.FlatAppearance.BorderSize = 0;
            this.BackToLogPan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToLogPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackToLogPan.ForeColor = System.Drawing.SystemColors.Window;
            this.BackToLogPan.Location = new System.Drawing.Point(39, 300);
            this.BackToLogPan.Name = "BackToLogPan";
            this.BackToLogPan.Size = new System.Drawing.Size(300, 59);
            this.BackToLogPan.TabIndex = 20;
            this.BackToLogPan.TabStop = false;
            this.BackToLogPan.Text = "Powrót do logowania";
            this.BackToLogPan.UseVisualStyleBackColor = false;
            this.BackToLogPan.Click += new System.EventHandler(this.BackToLogPan_Click);
            // 
            // RegButton
            // 
            this.RegButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RegButton.FlatAppearance.BorderSize = 0;
            this.RegButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegButton.ForeColor = System.Drawing.SystemColors.Window;
            this.RegButton.Location = new System.Drawing.Point(436, 300);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(300, 59);
            this.RegButton.TabIndex = 19;
            this.RegButton.TabStop = false;
            this.RegButton.Text = "Zarejestruj";
            this.RegButton.UseVisualStyleBackColor = false;
            this.RegButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameReg
            // 
            this.NameReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameReg.Location = new System.Drawing.Point(214, 82);
            this.NameReg.MaxLength = 24;
            this.NameReg.Name = "NameReg";
            this.NameReg.Size = new System.Drawing.Size(149, 29);
            this.NameReg.TabIndex = 0;
            // 
            // EmailReg
            // 
            this.EmailReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.EmailReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EmailReg.Location = new System.Drawing.Point(214, 154);
            this.EmailReg.MaxLength = 30;
            this.EmailReg.Name = "EmailReg";
            this.EmailReg.Size = new System.Drawing.Size(149, 29);
            this.EmailReg.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(35, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Adres E-mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(35, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nickname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(14, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 42);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rejestracja";
            // 
            // logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogPan);
            this.Controls.Add(this.RegistryPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "logowanie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zaloguj się";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.LogPan.ResumeLayout(false);
            this.LogPan.PerformLayout();
            this.RegistryPan.ResumeLayout(false);
            this.RegistryPan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LogPan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GoToReg;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.TextBox PassLog;
        private System.Windows.Forms.TextBox MailLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameReg;
        private System.Windows.Forms.TextBox EmailReg;
        private System.Windows.Forms.Button RegButton;
        private System.Windows.Forms.Button BackToLogPan;
        private System.Windows.Forms.TextBox PasswdReg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel RegistryPan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ConfPassButton;
        private System.Windows.Forms.Button button1;
    }
}

