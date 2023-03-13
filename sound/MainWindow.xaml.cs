using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using System.Windows.Threading;



namespace sound
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private List<string> filenames = new List<string>();
        private int currentTrackIndex = -1;
        private DispatcherTimer timer = new DispatcherTimer();
        private bool isReplayOn = false;


        public MainWindow()
        {
            InitializeComponent();

            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;

            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        



        private void MediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                track_mesto.Minimum = 0;
                track_mesto.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                track_mesto.TickFrequency = 1;
                track_mesto.IsSnapToTickEnabled = true;
                track_mesto.ValueChanged -= track_mesto_ValueChanged;
                track_mesto.ValueChanged += track_mesto_ValueChanged;

                timer.Start();

                TimeSpan totalDuration = mediaPlayer.NaturalDuration.TimeSpan;
                music_duration.Text = $"{totalDuration.Hours:D2}:{totalDuration.Minutes:D2}:{totalDuration.Seconds:D2}";
            }
        }


        private void Open(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                Multiselect = true,
                DefaultExtension = ".mp3"
            };
            fileDialog.Filters.Add(new CommonFileDialogFilter("MP3 files", "*.mp3"));
            var result = fileDialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                foreach (string filename in fileDialog.FileNames)
                {
                    track_list.Items.Add(System.IO.Path.GetFileName(filename));
                    filenames.Add(filename);
                }

                currentTrackIndex = 0;
                PlayTrack();
            }
        }


        private void Play(object sender, RoutedEventArgs e)
        {
            int index = track_list.SelectedIndex;
            if (index >= 0)
            {
                currentTrackIndex = index;
                PlayTrack();
            }
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            int index = currentTrackIndex;

            if (index == 0)
            {
                index = filenames.Count - 1;
            }
            else
            {
                index--;
            }

            currentTrackIndex = index;
            PlayTrack();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            int index = currentTrackIndex;

            if (index == filenames.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            currentTrackIndex = index;
            PlayTrack();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (isReplayOn)
            {
                mediaPlayer.Position = TimeSpan.Zero;
            }
            else if (currentTrackIndex < filenames.Count - 1)
            {
                currentTrackIndex++;
                PlayTrack();
            }
        }
        private void Repeat(object sender, RoutedEventArgs e)
        {
            isReplayOn = !isReplayOn;
            if (isReplayOn)
            {
                replay_button.Label = "Replay On";
            }
            else
            {
                replay_button.Label = "Replay Off";
            }
        }
        private void PlayTrack()
        {
            if (currentTrackIndex >= 0 && currentTrackIndex < filenames.Count)
            {
                track_list.SelectedIndex = currentTrackIndex;
                if (isReplayOn && mediaPlayer.Position == TimeSpan.Zero && currentTrackIndex != 0)
                {
                    currentTrackIndex--;
                }
                else
                {
                    mediaPlayer.Open(new Uri(filenames[currentTrackIndex]));
                    mediaPlayer.Play();
                    track_mesto.Value = 0;
                }
            }
        }
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int n = filenames.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = filenames[k];
                filenames[k] = filenames[n];
                filenames[n] = value;
            }
            currentTrackIndex = 0;
            PlayTrack();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                track_mesto.Value = mediaPlayer.Position.TotalMilliseconds;
                TimeSpan currentPosition = mediaPlayer.Position;
                current_time.Text = $"{currentPosition.Hours:D2}:{currentPosition.Minutes:D2}:{currentPosition.Seconds:D2}";
            }
        }
        private void track_mesto_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = TimeSpan.FromMilliseconds(track_mesto.Value);
        }

    }

}
