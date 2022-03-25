using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public class PixRepositorio : IPixRepositorio
    {
        public List<PixDto> Pixs { get; set; }

        public PixRepositorio()
        {
            Pixs = new List<PixDto>()
            {
                new PixDto(){ Chave = new Guid("asdfa125-asdad1"), Saldo = 126.9}
            };
        }
        public PixDto ConsultaPix(Guid pix)
        {
            throw new NotImplementedException();
        }
    }
}
