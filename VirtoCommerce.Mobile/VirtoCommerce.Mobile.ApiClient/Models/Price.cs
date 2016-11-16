using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class Price
    {
        /// <summary>
        /// Initializes a new instance of the Price class.
        /// </summary>
        public Price() { }

        /// <summary>
        /// Initializes a new instance of the Price class.
        /// </summary>
        /// <param name="sale">Sale price of a product. It can be null, then
        /// Sale price will be equal List price</param>
        /// <param name="list">Price of a product. It can be catalog price or
        /// purchase price</param>
        /// <param name="minQuantity">It defines the minimum quantity of
        /// Products. Use it for creating tier prices.</param>
        public Price(string pricelistId = default(string), string priceListName = default(string), string currency = default(string), string productId = default(string), double? sale = default(double?), double? list = default(double?), int? minQuantity = default(int?), System.DateTime? createdDate = default(System.DateTime?), System.DateTime? modifiedDate = default(System.DateTime?), string createdBy = default(string), string modifiedBy = default(string), string id = default(string))
        {
            PricelistId = pricelistId;
            PriceListName = priceListName;
            Currency = currency;
            ProductId = productId;
            Sale = sale;
            List = list;
            MinQuantity = minQuantity;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            Id = id;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "pricelistId")]
        public string PricelistId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "priceListName")]
        public string PriceListName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets sale price of a product. It can be null, then Sale
        /// price will be equal List price
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sale")]
        public double? Sale { get; set; }

        /// <summary>
        /// Gets or sets price of a product. It can be catalog price or
        /// purchase price
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "list")]
        public double? List { get; set; }

        /// <summary>
        /// Gets or sets it defines the minimum quantity of Products. Use it
        /// for creating tier prices.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "minQuantity")]
        public int? MinQuantity { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdDate")]
        public System.DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedDate")]
        public System.DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
