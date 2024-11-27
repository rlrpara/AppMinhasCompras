using AppMinhasCompras.Views;

namespace AppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new ListaProduto());
        }
    }
}
