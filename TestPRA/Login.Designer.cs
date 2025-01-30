namespace TestPRA
{
    partial class Login
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
            label2 = new Label();
            label4 = new Label();
            inputEmail = new TextBox();
            inputPass = new TextBox();
            label3 = new Label();
            lblRegister = new LinkLabel();
            btnlogin = new Button();
            lblLoginError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 60F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(583, 138);
            label1.Name = "label1";
            label1.Size = new Size(261, 116);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(486, 276);
            label2.Name = "label2";
            label2.Size = new Size(84, 38);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(445, 329);
            label4.Name = "label4";
            label4.Size = new Size(125, 31);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // inputEmail
            // 
            inputEmail.BackColor = SystemColors.WindowFrame;
            inputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputEmail.Location = new Point(583, 284);
            inputEmail.Name = "inputEmail";
            inputEmail.Size = new Size(349, 29);
            inputEmail.TabIndex = 4;
            inputEmail.WordWrap = false;
            // 
            // inputPass
            // 
            inputPass.BackColor = SystemColors.WindowFrame;
            inputPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPass.Location = new Point(583, 333);
            inputPass.Name = "inputPass";
            inputPass.PasswordChar = '*';
            inputPass.Size = new Size(349, 29);
            inputPass.TabIndex = 5;
            inputPass.UseSystemPasswordChar = true;
            inputPass.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(750, 410);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 6;
            label3.Text = "Don't have an account?";
            // 
            // lblRegister
            // 
            lblRegister.ActiveLinkColor = Color.White;
            lblRegister.AutoSize = true;
            lblRegister.LinkColor = Color.LightSkyBlue;
            lblRegister.Location = new Point(877, 410);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(49, 15);
            lblRegister.TabIndex = 7;
            lblRegister.TabStop = true;
            lblRegister.Text = "Register";
            lblRegister.LinkClicked += lblRegister_LinkClicked;
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.Location = new Point(583, 403);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(161, 29);
            btnlogin.TabIndex = 8;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // lblLoginError
            // 
            lblLoginError.AutoSize = true;
            lblLoginError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoginError.ForeColor = Color.Red;
            lblLoginError.Location = new Point(583, 374);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(165, 15);
            lblLoginError.TabIndex = 9;
            lblLoginError.Text = "All fields must contrain data!";
            lblLoginError.Visible = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(1384, 661);
            Controls.Add(lblLoginError);
            Controls.Add(btnlogin);
            Controls.Add(lblRegister);
            Controls.Add(label3);
            Controls.Add(inputPass);
            Controls.Add(inputEmail);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox inputEmail;
        private TextBox inputPass;
        private Label label3;
        private LinkLabel lblRegister;
        private Button btnlogin;
        private Label lblLoginError;
    }
}
