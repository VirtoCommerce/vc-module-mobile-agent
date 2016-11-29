using VirtoCommerce.Mobile.Enums;

namespace VirtoCommerce.Mobile.Responses
{
    public class SyncResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// Sync status
        /// </summary>
        public SyncStatus SyncStatus { set; get; } = SyncStatus.Ok;
    }
}
