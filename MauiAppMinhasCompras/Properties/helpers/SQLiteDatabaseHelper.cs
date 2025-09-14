using MauiAppMinhasCompras.Properties.models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper : ISQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        Task<int> ISQLiteDatabaseHelper.Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        Task<List<Produto>> ISQLiteDatabaseHelper.Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        Task<int> ISQLiteDatabaseHelper.Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        Task<List<Produto>> ISQLiteDatabaseHelper.GetAll() => _conn.Table<Produto>().ToListAsync();

        Task<List<Produto>> ISQLiteDatabaseHelper.Search(string q)
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}