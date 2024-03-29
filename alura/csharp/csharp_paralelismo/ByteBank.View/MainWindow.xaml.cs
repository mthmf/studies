﻿using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using ByteBank.View.Utils;
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
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;
            _cts = new CancellationTokenSource();
            
            var contas = r_Repositorio.GetContaClientes();
            PgsProgresso.Maximum = contas.Count();
            LimparView();
            var inicio = DateTime.Now;
            var progress = new Progress<string>(str => PgsProgresso.Value++);
            //var progress = new ByteBankProgress<string>(str => PgsProgresso.Value

            try
            {
                var resultado = await ConsolidarContas(contas, progress, _cts.Token);
                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }
            catch (Exception)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário";
            } finally
            {
                BtnProcessar.IsEnabled = true;
                BtnCancelar.IsEnabled = false;

            }

        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, IProgress<string> progresso, CancellationToken cancellationToken)
        {
            var tasks = contas.Select(conta => Task.Factory.StartNew(() => {
                cancellationToken.ThrowIfCancellationRequested();

                var resultadoConsolidacao = r_Servico.ConsolidarMovimentacao(conta, cancellationToken);
                progresso.Report(resultadoConsolidacao);

                cancellationToken.ThrowIfCancellationRequested();
                return resultadoConsolidacao;
            }, cancellationToken));
            return await Task.WhenAll(tasks);

        }

        private void AtualizarView(string[] result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
            _cts.Cancel();
        }


        private void LimparView()
        {
            LstResultados.ItemsSource = null;
            PgsProgresso.Value = 0;
            TxtTempo.Text = null;
        }
    }
}
