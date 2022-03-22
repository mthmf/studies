using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Modelos
{
    public class Patio
    {
       
        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }
        private List<Veiculo> veiculos;
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }
        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }    
        public Operador Operador { get; set; }


        public double TotalFaturado()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            GerarTicket(veiculo);
            Veiculos.Add(veiculo);            
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo procurado = null;
            string informacao=string.Empty;

            foreach (Veiculo v in this.Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Tipo == TipoVeiculo.Automovel)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;

                    }
                    if (v.Tipo == TipoVeiculo.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }
                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n "      +
                                             "Permanência: {2: HH:mm:ss} \n "       +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    this.Faturado = this.Faturado + valorASerCobrado;
                    break;
                }

            }
            if (procurado != null)
            {
                this.Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }

        public Veiculo PesquisaVeiculo(string idTicker)
        {
            var veiculo = veiculos.FirstOrDefault(v => v.IdTicket.Equals(idTicker));

            return veiculo;
        }

        public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
        {
            var veiculoTemp = veiculos.FirstOrDefault(v => v.Placa.Equals(veiculoAlterado.Placa));

            if (veiculoTemp != null)
                veiculoTemp.AlterarDadosVeiculo(veiculoAlterado);


            return veiculoTemp;
        }

        private void GerarTicket(Veiculo veiculo)
        {
            veiculo.IdTicket = new Guid().ToString().Substring(0, 5);
            string ticket = "### Ticket Estacionametno Alura ###" +
                            $"Data/Hora: {DateTime.Now}" +
                            $"Identificador: {veiculo.IdTicket}" +
                            $"Placa: {veiculo.Placa}"+
                            $"Operador: {Operador.Nome}";
            veiculo.Ticket = ticket;
        }
    }
}
