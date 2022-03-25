using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
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
    public  class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

            var provider = service.BuildServiceProvider();
            _contaCorrenteRepositorio = provider.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaObterTodasContasCorrentes()
        {
            //act 
            var conta = _contaCorrenteRepositorio.ObterTodos();
         
            // assert
            Assert.NotNull(conta);
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            // arrange
            var idConta = 1;
            //act 
            var conta = _contaCorrenteRepositorio.ObterPorId(idConta);
            // assert
            Assert.NotNull(conta);
            Assert.Equal(idConta, conta.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterVariasContaCorrentePorId(int idConta)
        {
            // arrange //act 
            var conta = _contaCorrenteRepositorio.ObterPorId(idConta);

            // assert
            Assert.NotNull(conta);
            Assert.Equal(idConta, conta.Id);
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //arrange 
            var conta = _contaCorrenteRepositorio.ObterPorId(1);
            double saldoNovo = 10;
            conta.Saldo += saldoNovo;

            //act
            var atualizado = _contaCorrenteRepositorio.Atualizar(conta.Id, conta);

            //assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereUmaNovaConta()
        {
            //arrange
            var conta = new ContaCorrente()
            {
                Saldo = 106,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Roberto",
                    CPF = "036.956.144-52",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1,
                },
                Agencia = new Agencia()
                {
                    Id = 1,
                    Identificador = Guid.NewGuid(),
                    Nome = "AG Costa",
                    Endereco = "Rua Marechal Palmas",
                    Numero = 145
                }
            };

            // act
            var retorno = _contaCorrenteRepositorio.Adicionar(conta);

            // assert
            Assert.True(retorno);
        }

        [Fact]
        public void TestaConsultaTodosPix()
        {
            //arrange 
            var guid = new Guid("asdfa125-asdad1");
            var pix = new PixDto() { Chave = guid, Saldo = 20 };

            var pixRepositorio = new Mock<IPixRepositorio>();
            pixRepositorio.Setup(x => x.ConsultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorio.Object;

            // act 
            var saldo = mock.ConsultaPix(guid).Saldo;

            //Assert 
            Assert.Equal(126.9, saldo);
        }
    }
}
