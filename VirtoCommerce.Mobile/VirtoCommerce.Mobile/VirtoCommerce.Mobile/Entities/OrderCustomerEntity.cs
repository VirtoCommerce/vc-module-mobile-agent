using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class OrderCustomerEntity:BaseEntity
    {
        public string OrderId { set; get; }
        public string Email { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string CompanyName { set; get; }
        public string Address { set; get; }
        public string Apt { set; get; }
        public string City { set; get; }
        public string Coutry { set; get; }
        public string PostalCode { set; get; }
        public string Phone { set; get; }

    }
}
