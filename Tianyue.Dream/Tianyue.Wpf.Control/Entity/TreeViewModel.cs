using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Wpf.Control
{
    /// <summary>
    /// TreeViewModel
    /// </summary>
    public class TreeViewModel : NotifyPropertyBase
    {

        public TreeViewModel()
        {

        }
        
        /// <summary>
        /// 父节点
        /// </summary>
        public TreeViewModel Parent
        {
            get;
            set;
        }
        
        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeViewModel> Children
        {
            get;
            set;
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName
        {
            get;
            set;
        }

        /// <summary>
        /// 节点名称
        /// </summary>
        public Guid NID
        {
            get;
            set;
        }


        public TreeViewModel(string strNodeName)
        {
            this.NodeName = strNodeName;
            this.Children = new List<TreeViewModel>();
        }
        
        /// <summary>
        /// 节点选中状态
        /// </summary>
        public bool? _isChecked;

        /// <summary>
        /// 节点选中状态
        /// </summary>
        public bool? IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                SetIsChecked(value, true, true);
            }
        }

        private void SetIsChecked(bool? value, bool checkedChildren, bool checkedParent)
        {
            if (_isChecked == value)
                return;

            _isChecked = value;

            //选中和取消子类
            if (checkedChildren && value.HasValue && Children != null)
                Children.ForEach(ch => ch.SetIsChecked(value, true, false));

            //选中和取消父类
            if (checkedParent && this.Parent != null)
                this.Parent.CheckParentCheckState();

            //通知更改

            this.SetProperty(x => x.IsChecked);
        }

        /// <summary>
        /// 检查父类是否选中
        /// 如果父类的子类中有一个和第一个子类的状态不一样父类ischecked为null
        /// </summary>
        private void CheckParentCheckState()
        {
            bool? _currentState = this.IsChecked;
            bool? _firstState = null;
            for (int i = 0; i < this.Children.Count(); i++)
            {
                bool? childrenState = this.Children[i].IsChecked;
                if (i == 0)
                {
                    _firstState = childrenState;
                }
                else if (_firstState != childrenState)
                {
                    _firstState = null;
                }
            }
            if (_firstState != null) _currentState = _firstState;
            SetIsChecked(_firstState, false, true);
        }
        
        /// <summary>
        /// 选中的行
        /// </summary>
        bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                this.SetProperty(x => x.IsChecked);
                if (_isSelected)
                {
                    SelectedTreeItem = this;
                    //MessageBox.Show("选中的是" + SelectedTreeItem.Name);
                }
                else
                    SelectedTreeItem = null;
            }
        }

        /// <summary>
        /// 选中的节点
        /// </summary>
        public TreeViewModel SelectedTreeItem
        {
            get;
            set;
        }
        
        /// <summary>
        /// 创建树
        /// </summary>
        /// <param name="children"></param>
        /// <param name="isChecked"></param>
        public void CreateTreeWithChildren(TreeViewModel children, bool? isChecked)
        {
            this.Children.Add(children);

            children.Parent = this;
            children.IsChecked = isChecked;
        }

    }

    public class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class CommonFun
    {
        /// <summary>
        /// 返回属性名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T, U>(Expression<Func<T, U>> expr)
        {
            string _propertyName = "";
            if (expr.Body is MemberExpression)
            {
                _propertyName = (expr.Body as MemberExpression).Member.Name;
            }
            else if (expr.Body is UnaryExpression)
            {
                _propertyName = ((expr.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            }
            return _propertyName;
        }
    }

    /// <summary>
    /// 扩展方法
    /// 避免硬编码问题
    /// </summary>
    public static class NotifyPropertyBaseEx
    {
        public static void SetProperty<T, U>(this T tvm, Expression<Func<T, U>> expre) where T : NotifyPropertyBase, new()
        {
            string _pro = CommonFun.GetPropertyName(expre);
            tvm.OnPropertyChanged(_pro);
        }
    }
}
