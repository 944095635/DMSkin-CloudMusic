using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    /// <summary>
    /// 拥有 颜色 圆角值 属性的 滚动容器
    /// </summary>
    public class DMScrollViewer: ScrollViewer
    {
        #region 滑块默认颜色
        public SolidColorBrush ThemeColor
        {
            get { return (SolidColorBrush)GetValue(ThemeColorProperty); }
            set { SetValue(ThemeColorProperty, value); }
        }
        /// <summary>
        /// 滑块默认颜色
        /// </summary>
        public static readonly DependencyProperty ThemeColorProperty =
            DependencyProperty.Register("ThemeColor", typeof(SolidColorBrush), typeof(DMScrollViewer), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 200, 200, 200))));
        #endregion

        #region 滑块悬浮颜色
        public SolidColorBrush ThemeColorMouseOver
        {
            get { return (SolidColorBrush)GetValue(ThemeColorMouseOverProperty); }
            set { SetValue(ThemeColorMouseOverProperty, value); }
        }
        /// <summary>
        /// 滑块悬浮颜色
        /// </summary>
        public static readonly DependencyProperty ThemeColorMouseOverProperty =
            DependencyProperty.Register("ThemeColorMouseOver", typeof(SolidColorBrush), typeof(DMScrollViewer), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 180, 180, 180))));
        #endregion

        #region 滑块悬浮按下颜色
        public SolidColorBrush ThemeColorPressed
        {
            get { return (SolidColorBrush)GetValue(ThemeColorPressedProperty); }
            set { SetValue(ThemeColorPressedProperty, value); }
        }
        /// <summary>
        /// 滑块悬浮按下颜色
        /// </summary>
        public static readonly DependencyProperty ThemeColorPressedProperty =
            DependencyProperty.Register("ThemeColorPressed", typeof(SolidColorBrush), typeof(DMScrollViewer), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 180, 180, 180))));
        #endregion

        #region 圆角值X
        /// <summary>
        /// 圆角值X
        /// </summary>
        public double RadiusX
        {
            get { return (double)GetValue(RadiusXProperty); }
            set { SetValue(RadiusXProperty, value); }
        }
        public static readonly DependencyProperty RadiusXProperty =
            DependencyProperty.Register("RadiusX", typeof(double), typeof(DMScrollViewer), new PropertyMetadata(2.0));
        #endregion

        #region 圆角值Y
        /// <summary>
        /// 圆角值Y
        /// </summary>
        public double RadiusY
        {
            get { return (double)GetValue(RadiusYProperty); }
            set { SetValue(RadiusYProperty, value); }
        }
        public static readonly DependencyProperty RadiusYProperty =
            DependencyProperty.Register("RadiusY", typeof(double), typeof(DMScrollViewer), new PropertyMetadata(2.0));
        #endregion

        #region 滚动条大小
        /// <summary>
        /// 滚动条大小
        /// </summary>
        public double ScrollBarSize
        {
            get { return (double)GetValue(ScrollBarSizeProperty); }
            set { SetValue(ScrollBarSizeProperty, value); }
        }
        public static readonly DependencyProperty ScrollBarSizeProperty =
            DependencyProperty.Register("ScrollBarSize", typeof(double), typeof(DMScrollViewer), new PropertyMetadata(6.0)); 
        #endregion
    }
}
