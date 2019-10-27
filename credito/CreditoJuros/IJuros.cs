using credito.ViewModel;

namespace credito.CreditoJuros
{
    public interface IJuros
    {
         CreditoView Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, int jurosMes);
         IJuros Proximo { get; set; }
    }
}