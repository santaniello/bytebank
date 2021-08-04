using System;
using System.IO;
using Core.OO.Classe;

namespace Core
{
    public class ExerciciosDisposable
    {
        public static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            
            // LeitorDeArquivo leitor = null;
            // try
            // {
            //     leitor = new LeitorDeArquivo("contas.txt");
            //     leitor.LerProximaLinha();
            //     leitor.LerProximaLinha();
            //     leitor.LerProximaLinha();
            // }
            // catch(IOException e)
            // {
            //     Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
            // }
            // finally
            // {
            //     if(leitor != null)
            //     {
            //         leitor.Fechar();
            //     }
            // }
        }   
    }
}