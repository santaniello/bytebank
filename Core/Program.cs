using System;

namespace Um_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaPaulo = new ContaCorrente();
            contaPaulo.SetTitular("Paulo");
            contaPaulo.Agencia = 888;
            contaPaulo.Numero = 999;
            contaPaulo.Saldo = 100;
            Console.WriteLine(contaPaulo.GetTitular());
            Console.WriteLine(contaPaulo.Numero);
            Console.WriteLine(contaPaulo.Agencia);
            Console.WriteLine(contaPaulo.Saldo);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
            
            ContaCorrente contaJoao = new ContaCorrente("Joao",111,222);
            contaJoao.Saldo = 333;
            Console.WriteLine(contaJoao.GetTitular());
            Console.WriteLine(contaJoao.Numero);
            Console.WriteLine(contaJoao.Agencia);
            Console.WriteLine(contaJoao.Saldo);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
        }
    }
}