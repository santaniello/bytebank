using System;

namespace Core.OO.Heranca
{
    
    /**
     * Implementado Heranca ( : é igual o extends no Java)
     * 
     */
    public class Diretor : FuncionarioAutenticavel
    {
        
        // /**
        //  * O construtor sem parâmetros da classe Diretor chamará antes de tudo o construtor sem parâmetros
        //  * da classe base Funcionario().         
        //  */
        // public Diretor()
        // {
        //     Console.WriteLine("Construtor sem parâmetros Diretor");
        // }
        
        /**
         * Aqui estamos chamando um construtor da classe base e passando o CPF
         * a construção :base(cpf) é o mesmo que this(cpf) no Java.
         *
         * OBS: Lembrando que no caso de um construtor não parametrico na classe derivada (Diretor),
         * primeiro será invocado o construtor sem parâmetros da classe base (Funcionario) sem a necessidade
         * de colocar :base() como foi demonstrado no construtor acima.
         */
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Construtor com parâmetros Diretor");
        }

        /**
         * A palavra chave override indica que estamos sobreescrendo um método da classe pai (Funcionario) ...
         * A palavra chave base aponta para métodos e atributos da nossa classe base ou pai no caso Funcionario 
         * 
         */
        public override void MetodoComImplementacaoPadrao()
        {
            Console.WriteLine("Sobreescrita do método: MetodoComImplementacaoPadrao");
        }

      
        public override double GetBonificacao()
        {
            return Salario + 0.5;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }
    }
}