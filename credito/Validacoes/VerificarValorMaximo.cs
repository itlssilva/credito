using System;

namespace credito.Validacoes
{
    public class VerificarValorMaximo : ICreditoValor
    {
        public ICreditoValor Proximo { get; set; }

        public Tuple<string, decimal, bool> Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, DateTime dataPrimeiraParcela)
        {
            var valorMaximoEmprestimo = 1000000;
            var mensagem = string.Empty;

            if (valorCredito > valorMaximoEmprestimo)
                return new Tuple<string, decimal, bool>($"Reprovado. Valor superior a R$ 1.000.000,00. Valor solicitado R$ {valorCredito}",
                 valorCredito,
                 false);

            return Proximo.Valor(valorCredito, tipoCredito, qtdParcelas, dataPrimeiraParcela);
        }
    }
}