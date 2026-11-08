using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEvento : ContentPage
{
	Evento evento = new Evento();

	public CadastroEvento()
	{
		InitializeComponent();

		BindingContext = evento;
	}

	private async void btn_resumo_Clicked(object? sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(evento.Nome))
				throw new Exception("Informe o nome do evento.");

			if (string.IsNullOrWhiteSpace(evento.Local))
				throw new Exception("Informe o local do evento.");

			if (evento.DataTermino < evento.DataInicio)
				throw new Exception("A data de término não pode ser anterior à data de início.");

			if (evento.NumeroParticipantes <= 0)
				throw new Exception("Informe um número de participantes maior que zero.");

			if (evento.CustoPorParticipante <= 0)
				throw new Exception("Informe o custo por participante.");

			await Navigation.PushAsync(new ResumoEvento()
			{
				BindingContext = evento
			});
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "OK");
		}
	}
}
