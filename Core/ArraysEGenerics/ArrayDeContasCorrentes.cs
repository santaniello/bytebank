using System;
using Core.OO.Classe;

namespace Core.ArraysEGenerics
{
    public class ArrayDeContasCorrentes
    {
        private ContaCorrente[] contasCorrente;

        public ArrayDeContasCorrentes()
        {
            // Acucar sintatico para criação de arrays em C#
            contasCorrente = new ContaCorrente[]
            {
                new ContaCorrente(111, 555555),
                new ContaCorrente(222, 888888),
                new ContaCorrente(777, 999999),
            };
        }
        
        public void TestarArray()
        {
            for (int i = 0; i < contasCorrente.Length; i++)
            {
                ContaCorrente contaAtual = contasCorrente[i];
                Console.WriteLine($"Conta {i} {contaAtual.Numero}");
            }
        }
    }
}