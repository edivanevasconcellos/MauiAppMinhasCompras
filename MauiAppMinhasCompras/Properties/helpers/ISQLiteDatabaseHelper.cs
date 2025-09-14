using MauiAppMinhasCompras.Properties.models;

namespace MauiAppMinhasCompras.Helpers
{
    public interface ISQLiteDatabaseHelper
    {
        Task<int> Delete(int id);
        Task<List<Produto>> GetAll();
        Task<int> Insert(Produto p);
        Task<List<Produto>> Search(string q);
        Task<List<Produto>> Update(Produto p);
    }
}