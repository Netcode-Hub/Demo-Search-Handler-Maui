using DemoSearchHandler.ViewModel;

namespace DemoSearchHandler;

public partial class ProductDetails : ContentPage
{
	public ProductDetails(ProductDetailsViewModel productDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = productDetailsViewModel;
	}
}