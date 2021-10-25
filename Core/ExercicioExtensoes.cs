using System;
using System.Collections.Generic;
using Modelos.Extensoes;

namespace Core
{
    public class ExercicioExtensoes
    {
        public static void AdicionarVarios()
        {
            List<int> idades = new List<int>();
            idades.AdicionarVarios(1,2,3,4,5);
            foreach (var idade in idades)
            {
                Console.WriteLine(idade);
            }
        }
    }
}