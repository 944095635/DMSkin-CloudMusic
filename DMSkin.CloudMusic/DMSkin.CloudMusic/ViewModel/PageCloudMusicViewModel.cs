using DMSkin.Core.MVVM;
using System;
using System.Windows.Input;

namespace DMSkin.CloudMusic.ViewModel
{
    public class PageCloudMusicViewModel: MusicViewModelBase
    {
        public PageCloudMusicViewModel()
        {
            //这里添加几个 测试的云盘歌曲

            MusicList.Add(new Model.Music()
            {
                Album = "SoundLift s High State Mix",
                Title = "Summer Kisses (SoundLift s High State Mix)",
                Artist = "Eric de la Vega",
                Size = 4946933,
                TimeStr = "05:09",
                Index = "01",
                Url = "https://raw.githubusercontent.com/944095635/TEST/master/Eric%20de%20la%20Vega%20-%20Summer%20Kisses%20(SoundLift%20s%20High%20State%20Mix)%20Midnight%20Coast.mp3",
                FileName = "Summer Kisses.mp3"
            });
            MusicList.Add(new Model.Music()
            {
                Album = "变形金刚",
                Title = "变形金刚塞伯特传奇",
                Artist = "变形金刚",
                Size = 641184,
                TimeStr = "00:32",
                Index = "02",
                Url = "https://raw.githubusercontent.com/944095635/TEST/master/Transformers30secsR3.mp3",
                FileName = "Transformers30secsR3.mp3"
            });

            ShowMusicList();
        }

        private double cloudMaxSize = 100;

        /// <summary>
        /// 最大云盘容量
        /// </summary>
        public double CloudMaxSize
        {
            get { return cloudMaxSize; }
            set
            {
                cloudMaxSize = value;
                OnPropertyChanged("CloudMaxSize");
            }
        }

        private double cloudSize = 90;

        /// <summary>
        /// 云盘容量
        /// </summary>
        public double CloudSize
        {
            get { return cloudSize; }
            set
            {
                cloudSize = value;
                OnPropertyChanged("CloudSize");
            }
        }



        /// <summary>
        /// 测试增加云盘体积
        /// </summary>
        public ICommand AddSizeCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    CloudMaxSize +=Math.Round(new Random().NextDouble() * 10,2);
                });
            }
        }

    }
}
