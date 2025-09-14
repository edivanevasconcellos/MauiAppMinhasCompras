using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Properties.models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Fix: Ensure the Insert method is correctly called on the ISQLiteDatabaseHelper instance
            ISQLiteDatabaseHelper db = App.Db; // Ensure App.Db is of type ISQLiteDatabaseHelper
            int insertResult = await db.Insert(p); // Correctly call the Insert method
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
