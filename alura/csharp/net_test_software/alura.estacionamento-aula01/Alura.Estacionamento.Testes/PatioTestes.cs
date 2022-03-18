using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamentoComUmVeiculo()
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

        [Theory]
        [InlineData("Pedro Paulo", "OLS-1253", "preto", "Fusca")]
        public void LocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
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

            // act
            var consultado = patio.PesquisaVeiculo(veiculo.Placa);

            // assert 
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact]
        public void AlterarDadosDeUmVeiculo()
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
            
            
            var veiculoAlterado =  new Veiculo();
            veiculoAlterado.Proprietario = "Pablo";
            veiculoAlterado.Tipo = Alura.Estacionamento.Modelos.TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = "Voyage"; //Alterado
            veiculoAlterado.Placa = "AQS-9900";

            // act
            var alterado = patio.AlterarDadosVeiculo(veiculoAlterado);


            // assert 
            Assert.Equal(alterado.Modelo, veiculoAlterado.Modelo);

        }


    }
}
