using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VirtoCommerce.CatalogModule.Web.Converters;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Domain.Pricing.Model.Search;
using VirtoCommerce.Domain.Pricing.Services;
using VirtoCommerce.Mobile.SyncModule.Web.Models;
using VirtoCommerce.Platform.Core.Assets;
using System.Web.Http.Description;
using VirtoCommerce.Mobile.SyncModule.Data.Services;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Domain.Shipping.Model;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Mobile.SyncModule.Web.Convertors;

namespace VirtoCommerce.Mobile.SyncModule.Web.Controllers.Api
{
    [RoutePrefix("api/mobile/sync")]
    public class SyncController : ApiController
    {
        private readonly ICatalogSearchService _catalogSearchService;
        private readonly IItemService _itemService;
        private readonly IBlobUrlResolver _blobUrlResolver;
        private readonly IPricingSearchService _priceSearchService;
        private readonly ISyncSettingsService _syncSettingsService;
        private readonly ICommerceService _commerceService;
        private readonly IStoreService _storeService;
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IMemberService _memberService;
        private readonly IMemberSearchService _memberSearchService;

        public SyncController(IMemberService memberService,IMemberSearchService meberSearchService,
            ICustomerOrderService custemerOrderService, IStoreService storeService,
            ICatalogSearchService searchService,
            IItemService itemService, IBlobUrlResolver blobUrlResolver, 
            IPricingSearchService priceSearchService, ISyncSettingsService syncSettingsService, 
            ICommerceService commerceService)
        {
            _memberSearchService = meberSearchService;
            _memberService = memberService;
            _customerOrderService = custemerOrderService;
            _storeService = storeService;
            _catalogSearchService = searchService;
            _itemService = itemService;
            _blobUrlResolver = blobUrlResolver;
            _priceSearchService = priceSearchService;
            _syncSettingsService = syncSettingsService;
            _commerceService = commerceService;
        }

        [Route("orders")]
        [HttpPost]
        [ResponseType(typeof(ICollection<Models.ShippingMethod>))]
        public IHttpActionResult SyncOrders(SyncOrdersRequest request)
        {
            if (request == null)
            {
                return Ok(true);
            }
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(request.UserLogin);
            if (syncSettings == null || string.IsNullOrEmpty(syncSettings.ProductsCategoryId))
                return Ok();
            var customerOrders = new List<CustomerOrder>();
            var store = _storeService.GetById(syncSettings.ProductsCategoryId);
            foreach (var item in request.Orders)
            {
                var address = new Address
                {
                    AddressType = AddressType.Shipping,
                    City = item.Customer.City,
                    CountryName = item.Customer.Coutry,
                    CountryCode = item.Customer.Coutry.Substring(0,3),
                    Email = item.Customer.Email,
                    FirstName = item.Customer.FirstName,
                    Name = item.Customer.FirstName,
                    LastName = item.Customer.LastName,
                    Phone = item.Customer.Phone,
                    Line1 = item.Customer.Address,
                    Organization = item.Customer.CompanyName,
                    PostalCode = item.Customer.PostalCode

                };
                var customer = new Domain.Customer.Model.Employee
                {
                    Id = item.Customer.Id,
                    Addresses = new[] { address },
                    Emails = new[] { item.Customer.Email },
                    IsActive = true,
                    Phones = new[] { item.Customer.Phone },
                    FirstName = item.Customer.FirstName,
                    LastName = item.Customer.LastName,
                    FullName = $"{item.Customer.FirstName} {item.Customer.LastName}"

                };
                _memberService.SaveChanges(new[] { customer });
                //convert items
                var products = _itemService.GetByIds(item.Items.Select(x => x.ProductId).ToArray(), ItemResponseGroup.ItemInfo);
                var order = new CustomerOrder
                {
                    Id = item.Id,
                    StoreId = store.Id,
                    StoreName = store.Name,
                    Addresses = new[] { address },
                    Currency = item.Items.First().Currency,
                    Items = new List<LineItem>(),
                    EmployeeId = customer.Id,
                    EmployeeName = customer.FullName,
                    CustomerId = customer.Id,
                };
                foreach (var lineItem in item.Items)
                {
                    var prod = products.First(x => x.Id == lineItem.ProductId);
                    order.Items.Add(new LineItem
                    {
                        CatalogId = prod.CatalogId,
                        Currency = lineItem.Currency,
                        Sku = prod.Code,
                        CategoryId = prod.CategoryId,
                        ImageUrl = _blobUrlResolver.GetAbsoluteUrl(prod.Images.FirstOrDefault()?.Url),
                        DiscountAmount = lineItem.Discount / lineItem.Quantity,
                        Id = lineItem.Id,
                        Name = prod.Name,
                        Price = lineItem.SubTotal / lineItem.Quantity + lineItem.Discount / lineItem.Quantity,
                        Quantity = lineItem.Quantity,
                        ProductType = prod.ProductType,
                        ProductId = prod.Id,
                        Product = prod
                    });
                }
                //
                customerOrders.Add(order);
            }
            _customerOrderService.SaveChanges(customerOrders.ToArray());
            return Ok(true);
        }

        [Route("shippingMethods/{userLogin}")]
        [HttpGet]
        [ResponseType(typeof(ICollection<Models.ShippingMethod>))]
        public IHttpActionResult SyncShippingMethods(string userLogin)
        {
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(userLogin);
            if (syncSettings == null || string.IsNullOrEmpty(syncSettings.ProductsCategoryId))
                return Ok();
            var store = _storeService.GetById(syncSettings.ProductsCategoryId);
            var result = new List<Models.ShippingMethod>();
            foreach (var sm in store.ShippingMethods.Where(x=>x.IsActive))
            {
                var newSm = new Models.ShippingMethod()
                {
                    Id = sm.Id,
                    Name = sm.Name
                };
                newSm.ShippingRates = sm.CalculateRates(new ShippingEvaluationContext(new Domain.Cart.Model.ShoppingCart { Currency = store.DefaultCurrency })).ToArray();
                result.Add(newSm);
            }
            return Ok(result);
        }

        [Route("paymentMethods/{userLogin}")]
        [HttpGet]
        [ResponseType(typeof(ICollection<PaymentMethod>))]
        public IHttpActionResult SyncPaymentMethods(string userLogin)
        {
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(userLogin);
            if (syncSettings == null || string.IsNullOrEmpty(syncSettings.ProductsCategoryId))
                return Ok();
            var store = _storeService.GetById(syncSettings.ProductsCategoryId);
            return Ok(store.PaymentMethods);
            //syncSettings.ProductsCategoryId()
        }


        [Route("currency/{userLogin}")]
        [HttpGet]
        [ResponseType(typeof(Domain.Commerce.Model.Currency))]
        public IHttpActionResult GetCurrency(string userLogin)
        {
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(userLogin);
            if (syncSettings == null || string.IsNullOrEmpty(syncSettings.ProductsCategoryId))
                return Ok();
            return Ok(_commerceService.GetAllCurrencies().FirstOrDefault(x => x.Code == _storeService.GetById(syncSettings.ProductsCategoryId)?.DefaultCurrency));
        }

        [Route("product/{userLogin}")]
        [HttpGet]
        [ResponseType(typeof(SyncProductResponseResult))]
        public IHttpActionResult SyncUser(string userLogin)
        {
            var response = new SyncProductResponseResult();
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(userLogin);
            if (syncSettings == null || string.IsNullOrEmpty(syncSettings.ProductsCategoryId))
                return Ok();
            var store = _storeService.GetById(syncSettings.ProductsCategoryId);
            var result = _catalogSearchService.Search(new SearchCriteria
            {
                CatalogId = store.Catalog,
                SearchInChildren = true,
                ResponseGroup = SearchResponseGroup.WithProducts,
                Take = int.MaxValue
            });
            response.Products = result.ToWebModel(_blobUrlResolver).Products.ToArray();
            var ids = response.Products.Select(x => x.Id).ToArray();
            var items = _itemService.GetByIds(ids, ItemResponseGroup.ItemEditorialReviews);
            foreach (var item in items)
            {
                response.Products.First(x=>x.Id == item.Id).Reviews = item.Reviews.Select(x => x.ToWebModel()).ToArray();
            }
            var prices = _priceSearchService.SearchPrices(new PricesSearchCriteria
            {
                ProductIds = ids
            });
            
            response.Prices = new List<ProductPrice>();
            foreach (var priceGr in prices.Results.GroupBy(x => x.ProductId))
            {
                var productPrice = new ProductPrice
                {
                    ProductId = priceGr.Key,
                    Prices = priceGr.Select(y => y.ToWebModel()).ToList()
                };
                response.Prices.Add(productPrice);

            }

            return Ok(response);
        }

        [Route("theme/{userLogin}")]
        [HttpGet]
        [ResponseType(typeof(SyncThemeResponseResult))]
        public IHttpActionResult SyncTheme(string userLogin)
        {
            var syncSettings = _syncSettingsService.GetSettingsByAccountName(userLogin);
            if (syncSettings == null)
                return Ok();
            var result = new SyncThemeResponseResult
            {
                Id = syncSettings.Id,
                MainColor = syncSettings.MainColor
            };
            return Ok(result);
        }
    }
}