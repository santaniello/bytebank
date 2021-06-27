using System;

namespace Core.ArraysEGenerics
{
    public class ArrayDeIdades
    {
        public void TestarArray()
        {
            int[] idades = new int[5];
            idades[0] = 1;
            idades[1] = 2;
            idades[2] = 3;
            idades[3] = 4;
            idades[4] = 5;

            for (int i = 0; i < idades.Length; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }
    }
}