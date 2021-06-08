using System;
using Core.OO.Classe;
using Core.OO.Heranca;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestarUsoDeClasse();
            TestarUsoDeHeranca();
        }

        static void TestarUsoDeClasse()
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

            ContaCorrente contaJoao = new ContaCorrente("Joao", 111, 222);
            contaJoao.Saldo = 333;
            Console.WriteLine(contaJoao.GetTitular());
            Console.WriteLine(contaJoao.Numero);
            Console.WriteLine(contaJoao.Agencia);
            Console.WriteLine(contaJoao.Saldo);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
        }

        static void TestarUsoDeHeranca()
        {
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            Funcionario carlos = new Funcionario();
            carlos.Nome = "Carlos";
            carlos.Cpf = "546.879.157-20";
            carlos.Salario = 2000;
            
            gerenciador.Registrar(carlos);
            
            Diretor roberta = new Diretor("454.658.148-3");
            roberta.Nome = "Roberta";
            roberta.Cpf = "454.658.148-3";
            roberta.Salario = 5000;

            Funcionario robertaTeste = roberta;

            Console.WriteLine("Bonificacao de uma referencia de Diretor: " + roberta.GetBonificacao());
            Console.WriteLine("Bonificacao de uma referencia de Funcionario: " + robertaTeste.GetBonificacao());


            gerenciador.Registrar(roberta);

            Console.WriteLine(carlos.Nome);
            Console.WriteLine(carlos.GetBonificacao());

            Console.WriteLine(roberta.Nome);
            Console.WriteLine(roberta.GetBonificacao());

            Console.WriteLine("Total de bonificações: " + gerenciador.GetTotalBonificacao());

            Console.ReadLine();
        }
    }
}