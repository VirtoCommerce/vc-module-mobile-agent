using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class PropertyValue
    {
        /// <summary>
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        public PropertyValue() { }

        /// <summary>
        /// Initializes a new instance of the PropertyValue class.
        /// </summary>
        /// <param name="valueType">Possible values include: 'shortText',
        /// 'longText', 'number', 'dateTime', 'boolean'</param>
        public PropertyValue(string id = default(string), string propertyName = default(string), string propertyId = default(string), string languageCode = default(string), string alias = default(string), string valueType = default(string), string valueId = default(string), string value = default(string), bool? isInherited = default(bool?))
        {
            Id = id;
            PropertyName = propertyName;
            PropertyId = propertyId;
            LanguageCode = languageCode;
            Alias = alias;
            ValueType = valueType;
            ValueId = valueId;
            Value = value;
            IsInherited = isInherited;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "propertyName")]
        public string PropertyName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "propertyId")]
        public string PropertyId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'shortText', 'longText',
        /// 'number', 'dateTime', 'boolean'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "valueType")]
        public string ValueType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "valueId")]
        public string ValueId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isInherited")]
        public bool? IsInherited { get; set; }

    }
}
