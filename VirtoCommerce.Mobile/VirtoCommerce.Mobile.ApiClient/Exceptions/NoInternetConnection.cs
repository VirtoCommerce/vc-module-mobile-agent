using System;

namespace VirtoCommerce.Mobile.ApiClient.Exceptions
{
    public class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException(string message) : base(message)
        { }
        public NoInternetConnectionException() { }
    }
}
