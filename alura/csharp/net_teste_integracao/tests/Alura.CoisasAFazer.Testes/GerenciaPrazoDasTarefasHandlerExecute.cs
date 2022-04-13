using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void DeveCriarTarefas()
        {
            // arrange
            var casaCateg = new Categoria(1, "Casa");
            var saudeCateg = new Categoria(2, "Saúde");

            var tarefas = new List<Tarefa>
            {
                new Tarefa(1, "Tirar Lixo",casaCateg, DateTime.Now, null, StatusTarefa.Criada),
                new Tarefa(2, "Ir para academia",saudeCateg, DateTime.Now, null, StatusTarefa.Criada)

            };

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
              .UseInMemoryDatabase("DbTarefasContext")
              .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);
            repo.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(DateTime.Now);
            var handler = new GerenciaPrazoDasTarefasHandler(repo);
            
            //act
            handler.Execute(comando);

            //assert
            var tarefasEmAtraso = repo.ObtemTarefas(t => t.Status == StatusTarefa.Criada);
            Assert.Equal(2, tarefasEmAtraso.Count());
        }

        [Fact]
        public void QuandoInvocadoDeveChamarAtualizarTarefasQtdAtrasadas()
        {
            //arrange 
            var categ = new Categoria(1, "Dummy");

            var tarefas = new List<Tarefa>
            {
                new Tarefa(1, "Tirar Lixo",categ, DateTime.Now, null, StatusTarefa.EmAtraso),
                new Tarefa(2, "Varrer chão",categ, DateTime.Now, null, StatusTarefa.EmAtraso)

            };
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.ObtemTarefas(It.IsAny<Func<Tarefa, bool>>())).Returns(tarefas);
            var repo = mock.Object;
                
            var comando = new GerenciaPrazoDasTarefas(DateTime.Now);
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            mock.Verify(r => r.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once());
        }
    }
}
