using MauiAppMinhasCompras.Properties.helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application,App
    {
        private static SQLiteDatabaseHelper _db;

        // Propriedade estática para acessar o banco de dados
        public static SQLiteDatabaseHelper DB
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

         
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}



