using System.Globalization;

namespace MauiAppEventos.Models
{
    // Converte o texto digitado nos campos numéricos para int/double da model e vice-versa
    public class NumeroConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // Zero aparece como campo vazio para mostrar o Placeholder
            if (value is int inteiro)
                return inteiro == 0 ? string.Empty : inteiro.ToString(CultureInfo.CurrentCulture);

            if (value is double numero)
                return numero == 0 ? string.Empty : numero.ToString(CultureInfo.CurrentCulture);

            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string texto = (value as string ?? string.Empty).Trim().Replace('.', ',');

            if (texto == string.Empty)
                return targetType == typeof(int) ? 0 : 0.0;

            if (targetType == typeof(int) && int.TryParse(texto, NumberStyles.Integer, CultureInfo.CurrentCulture, out int inteiro) && inteiro >= 0)
                return inteiro;

            if (targetType == typeof(double) && double.TryParse(texto, NumberStyles.Float, CultureInfo.CurrentCulture, out double numero) && numero >= 0)
                return numero;

            // Texto inválido: mantém o último valor válido na model
            return Binding.DoNothing;
        }
    }
}
