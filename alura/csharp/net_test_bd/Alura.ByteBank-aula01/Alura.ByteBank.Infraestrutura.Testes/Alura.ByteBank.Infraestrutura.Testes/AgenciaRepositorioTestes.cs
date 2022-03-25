using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;
        
        public AgenciaRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

            var provider = service.BuildServiceProvider();
            _agenciaRepositorio = provider.GetService<IAgenciaRepositorio>();

        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //arrange //act
            var agencia = _agenciaRepositorio.ObterTodos();

            // assert
            Assert.NotNull(agencia);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            // arrange
            var idAgencia = 1;

            // act 
            var agencia = _agenciaRepositorio.ObterPorId(idAgencia);

            // assert
            Assert.NotNull(agencia);
            Assert.Equal(idAgencia, agencia.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterVariasAgenciasPorId(int idAgencia)
        {
            // arrange // act 
            var agencia = _agenciaRepositorio.ObterPorId(idAgencia);

            // assert
            Assert.NotNull(agencia);
            Assert.Equal(idAgencia, agencia.Id);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            // act 
            // assert
            Assert.Throws <FormatException>(() => _agenciaRepositorio.ObterPorId(520));
        }

        [Fact]
        public void TestaAgenciaRepoMock()
        {
            //arrange 
            var agencia = new Agencia()
            {
                Nome = "Agência XV",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Amadeu Luz",
                Numero = 223
            };

            var repoMock = new ByteBankRepositorio();

            // act
            var adicionado = repoMock.AdicionarAgencia(agencia);

            // assert
            Assert.True(adicionado);
               
        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            // arrange 
            var byteBankMock = new Mock<IByteBackRespositorio>();
            var mock = byteBankMock.Object;

            // act
            var lista = mock.BuscarAgencias();

            //assert
            byteBankMock.Verify(b => b.BuscarAgencias());
        }
    }
}
