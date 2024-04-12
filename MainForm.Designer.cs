
namespace BackupApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            backup_items_listBox = new ListBox();
            label2 = new Label();
            location_textBox = new TextBox();
            location_select_button = new Button();
            start_button = new Button();
            label3 = new Label();
            current_item_textBox = new TextBox();
            save_list_button = new Button();
            restore_list_button = new Button();
            list_contextMenuStrip = new ContextMenuStrip(components);
            removeAllItemsToolStripMenuItem = new ToolStripMenuItem();
            removeItemToolStripMenuItem = new ToolStripMenuItem();
            addFilesToolStripMenuItem = new ToolStripMenuItem();
            addFolderToolStripMenuItem = new ToolStripMenuItem();
            list_contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 14);
            label1.Name = "label1";
            label1.Size = new Size(245, 15);
            label1.TabIndex = 0;
            label1.Text = "Folders and Files to back up (drag and drop): ";
            // 
            // backup_items_listBox
            // 
            backup_items_listBox.AllowDrop = true;
            backup_items_listBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            backup_items_listBox.FormattingEnabled = true;
            backup_items_listBox.ItemHeight = 15;
            backup_items_listBox.Location = new Point(20, 41);
            backup_items_listBox.Margin = new Padding(3, 2, 3, 2);
            backup_items_listBox.Name = "backup_items_listBox";
            backup_items_listBox.Size = new Size(341, 244);
            backup_items_listBox.TabIndex = 1;
            backup_items_listBox.DragDrop += Backup_items_listBox_DragDrop;
            backup_items_listBox.DragEnter += Backup_items_listBox_DragEnter;
            backup_items_listBox.MouseDown += Backup_items_listBox_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(390, 14);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 2;
            label2.Text = "Backup location:";
            // 
            // location_textBox
            // 
            location_textBox.Location = new Point(388, 41);
            location_textBox.Name = "location_textBox";
            location_textBox.Size = new Size(261, 23);
            location_textBox.TabIndex = 3;
            // 
            // location_select_button
            // 
            location_select_button.Location = new Point(502, 11);
            location_select_button.Name = "location_select_button";
            location_select_button.Size = new Size(75, 23);
            location_select_button.TabIndex = 4;
            location_select_button.Text = "Select";
            location_select_button.UseVisualStyleBackColor = true;
            location_select_button.Click += Location_select_button_Click;
            // 
            // start_button
            // 
            start_button.Font = new Font("Segoe UI", 14F);
            start_button.Location = new Point(470, 152);
            start_button.Name = "start_button";
            start_button.Size = new Size(92, 32);
            start_button.TabIndex = 5;
            start_button.Text = "Start";
            start_button.UseVisualStyleBackColor = true;
            start_button.Click += Start_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(388, 194);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 2;
            label3.Text = "Current item:";
            // 
            // current_item_textBox
            // 
            current_item_textBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            current_item_textBox.Location = new Point(388, 219);
            current_item_textBox.Multiline = true;
            current_item_textBox.Name = "current_item_textBox";
            current_item_textBox.Size = new Size(261, 66);
            current_item_textBox.TabIndex = 3;
            // 
            // save_list_button
            // 
            save_list_button.Location = new Point(418, 93);
            save_list_button.Name = "save_list_button";
            save_list_button.Size = new Size(83, 23);
            save_list_button.TabIndex = 6;
            save_list_button.Text = "Save List";
            save_list_button.UseVisualStyleBackColor = true;
            save_list_button.Click += Save_list_button_Click;
            // 
            // restore_list_button
            // 
            restore_list_button.Location = new Point(537, 93);
            restore_list_button.Name = "restore_list_button";
            restore_list_button.Size = new Size(75, 23);
            restore_list_button.TabIndex = 7;
            restore_list_button.Text = "Restore List";
            restore_list_button.UseVisualStyleBackColor = true;
            restore_list_button.Click += Restore_list_button_Click;
            // 
            // list_contextMenuStrip
            // 
            list_contextMenuStrip.Items.AddRange(new ToolStripItem[] { removeAllItemsToolStripMenuItem, removeItemToolStripMenuItem, addFilesToolStripMenuItem, addFolderToolStripMenuItem });
            list_contextMenuStrip.Name = "list_contextMenuStrip";
            list_contextMenuStrip.Size = new Size(167, 92);
            // 
            // removeAllItemsToolStripMenuItem
            // 
            removeAllItemsToolStripMenuItem.Name = "removeAllItemsToolStripMenuItem";
            removeAllItemsToolStripMenuItem.Size = new Size(166, 22);
            removeAllItemsToolStripMenuItem.Text = "Remove All Items";
            removeAllItemsToolStripMenuItem.Click += RemoveAllItemsToolStripMenuItem_Click;
            // 
            // removeItemToolStripMenuItem
            // 
            removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            removeItemToolStripMenuItem.Size = new Size(166, 22);
            removeItemToolStripMenuItem.Text = "Remove Item";
            removeItemToolStripMenuItem.Click += RemoveItemToolStripMenuItem_Click;
            // 
            // addFilesToolStripMenuItem
            // 
            addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            addFilesToolStripMenuItem.Size = new Size(166, 22);
            addFilesToolStripMenuItem.Text = "Add File(s)";
            addFilesToolStripMenuItem.Click += AddFilesToolStripMenuItem_Click;
            // 
            // addFolderToolStripMenuItem
            // 
            addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            addFolderToolStripMenuItem.Size = new Size(166, 22);
            addFolderToolStripMenuItem.Text = "Add Folder";
            addFolderToolStripMenuItem.Click += AddFolderToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 294);
            Controls.Add(restore_list_button);
            Controls.Add(save_list_button);
            Controls.Add(start_button);
            Controls.Add(location_select_button);
            Controls.Add(current_item_textBox);
            Controls.Add(location_textBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(backup_items_listBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup Manager";
            list_contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox backup_items_listBox;
        private Label label2;
        private TextBox location_textBox;
        private Button location_select_button;
        private Button start_button;
        private Label label3;
        private TextBox current_item_textBox;
        private Button save_list_button;
        private Button restore_list_button;
        private ContextMenuStrip list_contextMenuStrip;
        private ToolStripMenuItem removeAllItemsToolStripMenuItem;
        private ToolStripMenuItem removeItemToolStripMenuItem;
        private ToolStripMenuItem addFilesToolStripMenuItem;
        private ToolStripMenuItem addFolderToolStripMenuItem;
    }
}
