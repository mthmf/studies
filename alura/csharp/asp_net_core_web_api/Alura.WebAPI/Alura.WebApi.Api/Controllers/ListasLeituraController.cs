﻿using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ListasLeituraController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLeituraController(IRepository<Livro> repo)
        {
            _repo = repo;
        }

        private Lista CriaLista(TipoListaLeitura tipo)
        {
            return new Lista
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All.Where(livro => livro.Lista == tipo).Select(l => l.ToApi()).ToList()
            };
        }

        [HttpGet]
        public IActionResult TodasListas()
        {
            Lista paraLer = CriaLista(TipoListaLeitura.ParaLer);
            Lista lendo = CriaLista(TipoListaLeitura.Lendo);
            Lista lidos = CriaLista(TipoListaLeitura.Lidos);
            var colecao = new List<Lista> { paraLer, lendo, lidos };
            return Ok(colecao);
        }

        [HttpGet("{tipo}")]
        public IActionResult ListaEspecifica([FromQuery] TipoListaLeitura tipo)
        {

            var lista = CriaLista(tipo);
            return Ok(lista);
        }


    }
}
