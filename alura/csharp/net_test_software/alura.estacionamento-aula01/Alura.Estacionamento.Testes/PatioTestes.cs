using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private Patio Patio { get; set; }


        public PatioTestes(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            testOutputHelper.WriteLine("Construtor invocado");
            Patio = new Patio();
        }

        [Fact]
        public void ValidaFaturamentoComUmVeiculo()
        {
            // arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Pablo";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "T-Cross";
            veiculo.Placa = "AQS-9900";

            Patio.RegistrarEntradaVeiculo(veiculo);
            Patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // act 
            double faturamento = Patio.TotalFaturado();

            // assert
            Assert.Equal(2, faturamento);

            
        }

        [Theory]
        [InlineData("Pedro Paulo", "OLS-1253", "preto", "Fusca")]
        [InlineData("Ana Paula", "PQA-5534", "branco", "Civic")]
        [InlineData("Mari Luz", "MEU-7734", "branco", "Porsche")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            Patio.RegistrarEntradaVeiculo(veiculo);
            Patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // act 
            double faturamento = Patio.TotalFaturado();

            // assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Pedro Paulo", "OLS-1253", "preto", "Fusca")]
        public void LocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            Patio.RegistrarEntradaVeiculo(veiculo);

            // act
            var consultado = Patio.PesquisaVeiculo(veiculo.Placa);

            // assert 
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact]
        public void AlterarDadosDeUmVeiculo()
        {
            // arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Pablo";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "T-Cross";
            veiculo.Placa = "AQS-9900";
            Patio.RegistrarEntradaVeiculo(veiculo);
            
            
            var veiculoAlterado =  new Veiculo();
            veiculoAlterado.Proprietario = "Pablo";
            veiculoAlterado.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = "Voyage"; //Alterado
            veiculoAlterado.Placa = "AQS-9900";

            // act
            var alterado = Patio.AlterarDadosVeiculo(veiculoAlterado);


            // assert 
            Assert.Equal(alterado.Modelo, veiculoAlterado.Modelo);

        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Dipose invocado");

        }


    }
}
