using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Gerentes;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateGerenteDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();

        }
    }
}
