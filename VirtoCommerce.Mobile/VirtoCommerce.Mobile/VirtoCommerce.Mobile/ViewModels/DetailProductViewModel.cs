using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class DetailProductViewModel : MvxViewModel
    {
        public Product Product { set; get; }

        public bool HideDescription { set; get; } = true;
        public bool HideProperties { set; get; }
        private readonly IProductStorageService _productService;
        public DetailProductViewModel(IProductStorageService productService)
        {
            _productService = productService;
        }

        public void SetSegment(int segment)
        {
            switch (segment)
            {
                case 0:
                    HideDescription = true;
                    HideProperties = false;
                    break;
                case 1:
                    HideDescription = false;
                    HideProperties = true;
                    break; 
            }
            RaisePropertyChanged("HideDescription");
            RaisePropertyChanged("HideProperties");

        }

        public void Init(string id)
        {
            Product = _productService.GetProduct(id);
        }
    }
}
