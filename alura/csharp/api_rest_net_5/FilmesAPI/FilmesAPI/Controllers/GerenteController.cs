using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Gerentes;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new Gerente { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult RecuperarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(f => f.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarGerente([FromQuery] int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(f => f.Id == id);
            if (gerente != null)
            {
                return NotFound(gerente);
            }
            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
