using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Gerentes;
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

        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateGerenteDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);               
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            Console.WriteLine(filme.Titulo);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new Filme { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacao)
        {
            List<Filme> filmes;
            if(classificacao == null)
                filmes = _context.Filmes.ToList();    
            else
                filmes = _context.Filmes
                                .Where(filme => filme.Classificacao <= classificacao).ToList();

            if (filmes.Any())
            {
                List<ReadCinemaDto> filmesDto = _mapper.Map<List<ReadCinemaDto>>(filmes);
                return Ok(filmes);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperarFilmePorId([FromQuery] int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if(filme != null)
            {

                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                filmeDto.HoraDaConsulta = DateTime.Now;
                return Ok(filmeDto);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaRFilme([FromQuery] int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound(filme);
            }
            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarFilme([FromQuery] int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound(filme);
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
