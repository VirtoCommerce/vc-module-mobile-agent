using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Events;

namespace VirtoCommerce.Mobile.Services
{
    public class GlobalEventor : IGlobalEventor
    {
        private Dictionary<string, List<object>> _events = new Dictionary<string, List<object>>();
        public void Publish<TParam>(TParam param) where TParam : BaseEvent
        {
            var t = param.GetType();
            foreach (var e in _events.Keys)
            {
                if (e == t.FullName)
                {
                    foreach (var act in _events[e].ToList())
                    {
                        (act as Action<TParam>)?.Invoke(param);
                    }
                    break;
                }
            }
        }

        public void Subscribe<T>(Action<T> action) where T : BaseEvent
        {
            var t = typeof(T);
            if (_events.ContainsKey(t.FullName))
            {
                _events[t.FullName].Add(action);
            }
            else
            {
                _events.Add(t.FullName, new List<object>() { action });
            }
        }

        public void UnSubcribe<T>(Action<T> action) where T : BaseEvent
        {
            var t = typeof(T);
            if (_events.ContainsKey(t.FullName))
            {
                _events[t.FullName].Remove(action);
            }
        }
    }
}
