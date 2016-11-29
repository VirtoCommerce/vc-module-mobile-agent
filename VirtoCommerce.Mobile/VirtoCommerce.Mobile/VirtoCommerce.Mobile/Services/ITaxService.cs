using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface ITaxService
    {

        /// <summary>
        /// Get current tax
        /// </summary>
        Tax GetCurrentTax();
    }
}
