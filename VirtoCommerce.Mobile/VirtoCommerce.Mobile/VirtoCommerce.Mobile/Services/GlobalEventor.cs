using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Services
{
    public class GlobalEventor : IGlobalEventor
    {
        private Dictionary<string, List<Action>> _events = new Dictionary<string, List<Action>>();
        public void Publish(Type eventType)
        {
            foreach (var e in _events.Keys)
            {
                if (e == eventType.FullName)
                {
                    foreach (var act in _events[e])
                    {
                        act?.Invoke();
                    }
                    break;
                }
            }
        }

        public void Subscribe(Type eventType, Action action)
        {
            if (_events.ContainsKey(eventType.FullName))
            {
                _events[eventType.FullName].Add(action);
            }
            else
            {
                _events.Add(eventType.FullName, new List<Action>() { action });
            }
        }

        public void UnSubcribe(Type eventType, Action action)
        {
            if (_events.ContainsKey(eventType.FullName))
            {
                _events[eventType.FullName].Remove(action);
            }
        }
    }
}
