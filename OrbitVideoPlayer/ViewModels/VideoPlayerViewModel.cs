using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitVideoPlayer.ViewModels
{
    internal partial class VideoPlayerViewModel : ViewModelBase
    {
        private readonly LibVLC _vlc = new();
        public MediaPlayer MediaPlayer { get; private set; }
        public VideoPlayerViewModel()
        {
            MediaPlayer = new MediaPlayer(_vlc);
        }
        public void Dispose()
        {
            _vlc.Dispose();
        }

        #region Commands
        [RelayCommand]
        public void Play(Uri uri)
        {
            using var media = new Media(_vlc, uri);
            MediaPlayer.Play(media);
        }

        [RelayCommand]
        public void Stop()
        {
            MediaPlayer.Stop();
        }

        [RelayCommand]
        public void Pause()
        {
            MediaPlayer.Pause();
        }
        [RelayCommand]
        public void Seek(TimeSpan time)
        {
            MediaPlayer.SeekTo(time);
        }
        #endregion
    }
}
