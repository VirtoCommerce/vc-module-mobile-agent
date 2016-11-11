using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Services
{
    public interface IGlobalEventor
    {
        void Subscribe(Type eventType, Action action);
        void Publish(Type eventType);
        void UnSubcribe(Type eventType, Action action);
    }
}
