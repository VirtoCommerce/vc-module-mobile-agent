using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Convertors;

namespace VirtoCommerce.Mobile.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICartService _cartService;
        private readonly IGlobalEventor _globalEventor;
        private readonly IShippingMethodsService _shippingMethodService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly Repositories.IOrderRepository _orderRepository;
        public OrderService(ICartService cartService, IGlobalEventor eventor, IShippingMethodsService shippingMethodService, IPaymentMethodService paymentService, Repositories.IOrderRepository orderReposytory)
        {
            _paymentMethodService = paymentService;
            _orderRepository = orderReposytory;
            _cartService = cartService;
            _globalEventor = eventor;
            _shippingMethodService = shippingMethodService;
        }
        public Order CreateOreder(OrderCreateCreteria creteria)
        { 
            
            var order = new Order {
                ShipmentId = creteria.ShippingId,
                Shipment = (double)creteria.Cart.Shipment,
                Customer = creteria.Customer,
                Discount = (double)creteria.Cart.Discount,
                Id = Guid.NewGuid().ToString(),
                SubTotal = (double)creteria.Cart.SubTotal,
                Taxes = (double)creteria.Cart.Taxes,
                Total = (double)creteria.Cart.Total,
                PaymentId = creteria.PaymentId
            };
            _orderRepository.StartTransaction();
            try
            {
                if (!_orderRepository.SaveOrder(order.ModelToEntity()))
                {
                    _orderRepository.RollbackTransaction();
                    return null;
                }
                foreach (var item in creteria.Cart.CartItems)
                {
                    var orderItem = new OrderItem
                    {
                        Currency = item.Currency.Code,
                        Discount = item.Discount,
                        ProductId = item.Product.Id,
                        Id = Guid.NewGuid().ToString(),
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        SubTotal = item.SubTotal
                    };
                    order.Items.Add(orderItem);
                    if (!_orderRepository.SaveOrderItem(orderItem.ModelToEntity()))
                    {
                        _orderRepository.RollbackTransaction();
                        return null;
                    }
                }

                order.Customer = creteria.Customer;
                if (string.IsNullOrEmpty(order.Customer.Id))
                {
                    order.Customer.Id = Guid.NewGuid().ToString();
                }
                var customerEntity = order.Customer.ModelToEntity();
                customerEntity.OrderId = order.Id;
                if (!_orderRepository.SaveOrderCustomer(customerEntity))
                {
                    _orderRepository.RollbackTransaction();
                    return null;
                }
                _orderRepository.EndTransaction();

                _cartService.ClearCart();
                _globalEventor.Publish(new Events.CartChangeEvent());
            }
            catch(Exception ex)
            {
                _orderRepository.RollbackTransaction();
            }
            return order;
        }

        public ICollection<PaymentMethod> PaymentMethods()
        {
            return _paymentMethodService.GetAllPaymentMethods();
        }

        public ICollection<ShippingMethod> ShippingMethods()
        {
            return _shippingMethodService.GetAllShippingMethods();
        }

        public ICollection<Order> GetNotSyncOrders()
        {
            var orders = _orderRepository.GetNotSyncOrders().Select(x => x.EntityToModel()).ToArray();
            foreach (var item in orders)
            {
                item.Items = _orderRepository.GetOrderItems(item.Id).Select(x => x.EntityToModel()).ToArray();
                item.Customer = _orderRepository.GetOrderCustomer(item.Id).EntityToModel();
            }
            return orders;
        }
        public void SetSyncStatusOrders(ICollection<Order> orders)
        {
            foreach (var order in orders)
            {
                _orderRepository.SaveOrder(order.ModelToEntity());
            }
        }
    }
}
