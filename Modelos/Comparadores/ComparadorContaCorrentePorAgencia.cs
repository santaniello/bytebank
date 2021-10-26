using System.Collections.Generic;
using Modelos.OO.Classe;

namespace Modelos.Comparadores
{
    /**Classe que ensinara o método Sort de ContaCorrente a comparar por agencia */ 
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            return  x.CompareTo(y);
        }
    }
}