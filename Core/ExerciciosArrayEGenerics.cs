using System;
using Modelos.ArraysEGenerics;
using Modelos.OO.Classe;

namespace Core
{
    public class ExerciciosArrayEGenerics
    {
        public static void SomarNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length - 1; i+=2)
            {
                int primeiroNumero = numeros[i];
                int segundoNumero = numeros[i+1];

                int soma = primeiroNumero + segundoNumero;

                Console.WriteLine($"{primeiroNumero}+{segundoNumero} = {soma}");
            }
        }

        public static void TestarIndices()
        {
            ListaDeContaCorrente listaDeContas = new ListaDeContaCorrente();
            listaDeContas.AdicionarVarios(
                new ContaCorrente("Joao", 111, 222),
                           new ContaCorrente("Felipe", 111, 222),
                           new ContaCorrente("Felipe", 111, 222),
                           new ContaCorrente("Pedro ", 111, 222),
                           new ContaCorrente("Ademir", 111, 222),
                           new ContaCorrente("Natalia", 111, 222),
                           new ContaCorrente("Jean", 111, 222),
                           new ContaCorrente("Mauricio", 111, 222)
            );
            ContaCorrente[] contasUmCincoQuatro = listaDeContas[1, 5, 4];
            ContaCorrente[] contasDoisQuatro = listaDeContas[2, 4];
            foreach (var conta in contasUmCincoQuatro)
            {
                Console.WriteLine(conta.GetTitular());
            }
        }
        
        public static void TestarListaGenerica()
        {
            ListaGenerica<ContaCorrente> listaDeContas = new ListaGenerica<ContaCorrente>();
            listaDeContas.AdicionarVarios(
                new ContaCorrente("Joao", 111, 222),
                new ContaCorrente("Felipe", 111, 222),
                new ContaCorrente("Felipe", 111, 222),
                new ContaCorrente("Pedro ", 111, 222),
                new ContaCorrente("Ademir", 111, 222),
                new ContaCorrente("Natalia", 111, 222),
                new ContaCorrente("Jean", 111, 222),
                new ContaCorrente("Mauricio", 111, 222)
            );
            for(int x = 0; x < listaDeContas.Tamanho; x++)
            {
                Console.WriteLine(listaDeContas[x].GetTitular());
            }
        }
        
        public static void TestarArrays()
        {
            ArrayDeIdades idades = new ArrayDeIdades(5);
            idades.TestarArray();
            ArrayDeContasCorrentes contasCorrentes = new ArrayDeContasCorrentes();
            contasCorrentes.TestarArray();
        }
        
        public static void TestarListaPropria()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente(capacidadeInicial: 1);
            ContaCorrente contaFelipe = new ContaCorrente(555,555555);
            lista.Adicionar(contaFelipe);
            lista.Adicionar(new ContaCorrente(345, 23462));
            lista.Adicionar(new ContaCorrente(363, 22451));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            lista.Adicionar(new ContaCorrente(735, 23552));
            
            lista.EscreverNaTela();
            lista.Remover(contaFelipe);
            lista.EscreverNaTela();
            int r = lista.getIndex(contaFelipe);
            Console.WriteLine(r);


        }
    }
}