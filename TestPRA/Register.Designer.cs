namespace TestPRA
{
    partial class Register
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputName = new TextBox();
            inputLastName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            inputEmail = new TextBox();
            inputPass = new TextBox();
            inputConfirmPass = new TextBox();
            label5 = new Label();
            label6 = new Label();
            datePicker = new DateTimePicker();
            label7 = new Label();
            button1 = new Button();
            button2 = new Button();
            lblRegisterError = new Label();
            label8 = new Label();
            inputUsername = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(525, 56);
            label1.Name = "label1";
            label1.Size = new Size(385, 116);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // inputName
            // 
            inputName.BackColor = SystemColors.WindowFrame;
            inputName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputName.Location = new Point(561, 180);
            inputName.Name = "inputName";
            inputName.Size = new Size(349, 29);
            inputName.TabIndex = 4;
            inputName.WordWrap = false;
            // 
            // inputLastName
            // 
            inputLastName.BackColor = SystemColors.WindowFrame;
            inputLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputLastName.Location = new Point(561, 243);
            inputLastName.Name = "inputLastName";
            inputLastName.Size = new Size(349, 29);
            inputLastName.TabIndex = 5;
            inputLastName.WordWrap = false;
            // 
            // label3
            // 
            label3.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(412, 172);
            label3.Name = "label3";
            label3.Size = new Size(136, 38);
            label3.TabIndex = 6;
            label3.Text = "First name:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(412, 241);
            label4.Name = "label4";
            label4.Size = new Size(136, 31);
            label4.TabIndex = 7;
            label4.Text = "Last name:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(452, 344);
            label2.Name = "label2";
            label2.Size = new Size(96, 31);
            label2.TabIndex = 8;
            label2.Text = "Email:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputEmail
            // 
            inputEmail.BackColor = SystemColors.WindowFrame;
            inputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputEmail.Location = new Point(561, 344);
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new Size(349, 29);
            inputEmail.TabIndex = 9;
            inputEmail.WordWrap = false;
            // 
            // inputPass
            // 
            inputPass.BackColor = SystemColors.WindowFrame;
            inputPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPass.Location = new Point(561, 444);
            inputPass.Name = "inputPass";
            inputPass.Size = new Size(349, 29);
            inputPass.TabIndex = 10;
            inputPass.UseSystemPasswordChar = true;
            inputPass.WordWrap = false;
            // 
            // inputConfirmPass
            // 
            inputConfirmPass.BackColor = SystemColors.WindowFrame;
            inputConfirmPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputConfirmPass.Location = new Point(561, 496);
            inputConfirmPass.Name = "inputConfirmPass";
            inputConfirmPass.Size = new Size(349, 29);
            inputConfirmPass.TabIndex = 11;
            inputConfirmPass.UseSystemPasswordChar = true;
            inputConfirmPass.WordWrap = false;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(392, 444);
            label5.Name = "label5";
            label5.Size = new Size(156, 31);
            label5.TabIndex = 12;
            label5.Text = "Password:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(304, 496);
            label6.Name = "label6";
            label6.Size = new Size(244, 31);
            label6.TabIndex = 13;
            label6.Text = "Confirm password:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // datePicker
            // 
            datePicker.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePicker.CalendarForeColor = SystemColors.WindowFrame;
            datePicker.CalendarMonthBackground = SystemColors.WindowFrame;
            datePicker.CalendarTitleForeColor = SystemColors.ControlDarkDark;
            datePicker.CalendarTrailingForeColor = Color.FromArgb(192, 64, 0);
            datePicker.CustomFormat = "";
            datePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(561, 297);
            datePicker.Name = "datePicker";
            datePicker.RightToLeft = RightToLeft.No;
            datePicker.Size = new Size(349, 29);
            datePicker.TabIndex = 14;
            datePicker.Value = new DateTime(2025, 1, 27, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(344, 296);
            label7.Name = "label7";
            label7.Size = new Size(204, 31);
            label7.TabIndex = 15;
            label7.Text = "Date of birth:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(561, 572);
            button1.Name = "button1";
            button1.Size = new Size(151, 34);
            button1.TabIndex = 16;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(759, 572);
            button2.Name = "button2";
            button2.Size = new Size(151, 34);
            button2.TabIndex = 17;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblRegisterError
            // 
            lblRegisterError.AutoSize = true;
            lblRegisterError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegisterError.ForeColor = Color.Red;
            lblRegisterError.Location = new Point(561, 540);
            lblRegisterError.Name = "lblRegisterError";
            lblRegisterError.Size = new Size(165, 15);
            lblRegisterError.TabIndex = 18;
            lblRegisterError.Text = "All fields must contrain data!";
            lblRegisterError.Visible = false;
            // 
            // label8
            // 
            label8.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(392, 395);
            label8.Name = "label8";
            label8.Size = new Size(156, 31);
            label8.TabIndex = 20;
            label8.Text = "Username:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputUsername
            // 
            inputUsername.BackColor = SystemColors.WindowFrame;
            inputUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputUsername.Location = new Point(561, 395);
            inputUsername.Name = "inputUsername";
            inputUsername.Size = new Size(349, 29);
            inputUsername.TabIndex = 19;
            inputUsername.WordWrap = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1384, 661);
            Controls.Add(label8);
            Controls.Add(inputUsername);
            Controls.Add(lblRegisterError);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(datePicker);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(inputConfirmPass);
            Controls.Add(inputPass);
            Controls.Add(inputEmail);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(inputLastName);
            Controls.Add(inputName);
            Controls.Add(label1);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputName;
        private TextBox inputLastName;
        private Label label3;
        private Label label4;
        private Label label2;
        private TextBox inputEmail;
        private TextBox inputPass;
        private TextBox inputConfirmPass;
        private Label label5;
        private Label label6;
        private DateTimePicker datePicker;
        private Label label7;
        private Button button1;
        private Button button2;
        private Label lblRegisterError;
        private Label label8;
        private TextBox inputUsername;
    }
}
