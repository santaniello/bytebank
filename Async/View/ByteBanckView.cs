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
        
          public void BtnProcessar_Click()
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
    }
}