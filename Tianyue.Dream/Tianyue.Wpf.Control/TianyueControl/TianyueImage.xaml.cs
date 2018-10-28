using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Tianyue.Utility;
using Tianyue.Utility.Extension;

namespace Tianyue.Wpf.Control
{

    /// <summary>
    /// TianyueImage.xaml 的交互逻辑
    /// </summary>
    public partial class TianyueImage : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(string), typeof(TianyueImage), new PropertyMetadata(OnSourcePropertyChanged));
        /// <summary>
        /// 资源设置，支持VectorIcon图标，例如：&#xe64e;同VectorIcon使用方法一样
        /// 支持图片资源路径（相对路径、绝对路径）
        /// </summary>
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        internal TextBlock VectorIcon { get { return this.VIcon; } }
        internal Image Image { get { return this.img; } }

        public TianyueImage()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += TianyueImage_Loaded;
        }

        void TianyueImage_Loaded(object sender, RoutedEventArgs e)
        {
            BindSource(this);
        }

        /// <summary>
        /// 属性更改处理事件
        /// </summary>
        private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            TianyueImage img = sender as TianyueImage;
            if (img == null) return;
            if (!img.IsLoaded) return;
            BindSource(img);
        }
        private static void BindSource(TianyueImage img)
        {
            var value = img.Source;
            
            if (value.IsNotNullOrEmptyOrWhiteSpace())
                return;

            if (value.Length == 1)
            {
                img.VectorIcon.Text = value;
                return;
            }

            img.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    var path = value.TrimStart(' ', '/', '\\');
                    //如果是相对路径则转换为绝对路径
                    //if (!System.IO.Path.IsPathRooted(path))
                    //{
                    //    path = File.GetPhysicalPath(path);
                    //}

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(path);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    img.Image.Source = bitmapImage;
                }
                catch { }
            }), DispatcherPriority.ApplicationIdle);
        }
    }
}
