namespace TestPRA
{
    partial class MainWindow
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
            pnlGroups = new Panel();
            listGroups = new ListBox();
            label1 = new Label();
            btnCreateGroup = new Button();
            button1 = new Button();
            button2 = new Button();
            pnlGroups.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGroups
            // 
            pnlGroups.Controls.Add(listGroups);
            pnlGroups.Location = new Point(1, 45);
            pnlGroups.Name = "pnlGroups";
            pnlGroups.Size = new Size(200, 575);
            pnlGroups.TabIndex = 0;
            // 
            // listGroups
            // 
            listGroups.FormattingEnabled = true;
            listGroups.ItemHeight = 15;
            listGroups.Location = new Point(0, 0);
            listGroups.Name = "listGroups";
            listGroups.Size = new Size(200, 574);
            listGroups.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(1, 5);
            label1.MaximumSize = new Size(200, 40);
            label1.Name = "label1";
            label1.Size = new Size(191, 37);
            label1.TabIndex = 1;
            label1.Text = "GROUP CHATS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateGroup.Location = new Point(1, 616);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(200, 46);
            btnCreateGroup.TabIndex = 2;
            btnCreateGroup.Text = "Create new group";
            btnCreateGroup.UseVisualStyleBackColor = true;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1297, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 37);
            button1.TabIndex = 3;
            button1.Text = "PROFILE";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1216, 5);
            button2.Name = "button2";
            button2.Size = new Size(75, 37);
            button2.TabIndex = 4;
            button2.Text = "FRIENDS";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 661);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnCreateGroup);
            Controls.Add(label1);
            Controls.Add(pnlGroups);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainWindow";
            pnlGroups.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGroups;
        private Label label1;
        private ListBox listGroups;
        private Button btnCreateGroup;
        private Button button1;
        private Button button2;
    }
}