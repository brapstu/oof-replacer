using System;
using System.Windows;
using System.IO;

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

        static string userName = Environment.UserName;
        readonly string MainDirectory = "C:/Users/" + userName + "/AppData/Local/Roblox/Versions";
        private void replace_click(object sender, RoutedEventArgs e)
        {
            string[] subdirs = Directory.GetDirectories(MainDirectory);
            string highDir;
            foreach (string subdir in Directory.GetDirectories(MainDirectory))
            {
                highDir = subdir + "/content/sounds";
                if (Directory.Exists(highDir + "/ouch.ogg"))
                {
                    File.Delete(highDir + "/ouch.ogg");
                    File.Copy("ouch.ogg", highDir, true);
                }
            }
            Progress.Text = "Sound has been updated!";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"ouch.wav");
            player.Play();
        }
    }
}
