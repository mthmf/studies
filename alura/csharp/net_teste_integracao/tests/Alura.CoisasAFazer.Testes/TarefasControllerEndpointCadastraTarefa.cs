using Xunit;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Alura.CoisasAFazer.Core.Models;

namespace Alura.CoisasAFazer.Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaValidaDeveRetornar200()
        {
            //arrange 
            var options = new DbContextOptionsBuilder<DbTarefasContext>().UseInMemoryDatabase("DbTarefasContext").Options;
            var contexto = new DbTarefasContext(options);
            contexto.Categorias.Add(new Core.Models.Categoria(20, "Estudo"));
            var repo = new RepositorioTarefa(contexto);
            
            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();

            var controller = new TarefasController(repo, mockLog.Object);
            var model = new CadastraTarefaVM();
            model.IdCategoria = 20;
            model.Titulo = "Estudar Xunit";
            model.Prazo = DateTime.Now;
            //act
            var retorno = controller.EndpointCadastraTarefa(model);

            //assert
            Assert.IsType<OkResult>(retorno);

        }

        [Fact]
        public void QuandoExcecaoDeveRetornarStatus500()
        {
            //arrange 
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.ObtemCategoriaPorId(20)).Returns(new Core.Models.Categoria(20, "Estudo"));
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro"));


            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();
            var repo = mock.Object;

            var controller = new TarefasController(repo, mockLog.Object);
            var model = new CadastraTarefaVM();
            model.IdCategoria = 20;
            model.Titulo = "Estudar Xunit";
            model.Prazo = DateTime.Now;
            //act
            var retorno = controller.EndpointCadastraTarefa(model);

            //assert
            Assert.IsType<StatusCodeResult>(retorno);
            var statusCode = (retorno as StatusCodeResult).StatusCode;
            Assert.Equal(500, statusCode);

        }

    }
}
