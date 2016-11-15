using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Property(bool? isReadOnly = default(bool?), bool? isManageable = default(bool?), bool? isNew = default(bool?), string id = default(string), string catalogId = default(string), string categoryId = default(string), string name = default(string), bool? required = default(bool?), bool? dictionary = default(bool?), bool? multivalue = default(bool?), bool? multilanguage = default(bool?), string valueType = default(string), string type = default(string), System.Collections.Generic.IList<PropertyValue> values = default(System.Collections.Generic.IList<PropertyValue>), System.Collections.Generic.IList<PropertyDictionaryValue> dictionaryValues = default(System.Collections.Generic.IList<PropertyDictionaryValue>), System.Collections.Generic.IList<PropertyAttribute> attributes = default(System.Collections.Generic.IList<PropertyAttribute>), System.Collections.Generic.IList<PropertyDisplayName> displayNames = default(System.Collections.Generic.IList<PropertyDisplayName>), bool? isInherited = default(bool?))
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "isReadOnly")]
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isManageable")]
        public bool? IsManageable { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isNew")]
        public bool? IsNew { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dictionary")]
        public bool? Dictionary { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "multivalue")]
        public bool? Multivalue { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "multilanguage")]
        public bool? Multilanguage { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'shortText', 'longText',
        /// 'number', 'dateTime', 'boolean'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "valueType")]
        public string ValueType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'product', 'variation',
        /// 'category', 'catalog'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "values")]
        public System.Collections.Generic.IList<PropertyValue> Values { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dictionaryValues")]
        public System.Collections.Generic.IList<PropertyDictionaryValue> DictionaryValues { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "attributes")]
        public System.Collections.Generic.IList<PropertyAttribute> Attributes { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "displayNames")]
        public System.Collections.Generic.IList<PropertyDisplayName> DisplayNames { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isInherited")]
        public bool? IsInherited { get; set; }

    }
}
