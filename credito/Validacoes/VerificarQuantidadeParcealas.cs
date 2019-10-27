using System;

namespace credito.Validacoes
{
    public class VerificarQuantidadeParcealas : ICreditoValor
    {
        public ICreditoValor Proximo { get; set; }

        public Tuple<string, decimal, bool> Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, DateTime dataPrimeiraParcela)
        {
            var qtdMinimaParcelas = 5;
            var qtdMaximaParcelas = 72;
            
            if (qtdParcelas < qtdMinimaParcelas)
                return new Tuple<string, decimal, bool>("Reprovado. A Quantidade minima de Parcelas é de 5x", valorCredito, false);

            if (qtdParcelas > qtdMaximaParcelas)
                return new Tuple<string, decimal, bool>("Reprovado. A Quantidade máxima de Parcelas é de 72x", valorCredito, false);

            return Proximo.Valor(valorCredito, tipoCredito, qtdMaximaParcelas, dataPrimeiraParcela);
        }
    }
}