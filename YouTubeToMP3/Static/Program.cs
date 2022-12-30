using System;
using System.Windows.Forms;
using YouTubeToMP3.Forms;

namespace YouTubeToMP3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
