using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppEventos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private string _nome = string.Empty;
        private DateTime _dataInicio = DateTime.Today;
        private DateTime _dataTermino = DateTime.Today.AddDays(1);
        private int _numeroParticipantes;
        private string _local = string.Empty;
        private double _custoPorParticipante;

        public string Nome
        {
            get => _nome;
            set => AlterarValor(ref _nome, value);
        }

        public DateTime DataInicio
        {
            get => _dataInicio;
            set
            {
                if (AlterarValor(ref _dataInicio, value))
                    AvisarCalculosDeData();
            }
        }

        public DateTime DataTermino
        {
            get => _dataTermino;
            set
            {
                if (AlterarValor(ref _dataTermino, value))
                    AvisarCalculosDeData();
            }
        }

        public int NumeroParticipantes
        {
            get => _numeroParticipantes;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O número de participantes não pode ser negativo.");

                if (AlterarValor(ref _numeroParticipantes, value))
                    OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public string Local
        {
            get => _local;
            set => AlterarValor(ref _local, value);
        }

        public double CustoPorParticipante
        {
            get => _custoPorParticipante;
            set
            {
                if (value < 0)
                    throw new ArgumentException("O custo por participante não pode ser negativo.");

                if (AlterarValor(ref _custoPorParticipante, value))
                    OnPropertyChanged(nameof(CustoTotal));
            }
        }

        // Diferença entre as datas calculada com DateTime, resultando em um TimeSpan
        public TimeSpan Duracao => DataTermino.Date - DataInicio.Date;

        public int DuracaoEmDias => Duracao.Days;

        public bool DatasValidas => DataTermino.Date >= DataInicio.Date;

        public double CustoTotal => NumeroParticipantes * CustoPorParticipante;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AvisarCalculosDeData()
        {
            OnPropertyChanged(nameof(Duracao));
            OnPropertyChanged(nameof(DuracaoEmDias));
            OnPropertyChanged(nameof(DatasValidas));
        }

        private bool AlterarValor<T>(ref T campo, T valor, [CallerMemberName] string nomePropriedade = "")
        {
            if (EqualityComparer<T>.Default.Equals(campo, valor))
                return false;

            campo = valor;
            OnPropertyChanged(nomePropriedade);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string nomePropriedade = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }
    }
}
