using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Teste para validar aceleração")]
        public void TestaVeiculoAcelerar()
        {
            // arrange
            var veiculo = new Veiculo();
            // act
            veiculo.Acelerar(10);
            // assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste para validar método frear")]
        public void TestaVeiculoFrear()
        {
            //arrange
            var veiculo = new Veiculo();
            // act
            veiculo.Frear(10);
            // assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Teste para validar nome proprietario",Skip = "No implemented")]
        public void ValidaNomeProprietario()
        {

        }
    }
}