namespace TestPRA
{
    partial class Friends
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
            listMyFriends = new ListBox();
            flpFriendRequests = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            flpSendFriendRequest = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // listMyFriends
            // 
            listMyFriends.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listMyFriends.FormattingEnabled = true;
            listMyFriends.ItemHeight = 28;
            listMyFriends.Location = new Point(12, 60);
            listMyFriends.Name = "listMyFriends";
            listMyFriends.Size = new Size(472, 592);
            listMyFriends.TabIndex = 0;
            // 
            // flpFriendRequests
            // 
            flpFriendRequests.AutoScroll = true;
            flpFriendRequests.AutoSize = true;
            flpFriendRequests.FlowDirection = FlowDirection.TopDown;
            flpFriendRequests.Location = new Point(519, 60);
            flpFriendRequests.Name = "flpFriendRequests";
            flpFriendRequests.Size = new Size(429, 589);
            flpFriendRequests.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(472, 43);
            label1.TabIndex = 2;
            label1.Text = "MY FRIENDS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(519, 9);
            label2.Name = "label2";
            label2.Size = new Size(853, 43);
            label2.TabIndex = 3;
            label2.Text = "FRIEND REQUESTS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpSendFriendRequest
            // 
            flpSendFriendRequest.AutoScroll = true;
            flpSendFriendRequest.FlowDirection = FlowDirection.TopDown;
            flpSendFriendRequest.Location = new Point(954, 60);
            flpSendFriendRequest.Name = "flpSendFriendRequest";
            flpSendFriendRequest.Size = new Size(418, 589);
            flpSendFriendRequest.TabIndex = 2;
            flpSendFriendRequest.WrapContents = false;
            // 
            // Friends
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 661);
            Controls.Add(flpSendFriendRequest);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flpFriendRequests);
            Controls.Add(listMyFriends);
            Name = "Friends";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Friends";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listMyFriends;
        private FlowLayoutPanel flpFriendRequests;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpSendFriendRequest;
    }
}