using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public interface IApp
    {
        static abstract SQLiteDatabaseHelper DB { get; }
        static abstract Environment.SpecialFolderOption LocalAppcationData { get; }
    }
}