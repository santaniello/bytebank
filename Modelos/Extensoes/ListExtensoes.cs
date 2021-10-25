using System.Collections.Generic;

namespace Modelos.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] parametros)
        {
            foreach (var valor in parametros)
            {
                lista.Add(valor);
            }
        }
    }
}