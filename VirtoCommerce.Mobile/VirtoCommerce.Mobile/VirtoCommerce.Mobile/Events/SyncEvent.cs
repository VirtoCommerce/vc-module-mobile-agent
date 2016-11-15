using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Events
{
    public class SyncEvent : BaseEvent
    {
        public bool IsEnd { private set; get; }
        public bool IsError {private set; get; }
        public bool IsWarning { private set; get; }
        public string Message { private set; get; }
        public SyncEvent(bool isEnd)
        {
            IsEnd = isEnd;
        }
        public SyncEvent SetError(bool isError)
        {
            IsError = isError;
            return this;
        }
        public SyncEvent SetWarning(bool isWarning)
        {
            IsWarning = isWarning;
            return this;
        }
        public SyncEvent SetMessage(string message)
        {
            Message = message;
            return this;
        }
    }
}
