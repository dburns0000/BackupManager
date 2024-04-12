using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupApp
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string caption)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            Padding = new Padding(2);
            caption_textBox.Text = caption;
            message_label.Text = message;
            int width = message_label.Width + message_panel.Padding.Left;
            int height = caption_panel.Height + message_label.Height + button_panel.Height + message_panel.Padding.Top + 10;
            Size = new Size(width, height);
            ok_button.Select();
        }

        public static DialogResult Show(string message, string caption = "")
        {
            DialogResult result;
            using (var msgForm = new CustomMessageBox(message, caption))
                result = msgForm.ShowDialog();
            return result;
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
