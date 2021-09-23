using AutoMapper;
using FilmesAPI.Data.Dtos.Sessoes;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>().ForMember(dto => dto.HorarioInicio,
                    opts => opts.MapFrom(
                            dto => dto.HorarioTermino.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
