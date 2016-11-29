using System;
using VirtoCommerce.Mobile.Events;

namespace VirtoCommerce.Mobile.Services
{
    public interface IGlobalEventor
    {
        void Subscribe<T>(Action<T> action) where T : BaseEvent;
        void Publish<TParam>(TParam eventType) where TParam : BaseEvent;
        void Unsubscribe<T>(Action<T> action) where T: BaseEvent;
    }
}
