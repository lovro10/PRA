namespace TestPRA
{
    partial class UCSendFriendRequest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSendFriendRequest = new Button();
            label1 = new Label();
            lblUsername = new Label();
            SuspendLayout();
            // 
            // btnSendFriendRequest
            // 
            btnSendFriendRequest.Location = new Point(322, 13);
            btnSendFriendRequest.Name = "btnSendFriendRequest";
            btnSendFriendRequest.Size = new Size(75, 23);
            btnSendFriendRequest.TabIndex = 10;
            btnSendFriendRequest.Text = "Send";
            btnSendFriendRequest.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 44);
            label1.TabIndex = 9;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(121, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(195, 44);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "lovro";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UCSendFriendRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            Controls.Add(btnSendFriendRequest);
            Controls.Add(label1);
            Controls.Add(lblUsername);
            Name = "UCSendFriendRequest";
            Size = new Size(400, 47);
            ResumeLayout(false);
        }

        #endregion

        public Button btnSendFriendRequest;
        private Label label1;
        public Label lblUsername;
    }
}
