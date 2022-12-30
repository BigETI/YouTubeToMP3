using System.Diagnostics;
using System.Windows.Forms;

namespace YouTubeToMP3.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm() => InitializeComponent();

        private void GitHubLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://github.com/BigETI/YouTubeToMP3");

        private void DonateAtKoFiLinkLabelLinkClickedEvent(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://ko-fi.com/bigeti");
    }
}
