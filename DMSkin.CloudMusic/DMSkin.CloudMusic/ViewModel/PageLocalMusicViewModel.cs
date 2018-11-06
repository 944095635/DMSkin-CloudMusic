using DMSkin.CloudMusic.API;
using DMSkin.CloudMusic.Model;
using DMSkin.WPF;
using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkin.CloudMusic.ViewModel
{
    public class PageLocalMusicViewModel : ViewModelBase
    {
        public PageLocalMusicViewModel()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

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

        /// <summary>
        /// 新增文件夹
        /// </summary>
        public ICommand AddFileCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//注意，此处一定要手动引入System.Window.Forms空间，否则你如果使用默认的DialogResult会发现没有OK属性
                    {
                        //openFileDialog.SelectedPath;
                        //查找文件夹中的数据

                        Task.Run(() =>
                        {
                            int index = 1;
                            List<Music> TempList = new List<Music>();
                            string[] filelist = Directory.GetFiles(openFileDialog.SelectedPath);
                            foreach (var item in filelist)
                            {
                                FileInfo file = new FileInfo(item);
                                if (file.Extension.Contains(".mp3"))
                                {
                                    TempList.Add(new Music()
                                    {
                                        Title = file.Name,
                                        Size = file.Length,
                                        Index = index.ToString()
                                    });
                                    index++;
                                }
                            }
                            if (TempList.Count > 0)
                            {
                                Execute.OnUIThread(()=> 
                                {
                                    foreach (var item in TempList)
                                    {
                                        MusicList.Add(item);
                                    }
                                    DisplayMusicList = true;
                                });
                            }
                        });
                    }
                });
            }
        }



        /// <summary>
        /// 播放操作
        /// </summary>
        public ICommand PlayCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectMusic != null )
                    {
                        PlayManager.Play(SelectMusic);
                    }
                });
            }
        }


        private Music selectMusic;

        /// <summary>
        /// 选中的英语
        /// </summary>
        public Music SelectMusic
        {
            get { return selectMusic; }
            set
            {
                selectMusic = value;
                OnPropertyChanged("SelectMusic");
            }
        }



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

    }
}
