using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Titulo { get; set; }
        
        public string Diretor { get; set; }

        public string Genero { get; set; }

        public int Classificacao { get; set; }

        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
