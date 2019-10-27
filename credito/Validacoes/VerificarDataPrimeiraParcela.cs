using System;

namespace credito.Validacoes
{
    public class VerificarDataPrimeiraParcela : ICreditoValor
    {
        public ICreditoValor Proximo { get; set; }

        public Tuple<string, decimal, bool> Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, DateTime dataPrimeiraParcela)
        {
            var dataMinima = DateTime.Now.AddDays(15);
            var dataMaxima = DateTime.Now.AddDays(40);

            if (dataPrimeiraParcela < dataMinima)
                return new Tuple<string, decimal, bool>($"A Data da primeira parcela não pode ser inferior a $ {dataMinima}", valorCredito, false);

            if (dataPrimeiraParcela > dataMaxima)
                return new Tuple<string, decimal, bool>($"A Data da primeira parcela não pode ser superior a $ {dataMaxima}", valorCredito, false);

            return new Tuple<string, decimal, bool>($"Aprovado. Crédito liberado no valor de R$ {valorCredito}", valorCredito, true);
        }
    }
}