using DemoSearchHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSearchHandler.Handlers
{
    public class ProductSearchHandler : SearchHandler
    {
        public IList<Product> Products { get; set; }
        public string NavigationRoute { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrEmpty(newValue) || string.IsNullOrWhiteSpace(newValue))
                ItemsSource = null;
            else
                ItemsSource = Products.Where(t=> t.Title.ToLower().Contains(newValue.ToLower())).ToList();
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            if(!string.IsNullOrEmpty(NavigationRoute) || !string.IsNullOrWhiteSpace(NavigationRoute))
            {
                var navigationParameter = new Dictionary<string, object>()
                {
                    {"ProductDetails", item }
                };
                await Shell.Current.GoToAsync(NavigationRoute, navigationParameter);
            }
        }
    }
}
