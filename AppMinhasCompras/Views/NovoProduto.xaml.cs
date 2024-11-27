using AppMinhasCompras.Models;

namespace AppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
		try
		{
            var produto = new Produto
            {
                Descricao = txtDescricao.Text,
				Quantidade = Convert.ToDouble(txtQuantidade.Text),
				Preco = Convert.ToDouble(txtPreco.Text),
            };

			await App.DB.Insert(produto);

			await DisplayAlert("Sucesso", "Registro inserido", "OK");
        }
		catch (Exception ex)
		{
			DisplayAlert("OPS", ex.Message, "OK");
		}
    }
}