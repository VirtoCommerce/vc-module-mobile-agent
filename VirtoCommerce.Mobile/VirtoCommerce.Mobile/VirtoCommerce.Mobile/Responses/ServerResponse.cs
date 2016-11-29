namespace VirtoCommerce.Mobile.Responses
{
    /// <summary>
    /// Server get one object
    /// </summary>
    public class ServerResponse<T> : BaseResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { set; get; }
        
    }
}
