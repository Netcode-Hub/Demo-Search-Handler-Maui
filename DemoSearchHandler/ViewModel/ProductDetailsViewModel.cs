using CommunityToolkit.Mvvm.ComponentModel;
using DemoSearchHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSearchHandler.ViewModel
{
    [QueryProperty(nameof(Product), "ProductDetails")]
    public partial class ProductDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Product _product;


    }
}
