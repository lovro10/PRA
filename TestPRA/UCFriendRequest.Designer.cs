namespace TestPRA
{
    partial class UCFriendRequest
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
            lblDateSent = new Label();
            label2 = new Label();
            btnDeclineFriendRequest = new Button();
            btnAcceptFriendRequest = new Button();
            lblUsername = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblDateSent
            // 
            lblDateSent.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateSent.Location = new Point(93, 40);
            lblDateSent.Name = "lblDateSent";
            lblDateSent.Size = new Size(195, 31);
            lblDateSent.TabIndex = 1;
            lblDateSent.Text = "label2";
            lblDateSent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 42);
            label2.Name = "label2";
            label2.Size = new Size(84, 27);
            label2.TabIndex = 3;
            label2.Text = "Date sent:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDeclineFriendRequest
            // 
            btnDeclineFriendRequest.Location = new Point(307, 48);
            btnDeclineFriendRequest.Name = "btnDeclineFriendRequest";
            btnDeclineFriendRequest.Size = new Size(75, 23);
            btnDeclineFriendRequest.TabIndex = 5;
            btnDeclineFriendRequest.Text = "Decline";
            btnDeclineFriendRequest.UseVisualStyleBackColor = true;
            btnDeclineFriendRequest.Click += btnDeclineFriendRequest_Click;
            // 
            // btnAcceptFriendRequest
            // 
            btnAcceptFriendRequest.Location = new Point(307, 11);
            btnAcceptFriendRequest.Name = "btnAcceptFriendRequest";
            btnAcceptFriendRequest.Size = new Size(75, 23);
            btnAcceptFriendRequest.TabIndex = 4;
            btnAcceptFriendRequest.Text = "Accept";
            btnAcceptFriendRequest.UseVisualStyleBackColor = true;
            btnAcceptFriendRequest.Click += btnAcceptFriendRequest_Click;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(106, 5);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(195, 31);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "lovro";
            lblUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(97, 31);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UCFriendRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            Controls.Add(btnDeclineFriendRequest);
            Controls.Add(btnAcceptFriendRequest);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDateSent);
            Controls.Add(lblUsername);
            Name = "UCFriendRequest";
            Size = new Size(400, 85);
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        public Label lblDateSent;
        public Button btnDeclineFriendRequest;
        public Button btnAcceptFriendRequest;
        public Label lblUsername;
        private Label label1;
    }
}
