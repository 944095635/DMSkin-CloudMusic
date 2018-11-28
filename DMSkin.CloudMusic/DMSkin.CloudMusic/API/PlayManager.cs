using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media;
using DMSkin.CloudMusic.Model;
using DMSkin.Core.Common;

namespace DMSkin.CloudMusic.API
{
    class PlayManager
    {
        public static PlayState State { get; internal set; }

        internal static void Play(Music music)
        {
            State = PlayState.Play;
            if (music.Url.Contains("http"))
            {
                if (!File.Exists(music.FileName))
                {
                    Task.Run(() =>
                    {
                        music.DownLoad = true;
                        using (WebClient wb = new WebClient())
                        {
                            wb.DownloadFile(music.Url, music.FileName);
                        }
                        music.DownLoad = false;
                        music.Url = music.FileName;
                        Open(music);
                    });
                    return;
                }
                else
                {
                    music.Url = music.FileName;
                }
            }
            Open(music);
        }

        public static void Open(Music music)
        {
            Execute.OnUIThread(() =>
            {
                player.Open(new Uri(music.Url, UriKind.RelativeOrAbsolute));
                player.Play();
            });
        }

        public static MediaPlayer player;
    }

    public enum PlayState
    {
        Play,
        Pause,
        Stop
    }
}
