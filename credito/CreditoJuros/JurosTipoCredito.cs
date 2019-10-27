using System;
using credito.ViewModel;

namespace credito.CreditoJuros
{
    public class JurosTipoCredito : IJuros
    {
        public IJuros Proximo { get; set; }

        public CreditoView Valor(decimal valorCredito, string tipoCredito, int qtdParcelas, int jurosMes)
        {
            switch (tipoCredito)
            {
                case "Direto":
                    jurosMes = 2;
                    break;
                case "Consignado":
                    jurosMes = 1;
                    break;
                case "Pessoa Jurídica":
                    jurosMes = 5;
                    break;
                case "Pessoa Física":
                    jurosMes = 3;
                    break;
                case "Imobiliário":
                    jurosMes = 9;
                    break;

                default:
                    return new CreditoView(){
                        Aprovado = false,
                        StatusCrediro = $"Reprovado. Tipo Crédito não identificado = {tipoCredito}",
                        ValorTotalComJuros = 0,
                        ValorDosJuros = 0
                    };
            }
            
            return Proximo.Valor(valorCredito, tipoCredito, qtdParcelas, jurosMes);
        }
    }
}