

using System;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }

        public Operador()
        {
            Matricula = new Guid().ToString().Substring(0,8);
        }

        public override string ToString()
        {
            return $"Operador: {Nome} \n Matricula: {Matricula}";
        }
    }
}
