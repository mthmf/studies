using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private Veiculo veiculo { get; set; }

        public VeiculoTestes(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            testOutputHelper.WriteLine("Construtor invocado");

            veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Kwid"; //Alterado
            veiculo.Placa = "AQS-9900";
        }

        [Fact(DisplayName ="Teste para validar aceleração")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // arrange
            var veiculo = new Veiculo();
            // act
            veiculo.Acelerar(10);
            // assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste para validar método frear")]
        [Trait("Funcionalidade", "Frear")]

        public void TestaVeiculoFrearComParametro10()
        {
            //arrange
            //var veiculo = new Veiculo();
            // act
            veiculo.Frear(10);
            // assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Teste para validar nome proprietario", Skip = "No implemented")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        { 
            // arrange 
         /*   var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Kwid"; //Alterado
            veiculo.Placa = "AQS-9900";*/

            //act 
            string dados = veiculo.ToString();

            // assert
            Assert.Contains("Tipo do Veiculo: Automovel", dados);

        }

        [Fact]
        public void TesteNomeProprietarioVeiculoMenosDeTresCaracteres()
        {
            // arrange
            string nomeProprietario = "ab";

            // assert // act
            Assert.Throws<FormatException>(
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMnesagemExcecaoQuartoCaractereDaPlaca()
        {
            // arrange
            string placa = "ASDF8888";

            // act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
            );

            // assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Dispose invocado");

        }
    }
}