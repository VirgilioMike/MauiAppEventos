namespace MauiAppEventos.Views;

public partial class ResumoEvento : ContentPage
{
	public ResumoEvento()
	{
		InitializeComponent();
	}

	private async void btn_voltar_Clicked(object? sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}
