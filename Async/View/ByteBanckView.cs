using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Async.Model;
using Async.Repository;
using Async.Service;

namespace Async.View
{
    public class ByteBanckView
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public ByteBanckView(ContaClienteRepository rRepositorio, ContaClienteService rServico)
        {
            r_Repositorio = rRepositorio;
            r_Servico = rServico;
        }
        
          public void BtnProcessar_Click_Threads()
        {
            var contas = r_Repositorio.GetContaClientes();

            var contasQuantidadePorThread = contas.Count() / 4;
            
            var contas_parte1 = contas.Take(contasQuantidadePorThread);
            var contas_parte2 = contas.Skip(contasQuantidadePorThread).Take(contasQuantidadePorThread);
            var contas_parte3 = contas.Skip(contasQuantidadePorThread*2).Take(contasQuantidadePorThread);
            var contas_parte4 = contas.Skip(contasQuantidadePorThread*3);

            var resultado = new List<string>();

            ImprimirProcessamento(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            Thread thread_parte1 = new Thread(() =>
            {
                foreach (var conta in contas_parte1)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte2 = new Thread(() =>
            {
                foreach (var conta in contas_parte2)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte3 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });
            Thread thread_parte4 = new Thread(() =>
            {
                foreach (var conta in contas_parte4)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            thread_parte1.Start();
            thread_parte2.Start();
            thread_parte3.Start();
            thread_parte4.Start();

            while (thread_parte1.IsAlive || thread_parte2.IsAlive
                || thread_parte3.IsAlive || thread_parte4.IsAlive )
            {
                Thread.Sleep(250);
                //Não vou fazer nada
            }
            
            var fim = DateTime.Now;

            ImprimirProcessamento(resultado, fim - inicio);
        }
          
          public void BtnProcessar_Click_TASKS()
          {
              var contas = r_Repositorio.GetContaClientes();
            
              var resultado = new List<string>();

              ImprimirProcessamento(new List<string>(), TimeSpan.Zero);

              var inicio = DateTime.Now;
            
              var contasTarefas = contas.Select(conta =>
              {
                  return Task.Factory.StartNew(() =>
                  {

                      var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                      resultado.Add(resultadoConta);
                  });
              }).ToArray();

              Task.WhenAll(contasTarefas) // Aguarda a execução de todas as tasks
                  .ContinueWith(task => // Encadeia a uma Task em outra
                  {
                      var fim = DateTime.Now;
                      ImprimirProcessamento(resultado, fim - inicio);
                  }).Wait();
          }

          public async Task BtnProcessar_Click_Async_Await()
          {

              var contas = r_Repositorio.GetContaClientes();
           
              ImprimirProcessamento(new List<string>(), TimeSpan.Zero);

              var inicio = DateTime.Now;

              var resultado = await ConsolidarContas(contas);

              var fim = DateTime.Now;
             
              ImprimirProcessamento(resultado, fim - inicio);
              
          }
          
          public async Task BtnProcessar_Click_Async_Await_Com_Progress()
          {
              var contas = r_Repositorio.GetContaClientes();
           
              ImprimirProcessamento(new List<string>(), TimeSpan.Zero);

              int progressoMaximo = contas.Count();

              var inicio = DateTime.Now;

              int statusAtual = 0;
              
              var progresso = new Progress<String>(str =>
              {
                  statusAtual++;
                  Console.WriteLine("O Status atual é de : " + statusAtual);
              });

              var resultado = await ConsolidarContasComBarraDeProgresso(contas,progresso);

              var fim = DateTime.Now;
             
              ImprimirProcessamento(resultado, fim - inicio);
              
          }
          
        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas)
        {
              var tasks = contas.Select(conta =>
                  Task.Factory.StartNew(() => r_Servico.ConsolidarMovimentacao(conta))
              );

              return await Task.WhenAll(tasks);
        }
        
        private async Task<string[]> ConsolidarContasComBarraDeProgresso(IEnumerable<ContaCliente> contas, IProgress<String> progresso)
        {
            var tasks = contas.Select(conta =>
                Task.Factory.StartNew(() =>
                {
                    var movimentoConsolidado = r_Servico.ConsolidarMovimentacao(conta);
                    progresso.Report(movimentoConsolidado);
                    return movimentoConsolidado;
                })
            );

            return await Task.WhenAll(tasks);
        }


        private void ImprimirProcessamento(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine(mensagem);
        }
        
        private void ImprimirProcessamento(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine(mensagem);
        }
    }
}