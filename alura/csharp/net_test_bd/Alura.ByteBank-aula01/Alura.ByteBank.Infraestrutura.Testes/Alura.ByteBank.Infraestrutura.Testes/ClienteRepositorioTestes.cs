using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteRepositorioTestes(IClienteRepositorio clienteRepositorio)
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _clienteRepositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        { 
            //act
            List<Cliente> lista = _clienteRepositorio.ObterTodos();

            // assert 
            Assert.NotNull(lista);
            //Assert.Equal(3,lista.Count);
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //arrange
            var idCliente = 1;
            //act
            var cliente = _clienteRepositorio.ObterPorId(idCliente);

            //assert
            Assert.NotNull(cliente);
            Assert.Equal(idCliente, cliente.Id);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientesPorVariosId(int id)
        {
            //arrange //act 
            var cliente = _clienteRepositorio.ObterPorId(id);

            //assert
            Assert.NotNull(cliente);
            Assert.Equal(id, cliente.Id);
        }

    }
}
