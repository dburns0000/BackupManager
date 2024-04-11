using System.Text;
using System.Text.Json;

namespace BackupApp
{
    public partial class MainForm : Form
    {
        private readonly List<string> _folderAndFileList = [];
        private readonly List<string> _errorList = [];

        public MainForm()
        {
            InitializeComponent();
        }

        public void UpdateCurrentItem(string currentItem)
        {
            BeginInvoke(new Action(() =>
            {
                current_item_textBox.Text = currentItem;
            }));
        }

        public void AddError(string error)
        {
            _errorList.Add(error);
        }

        void Backup_items_listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Get the data being dropped
                if (e.Data.GetData(DataFormats.FileDrop) is string[] files)
                {
                    // Process the dropped files
                    foreach (string file in files)
                    {
                        _folderAndFileList.Add(file);
                        backup_items_listBox.Items.Add(file);
                    }
                }
            }
        }

        void Backup_items_listBox_DragEnter(object sender, DragEventArgs e)
        {
            // Display a + sign when the mouse is over the list box
            e.Effect = DragDropEffects.Copy;
        }

        void Backup_items_listBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Add a menu item to the context menu
            if (e.Button == MouseButtons.Right)
            {
                backup_items_listBox.SelectedIndex = backup_items_listBox.IndexFromPoint(e.Location);
                list_contextMenuStrip.Show(backup_items_listBox, e.Location);
            }
        }

        private void Location_select_button_Click(object sender, EventArgs e)
        {
            // Display a dialog to select a folder
            FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Select a folder for backing up to",
                ShowNewFolderButton = true
            };
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != "")
            {
                location_textBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async void Start_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(location_textBox.Text))
            {
                MessageBox.Show("Please select a location to save the backup file.");
                return;
            }
            if (backup_items_listBox.Items.Count == 0)
            {
                MessageBox.Show("Please add folders and files to back up.");
                return;
            }

            List<string> items = [];
            foreach (var item in backup_items_listBox.Items)
            {
                if (item != null)
                {
                    string? itemString = item.ToString();
                    if (itemString != null)
                    {
                        items.Add(itemString);
                    }
                }
            }

            _errorList.Clear();
            start_button.Enabled = false;

            BackupRunner backupRunner = new(this);
            await backupRunner.RunBackup(items, location_textBox.Text);

            start_button.Enabled = true;

            if (_errorList.Count > 0)
            {
                StringBuilder errorBuilder = new();
                foreach (string error in _errorList)
                {
                    errorBuilder.AppendLine(error);
                }
                MessageBox.Show($"Errors occurred during the backup:{Environment.NewLine}{errorBuilder}");
            }
        }

        private void Save_list_button_Click(object sender, EventArgs e)
        {
            List<string> items = [];
            foreach (var item in backup_items_listBox.Items)
            {
                if (item != null)
                {
                    string? itemString = item.ToString();
                    if (itemString != null)
                    {
                        items.Add(itemString);
                    }
                }
            }

            string jsonString = JsonSerializer.Serialize(items);
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        private void Restore_list_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonString = File.ReadAllText(openFileDialog.FileName);
                    List<string>? items = JsonSerializer.Deserialize<List<string>>(jsonString);
                    if (items == null)
                    {
                        return;
                    }
                    foreach (string item in items)
                    {
                        _folderAndFileList.Add(item);
                        backup_items_listBox.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error restoring file: {ex.Message}");
                }
            }

        }

        private void RemoveAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup_items_listBox.Items.Clear();
        }

        private void RemoveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backup_items_listBox.SelectedIndex == -1)
            {
                return;
            }
            backup_items_listBox.Items.RemoveAt(backup_items_listBox.SelectedIndex);
        }

        private void AddFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Process the selected files
                foreach (string file in openFileDialog.FileNames)
                {
                    _folderAndFileList.Add(file);
                    backup_items_listBox.Items.Add(file);
                }
            }
        }

        private void AddFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                Description = "Select a folder",
                ShowNewFolderButton = false
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Process the selected folder
                _folderAndFileList.Add(folderBrowserDialog.SelectedPath);
                backup_items_listBox.Items.Add(folderBrowserDialog.SelectedPath);
            }
        }

    }   // class MainForm
}   // namespace BackupApp
