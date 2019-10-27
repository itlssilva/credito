using System;

namespace credito.ViewModel
{
    public class SolicitacaoCreditoView
    {
        public decimal ValorCredito { get; set; }
        public string TipoCredito { get; set; }
        public int QtdParcelas { get; set; }
        public DateTime DataPrimeiraParcela { get; set; }
    }
}