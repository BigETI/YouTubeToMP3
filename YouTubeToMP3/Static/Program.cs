using System;
using System.IO;
using System.Windows.Forms;
using YouTubeToMP3.Forms;

namespace YouTubeToMP3
{
    internal static class Program
    {
        private static readonly string ffmpegProductName = "ffmpeg";
        
        private static readonly string ytDLPProductName = "yt-dlp";

        private static readonly string executableExtension = "exe";

        private static readonly string ffmpegFileName = $"{ffmpegProductName}.{executableExtension}";

        private static readonly string ytDLPFileName = $"{ytDLPProductName}.{executableExtension}";

        private static readonly string backslashFFMPEGFileName = $"\\{ffmpegFileName}";

        private static readonly string backslashYoutubeDLFileName = $"\\{ytDLPFileName}";

        private static readonly string slashFFMPEGFileName = $"/{ffmpegFileName}";

        private static readonly string slashYoutubeDLFileName = $"/{ytDLPFileName}";
        
        [STAThread]
        static void Main()
        {
            string yt_dlp_executable_path = Path.Combine(Environment.CurrentDirectory, ytDLPFileName);
            bool is_ffmpeg_installed = File.Exists(Path.Combine(Environment.CurrentDirectory, ffmpegFileName));
            bool is_yt_dlp_installed = File.Exists(yt_dlp_executable_path);
            if ((!is_ffmpeg_installed) || (!is_yt_dlp_installed))
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
                            else if ((!is_yt_dlp_installed) && (file_path.Contains(backslashYoutubeDLFileName) || file_path.Contains(slashYoutubeDLFileName)))
                            {
                                is_yt_dlp_installed = true;
                                yt_dlp_executable_path = file_path;
                            }
                            if (is_ffmpeg_installed && is_yt_dlp_installed)
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
            if (is_ffmpeg_installed && is_yt_dlp_installed)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(new YTDLP(yt_dlp_executable_path)));
            }
            else
            {
                string missing_dependencies_are =
                is_ffmpeg_installed ?
                    $"{ytDLPProductName} is" :
                    (
                        is_yt_dlp_installed ?
                            $"{ffmpegProductName} is" :
                            $"{ffmpegProductName} and {ytDLPProductName} are"
                    );
                string error_text = $"{missing_dependencies_are} not installed yet. Please make sure that {missing_dependencies_are} installed on your machine.";
                Console.Error.WriteLine(error_text);
                MessageBox.Show(error_text, "Missing dependencies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
