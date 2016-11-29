using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class Property
    {
        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        public Property() { }

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        /// <param name="valueType">Possible values include: 'shortText',
        /// 'longText', 'number', 'dateTime', 'boolean'</param>
        /// <param name="type">Possible values include: 'product',
        /// 'variation', 'category', 'catalog'</param>
        public Property(bool? isReadOnly = default(bool?), bool? isManageable = default(bool?), bool? isNew = default(bool?), string id = default(string), string catalogId = default(string), string categoryId = default(string), string name = default(string), bool? required = default(bool?), bool? dictionary = default(bool?), bool? multivalue = default(bool?), bool? multilanguage = default(bool?), string valueType = default(string), string type = default(string), IList<PropertyValue> values = default(IList<PropertyValue>), IList<PropertyDictionaryValue> dictionaryValues = default(IList<PropertyDictionaryValue>), IList<PropertyAttribute> attributes = default(IList<PropertyAttribute>), IList<PropertyDisplayName> displayNames = default(IList<PropertyDisplayName>), bool? isInherited = default(bool?))
        {
            IsReadOnly = isReadOnly;
            IsManageable = isManageable;
            IsNew = isNew;
            Id = id;
            CatalogId = catalogId;
            CategoryId = categoryId;
            Name = name;
            Required = required;
            Dictionary = dictionary;
            Multivalue = multivalue;
            Multilanguage = multilanguage;
            ValueType = valueType;
            Type = type;
            Values = values;
            DictionaryValues = dictionaryValues;
            Attributes = attributes;
            DisplayNames = displayNames;
            IsInherited = isInherited;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isReadOnly")]
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isManageable")]
        public bool? IsManageable { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNew")]
        public bool? IsNew { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dictionary")]
        public bool? Dictionary { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "multivalue")]
        public bool? Multivalue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "multilanguage")]
        public bool? Multilanguage { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'shortText', 'longText',
        /// 'number', 'dateTime', 'boolean'
        /// </summary>
        [JsonProperty(PropertyName = "valueType")]
        public string ValueType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'product', 'variation',
        /// 'category', 'catalog'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IList<PropertyValue> Values { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dictionaryValues")]
        public IList<PropertyDictionaryValue> DictionaryValues { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public IList<PropertyAttribute> Attributes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayNames")]
        public IList<PropertyDisplayName> DisplayNames { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isInherited")]
        public bool? IsInherited { get; set; }

    }
}
