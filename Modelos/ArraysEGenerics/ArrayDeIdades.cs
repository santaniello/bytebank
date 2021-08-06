using System;

namespace Modelos.ArraysEGenerics
{
    public class ArrayDeIdades
    {
        private int[] idades;

        public ArrayDeIdades(int size)
        {
            idades = new int[size];
        }

        public void TestarArray()
        {
            idades[0] = 1;
            idades[1] = 2;
            idades[2] = 3;
            idades[3] = 4;
            idades[4] = 5;

            for (int i = 0; i < idades.Length; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Acessando o array idades no indice {i}");
                Console.WriteLine($"Valor de idades[{i}] = {idade}");
            }
        }
    }
}