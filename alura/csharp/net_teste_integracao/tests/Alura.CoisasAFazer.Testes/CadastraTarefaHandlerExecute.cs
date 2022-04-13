using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

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
            mock.Setup(r => r.IncluirTarefas()).Throws(new Exception("Houve um erro"));
            var repo = mock.Object;

            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionLancadaDeveLogarMensagem()
        {
            //arrange
            var msgErro = "Houve um erro";
            var excecaoLogada = new Exception(msgErro); 
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), DateTime.Now);

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas()).Throws(excecaoLogada);
            var repo = mock.Object;
            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            mockLog.Verify(l => l.Log(
                                LogLevel.Error
                                , It.IsAny<EventId>()
                                , It.IsAny<object>()
                                , excecaoLogada
                                , It.IsAny<Func<object, Exception, string>>()), Times.Once());
        }

        delegate void CapturaMensagemLog(LogLevel level, EventId eventId, object state, Exception exception, Func<object, Exception, string> function);

        [Fact]
        public void DataTarefaComInfoValidaDeveLogar()
        {

            var tituloTarefa = "Estudar XUnit";
            var comando = new CadastraTarefa(tituloTarefa, new Categoria("Estudo"), DateTime.Now);

            var mock = new Mock<IRepositorioTarefas>();
            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();
            LogLevel logLevel = LogLevel.Error;
            string mensagemCap = string.Empty;
    
            CapturaMensagemLog captura = (level, eventId, state, exception, func) =>
            {
                logLevel = level;
                mensagemCap = func(state, exception);
            };

            //mock.Setup(r => r.IncluirTarefas());
            mockLog.Setup(l => l.Log(
                                It.IsAny<LogLevel>()
                                , It.IsAny<EventId>()
                                , It.IsAny<object>()
                                , It.IsAny<Exception>()
                                , It.IsAny<Func<object, Exception, string>>()))
                .Callback(captura);

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.Equal(LogLevel.Debug, logLevel);
            Assert.Contains(tituloTarefa, mensagemCap);
        }
    }
}
