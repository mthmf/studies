﻿

namespace FilmesAPI.Data.Dtos.Sessoes
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioEncerramento { get; set; }
    }
}
