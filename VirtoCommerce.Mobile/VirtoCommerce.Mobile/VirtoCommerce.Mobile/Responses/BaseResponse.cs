using VirtoCommerce.Mobile.Enums;

namespace VirtoCommerce.Mobile.Responses
{
    /// <summary>
    /// Base class for response from server
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// Status response
        /// </summary>
        public ResponseStatus Status { set; get; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { set; get; }
    }
}
