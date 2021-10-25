using System;
using Modelos.OO.Classe;
using Modelos.OO.Exception;

namespace Core
{
    public class ExerciciosOO
    {
        public static void TestarUsoDeClasse()
        {
            ContaCorrente contaPaulo = new ContaCorrente(888,999);
            contaPaulo.SetTitular("Paulo");
            // contaPaulo.Agencia = 888;
            // contaPaulo.Numero = 999;
            contaPaulo.Saldo = 100;
            Console.WriteLine(contaPaulo.GetTitular());
            Console.WriteLine(contaPaulo.Numero);
            Console.WriteLine(contaPaulo.Agencia);
            Console.WriteLine(contaPaulo.Saldo);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            ContaCorrente contaJoao = new ContaCorrente("Joao", 111, 222);
            contaJoao.Saldo = 333;
            Console.WriteLine(contaJoao.GetTitular());
            Console.WriteLine(contaJoao.Numero);
            Console.WriteLine(contaJoao.Agencia);
            Console.WriteLine(contaJoao.Saldo);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            try
            {
                //ContaCorrente contaInvalida = new ContaCorrente(0, 0);
                ContaCorrente contaInvalida = new ContaCorrente(6666, 7777);
                contaInvalida.Saldo = 100;
                contaInvalida.Sacar(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ParamName);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}