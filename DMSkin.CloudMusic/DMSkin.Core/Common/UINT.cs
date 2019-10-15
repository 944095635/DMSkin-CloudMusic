using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSkin.Core.Common
{
    public class UINT
    {
        /// <summary>
        /// 将数据转换为
        /// </summary>
        /// <param name="size">数值</param>
        /// <param name="fromtype">从类型</param>
        /// <param name="totype">到类型</param>
        /// <param name="count">小数点后位数</param>
        public static string ToSize(UINTYPE fromtype,double size,int count = 2)
        {
            double temp = size;
            double mod = 1024.0;
            switch (fromtype)
            {
                case UINTYPE.KB:
                    temp = size * mod;
                    break;
                case UINTYPE.MB:
                    temp = size * mod * mod;
                    break;
                case UINTYPE.GB:
                    temp = size * mod * mod * mod;
                    break;
            }

            string[] units = new string[] { "B", "KB", "MB", "GB", "TB"};
            int i = 0;
            while (temp >= mod)
            {
                temp /= mod;
                i++;
            }
            return Math.Round(temp,count) + units[i];
        }
    }

    public enum UINTYPE
    {
        B,
        KB,
        MB,
        GB
    }
}
