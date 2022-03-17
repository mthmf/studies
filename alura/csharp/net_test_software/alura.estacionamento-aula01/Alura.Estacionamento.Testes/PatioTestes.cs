using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            // arrange
            var patio = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Pablo";
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "T-Cross";
            veiculo.Placa = "AQS-9900";

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // act 
            double faturamento = patio.TotalFaturado();

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
            var patio = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            // act 
            double faturamento = patio.TotalFaturado();

            // assert
            Assert.Equal(2, faturamento);

        }
    }
}
