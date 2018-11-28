using DMSkin.CloudMusic.API;
using DMSkin.CloudMusic.Model;
using DMSkin.Core.MVVM;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DMSkin.CloudMusic.ViewModel
{
    /// <summary>
    /// 这是播放页面的基类
    /// </summary>
    public class MusicViewModelBase :ViewModelBase
    {
        #region 选中的音乐
        private Music selectedMusic;
        /// <summary>
        /// 选中的音乐
        /// </summary>
        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged("SelectedMusic");
            }
        }
        #endregion

        #region 播放操作
        /// <summary>
        /// 播放操作
        /// </summary>
        public ICommand PlayCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedMusic != null)
                    {
                        PlayManager.Play(SelectedMusic);
                    }
                });
            }
        }
        #endregion

        #region 音乐列表
        private ObservableCollection<Music> musicList;
        /// <summary>
        /// 音乐列表
        /// </summary>
        public ObservableCollection<Music> MusicList
        {
            get
            {
                if (musicList == null)
                {
                    musicList = new ObservableCollection<Music>();
                }
                return musicList;
            }
            set
            {
                musicList = value;
                OnPropertyChanged("MusicList");
            }
        }
        #endregion

        #region 是否显示歌曲列表
        private bool displayMusicList;
        /// <summary>
        /// 是否显示歌曲列表
        /// </summary>
        public bool DisplayMusicList
        {
            get { return displayMusicList; }
            set
            {
                displayMusicList = value;
                OnPropertyChanged("DisplayMusicList");
            }
        }

        public void ShowMusicList(bool show = true)
        {
            if (MusicList.Count>0)
            {
                DisplayMusicList = show;
            }
            else
            {
                //歌曲列表为空的时候 隐藏 歌曲列表视图
                DisplayMusicList = false;
            }
        }
        #endregion
    }
}
