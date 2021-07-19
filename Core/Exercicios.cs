using System;
using Core.ArraysEGenerics;
using Core.OO.Classe;

namespace Core
{
    public class Exercicios
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
    }
}