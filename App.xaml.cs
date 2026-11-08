using System.Globalization;

namespace MauiAppEventos;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// Formato brasileiro para datas, números e moeda (R$)
		CultureInfo cultura = new CultureInfo("pt-BR");
		CultureInfo.DefaultThreadCurrentCulture = cultura;
		CultureInfo.DefaultThreadCurrentUICulture = cultura;
		CultureInfo.CurrentCulture = cultura;
		CultureInfo.CurrentUICulture = cultura;

		UserAppTheme = AppTheme.Light;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new NavigationPage(new Views.CadastroEvento()));
	}
}
