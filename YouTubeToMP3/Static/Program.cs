using System;
using System.IO;
using System.Windows.Forms;
using YouTubeToMP3.Forms;

namespace YouTubeToMP3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            bool is_ffmpeg_installed = false;
            bool is_youtube_dl_installed = false;
            string[] directory_paths = Environment.GetEnvironmentVariable("PATH").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string youtube_dl_executable_path = string.Empty;
            foreach (string directory_path in directory_paths)
            {
                try
                {
                    foreach (string file_path in Directory.GetFiles(directory_path))
                    {
                        if (file_path.EndsWith("ffmpeg.exe"))
                        {
                            is_ffmpeg_installed = true;
                        }
                        else if (file_path.Contains("youtube-dl.exe"))
                        {
                            is_youtube_dl_installed = true;
                            youtube_dl_executable_path = file_path;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }
            if (is_ffmpeg_installed && is_youtube_dl_installed)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(new YouTubeDL(youtube_dl_executable_path)));
            }
            else
            {
                string missing_dependencies_are =
                is_ffmpeg_installed ?
                    "youtube-dl is" :
                    (
                        is_youtube_dl_installed ?
                            "ffmpeg is" :
                            "ffmpeg and youtube-dl are"
                    );
                string error_text = $"{missing_dependencies_are} not installed yet. Please make sure that {missing_dependencies_are} installed on your machine.";
                Console.Error.WriteLine(error_text);
                MessageBox.Show(error_text, "Missing dependencies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
