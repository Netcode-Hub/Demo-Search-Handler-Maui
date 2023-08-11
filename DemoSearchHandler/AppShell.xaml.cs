namespace DemoSearchHandler
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductDetails), typeof(ProductDetails));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
