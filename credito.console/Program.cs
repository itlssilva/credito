using credito.ViewModel;
using System;

namespace credito.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solicitação de Crédito");
            Console.WriteLine("1 - Crédito Direto");
            Console.WriteLine("2 - Crédito Consignado");
            Console.WriteLine("3 - Crédito Pessoa Jurídica");
            Console.WriteLine("4 - Crédito Pessoa Física");
            Console.WriteLine("5 - Crédito Imobiliário");
            Console.Write("Escolha um número para o Tipo de Crédito: ");
            var tipoCredito = Console.ReadLine();
            Console.Write("Valor do Crédito: ");
            var valorCredito = Console.ReadLine();
            Console.Write("Informe a quantidade de Parcelas: ");
            var qtdParcelas = Console.ReadLine();
            Console.Write("Informe a data da primeira Parcela: ");
            var dataPrimeiraParcela = Console.ReadLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("------------------------------");

            var dateResult = new DateTime();
            if (DateTime.TryParse(dataPrimeiraParcela, out dateResult))
            {
                var solicitacaoCredito = CriarObjeto(tipoCredito,
                                                 Convert.ToDecimal(valorCredito),
                                                 Convert.ToInt32(qtdParcelas),
                                                 dateResult);

                var credito = CriarCredito(solicitacaoCredito);
                Console.Write("Situação: ");
                Console.WriteLine(credito.StatusCrediro);
                Console.Write("Valor total com juros: ");
                Console.WriteLine($"R$ {credito.ValorTotalComJuros}");
                Console.Write("Valor do juros: ");
                Console.WriteLine($"R$ {credito.ValorDosJuros}");               
            }
            else
                Console.WriteLine("Data informada formato incorreto");
            
        }

        private static SolicitacaoCreditoView CriarObjeto(string tipoCredito, decimal valorCredito, int qtdParcelas, DateTime dataPrimeiraParcela)
        {
            switch (tipoCredito)
            {
                case "1":
                    tipoCredito = "Direto";
                    break;
                case "2":
                    tipoCredito = "Consignado";
                    break;
                case "3":
                    tipoCredito = "Pessoa Jurídica";
                    break;
                case "4":
                    tipoCredito = "Pessoa Física";
                    break;
                case "5":
                    tipoCredito = "Imobiliário";
                    break;
                default:
                    break;
            }

            return new SolicitacaoCreditoView()
            {
                TipoCredito = tipoCredito,
                ValorCredito = valorCredito,
                QtdParcelas = qtdParcelas,
                DataPrimeiraParcela = dataPrimeiraParcela
            };
        }

        private static CreditoView CriarCredito(SolicitacaoCreditoView solicitacaoCredito)
        {
            var servico = new Servico.Credito();
            return servico.ValidarCredito(solicitacaoCredito);
        }
    }
}
