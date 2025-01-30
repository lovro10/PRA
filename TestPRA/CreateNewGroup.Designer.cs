namespace TestPRA
{
    partial class CreateNewGroup
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
            label1 = new Label();
            label2 = new Label();
            inputGroupName = new TextBox();
            button1 = new Button();
            button2 = new Button();
            lblGroupNameError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(361, 64);
            label1.TabIndex = 0;
            label1.Text = "CREATE NEW GROUP";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 87);
            label2.Name = "label2";
            label2.Size = new Size(154, 36);
            label2.TabIndex = 1;
            label2.Text = "Group name:";
            // 
            // inputGroupName
            // 
            inputGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputGroupName.Location = new Point(12, 126);
            inputGroupName.Name = "inputGroupName";
            inputGroupName.Size = new Size(361, 29);
            inputGroupName.TabIndex = 2;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(298, 189);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(12, 189);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblGroupNameError
            // 
            lblGroupNameError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGroupNameError.ForeColor = Color.Red;
            lblGroupNameError.Location = new Point(12, 158);
            lblGroupNameError.Name = "lblGroupNameError";
            lblGroupNameError.Size = new Size(183, 28);
            lblGroupNameError.TabIndex = 19;
            lblGroupNameError.Text = "Name already exists";
            lblGroupNameError.TextAlign = ContentAlignment.MiddleLeft;
            lblGroupNameError.Visible = false;
            // 
            // CreateNewGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 224);
            Controls.Add(lblGroupNameError);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(inputGroupName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateNewGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateNewGroup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        public TextBox inputGroupName;
        public Label lblGroupNameError;
    }
}