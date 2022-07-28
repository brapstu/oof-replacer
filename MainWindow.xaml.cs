using System;
using System.Windows;
using System.IO;
using System.Media;
using System.Net.Http;

namespace Oof_replacer
{
    /// <summary>
    /// Interaction logic for What
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static HttpClient htc = new HttpClient();
        static string version;
        static string lad = Environment.GetEnvironmentVariable("LocalAppData");
        readonly string MainDirectory = @$"{lad}\Local\Roblox\Versions";
        private void replace_click(object sender, RoutedEventArgs e)
        {
            try {
                version = htc.GetStringAsync("http://setup.roblox.com/version").GetAwaiter().GetResult();
            } catch (Exception ex) {
                MessageBox.Show($"Could not download the current Roblox version code. Please make sure you are connected to the Internet.\nError: {ex.Message}", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Environment.Exit(1);
            }
            string versionDir = $@"{MainDirectory}\{version}";
            if (Directory.Exists(versionDir))
            {
                File.Delete($@"{versionDir}\content\sounds\ouch.ogg");
                File.Copy("ouch.ogg", $@"{versionDir}\content\sounds\", true);
                Progress.Text = "Sound has been updated!";
                SoundPlayer player = new SoundPlayer(@"ouch.wav");
                player.Play();
            } else {
                MessageBox.Show("Your Roblox version is out-of-date. No action has been taken.", "Uhh...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
