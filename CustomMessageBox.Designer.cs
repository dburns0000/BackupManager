namespace BackupApp
{
    partial class CustomMessageBox
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
            caption_panel = new Panel();
            caption_textBox = new TextBox();
            button_panel = new Panel();
            ok_button = new Button();
            message_panel = new Panel();
            message_label = new Label();
            caption_panel.SuspendLayout();
            button_panel.SuspendLayout();
            message_panel.SuspendLayout();
            SuspendLayout();
            // 
            // caption_panel
            // 
            caption_panel.BackColor = Color.White;
            caption_panel.Controls.Add(caption_textBox);
            caption_panel.Dock = DockStyle.Top;
            caption_panel.Location = new Point(2, 2);
            caption_panel.Name = "caption_panel";
            caption_panel.Size = new Size(330, 35);
            caption_panel.TabIndex = 0;
            // 
            // caption_textBox
            // 
            caption_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            caption_textBox.BorderStyle = BorderStyle.None;
            caption_textBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            caption_textBox.Location = new Point(3, 9);
            caption_textBox.Multiline = true;
            caption_textBox.Name = "caption_textBox";
            caption_textBox.Size = new Size(324, 20);
            caption_textBox.TabIndex = 1;
            caption_textBox.Text = "Caption";
            caption_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // button_panel
            // 
            button_panel.Controls.Add(ok_button);
            button_panel.Dock = DockStyle.Bottom;
            button_panel.Location = new Point(2, 113);
            button_panel.Name = "button_panel";
            button_panel.Size = new Size(330, 50);
            button_panel.TabIndex = 1;
            // 
            // ok_button
            // 
            ok_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok_button.Location = new Point(243, 15);
            ok_button.Name = "ok_button";
            ok_button.Size = new Size(75, 23);
            ok_button.TabIndex = 0;
            ok_button.Text = "OK";
            ok_button.UseVisualStyleBackColor = true;
            ok_button.Click += Close_button_Click;
            // 
            // message_panel
            // 
            message_panel.BackColor = Color.White;
            message_panel.Controls.Add(message_label);
            message_panel.Dock = DockStyle.Fill;
            message_panel.Location = new Point(2, 37);
            message_panel.Name = "message_panel";
            message_panel.Padding = new Padding(10, 10, 0, 0);
            message_panel.Size = new Size(330, 76);
            message_panel.TabIndex = 2;
            // 
            // message_label
            // 
            message_label.AutoSize = true;
            message_label.Dock = DockStyle.Fill;
            message_label.Location = new Point(10, 10);
            message_label.Name = "message_label";
            message_label.Size = new Size(53, 15);
            message_label.TabIndex = 0;
            message_label.Text = "Message";
            message_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 165);
            Controls.Add(message_panel);
            Controls.Add(button_panel);
            Controls.Add(caption_panel);
            MinimumSize = new Size(350, 150);
            Name = "CustomMessageBox";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterParent;
            Text = "CustomMessageBox";
            caption_panel.ResumeLayout(false);
            caption_panel.PerformLayout();
            button_panel.ResumeLayout(false);
            message_panel.ResumeLayout(false);
            message_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel caption_panel;
        private Panel button_panel;
        private Panel message_panel;
        private TextBox caption_textBox;
        private Button ok_button;
        private Label message_label;
    }
}