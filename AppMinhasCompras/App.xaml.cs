using AppMinhasCompras.Helpers;
using AppMinhasCompras.Views;

namespace AppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper DB
        {
            get
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_compras.db3");

                if(_db == null)
                    _db = new SQLiteDatabaseHelper(path);

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new ListaProduto());
        }
    }
}
