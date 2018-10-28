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
    /// TianyueTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class TianyueTreeView : UserControl
    {
        /// <summary>
        /// 控件数据
        /// </summary>
        private IList<TreeViewModel> _itemsSourceData;

        public TianyueTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 控件数据
        /// </summary>
        public IList<TreeViewModel> ItemsSourceData
        {
            get { return _itemsSourceData; }
            set
            {
                _itemsSourceData = value;
                tvTree.ItemsSource = _itemsSourceData;
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }


        private void treeNode_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (item != null)
            {
                item.Focus();
                eachCheckedNode();
                e.Handled = true;
            }
        }

        private void eachCheckedNode()
        {
            if (tvTree.SelectedItem != null)
            {
                TreeViewModel tree = (TreeViewModel)tvTree.SelectedItem;
                //tree.SetChildrenChecked(tree.IsChecked);
                //tree.Parent.SelectedTreeItem();
            }
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns></returns>
        public IList<TreeViewModel> CheckedItemsIgnoreRelation()
        {
            return GetCheckedItemsIgnoreRelation(_itemsSourceData);
        }

        /// <summary>
        /// 私有方法，忽略层次关系的情况下，获取选中项
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<TreeViewModel> GetCheckedItemsIgnoreRelation(IList<TreeViewModel> list)
        {
            IList<TreeViewModel> treeList = new List<TreeViewModel>();
            foreach (var tree in list)
            {
                if ((bool)tree.IsChecked)
                {
                    treeList.Add(tree);
                }
                foreach (var child in GetCheckedItemsIgnoreRelation(tree.Children))
                {
                    treeList.Add(child);
                }
            }
            return treeList;
        }
    }

}
