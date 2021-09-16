using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> Filmes = new List<Filme>();
        private static int Id = 1;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = Id++;
            Filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return Filmes;
        }

        [HttpGet]
        [Route("/{id}")]
        public Filme RecuperarFilmePorId([FromQuery] int id)
        {
            return Filmes.FirstOrDefault(f => f.Id == id);
        }


    }
}
