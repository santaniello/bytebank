using System;
using System.Collections.Generic;
using Modelos.Extensoes;

namespace Core
{
    public class ExercicioList
    {
        public static void TestarOrdenacaoDeListasDeInteiros()
        {
            List<int> idades = new List<int>();
            idades.AdicionarVarios(7,8,9,10);
            idades.Sort();
            foreach (var idade in idades)
            {
                Console.WriteLine(idade);
            }
        }
        
        public static void TestarOrdenacaoDeListasDeStrings()
        {
            List<string> nomes = new List<string>();
            nomes.AdicionarVarios("Pamela","Ana","Felipe");
            nomes.Sort();
            foreach (var idade in nomes)
            {
                Console.WriteLine(idade);
            }
        }
    }
}