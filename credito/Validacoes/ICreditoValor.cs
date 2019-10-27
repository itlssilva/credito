using System;

namespace credito.Validacoes
{
    public interface ICreditoValor
    {
        Tuple<string, decimal, bool> Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, DateTime dataPrimeiraParcela);
        ICreditoValor Proximo { get; set; }
    }
}