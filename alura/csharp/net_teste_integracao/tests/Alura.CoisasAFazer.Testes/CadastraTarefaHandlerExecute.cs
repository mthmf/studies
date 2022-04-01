using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTaerfaCOmInfoValidasDeveIncluirNoBanco()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), DateTime.Now);
            var repo = new RepositorioFake();
            
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefas = repo.ObtemTarefas(t => t.Titulo == "Estudar XUnit").FirstOrDefault();
            Assert.NotNull(tarefas);
        }
    }
}
