using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace credito.test
{
    [TestClass]
    public class CreditoTest
    {
        [TestMethod] //O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00
        public void ValorMaximoUmMilhao()
        {
            var valorMaximo = 1000000;
            var valorEmprestimo = 900000;
            Assert.IsTrue(valorEmprestimo <= valorMaximo);
        }

        [TestMethod] //A quantidade de parcelas mínima é de 5x
        public void QuantidadeMinimaParcela()
        {
            var qtdMinimaParcela = 5;
            var qtdParcela = 5;
            Assert.IsTrue(qtdParcela >= qtdMinimaParcela);
        }

        [TestMethod] //A quantidade de parcelas máximas é de 72x
        public void QuantidadeMaximaParcela()
        {
            var qtdMaximaParcela = 72;
            var qtdParcela = 5;
            Assert.IsTrue(qtdParcela <= qtdMaximaParcela);
        }

        [TestMethod] //O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00
        public void ValorNaoPodeUltrapassarUmMilhao()
        {
            var valorMaximo = 1000000;
            var valorEmprestimo = 1000001;
            var msn = string.Empty;

            if (valorEmprestimo > valorMaximo)
                msn = "Reprovado. Valor superior a R$ 1.000.000,00";

            Assert.AreEqual("Reprovado. Valor superior a R$ 1.000.000,00", msn);

        }

        [TestMethod] //A quantidade de parcelas mínima é de 5x
        public void QuantidadeMinimaParcelaNaoPodeSerInferiorCinco()
        {
            var qtdMinimaParcela = 5;
            var qtdParcela = 4;
            var msn = string.Empty;

            if (qtdParcela < qtdMinimaParcela)
                msn = "Reprovado. A Quantidade minima de Parcelas é de 5x";

            Assert.AreEqual("Reprovado. A Quantidade minima de Parcelas é de 5x", msn);
        }

        [TestMethod] //A quantidade de parcelas máximas é de 72x
        public void QuantidadeMaximaParcelaNaoPodeSerSuperiorSetentaDois()
        {
            var qtdMaximaParcela = 72;
            var qtdParcela = 75;
            var msn = string.Empty;

            if (qtdParcela > qtdMaximaParcela)
                msn = "Reprovado. A Quantidade máxima de Parcelas é de 72x";

            Assert.AreEqual("Reprovado. A Quantidade máxima de Parcelas é de 72x", msn);
        }

        [TestMethod] //Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00
        public void EmprestimoPessoaJurica()
        {
            var tipoCredito = "Pessoa Jurídica";
            decimal valorEmprestimo = 15001M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(16);
            
            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemAprovado = $"Aprovado. Crédito liberado no valor de R$ {valorEmprestimo}";

            Assert.AreEqual(mensagemAprovado, result.StatusCrediro);
        }

        [TestMethod] //Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00
        public void EmprestimoPessoaJuricaReprovadoValorMinimo()
        {
            var tipoCredito = "Pessoa Jurídica";
            decimal valorEmprestimo = 14000M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(16);
            
            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemAprovado = $"Recusado. Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00";

            Assert.AreEqual(mensagemAprovado, result.StatusCrediro);
        }

        [TestMethod] //Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00
        public void EmprestimoPessoaJuricaReprovadoValorMaximo()
        {
            var tipoCredito = "Pessoa Jurídica";
            decimal valorEmprestimo = 1000001M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(16);
            
            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemAprovado = $"Reprovado. Valor superior a R$ 1.000.000,00. Valor solicitado R$ {valorEmprestimo}";

            Assert.AreEqual(mensagemAprovado, result.StatusCrediro);
        }

        [TestMethod]
        public void EmprestimoNaoPessoaJuricaAprovado()
        {
            var tipoCredito = "Pessoa Física";
            decimal valorEmprestimo = 14000M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(16);
            
            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemAprovado = $"Aprovado. Crédito liberado no valor de R$ {valorEmprestimo}";

            Assert.AreEqual(mensagemAprovado, result.StatusCrediro);
        }

        [TestMethod]
        public void EmprestimoReprovadoPrimeiraParcelaDataMinima()
        {
            var tipoCredito = "Pessoa Física";
            decimal valorEmprestimo = 14000M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(3);

            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemReprovada = "A Data da primeira parcela não pode ser inferior a";
            
            Assert.IsTrue(result.StatusCrediro.Contains(mensagemReprovada));
        }

        [TestMethod]
        public void EmprestimoReprovadoPrimeiraParcelaDataMaxima()
        {
            var tipoCredito = "Pessoa Física";
            decimal valorEmprestimo = 14000M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(45);

            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemReprovada = "A Data da primeira parcela não pode ser superior a";
            
            Assert.IsTrue(result.StatusCrediro.Contains(mensagemReprovada));
        }

        [TestMethod]
        [TestInitialize]
        public void EmprestimoAprovado()
        {
            var tipoCredito = "Pessoa Física";
            decimal valorEmprestimo = 14000.00M;
            var qtdParcelas = 12;
            var dataPrimeiraParcela = DateTime.Now.AddDays(16);
            decimal valorFinal = 19960.65M;
            decimal valorJuros = 5960.65M;
            
            var target = new credito.Servico.Credito();
            var result = target.ValidarCredito(valorEmprestimo, tipoCredito, qtdParcelas, dataPrimeiraParcela);

            var mensagemAprovado = $"Aprovado. Crédito liberado no valor de R$ {valorEmprestimo}";

            Console.WriteLine(result.ValorTotalComJuros);
            Console.WriteLine(result.ValorDosJuros);
            
            Assert.AreEqual(mensagemAprovado, result.StatusCrediro);
            Assert.AreEqual(valorFinal, result.ValorTotalComJuros);
            Assert.AreEqual(valorJuros, result.ValorDosJuros);
        }
    }
}