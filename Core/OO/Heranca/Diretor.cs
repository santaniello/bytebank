namespace Core.OO.Heranca
{
    
    /**
     * Implementado Heranca ( : é igual o extends no Java)
     * 
     */
    public class Diretor : Funcionario
    {
        
        /**
         * A palavra chave override indica que estamos sobreescrendo um método da classe pai (Funcionario) ...
         * A palavra chave base aponta para métodos e atributos da nossa classe base ou pai no caso Funcionario 
         * 
         */
        public override double GetBonificacao()
        {
            return Salario + base.GetBonificacao();
        }
    }
}