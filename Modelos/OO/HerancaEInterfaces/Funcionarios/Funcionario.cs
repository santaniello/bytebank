using System;

namespace Modelos.OO.HerancaEInterfaces.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; protected set; }

        public Funcionario()
        {
            Console.WriteLine("Construtor sem parâmetros Funcionario");
        }
        
        public Funcionario(double salario ,string cpf)
        {
            Console.WriteLine("Construtor com parâmetros Funcionario");
            Cpf = cpf;
            Salario = salario;
        }

        /**
         * A palavra chave virtual indica que podemos sobreescrever o método GetBonificacao através de alguma classe filha.
         * Em Java, acontece justamente o contrario ...  Cada método criado é virtual por default, ou seja, pode ser sobreescrito e quando colocamos a palavra final
         * ai sim o compilador não deixa você sobreescrever o método...
         *
         * https://codewithshadman.com/no-virtual-keyword-in-java-and-no-final-keyword-in-csharp-explained/
         */
        public virtual void MetodoComImplementacaoPadrao()
        {
           Console.WriteLine("Implementacão Padrão do método: MetodoComImplementacaoPadrao");
        }
        
        /*
         * O modificador de acesso internal protected indica que esse metodo será visivel no projeto Modelos e para todas as classes que herdarem de Funcionario.
         * O unico modificador duplo (combinação de modificadores) que existe é o internal protected  
         * 
         */
        internal protected  abstract double GetBonificacao();

        public abstract void AumentarSalario();
    }
}