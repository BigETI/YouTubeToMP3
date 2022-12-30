using System;
using System.Windows.Forms;

namespace YouTubeToMP3.Forms
{
    public partial class LoadURLsFromAnInternetResourceForm : Form
    {
        public Uri URI => Uri.TryCreate(urlTextBox.Text, UriKind.RelativeOrAbsolute, out Uri ret) ? ret : null;

        public LoadURLsFromAnInternetResourceForm()
        {
            AcceptButton = loadURLsbutton;
            CancelButton = cancelButton;
            InitializeComponent();
        }

        private void HandleKeyEvent(KeyEventArgs keyEventArguments)
        {
            if ((keyEventArguments.KeyCode & Keys.Enter) == Keys.Enter)
            {
                AcceptDialog();
            }
            else if ((keyEventArguments.KeyCode & Keys.Escape) == Keys.Escape)
            {
                CancelDialog();
            }
        }

        private void AcceptDialog()
        {
            if (URI != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelDialog()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadURLsFromAnInternetResourceFormKeyUpEvent(object sender, KeyEventArgs e) => HandleKeyEvent(e);

        private void URLTextBoxKeyUpEvent(object sender, KeyEventArgs e) => HandleKeyEvent(e);

        private void LoadURLsbuttonClickEvent(object sender, EventArgs e) => AcceptDialog();

        private void CancelButtonClickEvent(object sender, EventArgs e) => CancelDialog();
    }
}
