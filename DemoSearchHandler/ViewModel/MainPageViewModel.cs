

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoSearchHandler.Models;
using DemoSearchHandler.Services;
using MvvmHelpers;

namespace DemoSearchHandler.ViewModel
{
    public partial class MainPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public static List<Product> SearchProducts { get; set; } = new();
        public  ObservableRangeCollection<Product> Products { get; set; } = new();
        private readonly IProductService productService;
        public MainPageViewModel(IProductService productService)
        {
            this.productService = productService;
            GetProductFromApi();
        }

        [ObservableProperty]
        bool _isBusy;

        private async void GetProductFromApi()
        {
            IsBusy = true;
            var products = await productService.GetProducts();

            if (Products.Count > 0)
                Products.Clear();

            if (SearchProducts.Count > 0)
                SearchProducts.Clear();


            if (products != null)
                Products.AddRange(products);
            SearchProducts.AddRange(products);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task Details(Product product)
        {
            if (product is null)
                return;

            var navigationParameter = new Dictionary<string, object>()
                {
                    {"ProductDetails", product }
                };
            await Shell.Current.GoToAsync(nameof(ProductDetails), navigationParameter);
        }
    }
}
