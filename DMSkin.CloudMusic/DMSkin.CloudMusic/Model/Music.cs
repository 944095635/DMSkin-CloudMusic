using DMSkin.Core.MVVM;
using System;

namespace DMSkin.CloudMusic.Model
{
    public class Music:ViewModelBase
    {
        private string index;

        /// <summary>
        /// 序号
        /// </summary>
        public string Index
        {
            get { return index; }
            set
            {
                index = value;
                OnPropertyChanged("Index");
            }
        }

        private string url;
        /// <summary>
        /// 路径
        /// </summary>
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("Url");
            }
        }



        private string title;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private double size;

        /// <summary>
        /// 体积
        /// </summary>
        public double Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        /// <summary>
        /// 体积-MB
        /// </summary>
        public string SizeStr
        {
            get {
                return HumanReadableFilesize(size);
            }
        }

        private String HumanReadableFilesize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size,2) + units[i];
        }

        private string album;

        /// <summary>
        /// 专辑
        /// </summary>
        public string Album
        {
            get { return album; }
            set
            {
                album = value;
                OnPropertyChanged("Album");
            }
        }


        private string artist;

        /// <summary>
        /// 作者
        /// </summary>
        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                OnPropertyChanged("Artist");
            }
        }


        private string timeStr;

        /// <summary>
        /// 
        /// </summary>
        public string TimeStr
        {
            get { return timeStr; }
            set
            {
                timeStr = value;
                OnPropertyChanged("TimeStr");
            }
        }

        public string FileName { get; internal set; }


        private bool download;

        /// <summary>
        /// 是否在下载
        /// </summary>
        public bool DownLoad
        {
            get { return download; }
            set
            {
                download = value;
                OnPropertyChanged("DownLoad");
            }
        }

    }
}
