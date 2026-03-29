namespace _7zVaultWF
{
    partial class WindowVault7z
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
            label_filenameText = new Label();
            filenameText = new TextBox();
            passwordText = new TextBox();
            label_passwordText = new Label();
            openButton = new Button();
            unlockButton = new Button();
            lockButton = new Button();
            lockStatus = new Label();
            SuspendLayout();
            // 
            // label_filenameText
            // 
            label_filenameText.AutoSize = true;
            label_filenameText.Location = new Point(12, 15);
            label_filenameText.Name = "label_filenameText";
            label_filenameText.Size = new Size(69, 16);
            label_filenameText.TabIndex = 0;
            label_filenameText.Text = "File to open";
            // 
            // filenameText
            // 
            filenameText.Location = new Point(87, 12);
            filenameText.Name = "filenameText";
            filenameText.Size = new Size(321, 23);
            filenameText.TabIndex = 1;
            filenameText.Text = "./data.7z";
            // 
            // passwordText
            // 
            passwordText.Location = new Point(87, 41);
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.Size = new Size(321, 23);
            passwordText.TabIndex = 2;
            // 
            // label_passwordText
            // 
            label_passwordText.AutoSize = true;
            label_passwordText.Location = new Point(12, 44);
            label_passwordText.Name = "label_passwordText";
            label_passwordText.Size = new Size(57, 16);
            label_passwordText.TabIndex = 3;
            label_passwordText.Text = "Password";
            // 
            // openButton
            // 
            openButton.Enabled = false;
            openButton.Location = new Point(6, 70);
            openButton.Name = "openButton";
            openButton.Size = new Size(75, 23);
            openButton.TabIndex = 4;
            openButton.Text = "Open";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += OpenVaultFolder;
            // 
            // unlockButton
            // 
            unlockButton.Location = new Point(87, 70);
            unlockButton.Name = "unlockButton";
            unlockButton.Size = new Size(75, 23);
            unlockButton.TabIndex = 5;
            unlockButton.Text = "Unlock";
            unlockButton.UseVisualStyleBackColor = true;
            unlockButton.Click += UnlockVaultFolder;
            // 
            // lockButton
            // 
            lockButton.Enabled = false;
            lockButton.Location = new Point(168, 70);
            lockButton.Name = "lockButton";
            lockButton.Size = new Size(75, 23);
            lockButton.TabIndex = 6;
            lockButton.Text = "Lock";
            lockButton.UseVisualStyleBackColor = true;
            lockButton.Click += LockVaultFolder;
            // 
            // lockStatus
            // 
            lockStatus.AutoSize = true;
            lockStatus.Location = new Point(249, 73);
            lockStatus.Name = "lockStatus";
            lockStatus.Size = new Size(85, 16);
            lockStatus.TabIndex = 7;
            lockStatus.Text = "Vault is locked.";
            // 
            // WindowVault7z
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 101);
            Controls.Add(lockStatus);
            Controls.Add(lockButton);
            Controls.Add(unlockButton);
            Controls.Add(openButton);
            Controls.Add(label_passwordText);
            Controls.Add(passwordText);
            Controls.Add(filenameText);
            Controls.Add(label_filenameText);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(436, 140);
            MinimizeBox = false;
            MinimumSize = new Size(436, 140);
            Name = "WindowVault7z";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "7Z Vault";
            Load += LoadForm;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_filenameText;
        private TextBox filenameText;
        private TextBox passwordText;
        private Label label_passwordText;
        private Button openButton;
        private Button unlockButton;
        private Button lockButton;
        private Label lockStatus;
    }
}
