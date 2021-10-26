using System;
using System.Collections.Generic;
using System.Linq;
using Modelos.Comparadores;
using Modelos.Extensoes;
using Modelos.OO.Classe;

namespace Core
{
    public class ExercicioList
    {
        public static void TestarOrdenacaoDeListasDeInteiros()
        {
            List<int> idades = new List<int>();
            idades.AdicionarVarios(7, 8, 9, 10);
            idades.Sort();
            foreach (var idade in idades)
            {
                Console.WriteLine(idade);
            }
        }

        public static void TestarOrdenacaoDeListasDeStrings()
        {
            List<string> nomes = new List<string>();
            nomes.AdicionarVarios("Pamela", "Ana", "Felipe");
            nomes.Sort();
            foreach (var idade in nomes)
            {
                Console.WriteLine(idade);
            }
        }

        public static void TestarOrdenacaoDeListasDeContaCorrente()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            contas.Sort();

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }
        
        public static void TestarOrdenacaoDeListasDeContaCorrentePorAgencia()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }
        
        public static void TestarOrdenacaoDeListasDeContaCorrenteUsandoOrderBy()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            var contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }
        
        public static void TestarOrdenacaoDeListasDeContaCorrenteUsandoOrderByComListaPossuindoObjetosNulos()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                null,
                new ContaCorrente(340, 48950),
                null
            };

            var contasOrdenadas = contas.OrderBy(conta =>
            {
                if(conta == null)
                {
                    return int.MaxValue;
                }
                return conta.Numero;
            });
            foreach(var conta in contasOrdenadas)
            {
                if(conta != null)
                {
                    Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
                }
            }
        }
        
        public static void TestarFiltrarContasNaoNulasAtravesDoWhereEDepoisOrdenarComOrderBy()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                null,
                new ContaCorrente(340, 48950),
                null
            };

            var contasOrdenadas = contas
                .Where(conta => conta != null)    
                .OrderBy(conta => conta.Numero);
            foreach(var conta in contasOrdenadas)
            {
               Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }
    }

}