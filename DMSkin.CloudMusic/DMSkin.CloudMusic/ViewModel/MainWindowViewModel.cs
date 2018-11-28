using DMSkin.CloudMusic.API;
using DMSkin.CloudMusic.Model;
using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.CloudMusic.ViewModel
{
    public class MainWindowViewModel:ViewModelBase
    {
        #region 初始化
        public MainWindowViewModel()
        {
            //初始化播放器
            PlayManager.player = Player;

            //Player.Position

            //Player.NaturalDuration.TimeSpan.TotalSeconds

            Task.Run(async () =>
            {
                while (true)
                {
                    //每隔900 毫秒更新 一次 播放数据
                    await Task.Delay(900);
                    if (PlayManager.State == PlayState.Play)
                    {
                        Execute.OnUIThread(()=> 
                        {
                            //获取当前进度
                            Position = Player.Position;
                            if (Player.NaturalDuration.HasTimeSpan)
                            {
                                Duration = Player.NaturalDuration.TimeSpan;
                            }
                        });
                    }
                }
            });
        } 
        #endregion

        #region 页面切换
        private Page currentPage = PageManager.PageEmpty;

        /// <summary>
        /// 当前页面
        /// </summary>
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private LeftMenu selectMenu;
        /// <summary>
        /// 选中的菜单
        /// </summary>
        public LeftMenu SelectMenu
        {
            get { return selectMenu; }
            set
            {
                selectMenu = value;
                switch (selectMenu)
                {
                    case LeftMenu.Home:
                        CurrentPage = PageManager.PageEmpty;
                        break;
                    //跳转到本地音乐
                    case LeftMenu.LocalMusic:
                        CurrentPage = PageManager.PageLocalMusic;
                        break;
                    case LeftMenu.DownLoad:
                        CurrentPage = PageManager.PageDownLoad;
                        break;
                    case LeftMenu.CloudMusic:
                        CurrentPage = PageManager.PageCloudMusic;
                        break;
                    case LeftMenu.Collection:
                        CurrentPage = PageManager.PageCollection;
                        break;
                }
                OnPropertyChanged("SelectMenu");
            }
        }

        #endregion

        #region 音乐播放器控制
        private MediaPlayer player =new MediaPlayer();
        /// <summary>
        /// 播放器
        /// </summary>
        public MediaPlayer Player
        {
            get {

                return player;
            }
            set
            {
                player = value;
                OnPropertyChanged("Player");
            }
        }

        private TimeSpan position;
        /// <summary>
        /// 播放进度
        /// </summary>
        public TimeSpan Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        private TimeSpan duration;

        /// <summary>
        /// 长度
        /// </summary>
        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }

        #endregion
    }
}
