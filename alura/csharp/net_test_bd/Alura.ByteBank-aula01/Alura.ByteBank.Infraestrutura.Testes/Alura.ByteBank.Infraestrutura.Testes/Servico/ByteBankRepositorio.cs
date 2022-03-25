using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public class ByteBankRepositorio : IByteBackRespositorio
    {

        private readonly List<Cliente> _clientes;
        private readonly List<Agencia> _agencias;
        private readonly List<ContaCorrente> _contas;

        public ByteBankRepositorio()
        {
            _agencias = new List<Agencia>();
            _contas = new List<ContaCorrente>();
            _clientes = new List<Cliente>();
        }


        public List<Agencia> BuscarAgencias()
        {
            return _agencias;
        }

        public List<Cliente> BuscarClientes()
        {
            return _clientes;
        }

        public List<ContaCorrente> BuscarContasCorrentes()
        {
            return _contas;
        }

        public bool AdicionarAgencia(Agencia agencia)
        {
            _agencias.Add(agencia);
            return true;
        }
    }
}
