using AppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace AppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

	public ListaProduto()
	{
		InitializeComponent();

		lvListaProdutos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
		List<Produto> tmp = await App.DB.GetAll();

		lista.Clear();
		tmp.ForEach(x => lista.Add(x));
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new NovoProduto());
		}
		catch (Exception ex)
		{
			DisplayAlert("OPS", ex.Message, "OK");
		}
    }

    private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
		string q = e.NewTextValue;

        List<Produto> tmp = await App.DB.Search(q);

        lista.Clear();

        tmp.ForEach(x => lista.Add(x));
    }

    private void btnSomar_Clicked(object sender, EventArgs e)
    {
		double soma = lista.Sum(x => x.ValorTotal);

		string msg = $"O total é {soma:C}";

		DisplayAlert("Total dos produtos", msg, "OK");
    }

    private void btnRemover_Clicked(object sender, EventArgs e)
    {

    }
}