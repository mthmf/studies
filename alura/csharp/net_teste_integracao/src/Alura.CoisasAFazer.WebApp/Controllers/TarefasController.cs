﻿using Microsoft.AspNetCore.Mvc;
using Alura.CoisasAFazer.WebApp.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IRepositorioTarefas _repositorio;
        private readonly ILogger<CadastraTarefaHandler> _logger;


        public TarefasController(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(_repositorio).Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);
            var handler = new CadastraTarefaHandler(_repositorio, _logger);
            var resultado = handler.Execute(comando);
            if (!resultado.IsSuccess)
                return StatusCode(500);
            
            return Ok();
        }
    }
}