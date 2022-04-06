using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
