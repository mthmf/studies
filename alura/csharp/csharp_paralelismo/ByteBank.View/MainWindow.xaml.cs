using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            var contas = r_Repositorio.GetContaClientes();
            var contasThreadQuantidade = contas.Count() / 4;
            var contasParte1 = contas.Take(contasThreadQuantidade);
            var contasParte2 = contas.Skip(contasThreadQuantidade).Take(contasThreadQuantidade);
            var contasParte3 = contas.Skip(contasThreadQuantidade*2).Take(contasThreadQuantidade);
            var contasParte4 = contas.Skip(contasThreadQuantidade * 3).Take(contasThreadQuantidade);


            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            Thread pt1 = new Thread(() =>
            {
                foreach (var conta in contasParte1)
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                }
            });

            Thread pt2 = new Thread(() =>
            {
                foreach (var conta in contasParte2)
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                }
            });


            Thread pt3 = new Thread(() =>
            {
                foreach (var conta in contasParte3)
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                }
            });

            Thread pt4 = new Thread(() =>
            {
                foreach (var conta in contasParte4)
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                }
            });


            pt1.Start();
            pt2.Start();
            pt3.Start();
            pt4.Start();


            while (pt1.IsAlive || pt2.IsAlive || pt3.IsAlive || pt4.IsAlive)
            {
                Thread.Sleep(250);
            }

            var fim = DateTime.Now;

            AtualizarView(resultado, fim - inicio);
        }

        private void AtualizarView(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
