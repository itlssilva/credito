using System;
using credito.CreditoJuros;
using credito.Validacoes;
using credito.ViewModel;

namespace credito.Servico
{
    public class Credito
    {
        public CreditoView ValidarCredito(SolicitacaoCreditoView solicitacaoCredito)
        {
            var creditoView = new CreditoView();
            ICreditoValor verificarValorMaximo = new VerificarValorMaximo();
            ICreditoValor verificarValorTipoCredito = new VerificarValorTipoCredito();
            ICreditoValor verificarQuantidadeParcelas = new VerificarQuantidadeParcealas();
            ICreditoValor verificarDataPrimeiraParcela = new VerificarDataPrimeiraParcela();

            verificarValorMaximo.Proximo = verificarValorTipoCredito;
            verificarValorTipoCredito.Proximo = verificarQuantidadeParcelas;
            verificarQuantidadeParcelas.Proximo = verificarDataPrimeiraParcela;

            var validacoes = verificarValorMaximo.Valor(solicitacaoCredito.ValorCredito,
                                                        solicitacaoCredito.TipoCredito, 
                                                        solicitacaoCredito.QtdParcelas, 
                                                        solicitacaoCredito.DataPrimeiraParcela);
            if (!validacoes.Item3)
            {
                creditoView.Aprovado = validacoes.Item3;
                creditoView.StatusCrediro = validacoes.Item1;
                creditoView.ValorTotalComJuros = validacoes.Item2;
                creditoView.ValorDosJuros = 0;
                return creditoView;
            }

            IJuros verificarJurosTipoCredito = new JurosTipoCredito();
            IJuros calcularValores = new CalcularValorFinal();
            verificarJurosTipoCredito.Proximo = calcularValores;

            var credito = verificarJurosTipoCredito.Valor(solicitacaoCredito.ValorCredito, 
                                                          solicitacaoCredito.TipoCredito,
                                                          solicitacaoCredito.QtdParcelas, 
                                                          0);

            creditoView.Aprovado = credito.Aprovado;
            creditoView.StatusCrediro = credito.StatusCrediro;
            creditoView.ValorTotalComJuros = credito.ValorTotalComJuros;
            creditoView.ValorDosJuros = credito.ValorDosJuros;

            return creditoView;
        }
    }
}