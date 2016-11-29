using System.Linq;
using ApiClientModel = VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class OrderConvertor
    {
        public static Entities.OrderEntity ModelToEntity(this Model.Order order)
        {
            return new Entities.OrderEntity
            {
                Discount = order.Discount,
                PaymentId = order.PaymentId,
                Shipment = order.Shipment,
                ShipmentId = order.ShipmentId,
                SubTotal = order.SubTotal,
                Taxes = order.Taxes,
                Total = order.Total,
                Id = order.Id,
                IsSync = order.IsSync
            };
        }
        public static Model.Order EntityToModel(this Entities.OrderEntity order)
        {
            return new Model.Order
            {
                Discount = order.Discount,
                PaymentId = order.PaymentId,
                Shipment = order.Shipment,
                ShipmentId = order.ShipmentId,
                SubTotal = order.SubTotal,
                Taxes = order.Taxes,
                Total = order.Total,
                Id = order.Id,
                IsSync = order.IsSync
            };
        }

        public static ApiClientModel.Order ModelToApiModel(this Model.Order order)
        {
            return new ApiClientModel.Order
            {
                Discount = order.Discount,
                PaymentId = order.PaymentId,
                Shipment = order.Shipment,
                ShipmentId = order.ShipmentId,
                SubTotal = order.SubTotal,
                Taxes = order.Taxes,
                Total = order.Total,
                Id = order.Id,
                IsSync = order.IsSync,
                Items = order.Items.Select(x => x.ModelToApiModel()).ToArray(),
                Customer = order.Customer.ModelToApiModel()
            };
        }

        public static Entities.OrderItemEntity ModelToEntity(this Model.OrderItem item)
        {
            return new Entities.OrderItemEntity
            {
                Id = item.Id,
                Currency = item.Currency,
                SubTotal = item.SubTotal,
                Discount = item.Discount,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }
        public static Model.OrderItem EntityToModel(this Entities.OrderItemEntity item)
        {
            return new Model.OrderItem
            {
                Id = item.Id,
                Currency = item.Currency,
                SubTotal = item.SubTotal,
                Discount = item.Discount,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }
        public static ApiClientModel.OrderItem ModelToApiModel(this Model.OrderItem item)
        {
            return new ApiClientModel.OrderItem
            {
                Id = item.Id,
                Currency = item.Currency,
                SubTotal = item.SubTotal,
                Discount = item.Discount,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }

        public static Entities.OrderCustomerEntity ModelToEntity(this Model.Customer customer)
        {
            return new Entities.OrderCustomerEntity
            {
                Id = customer.Id,
                City = customer.City,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Address = customer.Address,
                Apt = customer.Apt,
                CompanyName = customer.CompanyName,
                Coutry = customer.Coutry,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
            };
        }
        public static Model.Customer EntityToModel(this Entities.OrderCustomerEntity customer)
        {
            return new Model.Customer
            {
                Id = customer.Id,
                City = customer.City,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Address = customer.Address,
                Apt = customer.Apt,
                CompanyName = customer.CompanyName,
                Coutry = customer.Coutry,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
            };
        }
        public static ApiClientModel.Customer ModelToApiModel(this Model.Customer customer)
        {
            return new ApiClientModel.Customer
            {
                Id = customer.Id,
                City = customer.City,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Address = customer.Address,
                Apt = customer.Apt,
                CompanyName = customer.CompanyName,
                Coutry = customer.Coutry,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
            };
        }
    }
}
