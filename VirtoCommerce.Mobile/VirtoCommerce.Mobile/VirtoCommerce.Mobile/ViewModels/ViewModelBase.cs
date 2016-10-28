using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class ViewModelBase : NotifyPropertyChanged
    {
        private string _title;
        protected bool _isBusy;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title == value)
                {
                    return;
                }

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged();
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy == value) return;

                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Called when being navigated to.
        /// </summary>
        public virtual void OnNavigatingTo()
        {
        }

        /// <summary>
        /// Called when being navigated away from.
        /// </summary>
        public virtual void OnNavigatingFrom()
        {
        }
    }

    public abstract class NotifyPropertyChanged : INotifyPropertyChangedBase, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string whichProperty = null)
        {
            var changedArgs = new PropertyChangedEventArgs(whichProperty);
            RaisePropertyChanged(changedArgs);
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = property.GetPropertyNameFromExpression();
            RaisePropertyChanged(name);
        }

        public void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                try
                {
                    handler(this, changedArgs);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public virtual void Dispose()
        {
            //Super awesome trick to wipe attached event handlers
            if (PropertyChanged == null)
            {
                return;
            }

            var invocation = PropertyChanged.GetInvocationList();
            foreach (var p in invocation)
            {
                PropertyChanged -= (PropertyChangedEventHandler)p;
            }
        }
    }

    public interface INotifyPropertyChangedBase : INotifyPropertyChanged
    {
        void RaisePropertyChanged([CallerMemberName] string whichProperty = null);
    }

    public static class ExpressionExtension
    {
        public static string GetPropertyNameFromExpression<T>(this Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                return string.Empty;
            }

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                return string.Empty;
            }

            var member = memberExpression.Member as PropertyInfo;
            if (member == null)
            {
                return string.Empty;
            }

            if (member.DeclaringType == null)
            {
                return string.Empty;
            }

            return member.Name;
        }
    }

}
