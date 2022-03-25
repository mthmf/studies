

using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using System;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public interface IPixRepositorio
    {
        public PixDto ConsultaPix(Guid pix);

    }
}
