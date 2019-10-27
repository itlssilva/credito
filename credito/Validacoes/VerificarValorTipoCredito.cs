using System;

namespace credito.Validacoes
{
    public class VerificarValorTipoCredito : ICreditoValor
    {
        public ICreditoValor Proximo { get; set; }

        public Tuple<string, decimal, bool> Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, DateTime dataPrimeiraParcela)
        {
            var valorMinimo = 15000;            

            if (("Pessoa Jurídica".Equals(tipoCredito)) && (valorCredito < valorMinimo))
                return new Tuple<string, decimal, bool>(
                    "Recusado. Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00",
                    valorCredito,
                    false);
            else
                return Proximo.Valor(valorCredito, tipoCredito, qtdParcelas, dataPrimeiraParcela);
        }
    }
}