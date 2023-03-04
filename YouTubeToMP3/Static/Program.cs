using System;
using System.IO;
using System.Windows.Forms;
using YouTubeToMP3.Forms;

namespace YouTubeToMP3
{
    internal static class Program
    {
        private static readonly string ffmpegFileName = "ffmpeg.exe";

        private static readonly string youtubeDLFileName = "youtube-dl.exe";

        private static readonly string backslashFFMPEGFileName = $"\\{ffmpegFileName}";

        private static readonly string backslashYoutubeDLFileName = $"\\{youtubeDLFileName}";

        private static readonly string slashFFMPEGFileName = $"/{ffmpegFileName}";

        private static readonly string slashYoutubeDLFileName = $"/{youtubeDLFileName}";
        
        [STAThread]
        static void Main()
        {
            string youtube_dl_executable_path = Path.Combine(Environment.CurrentDirectory, youtubeDLFileName);
            bool is_ffmpeg_installed = File.Exists(Path.Combine(Environment.CurrentDirectory, ffmpegFileName));
            bool is_youtube_dl_installed = File.Exists(youtube_dl_executable_path);
            if ((!is_ffmpeg_installed) || (!is_youtube_dl_installed))
            {
                string[] directory_paths = Environment.GetEnvironmentVariable("PATH").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string directory_path in directory_paths)
                {
                    try
                    {
                        foreach (string file_path in Directory.GetFiles(directory_path))
                        {
                            if ((!is_ffmpeg_installed) && (file_path.EndsWith(backslashFFMPEGFileName) || file_path.EndsWith(slashFFMPEGFileName)))
                            {
                                is_ffmpeg_installed = true;
                            }
                            else if ((!is_youtube_dl_installed) && (file_path.Contains(backslashYoutubeDLFileName) || file_path.Contains(slashYoutubeDLFileName)))
                            {
                                is_youtube_dl_installed = true;
                                youtube_dl_executable_path = file_path;
                            }
                            if (is_ffmpeg_installed && is_youtube_dl_installed)
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
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
