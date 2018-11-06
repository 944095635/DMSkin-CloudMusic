using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
