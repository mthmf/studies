using FilmesAPI.Data;
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

        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            Console.WriteLine(filme.Titulo);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new Filme { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperarFilmePorId([FromQuery] int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }

            return NotFound();
        }


    }
}
