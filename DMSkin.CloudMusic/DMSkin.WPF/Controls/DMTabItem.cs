using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMTabItem : TabItem
    {

        /// <summary>
        /// 选中背景色
        /// </summary>
        public SolidColorBrush SelectedColor
        {
            get { return (SolidColorBrush)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(SolidColorBrush), typeof(DMTabItem), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 124, 125, 133))));

        /// <summary>
        /// 选中文字颜色
        /// </summary>
        public SolidColorBrush SelectedForeground
        {
            get { return (SolidColorBrush)GetValue(SelectedForegroundProperty); }
            set { SetValue(SelectedForegroundProperty, value); }
        }
        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.Register("SelectedForeground", typeof(SolidColorBrush), typeof(DMTabItem), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 229, 229, 231))));


        /// <summary>
        /// 鼠标悬浮背景色
        /// </summary>
        public SolidColorBrush HoverColor
        {
            get { return (SolidColorBrush)GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }

        public static readonly DependencyProperty HoverColorProperty =
            DependencyProperty.Register("HoverColor", typeof(SolidColorBrush), typeof(DMTabItem), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 220, 220, 220))));




        public TabItemType TabItemType
        {
            get { return (TabItemType)GetValue(TabItemTypeProperty); }
            set {
                SetValue(TabItemTypeProperty, value);
            }
        }
        public static readonly DependencyProperty TabItemTypeProperty =
            DependencyProperty.Register("TabItemType", typeof(TabItemType), typeof(DMTabItem), new PropertyMetadata(TabItemType.Middle));
    }

    public enum TabItemType
    {
        Left,Middle,Right
    }
}
