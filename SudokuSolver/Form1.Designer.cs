namespace SudokuSolver
{
    partial class Form1
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
            this.Go = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMessages = new System.Windows.Forms.Panel();
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.panelMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // Go
            // 
            this.Go.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Go.Location = new System.Drawing.Point(12, 532);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(374, 93);
            this.Go.TabIndex = 0;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 251);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(613, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 251);
            this.panel2.TabIndex = 2;
            // 
            // panelMessages
            // 
            this.panelMessages.BackColor = System.Drawing.Color.RosyBrown;
            this.panelMessages.Controls.Add(this.Messages);
            this.panelMessages.Location = new System.Drawing.Point(1109, 68);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(477, 505);
            this.panelMessages.TabIndex = 3;
            // 
            // Messages
            // 
            this.Messages.BackColor = System.Drawing.Color.RosyBrown;
            this.Messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Messages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Messages.Location = new System.Drawing.Point(0, 0);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(477, 505);
            this.Messages.TabIndex = 0;
            this.Messages.Text = "";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenFileButton.Location = new System.Drawing.Point(409, 532);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(319, 93);
            this.OpenFileButton.TabIndex = 4;
            this.OpenFileButton.Text = "OpenFile";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveFileButton.Location = new System.Drawing.Point(734, 532);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(319, 93);
            this.SaveFileButton.TabIndex = 5;
            this.SaveFileButton.Text = "SaveFile";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 653);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.panelMessages);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Go);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMessages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Go;
        private Panel panel1;
        private Panel panel2;
        private Panel panelMessages;
        private RichTextBox Messages;
        private Button OpenFileButton;
        private Button SaveFileButton;
    }
}