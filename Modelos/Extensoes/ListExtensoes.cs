using System.Collections.Generic;

namespace Modelos.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios(this List<int> lista, params int[] parametros)
        {
            foreach (var valor in parametros)
            {
                lista.Add(valor);
            }
        }
    }
}