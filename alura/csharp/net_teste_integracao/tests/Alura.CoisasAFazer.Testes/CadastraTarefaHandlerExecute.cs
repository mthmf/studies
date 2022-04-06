using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTaerfaComInfoValidasDeveIncluirNoBanco()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), DateTime.Now);

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);
            
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefas = repo.ObtemTarefas(t => t.Titulo == "Estudar XUnit").FirstOrDefault();
            Assert.NotNull(tarefas);
        }


        [Fact]
        public void DadaTarefaComExecucaoFalha()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), DateTime.Now);

            var mock = new Mock<IRepositorioTarefas>();
            //mock.Setup(r => r.IncluirTarefas()).Throws(new Exception("Houve um erro"));
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }
    }
}
