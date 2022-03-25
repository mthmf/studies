
using System.Collections.Generic;
using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public interface IByteBackRespositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();
        public List<ContaCorrente> BuscarContasCorrentes();

    }
}
