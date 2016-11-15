using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Events;

namespace VirtoCommerce.Mobile.Services
{
    public interface IGlobalEventor
    {
        void Subscribe<T>(Action<T> action) where T : BaseEvent;
        void Publish<TParam>(TParam eventType) where TParam : BaseEvent;
        void UnSubcribe<T>(Action<T> action) where T: BaseEvent;
    }
}
