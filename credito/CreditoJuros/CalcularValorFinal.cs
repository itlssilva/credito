using System;
using credito.ViewModel;

namespace credito.CreditoJuros
{
    public class CalcularValorFinal : IJuros
    {
        public IJuros Proximo { get; set; }

        public CreditoView Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, int jurosMes)
        {
            var valorTotalComJuros = valorCredito;

            for (int i = 1; i <= qtdParcelas; i++)
                valorTotalComJuros = valorTotalComJuros * (1 + Convert.ToDecimal(jurosMes / 100M));

            var totalDeJuros = valorTotalComJuros - valorCredito;

            var creditoView = new CreditoView()
            {
                Aprovado = true,
                StatusCrediro = $"Aprovado. Crédito liberado no valor de R$ {valorCredito}",
                ValorTotalComJuros = Math.Round(valorTotalComJuros, 2),
                ValorDosJuros = Math.Round(totalDeJuros, 2)
            };

            return creditoView;
        }
    }
}